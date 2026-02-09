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
    public partial class Update_Variant : System.Web.UI.Page
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
                    BindModel();
                    Divserver.Visible = false;

                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }
        public void BindModel()
        {
            DataSet ds = clsA.GetModelCodePurchase();
            cmf.BindDropDownList(ddlModelcode, ds, "ModelCode", "ModelCode");
            ListItem li = new ListItem("--Select ModelCode--", "0");
            ddlModelcode.Items.Insert(0, li);
        }
        public void BindDropDown()
        {
            try
            {
                DataSet ds = clsA.AllDropDownMaster();
                cmf.BindDropDownList(ddlCategory, ds, "CategoryName", "ID", 0);
                ddlProduct.Items.Insert(0, new ListItem("--Select Product--", "0"));

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
                cmf.BindDropDownList(ddlProduct, ds, "Name", "Id");
                ddlProduct.Items.Insert(0, new ListItem("--Select Product--", "0"));

                cmf.BindDropDownList(ddlproduct1, ds, "Name", "Id");
                ddlproduct1.Items.Insert(0, new ListItem("--Select Product--", "0"));
                ddlvariant.Items.Insert(0, new ListItem("--Select Variant--", "0"));
                
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
                    ds = clsA.GetUpdateVariantByChessis(founderMinus1);
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
                    UpdateVariant obj = new UpdateVariant();
                    obj.CategoryId = ddlCategory.SelectedValue;
                    obj.ProductId = ddlProduct.SelectedValue;
                    obj.ModelId = ddlModelcode.SelectedValue;
                    obj.AuctionId = ddlAuctionhouse.SelectedValue;
                    obj.Adate = txtADate.Text;
                    obj.ProductType = ddlProductType.SelectedValue;
                    obj.PageIndex = pageIndex.ToString();
                    obj.PageSize = ddlshortby.SelectedValue;
                    ds = clsA.GetAllUpdateVariant(obj);
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
        public void BindVariant()
        {
            if (ddlproduct1.SelectedValue != "0")
            {
                DataSet ds = clsA.GetVariantByProduct(Convert.ToInt32(ddlproduct1.SelectedValue));
                cmf.BindDropDownList(ddlvariant, ds, "Variant", "Id");
                ddlvariant.Items.Insert(0, new ListItem("--Select Product--", "0"));
            }
            else
            {
                ddlvariant.Items.Clear();
                ddlvariant.Items.Insert(0, new ListItem("--Select Variant--", "0"));
            }
        }
        protected void ddlproduct1_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindVariant();
        }

        protected void Updatevariant_Click(object sender, EventArgs e)
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
                        int temp = clsA.UpdateVariant(lblid.Text, ddlvariant.SelectedValue, Session["AID"].ToString());
                        if (temp > 0)
                        {
                            i = i + 1;
                        }
                    }
                }
                if (i > 0)
                {
                    CommonFunction.MessageBox(this, "S", "Variant Update successfully");
                    BindData();
                }
                else
                {
                    CommonFunction.MessageBox(this, "E", "Select atleast one record to update");
                    BindData();
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