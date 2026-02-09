using COMMON;
using DAL.Reports;
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
    public partial class Shipped_Cars : System.Web.UI.Page
    {
        public CommonFunction cmf = new CommonFunction();
        Report report = new Report();
        DataSet ds = new DataSet();
        ShippedCars shippedCars = new ShippedCars();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetAllMasterData();
                btnDownload.Visible = false;
            }
        }

        public void GetAllMasterData()
        {
            try
            {
                ds = report.ShippedCarsMaster();
                if (ds.Tables["Table"].Rows.Count > 0)
                {
                    ddlShippingCompany.Items.Clear();
                    ddlShippingCompany.DataSource = ds.Tables["Table"];
                    ddlShippingCompany.DataTextField = "ShippingName";
                    ddlShippingCompany.DataValueField = "Id";
                    ddlShippingCompany.DataBind();
                    ddlShippingCompany.Items.Insert(0, new ListItem("Select Shipping Company", "0"));
                }
                if (ds.Tables["Table1"].Rows.Count > 0)
                {
                    ddlCountry.Items.Clear();
                    ddlCountry.DataSource = ds.Tables["Table1"];
                    ddlCountry.DataTextField = "CountryName";
                    ddlCountry.DataValueField = "Id";
                    ddlCountry.DataBind();
                    ddlCountry.Items.Insert(0, new ListItem("Select Country", "0"));
                }
                if (ds.Tables["Table2"].Rows.Count > 0)
                {
                    ddlClientName.Items.Clear();
                    ddlClientName.DataSource = ds.Tables["Table2"];
                    ddlClientName.DataTextField = "Fullname";
                    ddlClientName.DataValueField = "id";
                    ddlClientName.DataBind();
                    ddlClientName.Items.Insert(0, new ListItem("Select Client", "0"));
                }
                if (ds.Tables["Table3"].Rows.Count > 0)
                {
                    ddlPortName.Items.Clear();
                    ddlPortName.DataSource = ds.Tables["Table3"];
                    ddlPortName.DataTextField = "PortName";
                    ddlPortName.DataValueField = "ID";
                    ddlPortName.DataBind();
                    ddlPortName.Items.Insert(0, new ListItem("Select Port Name", "0"));
                }
                if (ds.Tables["Table4"].Rows.Count > 0)
                {
                    ddlShipName.Items.Clear();
                    ddlShipName.DataSource = ds.Tables["Table4"];
                    ddlShipName.DataTextField = "ShipName";
                    ddlShipName.DataValueField = "Id";
                    ddlShipName.DataBind();
                    ddlShipName.Items.Insert(0, new ListItem("Select Ship Name", "0"));
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
            GetAllShippedCars();
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["DataTable"];
            CreateExcelFile(dt);
        }

        public void GetAllShippedCars()
        {
            try
            {
                shippedCars.Shipping = ddlShippingCompany.SelectedValue;
                shippedCars.Country = ddlCountry.SelectedValue;
                shippedCars.ClientName = ddlClientName.SelectedValue;
                shippedCars.Port = ddlPortName.SelectedValue;
                shippedCars.ShipName = ddlShipName.SelectedValue;
                shippedCars.ChassisNo = txtChassis.Text.Trim();
                shippedCars.Surrender = ddlSurrender.SelectedValue;
                shippedCars.DateFrom = txtDateFrom.Text.Trim();
                shippedCars.DateTo = txtDateTo.Text.Trim();
                shippedCars.UID = Convert.ToInt32(Session["AID"]);
                int pageNo = 1;
                int pageSize = Convert.ToInt32(ddlSortBy.SelectedValue);

                ds = report.GetShippedCars(shippedCars, pageNo, pageSize);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.PageSize = int.Parse(ddlSortBy.SelectedValue);
                    GridView1.VirtualItemCount = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                    GridView1.DataSource = ds.Tables[0];
                    GridView1.DataBind();
                    ViewState["DataTable"] = ds.Tables[0];
                    btnDownload.Visible = true;
                }
                else
                {
                    GridView1.DataSource = ds.Tables[0];
                    GridView1.DataBind();
                    btnDownload.Visible = false;
                }

            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        public void GetAllShippedCars(int pageNo)
        {
            try
            {
                shippedCars.Shipping = ddlShippingCompany.SelectedValue;
                shippedCars.Country = ddlCountry.SelectedValue;
                shippedCars.ClientName = ddlClientName.SelectedValue;
                shippedCars.Port = ddlPortName.SelectedValue;
                shippedCars.ShipName = ddlShipName.SelectedValue;
                shippedCars.ChassisNo = txtChassis.Text.Trim();
                shippedCars.Surrender = ddlSurrender.SelectedValue;
                shippedCars.DateFrom = txtDateFrom.Text.Trim();
                shippedCars.DateTo = txtDateTo.Text.Trim();
                shippedCars.UID = Convert.ToInt32(Session["AID"]);
                int pageSize = Convert.ToInt32(ddlSortBy.SelectedValue);
                ds = report.GetShippedCars(shippedCars, pageNo, pageSize);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.PageSize = int.Parse(ddlSortBy.SelectedValue);
                    GridView1.VirtualItemCount = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                    GridView1.DataSource = ds.Tables[0];
                    GridView1.DataBind();
                    ViewState["DataTable"] = ds.Tables[0];
                    btnDownload.Visible = true;
                }
                else
                {
                    GridView1.DataSource = ds.Tables[0];
                    GridView1.DataBind();
                    btnDownload.Visible = false;
                }

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
                Response.AddHeader("content-disposition", string.Format("attachment; filename=ShippedCars-Report.xls"));
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
                CommonFunction.DisplayAlert(this, ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GetAllShippedCars(e.NewPageIndex + 1);
        }
    }
}