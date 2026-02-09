using COMMON;
using DAL;
using ENTITY;
using System;
using System.Data;
using System.IO;
using System.Linq;

namespace SayyarahCars.CommonMasters
{
    public partial class AddBodyType : System.Web.UI.Page
    {
        public CommonFunction cmf = new CommonFunction();
        clsMasters cls = new clsMasters();
        entbodyType obj = new entbodyType();

        public string uid = "0";
        public string LogoPath = "";
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnSubmit.Text != "Update")
                {
                    if (fuImage.HasFile)
                    {
                        LogoPath = CommonFunction.SaveImg(this, fuImage, "~/Contents/admin/images/");
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
                    }
                    obj.Id = Convert.ToInt32(hdnId.Value);
                    obj.BodyTypeName = txtTypeName.Text.Trim();
                    obj.BodyTypeIcon = LogoPath;
                    obj.uid = uid;
                    if (rdoactive.Checked)
                    {
                        obj.Archive = false;
                    }
                    else
                    {
                        obj.Archive = true;
                    }
                    int result = cls.InsertBodyType(obj);
                    if (result != 0)
                    {
                        CommonFunction.MessageBox(this, "S", "Record saved successfully!!");
                        cmf.ClearAllControls(Page);
                    }
                }

                else
                {
                    LogoPath = HiddenFieldOldImage.Value;
                    if (fuImage.HasFile)
                    {
                        LogoPath = CommonFunction.SaveImg(this, fuImage, "~/Contents/admin/images/");
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
                    }
                    obj.Id = Convert.ToInt32(cmf.Decrypt(Request.QueryString["id"].ToString()));
                    obj.BodyTypeName = txtTypeName.Text.Trim();
                    obj.BodyTypeIcon = LogoPath;
                    obj.uid = uid;
                    if (rdoactive.Checked)
                    {
                        obj.Archive = false;

                    }
                    else
                    {
                        obj.Archive = true;
                    }
                    int result = cls.updateBodyType(obj);
                    if (result != 0)
                    {
                        btnSubmit.Text = "Submit";
                        txtTypeName.Text = "";
                        LogoPath = "";
                        CommonFunction.MessageBox(this, "S", "Record saved successfully!!");
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
            DataSet ds = cls.SelectBodyTypeByID(obj);
            if (ds.Tables[0].Rows.Count > 0)
            {
                hdnId.Value = cmf.Encrypt(ds.Tables[0].Rows[0]["id"].ToString());
                txtTypeName.Text = ds.Tables[0].Rows[0]["BodyTypeName"].ToString();
                HiddenFieldOldImage.Value = ds.Tables[0].Rows[0]["BodyTypeIcon"].ToString();
                string fileName = ds.Tables[0].Rows[0]["BodyTypeIcon"].ToString();
                if (!string.IsNullOrEmpty(fileName))
                {
                    imgPreview.ImageUrl = fileName;
                    imgPreview.Visible = true;
                }
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