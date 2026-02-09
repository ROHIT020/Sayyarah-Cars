using COMMON;
using DAL.Reports;
using ENTITY.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SayyarahCars.Admin
{
    public partial class Ship_Departure : System.Web.UI.Page
    {
        public CommonFunction cmf = new CommonFunction();
        Report report = new Report();
        DataSet ds = new DataSet();
        ShipDeparture shipDeparture = new ShipDeparture();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetShipDptMasterData();
                GetAllShipDeparture();
            }
        }

        public void GetShipDptMasterData()
        {
            try
            {
                ds = report.GetShipDptMasterData();
                if (ds.Tables["Table"].Rows.Count > 0)
                {
                    ddlShipName.Items.Clear();
                    ddlShipName.DataSource = ds.Tables["Table"];
                    ddlShipName.DataTextField = "ShipName";
                    ddlShipName.DataValueField = "Id";
                    ddlShipName.DataBind();
                    ddlShipName.Items.Insert(0, new ListItem("Select Ship Name", "0"));
                }
                if (ds.Tables["Table1"].Rows.Count > 0)
                {
                    ddlPortFrom.Items.Clear();
                    ddlPortFrom.DataSource = ds.Tables["Table1"];
                    ddlPortFrom.DataTextField = "PortName";
                    ddlPortFrom.DataValueField = "ID";
                    ddlPortFrom.DataBind();
                    ddlPortFrom.Items.Insert(0, new ListItem("Select Port Name", "0"));
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
                    ds = report.GetAllShipDeparture(Convert.ToInt32(Id));
                    if (ds != null)
                    {
                        hdnShipDpt.Value = ds.Tables[0].Rows[0]["Id"].ToString();
                        ddlShipName.SelectedValue = ds.Tables[0].Rows[0]["ShipId"].ToString();
                        ddlPortFrom.SelectedValue = ds.Tables[0].Rows[0]["PortId"].ToString();
                        txtArrivalDate.Text = ds.Tables[0].Rows[0]["ArrivalDate"].ToString();
                        txtDepartureDate.Text = ds.Tables[0].Rows[0]["DepartureDate"].ToString();
                        btnSubmit.Text = "Update";
                    }
                }
                else
                {
                    string Id = e.CommandArgument.ToString();
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
            try
            {
                if (btnSubmit.Text != "Update")
                {

                    shipDeparture.ShipName = ddlShipName.SelectedValue;
                    shipDeparture.PortName = ddlPortFrom.SelectedValue;
                    shipDeparture.ArrivalDate = txtArrivalDate.Text.Trim();
                    shipDeparture.DepartureDate = txtDepartureDate.Text.Trim();
                    shipDeparture.UID = Convert.ToInt32(Session["AID"]);
                    int result = report.AddShipDeparture(shipDeparture);
                    if (result != 0)
                    {
                        CommonFunction.MessageBox(this, "S", "Record saved succesfully!!");
                        cmf.ClearAllControls(Page);
                        GetAllShipDeparture();
                    }
                }
                else
                {
                    shipDeparture.Id = Convert.ToInt32(hdnShipDpt.Value);
                    shipDeparture.ShipName = ddlShipName.SelectedValue;
                    shipDeparture.PortName = ddlPortFrom.SelectedValue;
                    shipDeparture.ArrivalDate = txtArrivalDate.Text.Trim();
                    shipDeparture.DepartureDate = txtDepartureDate.Text.Trim();
                    shipDeparture.UID = Convert.ToInt32(Session["AID"]);
                    int result = report.UpdateShipDeparture(shipDeparture);
                    if (result != 0)
                    {
                        CommonFunction.MessageBox(this, "S", "Record updated succesfully!!");
                        cmf.ClearAllControls(Page);
                        GetAllShipDeparture();
                    }
                } 
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        public void GetAllShipDeparture()
        {
            try
            {
                int Id = 0;
                ds = report.GetAllShipDeparture(Id);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = ds.Tables[0];
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = ds.Tables[0];
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }
    }
}