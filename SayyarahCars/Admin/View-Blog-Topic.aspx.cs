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
    public partial class View_Blog_Topic : System.Web.UI.Page
    {
        public CommonFunction cmf = new CommonFunction();
        clsMasters cls = new clsMasters();
        entBlogTopic obj = new entBlogTopic();
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
                    BindGrid();
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }
        private void BindGrid()
        {
            try
            {
                DataSet ds = cls.ViewBlogTopic();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
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
                string str = ex.Message;
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "EditRow")
                {
                    binddata(e.CommandArgument.ToString());
                }
                else if (e.CommandName == "DeleteRow")
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
                obj.id = id;
                obj.uid = Convert.ToInt32(uid);
                cls.deleteBlogTopic(obj);
                CommonFunction.MessageBox(this, "S", "Record deleted successfully!!");
                BindGrid();
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }
        protected void binddata(string id)
        {
            obj.id = Convert.ToInt32(id);
            DataSet ds = cls.SelectBlogTopicByID(obj);
            if (ds.Tables[0].Rows.Count > 0)
            {
                hdnId.Value = ds.Tables[0].Rows[0]["id"].ToString();
                txtTopic.Text = ds.Tables[0].Rows[0]["Topic"].ToString();
                btnSubmit.Text = "Update";
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (btnSubmit.Text != "Update")
            {
                obj.btopic = txtTopic.Text.Trim();
                obj.uid = Convert.ToInt32(uid);
                cls.insertBlogTopic(obj);
                BindGrid();
                CommonFunction.MessageBox(this, "S", "Record saved successfully!!");                
                cmf.ClearAllControls(Page);
            }
            else
            {
                obj.id = Convert.ToInt32(hdnId.Value);
                obj.btopic = txtTopic.Text.Trim();
                obj.uid = Convert.ToInt32(uid);               
                cls.updateBlogTopicData(obj);
                BindGrid();
                CommonFunction.MessageBox(this, "S", "Record Updated successfully!!");               
                cmf.ClearAllControls(Page);
            }
        }
    }
}