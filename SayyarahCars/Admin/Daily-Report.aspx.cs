using COMMON;
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
    public partial class Daily_Report : System.Web.UI.Page
    {
        public CommonFunction cmf = new CommonFunction();
        Report report = new Report();
        DataSet ds = new DataSet();
        DailyReport dailyReport = new DailyReport();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtAuctionDate.Text = DateTime.Now.ToString();
                btnDownload.Visible = false;
                GetMasterData();
            }
        }

        public void GetMasterData()
        {
            try
            {
                ds = report.GetDailyRptMasterData();
                if (ds.Tables["Table"].Rows.Count > 0)
                {
                    ddlCategory.Items.Clear();
                    ddlCategory.DataSource = ds.Tables["Table"];
                    ddlCategory.DataTextField = "CategoryName";
                    ddlCategory.DataValueField = "ID";
                    ddlCategory.DataBind();
                    ddlCategory.Items.Insert(0, new ListItem("Select Category", "0"));
                }
                if (ds.Tables["Table1"].Rows.Count > 0)
                {
                    ddlAuctionName.Items.Clear();
                    ddlAuctionName.DataSource = ds.Tables["Table1"];
                    ddlAuctionName.DataTextField = "Name";
                    ddlAuctionName.DataValueField = "Id";
                    ddlAuctionName.DataBind();
                    ddlAuctionName.Items.Insert(0, new ListItem("Select Auction", "0"));
                }
                if (ds.Tables["Table2"].Rows.Count > 0)
                {
                    ddlTransportName.Items.Clear();
                    ddlTransportName.DataSource = ds.Tables["Table2"];
                    ddlTransportName.DataTextField = "TransportName";
                    ddlTransportName.DataValueField = "Id";
                    ddlTransportName.DataBind();
                    ddlTransportName.Items.Insert(0, new ListItem("Select Transport", "0"));
                }
                if (ds.Tables["Table3"].Rows.Count > 0)
                {
                    ddlCarStatus.Items.Clear();
                    ddlCarStatus.DataSource = ds.Tables["Table3"];
                    ddlCarStatus.DataTextField = "CarStatus";
                    ddlCarStatus.DataValueField = "Id";
                    ddlCarStatus.DataBind();
                    ddlCarStatus.Items.Insert(0, new ListItem("Select Car Status", "0"));
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
            GetAllDailyReportData();
        }

        public void GetAllDailyReportData()
        {
            try
            {
                dailyReport.Category = ddlCategory.SelectedValue;
                dailyReport.AuctionDate = txtAuctionDate.Text.Trim();
                dailyReport.MDate = txtMDate.Text.Trim();
                dailyReport.AuctionName = ddlAuctionName.SelectedValue;
                dailyReport.Urgent = ddlUrgent.SelectedValue;
                dailyReport.TransportName = ddlTransportName.SelectedValue;
                dailyReport.CarStatus = ddlCarStatus.SelectedValue;
                dailyReport.RDateFrom = txtRDateFrom.Text.Trim();
                dailyReport.RDateTo = txtRDateTo.Text.Trim();
                int pageNo = 1;
                int pageSize = Convert.ToInt32(ddlSortBy.SelectedValue);
                ds = report.GetAllDailyReportData(dailyReport, pageNo, pageSize);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ViewState["DataTable"] = ds.Tables[0];
                    GridView1.PageSize = Convert.ToInt32(ddlSortBy.SelectedValue);
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

        public void GetAllDailyReportData(int pageNo)
        {
            try
            {
                dailyReport.Category = ddlCategory.SelectedValue;
                dailyReport.AuctionDate = txtAuctionDate.Text.Trim();
                dailyReport.MDate = txtMDate.Text.Trim();
                dailyReport.AuctionName = ddlAuctionName.SelectedValue;
                dailyReport.Urgent = ddlUrgent.SelectedValue;
                dailyReport.TransportName = ddlTransportName.SelectedValue;
                dailyReport.CarStatus = ddlCarStatus.SelectedValue;
                dailyReport.RDateFrom = txtRDateFrom.Text.Trim();
                dailyReport.RDateTo = txtRDateTo.Text.Trim();
                int pageSize = Convert.ToInt32(ddlSortBy.SelectedValue);
                ds = report.GetAllDailyReportData(dailyReport, pageNo, pageSize);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ViewState["DataTable"] = ds.Tables[0];
                    GridView1.PageSize = Convert.ToInt32(ddlSortBy.SelectedValue);
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
                Response.AddHeader("content-disposition", string.Format("attachment; filename=Daily-Report.xls"));
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
            GetAllDailyReportData(e.NewPageIndex + 1);
        }
    }
}