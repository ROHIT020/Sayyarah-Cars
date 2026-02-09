using COMMON;
using DAL.Reports;
using ENTITY.Model;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SayyarahCars.Admin
{
    public partial class Download_Shipping_Details : System.Web.UI.Page
    {
        public CommonFunction cmf = new CommonFunction();
        Report report = new Report();
        DataSet ds = new DataSet();
        DownloadShipping downloadShipping = new DownloadShipping();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetShippingMaster();
                btnDownload.Visible = false;
            }
        }

        public void GetShippingMaster()
        {
            try
            {
                ds = report.GetShippingMaster();
                if (ds.Tables["Table"].Rows.Count > 0)
                {
                    ddlCountryName.Items.Clear();
                    ddlCountryName.DataSource = ds.Tables["Table"];
                    ddlCountryName.DataTextField = "CountryName";
                    ddlCountryName.DataValueField = "Id";
                    ddlCountryName.DataBind();
                    ddlCountryName.Items.Insert(0, new ListItem("Select Country name", "0"));
                }

                if (ds.Tables["Table1"].Rows.Count > 0)
                {
                    ddlShippingCompany.Items.Clear();
                    ddlShippingCompany.DataSource = ds.Tables["Table1"];
                    ddlShippingCompany.DataTextField = "ShippingName";
                    ddlShippingCompany.DataValueField = "Id";
                    ddlShippingCompany.DataBind();
                    ddlShippingCompany.Items.Insert(0, new ListItem("Select Shipping company", "0"));
                }

                if (ds.Tables["Table2"].Rows.Count > 0)
                {
                    ddlClientName.Items.Clear();
                    ddlClientName.DataSource = ds.Tables["Table2"];
                    ddlClientName.DataTextField = "FullName";
                    ddlClientName.DataValueField = "id";
                    ddlClientName.DataBind();
                    ddlClientName.Items.Insert(0, new ListItem("Select Client name", "0"));
                }

                if (ds.Tables["Table3"].Rows.Count > 0)
                {
                    ddlPortName.Items.Clear();
                    ddlPortName.DataSource = ds.Tables["Table3"];
                    ddlPortName.DataTextField = "PortName";
                    ddlPortName.DataValueField = "ID";
                    ddlPortName.DataBind();
                    ddlPortName.Items.Insert(0, new ListItem("Select port name", "0"));
                }

                if (ds.Tables["Table4"].Rows.Count > 0)
                {
                    ddlShipName.Items.Clear();
                    ddlShipName.DataSource = ds.Tables["Table4"];
                    ddlShipName.DataTextField = "ShipName";
                    ddlShipName.DataValueField = "Id";
                    ddlShipName.DataBind();
                    ddlShipName.Items.Insert(0, new ListItem("Select ship name", "0"));
                }

                if (ds.Tables["Table5"].Rows.Count > 0)
                {
                    ddlBroker.Items.Clear();
                    ddlBroker.DataSource = ds.Tables["Table5"];
                    ddlBroker.DataTextField = "BName";
                    ddlBroker.DataValueField = "Id";
                    ddlBroker.DataBind();
                    ddlBroker.Items.Insert(0, new ListItem("Select broker name", "0"));
                }

                if (ds.Tables["Table6"].Rows.Count > 0)
                {
                    ddlCarStatus.Items.Clear();
                    ddlCarStatus.DataSource = ds.Tables["Table6"];
                    ddlCarStatus.DataTextField = "CarStatus";
                    ddlCarStatus.DataValueField = "Id";
                    ddlCarStatus.DataBind();
                    ddlCarStatus.Items.Insert(0, new ListItem("Select car status", "0"));
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        public void GetAllDownloadShipData()
        {
            try
            {
                downloadShipping.Country = ddlCountryName.SelectedValue;
                downloadShipping.ShippingCmpny = ddlShippingCompany.SelectedValue;
                downloadShipping.Client = ddlClientName.SelectedValue;
                downloadShipping.PortName = ddlPortName.SelectedValue;
                downloadShipping.ShipName = ddlShipName.SelectedValue;
                downloadShipping.Chassis = txtChassis.Text.Trim();
                downloadShipping.Surrender = ddlSurrender.SelectedValue;
                downloadShipping.Broker = ddlBroker.SelectedValue;
                downloadShipping.DateFrom = txtDateFrom.Text.Trim();
                downloadShipping.DateTo = txtDateTo.Text.Trim();
                downloadShipping.CarStatus = ddlCarStatus.SelectedValue;
                downloadShipping.UID = Convert.ToInt32(Session["UID"]);
                int pageNo = 1;
                int pageSize = Convert.ToInt32(ddlSortBy.SelectedValue);
                if (ddlProductIn.SelectedValue == "0")
                {
                    ds = report.GetAllDownloadShiping(downloadShipping, pageNo, pageSize);
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
                else if (ddlProductIn.SelectedValue == "1")
                {
                    ds = report.GetAllDownloadShipingYes(downloadShipping, pageNo, pageSize);
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
                else
                {
                    ds = report.GetAllDownloadShipingNo(downloadShipping, pageNo, pageSize);
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


            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        public void GetAllDownloadShipData(int pageNo)
        {
            try
            {
                downloadShipping.Country = ddlCountryName.SelectedValue;
                downloadShipping.ShippingCmpny = ddlShippingCompany.SelectedValue;
                downloadShipping.Client = ddlClientName.SelectedValue;
                downloadShipping.PortName = ddlPortName.SelectedValue;
                downloadShipping.ShipName = ddlShipName.SelectedValue;
                downloadShipping.Chassis = txtChassis.Text.Trim();
                downloadShipping.Surrender = ddlSurrender.SelectedValue;
                downloadShipping.Broker = ddlBroker.SelectedValue;
                downloadShipping.DateFrom = txtDateFrom.Text.Trim();
                downloadShipping.DateTo = txtDateTo.Text.Trim();
                downloadShipping.CarStatus = ddlCarStatus.SelectedValue;
                downloadShipping.UID = Convert.ToInt32(Session["UID"]);
                int pageSize = Convert.ToInt32(ddlSortBy.SelectedValue);
                if (ddlProductIn.SelectedValue == "0")
                {
                    ds = report.GetAllDownloadShiping(downloadShipping, pageNo, pageSize);
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
                else if (ddlProductIn.SelectedValue == "1")
                {
                    ds = report.GetAllDownloadShipingYes(downloadShipping, pageNo, pageSize);
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
                else
                {
                    ds = report.GetAllDownloadShipingNo(downloadShipping, pageNo, pageSize);
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
                

            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            GetAllDownloadShipData();
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["DataTable"];
            CreateExcelFile(dt);
        }

        public void CreateExcelFile(DataTable Excel)
        {
            try
            {
                Response.ClearContent();
                Response.AddHeader("content-disposition", string.Format("attachment; filename=Download-Shipping-Report.xls"));
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
            GetAllDownloadShipData(e.NewPageIndex + 1);
        }
    }
}