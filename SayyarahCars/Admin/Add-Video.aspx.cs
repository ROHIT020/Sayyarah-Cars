using COMMON;
using DAL;
using ENTITY;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SayyarahCars.Admin
{
    public partial class Add_Video : System.Web.UI.Page
    {
        clsAdmin clsAdmin = new clsAdmin();
        DataSet ds = new DataSet();
        CommonFunction cmf = new CommonFunction();
        AddVideoModel addVideoModel = new AddVideoModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetAllVideoData();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnSubmit.Text != "Update")
                {
                    addVideoModel.VideoLanguage = ddlVideolanguage.SelectedValue;
                    addVideoModel.VideoTitle = txtVideoTitle.Text.Trim();
                    addVideoModel.VideoUrl = txtVideoHtml.Text.Trim();
                    int temp = clsAdmin.addVideo(addVideoModel, Session["AID"].ToString());
                    if (temp != 0)
                    {
                        CommonFunction.MessageBox(this, "S", "Record saved successfully!!");
                        cmf.ClearAllControls(Page);
                        GetAllVideoData();
                    }
                }
                else
                {
                    addVideoModel.Id = Convert.ToInt32(hdnVideoId.Value);
                    addVideoModel.VideoLanguage = ddlVideolanguage.SelectedValue;
                    addVideoModel.VideoTitle = txtVideoTitle.Text.Trim();
                    addVideoModel.VideoUrl = txtVideoHtml.Text.Trim();
                    int temp = clsAdmin.updateVideo(addVideoModel, Session["AID"].ToString());
                    if (temp != 0)
                    {
                        CommonFunction.MessageBox(this, "S", "Record updated successfully!!");
                        cmf.ClearAllControls(Page);
                        GetAllVideoData();
                    }
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        public void GetAllVideoData()
        {
            try
            {
                ds = clsAdmin.getAllVideoData();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = ds;
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
            try
            {
                if (e.CommandName == "EditRow")
                {
                    string Id = e.CommandArgument.ToString();
                    ds = clsAdmin.getAllVideoDataById(Id);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        hdnVideoId.Value = ds.Tables[0].Rows[0]["Id"].ToString();
                        ddlVideolanguage.SelectedValue = ds.Tables[0].Rows[0]["VideoLanguage"].ToString();
                        txtVideoTitle.Text = ds.Tables[0].Rows[0]["VideoTitle"].ToString();
                        txtVideoHtml.Text = ds.Tables[0].Rows[0]["VideoUrl"].ToString();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowModal", "setTimeout(function () { $('#add_region').modal('show'); }, 200);", true);
                        btnSubmit.Text = "Update";
                    }
                }
                else
                {
                    string Id = e.CommandArgument.ToString();
                    int temp = clsAdmin.deleteVideoDataById(Id, Session["AID"].ToString());

                    if (temp != 0)
                    {
                        CommonFunction.MessageBox(this, "S", "Record deleted successfully!!");
                        cmf.ClearAllControls(Page);
                        GetAllVideoData();

                    }
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
            GridView1.PageIndex = e.NewPageIndex;
            GetAllVideoData();
        }
    }
}