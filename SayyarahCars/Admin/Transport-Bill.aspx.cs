using COMMON;
using DAL;
using ENTITY.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SayyarahCars.Admin
{
    public partial class Transport_Bill : System.Web.UI.Page
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

                ds = cls.GetDropDownTransportBill();

                cmf.BindDropDownList(ddlCategory, ds, "Name", "ID", 0);
                ddlCategory.Items.Insert(0, new ListItem("Select Category", "0"));

                cmf.BindDropDownList(ddlProduct, ds, "Name", "ID", 1);
                ddlProduct.Items.Insert(0, new ListItem("Select Product", "0"));

                cmf.BindDropDownList(ddlAuctionH, ds, "Name", "ID", 2);
                ddlAuctionH.Items.Insert(0, new ListItem("Select Auction", "0"));

                cmf.BindDropDownList(ddlTransport, ds, "Name", "Id", 3);
                ddlTransport.Items.Insert(0, new ListItem("Select Transport", "0"));
            }

            catch (Exception ex)
            {
                string s = ex.Message;
            }

        }

        public void BindProducByID()
        {
            try
            {

                ds = cls.GetDropDownTransportBillByID(ddlCategory.SelectedValue);

                cmf.BindDropDownList(ddlProduct, ds, "Name", "ID");
                ddlProduct.Items.Insert(0, new ListItem("Select Product", "0"));
            }

            catch (Exception ex)
            {
                string s = ex.Message;
            }
        }

        public void BindAllData(int PageIndex=1)
        {
            try
            {
                DataSet DS = new DataSet();
                string FounderMinus1 = "";
                string Founder = txtAllChassisNo.Text;
                if (Founder != "")
                {
                    FounderMinus1 = Founder.Remove(Founder.Length - 1, 1);
                    DS = cls.GetTransportBillByChassisNo(FounderMinus1);
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
                    
                    GetTransportBill TransportBill = new GetTransportBill();
                    TransportBill.CategoryID = ddlCategory.SelectedValue;
                    TransportBill.ProductID = ddlProduct.SelectedValue;
                    TransportBill.AuctionID = ddlAuctionH.SelectedValue;
                    TransportBill.TransportID = ddlTransport.SelectedValue;
                    TransportBill.TransportDate = txttransport.Text;
                    TransportBill.Pageindex = PageIndex.ToString();
                    TransportBill.Pagesize = ddlPageSize.SelectedValue;             
                    ds = cls.GetAllTransportBill(TransportBill);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ViewState["DataTable"] = ds.Tables[0];
                        GridView1.PageSize = int.Parse(ddlPageSize.SelectedValue);
                        GridView1.VirtualItemCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
                        GridView1.DataSource = ds.Tables[0];
                        GridView1.DataBind();
                        Divb.Visible = true;

                    }
                    else
                    {
                        Divb.Visible = false;
                        GridView1.DataSource = ds.Tables[0];
                        GridView1.DataBind();
                        CommonFunction.MessageBox(this, "E", "No Record Found");
                    }
                }
            }
            catch(Exception ex)
            {
                string S = ex.Message;
            }


            }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            BindAllData();
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindProducByID();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindAllData(e.NewPageIndex + 1);
        }


        protected void UpdateTranportBill_Click(object sender, EventArgs e)
        {
            int i = 0;
            try
            {
                foreach (GridViewRow row in GridView1.Rows)
                {
                    CheckBox chk = row.FindControl("Chkbox") as CheckBox;
                    if (chk.Checked)
                    {
                        Label lblPID = row.FindControl("lblID") as Label;
                        Label lblTID = row.FindControl("lblTID") as Label;
                        TextBox txttrcharges = row.FindControl("txttrcharges") as TextBox;
                        TextBox txtothercharges = row.FindControl("txtothercharges") as TextBox;
                        TextBox txttdiscount = row.FindControl("txttdiscount") as TextBox;
                        TextBox txtexamount = row.FindControl("txtexamount") as TextBox;
                        TextBox txtremark = row.FindControl("txtremark") as TextBox;

                        TransportBill BillData = new TransportBill();

                        BillData.PID = lblPID.Text;
                        BillData.TID = lblTID.Text;
                        BillData.Tcharges = txttrcharges.Text;
                        BillData.Extracharges = txtothercharges.Text;
                        BillData.Tamount = txttdiscount.Text;
                        BillData.Extraamt = txtexamount.Text;
                        BillData.Remark = txtremark.Text;
                        BillData.UID = Session["AID"].ToString();
                        BillData.DOE = txtDate.Text;
                        int temp = cls.AddTransportBill(BillData);
                        if (temp > 0)
                        {
                            i = i + 1;
                        }
                    }


                }
                if (i > 0)
                {
                    BindAllData();
                    CommonFunction.MessageBox(this, "S", "Record update successfully");
                }


            }
            catch (Exception ex)
            {
                string S = ex.Message;
            }
        }
    }
}