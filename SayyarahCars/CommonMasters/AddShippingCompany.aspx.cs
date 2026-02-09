using COMMON;
using DAL;
using ENTITY;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace SayyarahCars.CommonMasters
{
    public partial class AddShippingCompany : System.Web.UI.Page
    {
        public CommonFunction cmf = new CommonFunction();
        clsMasters cls = new clsMasters();
        entShipping obj = new entShipping();
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
                    BindCountry();
                    if (Request.QueryString["id"] != null)
                    {
                        binddata();
                    }
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void BindCountry()
        {
            DataSet ds = cls.CountryBind();
            cmf.BindDropDownList(ddlCountry, ds, "CountryName", "Id");
            ListItem li = new ListItem("--Select Country--", "0");
            ddlCountry.Items.Insert(0, li);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnSubmit.Text != "Update")
                {
                    obj.CountryId = Convert.ToInt32(ddlCountry.SelectedValue);
                    obj.ShippingName = txtShippingName.Text.Trim();
                    obj.ShippingRate = txtShippingRate.Text.Trim();
                    obj.Email = txtEmail.Text.Trim();
                    obj.Contact = txtContact.Text.Trim();
                    obj.Archive = rdoactive.Checked ? 0 : 1;
                    obj.uid = Convert.ToInt32(uid);
                    int result = cls.InsertShipping(obj);
                    if (result != 0)
                    {
                        CommonFunction.MessageBox(this, "S", "Record Saved successfully!!", "close");
                        cmf.ClearAllControls(Page);
                    }
                }
                else
                {
                    obj.Id = Convert.ToInt32(cmf.Decrypt(Request.QueryString["id"].ToString()));
                    obj.CountryId = Convert.ToInt32(ddlCountry.SelectedValue);
                    obj.ShippingName = txtShippingName.Text.Trim();
                    obj.ShippingRate = txtShippingRate.Text.Trim();
                    obj.Email = txtEmail.Text.Trim();
                    obj.Contact = txtContact.Text.Trim();
                    obj.uid = Convert.ToInt32(uid);
                    if (rdoactive.Checked)
                    {
                        obj.Archive = 0;
                    }
                    else
                    {
                        obj.Archive = 1;
                    }
                    int result = cls.updateShipping(obj);
                    if (result != 0)
                    {
                        CommonFunction.MessageBox(this, "S", "Record Updated successfully!!", "close");
                        cmf.ClearAllControls(Page);
                    }
                } 
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void binddata()
        {
            obj.Id = Convert.ToInt32(cmf.Decrypt(Request.QueryString["id"].ToString()));
            DataSet ds = cls.SelectShippingById(obj);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlCountry.SelectedValue = ds.Tables[0].Rows[0]["CountryId"].ToString();
                txtShippingName.Text = ds.Tables[0].Rows[0]["ShippingName"].ToString();
                txtShippingRate.Text = ds.Tables[0].Rows[0]["ShippingRate"].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                txtContact.Text = ds.Tables[0].Rows[0]["Contact"].ToString();
                string status = ds.Tables[0].Rows[0]["Archive"].ToString();
                if (status == "True")
                {
                    rdoactive.Checked = false;
                    rdodeActive.Checked = true;
                }
                else
                {
                    rdoactive.Checked = true;
                    rdodeActive.Checked = false;
                }
                btnSubmit.Text = "Update";
            }
        }
    }
}