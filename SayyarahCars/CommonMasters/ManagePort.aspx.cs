using COMMON;
using DAL;
using ENTITY;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SayyarahCars.CommonMasters
{
    public partial class ManagePort : System.Web.UI.Page
    {
        clsUseMasters um = new clsUseMasters();
        clsMasters cls = new clsMasters();
        entPort portMaster = new entPort();
        CommonFunction cmf = new CommonFunction();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindCountry();
                binddata();
            }
        }

        public void BindCountry()
        {
            try
            {
                
                DataSet ds = new DataSet();
                ds = um.ListCountry();
                if (ds.Tables["Table"].Rows.Count > 0)
                {
                    ddlCountryName1.Items.Clear();
                    ddlCountryName1.DataSource = ds.Tables["Table"];
                    ddlCountryName1.DataTextField = "countryname";
                    ddlCountryName1.DataValueField = "ID";
                    ddlCountryName1.DataBind();
                    ddlCountryName1.Items.Insert(0, new ListItem("Select Country Name", "0"));
                }
                if (ds.Tables["Table"].Rows.Count > 0)
                {
                    ddlCountryName.Items.Clear();
                    ddlCountryName.DataSource = ds.Tables["Table"];
                    ddlCountryName.DataTextField = "countryname";
                    ddlCountryName.DataValueField = "ID";
                    ddlCountryName.DataBind();
                    ddlCountryName.Items.Insert(0, new ListItem("Select Country Name", "0"));
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
            if (btnSubmit.Text != "Update")
            {
                portMaster.CoutryName = ddlCountryName.SelectedValue;
                portMaster.PortName = txtrname.Text.Trim();
                portMaster.Address = txtaddress.Text.Trim();
                portMaster.EmailId = txtemail.Text.Trim();
                portMaster.ContactNo = txtcontact.Text.Trim();
                portMaster.FaxNo = txtfax.Text.Trim();
                portMaster.cActive = RadioAD.SelectedValue;


                int temp = cls.AddPortmaster(portMaster, Session["AID"].ToString());
                if (temp != 0)
                {
                    CommonFunction.MessageBox(this, "S", "Record saved successfully!!");
                    binddata();
                    cmf.ClearAllControls(Page);
                }

            }
            else
            {
                portMaster.Id = Convert.ToInt32(HiddenFieldID.Value);
                portMaster.CoutryName = ddlCountryName.SelectedValue;
                portMaster.PortName = txtrname.Text.Trim();
                portMaster.Address = txtaddress.Text.Trim();
                portMaster.EmailId = txtemail.Text.Trim();
                portMaster.ContactNo = txtcontact.Text.Trim();
                portMaster.FaxNo = txtfax.Text.Trim();
                portMaster.cActive = RadioAD.SelectedValue;

                int temp = cls.UpdatePortMaster(portMaster, Session["AID"].ToString());
                if (temp != 0)
                {
                    CommonFunction.MessageBox(this, "S", "Record saved successfully!!");
                    binddata();
                    cmf.ClearAllControls(Page);
                }
            }
        }

        public void binddata()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = cls.ViewAllPort(ddlCountryName1.SelectedValue);
                if (ds.Tables["Table"].Rows.Count > 0)
                {
                    GridView1.DataSource = ds.Tables["Table"];
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = ds.Tables["Table"];
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
            if (e.CommandName == "EditRow")
            {
                string Id = e.CommandArgument.ToString();
                DataSet ds = cls.ViewPortById(Convert.ToInt32(Id));
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlCountryName.SelectedValue = ds.Tables[0].Rows[0]["CountryId"].ToString();
                    txtrname.Text = ds.Tables[0].Rows[0]["PortName"].ToString();
                    txtaddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                    txtemail.Text = ds.Tables[0].Rows[0]["EmailId"].ToString();
                    txtcontact.Text = ds.Tables[0].Rows[0]["Contact"].ToString();
                    txtfax.Text = ds.Tables[0].Rows[0]["faxNo"].ToString();

                    string sactive = ds.Tables[0].Rows[0]["Active"].ToString();
                    if (sactive.Trim() == "Active")
                    {
                        RadioAD.SelectedValue = "0";
                    }
                    else { RadioAD.SelectedValue = "1"; }
                    HiddenFieldID.Value = Id;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowModal", "setTimeout(function () { $('#add_region').modal('show'); }, 200);", true);
                    btnSubmit.Text = "Update";
                }
            }
            else
            {
                string Id = e.CommandArgument.ToString();
                string UID = Session["AID"].ToString();
                DataSet ds = cls.DeleteportMaster(Convert.ToInt32(Id), Convert.ToInt32(UID));
                CommonFunction.MessageBox(this, "S", "Record deleted successfully!!");
                binddata();
            }
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            binddata();
        }
    }
}