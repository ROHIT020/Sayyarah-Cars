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
    public partial class Unsold_Ship_Car : System.Web.UI.Page
    {
        CommonFunction cmf = new CommonFunction();
        clsAdmin cls = new clsAdmin();
        public string uid = "0";
        entUnsoldShipCar obj = new entUnsoldShipCar();

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
                    //Divserver.Visible = false;
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
                DataSet ds = cls.GetAllUnsoldShipDDL();
                cmf.BindDropDownList(ddlShipComp, ds, "ShippingCompany", "Id", 0);
                ddlShipComp.Items.Insert(0, new ListItem("--Select Shipping--", "0"));

                cmf.BindDropDownList(ddlCountry, ds, "CountryName", "Id", 1);
                ddlCountry.Items.Insert(0, new ListItem("--Select Country--", "0"));
                    
                cmf.BindDropDownList(ddlClient, ds, "ClientName", "id", 2);
                ddlClient.Items.Insert(0, new ListItem("--Select Client--", "0"));

                cmf.BindDropDownList(ddlPort, ds, "PortName", "Id", 3);
                ddlPort.Items.Insert(0, new ListItem("--Select Port--", "0"));

                cmf.BindDropDownList(ddlShipName, ds, "ShipName", "Id", 4);
                ddlShipName.Items.Insert(0, new ListItem("--Select ShipName--", "0"));
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
        protected void BindData(int PageIndex = 1)
        {
            try
            {
                DataSet ds = new DataSet();  
                obj.ShippingId = ddlShipComp.SelectedValue;
                obj.CountryId = ddlCountry.SelectedValue;
                obj.ClientId = ddlClient.SelectedValue;
                obj.PortId = ddlPort.SelectedValue;
                obj.ShipId = ddlShipName.SelectedValue;
                obj.ChassisNo = txtChassisNo.Text.Trim();
                obj.DateFrom = txtDateF.Text.Trim();
                obj.DateTo = txtDateTo.Text.Trim();
                obj.SurrenderId = ddlSurrender.SelectedValue;                
                obj.PageIndex = PageIndex.ToString();
                obj.PageSize = ddlsortby.SelectedValue;
                ds = cls.GetAllUnsoldShipCar(obj);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ViewState["DataTable"] = ds.Tables[0];
                    GridView1.PageSize = int.Parse(ddlsortby.SelectedValue);
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
            catch(Exception ex)
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
                Response.AddHeader("content-disposition", string.Format("attachment; filename=Unsold-Ship-Car.xls"));
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