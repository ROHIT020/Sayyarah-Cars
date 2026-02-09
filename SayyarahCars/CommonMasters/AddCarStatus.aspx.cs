using COMMON;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SayyarahCars.CommonMasters
{
    public partial class AddCarStatus : System.Web.UI.Page
    {
        CommonFunction cmf = new CommonFunction();
        DataSet ds = new DataSet();
        clsMasters clsMasters = new clsMasters();
        public string uid = "0";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            { 
                GetAllCarStatus(); 
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnSubmit.Text != "Update")
                {
                    int result = clsMasters.AddcarStatus(txtCarStatus.Text.Trim(), Session["AID"].ToString());
                    if (result != 0)
                    {
                        CommonFunction.MessageBox(this, "S", "Record saved successfully!!");
                        GetAllCarStatus();
                        cmf.ClearAllControls(Page);
                    }
                    else
                    {
                        CommonFunction.MessageBox(this, "S", "Something went wrong. Please contact the admin");
                    }
                }
                else
                {
                    int temp = clsMasters.UpdateCarStatus(txtCarStatus.Text.Trim(), Convert.ToInt32(HiddenFieldID.Value), Session["AID"].ToString());
                    if (temp != 0)
                    {
                        CommonFunction.MessageBox(this, "S", "Record updated successfully!!");
                        GetAllCarStatus();
                    }
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        public void GetAllCarStatus()
        {
            int Id = 0;
            try
            {
                ds = clsMasters.getAllcarStatus(Id);
                if(ds.Tables[0].Rows.Count>0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditRow")
            {
                string Id = e.CommandArgument.ToString();
                ds = clsMasters.getAllcarStatus(Convert.ToInt32(Id));
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtCarStatus.Text = ds.Tables[0].Rows[0]["CarStatus"].ToString();
                    HiddenFieldID.Value = ds.Tables[0].Rows[0]["Id"].ToString();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowModal", "setTimeout(function () { $('#add_region').modal('show'); }, 200);", true);
                    btnSubmit.Text = "Update";
                }
            }
            else
            {
                string Id = e.CommandArgument.ToString();
                string UID = Session["AID"].ToString();
                DataSet ds = clsMasters.DeleteCarStatus(Convert.ToInt32(Id), Convert.ToInt32(UID));
                CommonFunction.MessageBox(this, "S", "Record deleted successfully!!");
                GetAllCarStatus();
            }
        }
    }
}