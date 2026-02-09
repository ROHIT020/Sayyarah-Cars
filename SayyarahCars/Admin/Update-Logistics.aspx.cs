using COMMON;
using DAL;
using ENTITY;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SayyarahCars.Admin
{
    public partial class Update_Logistics : System.Web.UI.Page
    {
        public CommonFunction cmf = new CommonFunction();
        clsMasters clsMasters = new clsMasters();
        clsAdmin clsAdmin = new clsAdmin();
        DataSet ds = new DataSet();
        public string uid = "0";
        UpdatelogisticModel updatelogisticModel = new UpdatelogisticModel();
        UpdateLogisticModelData updateLogisticModelData = new UpdateLogisticModelData();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetAllCountry();
                BindDropDownData();
                divUpdateFooter.Visible = false;
            }
        }

        public void GetAllCountry()
        {
            try
            {
                ds = clsMasters.CountryBind();
                cmf.BindDropDownList(ddlCountry, ds, "CountryName", "Id");
                ListItem li = new ListItem("--Select Country--", "0");
                ddlCountry.Items.Insert(0, li);
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        public void BindDropDownData()
        {
            try
            {
                ds = clsAdmin.GetUpdatelogisticData();
                if (ds.Tables["Table"].Rows.Count > 0)
                {
                    ddlShippingCompany.Items.Clear();
                    ddlShippingCompany.DataSource = ds.Tables["Table"];
                    ddlShippingCompany.DataTextField = "ShippingName";
                    ddlShippingCompany.DataValueField = "Id";
                    ddlShippingCompany.DataBind();
                    ddlShippingCompany.Items.Insert(0, new ListItem("Select Shipping Company", "0"));
                }
                if (ds.Tables["Table1"].Rows.Count > 0)
                {
                    ddlPortFrom.Items.Clear();
                    ddlPortFrom.DataSource = ds.Tables["Table1"];
                    ddlPortFrom.DataTextField = "PortName";
                    ddlPortFrom.DataValueField = "Id";
                    ddlPortFrom.DataBind();
                    ddlPortFrom.Items.Insert(0, new ListItem("Select Port Name", "0"));
                }
                if (ds.Tables["Table2"].Rows.Count > 0)
                {
                    ddlShipName.Items.Clear();
                    ddlShipName.DataSource = ds.Tables["Table2"];
                    ddlShipName.DataTextField = "ShipName";
                    ddlShipName.DataValueField = "Id";
                    ddlShipName.DataBind();
                    ddlShipName.Items.Insert(0, new ListItem("Select Ship Name", "0"));
                }
                if (ds.Tables["Table2"].Rows.Count > 0)
                {
                    ddlShipNme.Items.Clear();
                    ddlShipNme.DataSource = ds.Tables["Table2"];
                    ddlShipNme.DataTextField = "ShipName";
                    ddlShipNme.DataValueField = "Id";
                    ddlShipNme.DataBind();
                    ddlShipNme.Items.Insert(0, new ListItem("Select Ship Name", "0"));
                }
                if (ds.Tables["Table3"].Rows.Count > 0)
                {
                    ddlClientName.Items.Clear();
                    ddlClientName.DataSource = ds.Tables["Table3"];
                    ddlClientName.DataTextField = "Name";
                    ddlClientName.DataValueField = "Id";
                    ddlClientName.DataBind();
                    ddlClientName.Items.Insert(0, new ListItem("Select Client Name", "0"));
                }
                if (ds.Tables["Table4"].Rows.Count > 0)
                {
                    ddlBroker.Items.Clear();
                    ddlBroker.DataSource = ds.Tables["Table4"];
                    ddlBroker.DataTextField = "Name";
                    ddlBroker.DataValueField = "Id";
                    ddlBroker.DataBind();
                    ddlBroker.Items.Insert(0, new ListItem("Select Broker", "0"));
                }
                if (ds.Tables["Table5"].Rows.Count > 0)
                {
                    ddlAuctionHouse.Items.Clear();
                    ddlAuctionHouse.DataSource = ds.Tables["Table5"];
                    ddlAuctionHouse.DataTextField = "Name";
                    ddlAuctionHouse.DataValueField = "Id";
                    ddlAuctionHouse.DataBind();
                    ddlAuctionHouse.Items.Insert(0, new ListItem("Select House", "0"));
                }
                if (ds.Tables["Table6"].Rows.Count > 0)
                {
                    ddlTransport.Items.Clear();
                    ddlTransport.DataSource = ds.Tables["Table6"];
                    ddlTransport.DataTextField = "TransportName";
                    ddlTransport.DataValueField = "Id";
                    ddlTransport.DataBind();
                    ddlTransport.Items.Insert(0, new ListItem("Select Transport", "0"));
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
            GetAllData();
        }

        public void GetAllData()
        {
            try
            {
                string ChasisNo = "";
                string AllChasisNo = txtallchno.Text;
                if (AllChasisNo != "")
                {
                    ChasisNo = AllChasisNo.Remove(AllChasisNo.Length - 1, 1);
                    ds = clsAdmin.GetUpdateLogisticDataByChno(ChasisNo);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        divUpdateFooter.Visible = true;
                        ViewState["DataTable"] = ds.Tables[0];
                        GridView1.DataSource = ds.Tables[0];
                        GridView1.DataBind();
                    }
                    else
                    {
                        divUpdateFooter.Visible = false;
                        GridView1.DataSource = ds.Tables[0];
                        GridView1.DataBind();
                    }
                }
                else
                {
                    updatelogisticModel.CountryName = ddlCountry.SelectedValue;
                    updatelogisticModel.ClientName = ddlClientName.SelectedValue;
                    updatelogisticModel.AuctionHouse = ddlAuctionHouse.SelectedValue;
                    updatelogisticModel.ShippingCompany = ddlShippingCompany.SelectedValue;
                    updatelogisticModel.ShipName = ddlShipName.SelectedValue;
                    updatelogisticModel.PortFrom = ddlPortFrom.SelectedValue;
                    updatelogisticModel.Transport = ddlTransport.SelectedValue;
                    updatelogisticModel.Broker = ddlBroker.SelectedValue;
                    updatelogisticModel.Urgent = ddlUrgent.SelectedValue;
                    updatelogisticModel.NoPlate = ddlNoPlate.SelectedValue;
                    updatelogisticModel.Surrender = ddlSurrender.SelectedValue;
                    updatelogisticModel.Datefrom = txtDatefrom.Text.Trim();
                    updatelogisticModel.DateTo = txtDateTo.Text.Trim();
                    updatelogisticModel.RikujiDate = txtRikujiDate.Text.Trim();
                    updatelogisticModel.ProductIn = ddlProductIn.SelectedValue;
                    updatelogisticModel.Loading = ddlLoading.SelectedValue;
                    updatelogisticModel.CarStatus = ddlCarStatus.SelectedValue;
                    int pageNo = 1;
                    HiddenField1.Value = "1";
                    int pageSize = Convert.ToInt32(ddlShortBy.SelectedValue);
                    ds = clsAdmin.Updatelogistics(updatelogisticModel, pageNo.ToString(), pageSize);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ViewState["DataTable"] = ds.Tables[0];
                        GridView1.PageSize = int.Parse(ddlShortBy.SelectedValue);
                        GridView1.VirtualItemCount = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                        GridView1.DataSource = ds.Tables[0];
                        GridView1.DataBind();
                        divUpdateFooter.Visible = true;
                    }
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
                updateLogisticModelData.ProductInDate = string.IsNullOrWhiteSpace(txtProductInDate.Text) ? null : txtProductInDate.Text.Trim();
                updateLogisticModelData.WishPlanDate = string.IsNullOrWhiteSpace(txtWishPlanDate.Text) ? null : txtWishPlanDate.Text.Trim();
                updateLogisticModelData.WishPInDate = string.IsNullOrWhiteSpace(txtWishPInDate.Text) ? null : txtWishPInDate.Text.Trim();
                updateLogisticModelData.WishShipDate = string.IsNullOrWhiteSpace(txtWishShipDate.Text) ? null : txtWishShipDate.Text.Trim();
                updateLogisticModelData.WishArrivalDate = string.IsNullOrWhiteSpace(txtWishArrivalDate.Text) ? null : txtWishArrivalDate.Text.Trim();
                updateLogisticModelData.ShipName = string.IsNullOrWhiteSpace(ddlShipNme.SelectedValue) ? null : ddlShipNme.SelectedValue;
                updateLogisticModelData.Surrender = string.IsNullOrWhiteSpace(RadioSurrender.SelectedValue) ? null : RadioSurrender.SelectedValue;
                updateLogisticModelData.Loading = string.IsNullOrWhiteSpace(RadioLoading.SelectedValue) ? null : RadioLoading.SelectedValue;
                foreach (GridViewRow row in GridView1.Rows)
                {
                    CheckBox chk = row.FindControl("Chkbox") as CheckBox;
                    if (chk.Checked)
                    {
                        {
                            Label lblid = row.FindControl("lblpid") as Label;
                            int result = clsAdmin.UpdateLogisticById(updateLogisticModelData, lblid.Text);
                            if (result != 0)
                            {
                                CommonFunction.MessageBox(this, "S", "Record updated successfully!!");
                                GetAllData();
                                cmf.ClearAllControls(Page);
                            }
                        }
                    }
                }
                CommonFunction.MessageBox(this, "E", "Select atleast one record to update");
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }
    }
}