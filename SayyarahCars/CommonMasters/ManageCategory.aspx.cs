using COMMON;
using DAL;
using ENTITY;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SayyarahCars.CommonMasters
{
    public partial class ManageCategory : System.Web.UI.Page
    {
        clsMasters cls = new clsMasters();
        CategoryModel category = new CategoryModel();
        public CommonFunction cmf = new CommonFunction();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Category();
                binddata("0");
            }
        }

        public void Category()
        {
            DataSet ds = new DataSet();
            ds = cls.SelectCategoryByPID("0");
            cmf.BindDropDownList(ddlpid, ds, "CategoryName", "id");
            ListItem li = new ListItem("Select Category", "0");
            ddlpid.Items.Insert(0, li);
        }
        public void binddata(string pid)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = cls.SelectCategoryByPID(pid);
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "EditRow")
                {
                    int id = Convert.ToInt32(e.CommandArgument);
                    DataSet ds = cls.SelectCatgeoryByID(id.ToString());
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        hdnid.Value = cmf.Encrypt(ds.Tables[0].Rows[0]["id"].ToString());
                        if (ds.Tables[0].Rows[0]["pid"].ToString() == "0")
                        {
                            ddltype.SelectedValue = "1";
                            divPid.Visible = false;
                            lbltitle.Text = "Category Name";
                        }
                        else
                        {
                            ddltype.SelectedValue = "2";
                            lbltitle.Text = "Sub-Category Name";
                            divPid.Visible = true;
                        }
                        ddlpid.SelectedValue = ds.Tables[0].Rows[0]["pid"].ToString();
                        txtName.Text = ds.Tables[0].Rows[0]["CategoryName"].ToString();
                        ViewState["icon"] = ds.Tables[0].Rows[0]["CategoryIcon"].ToString();
                        imgPreview.ImageUrl = ds.Tables[0].Rows[0]["CategoryIcon"].ToString();
                        if (ds.Tables[0].Rows[0]["CategoryIcon"].ToString() != string.Empty)
                        {
                            imgPreview.Visible = true;
                        }
                        else
                        {
                            imgPreview.Visible = false;
                        }
                        RadioAD.SelectedValue = ds.Tables[0].Rows[0]["Archive"].ToString();
                        btnsubmit.Text = "Update";
                    }
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
                string Id = id.ToString();
                string UID = Session["AID"].ToString();
                cls.DeleteCatgeory(Id, UID);
                binddata(ddlpid.SelectedValue);
                CommonFunction.MessageBox(this, "S", "Record deleted successfully!!");
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }
        protected void ddltype_SelectedIndexChanged(object sender, EventArgs e)
        {
            Category();
            ddlpid.SelectedValue = "0";
            if (ddltype.SelectedValue == "1")
            {
                divPid.Visible = false;
                lbltitle.Text = "Category Name";
            }
            else
            {
                lbltitle.Text = "Sub-Category Name";
                divPid.Visible = true;
            }
            binddata(ddlpid.SelectedValue);
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string message = "", filepath = "";
                if (ViewState["icon"] != null)
                {
                    filepath = ViewState["icon"].ToString();
                }
                if (FileUpload1.HasFile)
                {
                    string[] allowedMimeTypes = { "image/JPG", "image/JPEG", "image/PNG", "image/x-png", "image/pjpeg" };
                    int result = FileUploadUtility.ValidateFile(FileUpload1, "Category Icon", allowedMimeTypes, 200, out message);
                    if (result == 0)
                    {
                        filepath = FileUploadUtility.UploadFile(FileUpload1, "Icon", "IconsPath", out message);
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
                if (ddltype.SelectedValue == "1")
                {
                    category.pid = "0";
                }
                else
                {
                    category.pid = ddlpid.SelectedValue;
                }
                category.CategoryName = txtName.Text.Trim();
                category.CategoryIcon = filepath;
                category.cActive =Convert.ToBoolean(RadioAD.SelectedValue);
                category.uid = Session["AID"].ToString();
                if (btnsubmit.Text != "Update")
                {
                    int temp = cls.InsertCategory(category);
                    if (temp == 1)
                    {
                        txtName.Text = "";
                        imgPreview.ImageUrl = "";
                        imgPreview.Visible = false;
                        RadioAD.SelectedIndex = 0;
                        ViewState["icon"] = null;
                        CommonFunction.MessageBox(this, "S", "Record saved successfully!!");
                        binddata(ddlpid.SelectedValue);
                    }
                    else if (temp == 2)
                    {
                        CommonFunction.MessageBox(this, "E", "Name is already exists!!");
                    }
                    else
                    {
                        CommonFunction.MessageBox(this, "E", "Something went wrong. Please try again later!!");
                    }
                }
                else
                {
                    category.Id = Convert.ToInt32(cmf.Decrypt(hdnid.Value));
                    int temp = cls.UpdateCategory(category);
                    if (temp == 1)
                    {
                        txtName.Text = "";
                        imgPreview.ImageUrl = "";
                        imgPreview.Visible = false;
                        RadioAD.SelectedIndex = 0;
                        ViewState["icon"] = null;
                        CommonFunction.MessageBox(this, "S", "Record updated successfully!!");
                        binddata(ddlpid.SelectedValue);
                        btnsubmit.Text = "Save";
                    }
                    else if (temp == 2)
                    {
                        CommonFunction.MessageBox(this, "E", "Name is already exists!!");
                    }
                    else
                    {
                        CommonFunction.MessageBox(this, "E", "Something went wrong. Please try again later!!");
                    }
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void ddlpid_SelectedIndexChanged(object sender, EventArgs e)
        {
            binddata(ddlpid.SelectedValue);
        }
    }
}