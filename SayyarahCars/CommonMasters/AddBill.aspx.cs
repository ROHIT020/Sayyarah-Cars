using COMMON;
using DAL;
using ENTITY;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;

namespace SayyarahCars.CommonMasters
{
    public partial class AddBill : System.Web.UI.Page
    {
        public CommonFunction cmf = new CommonFunction();
        clsMasters cls = new clsMasters();
        entBill obj = new entBill();
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
                    bindDocument();
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
        protected void bindDocument()
        {
            DataSet ds = cls.DocumentBind();
            cmf.BindDropDownList(ddlDocument, ds, "DocumentName", "Id");
            ListItem li = new ListItem("--Select Document--", "0");
            ddlDocument.Items.Insert(0, li);
        }

        protected void binddata()
        {
            obj.Id = Convert.ToInt32(cmf.Decrypt(Request.QueryString["id"].ToString()));
            DataSet ds = cls.SelectBillByID(obj);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlDocument.SelectedValue = ds.Tables[0].Rows[0]["DocumentId"].ToString();
                txtBillDate.Text = ds.Tables[0].Rows[0]["BillDate"].ToString();
                LogoPath = ds.Tables[0].Rows[0]["UploadDocument"].ToString();
            }
        }

        protected void btnSubmit_Click1(object sender, EventArgs e)
        {
            try
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
                if (btnSubmit.Text != "Update")
                {
                    obj.DocumentId = Convert.ToInt32(ddlDocument.SelectedValue);
                    obj.BillDate = txtBillDate.Text.Trim();
                    obj.UploadDocument = LogoPath;
                    obj.uid = uid;

                    int result = cls.InsertBill(obj);
                    if (result != 0)
                    {
                        btnSubmit.Text = "Submit";
                        txtBillDate.Text = "";
                        ddlDocument.SelectedIndex = 0;
                        CommonFunction.DisplayAlert(this, "Record saved successfully!!");
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