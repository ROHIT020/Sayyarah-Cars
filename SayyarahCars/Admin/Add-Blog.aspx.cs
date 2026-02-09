using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using COMMON;
using DAL;
using ENTITY;

namespace SayyarahCars.Admin
{
    public partial class Add_Blog : System.Web.UI.Page
    {
        public CommonFunction cmf = new CommonFunction();
        clsAdmin cls = new clsAdmin();
        entBlogs obj = new entBlogs();

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
                    BindBlogTopic();
                    if (Request.QueryString["id"] != null)
                    {
                        GetBlogsById();
                    }
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }
        protected void BindBlogTopic()
        {
            DataSet ds = cls.GetBlogTopic();
            cmf.BindDropDownList(ddlTopic, ds, "Topic", "id");
            ListItem li = new ListItem("--Select Blog Topic--", "0");
            ddlTopic.Items.Insert(0, li);
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (btnSubmit.Text != "Update")
            {

                string message = "", filepath = "";
                if (flpblog.HasFile)
                {
                    string[] allowedMimeTypes = { "image/JPG", "image/JPEG", "image/PNG", "image/x-png", "image/pjpeg" };
                    int result = FileUploadUtility.ValidateFile(flpblog, "Blog Image", allowedMimeTypes, 5120, out message);
                    if (result == 0)
                    {
                        filepath = FileUploadUtility.UploadFile(flpblog, "Image", "ImagePath", out message);
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
                obj.TopicId = ddlTopic.SelectedIndex;
                obj.BlogTitle = txtBlogTitle.Text.Trim();
                obj.BlogURL = txtBlogURL.Text.Trim();
                obj.BlogDate = txtBlogDate.Text;
                obj.BlogImage = filepath;
                cls.insertBlogs(obj);
                CommonFunction.MessageBox(this, "S", "Record saved successfully!!");
                imgPreview.Visible = false;
                cmf.ClearAllControls(Page);
            }
            else
            {

                string message = "", filepath = hdnOldImage.Value;
                if (flpblog.HasFile)
                {
                    string[] allowedMimeTypes = { "image/JPG", "image/JPEG", "image/PNG", "image/x-png", "image/pjpeg" };
                    int result = FileUploadUtility.ValidateFile(flpblog, "Author Image", allowedMimeTypes, 5120, out message);
                    if (result == 0)
                    {
                        filepath = FileUploadUtility.UploadFile(flpblog, "Image", "ImagePath", out message);
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
                obj.id = Convert.ToInt32(hdnId.Value);
                obj.TopicId = ddlTopic.SelectedIndex;
                obj.BlogTitle = txtBlogTitle.Text.Trim();
                obj.BlogURL = txtBlogURL.Text.Trim();
                obj.BlogDate = txtBlogDate.Text;
                obj.BlogImage = filepath;
                cls.updateBlogs(obj);
                CommonFunction.MessageBox(this, "S", "Record Updated successfully!!");
                imgPreview.Visible = false;
                btnSubmit.Text = "Submit";
                cmf.ClearAllControls(Page);
            }
        }

        public void GetBlogsById()
        {
            try
            {
                if (Request.QueryString["id"] != null)
                {
                    hdnId.Value = cmf.Decrypt(Request.QueryString["Id"].ToString());
                    obj.id =Convert.ToInt32(hdnId.Value);
                    DataSet ds = new DataSet();
                    ds = cls.selectBlogByid(obj);
                    if (ds.Tables["Table"].Rows.Count > 0)
                    {
                        hdnId .Value = ds.Tables[0].Rows[0]["id"].ToString();
                        ddlTopic.SelectedValue = ds.Tables[0].Rows[0]["TopicId"].ToString();
                        txtBlogTitle.Text = ds.Tables[0].Rows[0]["BlogTitle"].ToString();
                        txtBlogURL.Text = ds.Tables[0].Rows[0]["BlogURL"].ToString();
                        txtBlogDate.Text = ds.Tables[0].Rows[0]["BlogDate"].ToString();
                        hdnOldImage.Value = ds.Tables[0].Rows[0]["BlogImage"].ToString();
                        string fileName = ds.Tables[0].Rows[0]["BlogImage"].ToString();
                        if (!string.IsNullOrEmpty(fileName))
                        {
                            imgPreview.ImageUrl = fileName;
                            imgPreview.Visible = true;
                        }
                        btnSubmit.Text = "Update";
                    }
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }
    }
}