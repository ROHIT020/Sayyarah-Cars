using COMMON;
using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SayyarahCars.Admin
{
    public partial class UploadDocument : System.Web.UI.Page
    {
        public CommonFunction cmf = new CommonFunction();
        clsUploadDocument cls = new clsUploadDocument();
        entUploadDocument obj = new entUploadDocument();
        public string uid = "0";
        public string ImagePath = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["AID"] != null)
                {
                    uid = Session["AID"].ToString();
                }
                if (!Page.IsPostBack)
                {
                    bindDocumentDDL();
                }
            }
            catch (Exception ex)
            {
                CommonFunction.DisplayAlert(this, ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }
        protected void bindDocumentDDL()
        {
            DataSet ds = cls.DocumentBind();
            cmf.BindDropDownList(ddldocument, ds, "documentName", "documentId");
            ListItem li = new ListItem("--Select Document--", "0");
            ddldocument.Items.Insert(0, li);
        }
        protected void bindAuctionDDL()
        {
            DataSet ds = cls.AuctionBind();
            cmf.BindDropDownList(ddlauction, ds, "auctionName", "auctionId");
            ListItem li = new ListItem("--Select Auction House--", "0");
            ddlauction.Items.Insert(0, li);
        }
        protected void bindShippingDDL()
        {
            DataSet ds = cls.ShippingBind();
            cmf.BindDropDownList(ddlshipping, ds, "shippingName", "shippingId");
            ListItem li = new ListItem("--Select Shipping House--", "0");
            ddlshipping.Items.Insert(0, li);
        }
        protected void bindTransportDDL()
        {
            DataSet ds = cls.TransportBind();
            cmf.BindDropDownList(ddltransport, ds, "transportName", "transportId");
            ListItem li = new ListItem("--Select Transport House--", "0");
            ddltransport.Items.Insert(0, li);
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string fileurl = ViewState["imgurl"]?.ToString() ?? "";
                if (docFile.HasFile)
                {
                    fileurl = FileUploadUtility.UploadFile(docFile, "Document", "ClientDocsPath", out string msg);
                    if (fileurl == string.Empty)
                    {
                        return;
                    }
                }
                obj.billDate = txtbilldate.Text.Trim();
                obj.billTypeId = Convert.ToInt32(ddldocument.SelectedValue);
                obj.uploadDocument = fileurl;
                obj.uid = Convert.ToInt32(uid);
                switch (ddldocument.SelectedValue)
                {
                    case "1":
                        obj.selectBillTypeId = Convert.ToInt32(ddlauction.SelectedValue);
                        break;
                    case "2":
                        obj.selectBillTypeId = Convert.ToInt32(ddlshipping.SelectedValue);
                        break;
                    case "3":
                        obj.selectBillTypeId = Convert.ToInt32(ddltransport.SelectedValue);
                        break;
                }
                cls.InsertBillData(obj);
                CommonFunction.MessageBox(this, "S", "Record saved successfully!!", "close");
                cmf.ClearAllControls(Page);
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }
        protected void ddldocument_SelectedIndexChanged(object sender, EventArgs e)
        {

            DivAuction.Visible = false;
            DivShipping.Visible = false;
            DivTransport.Visible = false;
            switch (ddldocument.SelectedValue)
            {
                case "1":
                    bindAuctionDDL();
                    DivAuction.Visible = true;
                    break;
                case "2":
                    bindShippingDDL();
                    DivShipping.Visible = true;
                    break;
                case "3":
                    bindTransportDDL();
                    DivTransport.Visible = true;
                    break;
            }
        }
    }
}