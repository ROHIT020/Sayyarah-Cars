using COMMON;
using DAL;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SayyarahCars.CommonMasters
{
    public partial class ManageFOBPrice : System.Web.UI.Page
    {
        public CommonFunction cmf = new CommonFunction();
        clsMasters cls = new clsMasters();
        DataSet ds = new DataSet();
        ListItem li = new ListItem("--Select--", "0");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetAllCountry();
                GetAllFobTypeData();
            }

        }

        public void GetAllCountry()
        {
            clsUseMasters um = new clsUseMasters();
            DataSet ds = um.ListCountry();
            if (ds.Tables["Table"].Rows.Count > 0)
            {
                cmf.BindDropDownList(ddlCountryNameS, ds, "countryname", "ID");
                ddlCountryNameS.Items.Insert(0, li);
            }
        }

        protected void GetAllFobTypeData()
        {
            try
            {               
                ds = cls.getAllFobTypeData(ddlCountryNameS.SelectedValue, ddlCityNameS.SelectedValue, ddlFobtypeS.SelectedValue);
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteRow")
            {
                string Id = e.CommandArgument.ToString();
                string UID = Session["AID"].ToString();
                DataSet ds = cls.DeleteFobTypeMaster(Convert.ToInt32(Id), Convert.ToInt32(UID));
                CommonFunction.MessageBox(this, "S", "Record deleted successfully!!");
                GetAllFobTypeData();
            }
        }

        protected void ddlCountryNameS_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int countryId = Convert.ToInt32(ddlCountryNameS.SelectedValue);
                DataSet ds = cls.getPortsByCountryId(countryId);
                cmf.BindDropDownList(ddlCityNameS, ds, "Name", "ID", 1);
                ddlCityNameS.Items.Insert(0, li);
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            GetAllFobTypeData();
        }

        protected void btnreload_Click(object sender, EventArgs e)
        {
            GetAllFobTypeData();
        }
    }
}