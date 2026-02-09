using COMMON;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DAL;
using ENTITY;
using System.Web;

namespace SayyarahCars.Admin
{
    public partial class Add_Shipping_Price : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        clsAdmin clsAdmin = new clsAdmin();
        ShipingPriceModel shipingPrice = new ShipingPriceModel();
        CommonFunction commonFunction = new CommonFunction();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["AID"] != null)
            {
                if (!Page.IsPostBack)
                {
                    getAllMasterData();

                    if (Request.QueryString["Id"] != null)
                    {
                        getAllShipingPriceDataById();
                    }
                }
            }
            else
            {
                Response.Redirect("/Index", false);
            }
        }

        public void getAllMasterData()
        {
            try
            {
                ds = clsAdmin.getShipingPriceMasterData();

                if (ds.Tables["Table"].Rows.Count > 0)
                {
                    ddlShipingCompany.Items.Clear();
                    ddlShipingCompany.DataSource = ds.Tables["Table"];
                    ddlShipingCompany.DataTextField = "ShippingName";
                    ddlShipingCompany.DataValueField = "Id";
                    ddlShipingCompany.DataBind();
                    ddlShipingCompany.Items.Insert(0, new ListItem("Select shipping company", "0"));
                }
                if (ds.Tables["Table1"].Rows.Count > 0)
                {
                    ddlProductType.Items.Clear();
                    ddlProductType.DataSource = ds.Tables["Table1"];
                    ddlProductType.DataTextField = "ProductName";
                    ddlProductType.DataValueField = "Id";
                    ddlProductType.DataBind();
                    ddlProductType.Items.Insert(0, new ListItem("Select product type", "0"));
                }
                if (ds.Tables["Table2"].Rows.Count > 0)
                {
                    ddlCountryName.Items.Clear();
                    ddlCountryName.DataSource = ds.Tables["Table2"];
                    ddlCountryName.DataTextField = "CountryName";
                    ddlCountryName.DataValueField = "Id";
                    ddlCountryName.DataBind();
                    ddlCountryName.Items.Insert(0, new ListItem("Select country name", "0"));
                }
                if (ds.Tables["Table3"].Rows.Count > 0)
                {
                    ddlPortName.Items.Clear();
                    ddlPortName.DataSource = ds.Tables["Table3"];
                    ddlPortName.DataTextField = "PortName";
                    ddlPortName.DataValueField = "ID";
                    ddlPortName.DataBind();
                    ddlPortName.Items.Insert(0, new ListItem("Select port name", "0"));
                }
            }
            catch (Exception ex)
            {
                CommonFunction.DisplayAlert(this, ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                shipingPrice.ShipingCompany = ddlShipingCompany.SelectedValue;
                shipingPrice.ProductType = ddlProductType.SelectedValue;
                shipingPrice.CountryName = ddlCountryName.SelectedValue;
                shipingPrice.PortName = ddlPortName.SelectedValue;
                shipingPrice.FreightPrice = txtFreightPrice.Text.Trim();
                int temp = clsAdmin.addShipingPrice(shipingPrice, Session["AID"].ToString());
                if (temp != 0)
                {
                    CommonFunction.MessageBox(this, "S", "Record saved successfully!!");

                    commonFunction.ClearAllControls(Page);
                }
            }
            catch (Exception ex)
            {
                CommonFunction.DisplayAlert(this, ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        public void getAllShipingPriceDataById()
        {
            try
            {
                if (Request.QueryString["Id"] != null)
                {
                    hdnShipinpriceId.Value = Request.QueryString["Id"].ToString();

                    ds = clsAdmin.viewaShipinPriceById(hdnShipinpriceId.Value);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        btnSubmit.Visible = false;
                        btnUpdate.Visible = true;
                        hdnShipinpriceId.Value = ds.Tables[0].Rows[0]["Id"].ToString();
                        ddlShipingCompany.SelectedValue = ds.Tables[0].Rows[0]["ShipingCompanyId"].ToString();
                        ddlProductType.SelectedValue = ds.Tables[0].Rows[0]["ProductId"].ToString();
                        ddlCountryName.SelectedValue = ds.Tables[0].Rows[0]["CountryId"].ToString();
                        ddlPortName.SelectedValue = ds.Tables[0].Rows[0]["PortId"].ToString();
                        txtFreightPrice.Text = ds.Tables[0].Rows[0]["FreightPrice"].ToString();
                    }
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
                shipingPrice.Id = Convert.ToInt32(hdnShipinpriceId.Value);
                shipingPrice.ShipingCompany = ddlShipingCompany.SelectedValue;
                shipingPrice.ProductType = ddlProductType.SelectedValue;
                shipingPrice.CountryName = ddlCountryName.SelectedValue;
                shipingPrice.PortName = ddlPortName.SelectedValue;
                shipingPrice.FreightPrice = txtFreightPrice.Text.Trim();
                int temp = clsAdmin.updateShipiningPrice(shipingPrice, Session["AID"].ToString());
                if (temp != 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "toastr", "toastr.success('Record updated successfully!!');setTimeout(function() { window.location.href = 'View-ShipinPrice.aspx'; }, 1500);", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "toastr", "toastr.error('Record not updated !!');", true);
                }
            }
            catch (Exception ex)
            {
                CommonFunction.DisplayAlert(this, ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }
    }
}