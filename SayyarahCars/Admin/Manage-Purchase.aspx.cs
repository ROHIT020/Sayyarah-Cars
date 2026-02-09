using COMMON;
using DAL;
using ENTITY;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SayyarahCars.Admin
{
    public partial class Manage_Purchase : System.Web.UI.Page
    {
        clsMasters _cls = new clsMasters();
        clsAdmin _clsA = new clsAdmin();
        public CommonFunction cmf = new CommonFunction();
        protected void Page_Load(object sender, EventArgs e)       
        {
            if (!Page.IsPostBack)
            {
                BindProductCategory();
                BindBodyType();
                BindGrid();
            }
        }
        protected void BindProductCategory()
        {
            DataSet ds = _cls.BindProductandBrand();
            cmf.BindDropDownList(ddlcategory, ds.Tables[0], "CategoryName", "id");
            ListItem li = new ListItem("Select", "0");
            ddlcategory.Items.Insert(0, li);
            cmf.BindDropDownList(ddlBrand, ds.Tables[1], "MakerName", "id");
            ddlBrand.Items.Insert(0, li);
        }
        public void BindBodyType()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = _cls.GetBodyTypeandProduct();               
                if (ds.Tables["Table1"].Rows.Count > 0)
                {
                    ddlBodyType.Items.Clear();
                    ddlBodyType.DataSource = ds.Tables["Table1"];
                    ddlBodyType.DataTextField = "BodyTypeName";
                    ddlBodyType.DataValueField = "Id";
                    ddlBodyType.DataBind();
                    ddlBodyType.Items.Insert(0, new ListItem("Select Body Type", "0"));
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void ddlcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindproduct();
        }
        protected void ddlBodyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindvariant();
        }
        protected void bindproduct()
        {
            int cid = Convert.ToInt32(ddlcategory.SelectedValue);
            int mid = Convert.ToInt32(ddlBrand.SelectedValue);
            DataSet ds = _cls.ViewAllProductbyCIdAndMid(cid, mid);
            cmf.BindDropDownList(ddlproduct, ds, "ProductName", "id");
            ListItem li = new ListItem("Select", "0");
            ddlproduct.Items.Insert(0, li);
        }
        protected void bindvariant()
        {
            int pid = Convert.ToInt32(ddlproduct.SelectedValue);
            int bid = Convert.ToInt32(ddlBodyType.SelectedValue);
            DataSet ds = _cls.SelectVariantPBID(pid, bid);
            cmf.BindDropDownList(ddlModel, ds, "VariantName", "id");
            ListItem li = new ListItem("Select", "0");
            ddlModel.Items.Insert(0, li);
        }
        protected void ddlproduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindvariant();
        }
        protected void BindGrid(int PageIndex = 1)
        {
            DataSet ds = new DataSet();
            try
            {
                int PageSize = 100;
                if (ddlpageSize.SelectedValue != "-1")
                {
                    PageSize = Convert.ToInt32(ddlpageSize.SelectedValue);
                }
                else
                {
                    if (txtpagesize.Text != "0" && txtpagesize.Text != "")
                    {
                        PageSize = Convert.ToInt32(txtpagesize.Text.Trim());
                    }
                }
                txtpagesize.Text = PageSize.ToString();
                entPurchaseSearch _obj = new entPurchaseSearch();
                _obj.categoryid = ddlcategory.SelectedValue;
                _obj.productid = ddlproduct.SelectedValue;
                _obj.variantid = ddlModel.SelectedValue;
                _obj.makerid = ddlBrand.SelectedValue;
                _obj.bodytypeid = ddlBodyType.SelectedValue;
                _obj.ChassisNo = txtChassisNo.Text.Trim();
                _obj.KmsF = txtKmsF.Text.Trim();
                _obj.KmsT = txtKmsT.Text.Trim();
                _obj.PriceF = txtPriceF.Text.Trim();
                _obj.PriceT = txtPriceT.Text.Trim();
                _obj.Mileage = txtCC.Text.Trim();
                _obj.Color = ddlcolor.SelectedValue;
                _obj.fdate = txtYearF.Text;
                _obj.tdate =txtYearT.CalendarDate;
                _obj.PageIndex = PageIndex.ToString();
                _obj.PageSize = PageSize.ToString();
                ds = _clsA.SearchPurchaseList(_obj);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = ds.Tables[0];
                    GridView1.PageSize = PageSize;
                    
                    if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                    {
                        GridView1.VirtualItemCount = Convert.ToInt32(ds.Tables[1].Rows[0]["TotalCount"]);
                        GridView1.AllowCustomPaging = true;
                    }
                    GridView1.DataBind();                   
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    CommonFunction.MessageBox(this, "S", "No Record Found!!");                    
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this,"E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }
        protected string PushPrice(string stype, string id)
        {
            if (stype != null && stype.ToString() == "3")
            {               
                return $"<a class='avtar edit' href=\"javascript:void(0);\" title='Update Push Price' onclick=\"openCSSPopup('Add-Push-Price.aspx?id={cmf.Encrypt(id)}', 'Update Push Price')\"><i class='fa-solid fa-file-pen'></i></a>";
            }
            return string.Empty;
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteRow")
            {
                entPurchase _pur = new entPurchase();
                _pur.id = e.CommandArgument.ToString();
                _pur.uid = Session["AID"].ToString();
                int rtval = _clsA.deletePurchase(_pur);
                if (rtval != 0)
                {
                    CommonFunction.MessageBox(this, "S", "Record deleted successfully!!");
                    BindGrid();
                }
            }
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGrid(e.NewPageIndex + 1);
        }
   
        protected void ddlpageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlpageSize.SelectedValue == "-1")
            {
                txtpagesize.Visible = true;
            }
            else
            {
                txtpagesize.Visible = false;
            }
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {            
            BindGrid();
        }

        protected void ddlBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindproduct();
        }       
    }
}