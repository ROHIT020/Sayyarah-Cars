using COMMON;
using DAL;
using System;
using System.Data;
using ENTITY;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SayyarahCars.Admin
{
    public partial class Ledger_Head : System.Web.UI.Page
    {
        CommonFunction cmf = new CommonFunction();
        clsAdmin clsAdmin = new clsAdmin();
        DataSet ds = new DataSet();
        LedgerHead ledgerHead = new LedgerHead();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetAllGroupName();
                GetAllLedgerHead();
            }
        }

        public void GetAllLedgerHead()
        {
            int Id = 0;
            try
            {
                ds = clsAdmin.GetAllLedgerHead(Id, ddlGroupNameS.SelectedValue, txtLedgerHeadNameS.Text.Trim(), txtShortCodeS.Text.Trim());
                if (ds != null)
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

        public void GetAllGroupName()
        {
            int Id = 0;
            try
            {
                ds = clsAdmin.GetAllGroup(Id);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlGroupName.DataSource = ds;
                    ddlGroupName.DataTextField = "GroupName";
                    ddlGroupName.DataValueField = "Id";
                    ddlGroupName.DataBind();
                    ddlGroupName.Items.Insert(0, new ListItem("Select Group Name", "0"));
                }

                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlGroupNameS.DataSource = ds;
                    ddlGroupNameS.DataTextField = "GroupName";
                    ddlGroupNameS.DataValueField = "Id";
                    ddlGroupNameS.DataBind();
                    ddlGroupNameS.Items.Insert(0, new ListItem("Select Group Name", "0"));
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
                    ledgerHead.GroupName = ddlGroupName.SelectedValue;
                    ledgerHead.LedgerHeadName = txtLedgerHeadName.Text.Trim();
                    ledgerHead.Shortcode = txtShortCode.Text.Trim();
                    int temp = clsAdmin.addLedgerHead(ledgerHead, Session["AID"].ToString());
                    if (temp != 0)
                    {
                        CommonFunction.MessageBox(this, "S", "Record saved successfully!!");
                        cmf.ClearAllControls(Page);
                        GetAllLedgerHead();
                    }
                }
                else
                {
                    ledgerHead.Id = Convert.ToInt32(hdnledgerheadId.Value);
                    ledgerHead.GroupName = ddlGroupName.SelectedValue;
                    ledgerHead.LedgerHeadName = txtLedgerHeadName.Text.Trim();
                    ledgerHead.Shortcode = txtShortCode.Text.Trim();
                    int temp = clsAdmin.updateLedgerHead(ledgerHead, Session["AID"].ToString());
                    if (temp != 0)
                    {
                        CommonFunction.MessageBox(this, "S", "Record updated successfully!!", "Ledger-Head.aspx");
                        cmf.ClearAllControls(Page);
                        GetAllLedgerHead();
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
            if (e.CommandName == "EditRow")
            {
                string Id = e.CommandArgument.ToString();
                ds = clsAdmin.GetAllLedgerHead(Convert.ToInt32(Id), ddlGroupNameS.SelectedValue, txtLedgerHeadNameS.Text.Trim(), txtShortCodeS.Text.Trim());
                if (ds != null)
                {
                    hdnledgerheadId.Value = ds.Tables[0].Rows[0]["Id"].ToString();
                    ddlGroupName.SelectedValue = ds.Tables[0].Rows[0]["LedgerGroupId"].ToString();
                    txtLedgerHeadName.Text = ds.Tables[0].Rows[0]["LedgerHeadName"].ToString();
                    txtShortCode.Text = ds.Tables[0].Rows[0]["ShortCode"].ToString();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowModal", "setTimeout(function () { $('#add_region').modal('show'); }, 200);", true);
                    btnSubmit.Text = "Update";
                }
            }
            else if (e.CommandName == "DeleteRow")
            {
                string Id = e.CommandArgument.ToString();
                int temp = clsAdmin.DeleteLedgherHead(Id, Session["AID"].ToString());
                if (temp != 0)
                {
                    CommonFunction.MessageBox(this, "S", "Record deleted successfully!!", "Ledger-Head.aspx");
                    GetAllLedgerHead();
                }
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GetAllLedgerHead();
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            GetAllLedgerHead();
        }

        protected void ddlGroupNameS_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetAllLedgerHead();
        }
    }
}