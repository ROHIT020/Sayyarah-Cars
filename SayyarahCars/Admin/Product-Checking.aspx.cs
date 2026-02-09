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
    public partial class Product_Checking : System.Web.UI.Page
    {
        public CommonFunction cmf = new CommonFunction();
        DataSet ds = new DataSet();
        clsOtherReport clsOtherReport = new clsOtherReport();
        Report report = new Report();
        ProductChecking productChecking = new ProductChecking();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetMasterEmployee();
                GetAllAuctionData();
                btnDownload.Visible = false;
            }
        }
        public void GetMasterEmployee()
        {
            try
            {
                ds = clsOtherReport.GetMasterEmployee();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlCreatedBy.Items.Clear();
                    ddlCreatedBy.DataSource = ds.Tables[0];
                    ddlCreatedBy.DataTextField = "FullName";
                    ddlCreatedBy.DataValueField = "Id";
                    ddlCreatedBy.DataBind();
                    ddlCreatedBy.Items.Insert(0, new ListItem("Select Created by", "0"));
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        public void GetAllAuctionData()
        {
            try
            {
                ds = clsOtherReport.GetAllAuctionData();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlAuctionName.Items.Clear();
                    ddlAuctionName.DataSource = ds.Tables[0];
                    ddlAuctionName.DataTextField = "Name";
                    ddlAuctionName.DataValueField = "Id";
                    ddlAuctionName.DataBind();
                    ddlAuctionName.Items.Insert(0, new ListItem("Select Auction name", "0"));
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
            GetAllProductChecking();
        }

        public void GetAllProductChecking()
        {
            try
            {
                productChecking.CreatedBy = ddlCreatedBy.SelectedValue;
                productChecking.AuctionDate = txtAuctionDate.Text.Trim();
                productChecking.AuctionName = ddlAuctionName.SelectedValue;
                productChecking.Urgent = ddlUrgent.SelectedValue;
                productChecking.ChassisNo = txtchassis.Text.Trim();
                int pageNo = 1;
                int pageSize = Convert.ToInt32(ddlSortBy.SelectedValue);
                int aa = Convert.ToInt32(Session["LID"]);
                ds = report.GetAllProductChecking(productChecking, pageNo, pageSize);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ViewState["DataTable"] = ds.Tables[0];
                    GridView1.PageSize = Convert.ToInt32(ddlSortBy.SelectedValue);
                    GridView1.VirtualItemCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
                    GridView1.DataSource = ds.Tables[0];
                    GridView1.DataBind();
                    btnDownload.Visible = true;
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        public void GetAllProductChecking(int pageNo)
        {
            try
            {
                productChecking.CreatedBy = ddlCreatedBy.SelectedValue;
                productChecking.AuctionDate = txtAuctionDate.Text.Trim();
                productChecking.AuctionName = ddlAuctionName.SelectedValue;
                productChecking.Urgent = ddlUrgent.SelectedValue;
                productChecking.ChassisNo = txtchassis.Text.Trim();
                int pageSize = Convert.ToInt32(ddlSortBy.SelectedValue);
                int aa = Convert.ToInt32(Session["LID"]);
                ds = report.GetAllProductChecking(productChecking, pageNo, pageSize);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ViewState["DataTable"] = ds.Tables[0];
                    GridView1.PageSize = Convert.ToInt32(ddlSortBy.SelectedValue);
                    GridView1.VirtualItemCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
                    GridView1.DataSource = ds.Tables[0];
                    GridView1.DataBind();
                    btnDownload.Visible = true;
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GetAllProductChecking(e.NewPageIndex + 1);
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
                Response.AddHeader("content-disposition", string.Format("attachment; filename=Product-Checking.xls"));
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