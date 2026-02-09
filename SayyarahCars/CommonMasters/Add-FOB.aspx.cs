using COMMON;
using DAL;
using ENTITY;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SayyarahCars.CommonMasters
{
    public partial class Add_FOB : System.Web.UI.Page
    {
        CommonFunction cmf = new CommonFunction();
        clsMasters cls = new clsMasters();
        DataSet ds = new DataSet();
        ListItem li = new ListItem("--Select--", "0");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindCountry();
                if (Request.QueryString["id"] != null)
                {
                    btnSubmit.Text = "Update";
                    binddata();
                }
            }
        }

        protected void BindCountry()
        {
            clsUseMasters um = new clsUseMasters();
            DataSet ds = um.ListCountry();
            cmf.BindDropDownList(ddlCountryName, ds, "countryname", "ID");
            ddlCountryName.Items.Insert(0, li);
        }
        protected void ddlCountryName_SelectedIndexChanged1(object sender, EventArgs e)
        {
            try
            {
                int countryId = Convert.ToInt32(ddlCountryName.SelectedValue);
                DataSet ds = cls.getPortsByCountryId(countryId);
                cmf.BindDropDownList(ddlPortname, ds, "PortName", "ID", 0);
                ddlPortname.Items.Insert(0, li);
                cmf.BindDropDownList(ddlRegion, ds, "Name", "ID", 1);
                ddlRegion.Items.Insert(0, li);    
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void binddata()
        {
            string Id = cmf.Decrypt(Request.QueryString["id"].ToString());
            ds = cls.getFobTypeDataById(Id);
            if (ds.Tables[0].Rows.Count > 0)
            {              
                ddlCountryName.SelectedValue = ds.Tables[0].Rows[0]["Countryid"].ToString();
                int countryId = Convert.ToInt32(ddlCountryName.SelectedValue);
                DataSet dsm = cls.getPortsByCountryId(countryId);
                cmf.BindDropDownList(ddlPortname, dsm, "PortName", "ID", 0);
                ddlPortname.Items.Insert(0, li);
                cmf.BindDropDownList(ddlRegion, dsm, "Name", "ID", 1);
                ddlRegion.Items.Insert(0, li);
                ddlRegion.SelectedValue = ds.Tables[0].Rows[0]["StateId"].ToString();
                ddlPortname.SelectedValue = ds.Tables[0].Rows[0]["PortId"].ToString();
                ddlFobtype.SelectedValue = ds.Tables[0].Rows[0]["FobType"].ToString();
                txtprice.Text = ds.Tables[0].Rows[0]["FobPrice"].ToString();
                btnSubmit.Text = "Update";
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            FobType fobType = new FobType();
            if (btnSubmit.Text != "Update")
            {
                fobType.Country = ddlCountryName.SelectedValue;
                fobType.CityName = ddlRegion.SelectedValue;
                fobType.PortName = ddlPortname.SelectedValue;
                fobType.FobTypes = ddlFobtype.SelectedValue;
                fobType.Price = txtprice.Text.Trim();
                int temp = cls.addFobType(fobType, Session["AID"].ToString());
                if (temp != 0)
                {
                    CommonFunction.MessageBox(this, "S", "Record saved successfully!!");                   
                    cmf.ClearAllControls(Page);
                }
            }
            else
            {
                fobType.Country = ddlCountryName.SelectedValue;
                fobType.CityName = ddlRegion.SelectedValue;
                fobType.PortName = ddlPortname.SelectedValue;
                fobType.FobTypes = ddlFobtype.SelectedValue;
                fobType.Price = txtprice.Text.Trim();
                string Id = cmf.Decrypt(Request.QueryString["id"]).ToString();
                fobType.Id = Convert.ToInt32(Id);
                int temp = cls.updateFobType(fobType, Session["AID"].ToString());
                if (temp != 0)
                {
                    CommonFunction.MessageBox(this, "S", "Record updated successfully!!");                   
                    cmf.ClearAllControls(Page);
                    btnSubmit.Text = "Save changes";
                }
            }
        }
    }
}