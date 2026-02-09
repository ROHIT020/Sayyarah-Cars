using COMMON;
using DAL;
using ENTITY;
using System;
using System.Data;

namespace SayyarahCars.CommonMasters
{
    public partial class UpdateMetaData : System.Web.UI.Page
    {
        CommonFunction cmf = new CommonFunction();
        clsMasters cls = new clsMasters();
        entMetaDataMaster _ent = new entMetaDataMaster();
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
                    if (Request.QueryString["pageid"] != null && Request.QueryString["id"] != null)
                    {
                        bindData();
                    }
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }
        protected void bindData()
        {
            _ent.mid = Convert.ToInt32(cmf.Decrypt(Request.QueryString["id"].ToString()));
            _ent.pageid = Convert.ToInt32(Request.QueryString["pageid"].ToString());
            DataSet ds = cls.selectMetaDataMaster(_ent);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtTitle.Text = ds.Tables[0].Rows[0]["titletext"].ToString();
                txtKeyword.Text = ds.Tables[0].Rows[0]["keywords"].ToString();
                txtDescription.Text = ds.Tables[0].Rows[0]["description"].ToString();
                txtPageContent.Text = ds.Tables[0].Rows[0]["pagecontent"].ToString();
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            _ent.mid = Convert.ToInt32(cmf.Decrypt(Request.QueryString["id"].ToString()));
            _ent.pageid = Convert.ToInt32(Request.QueryString["pageid"].ToString());
            _ent.titletext = txtTitle.Text.Trim();
            _ent.keywords = txtKeyword.Text.Trim();
            _ent.description = txtDescription.Text.Trim();
            _ent.pagecontent = txtPageContent.Text.Trim();
            _ent.uid = Convert.ToInt32(uid);
            cls.InsertMetaDataMaster(_ent);
            CommonFunction.MessageBox(this, "S", "Record saved successfully!!","close");
        }
    }
}