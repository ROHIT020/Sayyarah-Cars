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
    public partial class Yearly_Report : System.Web.UI.Page
    {
        public CommonFunction cmf = new CommonFunction();
        Report report = new Report();
        DataSet ds = new DataSet();
        YearlyReport yearlyReport = new YearlyReport();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                btnDownload.Visible = false;
                GetMasterData();
            }
        }

        public void GetMasterData()
        {
            try
            {
                ds = report.GetYearlyRptMasterData();
                if (ds.Tables["Table"].Rows.Count > 0)
                {
                    ddlProductType.Items.Clear();
                    ddlProductType.DataSource = ds.Tables["Table"];
                    ddlProductType.DataTextField = "CategoryName";
                    ddlProductType.DataValueField = "ID";
                    ddlProductType.DataBind();
                    ddlProductType.Items.Insert(0, new ListItem("Select Product type", "0"));
                }
                if (ds.Tables["Table1"].Rows.Count > 0)
                {
                    ddlClient.Items.Clear();
                    ddlClient.DataSource = ds.Tables["Table1"];
                    ddlClient.DataTextField = "Fullname";
                    ddlClient.DataValueField = "id";
                    ddlClient.DataBind();
                    ddlClient.Items.Insert(0, new ListItem("Select Client name", "0"));
                }
                if (ds.Tables["Table2"].Rows.Count > 0)
                {
                    ddlAuctionName.Items.Clear();
                    ddlAuctionName.DataSource = ds.Tables["Table2"];
                    ddlAuctionName.DataTextField = "Name";
                    ddlAuctionName.DataValueField = "Id";
                    ddlAuctionName.DataBind();
                    ddlAuctionName.Items.Insert(0, new ListItem("Select Auction", "0"));
                }
                if (ds.Tables["Table3"].Rows.Count > 0)
                {
                    ddlCountryName.Items.Clear();
                    ddlCountryName.DataSource = ds.Tables["Table3"];
                    ddlCountryName.DataTextField = "CountryName";
                    ddlCountryName.DataValueField = "Id";
                    ddlCountryName.DataBind();
                    ddlCountryName.Items.Insert(0, new ListItem("Select Country", "0"));
                }
                if (ds.Tables["Table4"].Rows.Count > 0)
                {
                    ddlCarStatus.Items.Clear();
                    ddlCarStatus.DataSource = ds.Tables["Table4"];
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
            GetAllYearlyData();
        }

        public void GetAllYearlyData()
        {
            try
            {
                yearlyReport.ProductType = ddlProductType.SelectedValue;
                yearlyReport.ChassisNo = txtChassis.Text.Trim();
                yearlyReport.Client = ddlClient.SelectedValue;
                yearlyReport.AuctionName = ddlAuctionName.SelectedValue;
                yearlyReport.DateFrom = txtDateFrom.Text.Trim();
                yearlyReport.DateTo = txtDateTo.Text.Trim();
                yearlyReport.Urgent = ddlUrgent.SelectedValue;
                yearlyReport.CountryName = ddlCountryName.SelectedValue;
                yearlyReport.RegDate = txtRegistrationDate.Text.Trim();
                yearlyReport.ProductIn = ddlProductIn.SelectedValue;
                yearlyReport.CarStatus = ddlCarStatus.SelectedValue;
                yearlyReport.MDate = txtMDate.Text.Trim();
                yearlyReport.UID = Convert.ToInt32(Session["AID"]);
                int pageNo = 1;
                int pageSize = Convert.ToInt32(ddlSortBy.SelectedValue);
                ds = report.GetAllYearlyRpt(yearlyReport, pageNo, pageSize);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.PageSize = int.Parse(ddlSortBy.SelectedValue);
                    GridView1.VirtualItemCount = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                    GridView1.DataSource = ds.Tables[0];
                    GridView1.DataBind();
                    ViewState["DataTable"] = ds.Tables[0];
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

        public void GetAllYearlyData(int pageNo)
        {
            try
            {
                yearlyReport.ProductType = ddlProductType.SelectedValue;
                yearlyReport.ChassisNo = txtChassis.Text.Trim();
                yearlyReport.Client = ddlClient.SelectedValue;
                yearlyReport.AuctionName = ddlAuctionName.SelectedValue;
                yearlyReport.DateFrom = txtDateFrom.Text.Trim();
                yearlyReport.DateTo = txtDateTo.Text.Trim();
                yearlyReport.Urgent = ddlUrgent.SelectedValue;
                yearlyReport.CountryName = ddlCountryName.SelectedValue;
                yearlyReport.RegDate = txtRegistrationDate.Text.Trim();
                yearlyReport.ProductIn = ddlProductIn.SelectedValue;
                yearlyReport.CarStatus = ddlCarStatus.SelectedValue;
                yearlyReport.MDate = txtMDate.Text.Trim();
                yearlyReport.UID = Convert.ToInt32(Session["AID"]);
                int pageSize = Convert.ToInt32(ddlSortBy.SelectedValue);
                ds = report.GetAllYearlyRpt(yearlyReport, pageNo, pageSize);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.PageSize = int.Parse(ddlSortBy.SelectedValue);
                    GridView1.VirtualItemCount = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                    GridView1.DataSource = ds.Tables[0];
                    GridView1.DataBind();
                    ViewState["DataTable"] = ds.Tables[0];
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
                Response.AddHeader("content-disposition", string.Format("attachment; filename=Yearly-Report.xls"));
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
            GetAllYearlyData(e.NewPageIndex + 1);
        }
    }
}