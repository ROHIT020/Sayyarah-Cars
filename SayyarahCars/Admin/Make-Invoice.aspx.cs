using COMMON;
using DAL;
using ENTITY;
using System;
using System.Data;
using System.Web.UI.WebControls;


namespace SayyarahCars.Admin
{
    public partial class Make_Invoice : System.Web.UI.Page
    {
        CommonFunction cmf = new CommonFunction();
        DataSet ds = new DataSet();
        clsAdmin clsAdmin = new clsAdmin();
        MakeInvoice makeInvoice = new MakeInvoice();
        public string uid = "0";
        MakeInvoiceModel makeInvoiceModel = new MakeInvoiceModel();
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
                    GetMasterData();
                    if (Request.QueryString["PId"] != null)
                    {
                        GetInvoiceDataById();
                    }
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        public void GetMasterData()
        {
            try
            {
                ds = clsAdmin.GetAllInvoiceMasterData();
                if (ds.Tables["Table"].Rows.Count > 0)
                {
                    ddlAuctionName.Items.Clear();
                    ddlAuctionName.DataSource = ds.Tables["Table"];
                    ddlAuctionName.DataTextField = "Name";
                    ddlAuctionName.DataValueField = "Id";
                    ddlAuctionName.DataBind();
                    ddlAuctionName.Items.Insert(0, new ListItem("Select Auction Name", "0"));
                }
                else
                {
                    ddlAuctionName.Items.Clear();
                    ddlAuctionName.Items.Insert(0, new ListItem("Select Auction Name", "0"));
                }
                if (ds.Tables["Table1"].Rows.Count > 0)
                {

                    ddlPortName.Items.Clear();
                    ddlPortName.DataSource = ds.Tables["Table1"];
                    ddlPortName.DataTextField = "PortName";
                    ddlPortName.DataValueField = "Id";
                    ddlPortName.DataBind();
                    ddlPortName.Items.Insert(0, new ListItem("Select Port Name", "0"));
                }
                else
                {
                    ddlPortName.Items.Clear();
                    ddlPortName.Items.Insert(0, new ListItem("Select Port Name", "0"));
                }
                if (ds.Tables["Table2"].Rows.Count > 0)
                {
                    ddlShippingCompany.Items.Clear();
                    ddlShippingCompany.DataSource = ds.Tables["Table2"];
                    ddlShippingCompany.DataTextField = "ShippingName";
                    ddlShippingCompany.DataValueField = "Id";
                    ddlShippingCompany.DataBind();
                    ddlShippingCompany.Items.Insert(0, new ListItem("Select Shipping Company", "0"));
                }
                else
                {
                    ddlShippingCompany.Items.Clear();
                    ddlShippingCompany.Items.Insert(0, new ListItem("Select Shipping Company", "0"));
                }
                if (ds.Tables["Table3"].Rows.Count > 0)
                {
                    ddlCustomer.Items.Clear();
                    ddlCustomer.DataSource = ds.Tables["Table3"];
                    ddlCustomer.DataTextField = "Name";
                    ddlCustomer.DataValueField = "Id";
                    ddlCustomer.DataBind();
                    ddlCustomer.Items.Insert(0, new ListItem("Select Customer", "0"));
                }
                else
                {
                    ddlCustomer.Items.Clear();
                    ddlCustomer.Items.Insert(0, new ListItem("Select Customer", "0"));
                }

                if (ds.Tables["Table4"].Rows.Count > 0)
                {
                    ddlCurrencyType.Items.Clear();
                    ddlCurrencyType.DataSource = ds.Tables["Table4"];
                    ddlCurrencyType.DataTextField = "Symbol";
                    ddlCurrencyType.DataValueField = "Id";
                    ddlCurrencyType.DataBind();
                    ddlCurrencyType.Items.Insert(0, "Select Currency type");
                    ddlCurrencyType.SelectedValue = "2";
                }
                else
                {
                    ddlCurrencyType.Items.Clear();
                    ddlCurrencyType.Items.Insert(0, "Select Currency type");
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
            try
            {
                makeInvoiceModel.ProductId = hdnInvoiceId.Value;
                makeInvoiceModel.ProductType = ddlProductType.SelectedItem.Text;
                makeInvoiceModel.Customer = ddlCustomer.SelectedValue;
                makeInvoiceModel.ProductName = txtProductName.Text.Trim();
                makeInvoiceModel.ChassisNo = txtChassisNo.Text.Trim();
                makeInvoiceModel.AuctionName = ddlAuctionName.SelectedValue;
                makeInvoiceModel.ShippingCompany = ddlShippingCompany.SelectedValue;
                makeInvoiceModel.InvoiceType = ddlInvoiceType.SelectedValue;
                makeInvoiceModel.PortName = ddlPortName.SelectedValue;
                makeInvoiceModel.CurrencyType = ddlCurrencyType.SelectedValue;
                makeInvoiceModel.PushPrice = txtPushPrice.Text.Trim();
                makeInvoiceModel.FOBPrice = txtFOBPrice.Text.Trim();
                makeInvoiceModel.FreightCharge = txtFreightCharge.Text.Trim();
                makeInvoiceModel.RecycleAmount = txtRecycleAmount.Text.Trim();
                makeInvoiceModel.OtherServices = txtOtherServices.Text.Trim();
                makeInvoiceModel.Insurance = myCheck.SelectedValue;
                makeInvoiceModel.InsuranceText = txtInsurance.Text.Trim();
                makeInvoiceModel.Radiation = txtRadiationPrice.Text.Trim();
                makeInvoiceModel.InspectionPrice = txtInspectionPrice.Text.Trim();
                makeInvoiceModel.PortPrice = txtPortPrice.Text.Trim();
                makeInvoiceModel.CustomClearance = txtCustomClearance.Text.Trim();
                makeInvoiceModel.CarSelection = txtCarSelection.Text.Trim();
                makeInvoiceModel.Transport = txtTransport.Text.Trim();
                makeInvoiceModel.FinalSoldPrice = txtFinalSoldPrice.Text.Trim();
                makeInvoiceModel.OrderType = radiortype.SelectedValue;
                makeInvoiceModel.Discount = txtDiscount.Text.Trim();
                makeInvoiceModel.Rate = txtRate.Text.Trim();
                makeInvoiceModel.InvoiceUsed = ddlInvoiceUsed.SelectedValue;
                makeInvoiceModel.UID = Session["AID"].ToString();
                int result = clsAdmin.AddInvoice(makeInvoiceModel);
                if (result != 0)
                {
                    Session["InvoiceNo"] = result;
                    Response.Redirect("GenerateInvoice.aspx", false);
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        public void GetInvoiceDataById()
        {
            string Id = cmf.Decrypt(Request.QueryString["PId"]);
            ds = clsAdmin.GetInvoiceDetailsById(Convert.ToInt32(Id));
            if (ds.Tables["Table1"].Rows.Count > 0)
            {
                CommonFunction.MessageBox(this.Page, "W", "This item is no longer available as it has been sold. Please choose another product.", "Manage-Purchase.aspx");
            }
            if (ds.Tables["Table"].Rows.Count > 0)
            {
                hdnInvoiceId.Value = Id;
                txtProductName.Text = ds.Tables["Table"].Rows[0]["ProductName"].ToString();
                Hdollaryenprice.Value = ds.Tables["Table"].Rows[0]["PushPrice"].ToString();
                txtPushPrice.Text = ds.Tables["Table"].Rows[0]["PushPrice"].ToString();
                double pushPrice = ds.Tables["Table"].Rows[0]["PushPrice"] == DBNull.Value ? 0 : Convert.ToDouble(ds.Tables["Table"].Rows[0]["PushPrice"]);
                double dpp = pushPrice + pushPrice / 10;
                Hnetpprice.Value = dpp.ToString();
                Hnetprice.Value = ds.Tables["Table"].Rows[0]["Pushprice"].ToString();
                txtChassisNo.Text = ds.Tables["Table"].Rows[0]["ChassisNo"].ToString();
                txtFinalSoldPrice.Text = txtPushPrice.Text;
                ddlShippingCompany.SelectedValue = ds.Tables["Table"].Rows[0]["ShippingId"].ToString();
                //bindport();
                ddlCustomer.SelectedValue = ds.Tables["Table"].Rows[0]["uid"].ToString();
                CountryId.Value = ds.Tables["Table"].Rows[0]["countryid"].ToString();
                string CC = ds.Tables["Table"].Rows[0]["CC"].ToString().Trim();
                string Ctype = ds.Tables["Table"].Rows[0]["FuelType"].ToString().Trim();
                string Urgent = ds.Tables["Table"].Rows[0]["PType"].ToString();
                AuctionDate.Value = ds.Tables["Table"].Rows[0]["ADate"].ToString();
                string PID = ds.Tables["Table"].Rows[0]["productid"].ToString();
                ddlPortName.SelectedValue = ds.Tables["Table"].Rows[0]["PortFromId"].ToString();
                ddlAuctionName.SelectedValue = ds.Tables["Table"].Rows[0]["AuctionId"].ToString();
            }
            if (ds.Tables["Table2"].Rows.Count > 0)
            {
                txtRate.Text = ds.Tables["Table2"].Rows[0]["Rate"].ToString();
            }
        }
        public void bindfreight()
        {
            try
            {
                ds = clsAdmin.bindfreight(ddlShippingCompany.SelectedValue, CountryId.Value, ddlPortName.SelectedValue);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ddlProductType.SelectedValue == "1")
                    {
                        if (Convert.ToDouble(Hdollaryenprice.Value) > 10000000)
                        {
                            txtFreightCharge.Text = "0";
                            txtOtherServices.Text = "520";
                        }
                        else
                        {
                            txtFreightCharge.Text = "0";
                            txtOtherServices.Text = "520";
                        }
                        //bindnormal();   --In bizupon
                    }
                    else if (ddlProductType.SelectedValue == "2")
                    {
                        txtFreightCharge.Text = "2000";
                        txtOtherServices.Text = "400";
                        //bindnormalcutconstructor();  --In bizupon
                    }
                    else if (ddlProductType.SelectedValue == "3")
                    {
                        txtFreightCharge.Text = "2000";
                        txtOtherServices.Text = "400";
                    }
                    else
                    {
                        txtFreightCharge.Text = "2700";
                        txtOtherServices.Text = "400";
                        //bindnormalcutconstructor();  --In bizupon
                    }
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