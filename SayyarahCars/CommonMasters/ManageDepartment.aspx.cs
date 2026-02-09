using COMMON;
using DAL;
using ENTITY;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using COMMON.ResourceFile;

namespace SayyarahCars.CommonMasters
{
    public partial class ManageDepartment : System.Web.UI.Page
    {
        clsAdmin clsAdmin = new clsAdmin();
        DataSet ds = new DataSet();
        CommonFunction cmf = new CommonFunction();
        Department department = new Department();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetAllDepartment();
            }
        }

        public void GetAllDepartment()
        {
            int Id = 0;
            try
            {
                ds = clsAdmin.getAllDepartment(Id);
                if (ds.Tables[0].Rows.Count > 0)
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
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnSubmit.Text != "Update")
                {
                    department.DepartmentName = txtDepartmentName.Text.Trim();
                    department.Departmentcode = txtDepartmentCode.Text.Trim();
                    int temp = clsAdmin.AddDepartment(department, Session["AID"].ToString());
                    if (temp == 1)
                    {
                        CommonFunction.MessageBox(this, "S", Resource.successMsg);
                        cmf.ClearAllControls(Page);
                        GetAllDepartment();
                    }
                    if (temp == -1)
                    {
                        CommonFunction.MessageBox(this, "W", Resource.duplicateMsg);
                        cmf.ClearAllControls(Page);
                    }
                }
                else
                {
                    department.Id = Convert.ToInt32(hdnDepartmentId.Value);
                    department.DepartmentName = txtDepartmentName.Text.Trim();
                    department.Departmentcode = txtDepartmentCode.Text.Trim();
                    int temp = clsAdmin.updateDepartment(department, Session["AID"].ToString());
                    if (temp == 1)
                    {
                        CommonFunction.MessageBox(this, "S", Resource.updateMsg);
                        cmf.ClearAllControls(Page);
                        GetAllDepartment();
                    }
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
            try
            {
                if (e.CommandName == "EditRow")
                {
                    string Id = e.CommandArgument.ToString();

                    ds = clsAdmin.getAllDepartment(Convert.ToInt32(Id));
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        hdnDepartmentId.Value = ds.Tables[0].Rows[0]["Id"].ToString();
                        txtDepartmentName.Text = ds.Tables[0].Rows[0]["DepartmentName"].ToString();
                        txtDepartmentCode.Text = ds.Tables[0].Rows[0]["DepartmentCode"].ToString();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowModal", Resource.openModelPopup, true);
                        btnSubmit.Text = "Update";
                    }
                }
                else
                {
                    string Id = e.CommandArgument.ToString();
                    int temp = clsAdmin.deleteDepartment(Id, Session["AID"].ToString());
                    if (temp == 1)
                    {
                        CommonFunction.MessageBox(this, "S", Resource.deleteMsg);
                        GetAllDepartment();
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