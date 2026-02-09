using COMMON;
using DAL;
using ENTITY;
using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;

namespace SayyarahCars.Admin
{
    public partial class Update_Push_Price : System.Web.UI.Page
    {
        CommonFunction cmf = new CommonFunction();
        clsMasters _cls = new clsMasters();
        clsAdmin _clsA = new clsAdmin();
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
                    Divserver.Visible = false;
                    BindMasters();
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }
        protected void BindMasters()
        {
            ListItem li = new ListItem("Select", "0");
            DataSet ds = _cls.SelectAuctionBuyType();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ViewState["ABFType"] = ds.Tables[0];
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                ViewState["OtherType"] = ds.Tables[1];
            }
            ds = _cls.SelectAuction();
            cmf.BindDropDownList(ddlAuctionHouse, ds, "Name", "id", 0);
            ddlAuctionHouse.Items.Insert(0, li);
            cmf.BindDropDownList(ddlAuctionSource, ds, "Name", "id", 0);
            ddlAuctionSource.Items.Insert(0, li);
            ds = _cls.AuctionGroupBind();
            cmf.BindDropDownList(ddlAuctionGroup, ds, "Name", "id", 0);
            ddlAuctionGroup.Items.Insert(0, li);
        }

        protected void BindData(int pageIndex = 1)
        {
            DataSet ds = new DataSet();
            string founderMinus1 = "";
            string founder = txtAllChassisNo.Text;
            if (founder != "")
            {
                founderMinus1 = founder.Remove(founder.Length - 1, 1);
                ds = _clsA.SelectPushPriceByChassisNo(founderMinus1);
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
                entSearchPushPrice _ent = new entSearchPushPrice();
                _ent.GID = ddlAuctionGroup.SelectedValue;
                _ent.AID = ddlAuctionHouse.SelectedValue;
                _ent.SAID = ddlAuctionSource.SelectedValue;
                _ent.Adate = txtAdate.Text;
                _ent.PageIndex = pageIndex.ToString();
                _ent.PageSize = ddlPageSize.SelectedValue;
                ds = _clsA.SearchPushPrice(_ent);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ViewState["DataTable"] = ds.Tables[0];
                    GridView1.PageSize = int.Parse(ddlPageSize.SelectedValue);
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
        public void CreateExcelFile(DataTable Excel)
        {
            try
            {
                Response.ClearContent();
                Response.AddHeader("content-disposition", string.Format("attachment; filename=Push-price.xls"));
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
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            BindData();
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

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    Label PPType = (Label)e.Row.FindControl("PPType");
                    Label ABFType = (Label)e.Row.FindControl("ABFType");
                    Label OtherType = (Label)e.Row.FindControl("OtherType");
                    Label OtherNType = (Label)e.Row.FindControl("OtherNType");
                    DropDownList ddlPPType = (DropDownList)e.Row.FindControl("ddlPPType");
                    DropDownList ddlABFType = (DropDownList)e.Row.FindControl("ddlABFType");
                    DropDownList ddlOtherType = (DropDownList)e.Row.FindControl("ddlOtherType");
                    DropDownList ddlOtherNType = (DropDownList)e.Row.FindControl("ddlOtherNType");

                    ddlPPType.SelectedValue = PPType.Text;

                    DataTable dt = (DataTable)ViewState["ABFType"];
                    cmf.BindDropDownList(ddlABFType, dt, "Name", "id");
                    ListItem li = new ListItem("Select", "0");
                    ddlABFType.Items.Insert(0, li);
                    if (Convert.ToInt32(ABFType.Text) > 0)
                    {
                        ddlABFType.SelectedValue = ABFType.Text;
                    }

                    dt = (DataTable)ViewState["OtherType"];
                    cmf.BindDropDownList(ddlOtherType, dt, "Name", "id");
                    ddlOtherType.Items.Insert(0, li);
                    if (Convert.ToInt32(OtherType.Text) > 0)
                    {
                        ddlOtherType.SelectedValue = OtherType.Text;
                    }

                    cmf.BindDropDownList(ddlOtherNType, dt, "Name", "id");
                    ddlOtherNType.Items.Insert(0, li);
                    if (Convert.ToInt32(OtherNType.Text) > 0)
                    {
                        ddlOtherNType.SelectedValue = OtherNType.Text;
                    }
                }
                catch (Exception ex)
                {
                    CommonFunction.MessageBox(this, "E", ex.Message);
                    ExceptionLogging.SendErrorToText(ex);
                }
            }
        }
        protected void btnUpdatePrice_Click(object sender, EventArgs e)
        {
            int i = 0;
            try
            {
                foreach (GridViewRow row in GridView1.Rows)
                {
                    CheckBox chk = row.FindControl("Chkbox") as CheckBox;
                    if (chk.Checked)
                    {
                        Label lblpid = row.FindControl("lblpid") as Label;
                        Label lblaid = row.FindControl("lblaid") as Label;
                        DropDownList ddlctype = row.FindControl("ddlctype") as DropDownList;
                        DropDownList ddlPPType = row.FindControl("ddlPPType") as DropDownList;
                        TextBox txtPushPrice = row.FindControl("txtPushPrice") as TextBox;
                        TextBox txtPushPriceTax = row.FindControl("txtPushPriceTax") as TextBox;
                        DropDownList ddlABFType = row.FindControl("ddlABFType") as DropDownList;
                        TextBox txtAuctionFeed = row.FindControl("txtAuctionFeed") as TextBox;
                        TextBox txtAuctionFeedTax = row.FindControl("txtAuctionFeedTax") as TextBox;
                        TextBox txtNoPlate = row.FindControl("txtNoPlate") as TextBox;
                        TextBox txtNoPlateTax = row.FindControl("txtNoPlateTax") as TextBox;
                        TextBox txtNoPlateNTax = row.FindControl("txtNoPlateNTax") as TextBox;
                        TextBox txtSecurity = row.FindControl("txtSecurity") as TextBox;
                        TextBox txtSecurityTax = row.FindControl("txtSecurityTax") as TextBox;
                        TextBox txtSecurityNTax = row.FindControl("txtSecurityNTax") as TextBox;
                        TextBox txtTransport = row.FindControl("txtTransport") as TextBox;
                        TextBox txtTransportTax = row.FindControl("txtTransportTax") as TextBox;
                        TextBox txtCancellation = row.FindControl("txtCancellation") as TextBox;
                        TextBox txtCancellationTax = row.FindControl("txtCancellationTax") as TextBox;
                        TextBox txtCarPanalty = row.FindControl("txtCarPanalty") as TextBox;
                        TextBox txtRecycleFee = row.FindControl("txtRecycleFee") as TextBox;
                        DropDownList ddlOtherType = row.FindControl("ddlOtherType") as DropDownList;
                        TextBox txtOtherTypeAmt = row.FindControl("txtOtherTypeAmt") as TextBox;
                        TextBox txtOtherTypeTax = row.FindControl("txtOtherTypeTax") as TextBox;
                        DropDownList ddlOtherNType = row.FindControl("ddlOtherNType") as DropDownList;
                        TextBox txtOtherNTypeAmt = row.FindControl("txtOtherNTypeAmt") as TextBox;
                        TextBox txtTotalAmount = row.FindControl("txtTotalAmount") as TextBox;
                        TextBox txtRemarks = row.FindControl("txtRemarks") as TextBox;


                        entPushPrice _obj = new entPushPrice();
                        _obj.PID = lblpid.Text;
                        _obj.CurrencyType = ddlctype.SelectedValue;
                        _obj.PPType = ddlPPType.SelectedValue;
                        _obj.PushPrice = txtPushPrice.Text.Trim();
                        _obj.PushPriceTax = txtPushPriceTax.Text.Trim();
                        _obj.ABFType = ddlABFType.SelectedValue;
                        _obj.AuctionFeed = txtAuctionFeed.Text.Trim();
                        _obj.AuctionFeedTax = txtAuctionFeedTax.Text.Trim();
                        _obj.NoPlate = txtNoPlate.Text.Trim();
                        _obj.NoPlateTax = txtNoPlateTax.Text.Trim();
                        _obj.NoPlateNTax = txtNoPlateNTax.Text.Trim();
                        _obj.Security = txtSecurity.Text.Trim();
                        _obj.SecurityTax = txtSecurityTax.Text.Trim();
                        _obj.SecurityNTax = txtSecurityNTax.Text.Trim();
                        _obj.Transport = txtTransport.Text.Trim();
                        _obj.TransportTax = txtTransportTax.Text.Trim();
                        _obj.Cancellation = txtCancellation.Text.Trim();
                        _obj.CancellationTax = txtCancellationTax.Text.Trim();
                        _obj.CarPanalty = txtCarPanalty.Text.Trim();
                        _obj.RecycleFee = txtRecycleFee.Text.Trim();
                        _obj.OtherType = ddlOtherType.SelectedValue;
                        _obj.OtherTypeAmt = txtOtherTypeAmt.Text.Trim();
                        _obj.OtherTypeTax = txtOtherTypeTax.Text.Trim();
                        _obj.OtherNType = ddlOtherNType.SelectedValue;
                        _obj.OtherNTypeAmt = txtOtherNTypeAmt.Text.Trim();
                        _obj.Total = txtTotalAmount.Text.Trim();
                        _obj.Remarks = txtRemarks.Text.Trim();
                        _obj.uid = uid;
                        int temp = _clsA.insertPushPrice(_obj);

                        if (temp > 0)
                        {
                            i = i + 1;
                        }
                    }
                }
                if (i > 0)
                {
                    CommonFunction.MessageBox(this, "S", "Price Update successfully");
                    BindData();
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
        protected void btnUpdateAdate_Click(object sender, EventArgs e)
        {
            int i = 0;
            try
            {
                foreach (GridViewRow row in GridView1.Rows)
                {
                    CheckBox chk = row.FindControl("Chkbox") as CheckBox;
                    if (chk.Checked)
                    {
                        Label lblpid = row.FindControl("lblpid") as Label;
                        entPushPrice _obj = new entPushPrice();
                        _obj.PID = lblpid.Text;
                        _obj.DOE = txtPushDate.Text;
                        _obj.uid = uid;
                        int temp = _clsA.UpdatePushDate(_obj);

                        if (temp > 0)
                        {
                            i = i + 1;
                        }
                    }
                }
                if (i > 0)
                {
                    CommonFunction.MessageBox(this, "S", "Push Price date update successfully");
                    BindData();
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
    }
}