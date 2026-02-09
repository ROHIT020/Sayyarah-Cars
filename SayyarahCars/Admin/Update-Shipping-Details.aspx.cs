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
    public partial class Update_Shipping_Details : System.Web.UI.Page
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
                    BindAllDropDown();
                    BindAllMaster();
                    Divserver.Visible = false;
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
                DataSet ds = clsA.AllDropDownMaster();

                cmf.BindDropDownList(ddlCategory, ds, "CategoryName", "ID", 0);
                

                cmf.BindDropDownList(ddlAuctionhouse, ds, "Name", "Id", 1);
                ddlAuctionhouse.Items.Insert(0, new ListItem("--Select Auction--", "0"));
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

                cmf.BindDropDownList(ddlProduct, ds, "Name", "Id", 0);
                ddlProduct.Items.Insert(0, new ListItem("--Select product--", "0"));
            }
            else
            {
                ddlProduct.Items.Clear();
                ddlProduct.Items.Insert(0, new ListItem("--Select Product--", "0"));
            }
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
                    ds = clsA.GetUpdateShippingDetails(founderMinus1);
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
                    entUpdateShippingDetails obj = new entUpdateShippingDetails();
                    obj.CategoryId = ddlCategory.SelectedValue;
                    obj.ProductId = ddlProduct.SelectedValue;
                    obj.AuctionId = ddlAuctionhouse.SelectedValue;
                    obj.Adate = txtADate.Text;
                    obj.PageIndex = pageIndex.ToString();
                    obj.PageSize = ddlshortby.SelectedValue;
                    ds = clsA.GetAllUpdateshipping(obj);
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

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        public void BindAllMaster()
        {
            try
            {
                DataSet ds = clsA.GetAllMaster();

                cmf.BindDropDownList(ddlTransport, ds, "TransportName","Id",0);
                ddlTransport.Items.Insert(0, new ListItem("--Select Transport--", "0"));
                
                cmf.BindDropDownList(ddlshipping, ds, "ShippingName", "Id", 1);
                ddlshipping.Items.Insert(0, new ListItem("--Select Shipping--", "0"));

                cmf.BindDropDownList(ddlPortFrom, ds, "PortName", "ID", 2);
                ddlPortFrom.Items.Insert(0, new ListItem("--Select Port From--", "0"));

                cmf.BindDropDownList(ddlPortTo, ds, "PortName", "ID",2);
                ddlPortTo.Items.Insert(0, new ListItem("--Select Port To--", "0"));

                cmf.BindDropDownList(ddlsoldcountry, ds, "CountryName", "ID",3);
                ddlsoldcountry.Items.Insert(0, new ListItem("--Select Country--", "0"));

            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void UpdateTransport_Click(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                foreach (GridViewRow row in GridView1.Rows)
                {
                    CheckBox chk = row.FindControl("Chkbox") as CheckBox;
                    if (chk.Checked)
                    {
                        Label lblid = row.FindControl("lblpid") as Label;
                        Label lblTID = row.FindControl("lblTID") as Label;
                        if (lblTID.Text != ddlTransport.SelectedValue)
                        {
                            int temp = clsA.UpdateTransport(lblid.Text, ddlTransport.SelectedValue, Session["AID"].ToString());
                            if (temp > 0)
                            {
                                i = i + 1;
                            }
                        }
                    }
                }
                if (i > 0)
                {
                    CommonFunction.MessageBox(this, "S", "Transport Update successfully");
                    BindData();
                    BindAllMaster();
                }
                else
                {
                    CommonFunction.MessageBox(this, "E", "Select atleast one record to update");
                    BindData();
                    BindAllMaster();
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void Updateshipping_Click(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                foreach (GridViewRow row in GridView1.Rows)
                {
                    CheckBox chk = row.FindControl("Chkbox") as CheckBox;
                    if (chk.Checked)
                    {
                        Label lblid = row.FindControl("lblpid") as Label;
                        Label lblSID = row.FindControl("lblSID") as Label;
                        if (lblSID.Text != ddlTransport.SelectedValue)
                        {
                            int temp = clsA.UpdateShipping(lblid.Text, ddlshipping.SelectedValue, Session["AID"].ToString());
                            if (temp > 0)
                            {
                                i = i + 1;
                            }
                        }
                    }
                }
                if (i > 0)
                {
                    CommonFunction.MessageBox(this, "S", "Shipping Update successfully");
                    BindData();
                    BindAllMaster();
                }
                else
                {
                    CommonFunction.MessageBox(this, "E", "Select atleast one record to update");
                    BindData();
                    BindAllMaster();
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void UpdatePortfrom_Click(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                foreach (GridViewRow row in GridView1.Rows)
                {
                    CheckBox chk = row.FindControl("Chkbox") as CheckBox;
                    if (chk.Checked)
                    {
                        Label lblid = row.FindControl("lblpid") as Label;
                        Label lblPF = row.FindControl("lblPF") as Label;
                        if (lblPF.Text != ddlPortFrom.SelectedValue)
                        {
                            int temp = clsA.UpdatePortFrom(lblid.Text, ddlPortFrom.SelectedValue, Session["AID"].ToString());
                            if (temp > 0)
                            {
                                i = i + 1;
                            }
                        }
                    }
                }
                if (i > 0)
                {
                    CommonFunction.MessageBox(this, "S", "Port From Update successfully");
                    BindData();
                    BindAllMaster();
                }
                else
                {
                    CommonFunction.MessageBox(this, "E", "Select atleast one record to update");
                    BindData();
                    BindAllMaster();
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void UpdatePortTo_Click(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                foreach (GridViewRow row in GridView1.Rows)
                {
                    CheckBox chk = row.FindControl("Chkbox") as CheckBox;
                    if (chk.Checked)
                    {
                        Label lblid = row.FindControl("lblpid") as Label;
                        Label lblPT = row.FindControl("lblPT") as Label;
                        if (lblPT.Text != ddlTransport.SelectedValue)
                        {
                            int temp = clsA.UpdatePortTo(lblid.Text, ddlPortTo.SelectedValue, Session["AID"].ToString());
                            if (temp > 0)
                            {
                                i = i + 1;
                            }
                        }
                    }
                }
                if (i > 0)
                {
                    CommonFunction.MessageBox(this, "S", "Port To Update successfully");
                    BindData();
                    BindAllMaster();
                }
                else
                {
                    CommonFunction.MessageBox(this, "E", "Select atleast one record to update");
                    BindData();
                    BindAllMaster();
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void UpdateSoldCountry_Click(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                foreach (GridViewRow row in GridView1.Rows)
                {
                    CheckBox chk = row.FindControl("Chkbox") as CheckBox;
                    if (chk.Checked)
                    {
                        Label lblid = row.FindControl("lblpid") as Label;
                        Label lblscid = row.FindControl("lblscid") as Label;
                        if (lblscid.Text != ddlTransport.SelectedValue)
                        {
                            int temp = clsA.UpdateSoldCountry(lblid.Text, ddlsoldcountry.SelectedValue, Session["AID"].ToString());
                            if (temp > 0)
                            {
                                i = i + 1;
                            }
                        }
                    }
                }
                if (i > 0)
                {
                    CommonFunction.MessageBox(this, "S", "Sold Country Update successfully");
                    BindData();
                    BindAllMaster();
                }
                else
                {
                    CommonFunction.MessageBox(this, "E", "Select atleast one record to update");
                    BindData();
                    BindAllMaster();
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