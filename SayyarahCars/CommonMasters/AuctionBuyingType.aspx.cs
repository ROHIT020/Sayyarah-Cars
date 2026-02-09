using COMMON;
using DAL;
using ENTITY;
using System;
using System.Data;

namespace SayyarahCars.CommonMasters
{
    public partial class AuctionBuyingType : System.Web.UI.Page
    {
        clsAdmin cls = new clsAdmin();
        entAuctionBuying entBuy = new entAuctionBuying();
        public CommonFunction cmf = new CommonFunction();
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
                    bindAllAuction();

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
                entBuy.Name = txtbuyingName.Text.Trim();

                if (cls.IsBuyingExists(entBuy) == 1)
                {
                    cls.AddAuctionBuy(entBuy, Session["AID"].ToString());
                    CommonFunction.MessageBox(this, "S", "Record saved successfully!!");
                }
                else
                {
                    CommonFunction.MessageBox(this, "E", "Already exists!!");
                }
                bindAllAuction();
                cmf.ClearAllControls(Page);
                btnSubmit.Text = "Save";

            }
            else
            {
                entBuy.Id = Convert.ToInt32(hdnId.Value);
                entBuy.Name = txtbuyingName.Text.Trim();
                cls.UpdateAuctionBuy(entBuy, Session["AID"].ToString());
                CommonFunction.MessageBox(this, "S", "Record updated successfully!!");
                bindAllAuction();
                cmf.ClearAllControls(Page);
                btnSubmit.Text = "Save";
            }
        }
        protected void GridView1_RowCommand1(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditRow")
            {
                string Id = e.CommandArgument.ToString();
                DataSet ds = cls.GetBuyingById(Id);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtbuyingName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    hdnId.Value = Id;
                    btnSubmit.Text = "Update";
                }
            }
            else if (e.CommandName == "DeleteRow")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                DeleteItem(id);
            }
        }
        private void DeleteItem(int id)
        {
            try
            {
                entBuy.Id = id;
                entBuy.uid = Convert.ToInt32(uid);
                cls.DeleteAuctionBuying(entBuy);
                CommonFunction.MessageBox(this, "S", "Record deleted successfully!!");
                bindAllAuction();
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        public void bindAllAuction(int pageNo = 1)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = cls.ViewAllBuying();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    int pageSize = Convert.ToInt32(ddlpages.SelectedValue);
                    entBuy.PageNumber = pageNo.ToString();
                    entBuy.PageSize = pageSize.ToString();
                    GridView1.PageSize = Convert.ToInt32(ddlpages.SelectedValue);
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }
        protected void ddlpages_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindAllAuction();
        }
        protected void GridView1_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            bindAllAuction(e.NewPageIndex + 1);
        }
    }
}