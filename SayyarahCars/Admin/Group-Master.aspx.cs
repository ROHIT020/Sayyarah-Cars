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
    public partial class Group_Master : System.Web.UI.Page
    {
        CommonFunction cmf = new CommonFunction();
        clsAdmin clsAdmin = new clsAdmin();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetAllGroup();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnSubmit.Text != "Update")
                {
                    int temp = clsAdmin.AddGroup(txtGroupName.Text.Trim(), Session["AID"].ToString());
                    if (temp != 0)
                    {
                        CommonFunction.MessageBox(this, "S", "Record saved successfully!!");
                        cmf.ClearAllControls(Page);
                    }
                }
                else
                {
                    int temp = clsAdmin.updateGroup(txtGroupName.Text.Trim(), hdnGroupId.Value, Session["AID"].ToString());
                    if (temp != 0)
                    {
                        CommonFunction.MessageBox(this, "S", "Record updated successfully!!");
                        GetAllGroup();
                    }
                } 
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        public void GetAllGroup()
        {
            int Id = 0;
            try
            {
                ds = clsAdmin.GetAllGroup(Id);
                if (ds!=null)
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
                ds = clsAdmin.GetAllGroup(Convert.ToInt32(Id));
                if (ds.Tables[0].Rows.Count > 0)
                {
                    hdnGroupId.Value = ds.Tables[0].Rows[0]["Id"].ToString();
                    txtGroupName.Text = ds.Tables[0].Rows[0]["GroupName"].ToString();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowModal", "setTimeout(function () { $('#add_region').modal('show'); }, 200);", true);
                    btnSubmit.Text = "Update";
                }
            }
            else if(e.CommandName == "DeleteRow")
            {
                string Id = e.CommandArgument.ToString();
                int temp = clsAdmin.DeleteGroup(Id, Session["AID"].ToString());
                if (temp != 0)
                {
                    CommonFunction.MessageBox(this, "S", "Record deleted successfully!!");
                    GetAllGroup();
                }
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GetAllGroup();
        }
    }
}