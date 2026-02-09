using COMMON;
using DAL;
using ENTITY;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Reports;


namespace SayyarahCars.Admin
{
    public partial class Document_All_Reports : System.Web.UI.Page
    {
        public CommonFunction cmf = new CommonFunction();
        DataSet ds = new DataSet();
        clsOtherReport clsOtherReport = new clsOtherReport();
        DocumentAllReport documentAllReport = new DocumentAllReport();
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
                ds = clsOtherReport.GetDocumentMasterData();
                if (ds.Tables["Table"].Rows.Count > 0)
                {
                    ddlAuctionName.Items.Clear();
                    ddlAuctionName.DataSource = ds.Tables["Table"];
                    ddlAuctionName.DataTextField = "Name";
                    ddlAuctionName.DataValueField = "Id";
                    ddlAuctionName.DataBind();
                    ddlAuctionName.Items.Insert(0, new ListItem("Select auction name", "0"));
                }
                if (ds.Tables["Table1"].Rows.Count > 0)
                {
                    ddlPortFrom.Items.Clear();
                    ddlPortFrom.DataSource = ds.Tables["Table1"];
                    ddlPortFrom.DataTextField = "PortName";
                    ddlPortFrom.DataValueField = "ID";
                    ddlPortFrom.DataBind();
                    ddlPortFrom.Items.Insert(0, new ListItem("Select port name", "0"));
                }
                if (ds.Tables["Table2"].Rows.Count > 0)
                {
                    ddlSoldCountry.Items.Clear();
                    ddlSoldCountry.DataSource = ds.Tables["Table2"];
                    ddlSoldCountry.DataTextField = "CountryName";
                    ddlSoldCountry.DataValueField = "Id";
                    ddlSoldCountry.DataBind();
                    ddlSoldCountry.Items.Insert(0, new ListItem("Select country name", "0"));
                }
                if (ds.Tables["Table3"].Rows.Count > 0)
                {
                    ddlTransport.Items.Clear();
                    ddlTransport.DataSource = ds.Tables["Table3"];
                    ddlTransport.DataTextField = "TransportName";
                    ddlTransport.DataValueField = "Id";
                    ddlTransport.DataBind();
                    ddlTransport.Items.Insert(0, new ListItem("Select transport name", "0"));
                }
                if (ds.Tables["Table4"].Rows.Count > 0)
                {
                    ddlCarStatus.Items.Clear();
                    ddlCarStatus.DataSource = ds.Tables["Table4"];
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

        public void GetDocumentAlldata()
        {
            try
            {
                string ChasisNo = "";
                string AllChasisNo = txtallchno.Text;
                if (AllChasisNo != "")
                {
                    ChasisNo = AllChasisNo.Remove(AllChasisNo.Length - 1, 1);
                    ds = clsOtherReport.DocumentAllTransportByChasisNo(ChasisNo);
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
                    documentAllReport.AuctionFDate = txtAuctionDateFrom.Text.Trim();    
                    documentAllReport.AuctionTDate = txtAuctionDateTo.Text.Trim();      
                    documentAllReport.AuctionName = ddlAuctionName.SelectedValue;       
                    documentAllReport.PortFrom = ddlPortFrom.SelectedValue;             
                    documentAllReport.RikujiDate = txtRikujiDate.Text.Trim();           
                    documentAllReport.SoldCountry = ddlSoldCountry.SelectedValue;       
                    documentAllReport.Transport = ddlTransport.SelectedValue;           
                    documentAllReport.NoPlate = ddlNoPlate.SelectedValue;               
                    documentAllReport.Urgent = ddlUrgent.SelectedValue;                 
                    documentAllReport.InvoiceType = ddlInvoiceType.SelectedValue;       
                    documentAllReport.Reauction = ddlReauction.SelectedValue;           
                    documentAllReport.CarStatus = ddlCarStatus.SelectedValue;           
                    documentAllReport.SortBy = ddlSortBy.SelectedValue;                 
                    int pageNo = 1;
                    int pageSize = Convert.ToInt32(ddlSortBy.SelectedValue);
                    GridView1.PageSize = pageSize;
                    string pagesize = ddlSortBy.SelectedValue;
                    ds = clsOtherReport.GetDocumentAllTransport(documentAllReport, pageNo.ToString(), pagesize);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        GridView1.PageSize = int.Parse(ddlSortBy.SelectedValue);
                        GridView1.VirtualItemCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
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

        public void GetDocumentAlldata(int pageNo)
        {
            try
            {
                string ChasisNo = "";
                string AllChasisNo = txtallchno.Text;
                if (AllChasisNo != "")
                {
                    ChasisNo = AllChasisNo.Remove(AllChasisNo.Length - 1, 1);
                    ds = clsOtherReport.DocumentAllTransportByChasisNo(ChasisNo);
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
                    documentAllReport.AuctionFDate = txtAuctionDateFrom.Text.Trim();
                    documentAllReport.AuctionTDate = txtAuctionDateTo.Text.Trim();
                    documentAllReport.AuctionName = ddlAuctionName.SelectedValue;
                    documentAllReport.PortFrom = ddlPortFrom.SelectedValue;
                    documentAllReport.RikujiDate = txtRikujiDate.Text.Trim();
                    documentAllReport.SoldCountry = ddlSoldCountry.SelectedValue;
                    documentAllReport.Transport = ddlTransport.SelectedValue;
                    documentAllReport.NoPlate = ddlNoPlate.SelectedValue;
                    documentAllReport.Urgent = ddlUrgent.SelectedValue;
                    documentAllReport.InvoiceType = ddlInvoiceType.SelectedValue;
                    documentAllReport.Reauction = ddlReauction.SelectedValue;
                    documentAllReport.CarStatus = ddlCarStatus.SelectedValue;
                    documentAllReport.SortBy = ddlSortBy.SelectedValue;
                    int pageSize = Convert.ToInt32(ddlSortBy.SelectedValue);
                    GridView1.PageSize = pageSize;
                    string pagesize = ddlSortBy.SelectedValue;
                    ds = clsOtherReport.GetDocumentAllTransport(documentAllReport, pageNo.ToString(), pagesize);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        GridView1.PageSize = int.Parse(ddlSortBy.SelectedValue);
                        GridView1.VirtualItemCount = Convert.ToInt32(ds.Tables[0].Rows[1][0]);
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
            GetDocumentAlldata();
        }

        

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["DataTable"];
            CreateExcelFile(dt);
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GetDocumentAlldata(e.NewPageIndex + 1);
        }

        public void CreateExcelFile(DataTable Excel)
        {
            try
            {
                Response.ClearContent();
                Response.AddHeader("content-disposition", string.Format("attachment; filename=Document-All-Report.xls"));
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