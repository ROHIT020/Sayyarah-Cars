using COMMON;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SayyarahCars.Admin
{
    public partial class Auction_Report : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        CommonFunction cmf = new CommonFunction();
        clsAdmin cls = new clsAdmin();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDown();
            }
        }

        public void BindDropDown()
        {
            try
            {
                ds = cls.GetDropDownAuctionReport();

                cmf.BindDropDownList(ddlAuctionG, ds, "Name", "id", 0);
                ddlAuctionG.Items.Insert(0, new ListItem("Select Auction Group", "0"));

                cmf.BindDropDownList(ddlAuctionH, ds, "Name", "Id", 1);
                ddlAuctionH.Items.Insert(0, new ListItem("Select Auction House", "0"));

            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }


        }

        public void GetDropDownByID()
        {
            DataSet DS = new DataSet();
            try
            {
                ddlAuctionH.Items.Clear();

                DS = cls.GetDropDownByID(ddlAuctionG.SelectedValue);

                cmf.BindDropDownList(ddlAuctionH, DS, "Name", "Id", 0);
                ddlAuctionH.Items.Insert(0, new ListItem("Select Auction House", "0"));
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }

        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindAllData();
        }

        public void BindAllData()
        {
            try
            {
                ds = cls.GetAllAuctionReport();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = ds.Tables[0];
                    GridView1.DataBind();

                }


            }
            catch(Exception ex)
            {
                string s = ex.Message;
            }
        }
        protected void ddlAuctionG_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetDropDownByID();
        }


        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GetDropDownByID();
        }
    }
}