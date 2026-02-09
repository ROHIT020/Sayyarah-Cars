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
    public partial class View_Auction_Car : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        public CommonFunction cmf = new CommonFunction();
        clsUpdateInner cls = new clsUpdateInner();
        public string uid = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["AID"] != null)
                {
                    uid = Session["AID"].ToString();
                }
                if (!Page.IsPostBack)
                {
                    Divserver.Visible = false;
                    BindAllDropDown();
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        public void BindAllDropDown()
        {
            try
            {
                DataSet ds = cls.AllUpdateDropdown();
                cmf.BindDropDownList(ddlCategory, ds, "CategoryName", "ID", 0);     //Category                

                cmf.BindDropDownList(ddlAuctionhouse, ds, "Name", "Id", 2);
                ddlAuctionhouse.Items.Insert(0, new ListItem("--Select Auction House--", "0"));    //Auction House
                if (ds.Tables[2].Rows.Count > 0)
                {
                    ViewState["AuctionHouse"] = ds.Tables[2];
                }

                if (ds.Tables[3].Rows.Count > 0)
                {
                    ViewState["Transport"] = ds.Tables[3];
                }

                cmf.BindDropDownList(ddlAuctionGroup, ds, "Name", "ID", 7);
                ddlAuctionGroup.Items.Insert(0, new ListItem("--Select Auction Group--", "0"));    //Auction Group
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }
        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int productTypeId = ddlCategory.SelectedValue != null ? Convert.ToInt32(ddlCategory.SelectedValue) : 0;
            if (productTypeId > 0)
            {
                BindProductDropDown(productTypeId);
            }
            else
            {
                ddlProduct.Items.Clear();
                ddlProduct.Items.Insert(0, new ListItem("--Select Product Name", "0"));
            }
        }
        protected void BindProductDropDown(int productId)
        {
            if (ddlCategory.SelectedValue != "0")
            {
                DataSet ds = cls.GetProductNameByType(productId);
                cmf.BindDropDownList(ddlProduct, ds, "Name", "Id");
                ddlProduct.Items.Insert(0, new ListItem("--Select Product Name--", "0"));
            }
            else
            {
                ddlProduct.Items.Clear();
                ddlProduct.Items.Insert(0, new ListItem("--Select Product Name--", "0"));
            }
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
                BindData();
        }
        protected void BindData(int pageIndex = 1)
        {
            try
            {
                string founderMinus1 = "";
                string founder = txtAllChassisNo.Text;
                if (founder != "")
                {
                    founderMinus1 = founder.Remove(founder.Length - 1, 1);
                    ds = cls.ViewAuctionByChassisNo(founderMinus1);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ViewState["DataTable"] = ds.Tables[0];
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
                else
                {
                    string pageSize = ddlsort.SelectedValue;
                    ds = cls.ViewAllUpdateAuction(ddlCategory.SelectedValue, ddlProduct.SelectedValue, ddlAuctionGroup.SelectedValue, ddlAuctionhouse.SelectedValue, txtLotNo.Text, txtADate.Text, pageIndex.ToString(), pageSize);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ViewState["DataTable"] = ds.Tables[0];
                        GridView1.PageSize = int.Parse(ddlsort.SelectedValue);
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
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblpid = (Label)e.Row.FindControl("lblpid");
                    Label lblaid = (Label)e.Row.FindControl("lblAID");
                    Label lbltid = (Label)e.Row.FindControl("lblTID");
                    DropDownList ddloldauction = (DropDownList)e.Row.FindControl("ddlOldAuction");
                    DataTable dt = (DataTable)ViewState["AuctionHouse"];
                    cmf.BindDropDownList(ddloldauction, dt, "Name", "Id");
                    ddloldauction.SelectedValue = lblaid.Text;

                    DropDownList ddlnewauction = (DropDownList)e.Row.FindControl("ddlNewAuction");
                    DataTable dt2 = (DataTable)ViewState["AuctionHouse"];
                    cmf.BindDropDownList(ddlnewauction, dt2, "Name", "Id");
                    ddlnewauction.Items.Insert(0, new ListItem("New Auction House", "0"));
                    ddlnewauction.SelectedValue = lblaid.Text;


                    DropDownList ddltransport = (DropDownList)e.Row.FindControl("ddlTransport");
                    DataTable dt3 = (DataTable)ViewState["Transport"];
                    cmf.BindDropDownList(ddltransport, dt3, "Name", "Id");
                    ddltransport.Items.Insert(0, new ListItem("Transport", "0"));
                    ddltransport.SelectedValue = lbltid.Text;
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int i = 0;            
            try
            {
                foreach (GridViewRow row in GridView1.Rows)
                {
                    CheckBox chk = row.FindControl("Chkbox") as CheckBox;
                    if (chk.Checked)
                    {
                        {
                            Label lblid = row.FindControl("lblid") as Label;
                            Label lblpid = row.FindControl("lblpid") as Label;                            
                            int temp = cls.DeleteAuctionCar(lblid.Text,lblpid.Text, uid);
                            if (temp > 0)
                            {
                                i++;
                            }
                        }
                    }
                }
                    if (i > 0)
                    {
                        CommonFunction.MessageBox(this, "E", "Auction Delete Successfull!!");
                        BindData();
                    }
                    else
                    {
                        CommonFunction.MessageBox(this, "E", "Select atleast one record to delete");
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
            try
            {
                GridView1.PageIndex = e.NewPageIndex;
                BindData(e.NewPageIndex + 1);
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }
    }
}