using COMMON;
using DAL;
using ENTITY;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SayyarahCars.CommonMasters
{
    public partial class AssignMenu : System.Web.UI.Page
    {
        CommonFunction cmf = new CommonFunction();
        clsMasters cls = new clsMasters();
        entmanu obj = new entmanu();
        public string uid = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AID"] != null)
            {
                uid = Session["AID"].ToString();
            }
            if (!Page.IsPostBack)
            {
                binduser();
            }
            addchk();
        }

        protected void binduser()
        {
            DataSet ds = cls.ListAdminLoginDetails();
            cmf.BindDropDownList(ddluser, ds, "FullName", "id");
            ListItem li = new ListItem("Select User", "0");
            ddluser.Items.Insert(0, li);
            if (Request.QueryString["uid"] != null)
            {
                ddluser.SelectedValue = cmf.Decrypt(Request.QueryString["uid"].ToString());
                clearchk();
                selectchk();
                divuser.Visible = false;
            }
        }
        protected void addchk()
        {
            pnlcustomControl.Controls.Add(new LiteralControl("<table class='tbllist'>"));
            obj.utype = "1";
            obj.PID = 0;
            DataSet ds = cls.bindMenu(obj);
            if (ds.Tables[0].Rows.Count > 0)
            {
                int j = 0;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    CheckBox Chkbox = new CheckBox();
                    Chkbox.ID = "ctl" + ds.Tables[0].Rows[i]["id"].ToString();
                    Chkbox.Text = "<b>" + ds.Tables[0].Rows[i]["MenuTitle"].ToString() + "</b>(" + ds.Tables[0].Rows[i]["MenuURL"].ToString() + ")";
                    if (j == 0)
                    {
                        pnlcustomControl.Controls.Add(new LiteralControl("<tr valign='top'>"));
                    }
                    pnlcustomControl.Controls.Add(new LiteralControl("<td>"));
                    pnlcustomControl.Controls.Add(Chkbox);
                    addsubchk(Convert.ToInt32(ds.Tables[0].Rows[i]["id"].ToString()));
                    pnlcustomControl.Controls.Add(new LiteralControl("</td>"));
                    j++;
                    if (j == 2)
                    {
                        pnlcustomControl.Controls.Add(new LiteralControl("</tr>"));
                        j = 0;
                    }
                }
                if (j > 0 && j < 2)
                {
                    pnlcustomControl.Controls.Add(new LiteralControl("</tr>"));
                }
            }

            pnlcustomControl.Controls.Add(new LiteralControl("</table>"));
        }
        protected void addsubchk(int id)
        {
            obj.utype = "1";
            obj.PID = id;
            DataSet ds = cls.bindMenu(obj);
            string val2 = string.Empty;
            if (ds.Tables[0].Rows.Count > 0)
            {
                pnlcustomControl.Controls.Add(new LiteralControl("<br/><table class='tbllist'>"));
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    CheckBox Chkbox = new CheckBox();
                    Chkbox.ID = "ctl" + ds.Tables[0].Rows[i]["id"].ToString();
                    Chkbox.Text = ds.Tables[0].Rows[i]["MenuTitle"].ToString() + "(" + ds.Tables[0].Rows[i]["MenuURL"].ToString() + ")";
                    pnlcustomControl.Controls.Add(new LiteralControl("<tr><td>&nbsp;&nbsp;&nbsp;&nbsp;"));
                    pnlcustomControl.Controls.Add(Chkbox);
                    if (val2 != string.Empty)
                    {
                        val2 += "|" + Chkbox.ClientID;
                    }
                    else
                    {
                        val2 += Chkbox.ClientID;
                    }
                    addssubchk(Convert.ToInt32(ds.Tables[0].Rows[i]["id"].ToString()));
                    pnlcustomControl.Controls.Add(new LiteralControl("</td></tr>"));
                }

                pnlcustomControl.Controls.Add(new LiteralControl("</table>"));

                CheckBox Chkbox1 = (CheckBox)pnlcustomControl.FindControl("ctl" + id);
                if (Chkbox1 != null)
                    Chkbox1.Attributes.Add("onclick", "checkchk(this,'" + val2 + "')");
            }
        }
        protected void addssubchk(int id)
        {
            obj.utype = "1";
            obj.PID = id;
            DataSet ds = cls.bindMenu(obj);
            string val2 = string.Empty;
            if (ds.Tables[0].Rows.Count > 0)
            {
                pnlcustomControl.Controls.Add(new LiteralControl("<br/><table class='tbllist' width='100%'>"));

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    CheckBox Chkbox = new CheckBox();

                    Chkbox.ID = "ctl" + ds.Tables[0].Rows[i]["id"].ToString();
                    Chkbox.Text = ds.Tables[0].Rows[i]["MenuTitle"].ToString() + "(" + ds.Tables[0].Rows[i]["MenuURL"].ToString() + ")";

                    pnlcustomControl.Controls.Add(new LiteralControl("<tr><td>&nbsp;&nbsp;&nbsp;&nbsp;"));
                    pnlcustomControl.Controls.Add(Chkbox);
                    if (val2 != string.Empty)
                    {
                        val2 += "|" + Chkbox.ClientID;
                    }
                    else
                    {
                        val2 += Chkbox.ClientID;
                    }
                    // addssubchk(Convert.ToInt32(ds.Tables[0].Rows[i]["id"].ToString()));
                    pnlcustomControl.Controls.Add(new LiteralControl("</td></tr>"));
                }

                pnlcustomControl.Controls.Add(new LiteralControl("</table>"));

                CheckBox Chkbox1 = (CheckBox)pnlcustomControl.FindControl("ctl" + id);
                if (Chkbox1 != null)
                    Chkbox1.Attributes.Add("onclick", "checkchk(this,'" + val2 + "')");


            }

        }
        protected void changeddl(object sender, EventArgs e)
        {
            clearchk();
            selectchk();
        }

        protected void selectchk()
        {
            DataSet ds = cls.getAssignedMenuByUID(ddluser.SelectedValue);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                CheckBox chk1 = (CheckBox)pnlcustomControl.FindControl("ctl" + ds.Tables[0].Rows[i]["sID"].ToString());
                if (chk1 != null)
                {
                    chk1.Checked = true;
                }
            }
        }

        protected void clearchk()
        {
            obj.ID = 0;
            DataSet ds = cls.SelectMenuByID(obj);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                CheckBox chk1 = (CheckBox)pnlcustomControl.FindControl("ctl" + ds.Tables[0].Rows[i]["id"].ToString());
                if (chk1 != null)
                {
                    chk1.Checked = false;
                }
            }
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            obj.ID = 0;
            DataSet ds = cls.SelectMenuByID(obj);
            string mids = "";
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                CheckBox chk1 = (CheckBox)pnlcustomControl.FindControl("ctl" + ds.Tables[0].Rows[i]["id"].ToString());
                if (chk1 != null)
                {
                    if (chk1.Checked)
                    {
                        if (mids != string.Empty)
                        {
                            mids += "," + ds.Tables[0].Rows[i]["id"].ToString();
                        }
                        else
                        {
                            mids += ds.Tables[0].Rows[i]["id"].ToString();
                        }
                    }
                }
            }
            obj.uid = ddluser.SelectedValue;
            obj.MenuURL = mids;
            obj.ID = Convert.ToInt32(uid);
            cls.AssignMenu(obj);
            CommonFunction.MessageBox(this, "S", "Selected Menus successfully assigned to the " + ddluser.SelectedItem.Text + " .");
        }
    }
}