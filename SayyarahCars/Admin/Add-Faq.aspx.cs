using COMMON;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SayyarahCars.Admin
{
    public partial class Add_Faq : System.Web.UI.Page
    {
        clsAdmin clsAdmin = new clsAdmin();
        DataSet ds = new DataSet();
        CommonFunction cmf = new CommonFunction();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["Id"] != null)
                {
                    getFaqById();
                }
                if (Session["UpdateMessage"] != null)
                {
                    CommonFunction.MessageBox(this, "S", "Record updated successfully!!");
                    Session.Remove("UpdateMessage");
                }
            } 
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnSubmit.Text != "Update")
                {
                    int temp = clsAdmin.addFaqDetails(txtQuestion.Text.Trim(), txtAnswer.Text.Trim(), Session["AID"].ToString());

                    if (temp != 0)
                    {
                        CommonFunction.MessageBox(this, "S", "Record saved successfully!!");
                        cmf.ClearAllControls(Page);
                    }
                }
                else
                {
                    int Id = Convert.ToInt32(hdnFaqId.Value);
                    int temp = clsAdmin.updateFaqById(txtQuestion.Text, txtAnswer.Text, Id, Session["AID"].ToString());

                    if (temp != 0)
                    {
                        Session["UpdateMessage"] = "Record updated successfully!!";
                        //CommonFunction.MessageBox(this, "S", "Record updated successfully!!");
                        //Response.Redirect(Request.RawUrl);
                        Response.Redirect("~/Admin/View-faq.aspx");

                    }
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        public void getFaqById()
        {
            try
            {
                string Id = Request.QueryString["Id"].ToString();

                ds = clsAdmin.getFaqByid(Id);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    hdnFaqId.Value = ds.Tables[0].Rows[0]["Id"].ToString();
                    txtQuestion.Text = ds.Tables[0].Rows[0]["Question"].ToString();
                    txtAnswer.Text = ds.Tables[0].Rows[0]["Answer"].ToString();
                    btnSubmit.Text = "Update";
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