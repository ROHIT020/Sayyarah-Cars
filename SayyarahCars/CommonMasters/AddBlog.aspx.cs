using COMMON;
using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SayyarahCars.CommonMasters
{
    public partial class AddBlog : System.Web.UI.Page
    {
        public CommonFunction cmf = new CommonFunction();
        clsAdmin cls = new clsAdmin();
        entBlog obj = new entBlog();
        public string uid = "0";
        public string blogimage = "";
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
                    bindBlogTopic();
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
        protected void bindBlogTopic()
        {
            DataSet ds = cls.btopicBind();
            cmf.BindDropDownList(ddltopic, ds, "btopic", "id");
            ListItem li = new ListItem("--Select Topic--", "0");
            ddltopic.Items.Insert(0, li);
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnSubmit.Text != "Update")
                {
                    string message = "", filepath = "";
                    if (fuImage.HasFile)
                    {
                        string[] allowedMimeTypes = { "image/JPG", "image/JPEG", "image/PNG", "image/x-png", "image/pjpeg" };
                        int result = FileUploadUtility.ValidateFile(fuImage, "Blog Image", allowedMimeTypes, 800, out message);
                        if (result == 0)
                        {
                            filepath = FileUploadUtility.UploadFile(fuImage, "Blog Image", "BlogPath", out message);
                            if (string.IsNullOrEmpty(filepath))
                            {
                                CommonFunction.MessageBox(this, "E", message);
                                return;
                            }
                        }
                        else
                        {
                            CommonFunction.MessageBox(this, "E", message);
                            return;
                        }
                    }

                    obj.blang = ddllanguage.SelectedValue;
                    obj.btopicid = Convert.ToInt32(ddltopic.SelectedValue);
                    obj.btitle = txtbtitle.Text.Trim();
                    obj.burl = txtburl.Text.Trim();
                    obj.bdate = txtdate.Text.Trim();
                    obj.bimage = filepath;
                    obj.ptitle = txtptitle.Text.Trim();
                    obj.keytag = txtkeyword.Text.Trim();
                    obj.desctag = txtdescription.Text.Trim();
                    obj.sdetails = txtbsd.Text.Trim();
                    obj.fdetails = txtPageContent.Text.Trim();
                    obj.uid = Convert.ToInt32(uid);
                    cls.insertBlogdata(obj);
                    CommonFunction.MessageBox(this, "S", "Record saved successfully!!", "close");
                    cmf.ClearAllControls(Page);
                }
                else
                {
                    string message = "", filepath = HiddenFieldOldImage.Value;
                    if (fuImage.HasFile)
                    {

                        string[] allowedMimeTypes = { "image/JPG", "image/JPEG", "image/PNG", "image/x-png", "image/pjpeg" };
                        int result = FileUploadUtility.ValidateFile(fuImage, "Blog Image", allowedMimeTypes,2000, out message);
                        if (result == 0)
                        {
                            filepath = FileUploadUtility.UploadFile(fuImage, "Blog Image", "BlogPath", out message);
                            if (string.IsNullOrEmpty(filepath))
                            {
                                CommonFunction.MessageBox(this, "E", message);
                                return;
                            }
                        }
                        else
                        {
                            CommonFunction.MessageBox(this, "E", message);
                            return;
                        }
                    }
                    obj.blang = ddllanguage.SelectedValue;
                    obj.btopicid = Convert.ToInt32(ddltopic.SelectedValue);
                    obj.btitle = txtbtitle.Text.Trim();
                    obj.burl = txtburl.Text.Trim();
                    obj.bdate = txtdate.Text.Trim();
                    obj.bimage = filepath;
                    obj.ptitle = txtptitle.Text.Trim();
                    obj.keytag = txtkeyword.Text.Trim();
                    obj.desctag = txtdescription.Text.Trim();
                    obj.sdetails = txtbsd.Text.Trim();
                    obj.fdetails = txtPageContent.Text.Trim();
                    obj.uid = Convert.ToInt32(uid);
                    obj.id = Convert.ToInt32(cmf.Decrypt(Request.QueryString["id"].ToString()));
                   int temp= cls.updateBlogData(obj);
                    if (temp != 0)
                    {
                        CommonFunction.MessageBox(this, "S", "Record updated successfully!!", "ViewBlog.aspx");
                        cmf.ClearAllControls(Page);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void binddata()
        {
            obj.id = Convert.ToInt32(cmf.Decrypt(Request.QueryString["id"].ToString()));
            DataSet ds = cls.SelectBlogByID(obj);
            if (ds.Tables[0].Rows.Count > 0)
            {
                hdnId.Value = cmf.Encrypt(ds.Tables[0].Rows[0]["id"].ToString());
                ddltopic.SelectedValue = ds.Tables[0].Rows[0]["btopicid"].ToString();
                txtbtitle.Text = ds.Tables[0].Rows[0]["btitle"].ToString();
                txtburl.Text = ds.Tables[0].Rows[0]["burl"].ToString();
                txtdate.Text = ds.Tables[0].Rows[0]["bdate"].ToString();
                txtptitle.Text = ds.Tables[0].Rows[0]["ptitle"].ToString();
                txtkeyword.Text = ds.Tables[0].Rows[0]["keytag"].ToString();
                txtdescription.Text = ds.Tables[0].Rows[0]["desctag"].ToString();
                txtbsd.Text = ds.Tables[0].Rows[0]["sdetails"].ToString();
                txtPageContent.Text = ds.Tables[0].Rows[0]["fdetails"].ToString();
                HiddenFieldOldImage.Value = ds.Tables[0].Rows[0]["bimage"].ToString();
                string fileName = ds.Tables[0].Rows[0]["bimage"].ToString();
                if (!string.IsNullOrEmpty(fileName))
                {
                    imgPreview.ImageUrl = fileName;
                    imgPreview.Visible = true;
                }
                btnSubmit.Text = "Update";
            }
        }
    }
}