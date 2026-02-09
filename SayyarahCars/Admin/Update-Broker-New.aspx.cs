using DAL;
using System;
using COMMON;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENTITY;
using ENTITY.Model;

namespace SayyarahCars.Admin
{
    public partial class Update_Broker_New : System.Web.UI.Page
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

                ds = cls.GetDropDownUpdateBrokerNew();

                cmf.BindDropDownList(ddlCategory, ds, "CategoryName", "ID", 0);
                ddlCategory.Items.Insert(0, new ListItem("Select Category", "0"));

                cmf.BindDropDownList(ddlProduct, ds, "ProductName", "ID", 1);
                ddlProduct.Items.Insert(0, new ListItem("Select Product", "0"));

                cmf.BindDropDownList(ddlClient, ds, "ClientName", "ID", 2);
                ddlClient.Items.Insert(0, new ListItem("Select Client", "0"));

                cmf.BindDropDownList(ddlShip, ds, "ShipName", "ID", 3);
                ddlShip.Items.Insert(0, new ListItem("Select Ship", "0"));

                cmf.BindDropDownList(ddlAuctionH, ds, "Name", "ID", 4);
                ddlAuctionH.Items.Insert(0, new ListItem("Select Auction", "0"));

                cmf.BindDropDownList(ddlbrokerName, ds, "Bname", "ID", 5);
                ddlbrokerName.Items.Insert(0, new ListItem("Select Broker", "0"));

            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
        }

        public void Binddata(int PageI = 1)
        {
            try
            {
                DataSet DS = new DataSet();
                string FounderMinus1 = "";
                string Founder = txtAllChassisNo.Text;
                if (Founder != "")
                {
                    FounderMinus1 = Founder.Remove(Founder.Length - 1, 1);
                    DS = cls.GetUpdateBrokerNewByChassisNo(FounderMinus1);
                    if (DS.Tables[0].Rows.Count > 0)
                    {
                        GridView1.DataSource = DS.Tables[0];
                        GridView1.DataBind();
                        Divb.Visible = true;
                    }
                    else
                    {
                        Divb.Visible = false;
                        GridView1.DataSource = DS.Tables[0];
                        GridView1.DataBind();
                        CommonFunction.MessageBox(this, "E", "No record found");
                    }

                }

                else
                {

                    string PageIndex = PageI.ToString();

                    UpdateBrokerNew obj = new UpdateBrokerNew();
                    obj.CategoryID = ddlCategory.SelectedValue;
                    obj.ProductID = ddlProduct.SelectedValue;
                    obj.ClientID = ddlClient.SelectedValue;
                    obj.ShipID = ddlShip.SelectedValue;
                    obj.AuctionID = ddlAuctionH.SelectedValue;
                    obj.AuctionDate = txtADate.Text;
                    obj.PageIndex = PageIndex;
                    obj.PageSize = ddlPageSize.SelectedValue;

                    DS = cls.GetAllUpdateBrokerNew(obj);
                    if (DS.Tables[0].Rows.Count > 0)
                    {
                        GridView1.DataSource = DS.Tables[0];
                        GridView1.PageSize = int.Parse(ddlPageSize.SelectedValue);
                        GridView1.VirtualItemCount = Convert.ToInt32(DS.Tables[1].Rows[0][0]);
                        GridView1.DataBind();
                        Divb.Visible = true;
                    }
                    else
                    {
                        GridView1.DataSource = DS.Tables[0];
                        GridView1.DataBind();
                        Divb.Visible = false;
                        CommonFunction.MessageBox(this, "E", "Not Record Found");
                    }
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message;

            }

        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Binddata();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            Binddata(e.NewPageIndex + 1);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int i = 0;
            try
            {
                foreach (GridViewRow row in GridView1.Rows)
                {
                    CheckBox chk = row.FindControl("Chkbox") as CheckBox;
                    if (chk.Checked)
                    {
                        string upby = "E";
                        Label lblid = row.FindControl("lblID") as Label;
                        UpdateBrokerNewDetails obj = new UpdateBrokerNewDetails();
                        obj.Productid = lblid.Text;
                        obj.BrokerID = ddlbrokerName.SelectedValue;
                        obj.UPBY = upby;
                        obj.UID = Session["AID"].ToString();
                        
                        int temp = cls.UpdateBrokerNewLog(obj);
                        if (temp > 0)
                        {
                            i = i + 1;
                        }

                    }
                }
                if (i > 0)
                {

                    CommonFunction.MessageBox(this, "S", "Data Updated Successfully");
                    Binddata();
                }
                else
                {
                    CommonFunction.MessageBox(this, "E", "Select at least one record to update");
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
        }
    }
}