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
    public partial class Document_Confirmation : System.Web.UI.Page
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
                throw ex;
            }
        }

        public void BindAllDropDown()
        {
            try
            {
                DataSet ds = clsA.AllDropDownMaster();

                cmf.BindDropDownList(ddlShippingC, ds, "ShippingName", "Id", 6);
                ddlShippingC.Items.Insert(0, new ListItem("--Select Shipping--", "0"));

                cmf.BindDropDownList(ddlPortName, ds, "PortName", "Id", 4);
                ddlPortName.Items.Insert(0, new ListItem("--Select Port Name--", "0"));

                cmf.BindDropDownList(ddlShipName, ds, "ShipName", "Id", 2);
                ddlShipName.Items.Insert(0, new ListItem("--Select ShipName--", "0"));

                cmf.BindDropDownList(ddlcustomer, ds, "ClientName", "Id", 3);
                ddlcustomer.Items.Insert(0, new ListItem("--Select Client Name--", "0"));

                cmf.BindDropDownList(ddlScountry, ds, "CountryName", "Id", 5);
                ddlScountry.Items.Insert(0, new ListItem("--Select Country--", "0"));

                cmf.BindDropDownList(ddltransport, ds, "TransportName", "Id", 7);
                ddltransport.Items.Insert(0, new ListItem("--Select Transport Name--", "0"));

                cmf.BindDropDownList(ddlCarStatus, ds, "CarStatus", "Id", 8);
                ddlCarStatus.Items.Insert(0, new ListItem("--Select CarStatus--", "0"));

            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
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
                    ds = clsA.GetDConfirmationByChas(founderMinus1);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ViewState["DataTable"] = ds.Tables[0];
                        GridView1.DataSource = ds.Tables[0];
                        GridView1.DataBind();
                        Divserver.Visible = true;
                    }
                    else
                    {
                        Divserver.Visible = false;
                        GridView1.DataSource = ds.Tables[0];
                        GridView1.DataBind();
                    }
                }
                else
                {
                    DocumentConfirmation obj = new DocumentConfirmation();
                    obj.ShippingId = ddlShippingC.SelectedValue;
                    obj.PortId = ddlPortName.SelectedValue;
                    obj.ShipNameId = ddlShipName.SelectedValue;
                    obj.Loading = ddlloading.SelectedValue;
                    obj.Urgent = ddlurgent.SelectedValue;
                    obj.CustomerId = ddlcustomer.SelectedValue;
                    obj.ProductIndate = txtPInDate.Text;
                    obj.RikujiDate = txtRikuji.Text;
                    obj.SoldCountry = ddlScountry.SelectedValue;
                    obj.ProductType = ddlInvoicetype.SelectedValue;
                    obj.FDate = txtdateFrom.Text;
                    obj.TDate = txtDateto.Text;
                    obj.TransportId = ddltransport.SelectedValue;
                    obj.CarStatus = ddlCarStatus.SelectedValue;
                    obj.PageIndex = pageIndex.ToString();
                    obj.PageSize = ddlshortby.SelectedValue;
                    ds = clsA.GetAllDConfirmation(obj);
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

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindData(e.NewPageIndex + 1);
        }

        protected void lockship_Click(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                foreach (GridViewRow row in GridView1.Rows)
                {
                    CheckBox chk = row.FindControl("Chkbox") as CheckBox;
                    if (chk.Checked)
                    {
                        Label lblid = row.FindControl("lblpid") as Label;
                        Label lblslock = row.FindControl("lblslock") as Label;
                        Label lbluid = row.FindControl("lbluid") as Label;
                        if (lblslock.Text.Trim() == "0")
                        {
                            int temp = clsA.Shiplock(lblid.Text, uid);
                            if (temp > 0)
                            {
                                i = i + 1;
                            }
                        }

                    }
                }
                if (i > 0)
                {
                    CommonFunction.MessageBox(this, "S", "Ship Lock successfully");
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
                Response.AddHeader("content-disposition", string.Format("attachment; filename=Document-Confirmation.xls"));
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