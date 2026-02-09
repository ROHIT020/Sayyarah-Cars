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
    public partial class Document_Send_Date : System.Web.UI.Page
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
            DataSet ds = new DataSet();
            ds = clsA.AllDropDownMaster();
            cmf.BindDropDownList(ddlCategory, ds, "CategoryName", "ID", 0);
            ddlProduct.Items.Insert(0, new ListItem("Select Product--", "0"));

            cmf.BindDropDownList(ddlAuctionhouse, ds, "Name", "Id", 1);
            ddlAuctionhouse.Items.Insert(0, new ListItem("--Select Auction--", "0"));

            if (ds.Tables[2].Rows.Count > 0)
            {
                ViewState["Shipping"] = ds.Tables[2];
            }
            cmf.BindDropDownList(ddlShipping, ds, "ShipName", "Id", 2);
            ddlShipping.Items.Insert(0, new ListItem("--Select Shipping", "0"));

            if (ds.Tables[4].Rows.Count > 0)
            {
                ViewState["portfrom"] = ds.Tables[4];
            }
            cmf.BindDropDownList(ddlPortFrom, ds, "PortName", "ID", 4);
            ddlPortFrom.Items.Insert(0, new ListItem("--Select Port From--", "0"));
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
                    ds = clsA.GetUpdateDSdateByChe(founderMinus1);
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
                    entDocumnetSendDate obj = new entDocumnetSendDate();
                    obj.CategoryId = ddlCategory.SelectedValue;
                    obj.ProductId = ddlProduct.SelectedValue;
                    obj.AuctionId = ddlAuctionhouse.SelectedValue;
                    obj.Adate = txtADate.Text;
                    obj.PageIndex = pageIndex.ToString();
                    obj.PageSize = ddlshortby.SelectedValue;
                    ds = clsA.GetAllDSendDate(obj);
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
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            BindData();
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
                    Label lblpid = (Label)e.Row.FindControl("lblpid");
                    Label lblPFid = (Label)e.Row.FindControl("lblPFId");
                    Label lblSID = (Label)e.Row.FindControl("lblSid");
                    DropDownList ddlshippingcompany = (DropDownList)e.Row.FindControl("ddlshipping1");
                    DropDownList ddlportfrom = (DropDownList)e.Row.FindControl("ddlPortFrom1");
                    
                    DataTable dt = (DataTable)ViewState["Shipping"];
                    cmf.BindDropDownList(ddlshippingcompany, dt, "ShipName", "Id");
                    ddlshippingcompany.Items.Insert(0,new ListItem("--Select Shipping--", "0"));
                    ddlshippingcompany.SelectedValue = lblSID.Text;
                    
                    DataTable dt2 = (DataTable)ViewState["portfrom"];
                    cmf.BindDropDownList(ddlportfrom, dt2, "PortName", "ID");
                    ddlportfrom.Items.Insert(0, new ListItem("--Select Port--", "0"));
                    ddlportfrom.SelectedValue = lblPFid.Text;
                }
                catch (Exception ex)
                {
                    CommonFunction.MessageBox(this, "E", ex.Message);
                    ExceptionLogging.SendErrorToText(ex);
                }
            }
        }

        protected void UpdateAllSame_Click(object sender, EventArgs e)
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
                        int temp = clsA.UpdateDSShippingPort(lblid.Text, ddlShipping.SelectedValue, ddlPortFrom.SelectedValue, DocSendDate.Text, Session["AID"].ToString());
                        if (temp > 0)
                        {
                            i = i + 1;
                        }
                    }
                }
                if (i > 0)
                {
                    CommonFunction.MessageBox(this, "S", "Update successfully");
                    BindData();
                }
            }
            catch(Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void UpdateAllDifference_Click(object sender, EventArgs e)
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
                        DropDownList ddlshippingcompany = row.FindControl("ddlshipping1") as DropDownList;
                        DropDownList ddlportfrom = row.FindControl("ddlPortFrom1") as DropDownList;
                        UserControl uc = row.FindControl("lbldsdate1") as UserControl;
                        TextBox txtdate =uc.FindControl("txt_Date") as TextBox;
                        int temp = clsA.UpdateDSShippingPort(lblid.Text, ddlshippingcompany.SelectedValue, ddlportfrom.SelectedValue,Convert.ToDateTime(txtdate.Text).ToString("yyyy-MM-dd"), Session["AID"].ToString());
                        if (temp > 0)
                        {
                            i = i + 1;
                        }
                    }
                }
                if (i > 0)
                {
                    CommonFunction.MessageBox(this, "S", "Update successfully");
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


