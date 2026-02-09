using COMMON;
using DAL;
using ENTITY;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SayyarahCars.Admin
{
    public partial class Manage_Products : System.Web.UI.Page
    {

        clsMasters cls = new clsMasters();
        CommonFunction cmf = new CommonFunction();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Binddata();
                bindProduct();
            }
        }

        public void Binddata()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = cls.BindProductandBrand();
                cmf.BindDropDownList(ddlsubcat, ds, "CategoryName", "ID", 0);
                ddlsubcat.Items.Insert(0, new ListItem("--Select--", "0"));
                cmf.BindDropDownList(ddlcategorysearch, ds, "CategoryName", "ID", 0);
                ddlcategorysearch.Items.Insert(0, new ListItem("--Select--", "0"));

                cmf.BindDropDownList(ddlBrand, ds, "MakerName", "ID", 1);
                ddlBrand.Items.Insert(0, new ListItem("--Select--", "0"));
                cmf.BindDropDownList(ddlbrandsearch, ds, "MakerName", "ID", 1);
                ddlbrandsearch.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ProductModel productModel = new ProductModel();
            try
            {
                if (btnSubmit.Text != "Update")
                {
                    productModel.Category = ddlsubcat.SelectedValue;
                    productModel.BrandName = ddlBrand.SelectedValue;
                    productModel.ProductName = txtProductName.Text.Trim();
                    productModel.cActive = RadioAD.SelectedValue;
                    int temp = cls.AddProductMaster(productModel, Session["AID"].ToString());
                    if (temp != 0)
                    {
                        CommonFunction.MessageBox(this, "S", "Record saved successfully!!");
                        bindProduct();
                        cmf.ClearAllControls(Page);
                    }
                }
                else
                {
                    productModel.Id = Convert.ToInt32(hdnProductId.Value);
                    productModel.Category = ddlsubcat.SelectedValue;
                    productModel.BrandName = ddlBrand.SelectedValue;
                    productModel.ProductName = txtProductName.Text.Trim();
                    productModel.cActive = RadioAD.SelectedValue;
                    int temp = cls.UpdateProductMaster(productModel, Session["AID"].ToString());
                    if (temp != 0)
                    {
                        CommonFunction.MessageBox(this, "S", "Record updated successfully!!");
                        bindProduct();
                        cmf.ClearAllControls(Page);
                    }
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        public void bindProduct(int pageNo = 1)
        {
            try
            {
                int PageSize = GetPageSize();
                DataSet ds = new DataSet();
                ProductModel obj = new ProductModel();
                obj.Category = ddlcategorysearch.SelectedValue;
                obj.BrandName = ddlbrandsearch.SelectedValue;
                obj.ProductName = txtproduct.Text.Trim();
                obj.PageNo = pageNo.ToString();
                obj.PageSize = PageSize.ToString();
                ds = cls.ViewAllProduct(obj);                
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = ds.Tables[0];
                    GridView1.PageSize = PageSize;
                   
                    if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                    {
                        GridView1.VirtualItemCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
                        GridView1.AllowCustomPaging = true;
                    }

                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = ds.Tables["Table"];
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected int GetPageSize()
        {
            int pageSize = 100;
            if (ddlPageSize.SelectedValue != "-1")
            {
                pageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
            }
            else
            {
                if (txtpagesize.Text != "0" && txtpagesize.Text != "")
                {
                    pageSize = Convert.ToInt32(txtpagesize.Text.Trim());
                }
            }
            txtpagesize.Text = pageSize.ToString();
            return pageSize;
        }
        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPageSize.SelectedValue == "-1")
            {
                txtpagesize.Visible = true;
            }
            else
            {
                txtpagesize.Visible = false;
            }
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            bindProduct(e.NewPageIndex + 1);
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditRow")
            {
                string Id = e.CommandArgument.ToString();

                DataSet ds = cls.ViewAllProductbyId(Convert.ToInt32(Id));

                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlsubcat.SelectedValue = ds.Tables[0].Rows[0]["CategoryId"].ToString();
                    ddlBrand.Text = ds.Tables[0].Rows[0]["BrandId"].ToString();
                    txtProductName.Text = ds.Tables[0].Rows[0]["ProductName"].ToString();
                    string sactive = ds.Tables[0].Rows[0]["sActive"].ToString();
                    if (sactive.Trim() == "Active")
                    {
                        RadioAD.SelectedValue = "0";
                    }
                    else { RadioAD.SelectedValue = "1"; }
                    hdnProductId.Value = Id;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowModal", "setTimeout(function () { $('#add_region').modal('show'); }, 200);", true);
                    btnSubmit.Text = "Update";
                }
            }
            else if (e.CommandName == "DeleteRow")
            {
                string Id = e.CommandArgument.ToString();
                string UID = Session["AID"].ToString();
                DataSet ds = cls.DeleteProductMaster(Convert.ToInt32(Id), Convert.ToInt32(UID));

                CommonFunction.MessageBox(this, "S", "Record deleted successfully!!");

                bindProduct();
            }
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            bindProduct();
        }
       

    }
}