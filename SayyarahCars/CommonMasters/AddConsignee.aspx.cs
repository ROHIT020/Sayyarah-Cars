using COMMON;
using DAL;
using ENTITY;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace SayyarahCars.CommonMasters
{
    public partial class AddConsignee : System.Web.UI.Page
    {
        public CommonFunction cmf = new CommonFunction();
        clsMasters cls = new clsMasters();
        entConsignee obj = new entConsignee();
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
                    BindClient();
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
        protected void BindClient()
        {
            DataSet ds = cls.ClientBind();
            cmf.BindDropDownList(ddlClient, ds, "ClientName", "id");
            ListItem li = new ListItem("--Select Client Name--", "0");
            ddlClient.Items.Insert(0, li);
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (btnSubmit.Text != "Update")
            {
                obj.ClientId = Convert.ToInt32(ddlClient.SelectedValue);
                obj.CFS = txtcfs.Text.Trim();
                obj.ConsigneeName = txtconsigneename.Text.Trim();
                obj.Email = txtEmail.Text.Trim();
                obj.Address = txtAddress.Text.Trim();
                obj.uid = Convert.ToInt32(uid);
                int result=cls.InsertConsignee(obj);
                if (result != 0)
                {
                    CommonFunction.MessageBox(this, "S", "Record Saved successfully!!", "close");
                    cmf.ClearAllControls(Page);
                }

            }
            else
            {
                obj.Id = Convert.ToInt32(cmf.Decrypt(Request.QueryString["id"].ToString()));
                obj.ClientId = Convert.ToInt32(ddlClient.SelectedValue);
                obj.CFS = txtcfs.Text.Trim();
                obj.ConsigneeName = txtconsigneename.Text.Trim();
                obj.Email = txtEmail.Text.Trim();
                obj.Address = txtAddress.Text.Trim();
                obj.uid = Convert.ToInt32(uid);
                int result = cls.updateConsignee(obj);
                if (result != 0)
                {
                    CommonFunction.MessageBox(this, "S", "Record updated successfully!!", "close");
                    cmf.ClearAllControls(Page);
                }
            }
        }

        protected void binddata()
        {
            obj.Id = Convert.ToInt32(cmf.Decrypt(Request.QueryString["id"].ToString()));
            DataSet ds = cls.SelectConsigneeById(obj);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlClient.SelectedValue = ds.Tables[0].Rows[0]["ClientId"].ToString();
                txtcfs.Text = ds.Tables[0].Rows[0]["CFS"].ToString();
                txtconsigneename.Text = ds.Tables[0].Rows[0]["ConsigneeName"].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                btnSubmit.Text = "Update";
            }
        }
    }
}