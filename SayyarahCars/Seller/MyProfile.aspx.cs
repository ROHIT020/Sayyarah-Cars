using COMMON;
using DAL;
using ENTITY;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace SayyarahCars.Seller
{
    public partial class MyProfile : System.Web.UI.Page
    {
        CommonFunction cmf = new CommonFunction();
        clsClients cls = new clsClients();
        SellerModel sellerModel = new SellerModel();
        public string uid = "0";
        public string ImagePath = "";
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SID"] != null)
            {
                uid = Session["SID"].ToString();
            }
            if (!IsPostBack)
            {
                GetSellerData();
            }
            if (Session["successMail"] != null)
            {
                CommonFunction.MessageBox(this, "S", Session["successMail"].ToString());
                Session.Remove("successMail");
            }
        }

        protected void GetSellerData()
        {
            string Id = Convert.ToString(Session["SID"]);
            ds = cls.GetSellerById(Convert.ToInt32(Id));
            if (ds.Tables[0].Rows.Count > 0)
            {
                hdnProfileId.Value = Convert.ToString(ds.Tables[0].Rows[0]["Id"]);
                txtfname.Text = Convert.ToString(ds.Tables[0].Rows[0]["FName"]);
                txtlname.Text = Convert.ToString(ds.Tables[0].Rows[0]["LName"]);
                txtemailid.Text = Convert.ToString(ds.Tables[0].Rows[0]["Email"]);
                txtcontactno.Text = Convert.ToString(ds.Tables[0].Rows[0]["MobileNo"]);
                txtPassword.Text = Convert.ToString(ds.Tables[0].Rows[0]["Password"]);
                txtnationality.Text = Convert.ToString(ds.Tables[0].Rows[0]["Nationality"]);
                txtdateofBirth.Text = Convert.ToString(ds.Tables[0].Rows[0]["DateOfBirth"]);
                txtaddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["Address"]);
                hdnProfilePic.Value = ds.Tables[0].Rows[0]["ProfilePic"].ToString();
                string fileName = ds.Tables[0].Rows[0]["ProfilePic"].ToString();
                if (!string.IsNullOrEmpty(fileName))
                {
                    imgPreview.ImageUrl = fileName;
                    imgPreview.Visible = true;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string fileurl = string.Empty;
                if (hdnProfilePic.Value != null)
                {
                    fileurl = hdnProfilePic.Value;
                }
                if (fuProfile.HasFile)
                {
                    fileurl = UploadPhoto(fuProfile, "Profile Photo", "Photo", "SellerDoc", 200);
                    if (fileurl == string.Empty)
                    {
                        return;
                    }
                }
                sellerModel.Id = Convert.ToInt32(hdnProfileId.Value);
                sellerModel.FirstName = txtfname.Text;
                sellerModel.LastName = txtlname.Text;
                sellerModel.Email = txtemailid.Text;
                sellerModel.MobileNo = txtcontactno.Text;
                sellerModel.Password = txtPassword.Text;
                sellerModel.Nationality = txtnationality.Text;
                sellerModel.DateOfBirth = txtdateofBirth.Text;
                sellerModel.Address = txtaddress.Text;
                sellerModel.ProfilePic = fileurl;
                int temp = cls.updateProFileById(sellerModel, Session["SID"].ToString());
                if (temp != 0)
                {
                    CommonFunction.MessageBox(this, "S", "Record updated successfully!!");
                    GetSellerData();
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
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
    }
}