using COMMON;
using DAL;
using ENTITY;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace SayyarahCars.CommonMasters
{
    public partial class AddAction : System.Web.UI.Page
    {
        public CommonFunction cmf = new CommonFunction();
        clsMasters cls = new clsMasters();
        entAuction obj = new entAuction();
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
                    BindGroup();
                    if (Request.QueryString["id"] != null)
                    {
                        binddata();

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
            cmf.BindDropDownList(ddlCountry, ds, "CountryName", "Id");
            ListItem li = new ListItem("--Select Country--", "0");
            ddlCountry.Items.Insert(0, li);
        }
        protected void BindGroup()
        {
            DataSet ds = cls.AuctionGroupBind();
            cmf.BindDropDownList(ddlauctiongroup, ds, "Name", "Id");
            ListItem li = new ListItem("--Select Auction Group--", "0");
            ddlauctiongroup.Items.Insert(0, li);
            ListItem li2 = new ListItem("Add New", "-1");
            li2.Attributes.Add("class", "add-new-item");
            ddlauctiongroup.Items.Add(li2);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string groupid = ddlauctiongroup.SelectedValue;
            if (ddlauctiongroup.SelectedValue == "-1")
            {
                groupid = cls.InsertAuctionGroup(txtGroup.Text.Trim()).ToString();
            }

            if (btnSubmit.Text != "Update")
            {
                obj.CountryId = Convert.ToInt32(ddlCountry.SelectedValue);
                obj.AGroup = Convert.ToInt32(groupid);
                obj.Name = txtName.Text.Trim();
                obj.Address = txtAddress.Text.Trim();
                obj.Email = txtEmail.Text.Trim();
                obj.Contact = txtcontact.Text.Trim();
                obj.FaxNumber = Convert.ToDecimal(txtFaxNo.Text.Trim());
                obj.Archive = rdoactive.Checked ? false : true;
                obj.uid = Convert.ToInt32(uid);
                int result = cls.InsertAuction(obj);
                if (result != 0)
                {
                    CommonFunction.MessageBox(this, "S", "Record saved successfully!!", "close");
                    cmf.ClearAllControls(Page);
                }
            }
            else
            {

                obj.Id = Convert.ToInt32(cmf.Decrypt(Request.QueryString["id"].ToString()));
                obj.CountryId = Convert.ToInt32(ddlCountry.SelectedValue);
                obj.AGroup = Convert.ToInt32(groupid);
                obj.Name = txtName.Text.Trim();
                obj.Address = txtAddress.Text.Trim();
                obj.Email = txtEmail.Text.Trim();
                obj.Contact = txtcontact.Text.Trim();
                obj.FaxNumber = Convert.ToDecimal(txtFaxNo.Text.Trim());
                obj.uid = Convert.ToInt32(uid);
                if (rdoactive.Checked)
                {
                    obj.Archive = false;
                }
                else
                {
                    obj.Archive = true;
                }
               int result= cls.updateAuction(obj);
                if (result != 0)
                {
                    CommonFunction.MessageBox(this, "S", "Record Updated successfully!!", "close");
                    cmf.ClearAllControls(Page);
                }
            }

        }

        protected void binddata()
        {
            obj.Id = Convert.ToInt32(cmf.Decrypt(Request.QueryString["id"].ToString()));
            DataSet ds = cls.SelectAuctionById(obj);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlCountry.SelectedValue = ds.Tables[0].Rows[0]["CountryId"].ToString();
                ddlauctiongroup.SelectedValue = ds.Tables[0].Rows[0]["AGroup"].ToString();
                txtName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                txtcontact.Text = ds.Tables[0].Rows[0]["Contact"].ToString();
                txtFaxNo.Text = ds.Tables[0].Rows[0]["FaxNo"].ToString();
                string status = ds.Tables[0].Rows[0]["Archive"].ToString();
                if (status == "True")
                {
                    rdoactive.Checked = false;
                    rdodeActive.Checked = true;
                }
                else
                {
                    rdoactive.Checked = true;
                    rdodeActive.Checked = false;
                }

                btnSubmit.Text = "Update";
            }
        }

        protected void ddlauctiongroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlauctiongroup.SelectedValue == "-1")
            {
                Divgroup.Visible = true;
            }
            else
            {
                Divgroup.Visible = false;
            }
        }
    }
}