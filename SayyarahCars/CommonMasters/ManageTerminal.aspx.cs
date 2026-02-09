using COMMON;
using DAL;
using ENTITY;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace SayyarahCars.CommonMasters
{
    public partial class ManageTerminal : System.Web.UI.Page
    {
        public CommonFunction cmf = new CommonFunction();
        clsMasters cls = new clsMasters();
        entTerminal obj = new entTerminal();
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
                    BindPort();
                    BindGrid();
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }
        protected void BindPort()
        {
            clsUseMasters um = new clsUseMasters();
            DataSet ds = um.PortBind();
            cmf.BindDropDownList(ddlPort, ds, "PortName", "ID");
            ListItem li = new ListItem("--Select--", "0");
            ddlPort.Items.Insert(0, li);
        }
        private void BindGrid()
        {
            try
            {
                int clientId = Convert.ToInt32(ddlPort.SelectedValue);
                DataSet ds = cls.SelectTerminalPortById(clientId);
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
                throw ex;
            }
        }
        protected void btnreload_Click(object sender, EventArgs e)
        {
            BindGrid();
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
                cls.DeleteTerminal(obj);
                CommonFunction.MessageBox(this, "S", "Record deleted successfully!!");
                BindGrid();
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                int clientId = Convert.ToInt32(ddlPort.SelectedValue);
                DataSet ds = cls.SelectTerminalPortById(clientId);
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
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void ddlpages_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGrid();
        }
    }
}