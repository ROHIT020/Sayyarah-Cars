using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using ENTITY;
using COMMON;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SayyarahCars.Admin
{
    public partial class Updatee_Shipping : System.Web.UI.Page
    {
        CommonFunction cmf = new CommonFunction();
        private string  uid = "0";
        clsAdmin admin = new clsAdmin();
        DataSet ds;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["AID"] != null)
                {
                    uid = Session["AID"].ToString();
                }
                if(!IsPostBack)
                {
                    CategoryBind();
                    allMasterUpdate();
                    Divserver.Visible = false;
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        public void CategoryBind()
        {
            DataSet ds = admin.CategoryBind();
            cmf.BindDropDownList(ddcategory,ds,"CategoryName","Id",0);
            ListItem lst = new ListItem("Select Category","0");
            ddcategory.Items.Insert(0,lst);
            cmf.BindDropDownList(ddlAuction, ds, "Name", "Id", 1);
            ddlAuction.Items.Insert(0,lst);
        }

        public void ProductBind()
        {
            if(ddcategory.SelectedValue != "0")
            {
                DataSet ds = admin.getProduct(Convert.ToInt32(ddcategory.SelectedValue));
                cmf.BindDropDownList(ddlproduct, ds, "Name","Id");
                ListItem lst = new ListItem("Select Product", "0");
                ddlproduct.Items.Insert(0,lst);
            }
        }


        public void BindPurchaseData(int PageIndex=1)
        {
            try
            {
                ds = new DataSet();
                string FounderMinus1 = "";
                string Founder = txtAllChassisNo.Text;
                if(Founder != "")
                {
                    FounderMinus1 = Founder.Remove(Founder.Length - 1, 1);
                    ds = admin.GetUpdateData(FounderMinus1);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ViewState["DataTable"] = ds.Tables[0];
                        gvshipig.DataSource = ds.Tables[0];
                        gvshipig.DataBind();
                        Divserver.Visible = true;
                    }
                    else
                    {
                        gvshipig.DataSource = ds.Tables[0];
                        gvshipig.DataBind();
                    }

                }
                else
                {
                    UpdateShipping obj = new UpdateShipping();
                    obj.CategoryId = ddcategory.SelectedValue;
                    obj.ProductId = ddlproduct.SelectedValue;
                    obj.AuctionId = ddlAuction.SelectedValue;
                    obj.Adate = txtdate.Text;
                    obj.PageIndex = PageIndex.ToString();
                    obj.PageSize = ddlsortby.SelectedValue;
                    ds = admin.GetUpdateshippingdata(obj);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ViewState["DataTable"] = ds.Tables[0];
                        gvshipig.PageSize = int.Parse(ddlsortby.SelectedValue);
                        gvshipig.VirtualItemCount = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                        gvshipig.DataSource = ds.Tables[0];
                        gvshipig.DataBind();
                        Divserver.Visible = true;
                    }
                    else
                    {
                        Divserver.Visible = false;
                        gvshipig.DataSource = ds.Tables[0];
                        gvshipig.DataBind();
                        CommonFunction.MessageBox(this, "E", "No record found");
                    }
                }
            }
            catch(Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void ddcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProductBind();
        }

        protected void btnserach_Click(object sender, EventArgs e)
        {
            BindPurchaseData();
        }


        public void allMasterUpdate()
        {
            ds = admin.GetallShippingbind();
            cmf.BindDropDownList(ddlshipping,ds,"ShippingName","Id",0);
            ListItem lst = new ListItem("Select Shipping","0");
            ddlshipping.Items.Insert(0,lst);
            cmf.BindDropDownList(ddlportfrom, ds, "PortName", "Id", 1);
            ListItem ls = new ListItem("Select PortName","0");
            ddlportfrom.Items.Insert(0,ls);
        }

        protected void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                foreach(GridViewRow row in gvshipig.Rows)
                {
                    CheckBox chk = row.FindControl("Chckbox") as CheckBox;
                    if(chk.Checked)
                    {
                        Label llbld = row.FindControl("lblpid") as Label;
                        Label llsld = row.FindControl("lblSID") as Label;
                        int temp = admin.UpdateShippingData(llbld.Text, ddlshipping.SelectedValue, Session["AID"].ToString());
                        {
                            if (temp > 0)
                            {
                                i = i + 1;
                            }
                        }

                    }
                }
                if(i> 0)
                {
                    CommonFunction.MessageBox(this, "S", "Shipping Update successfully");
                    BindPurchaseData();
                    allMasterUpdate();
                }
                else
                {
                    CommonFunction.MessageBox(this, "E", "Select atleast one record to update");
                    BindPurchaseData();
                    allMasterUpdate();
                }
            }
            catch(Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }

        }

        protected void button2_Click(object sender, EventArgs e)
        {
            
            try
            {
                int i = 0;
                foreach (GridViewRow row in gvshipig.Rows)
                {
                    CheckBox chk = row.FindControl("Chckbox") as CheckBox;
                    if (chk.Checked)
                    {
                        Label lblid = row.FindControl("lblpid") as Label;
                        Label lblPF = row.FindControl("lblPF") as Label;
                        {
                            int temp = admin.UpdateProtFormData(lblid.Text, ddlportfrom.SelectedValue, Session["AID"].ToString());
                           {
                                if (temp > 0)
                                {
                                    i = i + 1;
                                }
                           }
                        }
                    }
                }
                if(i>0)
                {
                    CommonFunction.MessageBox(this, "S", "Port From Update successfully");
                    BindPurchaseData();
                    allMasterUpdate();
                }
                else
                {
                    CommonFunction.MessageBox(this, "E", "Select atleast one record to update");
                    BindPurchaseData();
                    allMasterUpdate();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        protected void gvshipig_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            gvshipig.PageIndex = e.NewPageIndex;
               BindPurchaseData(e.NewPageIndex + 1);
        }



        //protected void gvshipig_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    gvshipig.PageIndex = e.NewPageIndex;

        //    BindPurchaseData(e.NewPageIndex + 1);
        //}
    }
}