using COMMON;
using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SayyarahCars.Admin
{
    public partial class ViewBlog1 : System.Web.UI.Page
    {
        public CommonFunction cmf = new CommonFunction();
        clsAdmin cls = new clsAdmin();
        entBlog obj = new entBlog();
        public string uid = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        public void BindGrid(int pageNo=1)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = cls.ViewBlog();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    int pageSize = Convert.ToInt32(ddlpages.SelectedValue);
                    obj.PageNumber = pageNo.ToString();
                    obj.PageSize = pageSize.ToString();
                    GridView1.PageSize = int.Parse(ddlpages.SelectedValue);
                    GridView1.DataSource = ds;
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
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteRow")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                DeleteItem(id);
            }
            else if (e.CommandName == "EditRow")
            {
                Response.Redirect("AddBlog.aspx");
            }

        }
        private void DeleteItem(int id)
        {
            try
            {
                obj.id = id;
                obj.uid = Convert.ToInt32(uid);
                cls.deleteBlog(obj);
                BindGrid();
                CommonFunction.MessageBox(this, "S", "Record deleted successfully!!");
                cmf.ClearAllControls(Page);
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGrid(e.NewPageIndex + 1);
        }

        protected void ddlpages_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid();
        }
    }
}