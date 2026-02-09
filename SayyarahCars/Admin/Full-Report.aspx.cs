using COMMON;
using DAL;
using DAL.Reports;
using ENTITY.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SayyarahCars.Admin
{
    public partial class Full_Report : System.Web.UI.Page
    {
        public CommonFunction cmf = new CommonFunction();
        DataSet ds = new DataSet();
        clsOtherReport clsOtherReport = new clsOtherReport();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetFullReportmasterData();
                btnDownload.Visible = false;
            }
        }
        public void GetFullReportmasterData()
        {
            try
            {
                ds = clsOtherReport.GetFullReportmasterData();
                if (ds.Tables["Table"].Rows.Count > 0)
                {
                    ddlAuctionName.Items.Clear();
                    ddlAuctionName.DataSource = ds.Tables["Table"];
                    ddlAuctionName.DataTextField = "Name";
                    ddlAuctionName.DataValueField = "Id";
                    ddlAuctionName.DataBind();
                    ddlAuctionName.Items.Insert(0, new ListItem("Select auction name", "0"));
                }
                if (ds.Tables["Table1"].Rows.Count > 0)
                {
                    ddlPortFrom.Items.Clear();
                    ddlPortFrom.DataSource = ds.Tables["Table1"];
                    ddlPortFrom.DataTextField = "PortName";
                    ddlPortFrom.DataValueField = "ID";
                    ddlPortFrom.DataBind();
                    ddlPortFrom.Items.Insert(0, new ListItem("Select port name", "0"));
                }
                if (ds.Tables["Table2"].Rows.Count > 0)
                {
                    ddlSoldCountry.Items.Clear();
                    ddlSoldCountry.DataSource = ds.Tables["Table2"];
                    ddlSoldCountry.DataTextField = "CountryName";
                    ddlSoldCountry.DataValueField = "Id";
                    ddlSoldCountry.DataBind();
                    ddlSoldCountry.Items.Insert(0, new ListItem("Select country name", "0"));
                }
                if (ds.Tables["Table3"].Rows.Count > 0)
                {
                    ddlTransport.Items.Clear();
                    ddlTransport.DataSource = ds.Tables["Table3"];
                    ddlTransport.DataTextField = "TransportName";
                    ddlTransport.DataValueField = "Id";
                    ddlTransport.DataBind();
                    ddlTransport.Items.Insert(0, new ListItem("Select transport name", "0"));
                }
                if (ds.Tables["Table4"].Rows.Count > 0)
                {
                    ddlShipping.Items.Clear();
                    ddlShipping.DataSource = ds.Tables["Table4"];
                    ddlShipping.DataTextField = "ShippingName";
                    ddlShipping.DataValueField = "Id";
                    ddlShipping.DataBind();
                    ddlShipping.Items.Insert(0, new ListItem("Select shipping name", "0"));
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
            AllFullReport();
        }

        public void AllFullReport()
        {
            try
            {
                FullReport fullReport = new FullReport();
                fullReport.ActionDate = txtAuctionDate.Text.Trim();
                fullReport.ActionName = ddlAuctionName.SelectedValue;
                fullReport.PortFrom = ddlPortFrom.SelectedValue;
                fullReport.SoldCountry = ddlSoldCountry.SelectedValue;
                fullReport.RikujiDate = txtRikujiDate.Text.Trim();
                fullReport.Transport = ddlTransport.SelectedValue;
                fullReport.Shipping = ddlShipping.SelectedValue;
                fullReport.ChassisNo = txtchassis.Text.Trim();
                fullReport.Urgent = ddlUrgent.SelectedValue;
                fullReport.UID = Convert.ToInt32(Session["AID"]);
                int pageNo = 1;
                int pageSize = Convert.ToInt32(ddlSortBy.SelectedValue);
                GridView1.PageSize = pageSize;
                ds = clsOtherReport.GetFullReport(fullReport, pageNo, pageSize);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ViewState["DataTable"] = ds.Tables[0];
                    GridView1.PageSize = Convert.ToInt32(ddlSortBy.SelectedValue);
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

        public void AllFullReport(int pageNo)
        {
            try
            {
                FullReport fullReport = new FullReport();
                fullReport.ActionDate = txtAuctionDate.Text.Trim();
                fullReport.ActionName = ddlAuctionName.SelectedValue;
                fullReport.PortFrom = ddlPortFrom.SelectedValue;
                fullReport.SoldCountry = ddlSoldCountry.SelectedValue;
                fullReport.RikujiDate = txtRikujiDate.Text.Trim();
                fullReport.Transport = ddlTransport.SelectedValue;
                fullReport.Shipping = ddlShipping.SelectedValue;
                fullReport.ChassisNo = txtchassis.Text.Trim();
                fullReport.Urgent = ddlUrgent.SelectedValue;
                fullReport.UID = Convert.ToInt32(Session["AID"]);
                int pageSize = Convert.ToInt32(ddlSortBy.SelectedValue);
                GridView1.PageSize = pageSize;
                ds = clsOtherReport.GetFullReport(fullReport, pageNo, pageSize);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ViewState["DataTable"] = ds.Tables[0];
                    GridView1.PageSize = Convert.ToInt32(ddlSortBy.SelectedValue);
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
                Response.AddHeader("content-disposition", string.Format("attachment; filename=Transport-Status.xls"));
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
            AllFullReport(e.NewPageIndex + 1);
        }
    }
}