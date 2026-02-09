using COMMON;
using DAL;
using ENTITY;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace SayyarahCars.Admin
{
    public partial class Manage_User : System.Web.UI.Page
    {
        public CommonFunction cmf = new CommonFunction();
        clsMasters cls = new clsMasters();
        entAdduser obj = new entAdduser();
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
                    BindDepartment();
                    BindDesignation();
                    BindGrid();
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }
        protected void BindDepartment()
        {
            DataSet ds = cls.DepartmentBind();
            cmf.BindDropDownList(ddldepartment, ds, "Department", "Id");
            ListItem li = new ListItem("--Select Department--", "0");
            ddldepartment.Items.Insert(0, li);
        }
        protected void BindDesignation()
        {
            DataSet ds = cls.DesignationBind();
            cmf.BindDropDownList(ddldesignation, ds, "Designation", "Id");
            ListItem li = new ListItem("--Select Designation--", "0");
            ddldesignation.Items.Insert(0, li);
        }
        private void BindGrid(int pageNo = 1)
        {
            try
            {
                int PageSize = GetPageSize();
                obj.Fname = txtname.Text.Trim();
                obj.Edepartment =Convert.ToInt32(ddldepartment.SelectedValue);
                obj.Designation = Convert.ToInt32(ddldesignation.SelectedValue);
                obj.PageNo = pageNo.ToString();
                obj.PageSize = PageSize.ToString();
                DataSet ds = cls.SelectUser(obj);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = ds.Tables[0];
                    GridView1.PageSize = PageSize;

                    if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                    {
                        GridView1.VirtualItemCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
                        GridView1.AllowCustomPaging = true;
                    }

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
        protected int GetPageSize()
        {
            int pageSize = 100;
            if (ddlPageSize.SelectedValue != "-1")
            {
                pageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
            }
            else
            {
                if (txtpagesize.Text != "0" && txtpagesize.Text != "")
                {
                    pageSize = Convert.ToInt32(txtpagesize.Text.Trim());
                }
            }
            txtpagesize.Text = pageSize.ToString();
            return pageSize;
        }
        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPageSize.SelectedValue == "-1")
            {
                txtpagesize.Visible = true;
            }
            else
            {
                txtpagesize.Visible = false;
            }
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGrid(e.NewPageIndex + 1);
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "DeleteRow")
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
                obj.uid = Convert.ToInt32(uid);
                cls.Deleteuser(obj);
                CommonFunction.MessageBox(this,"S", "Record deleted successfully!!");
                BindGrid();
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }
    }
}