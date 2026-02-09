using COMMON;
using DAL;
using DAL.Reports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SayyarahCars.Admin
{
    public partial class Update_Fuzokuhin : System.Web.UI.Page
    {
        clsOtherReport clsOtherReport = new clsOtherReport();
        clsAdmin clsAdmin = new clsAdmin();
        CommonFunction cmf = new CommonFunction();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetAllFuzuhokin();
            }
        }

        public void GetAllFuzuhokin()
        {
            int Id = 0;
            try
            {
                ds = clsOtherReport.GetAllFuzokuhin(Id);
                if (ds != null || ds.Tables.Count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                CommonFunction.DisplayAlert(this, ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string allFnames = "";
            try
            {
                ds = clsOtherReport.checkchasisNo(txtchassis.Text.Trim());
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (GridViewRow row in GridView1.Rows)
                    {
                        Label lblid = row.FindControl("lblId") as Label;
                        CheckBox chk = row.FindControl("Chkbox") as CheckBox;
                        if (chk.Checked)
                        {
                            Label lblFname = row.FindControl("lblFname") as Label;
                            if (lblFname != null)
                            {
                                if (!string.IsNullOrEmpty(allFnames))
                                    allFnames += ", ";
                                allFnames += lblFname.Text.Trim();
                            }
                            string message = "", filepath = "";
                            if (FileUpload1.HasFile)
                            {
                                string[] allowedMimeTypes = { "image/JPG", "image/JPEG", "image/PNG", "image/x-png", "image/pjpeg", "application/octet-stream" };
                                int result = FileUploadUtility.ValidateFile(FileUpload1, "Fuzokuhin Icon", allowedMimeTypes, 200, out message);
                                if (result == 0)
                                {
                                    filepath = FileUploadUtility.UploadFile(FileUpload1, "Fuzokuhin", "FuzokuhinIcon", out message);
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
                            int temp = clsOtherReport.addFuzokuhinData(txtchassis.Text.Trim(), allFnames, filepath, Session["AID"].ToString());
                            if (temp != 0)
                            {
                                CommonFunction.MessageBox(this, "S", "Record added successfully!!");
                            }
                        }
                    }
                    cmf.ClearAllControls(Page);
                }
                else
                {
                    CommonFunction.MessageBox(this, "W", "Invalid Chassis No.!!");
                }
                CommonFunction.MessageBox(this, "W", "Please select at least one checkbox!!");
            }
            catch (Exception ex)
            {
                CommonFunction.DisplayAlert(this, ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }
    }
}