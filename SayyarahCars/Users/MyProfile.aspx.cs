using COMMON;
using DAL;
using ENTITY;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace SayyarahCars.Users
{
    public partial class MyProfile : System.Web.UI.Page
    {
        public CommonFunction cmf = new CommonFunction();
        clsClients cls = new clsClients();
        entClient obj = new entClient();
        public string uid = "0";
        public string ImagePath = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CID"] != null)
            {
                uid = Session["CID"].ToString();
            }
            if (!IsPostBack)
            {
                bindCountryBind();
                bindprofile();
            }
        }

        protected void bindCountryBind()
        {
            clsMasters mst = new clsMasters();
            DataSet ds = mst.CountryBind();
            cmf.BindDropDownList(ddlcountry, ds, "CountryName", "Id");
            ListItem li = new ListItem("Select Country", "0");
            ddlcountry.Items.Insert(0, li);
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
        private void bindprofile()
        {
            DataSet ds = cls.GetClientById(Convert.ToInt32(uid));
            if (ds.Tables[0].Rows.Count > 0)
            {

                ImagePath = ds.Tables[0].Rows[0]["pimage"].ToString();
                ViewState["imgurl"] = ImagePath;
                imgPreview.ImageUrl = ImagePath;
                txtfname.Text = ds.Tables[0].Rows[0]["fname"].ToString();
                txtlname.Text = ds.Tables[0].Rows[0]["lname"].ToString();
                txtemailid.Text = ds.Tables[0].Rows[0]["emailid"].ToString();
                txtcontactno.Text = ds.Tables[0].Rows[0]["contact"].ToString();
                ddlcountry.SelectedValue = ds.Tables[0].Rows[0]["CountryName"].ToString();
                ddlState1.Text = ds.Tables[0].Rows[0]["stateName"].ToString();
                txtaddress.Text = ds.Tables[0].Rows[0]["address"].ToString();
                txtrefempid.Text = ds.Tables[0].Rows[0]["refempid"].ToString();
                btnSave.Text = "Update";
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string fileurl = ViewState["imgurl"]?.ToString() ?? "";

                if (fuProfile.HasFile)
                {
                    fileurl = UploadPhoto(fuProfile, "Profile Photo", "Photo", "ClientDocsPath", 200);
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
                obj.stateid = Convert.ToInt32(ddlState1.SelectedValue);
                obj.address = txtaddress.Text.Trim();
                obj.refempid = Convert.ToString(txtrefempid.Text.Trim());
                obj.id = Convert.ToInt32(uid);
                cls.UpdateClientData(obj);
                CommonFunction.MessageBox(this, "S", "Profile has been updated successfully!!");
                cmf.ClearAllControls(Page);
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }
    }
}