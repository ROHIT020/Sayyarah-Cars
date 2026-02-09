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
    public partial class ManageAuctionYard : System.Web.UI.Page
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
                    BindGrid();
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
        private void BindGrid(int pageNo = 1)
        {
            try
            {
                int pageSize = Convert.ToInt32(ddlpages.SelectedValue);
                obj.PageNumber = pageNo.ToString();
                obj.PageSize = pageSize.ToString();
                DataSet ds = cls.SelectAuctionYard();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.PageSize = int.Parse(ddlpages.SelectedValue);
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
                string str = ex.Message;
            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "DeleteRow")
                {
                    int id = Convert.ToInt32(e.CommandArgument);
                    DeleteItem(id);
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }
        private void DeleteItem(int id)
        {
            try
            {
                obj.Id = id;
                obj.uid = Convert.ToInt32(uid);
                cls.DeleteAuctionYard(obj);
                CommonFunction.MessageBox(this, "S", "Record deleted successfully!!");
                BindGrid();
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGrid(e.NewPageIndex + 1);
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                int AuctioId = Convert.ToInt32(ddlAuction.SelectedValue);
                DataSet ds = cls.SelectAuctionYardAuctionById(AuctioId);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
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
            BindGrid();
        }

        protected void btnreload_Click(object sender, EventArgs e)
        {
            BindGrid();
        }
    }
}