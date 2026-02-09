using COMMON;
using DAL;
using ENTITY;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SayyarahCars.Admin
{
    public partial class Transport_Info : System.Web.UI.Page
    {
        public CommonFunction cmf = new CommonFunction();
        clsMasters clsMasters = new clsMasters();
        clsAdmin clsAdmin = new clsAdmin();
        DataSet ds = new DataSet();
        public string uid = "0";
        TransportInfo transportInfo = new TransportInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetAllCountry();
                GetAllRegion();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            GetAllData();
            FindGridData();
        }

        public void GetAllCountry()
        {
            try
            {
                ds = clsMasters.CountryBind();
                cmf.BindDropDownList(ddlCountry, ds, "CountryName", "Id");
                ListItem li = new ListItem("--Select Country--", "0");
                ddlCountry.Items.Insert(0, li);
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        public void GetAllRegion()
        {
            int countryId = 0;
            try
            {
                ds = clsMasters.GetAllstate(countryId);
                cmf.BindDropDownList(ddlStateName, ds, "Name", "Id");
                ListItem li = new ListItem("--Select Region--", "0");
                ddlStateName.Items.Insert(0, li);
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        public void GetAllData()
        {
            try
            {
                ds = clsAdmin.getAllAuctionByRID(ddlStateName.SelectedValue);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                    btnAddTransport.Visible = true;
                    BindGridDropDown();
                }
                else
                {
                    btnAddTransport.Visible = false;
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        public void FindGridData()
        {
            try
            {
                ds = clsAdmin.GetTransportshipinB(ddlCountry.SelectedValue, ddlStateName.SelectedValue);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    int count = ds.Tables["Table"].Rows.Count;
                    for (int i = 0; i < count; i++)
                    {
                        string AID = ds.Tables[0].Rows[i]["AuctionId"].ToString();
                        string TID = ds.Tables[0].Rows[i]["TransportId"].ToString();
                        string NSID = ds.Tables[0].Rows[i]["NormalShipingId"].ToString();
                        string NPID = ds.Tables[0].Rows[i]["NormalPortId"].ToString();
                        string ORSID = ds.Tables[0].Rows[i]["ConsShipingId"].ToString();
                        string ORPID = ds.Tables[0].Rows[i]["ConsPortId"].ToString();
                        string ERSID = ds.Tables[0].Rows[i]["ContainerShipingId"].ToString();
                        string ERPID = ds.Tables[0].Rows[i]["ContainerPortId"].ToString();
                        string CUTPIDE = ds.Tables[0].Rows[i]["CutPortId"].ToString();
                        string CUTSID = ds.Tables[0].Rows[i]["CutShipingId"].ToString();
                        foreach (GridViewRow row in GridView1.Rows)
                        {
                            Label lblid = row.FindControl("Label1") as Label;
                            if (lblid.Text == AID)
                            {
                                CheckBox chk = row.FindControl("Chkbox") as CheckBox;
                                chk.Checked = true;
                                DropDownList sddltrailer = row.FindControl("ddltrailer") as DropDownList;
                                sddltrailer.SelectedValue = TID;
                                DropDownList sddlnormal = row.FindControl("ddlnormal") as DropDownList;
                                sddlnormal.SelectedValue = NSID;
                                DropDownList ddlportn = row.FindControl("ddlportn") as DropDownList;
                                ddlportn.SelectedValue = NPID;
                                DropDownList ddlconst = row.FindControl("ddlconst") as DropDownList;
                                ddlconst.SelectedValue = ORSID;
                                DropDownList ddlportt = row.FindControl("ddlportt") as DropDownList;
                                ddlportt.SelectedValue = ORPID;
                                DropDownList sddlcontainer = row.FindControl("ddlcontainer") as DropDownList;
                                sddlcontainer.SelectedValue = ERSID;
                                DropDownList ddlportner = row.FindControl("ddlportner") as DropDownList;
                                ddlportner.SelectedValue = ERPID;
                                DropDownList ddlscut = row.FindControl("ddlscut") as DropDownList;
                                ddlscut.SelectedValue = CUTSID;
                                DropDownList ddlportcut = row.FindControl("ddlportcut") as DropDownList;
                                ddlportcut.SelectedValue = CUTPIDE;
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

        public void BindGridDropDown()
        {
            try
            {
                ds = clsAdmin.GetAllPortAndShippingName();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (GridViewRow row1 in GridView1.Rows)
                    {
                        DropDownList ddlportn = row1.FindControl("ddlportn") as DropDownList;
                        ddlportn.DataSource = ds.Tables["Table"];
                        ddlportn.DataTextField = "PortName";
                        ddlportn.DataValueField = "ID";
                        ddlportn.DataBind();

                        DropDownList ddlportt = row1.FindControl("ddlportt") as DropDownList;
                        ddlportt.DataSource = ds.Tables["Table"];
                        ddlportt.DataTextField = "PortName";
                        ddlportt.DataValueField = "ID";
                        ddlportt.DataBind();

                        DropDownList ddlportner = row1.FindControl("ddlportner") as DropDownList;
                        ddlportner.DataSource = ds.Tables["Table"];
                        ddlportner.DataTextField = "PortName";
                        ddlportner.DataValueField = "ID";
                        ddlportner.DataBind();

                        DropDownList ddlportcut = row1.FindControl("ddlportcut") as DropDownList;
                        ddlportcut.DataSource = ds.Tables["Table"];
                        ddlportcut.DataTextField = "PortName";
                        ddlportcut.DataValueField = "ID";
                        ddlportcut.DataBind();
                        //Start Shippin

                        DropDownList ddlnormal = row1.FindControl("ddlnormal") as DropDownList;
                        ddlnormal.DataSource = ds.Tables["Table1"];
                        ddlnormal.DataTextField = "ShippingName";
                        ddlnormal.DataValueField = "Id";
                        ddlnormal.DataBind();

                        DropDownList ddlconst = row1.FindControl("ddlconst") as DropDownList;
                        ddlconst.DataSource = ds.Tables["Table1"];
                        ddlconst.DataTextField = "ShippingName";
                        ddlconst.DataValueField = "Id";
                        ddlconst.DataBind();

                        DropDownList ddlcontainer = row1.FindControl("ddlcontainer") as DropDownList;
                        ddlcontainer.DataSource = ds.Tables["Table1"];
                        ddlcontainer.DataTextField = "ShippingName";
                        ddlcontainer.DataValueField = "Id";
                        ddlcontainer.DataBind();

                        DropDownList ddlscut = row1.FindControl("ddlscut") as DropDownList;
                        ddlscut.DataSource = ds.Tables["Table1"];
                        ddlscut.DataTextField = "ShippingName";
                        ddlscut.DataValueField = "Id";
                        ddlscut.DataBind();
                        //End Shipping
                        DropDownList ddltrailer = row1.FindControl("ddltrailer") as DropDownList;
                        ddltrailer.DataSource = ds.Tables["Table2"];
                        ddltrailer.DataTextField = "TransportName";
                        ddltrailer.DataValueField = "ID";
                        ddltrailer.DataBind();


                    }
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void btnAddTransport_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (GridViewRow row in GridView1.Rows)
                {
                    Label lblid = row.FindControl("Label1") as Label;
                    CheckBox chk = row.FindControl("Chkbox") as CheckBox;
                    DropDownList sddltrailer = row.FindControl("ddltrailer") as DropDownList;
                    DropDownList sddlnormal = row.FindControl("ddlnormal") as DropDownList;
                    DropDownList ddlportn = row.FindControl("ddlportn") as DropDownList;
                    DropDownList ddlconst = row.FindControl("ddlconst") as DropDownList;
                    DropDownList ddlportt = row.FindControl("ddlportt") as DropDownList;
                    DropDownList sddlcontainer = row.FindControl("ddlcontainer") as DropDownList;
                    DropDownList ddlportner = row.FindControl("ddlportner") as DropDownList;
                    DropDownList ddlportcut = row.FindControl("ddlportcut") as DropDownList;
                    DropDownList ddlscut = row.FindControl("ddlscut") as DropDownList;
                    transportInfo.CountryId = ddlCountry.SelectedValue;
                    transportInfo.RegionId = ddlStateName.SelectedValue;
                    transportInfo.AuctionId = lblid.Text;
                    transportInfo.TransportId = sddltrailer.SelectedValue;
                    transportInfo.NormailShipId = sddlnormal.SelectedValue;
                    transportInfo.NormailPortId = ddlportn.SelectedValue;
                    transportInfo.ConsShipId = ddlconst.SelectedValue;
                    transportInfo.ConsPortId = ddlportt.SelectedValue;
                    transportInfo.CutShipId = ddlscut.SelectedValue;
                    transportInfo.CutPortId = ddlportcut.SelectedValue;
                    transportInfo.ContainerShipId = sddlcontainer.SelectedValue;
                    transportInfo.ContainerPortId = ddlportner.SelectedValue;
                    if (chk.Checked)
                    {
                        int temp = clsAdmin.Updatetransportshipping(transportInfo, Session["AID"].ToString());
                        if (temp != 0)
                        {
                            CommonFunction.MessageBox(this, "S", "Record saved successfully!!");
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
    }
}