using COMMON;
using DAL.Reports;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENTITY.Model;

namespace SayyarahCars.Admin
{
    public partial class YardIn : System.Web.UI.Page
    {
        public CommonFunction cmf = new CommonFunction();
        DataSet ds = new DataSet();
        clsOtherReport clsOtherReport = new clsOtherReport();
        YardInModel yardInModel = new YardInModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetYardInMasterData();
            }
        }
        public void GetYardInMasterData()
        {
            try
            {
                ds = clsOtherReport.GetYardInMasterData();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlPortName.Items.Clear();
                    ddlPortName.DataSource = ds.Tables[0];
                    ddlPortName.DataTextField = "PortName";
                    ddlPortName.DataValueField = "Id";
                    ddlPortName.DataBind();
                    ddlPortName.Items.Insert(0, new ListItem("Select port name", "0"));
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    ddlShipName.Items.Clear();
                    ddlShipName.DataSource = ds.Tables[1];
                    ddlShipName.DataTextField = "ShipName";
                    ddlShipName.DataValueField = "Id";
                    ddlShipName.DataBind();
                    ddlShipName.Items.Insert(0, new ListItem("Select ship name", "0"));
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        public void GetAllYardInData()
        {
            try
            {
                yardInModel.PortName = ddlPortName.SelectedValue;
                yardInModel.ChassisNo = txtchassis.Text.Trim();
                yardInModel.YardOut = ddlYardOut.SelectedValue;
                yardInModel.YardOutDate = txtYardOutDate.Text.Trim();
                yardInModel.ShipName = ddlShipName.SelectedValue;
                yardInModel.UID = Session["AID"].ToString();
                ds = clsOtherReport.GetAllYardInData(yardInModel);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = ds.Tables[0];
                    GridView1.DataBind();
                    txtYardIn.Text = ds.Tables[1].Rows[0][0].ToString();
                    txtOut.Text = ds.Tables[1].Rows[0][1].ToString();
                    txtRemain.Text = (Convert.ToInt32(ds.Tables[1].Rows[0][0].ToString()) - Convert.ToInt32(ds.Tables[1].Rows[0][1].ToString())).ToString();
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            GetAllYardInData();
        }
    }
}