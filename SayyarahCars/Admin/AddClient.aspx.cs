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
    public partial class Add_Client : System.Web.UI.Page
    {
        public CommonFunction cmf = new CommonFunction();
        clsClients cls = new clsClients();
        entClient obj = new entClient();
        public string uid = "0";
        public string ImagePath = "";
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
                    bindCountryBind();
                }
            }
            catch (Exception ex)
            {
                CommonFunction.DisplayAlert(this, ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }


        }

        protected void bindCountryBind()
        {
            DataSet ds = cls.CountryBind();
            cmf.BindDropDownList(ddlcountry, ds, "CountryName", "Id");
            ListItem li = new ListItem("--Select Country--", "0");
            ddlcountry.Items.Insert(0, li);
        }
        protected void bindState(int countryId)
        {
            DataSet ds = cls.StateBind(countryId);
            cmf.BindDropDownList(ddlstate, ds, "StateName", "StateId");
            ListItem li = new ListItem("--Select State--", "0");
            ddlstate.Items.Insert(0, li);
        }


        protected string UploadPhoto(FileUpload flp, string docname, string docfilename, string docpath, int size)
        {
            string message = "", filepath = "";

            string[] allowedMimeTypes = { "image/pjpeg", "image/jpeg", "image/png", "image/x-png" };
            int result = FileUploadUtility.ValidateFile(flp, docname, allowedMimeTypes, size, out message);
            if (result == 0)
            {
                filepath = FileUploadUtility.UploadFile(flp, docfilename, docpath, out message);
                if (string.IsNullOrEmpty(filepath))
                {
                    CommonFunction.MessageBox(this, "E", message);
                    return "";
                }
            }
            else
            {
                CommonFunction.MessageBox(this, "E", message);
                return "";
            }
            return filepath;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string fileurl = ViewState["imgurl"]?.ToString() ?? "";

                if (fuProfile.HasFile)
                {
                    fileurl = UploadPhoto(fuProfile, "Profile Photo", "Photo", "ClientDocsPath", 800);
                    if (fileurl == string.Empty)
                    {
                        return;
                    }
                }
                obj.pimage = fileurl;
                obj.fname = txtfname.Text.Trim();
                obj.lname = txtlname.Text.Trim();
                obj.emailid = txtemailid.Text.Trim();
                obj.contact = txtcontactno.Text.Trim();
                obj.countryid = Convert.ToInt32(ddlcountry.SelectedValue);
                obj.stateid = Convert.ToInt32(ddlstate.SelectedValue);
                obj.address = txtaddress.Text.Trim();
                obj.refempid = Convert.ToString(txtrefempid.Text.Trim());
                obj.password = txtpassword.Text.Trim();
                obj.uid = Convert.ToInt32(uid);
                if (cls.IsClientExists(obj) == 1)
                {
                    cls.InsertAdminClient(obj);
                    CommonFunction.MessageBox(this, "S", "Record saved successfully!!");
                    cmf.ClearAllControls(Page);
                }
                else
                {
                    CommonFunction.MessageBox(this, "E", "Email ID already exists!!");
                }

            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
        {

            int countryId = Convert.ToInt32(ddlcountry.SelectedValue);
            if (countryId > 0)
            {
                bindState(countryId);
            }
            else
            {
                ddlstate.Items.Clear();
                ddlstate.Items.Insert(0, new ListItem("--Select State--", "0"));
            }
        }
    }
}