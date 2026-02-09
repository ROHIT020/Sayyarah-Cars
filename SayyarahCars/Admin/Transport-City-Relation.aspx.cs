using COMMON;
using DAL;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace SayyarahCars.Admin
{
    public partial class Transport_City_Relation : System.Web.UI.Page
    {
        
        public CommonFunction cmf = new CommonFunction();
        clsAdmin cls = new clsAdmin();

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
                    BindGrid();
                    BindTransport();
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }
        protected void BindTransport()
        {
            DataSet ds = cls.TransportBind();
            cmf.BindDropDownList(ddlTransport, ds, "TransportName", "Id");
            ListItem li = new ListItem("--Select Transport Name--", "0");
            ddlTransport.Items.Insert(0, li);
        }
        private void BindGrid()
        {

            DataSet ds = cls.GetRegion();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {

                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
            }
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (GridViewRow row in GridView1.Rows)
                {
                    CheckBox chk = row.FindControl("Chkbox") as CheckBox;

                    chk.Checked = false;
                }
                bindcityrecord();
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }
        public void bindcityrecord()
        {
            try
            {
                DataSet ds = cls.FindtransPortRID(Convert.ToInt32(ddlTransport.SelectedValue));

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        string ID = dr[0].ToString();

                        foreach (GridViewRow row in GridView1.Rows)
                        {
                            CheckBox chk = row.FindControl("Chkbox") as CheckBox;
                            Label lblid = row.FindControl("Label1") as Label;

                            if (chk != null && lblid != null && ID == lblid.Text)
                            {
                                chk.Checked = true;
                            }
                        }
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
            BindGrid();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (ddlTransport.SelectedValue == "0")
            {
                CommonFunction.MessageBox(this, "E", "please Select Transport Name!!");
                BindGrid();
            }
            else
            {
                int temp1 = cls.UpdateTransportRID(ddlTransport.SelectedValue);
                foreach (GridViewRow row in GridView1.Rows)
                {
                    Label lblid = row.FindControl("Label1") as Label;
                    CheckBox chk = row.FindControl("Chkbox") as CheckBox;
                    if (chk.Checked)
                    {
                        int temp = cls.AddTransportToCity(ddlTransport.SelectedValue, lblid.Text, Session["AID"].ToString());
                        if (temp != 0)
                        {
                            CommonFunction.MessageBox(this, "S", "Record saved successfully!!");
                        }
                    }
                }
            }
        }
    }
}