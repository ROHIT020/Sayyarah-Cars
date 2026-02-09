using COMMON;
using DAL;
using ENTITY;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace SayyarahCars.CommonMasters
{
    public partial class ManageMenu : System.Web.UI.Page
    {
        CommonFunction cmf = new CommonFunction();
        clsMasters cls = new clsMasters();
        entmanu obj = new entmanu();
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
                    bindmainmenu();
                    bindsearch();
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }
        protected void bindmainmenu()
        {
            obj.utype = ddlusertype.SelectedValue;
            obj.PID = 0;
            DataSet ds = cls.bindMenu(obj);
            cmf.BindDropDownList(ddlpid, ds, "MenuTitle", "ID");
            ListItem li = new ListItem("Select Menu", "0");
            ddlpid.Items.Insert(0, li);
        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnsubmit.Text != "Update")
                {
                    obj.utype = ddlusertype.SelectedValue;
                    obj.MenuTitle = txtmenutitle.Text.Trim();
                    obj.MenuURL = txturl.Text.Trim();
                    obj.PID = Convert.ToInt32(ddlpid.SelectedValue);
                    obj.uid = uid;
                    cls.InsertMenu(obj);
                }
                else
                {
                    obj.utype = ddlusertype.SelectedValue;
                    obj.ID = Convert.ToInt32(cmf.Decrypt(hdnid.Value));
                    obj.MenuTitle = txtmenutitle.Text.Trim();
                    obj.MenuURL = txturl.Text.Trim();
                    obj.PID = Convert.ToInt32(ddlpid.SelectedValue);
                    obj.uid = uid;
                    cls.updateMenu(obj);
                }
                btnsubmit.Text = "Submit";
                txtmenutitle.Text = "";
                txturl.Text = "";
                if (ddlpid.SelectedValue == "0")
                {
                    bindmainmenu();
                    bindsearch();
                    CommonFunction.MessageBox(this, "S", "Record saved successfully and updated to Parent Dropdown List!!");
                }
                else
                {
                    bindsearch();
                    CommonFunction.MessageBox(this, "S", "Record saved successfully!!");
                }


            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }
        public void bindsearch()
        {
            try
            {
                obj.utype = ddlusertype.SelectedValue;
                obj.PID = Convert.ToInt32(ddlpid.SelectedValue); 
                DataSet ds = cls.bindMenu(obj);
                ViewState["DataTable"] = ds.Tables[0];
                GridView1.DataSource = ds;
                GridView1.DataBind();
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
            bindsearch();
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "EditRow")
                {

                    int id = Convert.ToInt32(e.CommandArgument);
                    obj.ID = id;
                    DataSet ds = cls.SelectMenuByID(obj);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        hdnid.Value = cmf.Encrypt(ds.Tables[0].Rows[0]["id"].ToString());
                        txtmenutitle.Text = ds.Tables[0].Rows[0]["MenuTitle"].ToString();
                        txturl.Text = ds.Tables[0].Rows[0]["MenuURL"].ToString();
                        if (ds.Tables[0].Rows[0]["pid"].ToString() == "0")
                        {
                            ddltype.SelectedValue = "1";
                            divPid.Visible = false;
                            lbltitle.Text = "Menu Title";
                            lblurl.Text = "Menu URL";
                        }
                        else
                        {
                            ddltype.SelectedValue = "2";
                            lbltitle.Text = "Sub-Menu Title";
                            lblurl.Text = "Sub-Menu URL";
                            divPid.Visible = true;
                        }
                        ddlpid.SelectedValue = ds.Tables[0].Rows[0]["PID"].ToString();
                        ddlusertype.SelectedValue = ds.Tables[0].Rows[0]["utype"].ToString();
                        btnsubmit.Text = "Update";
                    }
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
                obj.ID = id;
                obj.uid = uid;
                cls.DeleteMenu(obj);
                bindsearch();
                CommonFunction.MessageBox(this, "S", "Record deleted successfully!!");
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void ddlpages_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindsearch();
        }

        protected void ddlpid_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindsearch();

        }

        protected void ddlusertype_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindmainmenu();
            bindsearch();
        }
        protected void ddltype_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindmainmenu();
            ddlpid.SelectedValue = "0";
            if (ddltype.SelectedValue == "1")
            {
                divPid.Visible = false;
                lbltitle.Text = "Menu Title";
                lblurl.Text = "Menu URL";
                
            }
            else
            {
                lbltitle.Text = "Sub-Menu Title";
                lblurl.Text = "Sub-Menu URL";
                divPid.Visible = true;
            }
            bindsearch();
        }
    }
}