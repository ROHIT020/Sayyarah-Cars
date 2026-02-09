using COMMON;
using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SayyarahCars.Admin
{
    public partial class Update_Broker : System.Web.UI.Page
    {
        CommonFunction cmf = new CommonFunction();
        clsAdmin clsA = new clsAdmin();
        public string uid = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["AID"] != null)
                {
                    uid = Session["AID"].ToString();
                }
                if (!IsPostBack)
                {
                    BindDropDown();
                    BindBroker();
                    Divserver.Visible = false;
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }
        public void BindDropDown()
        {
            try
            {
                DataSet ds = clsA.AllDropDownMaster();

                cmf.BindDropDownList(ddlCategory, ds, "CategoryName", "ID",0);
                ddlProduct.Items.Insert(0, new ListItem("--Select Product--", "0"));
               
                cmf.BindDropDownList(ddlAuctionhouse, ds, "Name", "Id",1);
                ddlAuctionhouse.Items.Insert(0, new ListItem("--Select Auction--", "0"));

                cmf.BindDropDownList(ddlShip, ds, "ShipName", "Id", 2);
                ddlShip.Items.Insert(0, new ListItem("--Select Ship--", "0"));

                cmf.BindDropDownList(ddlClient, ds, "ClientName", "id", 3);
                ddlClient.Items.Insert(0, new ListItem("--Select Client--", "0"));

            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }
        public void BindProductDropDown()
        {
            if (ddlCategory.SelectedValue != "0")
            {
                DataSet ds = clsA.GetProductByCategory(Convert.ToInt32(ddlCategory.SelectedValue));
                cmf.BindDropDownList(ddlProduct, ds, "Name", "Id");
                ddlProduct.Items.Insert(0, new ListItem("--Select Product--", "0"));

            }
            else
            {
                ddlProduct.Items.Clear();
                ddlProduct.Items.Insert(0, new ListItem("--Select Product--", "0"));
            }
        }
        protected void BindBroker()
        {
            DataSet ds = clsA.GetBroker();
            ViewState["brokertable"] = ds.Tables[0];
            cmf.BindDropDownList(ddlBrokerName, ds, "BrokerName", "Id");
            ListItem li = new ListItem("--Broker Details--", "0");
            ddlBrokerName.Items.Insert(0, li);
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            BindData();
        }
        public void BindData(int pageIndex = 1)
        {
            try
            {
                DataSet ds = new DataSet();
                string founderMinus1 = "";
                string founder = txtAllChassisNo.Text;
                if (founder != "")
                {
                    founderMinus1 = founder.Remove(founder.Length - 1, 1);
                    ds = clsA.GetBrokerDetailsByChassis(founderMinus1);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ViewState["DataTable"] = ds.Tables[0];
                        GridView1.DataSource = ds.Tables[0];
                        GridView1.DataBind();
                        Divserver.Visible = true;
                    }
                    else
                    {

                        GridView1.DataSource = ds.Tables[0];
                        GridView1.DataBind();
                    }
                }
                else
                {
                    entUpdateBroker obj = new entUpdateBroker();
                    obj.CategoryId = ddlCategory.SelectedValue;
                    obj.ProductId = ddlProduct.SelectedValue;
                    obj.ClientId = ddlClient.SelectedValue;
                    obj.ShipId = ddlShip.SelectedValue;
                    obj.AuctionId = ddlAuctionhouse.SelectedValue;
                    obj.Adate = txtADate.Text;
                    obj.PageIndex = pageIndex.ToString();
                    obj.PageSize = ddlshortby.SelectedValue;
                    ds = clsA.GetAllBrokerDetails(obj);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ViewState["DataTable"] = ds.Tables[0];
                        GridView1.PageSize = int.Parse(ddlshortby.SelectedValue);
                        GridView1.VirtualItemCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
                        GridView1.DataSource = ds.Tables[0];
                        GridView1.DataBind();
                        Divserver.Visible = true;
                    }
                    else
                    {
                        Divserver.Visible = false;
                        GridView1.DataSource = ds.Tables[0];
                        GridView1.DataBind();
                        CommonFunction.MessageBox(this, "E", "No record found");
                    }
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }
        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindProductDropDown();
        }


        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindData(e.NewPageIndex + 1);
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    Label lblid = (Label)e.Row.FindControl("lblbid");
                    DropDownList ddlbroker = (DropDownList)e.Row.FindControl("ddlBroker");
                    ddlbroker.DataSource = ViewState["brokertable"];
                    ddlbroker.DataTextField = "BrokerName";
                    ddlbroker.DataValueField = "Id";
                    ddlbroker.DataBind();
                    ddlbroker.Items.Insert(0, new ListItem("Broker Details", "0"));
                    ddlbroker.SelectedValue = lblid.Text;

                }
                catch (Exception ex)
                {
                    CommonFunction.MessageBox(this, "E", ex.Message);
                    ExceptionLogging.SendErrorToText(ex);
                }
            }
        }

        protected void UpdateBWDBroker_Click(object sender, EventArgs e)
        {
            int i = 0;
            try
            {
                foreach (GridViewRow row in GridView1.Rows)
                {
                    CheckBox chk = row.FindControl("Chkbox") as CheckBox;
                    if (chk.Checked)
                    {
                        DropDownList ddlbroker = row.FindControl("ddlbroker") as DropDownList;
                        Label lblid = row.FindControl("lblpid") as Label;
                        string upby = "E";
                        int temp = clsA.UpdateBroker(lblid.Text, ddlbroker.SelectedValue, upby, Session["AID"].ToString());
                        if (temp > 0)
                        {
                            i = i + 1;
                        }
                    }
                }
                if (i > 0)
                {
                    CommonFunction.MessageBox(this, "S", "Port From Update successfully");
                    BindData();
                }
                else
                {
                    CommonFunction.MessageBox(this, "E", "Select atleast one record to update");
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void UpdateBSBroker_Click(object sender, EventArgs e)
        {
            int i = 0;
            try
            {
                foreach (GridViewRow row in GridView1.Rows)
                {
                    CheckBox chk = row.FindControl("Chkbox") as CheckBox;
                    if (chk.Checked)
                    {
                        Label lblid = row.FindControl("lblpid") as Label;
                        string upby = "E";
                        int temp = clsA.UpdateBroker(lblid.Text, ddlBrokerName.SelectedValue, upby, Session["AID"].ToString());
                        if (temp > 0)
                        {
                            i = i + 1;
                        }
                    }
                }
                if (i > 0)
                {
                    CommonFunction.MessageBox(this, "S", "Port From Update successfully");
                    BindData();
                }
                else
                {
                    CommonFunction.MessageBox(this, "E", "Select atleast one record to update");
                    
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }
    }
}