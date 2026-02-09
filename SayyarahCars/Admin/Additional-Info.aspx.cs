using COMMON;
using DAL;
using ENTITY;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SayyarahCars.Admin
{
    public partial class Additional_Info : System.Web.UI.Page
    {
        clsAdmin clsAdmin = new clsAdmin();
        DataSet ds = new DataSet();
        CommonFunction cmf = new CommonFunction();
        Additionalinfo additionalinfo = new Additionalinfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                getAllCategory();
                getAllAdditionInfo();
            }
        }

        public void getAllCategory()
        {
            try
            {
                ds = clsAdmin.getAllcategory();
                if (ds.Tables["Table"].Rows.Count > 0)
                {
                    ddlCategoryName.Items.Clear();
                    ddlCategoryName.DataSource = ds.Tables["Table"];
                    ddlCategoryName.DataTextField = "CategoryName";
                    ddlCategoryName.DataValueField = "Id";
                    ddlCategoryName.DataBind();
                    ddlCategoryName.Items.Insert(0, new ListItem("Select category Name", "0"));
                }
                if (ds.Tables["Table"].Rows.Count > 0)
                {
                    ddlCategoryName1.Items.Clear();
                    ddlCategoryName1.DataSource = ds.Tables["Table"];
                    ddlCategoryName1.DataTextField = "CategoryName";
                    ddlCategoryName1.DataValueField = "Id";
                    ddlCategoryName1.DataBind();
                    ddlCategoryName1.Items.Insert(0, new ListItem("Select category Name", "0"));
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
                    additionalinfo.CategoryId = ddlCategoryName.SelectedValue;
                    additionalinfo.AdditinalInfoName = txtAdditinalInfo.Text.Trim();
                    additionalinfo.InfoType = ddlInfoType.SelectedValue;
                    additionalinfo.Status = RadioAD.SelectedValue;
                    int temp = clsAdmin.addAdditionalInfo(additionalinfo, Session["AID"].ToString());
                    if (temp != 0)
                    {
                        CommonFunction.MessageBox(this, "S", "Record saved successfully!!");
                        getAllAdditionInfo();
                        cmf.ClearAllControls(Page);
                    }
                    else
                    {
                        CommonFunction.MessageBox(this, "E", "Record not saved successfully!!");
                    }
                }
                else
                {
                    additionalinfo.Id = Convert.ToInt32(hdnAdditionalInfo.Value);
                    additionalinfo.CategoryId = ddlCategoryName.SelectedValue;
                    additionalinfo.AdditinalInfoName = txtAdditinalInfo.Text.Trim();
                    additionalinfo.InfoType = ddlInfoType.SelectedValue;
                    additionalinfo.Status = RadioAD.SelectedValue;

                    int temp = clsAdmin.updateAdditionalInfo(additionalinfo, Session["AID"].ToString());

                    if (temp != 0)
                    {
                        CommonFunction.MessageBox(this, "S", "Record updated successfully!!");
                        getAllAdditionInfo();
                        cmf.ClearAllControls(Page);
                    }
                }

            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        public void getAllAdditionInfo()
        {
            try
            {
                int Id = 0;
                ds = clsAdmin.getAllAdditionInfo(Id,ddlCategoryName1.SelectedValue, ddlInfoType1.SelectedValue);
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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "EditRow")
                {
                    string Id = e.CommandArgument.ToString();
                    DataSet ds = clsAdmin.getAllAdditionInfoById(Convert.ToInt32(Id));
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        hdnAdditionalInfo.Value = ds.Tables[0].Rows[0]["Id"].ToString();
                        ddlCategoryName.SelectedValue = ds.Tables[0].Rows[0]["CategoryId"].ToString();
                        txtAdditinalInfo.Text = ds.Tables[0].Rows[0]["AdditinalInfoName"].ToString();
                        ddlInfoType.SelectedValue = ds.Tables[0].Rows[0]["InfoTypeId"].ToString();
                        string status = ds.Tables[0].Rows[0]["Status"].ToString();
                        if (status == "Active")
                        {
                            RadioAD.SelectedValue = "1";
                        }
                        else
                        {
                            RadioAD.SelectedValue = "0";
                        }
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowModal", "setTimeout(function () { $('#add_region').modal('show'); }, 200);", true);
                        btnSubmit.Text = "Update";
                    }
                }
                else
                {
                    string Id = e.CommandArgument.ToString();
                    int temp = clsAdmin.deleteAdditionalById(Id, Session["AID"].ToString());
                    if (temp != 0)
                    {
                        CommonFunction.MessageBox(this, "S", "Record deleted successfully!!");
                        getAllAdditionInfo();
                    }
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            getAllAdditionInfo();
        }
    }
}