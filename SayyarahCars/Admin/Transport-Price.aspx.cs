using COMMON;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SayyarahCars.Admin
{
    public partial class Transport_Price : System.Web.UI.Page
    {
        public CommonFunction cmf = new CommonFunction();
        clsAdmin clsAdmin = new clsAdmin();
        public string uid = "0";
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                binddata();
            }
        }

        public void binddata()
        {
            try
            {
                ds = clsAdmin.ViewTransportAuction();
                if (ds.Tables["Table"].Rows.Count > 0)
                {
                    ddlTransportName.DataSource = ds.Tables["Table"];
                    ddlTransportName.DataTextField = "TransportName";
                    ddlTransportName.DataValueField = "ID";
                    ddlTransportName.DataBind();
                    ddlTransportName.Items.Insert(0, new ListItem("Transport Name", "0"));
                }
                if (ds.Tables["Table1"].Rows.Count > 0)
                {
                    ddlAuctionName.DataSource = ds.Tables["Table1"];
                    ddlAuctionName.DataTextField = "AuctionName";
                    ddlAuctionName.DataValueField = "ID";
                    ddlAuctionName.DataBind();
                    ddlAuctionName.Items.Insert(0, new ListItem("Auction Name", "0"));
                }
            }
            catch (Exception ex)
            {
                CommonFunction.DisplayAlert(this, ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void ddlAuctionName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ds = clsAdmin.viewYardByAuctioId(ddlAuctionName.SelectedValue);
                if (ds != null)
                {
                    ddlYardName.DataSource = ds.Tables["Table"];
                    ddlYardName.DataTextField = "AuctionYard";
                    ddlYardName.DataValueField = "Id";
                    ddlYardName.DataBind();
                    ddlYardName.Items.Insert(0, new ListItem("Select Yard Name", "0"));
                }
            }
            catch (Exception ex)
            {
                CommonFunction.DisplayAlert(this, ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        public void GetAallPort()
        {
            try
            {
                ds = clsAdmin.GetAllPortView();
                if (ds != null || ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                CommonFunction.DisplayAlert(this, ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            GetAallPort();
            btnAddPrice.Visible = true;
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GetAallPort();
        }

        protected void btnAddPrice_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (GridViewRow row in GridView1.Rows)
                {
                    Label lblid = row.FindControl("lblId") as Label;
                    CheckBox chk = row.FindControl("Chkbox") as CheckBox;
                    TextBox txtprice = row.FindControl("txtprice") as TextBox;
                    TextBox txttax = row.FindControl("txttax") as TextBox;
                    if (chk.Checked)
                    {
                        if (Convert.ToDecimal(txtprice.Text) > 0)
                        {
                            int temp = clsAdmin.updateTransportPrice(ddlTransportName.SelectedValue, ddlAuctionName.SelectedValue, ddlYardName.SelectedValue, lblid.Text, txtprice.Text.Trim(), txttax.Text, Session["AID"].ToString());
                            if (temp != 0)
                            {
                                CommonFunction.MessageBox(this, "S", "Record saved successfully!!");
                                cmf.ClearAllControls(Page);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CommonFunction.DisplayAlert(this, ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        
    }
}