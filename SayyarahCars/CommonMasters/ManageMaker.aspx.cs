using COMMON;
using DAL;
using ENTITY;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace SayyarahCars.CommonMasters
{
    public partial class ManageMaker : System.Web.UI.Page
    {
        public CommonFunction cmf = new CommonFunction();
        clsMasters cls = new clsMasters();
        entmaker obj = new entmaker();
        public string uid = "0";
        public string LogoPath = "";
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
                    BindMakerGrid();
                    //if (Session["SuccessDelete"] != null)
                    //{
                    //    CommonFunction.MessageBox(this, "S", Session["SuccessDelete"].ToString());
                    //    Session.Remove("SuccessMessage");
                    //}
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }
        public void BindMakerGrid()
        {
            try
            {
                DataSet ds = cls.SelectMaker(obj);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    gvMaker.DataSource = ds;
                    gvMaker.DataBind();
                }
                else
                {
                    gvMaker.DataSource = null;
                    gvMaker.DataBind();
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }
        protected void gvMaker_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "DeleteRow")
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
                obj.Id = id;
                obj.uid = uid;
                int temp = cls.DeleteMaker(obj);
                if (temp != 0)
                {
                    CommonFunction.MessageBox(this, "S", "Record deleted successfully!!");
                    //Session["SuccessDelete"] = "Record deleted successfully!!";
                    //Response.Redirect(Request.RawUrl);
                    BindMakerGrid();
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void btnreload_Click(object sender, EventArgs e)
        {
            BindMakerGrid();
        }
    }
}