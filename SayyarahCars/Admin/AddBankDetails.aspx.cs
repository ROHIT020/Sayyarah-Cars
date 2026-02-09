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
    public partial class AddBankDetails : System.Web.UI.Page
    {
        clsAdmin clsAdmin = new clsAdmin();
        CommonFunction cmf = new CommonFunction();
        DataSet ds = new DataSet();
        Addbankdetails addbankdetails = new Addbankdetails();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetCompanyName();
                getAllBankDetailsData();
            }
        }

        public void GetCompanyName()
        {
            try
            {
                ds = clsAdmin.GetAllCompany();
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlCompany.DataSource = ds.Tables["Table"];
                        ddlCompany.DataTextField = "CompanyName";
                        ddlCompany.DataValueField = "id";
                        ddlCompany.DataBind();
                        ddlCompany.Items.Insert(0, new ListItem("Select Company Name", "0"));
                    }
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
                    addbankdetails.CompanyName = ddlCompany.SelectedValue;
                    addbankdetails.BankName = txtBankName.Text.Trim();
                    addbankdetails.BranchName = txtBranchName.Text.Trim();
                    addbankdetails.AccountName = txtAccountName.Text.Trim();
                    addbankdetails.SwiftName = txtSwiftName.Text.Trim();
                    addbankdetails.AccountNo = txtAccountNo.Text.Trim();
                    addbankdetails.Address = txtAddress.Text.Trim();
                    int temp = clsAdmin.addBankDetails(addbankdetails, Session["AID"].ToString());

                    if (temp != 0)
                    {
                        CommonFunction.MessageBox(this, "S", "Record saved successfully!!");
                        cmf.ClearAllControls(Page);
                        getAllBankDetailsData();
                    }
                    else
                    {
                        CommonFunction.MessageBox(this, "E", "Record not saved successfully!!");
                    }
                }
                else
                {
                    addbankdetails.Id = Convert.ToInt32(hdnBankDetailId.Value);
                    addbankdetails.CompanyName = ddlCompany.SelectedValue;
                    addbankdetails.BankName = txtBankName.Text.Trim();
                    addbankdetails.BranchName = txtBranchName.Text.Trim();
                    addbankdetails.AccountName = txtAccountName.Text.Trim();
                    addbankdetails.SwiftName = txtSwiftName.Text.Trim();
                    addbankdetails.AccountNo = txtAccountNo.Text.Trim();
                    addbankdetails.Address = txtAddress.Text.Trim();
                    int temp = clsAdmin.updateBankDetailsById(addbankdetails, Session["AID"].ToString());
                    if (temp != 0)
                    {
                        CommonFunction.MessageBox(this, "S", "Record updated successfully!!");
                        cmf.ClearAllControls(Page);
                        getAllBankDetailsData();
                        btnSubmit.Text = "Save changes";
                    }
                    else
                    {
                        CommonFunction.MessageBox(this, "E", "Record not updated successfully!!");
                    }
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        public void getAllBankDetailsData()
        {
            try
            {
                ds = clsAdmin.getAllBankDetails();
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

                    ds = clsAdmin.getAllBankDetailsById(Id);

                    hdnBankDetailId.Value = ds.Tables[0].Rows[0]["Id"].ToString();
                    ddlCompany.SelectedValue = ds.Tables[0].Rows[0]["CompanyId"].ToString();
                    txtBankName.Text = ds.Tables[0].Rows[0]["BankName"].ToString();
                    txtBranchName.Text = ds.Tables[0].Rows[0]["BranchName"].ToString();
                    txtAccountName.Text = ds.Tables[0].Rows[0]["AccountName"].ToString();
                    txtSwiftName.Text = ds.Tables[0].Rows[0]["SwiftName"].ToString();
                    txtAccountNo.Text = ds.Tables[0].Rows[0]["AccountNo"].ToString();
                    txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowModal", "setTimeout(function () { $('#add_region').modal('show'); }, 200);", true);
                    btnSubmit.Text = "Update";
                }
                else
                {
                    string Id = e.CommandArgument.ToString();
                    string UID = Session["AID"].ToString();

                    int temp = clsAdmin.deleteBankDetails(Id, UID);

                    if (temp != 0)
                    {
                        CommonFunction.MessageBox(this, "S", "Record deleted successfully!!");
                        getAllBankDetailsData();
                    }
                    else
                    {
                        CommonFunction.MessageBox(this, "E", "Record not deleted successfully!!");
                    }
                }
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
            getAllBankDetailsData();
        }
    }
}