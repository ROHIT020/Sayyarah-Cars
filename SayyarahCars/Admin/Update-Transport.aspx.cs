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
    public partial class Update_Transport : System.Web.UI.Page
    {
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
        public void BindAllDropDown()
        {
            try
            {
                DataSet ds = cls.AllUpdateDropdown();


                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ddlCategory.DataSource = ds.Tables[0];
                    ddlCategory.DataTextField = "CategoryName";
                    ddlCategory.DataValueField = "ID";
                    ddlCategory.DataBind();
                }
                ddlProduct.Items.Clear();
                ddlProduct.Items.Insert(0, new ListItem("--Select Product Name--", "0"));
                                               
                if (ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
                {
                    ddlAuctionhouse.DataSource = ds.Tables[2];
                    ddlAuctionhouse.DataTextField = "Name";
                    ddlAuctionhouse.DataValueField = "Id";
                    ddlAuctionhouse.DataBind();
                    ddlAuctionhouse.Items.Insert(0, new ListItem("--Select Auction--", "0"));
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
            int productTypeId = ddlCategory.SelectedValue != null ? Convert.ToInt32(ddlCategory.SelectedValue) : 0;
            if (productTypeId > 0)
            {
                BindProductDropDown(productTypeId);
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
                DataSet ds = new DataSet();
                string founderMinus1 = "";
                string founder = txtAllChassisNo.Text;
                if (founder != "")
                {
                    founderMinus1 = founder.Remove(founder.Length - 1, 1);
                    ds = cls.GetDataByChassisNo(founderMinus1);
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

                    }
                }
                else
                {
                    string pageSize = ddlsort.SelectedValue;
                    ds = cls.UpdateShippingDetails(ddlCategory.SelectedValue, ddlProduct.SelectedValue, ddlAuctionhouse.SelectedValue, txtADate.Text, pageIndex.ToString(), pageSize);
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
        protected void btnUpdate_Click(object sender, EventArgs e)
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
                            Label lblid = row.FindControl("lblpid") as Label;
                            TextBox txtconfirm = row.FindControl("txtTConfirm") as TextBox;
                            TextBox txtTDate = row.FindControl("txtTDate") as TextBox;
                            int temp = cls.UpdateTransportData(lblid.Text, txtconfirm.Text, txtTDate.Text, uid);
                            if (temp > 0)
                            {
                                i = i + 1;
                            }
                        }
                    }
                }
                if (i > 0)
                {
                    CommonFunction.MessageBox(this, "S", "Record Update successfully");
                    int currentPageIndex = GridView1.PageIndex + 1;
                    BindData(currentPageIndex);
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