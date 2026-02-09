using COMMON;
using DAL;
using ENTITY;
using ENTITY.Model;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Reports;

namespace SayyarahCars.Admin
{
    public partial class Document_Another_Status : System.Web.UI.Page
    {
        public CommonFunction cmf = new CommonFunction();
        DataSet ds = new DataSet();
        clsOtherReport clsOtherReport = new clsOtherReport();
        DocAnotherStatus docAnotherStatus = new DocAnotherStatus();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                btnDownload.Visible = false;
            }
        }

        public void GetAllDocAnotherStaus()
        {
            try
            {
                docAnotherStatus.DocChangeDate = txtDocumentChangeDate.Text.Trim();
                docAnotherStatus.ChassisNo = txtchassis.Text.Trim();
                docAnotherStatus.InvoiceType = ddlInvoiceType.SelectedValue;
                docAnotherStatus.Reauction = ddlReauction.SelectedValue;
                docAnotherStatus.UID = Convert.ToInt32(Session["AID"]);
                int pageNo = 1;
                int pageSize = Convert.ToInt32(ddlSortBy.SelectedValue);
                GridView1.PageSize = pageSize;

                ds = clsOtherReport.GetDocAnotherStatus(docAnotherStatus, pageNo, pageSize);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ViewState["DataTable"] = ds.Tables[0];
                    GridView1.PageSize = int.Parse(ddlSortBy.SelectedValue);
                    GridView1.VirtualItemCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
                    GridView1.DataSource = ds.Tables[0];
                    GridView1.DataBind();
                    btnDownload.Visible = true;
                }
                else
                {
                    GridView1.DataSource = ds.Tables[0];
                    GridView1.DataBind();
                    btnDownload.Visible = false;
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        public void GetAllDocAnotherStaus(int pageNo)
        {
            try
            {
                docAnotherStatus.DocChangeDate = txtDocumentChangeDate.Text.Trim();
                docAnotherStatus.ChassisNo = txtchassis.Text.Trim();
                docAnotherStatus.InvoiceType = ddlInvoiceType.SelectedValue;
                docAnotherStatus.Reauction = ddlReauction.SelectedValue;
                docAnotherStatus.UID = Convert.ToInt32(Session["AID"]);
                int pageSize = Convert.ToInt32(ddlSortBy.SelectedValue);
                GridView1.PageSize = pageSize;

                ds = clsOtherReport.GetDocAnotherStatus(docAnotherStatus, pageNo, pageSize);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ViewState["DataTable"] = ds.Tables[0];
                    GridView1.PageSize = int.Parse(ddlSortBy.SelectedValue);
                    GridView1.VirtualItemCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
                    GridView1.DataSource = ds.Tables[0];
                    GridView1.DataBind();
                    btnDownload.Visible = true;
                }
                else
                {
                    GridView1.DataSource = ds.Tables[0];
                    GridView1.DataBind();
                    btnDownload.Visible = false;
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            GetAllDocAnotherStaus();
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["DataTable"];
            CreateExcelFile(dt);
        }

        public void CreateExcelFile(DataTable Excel)
        {
            try
            {
                Response.ClearContent();
                Response.AddHeader("content-disposition", string.Format("attachment; filename=Document-Anothet-Status.xls"));
                Response.ContentEncoding = System.Text.Encoding.Unicode;
                Response.ContentType = "application/ms-excel";
                Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
                string space = "";
                foreach (DataColumn dcolumn in Excel.Columns)
                {
                    Response.Write(space + dcolumn.ColumnName);
                    space = "\t";
                }
                Response.Write("\n");
                int countcolumn;
                foreach (DataRow dr in Excel.Rows)
                {
                    space = "";
                    for (countcolumn = 0; countcolumn < Excel.Columns.Count; countcolumn++)
                    {
                        Response.Write(space + dr[countcolumn].ToString().Trim());
                        space = "\t";
                    }
                    Response.Write("\n");
                }
                HttpContext.Current.Response.End();
            }
            catch (Exception ex)
            {
                CommonFunction.DisplayAlert(this, ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GetAllDocAnotherStaus(e.NewPageIndex + 1);
        }
    }
}