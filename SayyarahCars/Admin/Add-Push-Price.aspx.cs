using COMMON;
using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;

namespace SayyarahCars.Admin
{
    public partial class Add_Push_Price : System.Web.UI.Page
    {
        CommonFunction cmf = new CommonFunction();
        clsMasters _cls = new clsMasters();
        clsAdmin _clsA = new clsAdmin();
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
                    BindMasters();
                    if (Request.QueryString["ID"] != null)
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
        protected void BindMasters()
        {
            DataSet ds = _cls.SelectAuctionBuyType();
            cmf.BindDropDownList(ddlABFType, ds, "Name", "id", 0);
            ListItem li = new ListItem("Select", "0");
            ddlABFType.Items.Insert(0, li);
            cmf.BindDropDownList(ddlOtherType, ds, "Name", "id", 1);
            ddlOtherType.Items.Insert(0, li);
            cmf.BindDropDownList(ddlOtherNType, ds, "Name", "id", 1);
            ddlOtherNType.Items.Insert(0, li);

            ds = _cls.SelectCurrencyType();
            cmf.BindDropDownList(ddlctype, ds, "Ctype", "id", 0);
            ddlctype.Items.Insert(0, li);
        }
        protected void binddata()
        {
            string PID = cmf.Decrypt(Request.QueryString["ID"].ToString());
            DataSet ds = _clsA.SelectPushPrice(PID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblcno.Text = ds.Tables[0].Rows[0]["ChassisNo"].ToString();
                lblAuctionHouse.Text = ds.Tables[0].Rows[0]["AName"].ToString();
                lblAuctionDate.Text = cmf.dateConvertShow(ds.Tables[0].Rows[0]["DOE"].ToString());
                ddlctype.SelectedValue = ds.Tables[0].Rows[0]["Ctype"].ToString();
                ddlPPType.SelectedValue = ds.Tables[0].Rows[0]["PPType"].ToString();
                txtPushPrice.Text = ds.Tables[0].Rows[0]["PushPrice"].ToString();
                txtPushPriceTax.Text = ds.Tables[0].Rows[0]["PushPriceTax"].ToString();
                ddlABFType.SelectedValue = ds.Tables[0].Rows[0]["ABFType"].ToString();
                txtAuctionFeed.Text = ds.Tables[0].Rows[0]["AuctionFeed"].ToString();
                txtAuctionFeedTax.Text = ds.Tables[0].Rows[0]["AuctionFeedTax"].ToString();
                txtNoPlate.Text = ds.Tables[0].Rows[0]["NoPlate"].ToString();
                txtNoPlateTax.Text = ds.Tables[0].Rows[0]["NoPlateTax"].ToString();
                txtNoPlateNTax.Text = ds.Tables[0].Rows[0]["NoPlateNTax"].ToString();
                txtSecurity.Text = ds.Tables[0].Rows[0]["Security"].ToString();
                txtSecurityTax.Text = ds.Tables[0].Rows[0]["SecurityTax"].ToString();
                txtSecurityNTax.Text = ds.Tables[0].Rows[0]["SecurityNTax"].ToString();
                txtTransport.Text = ds.Tables[0].Rows[0]["Transport"].ToString();
                txtTransportTax.Text = ds.Tables[0].Rows[0]["TransportTax"].ToString();
                txtCancellation.Text = ds.Tables[0].Rows[0]["Cancellation"].ToString();
                txtCancellationTax.Text = ds.Tables[0].Rows[0]["CancellationTax"].ToString();
                txtCarPanalty.Text = ds.Tables[0].Rows[0]["CarPanalty"].ToString();
                txtRecycleFee.Text = ds.Tables[0].Rows[0]["RecycleFee"].ToString();
                ddlOtherType.SelectedValue = ds.Tables[0].Rows[0]["OtherType"].ToString();
                txtOtherTypeAmt.Text = ds.Tables[0].Rows[0]["OtherTypeAmt"].ToString();
                txtOtherTypeTax.Text = ds.Tables[0].Rows[0]["OtherTypeTax"].ToString();
                ddlOtherNType.SelectedValue = ds.Tables[0].Rows[0]["OtherNType"].ToString();
                txtOtherNTypeAmt.Text = ds.Tables[0].Rows[0]["OtherNTypeAmt"].ToString();
                txtTotalAmount.Text = ds.Tables[0].Rows[0]["TotalAmount"].ToString();
                txtRemarks.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();

            }
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            entPushPrice _obj = new entPushPrice();
            _obj.PID = cmf.Decrypt(Request.QueryString["id"].ToString());
            _obj.CurrencyType = ddlctype.SelectedValue;
            _obj.PPType = ddlPPType.SelectedValue;
            _obj.PushPrice = txtPushPrice.Text.Trim();
            _obj.PushPriceTax = txtPushPriceTax.Text.Trim();
            _obj.ABFType = ddlABFType.SelectedValue;
            _obj.AuctionFeed = txtAuctionFeed.Text.Trim();
            _obj.AuctionFeedTax = txtAuctionFeedTax.Text.Trim();
            _obj.NoPlate = txtNoPlate.Text.Trim();
            _obj.NoPlateTax = txtNoPlateTax.Text.Trim();
            _obj.NoPlateNTax = txtNoPlateNTax.Text.Trim();
            _obj.Security = txtSecurity.Text.Trim();
            _obj.SecurityTax = txtSecurityTax.Text.Trim();
            _obj.SecurityNTax = txtSecurityNTax.Text.Trim();
            _obj.Transport = txtTransport.Text.Trim();
            _obj.TransportTax = txtTransportTax.Text.Trim();
            _obj.Cancellation = txtCancellation.Text.Trim();
            _obj.CancellationTax = txtCancellationTax.Text.Trim();
            _obj.CarPanalty = txtCarPanalty.Text.Trim();
            _obj.RecycleFee = txtRecycleFee.Text.Trim();
            _obj.OtherType = ddlOtherType.SelectedValue;
            _obj.OtherTypeAmt = txtOtherTypeAmt.Text.Trim();
            _obj.OtherTypeTax = txtOtherTypeTax.Text.Trim();
            _obj.OtherNType = ddlOtherNType.SelectedValue;
            _obj.OtherNTypeAmt = txtOtherNTypeAmt.Text.Trim();
            _obj.Total = txtTotalAmount.Text.Trim();
            _obj.Remarks = txtRemarks.Text.Trim();
            _obj.uid = uid;
            int result = _clsA.insertPushPrice(_obj);
            if (result != 0)
            {
                CommonFunction.MessageBox(this, "S", "Record updated successfully!!", "close");
            }
        }
    }
}