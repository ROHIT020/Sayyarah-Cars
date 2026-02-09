using COMMON;
using DAL;
using DAL.Reports;
using ENTITY;
using System;
using System.Data;
using System.Web.UI;

namespace SayyarahCars.Admin
{
    public partial class Fuzokuhin : System.Web.UI.Page
    {
        clsAdmin clsAdmin = new clsAdmin();
        clsOtherReport clsOtherReport = new clsOtherReport();
        CommonFunction cmf = new CommonFunction();
        DataSet ds = new DataSet();
        FuzokuhinModel fuzokuhinModel = new FuzokuhinModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetAllFuzuhokin();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnSubmit.Text != "Update")
                {
                    fuzokuhinModel.FuzokuhinName = txtFuzokuhinName.Text.Trim();
                    fuzokuhinModel.Price = txtPrice.Text.Trim();
                    fuzokuhinModel.ActiveDeActive = RadioAD.SelectedValue;

                    int temp = clsAdmin.addFuzokuhin(fuzokuhinModel, Session["AID"].ToString());
                    if (temp == 1)
                    {
                        CommonFunction.MessageBox(this, "S", "Record saved successfully!!");
                        GetAllFuzuhokin();
                        cmf.ClearAllControls(Page);
                    }
                }
                else
                {
                    fuzokuhinModel.Id = Convert.ToInt32(hdnFuzokuhinId.Value);
                    fuzokuhinModel.FuzokuhinName = txtFuzokuhinName.Text.Trim();
                    fuzokuhinModel.Price = txtPrice.Text.Trim();
                    fuzokuhinModel.ActiveDeActive = RadioAD.SelectedValue;

                    int temp = clsAdmin.updateFuzokuhinById(fuzokuhinModel, Session["AID"].ToString());
                    if (temp == 1)
                    {
                        CommonFunction.MessageBox(this, "S", "Record saved successfully!!");
                        GetAllFuzuhokin();
                    }
                }
            }
            catch (Exception ex)
            {
                CommonFunction.DisplayAlert(this, ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        public void GetAllFuzuhokin()
        {
            int Id = 0;
            try
            {
                ds = clsOtherReport.GetAllFuzokuhin(Id);
                if (ds != null || ds.Tables.Count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                CommonFunction.DisplayAlert(this, ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void GridView1_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditRow")
            {
                string Id = e.CommandArgument.ToString();
                ds = clsOtherReport.GetAllFuzokuhin(Convert.ToInt32(Id));
                if (ds != null || ds.Tables[0].Rows.Count > 0)
                {
                    hdnFuzokuhinId.Value = ds.Tables[0].Rows[0]["Id"].ToString();
                    txtFuzokuhinName.Text = ds.Tables[0].Rows[0]["FuzokuhinName"].ToString();
                    txtPrice.Text = ds.Tables[0].Rows[0]["Price"].ToString();
                    string Active = ds.Tables[0].Rows[0]["Status"].ToString();
                    if (Active == "Active")
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
                int temp = clsAdmin.deleteFuzokuhin(Id, Session["AID"].ToString());
                if (temp == 1)
                {
                    CommonFunction.MessageBox(this, "S", "Record deleted successfully!!");
                    GetAllFuzuhokin();
                }
            }
        }
    }
}