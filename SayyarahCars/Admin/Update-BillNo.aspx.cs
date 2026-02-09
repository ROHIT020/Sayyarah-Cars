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
    public partial class Update_BillNo : System.Web.UI.Page
    {
        public CommonFunction cmf = new CommonFunction();
        clsUpdateBillNo clsbillno = new clsUpdateBillNo();
        clsUpdateInner cls = new clsUpdateInner();
        string uid = "0";
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
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ddlcategory.DataSource = ds.Tables[0];
                    ddlcategory.DataTextField = "CategoryName";
                    ddlcategory.DataValueField = "ID";
                    ddlcategory.DataBind();
                }
                ddlproductname.Items.Clear();
                ddlproductname.Items.Insert(0, new ListItem("--Select Product Name--", "0"));


                if (ds.Tables.Count > 5 && ds.Tables[5].Rows.Count > 0)
                {
                    ddlshipping.DataSource = ds.Tables[5];
                    ddlshipping.DataTextField = "Name";
                    ddlshipping.DataValueField = "Id";
                    ddlshipping.DataBind();
                    ddlshipping.Items.Insert(0, new ListItem("--Select Shipping Company --", "0"));
                }
                if (ds.Tables.Count > 6 && ds.Tables[6].Rows.Count > 0)
                {
                    ddlshipname.DataSource = ds.Tables[6];
                    ddlshipname.DataTextField = "Name";
                    ddlshipname.DataValueField = "Id";
                    ddlshipname.DataBind();
                    ddlshipname.Items.Insert(0, new ListItem("--Select Ship Name--", "0"));
                }
                if (ds.Tables.Count > 7 && ds.Tables[7].Rows.Count > 0)
                {
                    ddlportname.DataSource = ds.Tables[7];
                    ddlportname.DataTextField = "Name";
                    ddlportname.DataValueField = "Id";
                    ddlportname.DataBind();
                    ddlportname.Items.Insert(0, new ListItem("--Select Port Name--", "0"));
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
            if (ddlcategory.SelectedValue != "0")
            {
                DataSet ds = cls.GetProductNameByType(productId);
                cmf.BindDropDownList(ddlproductname, ds, "Name", "Id");
                ddlproductname.Items.Insert(0, new ListItem("--Select Product Name--", "0"));
            }
            else
            {
                ddlproductname.Items.Clear();
                ddlproductname.Items.Insert(0, new ListItem("--Select Product Name--", "0"));
            }
        }
        protected void BindPortDropdown(int shipId)
        {
            if (ddlshipname.SelectedValue != "0")
            {
                DataSet ds = clsbillno.GetPortByShipName(shipId);
                cmf.BindDropDownList(ddlportname, ds, "PortName", "id");
                ddlportname.Items.Insert(0, new ListItem("--Select Port--", "0"));
            }
            else
            {
                ddlportname.Items.Clear();
                ddlportname.Items.Insert(0, new ListItem("--Select Port--", "0"));
            }
        }
        protected void ddlcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int categoryId = Convert.ToInt32(ddlcategory.SelectedValue);
            if (categoryId > 0)
            {
                BindProductDropDown(categoryId);
            }
            else
            {
                ddlproductname.Items.Clear();
                ddlproductname.Items.Insert(0, new ListItem("--Select Product Name--", "0"));
            }
        }

        protected void ddlshipname_SelectedIndexChanged(object sender, EventArgs e)
        {
            int shippingId = Convert.ToInt32(ddlshipname.SelectedValue);
            if (shippingId > 0)
            {
                BindPortDropdown(shippingId);
            }
            else
            {
                ddlshipname.Items.Clear();
                ddlshipname.Items.Insert(0, new ListItem("--Select Port--", "0"));
            }
        }


        protected void btnSearch_Click(object sender, EventArgs e)
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
                    ds = clsbillno.InsertBillNo(ddlcategory.SelectedValue, ddlproductname.SelectedValue, ddlshipping.SelectedValue, ddlshipname.SelectedValue, ddlportname.SelectedValue, pageIndex.ToString(), pageSize);
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
                            TextBox txtbillno = row.FindControl("txtbillno") as TextBox;
                            int temp = clsbillno.UpdateBillData(lblid.Text, txtbillno.Text, uid);
                            if (temp > 0)
                            {
                                i++;
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

        protected void btnUpdateAll_Click(object sender, EventArgs e)
        {
            int i = 0;
            try
            {
                foreach (GridViewRow row in GridView1.Rows)
                {
                    CheckBox chk = row.FindControl("Chkbox") as CheckBox;
                    if (chk != null && chk.Checked)
                    {
                        Label lblid = row.FindControl("lblpid") as Label;
                        int temp = clsbillno.UpdateBillData(lblid.Text, txtbillnos.Text, Convert.ToString(Session["AID"]));
                        if (temp > 0)
                        {
                            i++;
                        }
                    }
                }
                if (i > 0)
                {
                    CommonFunction.MessageBox(this, "S", "Selected records updated successfully!!");
                    int currentPageIndex = GridView1.PageIndex + 1;
                    BindData(currentPageIndex);                    
                }
                else
                {
                    CommonFunction.MessageBox(this, "E", "No records were update. Please try again.!!");
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