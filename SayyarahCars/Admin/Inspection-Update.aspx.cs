using COMMON;
using DAL;
using ENTITY.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SayyarahCars.Admin
{
    public partial class Inspection_Update : System.Web.UI.Page
    {
        CommonFunction cmf = new CommonFunction();
        clsAdmin clsA = new clsAdmin();
        public string uid = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Divserver.Visible = false;
            }
        }
        public void BindData()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = clsA.GetInspection(txtChassisNo.Text);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = ds.Tables[0];
                    GridView1.DataBind();
                    Divserver.Visible = true;
                    btnDelete.Visible = true;
                }
                else
                {
                    GridView1.DataSource = ds.Tables[0];
                    GridView1.DataBind();
                    btnDelete.Visible = false;
                    Divserver.Visible = true;
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
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
            Inspection obj = new Inspection();
            obj.ChassisNo = txtChassisNo.Text;
            obj.InsRRDate = txtIRRDate.Text;
            obj.InsRRRemark = txtIRRRemark.Text;
            obj.PayFInsDate = txtDofPForI.Text;
            obj.PayFInsRemark = txtDofInsRemark.Text;
            obj.InsDate = txtdateofInspection.Text;
            obj.InsDRemark = txtDofInsRemark.Text;
            obj.InsStatus = txtInsStatus.Text;
            obj.InsSRemark = txtInsStatusRemark.Text;
            obj.InsDocSend = txtInsDocSent.Text;
            obj.InsDocSRemark = txtInsDocSRemark.Text;
            obj.InsDocBack = txtInsDocBack.Text;
            obj.InsDocBRemark = txtInsDocBRemark.Text;
            obj.Certificate = filepath;
            obj.Uid = Session["AID"].ToString();
            int temp = clsA.GetAddAllInspection(obj);
            if (temp > 0)
            {
                CommonFunction.MessageBox(this, "S", "Inspection Add Successfully!!!");
                BindData();
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int i = 0;
            try
            {
                foreach (GridViewRow row in GridView1.Rows)
                {
                    CheckBox chk = row.FindControl("Chkbox") as CheckBox;
                    if (chk.Checked)
                    {
                        Label lblid = row.FindControl("lblpid") as Label;
                        i = clsA.deleteInspectionDetails(lblid.Text);
                        if (i > 0)
                        {
                            i = i + 1;
                        }
                    }
                }
                if (i > 0)
                {
                    CommonFunction.MessageBox(this, "S", "Record is Deleted Successfully!!!");
                    BindData();
                }
            }
            catch (Exception ex)
            {
                CommonFunction.DisplayAlert(this, ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }

        }
    }
}