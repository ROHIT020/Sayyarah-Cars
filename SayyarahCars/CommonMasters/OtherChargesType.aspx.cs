using COMMON;
using DAL;
using ENTITY;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace SayyarahCars.CommonMasters
{
    public partial class OtherChargesType : System.Web.UI.Page
    {
        clsAdmin cls = new clsAdmin();
        entOtherTypeBuy obj = new entOtherTypeBuy();
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
                    bindAllOtherAuction();
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
                obj.Name = txtbuyingName.Text.Trim();
                if (cls.IsOtherAuctionExists(obj) == 1)
                {
                    cls.addOtherAuctionBuy(obj, Session["AID"].ToString());
                    CommonFunction.MessageBox(this, "S", "Record saved successfully!!", "AuctionBuyOtherType.aspx");
                }
                else
                {
                    CommonFunction.MessageBox(this, "E", "Already exists!!");
                }
                bindAllOtherAuction();
                txtbuyingName.Text = "";
                hdnId.Value = "";
                btnSubmit.Text = "Save";
            }
            else
            {
                obj.Id = Convert.ToInt32(hdnId.Value);
                obj.Name = txtbuyingName.Text.Trim();
                cls.updateOtherAuctionBuy(obj, Session["AID"].ToString());
                bindAllOtherAuction();
                txtbuyingName.Text = "";
                hdnId.Value = "";
                btnSubmit.Text = "Save";
                CommonFunction.MessageBox(this, "S", "Record Updated successfully!!","AuctionBuyOtherType.aspx");
            }
        }
        public void bindAllOtherAuction(int pageNo=1)
        {
            try
            {
                DataSet ds = cls.viewAllOtherAuctionBuy(); 
                if (ds!=null && ds.Tables[0].Rows.Count > 0)
                {
                    int pageSize = Convert.ToInt32(ddlpages.SelectedValue);
                    obj.PageNumber = pageNo.ToString();
                    obj.PageSize = pageSize.ToString();
                    GridView1.PageSize=Convert.ToInt32(ddlpages.SelectedValue);
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource =null;
                    GridView1.DataBind();
                }
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
                DataSet ds = cls.getAllOtherAuctionById(Id);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtbuyingName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    hdnId.Value = Id;
                    btnSubmit.Text = "Update";
                }
            }
            else if(e.CommandName == "DeleteRow")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                DeleteItem(id);                
            }
               }
        private void DeleteItem(int id)
        {
            try
            {
                obj.Id = id;
                obj.uid = Convert.ToInt32(uid);
                cls.deleteOtherAuction(obj);        
                bindAllOtherAuction();
                cmf.ClearAllControls(Page);
                CommonFunction.MessageBox(this, "S", "Record deleted successfully!!", "AuctionBuyOtherType.aspx");

            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void ddlpages_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindAllOtherAuction();
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            bindAllOtherAuction(e.NewPageIndex + 1);
        }
    }
}