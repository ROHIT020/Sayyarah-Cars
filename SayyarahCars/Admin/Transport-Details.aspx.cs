using COMMON;
using DAL;
using ENTITY;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SayyarahCars.Admin
{
    public partial class Transport_Details : System.Web.UI.Page
    {
        CommonFunction cmf = new CommonFunction();
        DataSet ds = new DataSet();
        clsAdmin clsAdmin = new clsAdmin();
        public string uid = "0";
        TransportDetailsModel transportDetailsModel = new TransportDetailsModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetMasterData();
            }
        }
        public void GetMasterData()
        {
            try
            {
                ds = clsAdmin.GetMasterDataForTransport();
                if (ds.Tables["Table"].Rows.Count > 0)
                {
                    ddlAuctionHouse.DataSource = ds.Tables["Table"];
                    ddlAuctionHouse.DataTextField = "Name";
                    ddlAuctionHouse.DataValueField = "Id";
                    ddlAuctionHouse.DataBind();
                    ddlAuctionHouse.Items.Insert(0, new ListItem("Select Auction Name", "0"));
                }
                if (ds.Tables["Table1"].Rows.Count > 0)
                {
                    ddlTransport.DataSource = ds.Tables["Table1"];
                    ddlTransport.DataTextField = "TransportName";
                    ddlTransport.DataValueField = "Id";
                    ddlTransport.DataBind();
                    ddlTransport.Items.Insert(0, new ListItem("Select Transport Name", "0"));
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        public void GetAllTransPortData()
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            GetAllData();
        }

        public void GetAllData()
        {
            try
            {
                transportDetailsModel.DateFrom = txtDateFrom.Text.Trim();
                transportDetailsModel.DateTo = txtDateTo.Text.Trim();
                transportDetailsModel.AuctionHouse = ddlAuctionHouse.SelectedValue;
                transportDetailsModel.Transport = ddlTransport.SelectedValue;
                transportDetailsModel.NoPlate = ddlNoPlate.SelectedValue;
                transportDetailsModel.Urgent = ddlUrgent.SelectedValue;


                int pageNo = 1;
                HiddenField1.Value = "1";
                int pageSize = Convert.ToInt32(ddlSortBy.SelectedValue);
                GridView1.PageSize = pageSize;
                ds = clsAdmin.GetAllDataForTransport(transportDetailsModel, pageNo.ToString(), pageSize);
                if (ds.Tables["Table"].Rows.Count > 0)
                {
                    ViewState["DataTable"] = ds.Tables["Table"];
                    GridView1.PageSize = int.Parse(ddlSortBy.SelectedValue);
                    GridView1.VirtualItemCount = Convert.ToInt32(ds.Tables["Table1"].Rows[0][0]);
                    GridView1.DataSource = ds.Tables["Table"];
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = ds.Tables["Table"];
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        public void GetAllDataPagination(int pageNo)
        {
            try
            {
                HiddenField1.Value = pageNo.ToString();
                int pageSize = Convert.ToInt32(ddlSortBy.SelectedValue);
                GridView1.PageSize = pageSize;
                ds = clsAdmin.GetAllDataForTransport(transportDetailsModel, pageNo.ToString(), pageSize);
                if (ds.Tables["Table"].Rows.Count > 0)
                {
                    ViewState["DataTable"] = ds.Tables["Table"];
                    GridView1.PageSize = int.Parse(ddlSortBy.SelectedValue);
                    GridView1.VirtualItemCount = Convert.ToInt32(ds.Tables["Table1"].Rows[0][0]);
                    GridView1.DataSource = ds.Tables["Table"];
                    GridView1.DataBind();
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
            GetAllDataPagination(e.NewPageIndex + 1);
        }
    }
}