using COMMON;
using DAL.Reports;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENTITY.Model;

namespace SayyarahCars.Admin
{
    public partial class Ship_Confirmation_Report : System.Web.UI.Page
    {
        public CommonFunction cmf = new CommonFunction();
        DataSet ds = new DataSet();
        clsOtherReport clsOtherReport = new clsOtherReport();
        ShipConfirmationReport shipConfirmationReport = new ShipConfirmationReport();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GeAllMasterData();
            }
        }

        public void GeAllMasterData()
        {
            try
            {
                ds = clsOtherReport.GetDocConformationRpt();
                if (ds.Tables["Table"].Rows.Count > 0)
                {
                    ddlShippingCompany.Items.Clear();
                    ddlShippingCompany.DataSource = ds.Tables["Table"];
                    ddlShippingCompany.DataTextField = "ShippingName";
                    ddlShippingCompany.DataValueField = "Id";
                    ddlShippingCompany.DataBind();
                    ddlShippingCompany.Items.Insert(0, new ListItem("Select Shipping company", "0"));
                }
                if (ds.Tables["Table1"].Rows.Count > 0)
                {
                    ddlPortName.Items.Clear();
                    ddlPortName.DataSource = ds.Tables["Table1"];
                    ddlPortName.DataTextField = "PortName";
                    ddlPortName.DataValueField = "Id";
                    ddlPortName.DataBind();
                    ddlPortName.Items.Insert(0, new ListItem("Select port name", "0"));
                }
                if (ds.Tables["Table2"].Rows.Count > 0)
                {
                    ddlShipName.Items.Clear();
                    ddlShipName.DataSource = ds.Tables["Table2"];
                    ddlShipName.DataTextField = "";
                    ddlShipName.DataValueField = "";
                    ddlShipName.DataBind();
                    ddlShipName.Items.Insert(0, new ListItem("Select ship name", "0"));
                }
                if (ds.Tables["Table3"].Rows.Count > 0)
                {
                    ddlCustomerName.Items.Clear();
                    ddlCustomerName.DataSource = ds.Tables["Table3"];
                    ddlCustomerName.DataTextField = "FullName";
                    ddlCustomerName.DataValueField = "Id";
                    ddlCustomerName.DataBind();
                    ddlCustomerName.Items.Insert(0, new ListItem("Select customer name", "0"));
                }
                if (ds.Tables["Table4"].Rows.Count > 0)
                {
                    ddlSoldCountry.Items.Clear();
                    ddlSoldCountry.DataSource = ds.Tables["Table4"];
                    ddlSoldCountry.DataTextField = "CountryName";
                    ddlSoldCountry.DataValueField = "Id";
                    ddlSoldCountry.DataBind();
                    ddlSoldCountry.Items.Insert(0, new ListItem("Select country name", "0"));
                }
                if (ds.Tables["Table5"].Rows.Count > 0)
                {
                    ddlCarStatus.Items.Clear();
                    ddlCarStatus.DataSource = ds.Tables["Table5"];
                    ddlCarStatus.DataTextField = "CarStatus";
                    ddlCarStatus.DataValueField = "Id";
                    ddlCarStatus.DataBind();
                    ddlCarStatus.Items.Insert(0, new ListItem("Select car status", "0"));
                }
                if (ds.Tables["Table6"].Rows.Count > 0)
                {
                    ddlTransport.Items.Clear();
                    ddlTransport.DataSource = ds.Tables["Table6"];
                    ddlTransport.DataTextField = "TransportName";
                    ddlTransport.DataValueField = "Id";
                    ddlTransport.DataBind();
                    ddlTransport.Items.Insert(0, new ListItem("Select transport name", "0"));
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
            GetAllDocReportData();
        }

        public void GetAllDocReportData()
        {
            try
            {
                string ChasisNo = "";
                string AllChasisNo = txtallchno.Text;
                if (AllChasisNo != "")
                {
                    ChasisNo = AllChasisNo.Remove(AllChasisNo.Length - 1, 1);
                    ds = clsOtherReport.DocumentConfirmationByChasisNo(ChasisNo);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ViewState["DataTable"] = ds.Tables[0];
                        GridView1.DataSource = ds.Tables[0];
                        GridView1.DataBind();
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
                    shipConfirmationReport.ShippingCompany = ddlShippingCompany.SelectedValue;
                    shipConfirmationReport.PortName = ddlPortName.SelectedValue;
                    shipConfirmationReport.ShipName = ddlShipName.SelectedValue;
                    shipConfirmationReport.Loading = ddlLoading.SelectedValue;
                    shipConfirmationReport.Urgent = ddlUrgent.SelectedValue;
                    shipConfirmationReport.CustomerName = ddlCustomerName.SelectedValue;
                    shipConfirmationReport.ProductInDate = txtProductInDate.Text.Trim();
                    shipConfirmationReport.ProductInStatus = ddlProductInStatus.SelectedValue;
                    shipConfirmationReport.Orderby = ddlOrderby.SelectedValue;
                    shipConfirmationReport.RikujiDate = txtRikujiDate.Text.Trim();
                    shipConfirmationReport.SoldCountry = ddlSoldCountry.Text.Trim();
                    shipConfirmationReport.InvoiceType = ddlInvoiceType.Text.Trim();
                    shipConfirmationReport.DocumentsStatus = ddlDocumentsStatus.SelectedValue;
                    shipConfirmationReport.Datefrom = txtDatefrom.Text.Trim();
                    shipConfirmationReport.DateTo = txtDateTo.Text.Trim();
                    shipConfirmationReport.Transport = ddlTransport.SelectedValue;
                    shipConfirmationReport.CarStatus = ddlCarStatus.SelectedValue;
                    int pageNo = 1;
                    int pageSize = Convert.ToInt32(ddlSortBy.SelectedValue);
                    GridView1.PageSize = pageSize;
                    ds = clsOtherReport.GetDocAllCofrnReport(shipConfirmationReport, pageNo, pageSize);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ViewState["DataTable"] = ds.Tables[0];
                        GridView1.PageSize = Convert.ToInt32(ddlSortBy.SelectedValue);
                        GridView1.VirtualItemCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
                        GridView1.DataSource = ds.Tables[0];
                        GridView1.DataBind();
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

        public void GetAllDocReportData(int pageNo)
        {
            try
            {
                string ChasisNo = "";
                string AllChasisNo = txtallchno.Text;
                if (AllChasisNo != "")
                {
                    ChasisNo = AllChasisNo.Remove(AllChasisNo.Length - 1, 1);
                    ds = clsOtherReport.DocumentConfirmationByChasisNo(ChasisNo);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ViewState["DataTable"] = ds.Tables[0];
                        GridView1.DataSource = ds.Tables[0];
                        GridView1.DataBind();
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
                    shipConfirmationReport.ShippingCompany = ddlShippingCompany.SelectedValue;
                    shipConfirmationReport.PortName = ddlPortName.SelectedValue;
                    shipConfirmationReport.ShipName = ddlShipName.SelectedValue;
                    shipConfirmationReport.Loading = ddlLoading.SelectedValue;
                    shipConfirmationReport.Urgent = ddlUrgent.SelectedValue;
                    shipConfirmationReport.CustomerName = ddlCustomerName.SelectedValue;
                    shipConfirmationReport.ProductInDate = txtProductInDate.Text.Trim();
                    shipConfirmationReport.ProductInStatus = ddlProductInStatus.SelectedValue;
                    shipConfirmationReport.Orderby = ddlOrderby.SelectedValue;
                    shipConfirmationReport.RikujiDate = txtRikujiDate.Text.Trim();
                    shipConfirmationReport.SoldCountry = ddlSoldCountry.Text.Trim();
                    shipConfirmationReport.InvoiceType = ddlInvoiceType.Text.Trim();
                    shipConfirmationReport.DocumentsStatus = ddlDocumentsStatus.SelectedValue;
                    shipConfirmationReport.Datefrom = txtDatefrom.Text.Trim();
                    shipConfirmationReport.DateTo = txtDateTo.Text.Trim();
                    shipConfirmationReport.Transport = ddlTransport.SelectedValue;
                    shipConfirmationReport.CarStatus = ddlCarStatus.SelectedValue;
                    int pageSize = Convert.ToInt32(ddlSortBy.SelectedValue);
                    GridView1.PageSize = pageSize;
                    ds = clsOtherReport.GetDocAllCofrnReport(shipConfirmationReport, pageNo, pageSize);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ViewState["DataTable"] = ds.Tables[0];
                        GridView1.PageSize = Convert.ToInt32(ddlSortBy.SelectedValue);
                        GridView1.VirtualItemCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
                        GridView1.DataSource = ds.Tables[0];
                        GridView1.DataBind();
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

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GetAllDocReportData(e.NewPageIndex + 1);
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
                Response.AddHeader("content-disposition", string.Format("attachment; filename=Transport-Status.xls"));
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
    }
}