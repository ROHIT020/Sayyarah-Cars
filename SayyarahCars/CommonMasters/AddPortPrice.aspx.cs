using COMMON;
using DAL;
using ENTITY;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace SayyarahCars.CommonMasters
{
    public partial class AddPortPrice : System.Web.UI.Page
    {
        public CommonFunction cmf = new CommonFunction();
        clsMasters cls = new clsMasters();
        entPortPrice obj = new entPortPrice();
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
                    BindCountryFrom();
                    BindCountryTo();
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

        protected void BindCountryFrom()
        {
            DataSet ds = cls.CountryBind();
            cmf.BindDropDownList(ddlCountryfrom, ds, "CountryName", "Id");
            ListItem li = new ListItem("--Select Country--", "0");
            ddlCountryfrom.Items.Insert(0, li);
        }
        protected void BindCountryTo()
        {
            DataSet ds = cls.CountryBind();
            cmf.BindDropDownList(ddlCountryTo, ds, "CountryName", "Id");
            ListItem li = new ListItem("--Select Country--", "0");
            ddlCountryTo.Items.Insert(0, li);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnSubmit.Text != "Update")
                {
                    obj.CountryFromId = Convert.ToInt32(ddlCountryfrom.SelectedValue);
                    obj.CountryToId = Convert.ToInt32(ddlCountryTo.SelectedValue);
                    obj.InspectionPrice = Convert.ToDecimal(NumInspectionPrice.Text.Trim());
                    obj.RatiaionPrice = Convert.ToDecimal(NumRadiationPrice.Text.Trim());
                    obj.PortPrice = Convert.ToDecimal(NumPortPrice.Text.Trim());
                    obj.MiscPrice = Convert.ToDecimal(NumMiscPrice.Text.Trim());
                    obj.Archive = rdoactive.Checked ? false : true;
                    obj.uid = Convert.ToInt32(uid);
                    int result = cls.InsertPortPrice(obj);
                    if (result != 0)
                    {
                        CommonFunction.MessageBox(this, "S", "Record Saved successfully!!", "close");
                        cmf.ClearAllControls(Page);
                    }
                }
                else
                {
                    obj.Id = Convert.ToInt32(cmf.Decrypt(Request.QueryString["id"].ToString()));
                    obj.CountryFromId = Convert.ToInt32(ddlCountryfrom.SelectedValue);
                    obj.CountryToId = Convert.ToInt32(ddlCountryTo.SelectedValue);
                    obj.InspectionPrice = Convert.ToDecimal(NumInspectionPrice.Text.Trim());
                    obj.RatiaionPrice = Convert.ToDecimal(NumRadiationPrice.Text.Trim());
                    obj.PortPrice = Convert.ToDecimal(NumPortPrice.Text.Trim());
                    obj.MiscPrice = Convert.ToDecimal(NumMiscPrice.Text.Trim());
                    obj.uid = Convert.ToInt32(uid);
                    if (rdoactive.Checked)
                    {
                        obj.Archive = false;
                    }
                    else
                    {
                        obj.Archive = true;
                    }
                    int result = cls.updatePortPrice(obj);
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
            DataSet ds = cls.SelectPortPriceById(obj);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlCountryfrom.SelectedValue = ds.Tables[0].Rows[0]["CountryFromId"].ToString();
                ddlCountryTo.SelectedValue = ds.Tables[0].Rows[0]["CountryToId"].ToString();
                NumInspectionPrice.Text = ds.Tables[0].Rows[0]["InspectionPrice"].ToString();
                NumRadiationPrice.Text = ds.Tables[0].Rows[0]["RadiationPrice"].ToString();
                NumPortPrice.Text = ds.Tables[0].Rows[0]["PortPrice"].ToString();
                NumMiscPrice.Text = ds.Tables[0].Rows[0]["MiscPrice"].ToString();
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