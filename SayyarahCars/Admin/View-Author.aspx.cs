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
    public partial class View_Author : System.Web.UI.Page
    {
        public CommonFunction cmf = new CommonFunction();
        clsAdmin cls = new clsAdmin();
        entAuthor obj = new entAuthor();
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
                    BindGrid();
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }
        private void BindGrid()
        {
            try
            {
                DataSet ds = cls.SelectAuthor();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "EditRow")
                {
                    binddata(e.CommandArgument.ToString());
                }
                else if (e.CommandName == "DeleteRow")
                {
                    int id = Convert.ToInt32(e.CommandArgument);
                    DeleteItem(id);
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }
        private void DeleteItem(int id)
        {
            try
            {
                obj.Id = id;
                obj.uid = uid;
                cls.DeleteAuthor(obj);
                CommonFunction.MessageBox(this, "S", "Record deleted successfully!!");
                BindGrid();
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }
        protected void binddata(string id)
        {
            obj.Id = Convert.ToInt32(id);
            DataSet ds = cls.SelectAuthorById(obj);
            if (ds.Tables[0].Rows.Count > 0)
            {
                hdnId.Value = ds.Tables[0].Rows[0]["id"].ToString();
                txtAuthor.Text = ds.Tables[0].Rows[0]["AuthorName"].ToString();
                txtDescriptions.Text = ds.Tables[0].Rows[0]["Description"].ToString();
                HiddenFieldOldImage.Value = ds.Tables[0].Rows[0]["AuthorImg"].ToString();
                string fileName = ds.Tables[0].Rows[0]["AuthorImg"].ToString();
                if (!string.IsNullOrEmpty(fileName))
                {
                    imgPreview.ImageUrl = fileName;
                    imgPreview.Visible = true;
                }
                btnSubmit.Text = "Update";
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (btnSubmit.Text != "Update")
            {
                string message = "", filepath = "";
                if (authorImage.HasFile)
                {
                    string[] allowedMimeTypes = { "image/JPG", "image/JPEG", "image/PNG", "image/x-png", "image/pjpeg" };
                    int result = FileUploadUtility.ValidateFile(authorImage, "Author Image", allowedMimeTypes, 1024, out message);
                    if (result == 0)
                    {
                        filepath = FileUploadUtility.UploadFile(authorImage, "Image", "ImagePath", out message);
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
                obj.AName = txtAuthor.Text.Trim();
                obj.AImage = filepath;
                obj.Description = txtDescriptions.Text.Trim();
                cls.AddAuthor(obj);
                BindGrid();
                CommonFunction.MessageBox(this, "S", "Record saved successfully!!");
                imgPreview.Visible = false;
                cmf.ClearAllControls(Page);
            }
            else
            {

                string message = "", filepath = HiddenFieldOldImage.Value;
                if (authorImage.HasFile)
                {
                    string[] allowedMimeTypes = { "image/JPG", "image/JPEG", "image/PNG", "image/x-png", "image/pjpeg" };
                    int result = FileUploadUtility.ValidateFile(authorImage, "Author Image", allowedMimeTypes, 1024, out message);
                    if (result == 0)
                    {
                        filepath = FileUploadUtility.UploadFile(authorImage, "Image", "ImagePath", out message);
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
                obj.Id = Convert.ToInt32(hdnId.Value);
                obj.AName = txtAuthor.Text.Trim();
                obj.AImage = filepath;
                obj.Description = txtDescriptions.Text.Trim();
                cls.UpdateAuthor(obj);
                BindGrid();
                CommonFunction.MessageBox(this, "S", "Record Updated successfully!!");
                imgPreview.Visible = false;
                cmf.ClearAllControls(Page);
            }
        }

        protected void btnreload_Click(object sender, EventArgs e)
        {
            BindGrid();
        }
    }
}