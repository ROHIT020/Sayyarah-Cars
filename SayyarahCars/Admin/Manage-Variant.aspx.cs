using COMMON;
using DAL;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SayyarahCars.Admin
{
    public partial class Manage_Variant : System.Web.UI.Page
    {
        clsMasters cls = new clsMasters();
        public CommonFunction cmf = new CommonFunction();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindMasterdata();
                GetallVarint();
            }
        }
        public void BindMasterdata()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = cls.GetBodyTypeandProduct();
                if (ds.Tables["Table"].Rows.Count > 0)
                {
                    ddlProduct.Items.Clear();
                    ddlProduct.DataSource = ds.Tables["Table"];
                    ddlProduct.DataTextField = "ProductName";
                    ddlProduct.DataValueField = "Id";
                    ddlProduct.DataBind();
                    ddlProduct.Items.Insert(0, new ListItem("Select Product", "0"));
                }
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

        public void GetallVarint()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = cls.ViewallVariant(ddlProduct.SelectedValue, ddlBodyType.SelectedValue, txtModelCode.Text.Trim());
                if (ds.Tables["Table"].Rows.Count > 0)
                {
                    GridView1.DataSource = ds.Tables["Table"];
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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteRow")
            {
                string Id = e.CommandArgument.ToString();
                string UID = Session["AID"].ToString();
                DataSet ds = cls.DeleteVariant(Convert.ToInt32(Id), Convert.ToInt32(UID));
                CommonFunction.MessageBox(this, "S", "Record deleted successfully!!");
                GetallVarint();
            }

        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            GetallVarint();
        }

        protected void btnreload_Click(object sender, EventArgs e)
        {
            GetallVarint();
        }
    }
}