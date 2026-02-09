using COMMON;
using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SayyarahCars.Admin
{
    public partial class Blog_Preview : System.Web.UI.Page
    {
        CommonFunction cmf = new CommonFunction();
        clsMasters cls = new clsMasters();
        clsAdmin _clsA = new clsAdmin();
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
            DataSet ds = new DataSet();
            try
            {  
                ds = _clsA.selectBlogForPreview(cmf.Decrypt(Request.QueryString["id"].ToString()));
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataList1.DataSource = ds.Tables[0];
                    DataList1.DataBind();

                    string page = Request.Url.Segments[Request.Url.Segments.Length - 1];
                    this.Page.Title = ds.Tables[0].Rows[0]["titletext"].ToString();

                    HtmlMeta keywords = new HtmlMeta();
                    keywords.HttpEquiv = "keywords";
                    keywords.Name = "keywords";
                    keywords.Content = ds.Tables[0].Rows[0]["keywords"].ToString();
                    this.Page.Header.Controls.Add(keywords);


                    HtmlMeta description = new HtmlMeta();
                    description.HttpEquiv = "description";
                    description.Name = "description";
                    description.Content = ds.Tables[0].Rows[0]["description"].ToString();
                    this.Page.Header.Controls.Add(description);
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    DataList2.DataSource = ds.Tables[1];
                    DataList2.DataBind();
                }
               
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", "Something went wrong. Please try again!!");
                ExceptionLogging.LogError(ex.Message);
            }
        }
    }
}