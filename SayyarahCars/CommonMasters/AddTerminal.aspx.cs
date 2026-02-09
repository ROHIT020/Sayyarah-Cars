using COMMON;
using DAL;
using ENTITY;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace SayyarahCars.CommonMasters
{
    public partial class AddTerminal : System.Web.UI.Page
    {
        public CommonFunction cmf = new CommonFunction();
        clsMasters cls = new clsMasters();
        entTerminal obj = new entTerminal();
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
                    BindPort();
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

        protected void BindPort()
        {
            clsUseMasters um = new clsUseMasters();
            DataSet ds = um.PortBind();
            cmf.BindDropDownList(ddlPort, ds, "PortName", "ID");
            ListItem li = new ListItem("--Select--", "0");
            ddlPort.Items.Insert(0, li);
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (btnSubmit.Text != "Update")
            {
                obj.PortId = Convert.ToInt32(ddlPort.SelectedValue);
                obj.Tcname = txttcname.Text.Trim();
                obj.Tname = txttname.Text.Trim();
                obj.Cperson = txtCperson.Text.Trim();
                obj.Email = txtEmail.Text.Trim();
                obj.ContactNo = txtContactNo.Text.Trim();
                obj.Price = Convert.ToDecimal(txtprice.Text.Trim());
                obj.Taddress = txttaddress.Text.Trim();
                obj.uid = Convert.ToInt32(uid);
                int result = cls.InsertTerminal(obj);
                if (result != 0)
                {
                    CommonFunction.MessageBox(this, "S", "Record saved successfully!!", "close");
                    cmf.ClearAllControls(Page);
                }
            }
            else
            {
                obj.Id = Convert.ToInt32(cmf.Decrypt(Request.QueryString["id"].ToString()));
                obj.PortId = Convert.ToInt32(ddlPort.SelectedValue);
                obj.Tcname = txttcname.Text.Trim();
                obj.Tname = txttname.Text.Trim();
                obj.Cperson = txtCperson.Text.Trim();
                obj.Email = txtEmail.Text.Trim();
                obj.ContactNo = txtContactNo.Text.Trim();
                obj.Price = Convert.ToDecimal(txtprice.Text.Trim());
                obj.Taddress = txttaddress.Text.Trim();
                obj.uid = Convert.ToInt32(uid);
                int result = cls.updateTerminal(obj);
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
            DataSet ds = cls.SelectTerminalById(obj);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlPort.SelectedValue = ds.Tables[0].Rows[0]["PortId"].ToString();
                txttcname.Text = ds.Tables[0].Rows[0]["Tcname"].ToString();
                txttname.Text = ds.Tables[0].Rows[0]["Tname"].ToString();
                txtCperson.Text = ds.Tables[0].Rows[0]["Cperson"].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0]["EmailID"].ToString();
                txtContactNo.Text = ds.Tables[0].Rows[0]["ContactNo"].ToString();
                txtprice.Text = ds.Tables[0].Rows[0]["Price"].ToString();
                txttaddress.Text = ds.Tables[0].Rows[0]["Taddress"].ToString();
                btnSubmit.Text = "Update";
            }
        }
    }
}