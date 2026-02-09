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
    public partial class Purchase_Report : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        CommonFunction cmf = new CommonFunction();
        clsAdmin cls = new clsAdmin();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDown();
                //txtFromDate.Text = DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd");
                //txToDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        public void BindDropDown()
        {
            try
            {

                ds = cls.GetDropDownPurchaseReport();
                cmf.BindDropDownList(ddlShippingCom, ds, "ShippingName", "ID", 0);
                ddlShippingCom.Items.Insert(0, new ListItem("Select Shipping Company", "0"));

                cmf.BindDropDownList(ddlAyctionH, ds, "Name", "id", 1);
                ddlAyctionH.Items.Insert(0, new ListItem("Select Auction House", "0"));

            }
            catch (Exception ex)
            {
                string s = ex.Message;

            }
        }

        public void BindAllData()
        {
            try
            {
                PurchaseReport obj = new PurchaseReport();
                obj.ShipingID = ddlShippingCom.SelectedValue;
                obj.AuctionID = ddlAyctionH.SelectedValue;
                obj.ChassisNo = txtChassisNo.Text;
                obj.FromDate = txtFromDate.Text;
                obj.ToDate = txToDate.Text;

                ds = cls.GetAllPurchaseReport(obj);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ViewState["DataTable"] = ds.Tables[0];
                    GridView1.PageSize = int.Parse(ddlPageSize.SelectedValue);
                    GridView1.DataSource = ds.Tables[0];
                    GridView1.DataBind();
                    Divb.Visible = true;
                }
                else
                {
                    GridView1.DataSource = ds.Tables[0];
                    GridView1.DataBind();
                    Divb.Visible = false;
                }

            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            BindAllData();
        }

        protected void btnDowExel_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["DataTable"];
            CreateExcelFile(dt);
        }


        public void CreateExcelFile(DataTable Excel)
        {
            try
            {
                Response.ClearContent();
                Response.AddHeader("content-disposition", string.Format("attachment; filename=Purchase-Report.xls"));
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

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindAllData();
        }
    }
}