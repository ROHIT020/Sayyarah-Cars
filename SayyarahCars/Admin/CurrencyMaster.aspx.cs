using COMMON;
using DAL;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SayyarahCars.Admin
{
    public partial class CurrencyMaster : System.Web.UI.Page
    {
        clsAdmin clsAdmin = new clsAdmin();
        CommonFunction cmf = new CommonFunction();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
                if (!Page.IsPostBack)
                {
                    bindCurrenctMasterData();
                }
            }
        
        public void bindCurrenctMasterData()
        {
            try
            {
                ds = clsAdmin.getCurrencyMasterData();
                if (ds.Tables[0].Rows != null)
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
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (GridViewRow row in GridView1.Rows)
                {
                    CheckBox checkBox = row.FindControl("Chkbox") as CheckBox;
                    if (checkBox.Checked)
                    {
                        Label lblid = row.FindControl("lblid") as Label;
                        TextBox txtRate = row.FindControl("txtRate") as TextBox;
                        
                        int temp = clsAdmin.updateCurrenctMaster(lblid.Text, txtRate.Text.Trim(), Session["AID"].ToString());
                        if (temp != 0)
                        {
                            CommonFunction.MessageBox(this, "S", "Record updated successfully!!", "CurrencyMaster.aspx");
                            bindCurrenctMasterData();
                        }
                    }
                }
                CommonFunction.MessageBox(this, "E", "Please select at least one checkbox.");
            }
            catch (Exception ex)
            {
                CommonFunction.DisplayAlert(this, ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteRow")
            {
                string Id = e.CommandArgument.ToString();

                int temp = clsAdmin.deleteCurrencymaster(Convert.ToInt32(Id), Session["AID"].ToString());

                if (temp != 0)
                {
                    CommonFunction.MessageBox(this, "S", "Record deleted successfully!!", "CurrencyMaster.aspx");
                    bindCurrenctMasterData();
                }
                else 
                {
                    CommonFunction.MessageBox(this, "E", "Record not deleted successfully!!");
                }
            }
        }
    }
}