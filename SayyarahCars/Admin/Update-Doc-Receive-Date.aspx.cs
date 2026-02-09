using COMMON;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using ENTITY;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SayyarahCars.Admin
{
    public partial class Update_Doctument_Receive_Date : System.Web.UI.Page
    {
        CommonFunction cmf = new CommonFunction();
        DataSet ds = new DataSet();
        clsAdmin cls = new clsAdmin();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtADate.Text = (DateTime.Now).ToString();
            }
        }


        public void BindStatus( int PageI=1)
        {
            try
            {
                DataSet Ds = new DataSet();
                string FounderMinus = "";
                string Found = txtAllChassisNo.Text;
                if (Found != "")
                {
                    FounderMinus = Found.Remove(Found.Length - 1, 1);
                    Ds = cls.GetUpdateDocRDByChassisNo(FounderMinus);
                    if (Ds.Tables[0].Rows.Count > 0)
                    {
                        ViewState["DataTable"] = Ds.Tables[0];
                        GridView1.DataSource = Ds.Tables[0];
                        GridView1.DataBind();
                        Divb.Visible = true;
                    }
                    else
                    {
                        GridView1.DataSource = Ds.Tables[0];
                        GridView1.DataBind();
                        Divb.Visible = false;
                        CommonFunction.MessageBox(this, "E", "No Record Found");
                    }

                }
                else
                {


                    string PageIndex = PageI.ToString();
                    UpdateDocReceiveDate obj = new UpdateDocReceiveDate();
                    obj.ADate = txtADate.Text;
                    obj.Urgent = ddlurgent.SelectedValue;                    
                    obj.PageIndex = PageIndex;
                    obj.PageSize = ddlPageSize.SelectedValue;
                    Ds = cls.GetAllUpdateDocRD(obj);
                    if (Ds.Tables[0].Rows.Count > 0)
                    {

                        GridView1.DataSource = Ds.Tables[0];
                        GridView1.PageSize = int.Parse(ddlPageSize.SelectedValue);
                        GridView1.VirtualItemCount = Convert.ToInt32(Ds.Tables[1].Rows[0][0]);
                        GridView1.DataBind();
                        Divb.Visible = true;
                    }

                    else
                    {
                        GridView1.DataSource = Ds.Tables[0];
                        GridView1.DataBind();
                        Divb.Visible = false;
                        CommonFunction.MessageBox(this, "E", "No Record Found");
                    }
                } 
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
           

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            BindStatus();
        }

       
        protected void BtnUpdateStatus_Click(object sender, EventArgs e)
        {
            int i = 0;
            int temp = 0;
            try
            {
                foreach(GridViewRow row in GridView1.Rows)
                {
                    CheckBox chk = row.FindControl("Chkbox") as CheckBox;
                    if (chk.Checked)
                    {
                        Label lbl = row.FindControl("Label1") as Label;                        
                        UserControl uc = row.FindControl("TxtDRDate") as UserControl;
                        TextBox TxtDRDate = uc.FindControl("txt_Date") as TextBox;
                        if (TxtDRDate.Text != "")
                        {
                           
                            temp = cls.UpdateDataForUDRD(lbl.Text, Convert.ToDateTime(TxtDRDate.Text).ToString("yyyy-MM-dd"));
                            if (temp > 0)
                            {
                                i = i + 1;

                            }

                        }
                        else
                        {
                            temp = cls.UpdateDataForUDRD(lbl.Text, TxtDRDate.Text);
                            if (temp > 0)
                            {
                                i = 1 + 1;
                            }

                        }
                    }                    
                    
                }
                if (i > 0)
                {
                    CommonFunction.MessageBox(this, "S", "Data Updated Successfully");
                    BindStatus();
                }
                else
                {
                    CommonFunction.MessageBox(this, "E", "Select at least one record to update"); 
                }
            }
            catch(Exception ex)
            {
                string s = ex.Message;
            }
        }

        

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindStatus(e.NewPageIndex + 1);
        }
    }
}