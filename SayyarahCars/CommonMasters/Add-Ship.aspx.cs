using COMMON;
using DAL;
using ENTITY;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web;

namespace SayyarahCars.CommonMasters
{
    public partial class Add_Ship : System.Web.UI.Page
    {
        clsAdmin clsAdmin = new clsAdmin();
        AddShip addShip = new AddShip();
        CommonFunction cmf = new CommonFunction();
        DataSet ds = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["AID"] != null)
            {
                if (!Page.IsPostBack)
                {
                    getShipingPortTAndCountry();
                    if (Request.QueryString["Id"] != null)
                    {
                        GetShiDetailsById();
                    }
                }
            }
            else
            {
                Response.Redirect("~/Index.aspx",false);
            }
        }

        public void getShipingPortTAndCountry()
        {

            try
            {
                ds = clsAdmin.getShipingPortTAndCountryData();
                if (ds.Tables["Table"].Rows.Count > 0)
                {
                    ddlShipingCompany.Items.Clear();
                    ddlShipingCompany.DataSource = ds.Tables["Table"];
                    ddlShipingCompany.DataTextField = "ShippingName";
                    ddlShipingCompany.DataValueField = "Id";
                    ddlShipingCompany.DataBind();
                    ddlShipingCompany.Items.Insert(0, new ListItem("--Shipping Company--", "0"));
                }
                if (ds.Tables["Table1"].Rows.Count > 0)
                {
                    ddlPortFrom.Items.Clear();
                    ddlPortFrom.DataSource = ds.Tables["Table1"];
                    ddlPortFrom.DataTextField = "PortName";
                    ddlPortFrom.DataValueField = "ID";
                    ddlPortFrom.DataBind();
                    ddlPortFrom.Items.Insert(0, new ListItem("--Select Port--", "0"));
                }               
                if (ds.Tables["Table2"].Rows.Count > 0)
                {
                    ddlCountryName.Items.Clear();
                    ddlCountryName.DataSource = ds.Tables["Table2"];
                    ddlCountryName.DataTextField = "CountryName";
                    ddlCountryName.DataValueField = "Id";
                    ddlCountryName.DataBind();
                    ddlCountryName.Items.Insert(0, new ListItem("--Select Country--", "0"));
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                addShip.shiptype = ddlshiptype.SelectedValue;
                addShip.ShippingCompany = ddlShipingCompany.SelectedValue;
                addShip.PortFrom = ddlPortFrom.SelectedValue;
                addShip.TerminalName = ddlTerminalName.SelectedValue;
                addShip.CountryName = ddlCountryName.SelectedValue;
                addShip.ShipName = txtShipName.Text.Trim();
                addShip.DepartureDate = txtDepartureDate.Text.Trim();
                addShip.ArrivalDate = txtArrivalDate.Text.Trim();
                addShip.ShipFreight = txtShipFreight.Text.Trim();
                addShip.ShipCapacity = txtLoadingCapacity.Text.Trim();
                addShip.ShipUse = ddlshipuse.SelectedValue;
                int temp = clsAdmin.AddShip(addShip, Session["AID"].ToString());
                if (temp != 0)
                {
                    CommonFunction.MessageBox(this, "S", "Record saved successfully!!","close");
                    cmf.ClearAllControls(Page);
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        public void GetShiDetailsById()
        {
            try
            {
                string Id = cmf.Decrypt(Request.QueryString["Id"].ToString());
                ds = clsAdmin.ViewaShipDetailsById(Id);
                if (ds.Tables["Table"].Rows.Count > 0)
                {
                    btnSubmit.Visible = false;
                    btnUpdate.Visible = true;
                    hdnshipId.Value = ds.Tables[0].Rows[0]["Id"].ToString();
                    ddlShipingCompany.SelectedValue = ds.Tables[0].Rows[0]["ShippingCompanyId"].ToString();
                    ddlPortFrom.SelectedValue = ds.Tables[0].Rows[0]["PortId"].ToString();
                    ddlTerminalName.SelectedValue = ds.Tables[0].Rows[0]["TerminalId"].ToString();
                    ddlCountryName.SelectedValue = ds.Tables[0].Rows[0]["CountryId"].ToString();
                    txtShipName.Text = ds.Tables[0].Rows[0]["ShipName"].ToString();
                    txtDepartureDate.Text = ds.Tables[0].Rows[0]["DepartureDate"].ToString();
                    txtArrivalDate.Text = ds.Tables[0].Rows[0]["ArrivalDate"].ToString();
                    txtShipFreight.Text = ds.Tables[0].Rows[0]["ShipFreight"].ToString();
                    ddlshiptype.SelectedValue = ds.Tables[0].Rows[0]["shiptype"].ToString();
                    txtLoadingCapacity.Text = ds.Tables[0].Rows[0]["ShipCapacity"].ToString();
                    ddlshipuse.SelectedValue = ds.Tables[0].Rows[0]["ShipUse"].ToString();

                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                addShip.Id = Convert.ToInt32(hdnshipId.Value);
                addShip.shiptype = ddlshiptype.SelectedValue;
                addShip.ShippingCompany = ddlShipingCompany.SelectedValue;
                addShip.PortFrom = ddlPortFrom.SelectedValue;
                addShip.TerminalName = ddlTerminalName.SelectedValue;
                addShip.CountryName = ddlCountryName.SelectedValue;
                addShip.ShipName = txtShipName.Text.Trim();
                addShip.DepartureDate = txtDepartureDate.Text.Trim();
                addShip.ArrivalDate = txtArrivalDate.Text.Trim();
                addShip.ShipFreight = txtShipFreight.Text.Trim();
                addShip.ShipCapacity = txtLoadingCapacity.Text.Trim();
                addShip.ShipUse = ddlshipuse.SelectedValue;
                int temp = clsAdmin.updateAddShip(addShip, Session["AID"].ToString());
                if (temp != 0)
                {
                    CommonFunction.MessageBox(this, "S", "Record updated successfully!!", "close");
                    cmf.ClearAllControls(Page);
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void ddlPortFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            clsMasters cls = new clsMasters();
            int clientId = Convert.ToInt32(ddlPortFrom.SelectedValue);
            DataSet ds = cls.SelectTerminalPortById(clientId);
            cmf.BindDropDownList(ddlTerminalName, ds, "Tname", "id");
            ListItem li = new ListItem("--Select Terminal--", "0");
            ddlTerminalName.Items.Insert(0, li);
        }
    }
}