using COMMON;
using DAL;
using ENTITY;
using System;
using System.Data;
using System.Web.UI;

namespace SayyarahCars.CommonMasters
{
    public partial class ManageCountry : System.Web.UI.Page
    {
        clsMasters cls = new clsMasters();
        CountryModel country = new CountryModel();
        CommonFunction commonFunction = new CommonFunction();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                bindAllCountry();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (btnSubmit.Text != "Update")
            {
                string message = "", filepath = "";
                if (FileUpload1.HasFile)
                {
                    string[] allowedMimeTypes = { "image/JPG", "image/JPEG", "image/PNG", "image/x-png", "image/pjpeg" };
                    int result = FileUploadUtility.ValidateFile(FileUpload1, "Country Icon", allowedMimeTypes, 200, out message);
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
                country.CountryName = txtCountryName.Text.Trim();
                country.CountryCode = txtCountryCode.Text.Trim();              
                country.Countryicon = filepath;
                country.cActive = RadioAD.SelectedValue;
                int temp = cls.AddCountry(country, Session["AID"].ToString());
                if (temp != 0)
                {
                    CommonFunction.MessageBox(this, "S", "Record saved successfully!!");
                    bindAllCountry();
                    RadioAD.SelectedIndex = 0;
                    imgPreview.ImageUrl = "";
                    commonFunction.ClearAllControls(Page);
                }
            }
            else
            {
                string message = "", filepath = HiddenFieldOldImage.Value;
                if (FileUpload1.HasFile)
                {
                    string[] allowedMimeTypes = { "image/JPG", "image/JPEG", "image/PNG", "image/x-png", "image/pjpeg" };
                    int result = FileUploadUtility.ValidateFile(FileUpload1, "Country Icon", allowedMimeTypes, 200, out message);
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
                country.CountryName = txtCountryName.Text.Trim();
                country.CountryCode = txtCountryCode.Text.Trim();                
                country.Countryicon = filepath;
                country.cActive = RadioAD.SelectedValue;
                country.Id = Convert.ToInt32(HiddenFieldID.Value);
                int temp = cls.UpdateCountryMaster(country, Session["AID"].ToString());
                if (temp != 0)
                {
                    CommonFunction.MessageBox(this, "S", "Record updated successfully!!");
                    bindAllCountry();
                    RadioAD.SelectedIndex = 0;
                    imgPreview.ImageUrl = "";
                    commonFunction.ClearAllControls(Page);
                }
            }
        }

        public void bindAllCountry()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = cls.ViewAllCountry();
                if (ds.Tables["Table"].Rows.Count > 0)
                {
                    GridView1.DataSource = ds.Tables["Table"];
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = ds.Tables["Table"];
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void GridView1_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditRow")
            {
                string Id = e.CommandArgument.ToString();
                DataSet ds = cls.GetCountryById(Id);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtCountryName.Text = ds.Tables[0].Rows[0]["CountryName"].ToString();
                    txtCountryCode.Text = ds.Tables[0].Rows[0]["ISDCode"].ToString();                    
                    HiddenFieldOldImage.Value = ds.Tables[0].Rows[0]["Flag"].ToString();
                    string fileName = ds.Tables[0].Rows[0]["Flag"].ToString();
                    if (!string.IsNullOrEmpty(fileName))
                    {
                        imgPreview.ImageUrl = fileName;
                        imgPreview.Visible = true;
                    }
                    string sactive = ds.Tables[0].Rows[0]["cActive"].ToString();
                    if (sactive.Trim() == "Active")
                    {
                        RadioAD.SelectedValue = "0";
                    }
                    else { RadioAD.SelectedValue = "1"; }
                    HiddenFieldID.Value = Id;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowModal", "setTimeout(function () { $('#add_region').modal('show'); }, 200);", true);
                    btnSubmit.Text = "Update";
                }
            }
            else
            {
                string Id = e.CommandArgument.ToString();
                string UID = Session["AID"].ToString();
                DataSet ds = cls.DeleteCountry(Convert.ToInt32(Id), Convert.ToInt32(UID));
                CommonFunction.MessageBox(this, "S", "Record deleted successfully!!");
                bindAllCountry();
            }
        }
    }
}