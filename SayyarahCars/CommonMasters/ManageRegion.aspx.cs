using COMMON;
using DAL;
using ENTITY;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SayyarahCars.CommonMasters
{
    public partial class ManageRegion : System.Web.UI.Page
    {
        CommonFunction cmf = new CommonFunction();
        clsUseMasters um = new clsUseMasters();
        clsMasters cls = new clsMasters();
        Region obj = new Region();
        public string uid = "0";
        ListItem li = new ListItem("--Select--", "0");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AID"] != null)
            {
                uid = Session["AID"].ToString();
            }
            if (!Page.IsPostBack)
            {
                getCountry();
                BindPort();
                GetAllRegionData();
            }
        }

        public void getCountry()
        {
            DataSet ds = um.ListCountry();
            if (ds.Tables[0].Rows.Count > 0)
            {
                cmf.BindDropDownList(ddlCountryName, ds, "countryname", "ID");
                ddlCountryName.Items.Insert(0, li);

                cmf.BindDropDownList(ddlcountry, ds, "countryname", "ID");
                ddlcountry.Items.Insert(0, li);
            }
        }
        protected void BindPort()
        {
            DataSet ds = um.ListPortByCountryID(ddlcountry.SelectedValue);
            cmf.BindDropDownList(ddlport, ds, "PortName", "ID");
            ddlport.Items.Insert(0, li);
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnSubmit.Text != "Update")
                {
                    obj.CountryName = ddlCountryName.SelectedValue;
                    obj.Regionname = txtRegioName.Text.Trim();
                    obj.ActiveDeactive = RadioAD.SelectedValue;
                    
                    int temp = cls.AddRegion(obj, Session["AID"].ToString());
                    if (temp != 0)
                    {
                        CommonFunction.MessageBox(this, "S", "Record saved successfully!!");
                        cmf.ClearAllControls(Page);
                        GetAllRegionData();
                    }
                }
                else
                {
                    obj.CountryName = ddlCountryName.SelectedValue;
                    obj.Regionname = txtRegioName.Text.Trim();
                    obj.Id = Convert.ToInt32(HiddenFieldSID.Value);
                    obj.ActiveDeactive = RadioAD.SelectedValue;
                    
                    int temp = cls.UpdateRegion(obj, Session["AID"].ToString());
                    if (temp != 0)
                    {
                        CommonFunction.MessageBox(this, "S", "Record updated successfully!!");
                        cmf.ClearAllControls(Page);
                        GetAllRegionData();
                        btnSubmit.Text = "Save changes";
                    }

                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void GetAllRegionData()
        {
            try
            {
                DataSet ds = cls.getAllRegionData(ddlcountry.SelectedValue);
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
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
                DataSet ds = cls.Getstate(Convert.ToInt32(Id));
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlCountryName.SelectedValue = ds.Tables[0].Rows[0]["Countryid"].ToString();
                    txtRegioName.Text = ds.Tables[0].Rows[0]["stateName"].ToString();
                    string sactive = ds.Tables[0].Rows[0]["Status"].ToString();
                    if (sactive.Trim() == "Active")
                    {
                        RadioAD.SelectedValue = "0";
                    }
                    else { RadioAD.SelectedValue = "1"; }
                    HiddenFieldSID.Value = Id;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowModal", "setTimeout(function () { $('#add_region').modal('show'); }, 200);", true);
                    btnSubmit.Text = "Update";
                }
            }
            else
            {
                string Id = e.CommandArgument.ToString();
                int rtval = cls.DeleteRegion(Convert.ToInt32(Id), Session["AID"].ToString());
                CommonFunction.MessageBox(this, "S", "Record deleted successfully!!");
                GetAllRegionData();
            }
        }

        protected void btnupdateport_Click(object sender, EventArgs e)
        {
            int i = 0;
            try
            {
                foreach (GridViewRow row in GridView1.Rows)
                {
                    CheckBox chk = row.FindControl("Chkbox") as CheckBox;
                    if (chk.Checked)
                    {
                        Label lblid = row.FindControl("lblid") as Label;
                        obj.Id = Convert.ToInt32(lblid.Text);
                        obj.PortId = ddlport.SelectedValue;
                        int temp = cls.UpdateRegionPort(obj, Session["AID"].ToString());
                        if (temp > 0)
                        {
                            i = i + 1;
                        }
                    }
                }
                if (i > 0)
                {
                    CommonFunction.MessageBox(this, "S", "Region Port updated successfully");
                    GetAllRegionData();
                }
                else
                {
                    CommonFunction.MessageBox(this, "E", "Select atleast one record to update");
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
            GetAllRegionData();
        }

        protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindPort();
        }
    }
}