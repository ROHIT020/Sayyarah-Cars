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
    public partial class Notify_Party_and_Cfs : System.Web.UI.Page
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
                ddlProduct.Items.Insert(0, new ListItem("--Select Product--", "0"));

                cmf.BindDropDownList(ddlAuctionhouse, ds, "Name", "Id", 1);
                ddlAuctionhouse.Items.Insert(0, new ListItem("--Select Auction--", "0"));

                cmf.BindDropDownList(ddlClient, ds, "ClientName", "id", 3);
                ddlClient.Items.Insert(0, new ListItem("--Select Client Name--","0"));
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
        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindProductDropDown();
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
                    ds = clsA.GetNotifyByChassiss(founderMinus1);
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
                    entNotifyPartyCFS obj = new entNotifyPartyCFS();
                    obj.CategoryId = ddlCategory.SelectedValue;
                    obj.ProductId = ddlProduct.SelectedValue;
                    obj.AuctionId = ddlAuctionhouse.SelectedValue;
                    obj.ClientId = ddlClient.SelectedValue;
                    obj.Adate = txtADate.Text;
                    obj.PageIndex = pageIndex.ToString();
                    obj.PageSize = ddlshortby.SelectedValue;
                    ds = clsA.GetAllUpdateNotify(obj);
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

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindData(e.NewPageIndex + 1);
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
           BindData();
        }

        protected void UpdateCansignee_Click(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                foreach(GridViewRow row in GridView1.Rows)
                {
                    CheckBox chk = row.FindControl("Chkbox") as CheckBox;
                    if (chk.Checked)
                    {
                        Label lblid = row.FindControl("lblpid") as Label;
                        TextBox txtnotify = row.FindControl("txtnotify") as TextBox;
                        TextBox txtcontact = row.FindControl("txtcontact") as TextBox;
                        TextBox txtemail = row.FindControl("txtEmail") as TextBox;
                        TextBox txtaddress = row.FindControl("txtaddress") as TextBox;
                        string Upby = "E";
                        int temp = clsA.AddNotify(lblid.Text, txtnotify.Text, txtaddress.Text, txtcontact.Text, txtemail.Text, Session["AID"].ToString(), Upby);
                        if (temp > 0)
                        {
                            i = i + 1;
                        }
                    }
                }
                if (i > 0)
                {
                    CommonFunction.MessageBox(this, "S", "Update Successfully");
                    BindData();
                }
                else
                {
                    CommonFunction.MessageBox(this, "E", "Select atleast one record to update");
                    BindData();
                }
            }
            catch(Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }
    }
}
