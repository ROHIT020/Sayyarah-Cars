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

namespace SayyarahCars.Admin
{
    public partial class Update_Another_Status : System.Web.UI.Page
    {
        CommonFunction cmf = new CommonFunction();
        clsAdmin clsA = new clsAdmin();
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
                    BindAllDropDown();
                    Divserver.Visible = false;
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }
        public void BindAllDropDown()
        {
            try
            {
                DataSet ds = clsA.AllDropDownMaster();

                cmf.BindDropDownList(ddlCategory, ds, "CategoryName", "ID", 0);

                cmf.BindDropDownList(ddlAuctionhouse, ds, "Name", "Id", 1);
                ddlAuctionhouse.Items.Insert(0, new ListItem("--Select Auction--", "0"));

                cmf.BindDropDownList(ddlshipping, ds, "ShipName", "Id", 2);
                ddlshipping.Items.Insert(0, new ListItem("--Select Shipping--", "0"));

                cmf.BindDropDownList(ddlPortFrom, ds, "PortName", "Id", 4);
                ddlPortFrom.Items.Insert(0, new ListItem("--Select Port From--", "0"));

                cmf.BindDropDownList(ddlSCountry, ds, "CountryName", "Id", 5);
                ddlSCountry.Items.Insert(0, new ListItem("--Select Country--", "0"));

            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }
        public void BindProductDropDown()
        {
            if (ddlCategory.SelectedValue != "0")
            {
                DataSet ds = clsA.GetProductByCategory(Convert.ToInt32(ddlCategory.SelectedValue));

                cmf.BindDropDownList(ddlProduct, ds, "Name", "Id");
                ddlProduct.Items.Insert(0, new ListItem("--Select Product--", "0"));

            }
            else
            {
                ddlProduct.Items.Clear();
                ddlProduct.Items.Insert(0, new ListItem("--Select Product--", "0"));
            }
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindProductDropDown();
        }

        public void BindData(int pageIndex = 1)
        {
            try
            {
                DataSet ds = new DataSet();
                string founderMinus1 = "";
                string founder = txtAllChassisNo.Text;
                if (founder != "")
                {
                    founderMinus1 = founder.Remove(founder.Length - 1, 1);
                    ds = clsA.GetAnotherStatusByChassis(founderMinus1);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ViewState["DataTable"] = ds.Tables[0];
                        GridView1.DataSource = ds.Tables[0];
                        GridView1.DataBind();
                        Divserver.Visible = true;
                    }
                    else
                    {

                        GridView1.DataSource = ds.Tables[0];
                        GridView1.DataBind();
                    }
                }
                else
                {
                    UpdateAnotherStatus obj = new UpdateAnotherStatus();
                    obj.CategoryId = ddlCategory.SelectedValue;
                    obj.ProductId = ddlProduct.SelectedValue;
                    obj.AuctionId = ddlAuctionhouse.SelectedValue;
                    obj.ShippingId = ddlshipping.SelectedValue;
                    obj.PortFromId = ddlPortFrom.SelectedValue;
                    obj.SoldCountryId = ddlSCountry.SelectedValue;
                    obj.Urgent = ddlurgent.SelectedValue;
                    obj.Adate = txtADate.Text;
                    obj.RDate = txtRikujiDate.Text;
                    obj.DRDate = txtDRdate.Text;      
                    obj.RegisDate = txtRegisDate.Text;
                    obj.PageIndex = pageIndex.ToString();
                    obj.PageSize = ddlshortby.SelectedValue;
                    ds = clsA.GetAllAnotherStatus(obj);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ViewState["DataTable"] = ds.Tables[0];
                        GridView1.PageSize = int.Parse(ddlshortby.SelectedValue);
                        GridView1.VirtualItemCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
                        GridView1.DataSource = ds.Tables[0];
                        GridView1.DataBind();
                        Divserver.Visible = true;
                    }
                    else
                    {
                        Divserver.Visible = false;
                        GridView1.DataSource = ds.Tables[0];
                        GridView1.DataBind();
                        CommonFunction.MessageBox(this, "E", "No record found");
                    }
                }
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
            BindData(e.NewPageIndex + 1);
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void UpdateDRDate_Click(object sender, EventArgs e)
        {
            int i = 0;
            try
            {
                foreach (GridViewRow row in GridView1.Rows)
                {
                    CheckBox chk = row.FindControl("Chkbox") as CheckBox;
                    if (chk.Checked)
                    {
                        Label lblid = row.FindControl("lblpid") as Label;
                        int temp = clsA.UpdateDocReceiveDate(lblid.Text, txtDocReceived.Text, txtDRRemark.Text, Session["AID"].ToString());
                        if (temp > 0)
                        {
                            i = i + 1;
                        }
                    }
                }
                if (i > 0)
                {
                    CommonFunction.MessageBox(this, "S","Doc Receive Update successfully");
                    BindData();
                }
                else
                {
                    CommonFunction.MessageBox(this, "E", "Select atleast one record to update");
                    BindData();
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void UpdateDSDate_Click(object sender, EventArgs e)
        {
            int i = 0;
            try
            {
                foreach (GridViewRow row in GridView1.Rows)
                {
                    CheckBox chk = row.FindControl("Chkbox") as CheckBox;
                    if (chk.Checked)
                    {
                        Label lblid = row.FindControl("lblpid") as Label;
                        Label lblDsdate = row.FindControl("lblDsdate") as Label;
                        if (lblDsdate.Text == "")
                        {
                            int temp = clsA.UpdateDocSendDate(lblid.Text, txtDocSend.Text, txtDSendRemark.Text, Session["AID"].ToString());
                            if (temp > 0)
                            {
                                i = i + 1;
                            }
                        }
                        else
                        {
                            CommonFunction.MessageBox(this, "W", "You cannot update document send date of this product"); 
                        }
                    }
                }
                if (i > 0)
                {
                    CommonFunction.MessageBox(this, "S", "Doc Send Update successfully");
                    BindData();
                }
                else
                {
                    CommonFunction.MessageBox(this, "E", "Select atleast one record to update");
                    BindData();
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)ViewState["DataTable"];
                CreateExcelFile(dt);
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        public void CreateExcelFile(DataTable Excel)
        {
            try
            {
                Response.ClearContent();
                Response.AddHeader("content-disposition", string.Format("attachment; filename=Update-Another-Status.xls"));
                Response.ContentEncoding = System.Text.Encoding.Unicode;
                Response.ContentType = "application/ms-excel";
                Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
                string space = "";
                foreach (DataColumn dcolumn in Excel.Columns)
                {
                    Response.Write(space + dcolumn.ColumnName);
                    space = "\t";
                }
                Response.Write("\n");
                int countcolumn;
                foreach (DataRow dr in Excel.Rows)
                {
                    space = "";
                    for (countcolumn = 0; countcolumn < Excel.Columns.Count; countcolumn++)
                    {
                        Response.Write(space + dr[countcolumn].ToString().Trim());
                        space = "\t";
                    }
                    Response.Write("\n");
                }
                HttpContext.Current.Response.End();
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }
    }
}