using COMMON;
using DAL;
using ENTITY;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SayyarahCars.Admin
{
    public partial class Update_Inner : System.Web.UI.Page
    {
        public CommonFunction cmf = new CommonFunction();
        clsUpdateInner cls = new clsUpdateInner();
        public string uid = "0";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["AID"] != null)
                {
                    uid = Session["AID"].ToString();
                }
                if (!Page.IsPostBack)
                {
                    Divserver.Visible = false;
                    BindAllDropDown();

                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void BindProductDropDown(int productTypeId)
        {
            if (ddlproducttype.SelectedValue != "0")
            {
                DataSet ds = cls.GetProductNameByType(productTypeId);
                cmf.BindDropDownList(ddlproductname, ds, "Name", "Id");
                ddlproductname.Items.Insert(0, new ListItem("--Select Product Name--", "0"));
            }
            else
            {
                ddlproductname.Items.Clear();
                ddlproductname.Items.Insert(0, new ListItem("--Select Product Name--", "0"));
            }
        }
        public void BindAllDropDown()
        {
            try
            {
                DataSet ds = cls.AllUpdateDropdown();


                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ddlproducttype.DataSource = ds.Tables[0];
                    ddlproducttype.DataTextField = "CategoryName";
                    ddlproducttype.DataValueField = "ID";
                    ddlproducttype.DataBind();          

                }
                ddlproductname.Items.Clear();
                ddlproductname.Items.Insert(0, new ListItem("--Select Product Name--", "0"));


                if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                {
                    ddlclientname.DataSource = ds.Tables[1];
                    ddlclientname.DataTextField = "Name";
                    ddlclientname.DataValueField = "Id";
                    ddlclientname.DataBind();
                    ddlclientname.Items.Insert(0, new ListItem("--Select Client--", "0"));
                }


                if (ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
                {
                    ddlauctionhouse.DataSource = ds.Tables[2];
                    ddlauctionhouse.DataTextField = "Name";
                    ddlauctionhouse.DataValueField = "Id";
                    ddlauctionhouse.DataBind();
                    ddlauctionhouse.Items.Insert(0, new ListItem("--Select Auction--", "0"));
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }
        protected void ddlproducttype_SelectedIndexChanged(object sender, EventArgs e)
        {
            int productTypeId = ddlproducttype.SelectedValue != null ? Convert.ToInt32(ddlproducttype.SelectedValue) : 0;
            if (productTypeId > 0)
            {
                BindProductDropDown(productTypeId);
            }
            else
            {
                ddlproductname.Items.Clear();
                ddlproductname.Items.Insert(0, new ListItem("--Select Product Name--", "0"));
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        
        {
            BindData();
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
                    ds = cls.GetDataByChassisNo(founderMinus1);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ViewState["DataTable"] = ds.Tables[0];
                        GridView1.DataSource = ds.Tables[0];
                        GridView1.DataBind();
                        btnDownload.Visible = true;
                        Divserver.Visible = true;
                    }
                    else
                    {
                        Divserver.Visible = false;
                        GridView1.DataSource = ds.Tables[0];
                        GridView1.DataBind();
                        btnDownload.Visible = false;
                    }
                }
                else
                {
                    string pageSize = ddlsort.SelectedValue;                    
                    ds = cls.InsertUpdateData(ddlproducttype.SelectedValue, ddlproductname.SelectedValue, ddlclientname.SelectedValue, ddlauctionhouse.SelectedValue, txtauctiondate.Text, pageIndex.ToString(), pageSize);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ViewState["DataTable"] = ds.Tables[0];
                        GridView1.PageSize = int.Parse(ddlsort.SelectedValue);
                        GridView1.VirtualItemCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
                        GridView1.DataSource = ds.Tables[0];
                        GridView1.DataBind();
                        btnDownload.Visible = true;
                        Divserver.Visible = true;
                    }
                    else
                    {
                        Divserver.Visible = false;
                        GridView1.DataSource = ds.Tables[0];
                        GridView1.DataBind();
                        btnDownload.Visible = false;
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

        protected void btnDownload_Click(object sender, EventArgs e)
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
                Response.AddHeader("content-disposition", string.Format("attachment; filename=Update-r.xls"));
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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int i = 0;
            try
            {
                foreach (GridViewRow row in GridView1.Rows)
                {
                    CheckBox chk = row.FindControl("Chkbox") as CheckBox;
                    if (chk.Checked)
                    {
                        {
                            Label lblid = row.FindControl("lblpid") as Label;
                            TextBox txtiname = row.FindControl("txtiname") as TextBox;
                            TextBox txtiweight = row.FindControl("txtiweight") as TextBox;
                            TextBox txtiprice = row.FindControl("txtiprice") as TextBox;
                            int temp = cls.InsertInnerData(lblid.Text, txtiname.Text, txtiweight.Text, txtiprice.Text, uid, "Yes");
                            if (temp > 0)
                            {
                                i = i + 1;
                            }
                        }
                    }
                }
                if (i > 0)
                {
                    CommonFunction.MessageBox(this, "S", "Record Update successfully");
                    int currentPageIndex = GridView1.PageIndex + 1;
                    BindData(currentPageIndex);
                }
                else
                {
                    CommonFunction.MessageBox(this, "E", "Select atleast one record to update");
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
            try
            {
                GridView1.PageIndex = e.NewPageIndex;
                BindData(e.NewPageIndex + 1);
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }
    }
}