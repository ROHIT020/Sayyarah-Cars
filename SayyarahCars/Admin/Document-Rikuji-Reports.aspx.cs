using COMMON;
using DAL;
using DAL.Reports;
using ENTITY;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SayyarahCars.Admin
{
    public partial class Document_Rikuji_Reports : System.Web.UI.Page
    {
        public CommonFunction cmf = new CommonFunction();
        DataSet ds = new DataSet();
        clsOtherReport clsOtherReport = new clsOtherReport();
        DocumentRikujiReport documentRikujiReport = new DocumentRikujiReport();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetAllMasterData();
                btnDownload.Visible = false;
                //procedure name = (DocumentRikujiReport) but it's not done only preparing
            }
        }
        public void GetAllMasterData()
        {
            try
            {
                ds = clsOtherReport.GetRikujiReportMasterData();
                if (ds.Tables["Table"].Rows.Count > 0)
                {
                    ddlSoldCountry.Items.Clear();
                    ddlSoldCountry.DataSource = ds.Tables["Table"];
                    ddlSoldCountry.DataTextField = "CountryName";
                    ddlSoldCountry.DataValueField = "Id";
                    ddlSoldCountry.DataBind();
                    ddlSoldCountry.Items.Insert(0, new ListItem("Select country name", "0"));
                }

                if (ds.Tables["Table1"].Rows.Count > 0)
                {
                    ddlPortName.Items.Clear();
                    ddlPortName.DataSource = ds.Tables["Table1"];
                    ddlPortName.DataTextField = "PortName";
                    ddlPortName.DataValueField = "ID";
                    ddlPortName.DataBind();
                    ddlPortName.Items.Insert(0, new ListItem("Select port name", "0"));
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        public void GetAllRikujiData()
        {
            try
            {
                documentRikujiReport.RikujiDate = txtRikujiDate.Text.Trim();
                documentRikujiReport.SoldCountry = ddlSoldCountry.SelectedValue;
                documentRikujiReport.ChassisNo = txtchassis.Text.Trim();
                documentRikujiReport.PortName = ddlPortName.SelectedValue;
                documentRikujiReport.Urgent = ddlUrgent.SelectedValue;
                documentRikujiReport.InvoiceType = ddlInvoiceType.SelectedValue;
                documentRikujiReport.ReAuction = ddlReauction.SelectedValue;
                documentRikujiReport.UID = Session["AID"].ToString();
                int pageNo = 1;
                int pageSize = Convert.ToInt32(ddlSortBy.SelectedValue);
                GridView1.PageSize = pageSize;
                ds= clsOtherReport.GetDocumentByRikujiReport(documentRikujiReport, pageNo, pageSize);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ViewState["DataTable"] = ds.Tables[0];
                    GridView1.PageSize = int.Parse(ddlSortBy.SelectedValue);
                    GridView1.VirtualItemCount = Convert.ToInt32(ds.Tables[0].Rows[1][0]);
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

        public void GetAllRikujiData(int pageNo)
        {
            try
            {
                documentRikujiReport.RikujiDate = txtRikujiDate.Text.Trim();
                documentRikujiReport.SoldCountry = ddlSoldCountry.SelectedValue;
                documentRikujiReport.ChassisNo = txtchassis.Text.Trim();
                documentRikujiReport.PortName = ddlPortName.SelectedValue;
                documentRikujiReport.Urgent = ddlUrgent.SelectedValue;
                documentRikujiReport.InvoiceType = ddlInvoiceType.SelectedValue;
                documentRikujiReport.ReAuction = ddlReauction.SelectedValue;
                documentRikujiReport.UID = Session["AID"].ToString();
                int pageSize = Convert.ToInt32(ddlSortBy.SelectedValue);
                GridView1.PageSize = pageSize;
                ds = clsOtherReport.GetDocumentByRikujiReport(documentRikujiReport, pageNo, pageSize);
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
            GetAllRikujiData();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GetAllRikujiData(e.NewPageIndex + 1);
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
                Response.AddHeader("content-disposition", string.Format("attachment; filename=Document-Rikuji-Report.xls"));
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
    }
}