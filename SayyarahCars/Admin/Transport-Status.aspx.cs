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
using DAL.Reports;

namespace SayyarahCars.Admin
{
    public partial class Transport_Status : System.Web.UI.Page
    {
        public CommonFunction cmf = new CommonFunction();
        clsOtherReport clsOtherReport = new clsOtherReport();
        DataSet ds = new DataSet();
        //clsAdmin clsAdmin = new clsAdmin();
        TransportStatus transportStatus = new TransportStatus();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetmasterData();
                btnDownload.Visible = false;
            }
        }

        public void GetmasterData()
        {
            try
            {
                ds = clsOtherReport.GettransPortStatusMasterData();
                if (ds.Tables["Table"].Rows.Count > 0)
                {
                    ddlShippingCompany.Items.Clear();
                    ddlShippingCompany.DataSource = ds.Tables["Table"];
                    ddlShippingCompany.DataTextField = "ShippingName";
                    ddlShippingCompany.DataValueField = "Id";
                    ddlShippingCompany.DataBind();
                    ddlShippingCompany.Items.Insert(0, new ListItem("Select shipping company", "0"));
                }
                if (ds.Tables["Table1"].Rows.Count > 0)
                {
                    ddlPortName.Items.Clear();
                    ddlPortName.DataSource = ds.Tables["Table1"];
                    ddlPortName.DataTextField = "PortName";
                    ddlPortName.DataValueField = "ID";
                    ddlPortName.DataBind();
                    ddlPortName.Items.Insert(0, new ListItem("Select port name", "0"));
                }
                if (ds.Tables["Table2"].Rows.Count > 0)
                {
                    ddlShipName.Items.Clear();
                    ddlShipName.DataSource = ds.Tables["Table2"];
                    ddlShipName.DataTextField = "ShipName";
                    ddlShipName.DataValueField = "Id";
                    ddlShipName.DataBind();
                    ddlShipName.Items.Insert(0, new ListItem("Select ship name", "0"));
                }
                if (ds.Tables["Table3"].Rows.Count > 0)
                {
                    ddlCustomerName.Items.Clear();
                    ddlCustomerName.DataSource = ds.Tables["Table3"];
                    ddlCustomerName.DataTextField = "FullName";
                    ddlCustomerName.DataValueField = "id";
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
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            GetAlltransportStatus();
        }

        public void GetAlltransportStatus()
        {
            try
            {
                string ChasisNo = "";
                string AllChasisNo = txtallchno.Text;
                if (AllChasisNo != "")
                {
                    ChasisNo = AllChasisNo.Remove(AllChasisNo.Length - 1, 1);
                    ds = clsOtherReport.GetAllTransportStatusByChasisNo(ChasisNo);
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
                    transportStatus.ShippingCompany = ddlShippingCompany.SelectedValue;
                    transportStatus.PortName = ddlPortName.SelectedValue;
                    transportStatus.ShipName = ddlShipName.SelectedValue;
                    transportStatus.Loading = ddlLoading.SelectedValue;
                    transportStatus.Urgent = ddlUrgent.SelectedValue;
                    transportStatus.CustomerName = ddlCustomerName.SelectedValue;
                    transportStatus.ProductInDate = txtProductInDate.Text.Trim();
                    transportStatus.ProductInStatus = ddlProductInStatus.SelectedValue;
                    transportStatus.RikujiDate = txtRikujiDate.Text.Trim();
                    transportStatus.SoldCountry = ddlSoldCountry.SelectedValue;
                    transportStatus.DocumentsStatus = ddlDocumentsStatus.SelectedValue;
                    transportStatus.UID = Convert.ToInt32(Session["AID"]);
                    int pageNo = 1;
                    int pageSize = Convert.ToInt32(ddlSortBy.SelectedValue);
                    GridView1.PageSize = pageSize;
                    ds = clsOtherReport.GetAlltranspoortStatus(transportStatus, pageNo, pageSize);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ViewState["DataTable"] = ds.Tables[0];
                        GridView1.PageSize = Convert.ToInt32(ddlSortBy.SelectedValue);
                        GridView1.VirtualItemCount = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
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

        public void GetAlltransportStatus(int pageNo)
        {
            try
            {
                string ChasisNo = "";
                string AllChasisNo = txtallchno.Text;
                if (AllChasisNo != "")
                {
                    ChasisNo = AllChasisNo.Remove(AllChasisNo.Length - 1, 1);
                    ds = clsOtherReport.GetAllTransportStatusByChasisNo(ChasisNo);
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
                    transportStatus.ShippingCompany = ddlShippingCompany.SelectedValue;
                    transportStatus.PortName = ddlPortName.SelectedValue;
                    transportStatus.ShipName = ddlShipName.SelectedValue;
                    transportStatus.Loading = ddlLoading.SelectedValue;
                    transportStatus.Urgent = ddlUrgent.SelectedValue;
                    transportStatus.CustomerName = ddlCustomerName.SelectedValue;
                    transportStatus.ProductInDate = txtProductInDate.Text.Trim();
                    transportStatus.ProductInStatus = ddlProductInStatus.SelectedValue;
                    transportStatus.RikujiDate = txtRikujiDate.Text.Trim();
                    transportStatus.SoldCountry = ddlSoldCountry.SelectedValue;
                    transportStatus.DocumentsStatus = ddlDocumentsStatus.SelectedValue;
                    transportStatus.UID = Convert.ToInt32(Session["AID"]);
                    int pageSize = Convert.ToInt32(ddlSortBy.SelectedValue);
                    GridView1.PageSize = pageSize;
                    ds = clsOtherReport.GetAlltranspoortStatus(transportStatus, pageNo, pageSize);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ViewState["DataTable"] = ds.Tables[0];
                        GridView1.PageSize = Convert.ToInt32(ddlSortBy.SelectedValue);
                        GridView1.VirtualItemCount = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
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

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["DataTable"];
            CreateExcelFile(dt);
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GetAlltransportStatus(e.NewPageIndex + 1);
        }
    }
}