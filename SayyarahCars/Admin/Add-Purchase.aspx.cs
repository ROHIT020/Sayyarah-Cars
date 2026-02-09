using COMMON;
using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;


namespace SayyarahCars.Admin
{
    public partial class Add_Purchase : System.Web.UI.Page
    {
        CommonFunction cmf = new CommonFunction();
        clsMasters cls = new clsMasters();
        clsAdmin _clsA = new clsAdmin();
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
                    BindProductCategory();
                    if (Request.QueryString["Id"] != null)
                    {
                        btnsubmit.Text = "Update";
                        hdnid.Value = Request.QueryString["Id"].ToString();
                        bindPurchase();
                    }
                    bindfeatures();
                    TabContainer1_ActiveTabChanged(TabContainer1, null);
                }

            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }
        protected void bindPurchase()
        {
            string Id = cmf.Decrypt(hdnid.Value);
            DataSet ds = _clsA.SelectPurchaseById(Id);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlcategory.SelectedValue = ds.Tables[0].Rows[0]["SubCId"].ToString();
                bindproduct();
                ddlproduct.SelectedValue = ds.Tables[0].Rows[0]["PID"].ToString();
                bindvariant();
                ddlModel.SelectedValue = ds.Tables[0].Rows[0]["VID"].ToString();
                txtChassisNo.Text = ds.Tables[0].Rows[0]["Cno"].ToString();
                txtMDate.Text = ds.Tables[0].Rows[0]["Mdate"].ToString();
                txtRDate.Text = ds.Tables[0].Rows[0]["Rgdate"].ToString();
                txtMileage.Text = ds.Tables[0].Rows[0]["Mileage"].ToString();
                ddlcolor.SelectedValue = ds.Tables[0].Rows[0]["Ccolor"].ToString();
                ddlSellerType.SelectedValue = ds.Tables[0].Rows[0]["Otype"].ToString();
                ddlSeller.SelectedValue = ds.Tables[0].Rows[0]["OID"].ToString();
                txtLotNo.Text= ds.Tables[0].Rows[0]["LotNo"].ToString();
                txtGrade.Text = ds.Tables[0].Rows[0]["Grade"].ToString();
                ddlUrgent.SelectedValue = ds.Tables[0].Rows[0]["Urgent"].ToString();

                lblSeller.InnerText = ddlSellerType.SelectedItem.Text;
                if (ddlSellerType.SelectedValue == "-1")
                {
                    pnlother.Visible = true;
                    pnlseller.Visible = false;
                }
                else
                {
                    if (ddlSellerType.SelectedValue == "3")
                    {
                        divAuctionDate.Visible = true;
                        divAuctionSource.Visible = true;
                    }
                    else
                    {
                        divAuctionDate.Visible = false;
                        divAuctionSource.Visible = false;
                    }
                    pnlother.Visible = false;
                    pnlseller.Visible = true;
                    bindSellerMaster(ddlSellerType.SelectedValue);
                }
                ddlSeller.SelectedValue = ds.Tables[0].Rows[0]["AID"].ToString();
                if (ds.Tables[0].Rows[0]["Otype"].ToString() == "3")
                {
                    txtAuctionDate.Text = ds.Tables[0].Rows[0]["Adate"].ToString();
                    ddlAuctionSource.SelectedValue = ds.Tables[0].Rows[0]["SAID"].ToString();
                }
                
                bindImages();
                bindSelectedFeatures();
                bindImages_Left();
                bindImages_Right();
                bindImages_Front();
                bindImages_Rear();
                bind_Documents();
                if (hdnid.Value == "0")
                {
                    TabPanel2.Enabled = false;
                    TabPanel3.Enabled = false;
                    TabPanel4.Enabled = false;
                    TabPanel5.Enabled = false;
                    TabPanel6.Enabled = false;
                }
                else
                {
                    TabPanel2.Enabled = true;
                    TabPanel3.Enabled = true;
                    TabPanel4.Enabled = true;
                    TabPanel5.Enabled = true;
                    TabPanel6.Enabled = true;
                }
            }
        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                int rtval = 0;
                  entPurchase _obj = new entPurchase();
                _obj.categoryid = ddlcategory.SelectedValue;
                _obj.productid = ddlproduct.SelectedValue;
                _obj.variantid = ddlModel.SelectedValue;
                _obj.ChassisNo = txtChassisNo.Text.Trim();
                _obj.MDate = txtMDate.Text.Trim();
                _obj.RDate = txtRDate.Text.Trim();
                string[] Year = txtRDate.Text.Split('/');
                _obj.Year = Year[2];
                _obj.Mileage = txtMileage.Text.Trim();
                _obj.Color = ddlcolor.SelectedValue;
                _obj.OwnerType = ddlSellerType.SelectedValue;
                _obj.OwnerTypeId = ddlSeller.SelectedValue;
                _obj.LotNo = txtLotNo.Text.Trim();
                _obj.Grade = txtGrade.Text.Trim();
                _obj.Urgent = ddlUrgent.SelectedValue;

                if (ddlSellerType.SelectedValue == "3")
                {
                    _obj.AID = ddlSeller.Text.Trim();
                    _obj.SAID = ddlAuctionSource.SelectedValue;
                    _obj.ADate = txtAuctionDate.Text.Trim();
                    _obj.OwnerTypeId = null;
                }
             
                _obj.uid = uid;
                if (btnsubmit.Text != "Update")
                {
                    rtval = _clsA.insertPurchase(_obj);
                    hdnid.Value = cmf.Encrypt(rtval.ToString());
                }
                else
                {
                    _obj.id = cmf.Decrypt(hdnid.Value);
                    rtval = _clsA.updatePurchase(_obj);
                }
                CommonFunction.MessageBox(this, "S", "Record updated successfully!!");
                Response.Redirect("Add-Purchase?Id=" + cmf.Encrypt(rtval.ToString()));
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", "Something went wrong. Please try again!!");
                ExceptionLogging.LogError(ex.Message);
            }
        }

        protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
        {
            if (hdnid.Value == "0")
            {
                TabPanel2.Enabled = false;
                TabPanel3.Enabled = false;
                TabPanel4.Enabled = false;
                TabPanel5.Enabled = false;
                TabPanel6.Enabled = false;
            }
            else
            {
                TabPanel2.Enabled = true;
                TabPanel3.Enabled = true;
                TabPanel4.Enabled = true;
                TabPanel5.Enabled = true;
                TabPanel6.Enabled = true;
            }
        }
        protected void BindProductCategory()
        {
            DataSet ds = cls.SelectCategories("1");
            cmf.BindDropDownList(ddlcategory, ds, "CategoryName", "id");
            ListItem li = new ListItem("Select", "0");
            ddlcategory.Items.Insert(0, li);
        }
        protected void bindfeatures()
        {
            DataTable dt = new DataTable();
            List<entFeaturesMaster> lst = new List<entFeaturesMaster>();
            entFeaturesMaster obj = new entFeaturesMaster();
            obj.categoryid = Convert.ToInt32("1");

            DataSet ds = cls.SelectFeatureByCATID(obj);
            dt = ds.Tables[0];
            DataView dataView = ds.Tables[1].DefaultView;

            foreach (DataRow dtrow in dt.Rows)
            {
                DataTable dt1 = new DataTable();
                dataView.RowFilter = "PID = '" + dtrow["ID"] + "'";
                dt1 = dataView.ToTable();

                List<entFeaturesMaster> child = new List<entFeaturesMaster>();
                foreach (DataRow row in dt1.Rows)
                {
                    child.Add(new entFeaturesMaster()
                    {
                        id = Convert.ToInt32(row["ID"]),
                        FeatureName = row["FeatureName"].ToString().Trim(),
                        PID = Convert.ToInt32(row["PID"]),
                    });
                }

                lst.Add(new entFeaturesMaster()
                {
                    id = Convert.ToInt32(dtrow["ID"]),
                    FeatureName = dtrow["FeatureName"].ToString().Trim(),
                    PID = Convert.ToInt32(dtrow["PID"]),
                    SubFeatures = child
                });
            }

            rptCategories.DataSource = lst;
            rptCategories.DataBind();
        }

        protected void ddlcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindproduct();
        }
        protected void bindproduct()
        {
            int cid = Convert.ToInt32(ddlcategory.SelectedValue);
            DataSet ds = cls.ViewAllProductbyCId(cid);
            cmf.BindDropDownList(ddlproduct, ds, "ProductName", "id");
            ListItem li = new ListItem("Select", "0");
            ddlproduct.Items.Insert(0, li);
        }
        protected void bindvariant()
        {
            int pid = Convert.ToInt32(ddlproduct.SelectedValue);
            DataSet ds = cls.SelectVariantByProductID(pid);
            cmf.BindDropDownList(ddlModel, ds, "Variant", "id");
            ListItem li = new ListItem("Select", "0");
            ddlModel.Items.Insert(0, li);
        }
        protected void ddlproduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindvariant();
        }

        protected void ddlSellerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblSeller.InnerText = ddlSellerType.SelectedItem.Text;
            if (ddlSellerType.SelectedValue == "-1")
            {
                pnlother.Visible = true;
                pnlseller.Visible = false;
            }
            else
            {
                if (ddlSellerType.SelectedValue == "3")
                {
                    divAuctionDate.Visible = true;
                    divAuctionSource.Visible = true;
                }
                else
                {
                    divAuctionDate.Visible = false;
                    divAuctionSource.Visible = false;
                }
                pnlother.Visible = false;
                pnlseller.Visible = true;
                bindSellerMaster(ddlSellerType.SelectedValue);
            }
        }
        protected void bindSellerMaster(string type)
        {
            DataSet ds = _clsA.SelectSellerMaster(type);
            cmf.BindDropDownList(ddlSeller, ds, "Name", "id");
            ListItem li = new ListItem("Select", "0");
            ddlSeller.Items.Insert(0, li);
            if (type == "3")
            {
                cmf.BindDropDownList(ddlAuctionSource, ds, "Name", "id");
                li = new ListItem("Select", "0");
                ddlAuctionSource.Items.Insert(0, li);
            }
        }
        protected void bindImages()
        {
            string id = cmf.Decrypt(hdnid.Value);
            DataSet ds = _clsA.SelectPurchaseAdditionalInfo(id, "Image");
            rptFiles.DataSource = ds;
            rptFiles.DataBind();
            string str = string.Empty;
            if (ds.Tables[0].Rows.Count > 0)
            {
                filesPreview.Attributes.Remove("class");
                filesPreview.Attributes.Add("class", "files-preview show");
                uploadBox.Visible = false;
            }
            else
            {
                filesPreview.Attributes.Remove("class");
                filesPreview.Attributes.Add("class", "files-preview");
                uploadBox.Visible = true;
            }
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (str != string.Empty)
                {
                    str += "," + ds.Tables[0].Rows[i]["sID"].ToString();
                }
                else
                {
                    str = ds.Tables[0].Rows[i]["sID"].ToString();
                }
            }
            ViewState["Images"] = str;
        }
        protected void btnupload_Click(object sender, EventArgs e)
        {
            try
            {
                pnlerror.Visible = false;
                lblnooffilesuploaded.Text = "";
                lblmsg.Text = "";
                string[] allowedMimeTypes = { "image/JPG", "image/JPEG", "image/PNG", "image/x-png", "image/pjpeg" };
                List<string> messages;
                string docName = txtChassisNo.Text.Trim();
                List<string> uploadedFiles = FileUploadUtility.UploadMultipleFiles(flpupload, docName, "CarImageUploadPath", allowedMimeTypes, 2048, out messages);
                string str = string.Empty;
                string error = string.Empty;
                for (int i = 0; i < messages.Count; i++)
                {
                    string msg = messages[i];
                    if (error != string.Empty)
                    {
                        error += "|" + msg;
                    }
                    else
                    {
                        error = msg;
                    }
                }
                for (int i = 0; i < uploadedFiles.Count; i++)
                {
                    string filePath = uploadedFiles[i];
                    if (str != string.Empty)
                    {
                        str += "," + filePath;
                    }
                    else
                    {
                        str = filePath;
                    }
                }
                if (uploadedFiles.Count > 0)
                {
                    lblnooffilesuploaded.Text = uploadedFiles.Count.ToString();
                }

                if (str != string.Empty)
                {
                    if (ViewState["Images"] != null && ViewState["Images"].ToString() != string.Empty)
                    {
                        str = ViewState["Images"].ToString() + "," + str;
                    }
                    entPurchase_Media _obj = new entPurchase_Media();
                    _obj.PID = cmf.Decrypt(hdnid.Value);
                    _obj.Data = str;
                    _obj.uid = uid;
                    _obj.mtype = "ImageUrl";
                    _clsA.insertPurchaseAdditionalInfo(_obj);
                    bindImages();

                }
                if (error != string.Empty)
                {
                    pnlerror.Visible = true;
                    lblmsg.Text = error;
                }
                if (lblnooffilesuploaded.Text != string.Empty)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "showUploadComplete", @"<script type='text/javascript'>
                    document.getElementById('uploadComplete').style.display = 'block';  setTimeout(() => {
                const uploadCompleteDiv = document.getElementById('uploadComplete');
                if (uploadCompleteDiv) {                 
                    uploadCompleteDiv.style.transition = 'opacity 1s ease';
                    uploadCompleteDiv.style.opacity = '0';             
                    setTimeout(() => {
                        uploadCompleteDiv.style.display = 'none';
                    }, 1000); 
                }
            }, 3000);</script>");
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", "Something went wrong. Please try again!!");
                ExceptionLogging.LogError(ex.Message);
            }
        }
        protected void rptFiles_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                pnlerror.Visible = false;
                lblnooffilesuploaded.Text = "";
                lblmsg.Text = "";
                if (e.CommandName == "Delete")
                {
                    string img = e.CommandArgument.ToString();
                    string images = ViewState["Images"].ToString();
                    List<string> imageList = images.Split(',').ToList();
                    imageList.Remove(img);
                    string physicalPath = Server.MapPath(img);
                    if (File.Exists(physicalPath))
                    {
                        File.Delete(physicalPath);
                    }
                    string result = string.Join(",", imageList);
                    entPurchase_Media _obj = new entPurchase_Media();
                    _obj.PID = cmf.Decrypt(hdnid.Value);
                    _obj.Data = result;
                    _obj.uid = uid;
                    _obj.mtype = "ImageUrl";
                    _clsA.insertPurchaseAdditionalInfo(_obj);
                    if (result == string.Empty)
                    {
                        ViewState["Images"] = null;
                    }
                    bindImages();
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", "Something went wrong. Please try again!!");
                ExceptionLogging.LogError(ex.Message);
            }
        }

        protected void addMoreBtn_Click(object sender, EventArgs e)
        {
            lblnooffilesuploaded.Text = "";
            lblmsg.Text = "";
            pnlerror.Visible = false;
            hdnuploaded.Value = "0";
            filesPreview.Attributes.Remove("class");
            filesPreview.Attributes.Add("class", "files-preview show");
            uploadBox.Visible = true;
        }

        protected string GetSelectedFeatureIds()
        {
            List<string> selectedFeatureIds = new List<string>();

            foreach (RepeaterItem categoryItem in rptCategories.Items)
            {
                Repeater rptFeatures = (Repeater)categoryItem.FindControl("rptFeatures");

                foreach (RepeaterItem featureItem in rptFeatures.Items)
                {
                    CheckBox chkFeature = (CheckBox)featureItem.FindControl("chkFeature");
                    if (chkFeature != null && chkFeature.Checked)
                    {
                        string featureId = chkFeature.Attributes["data-id"];
                        if (!string.IsNullOrEmpty(featureId))
                        {
                            selectedFeatureIds.Add(featureId);
                        }
                    }
                }
            }
            return string.Join(",", selectedFeatureIds);
        }
        protected void rptCategories_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    var data = (entFeaturesMaster)e.Item.DataItem;
                    Repeater rptFeatures = (Repeater)e.Item.FindControl("rptFeatures");
                    rptFeatures.DataSource = data.SubFeatures;
                    rptFeatures.DataBind();

                    foreach (RepeaterItem featureItem in rptFeatures.Items)
                    {
                        CheckBox chkFeature = (CheckBox)featureItem.FindControl("chkFeature");
                        if (chkFeature != null)
                        {
                            string featureId = chkFeature.Attributes["data-id"];
                            if (!string.IsNullOrEmpty(featureId))
                            {
                                if (("," + selectedFeatureIds + ",").Contains("," + featureId + ","))
                                {
                                    chkFeature.Checked = true;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", "Something went wrong. Please try again!!");
                ExceptionLogging.LogError(ex.Message);
            }
        }
        protected void btnsavefeature_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedIds = GetSelectedFeatureIds();
                entPurchase_Media _obj = new entPurchase_Media();
                _obj.PID = cmf.Decrypt(hdnid.Value);
                _obj.Data = selectedIds;
                _obj.uid = uid;
                _obj.mtype = "Features";
                _clsA.insertPurchaseAdditionalInfo(_obj);
                bindSelectedFeatures();
                CommonFunction.MessageBox(this, "S", "Features saved successfully!!");
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", "Something went wrong. Please try again!!");
                ExceptionLogging.LogError(ex.Message);
            }
        }
        string selectedFeatureIds = "";
        protected void bindSelectedFeatures()
        {
            string id = cmf.Decrypt(hdnid.Value);
            DataSet ds = _clsA.SelectPurchaseAdditionalInfo(id, "Feature");
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Features"].ToString() != string.Empty)
                {
                    selectedFeatureIds = ds.Tables[0].Rows[0]["Features"].ToString();
                }
            }
        }

        protected void TabContainer2_ActiveTabChanged(object sender, EventArgs e)
        {

        }

        #region Left Side Defects
        protected void bindImages_Left()
        {
            string id = cmf.Decrypt(hdnid.Value);
            DataSet ds = _clsA.SelectPurchaseAdditionalInfo(id, "Left");
            rptLeft.DataSource = ds;
            rptLeft.DataBind();
            string str = string.Empty;
            if (ds.Tables[0].Rows.Count > 0)
            {
                filesPreview_Left.Attributes.Remove("class");
                filesPreview_Left.Attributes.Add("class", "files-preview show");
                uploadBox_Left.Visible = false;
            }
            else
            {
                filesPreview_Left.Attributes.Remove("class");
                filesPreview_Left.Attributes.Add("class", "files-preview");
                uploadBox_Left.Visible = true;
            }
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (str != string.Empty)
                {
                    str += "," + ds.Tables[0].Rows[i]["sID"].ToString();
                }
                else
                {
                    str = ds.Tables[0].Rows[i]["sID"].ToString();
                }
            }
            ViewState["Left"] = str;
        }
        protected void btnupload_Left_Click(object sender, EventArgs e)
        {
            try
            {
                lblerrorDefects.Text = "";
                pnlErrorDefects.Visible = false;
                string[] allowedMimeTypes = { "image/JPG", "image/JPEG", "image/PNG", "image/x-png", "image/pjpeg" };
                List<string> messages;
                string docName = txtChassisNo.Text.Trim();
                List<string> uploadedFiles = FileUploadUtility.UploadMultipleFiles(flpupload_Left, docName, "CarImageUploadPath", allowedMimeTypes, 2048, out messages);
                string str = string.Empty;
                string error = string.Empty;
                for (int i = 0; i < messages.Count; i++)
                {
                    string msg = messages[i];
                    if (error != string.Empty)
                    {
                        error += "|" + msg;
                    }
                    else
                    {
                        error = msg;
                    }
                }
                for (int j = 0; j < uploadedFiles.Count; j++)
                {
                    string filePath = uploadedFiles[j];
                    Response.Write(filePath + "|");
                    if (str != string.Empty)
                    {
                        str += "," + filePath;
                    }
                    else
                    {
                        str = filePath;
                    }
                }

                if (str != string.Empty)
                {
                    if (ViewState["Left"] != null && ViewState["Left"].ToString() != string.Empty)
                    {
                        str = ViewState["Left"].ToString() + "," + str;
                    }
                    entPurchase_Media _obj = new entPurchase_Media();
                    _obj.PID = cmf.Decrypt(hdnid.Value);
                    _obj.Data = str;
                    _obj.uid = uid;
                    _obj.mtype = "LeftSide";
                    _clsA.insertPurchaseAdditionalInfo(_obj);
                    bindImages_Left();

                }
                if (error != string.Empty)
                {
                    pnlErrorDefects.Visible = true;
                    lblerrorDefects.Text = error;
                }

            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", "Something went wrong. Please try again!!");
                ExceptionLogging.LogError(ex.Message);
            }
        }
        protected void rptLeft_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                lblerrorDefects.Text = "";
                pnlErrorDefects.Visible = false;
                if (e.CommandName == "Delete")
                {
                    string img = e.CommandArgument.ToString();
                    string images = ViewState["Left"].ToString();
                    List<string> imageList = images.Split(',').ToList();
                    imageList.Remove(img);
                    string physicalPath = Server.MapPath(img);
                    if (File.Exists(physicalPath))
                    {
                        File.Delete(physicalPath);
                    }
                    string result = string.Join(",", imageList);
                    entPurchase_Media _obj = new entPurchase_Media();
                    _obj.PID = cmf.Decrypt(hdnid.Value);
                    _obj.Data = result;
                    _obj.uid = uid;
                    _obj.mtype = "LeftSide";
                    _clsA.insertPurchaseAdditionalInfo(_obj);
                    if (result == string.Empty)
                    {
                        ViewState["Left"] = null;
                    }
                    bindImages_Left();
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", "Something went wrong. Please try again!!");
                ExceptionLogging.LogError(ex.Message);
            }
        }

        protected void btnadd_Left_Click(object sender, EventArgs e)
        {
            lblerrorDefects.Text = "";
            pnlErrorDefects.Visible = false;
            filesPreview_Left.Attributes.Remove("class");
            filesPreview_Left.Attributes.Add("class", "files-preview show");
            uploadBox_Left.Visible = true;
        }

        #endregion

        #region Right Side Defects
        protected void bindImages_Right()
        {
            string id = cmf.Decrypt(hdnid.Value);
            DataSet ds = _clsA.SelectPurchaseAdditionalInfo(id, "Right");
            rptRight.DataSource = ds;
            rptRight.DataBind();
            string str = string.Empty;
            if (ds.Tables[0].Rows.Count > 0)
            {
                filesPreview_Right.Attributes.Remove("class");
                filesPreview_Right.Attributes.Add("class", "files-preview show");
                uploadBox_Right.Visible = false;
            }
            else
            {
                filesPreview_Right.Attributes.Remove("class");
                filesPreview_Right.Attributes.Add("class", "files-preview");
                uploadBox_Right.Visible = true;
            }
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (str != string.Empty)
                {
                    str += "," + ds.Tables[0].Rows[i]["sID"].ToString();
                }
                else
                {
                    str = ds.Tables[0].Rows[i]["sID"].ToString();
                }
            }
            ViewState["Right"] = str;
        }
        protected void btnupload_Right_Click(object sender, EventArgs e)
        {
            try
            {
                lblerrorDefects.Text = "";
                pnlErrorDefects.Visible = false;
                string[] allowedMimeTypes = { "image/JPG", "image/JPEG", "image/PNG", "image/x-png", "image/pjpeg" };
                List<string> messages;
                string docName = txtChassisNo.Text.Trim();
                List<string> uploadedFiles = FileUploadUtility.UploadMultipleFiles(flpupload_Right, docName, "CarImageUploadPath", allowedMimeTypes, 2048, out messages);
                string str = string.Empty;
                string error = string.Empty;
                for (int i = 0; i < messages.Count; i++)
                {
                    string msg = messages[i];
                    if (error != string.Empty)
                    {
                        error += "|" + msg;
                    }
                    else
                    {
                        error = msg;
                    }
                }
                for (int j = 0; j < uploadedFiles.Count; j++)
                {
                    string filePath = uploadedFiles[j];
                    Response.Write(filePath + "|");
                    if (str != string.Empty)
                    {
                        str += "," + filePath;
                    }
                    else
                    {
                        str = filePath;
                    }
                }

                if (str != string.Empty)
                {
                    if (ViewState["Right"] != null && ViewState["Right"].ToString() != string.Empty)
                    {
                        str = ViewState["Right"].ToString() + "," + str;
                    }
                    entPurchase_Media _obj = new entPurchase_Media();
                    _obj.PID = cmf.Decrypt(hdnid.Value);
                    _obj.Data = str;
                    _obj.uid = uid;
                    _obj.mtype = "RightSide";
                    _clsA.insertPurchaseAdditionalInfo(_obj);
                    bindImages_Right();

                }
                if (error != string.Empty)
                {
                    pnlErrorDefects.Visible = true;
                    lblerrorDefects.Text = error;
                }

            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", "Something went wrong. Please try again!!");
                ExceptionLogging.LogError(ex.Message);
            }
        }
        protected void rptRight_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                lblerrorDefects.Text = "";
                pnlErrorDefects.Visible = false;
                if (e.CommandName == "Delete")
                {
                    string img = e.CommandArgument.ToString();
                    string images = ViewState["Right"].ToString();
                    List<string> imageList = images.Split(',').ToList();
                    imageList.Remove(img);
                    string physicalPath = Server.MapPath(img);
                    if (File.Exists(physicalPath))
                    {
                        File.Delete(physicalPath);
                    }
                    string result = string.Join(",", imageList);
                    entPurchase_Media _obj = new entPurchase_Media();
                    _obj.PID = cmf.Decrypt(hdnid.Value);
                    _obj.Data = result;
                    _obj.uid = uid;
                    _obj.mtype = "RightSide";
                    _clsA.insertPurchaseAdditionalInfo(_obj);
                    if (result == string.Empty)
                    {
                        ViewState["Right"] = null;
                    }
                    bindImages_Right();
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", "Something went wrong. Please try again!!");
                ExceptionLogging.LogError(ex.Message);
            }
        }

        protected void btnadd_Right_Click(object sender, EventArgs e)
        {
            lblerrorDefects.Text = "";
            pnlErrorDefects.Visible = false;
            filesPreview_Right.Attributes.Remove("class");
            filesPreview_Right.Attributes.Add("class", "files-preview show");
            uploadBox_Right.Visible = true;
        }

        #endregion

        #region Front Side Defects
        protected void bindImages_Front()
        {
            string id = cmf.Decrypt(hdnid.Value);
            DataSet ds = _clsA.SelectPurchaseAdditionalInfo(id, "Front");
            rptFront.DataSource = ds;
            rptFront.DataBind();
            string str = string.Empty;
            if (ds.Tables[0].Rows.Count > 0)
            {
                filesPreview_Front.Attributes.Remove("class");
                filesPreview_Front.Attributes.Add("class", "files-preview show");
                uploadBox_Front.Visible = false;
            }
            else
            {
                filesPreview_Front.Attributes.Remove("class");
                filesPreview_Front.Attributes.Add("class", "files-preview");
                uploadBox_Front.Visible = true;
            }
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (str != string.Empty)
                {
                    str += "," + ds.Tables[0].Rows[i]["sID"].ToString();
                }
                else
                {
                    str = ds.Tables[0].Rows[i]["sID"].ToString();
                }
            }
            ViewState["Front"] = str;
        }
        protected void btnupload_Front_Click(object sender, EventArgs e)
        {
            try
            {
                lblerrorDefects.Text = "";
                pnlErrorDefects.Visible = false;
                string[] allowedMimeTypes = { "image/JPG", "image/JPEG", "image/PNG", "image/x-png", "image/pjpeg" };
                List<string> messages;
                string docName = txtChassisNo.Text.Trim();
                List<string> uploadedFiles = FileUploadUtility.UploadMultipleFiles(flpupload_Front, docName, "CarImageUploadPath", allowedMimeTypes, 2048, out messages);
                string str = string.Empty;
                string error = string.Empty;
                for (int i = 0; i < messages.Count; i++)
                {
                    string msg = messages[i];
                    if (error != string.Empty)
                    {
                        error += "|" + msg;
                    }
                    else
                    {
                        error = msg;
                    }
                }
                for (int j = 0; j < uploadedFiles.Count; j++)
                {
                    string filePath = uploadedFiles[j];

                    if (str != string.Empty)
                    {
                        str += "," + filePath;
                    }
                    else
                    {
                        str = filePath;
                    }
                }

                if (str != string.Empty)
                {
                    if (ViewState["Front"] != null && ViewState["Front"].ToString() != string.Empty)
                    {
                        str = ViewState["Front"].ToString() + "," + str;
                    }
                    entPurchase_Media _obj = new entPurchase_Media();
                    _obj.PID = cmf.Decrypt(hdnid.Value);
                    _obj.Data = str;
                    _obj.uid = uid;
                    _obj.mtype = "FrontSide";
                    _clsA.insertPurchaseAdditionalInfo(_obj);
                    bindImages_Front();

                }
                if (error != string.Empty)
                {
                    pnlErrorDefects.Visible = true;
                    lblerrorDefects.Text = error;
                }

            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", "Something went wrong. Please try again!!");
                ExceptionLogging.LogError(ex.Message);
            }
        }
        protected void rptFront_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                lblerrorDefects.Text = "";
                pnlErrorDefects.Visible = false;
                if (e.CommandName == "Delete")
                {
                    string img = e.CommandArgument.ToString();
                    string images = ViewState["Front"].ToString();
                    List<string> imageList = images.Split(',').ToList();
                    imageList.Remove(img);
                    string physicalPath = Server.MapPath(img);
                    if (File.Exists(physicalPath))
                    {
                        File.Delete(physicalPath);
                    }
                    string result = string.Join(",", imageList);
                    entPurchase_Media _obj = new entPurchase_Media();
                    _obj.PID = cmf.Decrypt(hdnid.Value);
                    _obj.Data = result;
                    _obj.uid = uid;
                    _obj.mtype = "FrontSide";
                    _clsA.insertPurchaseAdditionalInfo(_obj);
                    if (result == string.Empty)
                    {
                        ViewState["Front"] = null;
                    }
                    bindImages_Front();
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", "Something went wrong. Please try again!!");
                ExceptionLogging.LogError(ex.Message);
            }
        }

        protected void btnadd_Front_Click(object sender, EventArgs e)
        {
            lblerrorDefects.Text = "";
            pnlErrorDefects.Visible = false;
            filesPreview_Front.Attributes.Remove("class");
            filesPreview_Front.Attributes.Add("class", "files-preview show");
            uploadBox_Front.Visible = true;
        }

        #endregion

        #region Rear Side Defects
        protected void bindImages_Rear()
        {
            string id = cmf.Decrypt(hdnid.Value);
            DataSet ds = _clsA.SelectPurchaseAdditionalInfo(id, "Rear");
            rptRear.DataSource = ds;
            rptRear.DataBind();
            string str = string.Empty;
            if (ds.Tables[0].Rows.Count > 0)
            {
                filesPreview_Rear.Attributes.Remove("class");
                filesPreview_Rear.Attributes.Add("class", "files-preview show");
                uploadBox_Rear.Visible = false;
            }
            else
            {
                filesPreview_Rear.Attributes.Remove("class");
                filesPreview_Rear.Attributes.Add("class", "files-preview");
                uploadBox_Rear.Visible = true;
            }
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (str != string.Empty)
                {
                    str += "," + ds.Tables[0].Rows[i]["sID"].ToString();
                }
                else
                {
                    str = ds.Tables[0].Rows[i]["sID"].ToString();
                }
            }
            ViewState["Rear"] = str;
        }
        protected void btnupload_Rear_Click(object sender, EventArgs e)
        {
            try
            {
                lblerrorDefects.Text = "";
                pnlErrorDefects.Visible = false;
                string[] allowedMimeTypes = { "image/JPG", "image/JPEG", "image/PNG", "image/x-png", "image/pjpeg" };
                List<string> messages;
                string docName = txtChassisNo.Text.Trim();
                List<string> uploadedFiles = FileUploadUtility.UploadMultipleFiles(flpupload_Rear, docName, "CarImageUploadPath", allowedMimeTypes, 2048, out messages);
                string str = string.Empty;
                string error = string.Empty;
                for (int i = 0; i < messages.Count; i++)
                {
                    string msg = messages[i];
                    if (error != string.Empty)
                    {
                        error += "|" + msg;
                    }
                    else
                    {
                        error = msg;
                    }
                }
                for (int j = 0; j < uploadedFiles.Count; j++)
                {
                    string filePath = uploadedFiles[j];
                    Response.Write(filePath + "|");
                    if (str != string.Empty)
                    {
                        str += "," + filePath;
                    }
                    else
                    {
                        str = filePath;
                    }
                }

                if (str != string.Empty)
                {
                    if (ViewState["Rear"] != null && ViewState["Rear"].ToString() != string.Empty)
                    {
                        str = ViewState["Rear"].ToString() + "," + str;
                    }
                    entPurchase_Media _obj = new entPurchase_Media();
                    _obj.PID = cmf.Decrypt(hdnid.Value);
                    _obj.Data = str;
                    _obj.uid = uid;
                    _obj.mtype = "RearSide";
                    _clsA.insertPurchaseAdditionalInfo(_obj);
                    bindImages_Rear();

                }
                if (error != string.Empty)
                {
                    pnlErrorDefects.Visible = true;
                    lblerrorDefects.Text = error;
                }

            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", "Something went wrong. Please try again!!");
                ExceptionLogging.LogError(ex.Message);
            }
        }
        protected void rptRear_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                lblerrorDefects.Text = "";
                pnlErrorDefects.Visible = false;
                if (e.CommandName == "Delete")
                {
                    string img = e.CommandArgument.ToString();
                    string images = ViewState["Rear"].ToString();
                    List<string> imageList = images.Split(',').ToList();
                    imageList.Remove(img);
                    string physicalPath = Server.MapPath(img);
                    if (File.Exists(physicalPath))
                    {
                        File.Delete(physicalPath);
                    }
                    string result = string.Join(",", imageList);
                    entPurchase_Media _obj = new entPurchase_Media();
                    _obj.PID = cmf.Decrypt(hdnid.Value);
                    _obj.Data = result;
                    _obj.uid = uid;
                    _obj.mtype = "RearSide";
                    _clsA.insertPurchaseAdditionalInfo(_obj);
                    if (result == string.Empty)
                    {
                        ViewState["Rear"] = null;
                    }
                    bindImages_Rear();
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", "Something went wrong. Please try again!!");
                ExceptionLogging.LogError(ex.Message);
            }
        }

        protected void btnadd_Rear_Click(object sender, EventArgs e)
        {
            lblerrorDefects.Text = "";
            pnlErrorDefects.Visible = false;
            filesPreview_Rear.Attributes.Remove("class");
            filesPreview_Rear.Attributes.Add("class", "files-preview show");
            uploadBox_Rear.Visible = true;
        }

        #endregion

        #region Documents 
        protected void bind_Documents()
        {
            string id = cmf.Decrypt(hdnid.Value);
            DataSet ds = _clsA.SelectPurchaseAdditionalInfo(id, "Document");
            rptDocuments.DataSource = ds;
            rptDocuments.DataBind();
            string str = string.Empty;
            if (ds.Tables[0].Rows.Count > 0)
            {
                filesPreview_Documents.Attributes.Remove("class");
                filesPreview_Documents.Attributes.Add("class", "files-preview show");
                uploadBox_Documents.Visible = false;
            }
            else
            {
                filesPreview_Documents.Attributes.Remove("class");
                filesPreview_Documents.Attributes.Add("class", "files-preview");
                uploadBox_Documents.Visible = true;
            }
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (str != string.Empty)
                {
                    str += "," + ds.Tables[0].Rows[i]["sID"].ToString();
                }
                else
                {
                    str = ds.Tables[0].Rows[i]["sID"].ToString();
                }
            }
            ViewState["Documents"] = str;
        }
        protected void btnupload_Documents_Click(object sender, EventArgs e)
        {
            try
            {
                pnlErrorDocuments.Visible = false;
                lblerrorDocuments.Text = "";
                string[] allowedMimeTypes = { "image/JPG", "image/JPEG", "image/PNG", "image/x-png", "image/pjpeg", "application/pdf" };
                List<string> messages;
                string docName = txtChassisNo.Text.Trim();
                List<string> uploadedFiles = FileUploadUtility.UploadMultipleFiles(flpupload_Documents, docName, "CarImageUploadPath", allowedMimeTypes, 2048, out messages);
                string str = string.Empty;
                string error = string.Empty;
                for (int i = 0; i < messages.Count; i++)
                {
                    string msg = messages[i];
                    if (error != string.Empty)
                    {
                        error += "|" + msg;
                    }
                    else
                    {
                        error = msg;
                    }
                }
                for (int j = 0; j < uploadedFiles.Count; j++)
                {
                    string filePath = uploadedFiles[j];
                    Response.Write(filePath + "|");
                    if (str != string.Empty)
                    {
                        str += "," + filePath;
                    }
                    else
                    {
                        str = filePath;
                    }
                }

                if (str != string.Empty)
                {
                    if (ViewState["Documents"] != null && ViewState["Documents"].ToString() != string.Empty)
                    {
                        str = ViewState["Documents"].ToString() + "," + str;
                    }
                    entPurchase_Media _obj = new entPurchase_Media();
                    _obj.PID = cmf.Decrypt(hdnid.Value);
                    _obj.Data = str;
                    _obj.uid = uid;
                    _obj.mtype = "Documents";
                    _clsA.insertPurchaseAdditionalInfo(_obj);
                    bind_Documents();

                }
                if (error != string.Empty)
                {
                    pnlErrorDocuments.Visible = true;
                    lblerrorDocuments.Text = error;
                }

            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", "Something went wrong. Please try again!!");
                ExceptionLogging.LogError(ex.Message);
            }
        }
        protected void rptDocuments_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                pnlErrorDocuments.Visible = false;
                lblerrorDocuments.Text = "";
                if (e.CommandName == "Delete")
                {
                    string img = e.CommandArgument.ToString();
                    string images = ViewState["Documents"].ToString();
                    List<string> imageList = images.Split(',').ToList();
                    imageList.Remove(img);
                    string physicalPath = Server.MapPath(img);
                    if (File.Exists(physicalPath))
                    {
                        File.Delete(physicalPath);
                    }
                    string result = string.Join(",", imageList);
                    entPurchase_Media _obj = new entPurchase_Media();
                    _obj.PID = cmf.Decrypt(hdnid.Value);
                    _obj.Data = result;
                    _obj.uid = uid;
                    _obj.mtype = "Documents";
                    _clsA.insertPurchaseAdditionalInfo(_obj);
                    if (result == string.Empty)
                    {
                        ViewState["Documents"] = null;
                    }
                    bind_Documents();
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", "Something went wrong. Please try again!!");
                ExceptionLogging.LogError(ex.Message);
            }
        }

        protected void btnadd_Documents_Click(object sender, EventArgs e)
        {
            lblerrorDocuments.Text = "";
            pnlErrorDocuments.Visible = false;
            filesPreview_Documents.Attributes.Remove("class");
            filesPreview_Documents.Attributes.Add("class", "files-preview show");
            uploadBox_Documents.Visible = true;
        }
        protected bool IsImageFile(object fileName)
        {
            if (fileName == null) return false;

            string[] imageExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".webp" };
            string ext = System.IO.Path.GetExtension(fileName.ToString()).ToLower();
            return imageExtensions.Contains(ext);
        }
        #endregion


    }
}