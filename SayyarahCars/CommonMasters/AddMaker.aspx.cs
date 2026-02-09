using COMMON;
using DAL;
using ENTITY;
using System;

using System.Data;
using System.IO;
using System.Linq;


namespace SayyarahCars.CommonMasters
{
    public partial class AddMaker : System.Web.UI.Page
    {
        public CommonFunction cmf = new CommonFunction();
        clsMasters cls = new clsMasters();
        entmaker obj = new entmaker();

        public string uid = "0";
        public string LogoPath = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["AID"] != null)
                {
                    uid = Session["AID"].ToString();

                    if (!IsPostBack)
                    {
                        if (Request.QueryString["id"] != null)
                        {
                            binddata();
                        }
                    }
                }
                else
                {
                    Response.Redirect("~/Index.aspx", false);
                }

            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnOldFileName.Value != "")
                {
                    LogoPath = hdnOldFileName.Value;

                }
                if (fuImage.HasFiles)
                {
                    LogoPath = CommonFunction.SaveImg(this, fuImage, "~/Contents/admin/images/");
                }

                string ext = Path.GetExtension(fuImage.FileName).ToLower();
                string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif" };

                if (fuImage.HasFile && allowedExtensions.Contains(ext))
                {
                    ViewState["LogoPath"] = LogoPath;
                }
                else if (ViewState["LogoPath"] != null)
                {
                    LogoPath = ViewState["LogoPath"].ToString();
                }
                if (btnSubmit.Text != "Update")
                {
                    obj.Id = Convert.ToInt32(hdnId.Value);
                    obj.MakerName = txtMakerName.Text.Trim();
                    obj.MakerLogo = LogoPath;
                    obj.uid = uid;
                    obj.Archive = rdodeActive.Checked ? true : false;
                    int temp = cls.InsertMaker(obj);
                    if (temp != 0)
                    {
                        CommonFunction.MessageBox(this, "S", "Record saved successfully!!");
                        cmf.ClearAllControls(Page);
                    }
                }
                else
                {
                    obj.Id = Convert.ToInt32(cmf.Decrypt(Request.QueryString["id"].ToString()));
                    obj.MakerName = txtMakerName.Text.Trim();
                    obj.MakerLogo = LogoPath;
                    obj.uid = uid;
                    obj.Archive = rdodeActive.Checked ? true : false;
                    int temp = cls.updateMaker(obj);
                    if (temp != 0)
                    {
                        CommonFunction.MessageBox(this, "S", "Record updated successfully!!");
                        cmf.ClearAllControls(Page);
                    }
                }
                btnSubmit.Text = "Submit";
                txtMakerName.Text = "";
                LogoPath = "";
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
            DataSet ds = cls.SelectMakerByID(obj);
            if (ds.Tables[0].Rows.Count > 0)
            {
                hdnId.Value = cmf.Encrypt(ds.Tables[0].Rows[0]["id"].ToString());
                txtMakerName.Text = ds.Tables[0].Rows[0]["MakerName"].ToString();
                LogoPath = ds.Tables[0].Rows[0]["MakerLogo"].ToString();
                if (!string.IsNullOrEmpty(LogoPath))
                {
                    imgPreview.ImageUrl = LogoPath;
                    imgPreview.Visible = true;
                }
                hdnOldFileName.Value = ds.Tables[0].Rows[0]["MakerLogo"].ToString();
                string status = ds.Tables[0].Rows[0]["Archive"].ToString();
                if (status == "False")
                {
                    rdoactive.Checked = true;
                    rdodeActive.Checked = false;
                }
                else
                {
                    rdoactive.Checked = false;
                    rdodeActive.Checked = true;
                }
                btnSubmit.Text = "Update";
            }
        }
    }
}