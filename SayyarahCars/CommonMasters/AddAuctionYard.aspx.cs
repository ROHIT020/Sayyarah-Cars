using COMMON;
using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SayyarahCars.CommonMasters
{
    public partial class AddAuctionYard : System.Web.UI.Page
    {
        public CommonFunction cmf = new CommonFunction();
        clsMasters cls = new clsMasters();
        entAuctionYard obj = new entAuctionYard();
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
                    BindAuction();
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
        protected void BindAuction()
        {
            DataSet ds = cls.AuctionBind();
            cmf.BindDropDownList(ddlAuction, ds, "Name", "Id");
            ListItem li = new ListItem("--Select Auction--", "0");
            ddlAuction.Items.Insert(0, li);
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (btnSubmit.Text != "Update")
            {
                obj.AuctionId = Convert.ToInt32(ddlAuction.SelectedValue);
                obj.AuctionYard = txtAuctionYard.Text.Trim();
                obj.LotNoFrom = txtlotNoFrom.Text.Trim();
                obj.LotNoTo = txtlotNoTo.Text.Trim();
                obj.OutDay = txtoutday.Text.Trim();
                obj.OutTime = txtouttime.Text.Trim();
                obj.Address = txtaddress.Text.Trim();
                obj.EmailId = txtemail.Text.Trim();
                obj.ContactNo = txtcontact.Text.Trim();
                obj.FaxNo = txtfaxno.Text.Trim();
                obj.uid = Convert.ToInt32(uid);
                if (rdoactive.Checked)
                {
                    obj.Archive = false;
                }
                else
                {
                    obj.Archive = true;
                }
                int result = cls.InsertAuctionYard(obj);
                if (result != 0)
                {
                    CommonFunction.MessageBox(this, "S", "Record saved successfully!!");
                    cmf.ClearAllControls(Page);
                }
            }
            else
            {
                obj.Id = Convert.ToInt32(cmf.Decrypt(Request.QueryString["id"].ToString()));
                obj.AuctionId = Convert.ToInt32(ddlAuction.SelectedValue);
                obj.AuctionYard = txtAuctionYard.Text.Trim();
                obj.LotNoFrom = txtlotNoFrom.Text.Trim();
                obj.LotNoTo = txtlotNoTo.Text.Trim();
                obj.OutDay = txtoutday.Text.Trim();
                obj.OutTime = txtouttime.Text.Trim();
                obj.Address = txtaddress.Text.Trim();
                obj.EmailId = txtemail.Text.Trim();
                obj.ContactNo = txtcontact.Text.Trim();
                obj.FaxNo = txtfaxno.Text.Trim();
                obj.uid = Convert.ToInt32(uid);
                if (rdoactive.Checked)
                {
                    obj.Archive = false;
                }
                else
                {
                    obj.Archive = true;
                }
                int result = cls.updateAuctionYard(obj);
                if (result != 0)
                {
                    CommonFunction.MessageBox(this, "S", "Record updated successfully!!");
                    cmf.ClearAllControls(Page);
                    btnSubmit.Text = "Submit";
                }
            }
        }

        protected void binddata()
        {
            obj.Id = Convert.ToInt32(cmf.Decrypt(Request.QueryString["id"].ToString()));
            DataSet ds = cls.SelectAuctionYardById(obj);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlAuction.SelectedValue = ds.Tables[0].Rows[0]["AuctionId"].ToString();
                txtAuctionYard.Text = ds.Tables[0].Rows[0]["AuctionYard"].ToString();
                txtlotNoFrom.Text = ds.Tables[0].Rows[0]["LotNoFrom"].ToString();
                txtlotNoTo.Text = ds.Tables[0].Rows[0]["LotNoTo"].ToString();
                txtoutday.Text = ds.Tables[0].Rows[0]["OutDay"].ToString();
                txtouttime.Text = ds.Tables[0].Rows[0]["OutTime"].ToString();
                txtaddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                txtaddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                txtemail.Text = ds.Tables[0].Rows[0]["EmailId"].ToString();
                txtcontact.Text = ds.Tables[0].Rows[0]["ContactNo"].ToString();
                txtfaxno.Text = ds.Tables[0].Rows[0]["FaxNo"].ToString();
                string status = ds.Tables[0].Rows[0]["Archive"].ToString();
                if (status == "True")
                {
                    rdoactive.Checked = false;
                    rdodeActive.Checked = true;
                }
                else
                {
                    rdoactive.Checked = true;
                    rdodeActive.Checked = false;
                }
                btnSubmit.Text = "Update";
            }
        }
    }
}