using COMMON;
using DAL;
using ENTITY;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SayyarahCars.Admin
{
    public partial class Add_Variant : System.Web.UI.Page
    {
        clsMasters cls = new clsMasters();
        VariantModel variantModel = new VariantModel();
        CommonFunction commonFunction = new CommonFunction();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AID"] == null)
            {
                Response.Redirect("~/Index", false);
            }
            if (!Page.IsPostBack)
            {
                BindMasterdata();
                if (Request.QueryString["Id"] != null)
                {
                    GetVariantById();
                }
            }
        }

        public void BindMasterdata()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = cls.GetBodyTypeandProduct();
                if (ds.Tables["Table"].Rows.Count > 0)
                {
                    ddlProduct.Items.Clear();
                    ddlProduct.DataSource = ds.Tables["Table"];
                    ddlProduct.DataTextField = "ProductName";
                    ddlProduct.DataValueField = "Id";
                    ddlProduct.DataBind();
                    ddlProduct.Items.Insert(0, new ListItem("Select Product", "0"));
                }
                if (ds.Tables["Table1"].Rows.Count > 0)
                {
                    ddlBodyType.Items.Clear();
                    ddlBodyType.DataSource = ds.Tables["Table1"];
                    ddlBodyType.DataTextField = "BodyTypeName";
                    ddlBodyType.DataValueField = "Id";
                    ddlBodyType.DataBind();
                    ddlBodyType.Items.Insert(0, new ListItem("Select Body Type", "0"));
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                variantModel.Product = ddlProduct.SelectedValue;
                variantModel.BodyType = ddlBodyType.SelectedValue;
                variantModel.VariantName = txtVarientName.Text.Trim();
                variantModel.ModelCode = txtModelCode.Text.Trim();
                variantModel.Drive = ddldrive.SelectedValue;
                variantModel.Transmission = txtTransmission.Text.Trim();
                variantModel.FuelType = ddlfueltype.SelectedValue;
                variantModel.SteeringSide = ddlSteeringside.SelectedValue;
                variantModel.CC = txtCC.Text.Trim();
                variantModel.Cylinders = txtCC.Text.Trim();
                variantModel.Doors = txtDoors.Text.Trim();
                variantModel.Seats = txtSeats.Text.Trim();
                variantModel.WheelSize = txtWheelSize.Text.Trim();
                variantModel.Sunroof = ddlsunroof.SelectedValue;
                variantModel.Weight = txtWeight.Text.Trim();
                variantModel.Length = txtLength.Text.Trim();
                variantModel.Width = txtWidth.Text.Trim();
                variantModel.Height = txtheight.Text.Trim();
                variantModel.PType = ddlPType.SelectedValue;
                variantModel.MildHybrid = ddlhybrid.SelectedValue;

                int temp = cls.AddVarint(variantModel, Session["AID"].ToString());
                if (temp != 0)
                {
                    CommonFunction.MessageBox(this, "S", "Record saved successfully!!");
                    commonFunction.ClearAllControls(Page);
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        public void GetVariantById()
        {
            try
            {
                if (Request.QueryString["Id"] != null)
                {
                    hdnVariantId.Value = commonFunction.Decrypt(Request.QueryString["Id"].ToString());
                    DataSet ds = new DataSet();
                    ds = cls.ViewallVariantById(Convert.ToInt32(hdnVariantId.Value));
                    if (ds.Tables["Table"].Rows.Count > 0)
                    {
                        Button1.Visible = false;
                        Button2.Visible = true;
                        hdnVariantId.Value = ds.Tables[0].Rows[0]["Id"].ToString();
                        ddlProduct.SelectedValue = ds.Tables[0].Rows[0]["ProductId"].ToString();
                        ddlBodyType.SelectedValue = ds.Tables[0].Rows[0]["BodytypeId"].ToString();
                        txtVarientName.Text = ds.Tables[0].Rows[0]["VariantName"].ToString();
                        txtModelCode.Text = ds.Tables[0].Rows[0]["ModelCode"].ToString();
                        ddldrive.SelectedValue = ds.Tables[0].Rows[0]["Drive"].ToString();
                        txtTransmission.Text = ds.Tables[0].Rows[0]["Transmission"].ToString();
                        ddlfueltype.SelectedValue = ds.Tables[0].Rows[0]["FuelType"].ToString();
                        ddlSteeringside.SelectedValue = ds.Tables[0].Rows[0]["SteeringSide"].ToString();
                        txtCC.Text = ds.Tables[0].Rows[0]["CC"].ToString();
                        txtCylinders.Text = ds.Tables[0].Rows[0]["Cylinders"].ToString();
                        txtDoors.Text = ds.Tables[0].Rows[0]["Doors"].ToString();
                        txtSeats.Text = ds.Tables[0].Rows[0]["Seats"].ToString();
                        txtWheelSize.Text = ds.Tables[0].Rows[0]["WheelSize"].ToString();
                        ddlsunroof.SelectedValue = ds.Tables[0].Rows[0]["Sunroof"].ToString();
                        txtWeight.Text = ds.Tables[0].Rows[0]["Weight"].ToString();
                        txtLength.Text = ds.Tables[0].Rows[0]["Length"].ToString();
                        txtWidth.Text = ds.Tables[0].Rows[0]["Width"].ToString();
                        txtheight.Text = ds.Tables[0].Rows[0]["Height"].ToString();
                        ddlPType.SelectedValue = ds.Tables[0].Rows[0]["PType"].ToString();
                        ddlhybrid.SelectedValue = ds.Tables[0].Rows[0]["MildHybrid"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                variantModel.Id = Convert.ToInt32(hdnVariantId.Value);
                variantModel.Product = ddlProduct.SelectedValue;
                variantModel.BodyType = ddlBodyType.SelectedValue;
                variantModel.VariantName = txtVarientName.Text.Trim();
                variantModel.ModelCode = txtModelCode.Text.Trim();
                variantModel.Drive = ddldrive.SelectedValue;
                variantModel.Transmission = txtTransmission.Text.Trim();
                variantModel.FuelType = ddlfueltype.SelectedValue;
                variantModel.SteeringSide = ddlSteeringside.SelectedValue;
                variantModel.CC = txtCC.Text.Trim();
                variantModel.Cylinders = txtCC.Text.Trim();
                variantModel.Doors = txtDoors.Text.Trim();
                variantModel.Seats = txtSeats.Text.Trim();
                variantModel.WheelSize = txtWheelSize.Text.Trim();
                variantModel.Sunroof = ddlsunroof.SelectedValue;
                variantModel.Weight = txtWeight.Text.Trim();
                variantModel.Length = txtLength.Text.Trim();
                variantModel.Width = txtWidth.Text.Trim();
                variantModel.Height = txtheight.Text.Trim();
                variantModel.PType = ddlPType.SelectedValue;
                variantModel.MildHybrid = ddlhybrid.SelectedValue;
                int temp = cls.updateVarint(variantModel, Session["AID"].ToString());
                if (temp != 0)
                {
                    CommonFunction.MessageBox(this, "S", "Record updated successfully!!", "close");
                    GetVariantById();
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