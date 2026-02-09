using COMMON;
using System;
using System.Data;
using DAL;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENTITY.Model;
using DAL.Reports;

namespace SayyarahCars.Admin
{
    public partial class Document_Auction_Kanri : System.Web.UI.Page
    {
        clsOtherReport clsOtherReport = new clsOtherReport();
        public CommonFunction cmf = new CommonFunction();
        DocumentAuctionKanri documentAuctionKanri = new DocumentAuctionKanri();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetAllMasterData();
            }
        }

        public void GetAllMasterData()
        {
            try
            {
                ds = clsOtherReport.GetDocumentMasterData();
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
                    ddlPortName.Items.Clear();
                    ddlPortName.DataSource = ds.Tables["Table1"];
                    ddlPortName.DataTextField = "PortName";
                    ddlPortName.DataValueField = "ID";
                    ddlPortName.DataBind();
                    ddlPortName.Items.Insert(0, new ListItem("Select port name", "0"));
                }
                if (ds.Tables["Table2"].Rows.Count > 0)
                {
                    ddlCountry.Items.Clear();
                    ddlCountry.DataSource = ds.Tables["Table2"];
                    ddlCountry.DataTextField = "CountryName";
                    ddlCountry.DataValueField = "Id";
                    ddlCountry.DataBind();
                    ddlCountry.Items.Insert(0, new ListItem("Select country name", "0"));
                }
                if (ds.Tables["Table4"].Rows.Count > 0)
                {
                    ddlCarStatus.Items.Clear();
                    ddlCarStatus.DataSource = ds.Tables["Table4"];
                    ddlCarStatus.DataTextField = "CarStatus";
                    ddlCarStatus.DataValueField = "Id";
                    ddlCarStatus.DataBind();
                    ddlCarStatus.Items.Insert(0, new ListItem("Select car status", "0"));
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        public void GetAllData()
        {
            try
            {
                documentAuctionKanri.AuctionName = ddlAuctionName.SelectedValue;
                documentAuctionKanri.AuctionDate = txtAuctionDate.Text.Trim();
                documentAuctionKanri.PortName = ddlPortName.SelectedValue;
                documentAuctionKanri.ChassisNo = txtchassis.Text.Trim();
                documentAuctionKanri.InvoiceType = ddlInvoiceType.SelectedValue;
                documentAuctionKanri.Reauction = ddlReauction.SelectedValue;
                documentAuctionKanri.Country = ddlCountry.SelectedValue;
                documentAuctionKanri.NoPlate = ddlNoPlate.SelectedValue;
                documentAuctionKanri.Urgent = ddlUrgent.SelectedValue;
                documentAuctionKanri.CarStatus = ddlCarStatus.SelectedValue;
                documentAuctionKanri.UID = Convert.ToInt32(Session["AID"]);
                int pageNo = 1;
                int pageSize = Convert.ToInt32(ddlSortBy.SelectedValue);
                GridView1.PageSize = pageSize;
                ds = clsOtherReport.GetDocumentAuctionkanri(documentAuctionKanri, pageNo, pageSize);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ViewState["DataTable"] = ds.Tables[0];
                    GridView1.PageSize = Convert.ToInt32(ddlSortBy.SelectedValue);
                    GridView1.VirtualItemCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
                    GridView1.DataSource = ds.Tables[0];
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = ds.Tables[0];
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        public void GetAllData(int pageNo)
        {
            try
            {
                documentAuctionKanri.AuctionName = ddlAuctionName.SelectedValue;
                documentAuctionKanri.AuctionDate = txtAuctionDate.Text.Trim();
                documentAuctionKanri.PortName = ddlPortName.SelectedValue;
                documentAuctionKanri.ChassisNo = txtchassis.Text.Trim();
                documentAuctionKanri.InvoiceType = ddlInvoiceType.SelectedValue;
                documentAuctionKanri.Reauction = ddlReauction.SelectedValue;
                documentAuctionKanri.Country = ddlCountry.SelectedValue;
                documentAuctionKanri.NoPlate = ddlNoPlate.SelectedValue;
                documentAuctionKanri.Urgent = ddlUrgent.SelectedValue;
                documentAuctionKanri.CarStatus = ddlCarStatus.SelectedValue;
                documentAuctionKanri.UID = Convert.ToInt32(Session["AID"]);
                int pageSize = Convert.ToInt32(ddlSortBy.SelectedValue);
                GridView1.PageSize = pageSize;
                ds = clsOtherReport.GetDocumentAuctionkanri(documentAuctionKanri, pageNo, pageSize);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ViewState["DataTable"] = ds.Tables[0];
                    GridView1.PageSize = Convert.ToInt32(ddlSortBy.SelectedValue);
                    GridView1.VirtualItemCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
                    GridView1.DataSource = ds.Tables[0];
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = ds.Tables[0];
                    GridView1.DataBind();
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
            GetAllData();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GetAllData(e.NewPageIndex + 1);
        }
    }
}