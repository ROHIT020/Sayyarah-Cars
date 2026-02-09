using COMMON;
using DAL;
using ENTITY;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace SayyarahCars.CommonMasters
{
    public partial class AddTransport : System.Web.UI.Page
    {
        public CommonFunction cmf = new CommonFunction();
        clsMasters cls = new clsMasters();
        entTransport obj = new entTransport();
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
                    BindCountry();
                    if (Request.QueryString["id"] != null)
                    {
                        binddata();
                    }
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void BindCountry()
        {
            DataSet ds = cls.CountryBind();
            cmf.BindDropDownList(ddlCountry, ds, "CountryName", "Id");
            ListItem li = new ListItem("--Select Country--", "0");
            ddlCountry.Items.Insert(0, li);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnSubmit.Text != "Update")
                {
                    obj.CountryId = Convert.ToInt32(ddlCountry.SelectedValue);
                    obj.TransportName = txtTransportName.Text.Trim();
                    obj.Address = txtAddress.Text.Trim();
                    obj.Email = txtEmail.Text.Trim();
                    obj.FaxNumber = txtFaxNo.Text.Trim();
                    obj.uid = Convert.ToInt32(uid);
                    if (rdoactive.Checked)
                    {
                        obj.Archive = true;
                    }
                    else
                    {
                        obj.Archive = false;
                    }
                    cls.InsertTransport(obj);
                    CommonFunction.MessageBox(this, "S", "Record saved successfully!!", "close");
                    cmf.ClearAllControls(Page);
                }
                else
                {
                    obj.Id = Convert.ToInt32(cmf.Decrypt(Request.QueryString["id"].ToString()));
                    obj.CountryId = Convert.ToInt32(ddlCountry.SelectedValue);
                    obj.TransportName = txtTransportName.Text.Trim();
                    obj.Address = txtAddress.Text.Trim();
                    obj.Email = txtEmail.Text.Trim();
                    obj.FaxNumber = txtFaxNo.Text.Trim();
                    obj.uid = Convert.ToInt32(uid);
                    if (rdoactive.Checked)
                    {
                        obj.Archive = false;
                    }
                    else
                    {
                        obj.Archive = true;
                    }
                    cls.updateTransport(obj);
                    CommonFunction.MessageBox(this, "S", "Record updated successfully!!","close");
                    cmf.ClearAllControls(Page);
                }
            

            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void binddata()
        {
            obj.Id = Convert.ToInt32(cmf.Decrypt(Request.QueryString["id"].ToString()));
            DataSet ds = cls.SelectTransportById(obj);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlCountry.SelectedValue = ds.Tables[0].Rows[0]["CountryId"].ToString();
                txtTransportName.Text = ds.Tables[0].Rows[0]["TransportName"].ToString();
                txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                txtFaxNo.Text = ds.Tables[0].Rows[0]["FaxNumber"].ToString();
                string status = ds.Tables[0].Rows[0]["Archive"].ToString();
                if (status == "True")
                {
                    rdoactive.Checked = false;
                    rdodeActive.Checked = true;
                }
                else
                {
                    rdoactive.Checked = true;
                    rdodeActive.Checked = false;
                }

                btnSubmit.Text = "Update";
            }
        }
    }
}