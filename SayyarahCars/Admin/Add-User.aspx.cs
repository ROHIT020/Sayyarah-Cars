using COMMON;
using DAL;
using ENTITY;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace SayyarahCars.Admin
{
    public partial class Add_User : System.Web.UI.Page
    {
        CommonFunction cmf = new CommonFunction();
        clsMasters cls = new clsMasters();
        entAdduser obj = new entAdduser();
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
                    BindCountry();
                    BindDepartment();
                    BindUsertype();
                    BindDesignation();
                    if (Request.QueryString["id"] != null)
                    {
                        pnlUserDetails.Visible = false;
                        binddata();
                    }
                    else
                    {
                        pnlUserDetails.Visible = true;
                        chkShowpanel.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }
        protected void BindCountry()
        {
            DataSet ds = cls.CountryBind();
            cmf.BindDropDownList(ddlcountry, ds, "CountryName", "Id");
            ListItem li = new ListItem("--Select Country--", "0");
            ddlcountry.Items.Insert(0, li);
        }
        protected void BindDepartment()
        {
            DataSet ds = cls.DepartmentBind();
            cmf.BindDropDownList(ddldepartment, ds, "Department", "Id");
            ListItem li = new ListItem("--Select Department--", "0");
            ddldepartment.Items.Insert(0, li);
        }
        protected void BindUsertype()
        {
            DataSet ds = cls.UserTypeBind();
            cmf.BindDropDownList(ddlusertype, ds, "Usertype", "Id");
            ListItem li = new ListItem("--Select UserType--", "0");
            ddlusertype.Items.Insert(0, li);
        }

        protected void BindDesignation()
        {
            DataSet ds = cls.DesignationBind();
            cmf.BindDropDownList(ddldesignation, ds, "Designation", "Id");
            ListItem li = new ListItem("--Select Designation--", "0");
            ddldesignation.Items.Insert(0, li);
        }

        protected void BindMasters()
        {

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnSubmit.Text != "Update")
                {

                    obj.Fname = txtfname.Text.Trim();
                    obj.Lname = txtlname.Text.Trim();
                    obj.UserName = txtusername.Text.Trim();
                    obj.Password = txtpassword.Text.Trim();
                    obj.Contact = txtcontactno.Text.Trim();
                    obj.Email = txtemailid.Text.Trim();
                    obj.CountryId = Convert.ToInt32(ddlcountry.SelectedValue);
                    obj.Idtype = txtIDtype.Text.Trim();
                    obj.IdNumber = txtIDNumber.Text.Trim();
                    obj.DOB = txtDOB.Text.Trim();
                    obj.DOJ = txtDOJ.Text.Trim();
                    obj.Designation = Convert.ToInt32(ddldesignation.SelectedValue);
                    obj.UserType = Convert.ToInt32(ddlusertype.SelectedValue);
                    obj.Edepartment = Convert.ToInt32(ddldepartment.SelectedValue);
                    obj.PAddress = txtPAddress.Text.Trim();
                    obj.RAddress = txtRAddress.Text.Trim();
                    obj.uid = Convert.ToInt32(uid);
                    if (cls.IsUserExists(obj) == 1)
                    {
                        cls.InsertAdminuser(obj);
                        CommonFunction.MessageBox(this, "S", "Record saved successfully!!");
                        cmf.ClearAllControls(Page);
                    }
                    else
                    {
                        CommonFunction.MessageBox(this, "E", "UserName or Email ID already exists!!");
                    }

                }
                else
                {
                    obj.Id = Convert.ToInt32(cmf.Decrypt(Request.QueryString["id"].ToString()));
                    obj.Fname = txtfname.Text.Trim();
                    obj.Lname = txtlname.Text.Trim();
                    obj.Contact = txtcontactno.Text.Trim();
                    obj.Email = txtemailid.Text.Trim();
                    obj.CountryId = Convert.ToInt32(ddlcountry.SelectedValue);
                    obj.Idtype = txtIDtype.Text.Trim();
                    obj.IdNumber = txtIDNumber.Text.Trim();
                    obj.DOB = txtDOB.Text.Trim();
                    obj.DOJ = txtDOJ.Text.Trim();
                    obj.Designation = Convert.ToInt32(ddldesignation.SelectedValue);
                    obj.UserType = Convert.ToInt32(ddlusertype.SelectedValue);
                    obj.Edepartment = Convert.ToInt32(ddldepartment.SelectedValue);
                    obj.PAddress = txtPAddress.Text.Trim();
                    obj.RAddress = txtRAddress.Text.Trim();
                    obj.uid = Convert.ToInt32(uid);
                    if (cls.IsUpdateUserExists(obj) == 1)
                    {
                        cls.updateUser(obj);
                        if (chkShowpanel.Checked)
                        {
                            obj.UserName = txtusername.Text.Trim();
                            obj.Password = txtpassword.Text.Trim();
                            obj.uid = Convert.ToInt32(uid);
                            cls.updateUserPassword(obj);
                        }
                        CommonFunction.MessageBox(this, "S", "Record updated successfully!!");
                        cmf.ClearAllControls(Page);
                    }
                    else
                    {
                        CommonFunction.MessageBox(this, "E", "UserName or Email ID already exists!!");
                    }
                }

            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void binddata()
        {
            obj.Id = Convert.ToInt32(cmf.Decrypt(Request.QueryString["id"].ToString()));
            DataSet ds = cls.SelectUserById(obj);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtfname.Text = ds.Tables[0].Rows[0]["Fname"].ToString();
                txtlname.Text = ds.Tables[0].Rows[0]["Lname"].ToString();
                txtusername.Text = ds.Tables[0].Rows[0]["username"].ToString();
                txtpassword.Text = ds.Tables[0].Rows[0]["password"].ToString();
                txtcontactno.Text = ds.Tables[0].Rows[0]["Contact"].ToString();
                txtemailid.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                if (ds.Tables[0].Rows[0]["CountryId"].ToString() != string.Empty)
                {
                    ddlcountry.SelectedValue = ds.Tables[0].Rows[0]["CountryId"].ToString();
                }
                txtIDtype.Text = ds.Tables[0].Rows[0]["Idtype"].ToString();
                txtIDNumber.Text = ds.Tables[0].Rows[0]["IdNumber"].ToString();
                if (ds.Tables[0].Rows[0]["DOB"].ToString() != string.Empty)
                {
                    txtDOB.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["DOB"]).ToString("yyyy-MM-dd");
                }
                if (ds.Tables[0].Rows[0]["DOJ"].ToString() != string.Empty)
                {
                    txtDOJ.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["DOJ"]).ToString("yyyy-MM-dd");
                }
                if (ds.Tables[0].Rows[0]["designation"].ToString() != string.Empty)
                {
                    ddldesignation.SelectedValue = ds.Tables[0].Rows[0]["designation"].ToString();
                }
                if (ds.Tables[0].Rows[0]["utype"].ToString() != string.Empty)
                {
                    ddlusertype.SelectedValue = ds.Tables[0].Rows[0]["utype"].ToString();
                }
                if (ds.Tables[0].Rows[0]["EDepartment"].ToString() != string.Empty)
                {
                    ddldepartment.SelectedValue = ds.Tables[0].Rows[0]["EDepartment"].ToString();
                }
                txtPAddress.Text = ds.Tables[0].Rows[0]["PAddress"].ToString();
                txtRAddress.Text = ds.Tables[0].Rows[0]["RAddress"].ToString();
                btnSubmit.Text = "Update";
            }
        }

        protected void chkShowLoginFields_CheckedChanged(object sender, EventArgs e)
        {
            pnlUserDetails.Visible = chkShowpanel.Checked;
        }
    }

}