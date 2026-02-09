using COMMON;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SayyarahCars.Admin
{
    public partial class AddCurrency : System.Web.UI.Page
    {
        clsAdmin clsAdmin = new clsAdmin();
        CommonFunction cmf = new CommonFunction();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["AID"] != null)
            {
                if (!Page.IsPostBack)
                {
                    GetCurrencyType();
                }
            }
            else
            {
                Response.Redirect("~/Index.aspx", false);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                int temp = clsAdmin.addCurrencyType(ddlCurrencyType.SelectedValue,ddlsymbol.SelectedValue,txtRate.Text.Trim(),Session["AID"].ToString());
                if (temp != 0)
                {
                    CommonFunction.MessageBox(this, "S", "Record saved successfully!!");
                    cmf.ClearAllControls(Page);
                }
                //int temp = clsAdmin.addCurrency(txtCurrencyType.Text.Trim(), txtSymbol.Text.Trim(), txtRate.Text.Trim(), Session["AID"].ToString());
                //if (temp != 0)
                //{
                //    CommonFunction.MessageBox(this, "S", "Record saved successfully!!");
                //    cmf.ClearAllControls(Page);
                //}
                else
                {
                    CommonFunction.MessageBox(this, "E", "Record not saved successfully!!");
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        public void GetCurrencyType()
        {
            try
            {
                ds = clsAdmin.getAllCurrencyType();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlCurrencyType.Items.Clear();
                    ddlCurrencyType.DataSource = ds.Tables["Table"];
                    ddlCurrencyType.DataTextField = "Ctype";
                    ddlCurrencyType.DataValueField = "Id";
                    ddlCurrencyType.DataBind();
                    ddlCurrencyType.Items.Insert(0, new ListItem("Select currency type", "0"));

                    //Bind Symbol dropdown
                    ddlsymbol.Items.Clear();
                    ddlsymbol.DataSource = ds.Tables["Table"];
                    ddlsymbol.DataTextField = "Symbol";
                    ddlsymbol.DataValueField = "Id";
                    ddlsymbol.DataBind();
                    ddlsymbol.Items.Insert(0, new ListItem("Select symbol type", "0"));
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