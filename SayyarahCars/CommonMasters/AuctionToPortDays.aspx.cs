using COMMON;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SayyarahCars.CommonMasters
{
    public partial class AuctionToPortDays : System.Web.UI.Page
    {
        DataAccess da;
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
                    BindAllPort();
                    BindGrid();
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }
        protected void BindAllPort()
        {
            clsUseMasters um = new clsUseMasters();
            DataSet ds = um.PortBind();
            cmf.BindDropDownList(ddlAllPortName, ds, "PortName", "Id");
            ListItem li = new ListItem("--Select Port--", "0");
            ddlAllPortName.Items.Insert(0, li);
        }

        private void BindGrid()
        {
            try
            {
                da = new DataAccess();
                SqlParameter[] prm = new SqlParameter[2];
                prm[0] = new SqlParameter("@AID", "0");
                prm[1] = new SqlParameter("@PID", ddlAllPortName.SelectedValue);
                DataSet ds = da.GetDataSet("GetAddAuctionPortWithAuctionName", prm);
                GridView1.DataSource = ds;
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            string selectedPort = ddlAllPortName.SelectedValue;
            if (selectedPort == "0")
            {
                CommonFunction.MessageBox(this, "E", " Please Select Port !!");
                BindGrid();
            }
            else
            {
                foreach (GridViewRow row in GridView1.Rows)
                {
                    CheckBox chk = (CheckBox)row.FindControl("Chkbox");
                    if (chk != null && chk.Checked)
                    {
                        Label lblID = (Label)row.FindControl("Label1");
                        TextBox txtDays = (TextBox)row.FindControl("txtdays");
                        int temp = cls.AddPortAndAuction(selectedPort, lblID.Text.Trim(), txtDays.Text.Trim(), Session["AID"].ToString());
                        if (temp != 0)
                        {
                            CommonFunction.MessageBox(this, "S", "Record saved successfully!!");
                            BindGrid();
                        }

                    }
                }
            }
        }


        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblID = (Label)e.Row.FindControl("Label1");
                TextBox txtDays = (TextBox)e.Row.FindControl("txtdays");
                CheckBox chk = (CheckBox)e.Row.FindControl("Chkbox");
                string noOfDays = "";
                da = new DataAccess();
                SqlParameter[] parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@PID", ddlAllPortName.SelectedValue);
                parameters[1] = new SqlParameter("@AID", lblID.Text);
                DataSet ds = da.GetDataSet("GetAuctionToPortNoofDays", parameters);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    noOfDays = ds.Tables[0].Rows[0]["noOfDays"].ToString();
                }

                if (txtDays != null && chk != null)
                {
                    if (noOfDays != "0" && noOfDays != "")
                    {
                        chk.Checked = true;
                        txtDays.Text = noOfDays;
                    }
                    else
                    {
                        chk.Checked = false;
                        txtDays.Text = "";
                    }
                }
            }
        }

        protected void ddlAllPortName_SelectedIndexChanged1(object sender, EventArgs e)
        {
            BindGrid();
        }
    }
}