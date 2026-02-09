using COMMON;
using DAL;
using ENTITY;
using System;
using System.Data;
using System.Web.UI.WebControls;


namespace SayyarahCars.CommonMasters
{
    public partial class ManageFeatures : System.Web.UI.Page
    {
        CommonFunction cmf = new CommonFunction();
        clsMasters cls = new clsMasters();
        entFeaturesMaster obj = new entFeaturesMaster();
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
                    BindProductCategory();
                    bindFeatureCategory();
                    bindsearch();
                }
            }
            catch (Exception ex)
            {
                //CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }
        protected void BindProductCategory()
        {
            DataSet ds = new DataSet();
            ds = cls.SelectCategory();
            cmf.BindDropDownList(ddlcategory, ds, "CategoryName", "ID");
            ListItem li1 = new ListItem("Category", "0");
            ddlcategory.Items.Insert(0, li1);
        }
        protected void bindFeatureCategory()
        {
            obj.categoryid = Convert.ToInt32(ddlcategory.SelectedValue);
            obj.PID = 0;
            DataSet ds = cls.bindFeatures(obj);
            cmf.BindDropDownList(ddlpid, ds, "FeatureName", "ID");
            ListItem li1 = new ListItem("Parent Group", "0");
            ddlpid.Items.Insert(0, li1);
        }


        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnsubmit.Text != "Update")
                {
                    obj.id = 0;
                    obj.categoryid = Convert.ToInt32(ddlcategory.SelectedValue);
                    obj.FeatureName = txtfeature.Text.Trim();
                    obj.PID = Convert.ToInt32(ddlpid.SelectedValue);
                    cls.InsertFeaturesMaster(obj);
                }
                else
                {

                    obj.id = Convert.ToInt32(cmf.Decrypt(hdnid.Value));
                    obj.categoryid = Convert.ToInt32(ddlcategory.SelectedValue);
                    obj.FeatureName = txtfeature.Text.Trim();
                    obj.PID = Convert.ToInt32(ddlpid.SelectedValue);
                    cls.UpdateFeaturesMaster(obj);
                }
                btnsubmit.Text = "Submit";
                txtfeature.Text = "";
                if (ddlpid.SelectedValue == "0")
                {
                    bindFeatureCategory();
                    bindsearch();
                    CommonFunction.MessageBox(this, "S", "Feature Group added to Feature Group Dropdown List!!");
                }
                else
                {
                    bindsearch();
                    CommonFunction.MessageBox(this, "S", "Sub Feature saved successfully!!");
                }


            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }
        public void bindsearch()
        {
            try
            {
                obj.categoryid = Convert.ToInt32(ddlcategory.SelectedValue);
                obj.PID = Convert.ToInt32(ddlpid.SelectedValue);
                DataSet ds = cls.bindFeatures(obj);
                ViewState["DataTable"] = ds.Tables[0];
                GridView1.PageSize = int.Parse(ddlpages.SelectedValue);
                GridView1.DataSource = ds;
                GridView1.DataBind();
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
            bindsearch();
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "EditRow")
                {

                    int id = Convert.ToInt32(e.CommandArgument);
                    obj.id = id;
                    DataSet ds = cls.SelectFeatureByID(obj);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        hdnid.Value = cmf.Encrypt(ds.Tables[0].Rows[0]["id"].ToString());
                        txtfeature.Text = ds.Tables[0].Rows[0]["FeatureName"].ToString();
                        ddlpid.SelectedValue = ds.Tables[0].Rows[0]["PID"].ToString();
                        ddlcategory.SelectedValue = ds.Tables[0].Rows[0]["categoryid"].ToString();
                        btnsubmit.Text = "Update";
                    }
                }
                else if (e.CommandName == "DeleteRow")
                {
                    int id = Convert.ToInt32(e.CommandArgument);
                    DeleteItem(id);
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }
        private void DeleteItem(int id)
        {
            try
            {
                obj.id = id;
                cls.DeleteFeaturesMaster(obj);
                bindsearch();
                CommonFunction.MessageBox(this, "S", "Record deleted successfully!!");
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void ddlpages_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindsearch();
        }

        protected void ddlpid_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindsearch();

        }
        protected void ddlcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindFeatureCategory();
            bindsearch();
        }
    }
}