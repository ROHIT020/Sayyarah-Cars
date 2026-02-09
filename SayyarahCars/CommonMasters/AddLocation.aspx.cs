using COMMON;
using DAL;
using ENTITY;
using System;
using System.Data;
using System.Web.UI.WebControls;


namespace SayyarahCars.CommonMasters
{
    public partial class AddLocation : System.Web.UI.Page
    {
        public CommonFunction cmf = new CommonFunction();
        clsMasters cls = new clsMasters();
        entLocation obj = new entLocation();
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
                    obj.LocationName = txtlocationName.Text.Trim();
                    if (rdoactive.Checked)
                    {
                        obj.Archive = false;
                    }
                    else
                    {
                        obj.Archive = true;
                    }
                    obj.uid = Convert.ToInt32(uid);
                    int result = cls.InsertLocation(obj);
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
                    obj.LocationName = txtlocationName.Text.Trim();
                    obj.uid = Convert.ToInt32(uid);
                    if (rdoactive.Checked)
                    {
                        obj.Archive = false;
                    }
                    else
                    {
                        obj.Archive = true;
                    }
                    int result = cls.updateLocation(obj);
                    if (result != 0)
                    {
                        CommonFunction.MessageBox(this, "S", "Record Update successfully!!", "close");
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
            DataSet ds = cls.SelectlocationByID(obj);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlCountry.SelectedValue = ds.Tables[0].Rows[0]["CountryId"].ToString();
                txtlocationName.Text = ds.Tables[0].Rows[0]["LocationName"].ToString();
                string status = ds.Tables[0].Rows[0]["Archive"].ToString();
                if (status == "True")
                {
                    rdodeActive.Checked = true;
                    rdoactive.Checked = false;
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