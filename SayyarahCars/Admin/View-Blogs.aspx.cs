using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using COMMON;
using DAL;
using ENTITY;

namespace SayyarahCars.Admin
{
    public partial class View_Blogs : System.Web.UI.Page
    {
        protected CommonFunction cmf = new CommonFunction();
        clsMasters cls = new clsMasters();
        clsAdmin _clsA = new clsAdmin();
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
                    bindAuthor();
                    BindGrid();
                }

            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void BindGrid()
        {
            DataSet ds = _clsA.selectBlogs();
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteRow")
            {
                entBlogs ent = new entBlogs();
                ent.id = Convert.ToInt32(e.CommandArgument);
                ent.uid = Convert.ToInt32(uid);
                int rtval = _clsA.deleteBlogs(ent);
                CommonFunction.MessageBox(this, "S", "Record deleted successfully!!");
                BindGrid();
            }
        }
        protected void btnreload_Click(object sender, EventArgs e)
        {
            BindGrid();
        }
        protected void bindAuthor()
        {
            DataSet ds = _clsA.SelectAuthor();
            cmf.BindDropDownList(ddlAuthor, ds, "AuthorName", "ID");
            ListItem li = new ListItem("--Select Author--", "0");
            ddlAuthor.Items.Insert(0, li);
        }
        protected void btnAssignAuthor_Click(object sender, EventArgs e)
        {
            entBlogs ent = new entBlogs();
            int i = 0;
            try
            {
                foreach (GridViewRow row in GridView1.Rows)
                {
                    CheckBox chk = row.FindControl("Chkbox") as CheckBox;
                    if (chk.Checked)
                    {
                        HiddenField hdnid = row.FindControl("hdnid") as HiddenField;
                        ent.id = Convert.ToInt32(hdnid.Value);
                        ent.uid = Convert.ToInt32(uid);
                        ent.BlogAuthor= Convert.ToInt32(ddlAuthor.SelectedValue);
                        int temp = _clsA.AssignAuthortoBlog(ent);
                        if (temp > 0)
                        {
                            i = i + 1;
                        }
                    }
                }
                if (i > 0)
                {
                    ddlAuthor.SelectedIndex = 0;
                    CommonFunction.MessageBox(this, "S", "Author assigned successfully");
                    BindGrid();
                }
                else
                {
                    CommonFunction.MessageBox(this, "E", "Select atleast one record to update");
                    BindGrid();
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