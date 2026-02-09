using COMMON;
using DAL;
using ENTITY;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ListItem = System.Web.UI.WebControls.ListItem;

namespace SayyarahCars.Admin
{
    public partial class Update_Loading_Surrender : System.Web.UI.Page
    {
        CommonFunction cmf = new CommonFunction();
        clsAdmin clsA = new clsAdmin();
        public string uid = "0";
        SendMail sm = new SendMail();
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
                    BindAllDropDown();
                    Divserver.Visible = false;
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }
        public void BindAllDropDown()
        {
            try
            {
                DataSet ds = clsA.GetSDropDown();
                cmf.BindDropDownList(ddlShippingC, ds, "ShippingName", "Id", 0);
                ddlShippingC.Items.Insert(0, new ListItem("--Select Shipping--", "0"));

                cmf.BindDropDownList(ddlClient, ds, "ClientName", "id", 1);
                ddlClient.Items.Insert(0, new ListItem("--Select Client--", "0"));

               
                cmf.BindDropDownList(ddlPort, ds, "PortName", "ID", 2);
                ddlPort.Items.Insert(0, new ListItem("--Select Port--", "0"));

                cmf.BindDropDownList(ddlShip, ds, "ShipName", "Id", 3);
                ddlShip.Items.Insert(0, new ListItem("--Select Ship--", "0"));

                cmf.BindDropDownList(ddlBroker, ds, "BrokerName", "Id", 4);
                ddlBroker.Items.Insert(0, new ListItem("--Select Broker--", "0"));
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
            BindData(e.NewPageIndex + 1);
        }
        public void BindData(int pageIndex = 1)
        {
            try
            {
                DataSet ds = new DataSet();
                UpdateLoadingSurrender obj = new UpdateLoadingSurrender();
                obj.ShippingId = ddlShippingC.SelectedValue;
                obj.ClientId = ddlClient.SelectedValue;
                obj.PortId = ddlPort.SelectedValue;
                obj.ShipId = ddlShip.SelectedValue;
                obj.SurrenderId = ddlSurrender.SelectedValue;
                obj.BrokerId = ddlBroker.SelectedValue;
                obj.ChassisNo = txtChassisNo.Text.Trim();
                obj.PageIndex = pageIndex.ToString();
                obj.PageSize = ddlshortby.SelectedValue;
                ds = clsA.GetAllLoadingSurrender(obj);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ViewState["DataTable"] = ds.Tables[0];
                    GridView1.PageSize = int.Parse(ddlshortby.SelectedValue);
                    GridView1.VirtualItemCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
                    GridView1.DataSource = ds.Tables[0];
                    GridView1.DataBind();
                    Divserver.Visible = true;
                }
                else
                {
                    Divserver.Visible = false;
                    GridView1.DataSource = ds.Tables[0];
                    GridView1.DataBind();
                    CommonFunction.MessageBox(this, "E", "No record found");
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            BindData();
            if (ddlShippingC.SelectedValue != "0")
            {
                DataSet ds = new DataSet();
                ds = clsA.GetShippingEmail(Convert.ToInt32(ddlShippingC.SelectedValue));
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    HiddenField1.Value = ds.Tables[0].Rows[0][0].ToString();
                    HiddenField2.Value = ds.Tables[0].Rows[0][1].ToString();
                    HiddenField3.Value = ds.Tables[0].Rows[0][2].ToString();

                }
            }
        }


        protected void btnSurrNo_Click(object sender, EventArgs e)
        {
            int status = 0;
            int i = 0;
            try
            {
                foreach (GridViewRow row in GridView1.Rows)
                {
                    CheckBox chk = row.FindControl("Chkbox") as CheckBox;
                    if (chk.Checked)
                    {
                        Label lblid = row.FindControl("lblpid") as Label;
                        int temp = clsA.UpdateSurrender(lblid.Text, status, Session["AID"].ToString());
                        if (temp > 0)
                        {
                            i = i + 1;
                        }
                    }
                }
                if (i > 0)
                {
                    CommonFunction.MessageBox(this, "S", "Surrender No Update successfully");
                    BindData();
                }
                else
                {
                    CommonFunction.MessageBox(this, "E", "Select atleast one record to update");
                    BindData();
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void btnloadYes_Click(object sender, EventArgs e)
        {
            int status = 1;
            int i = 0;
            try
            {
                foreach (GridViewRow row in GridView1.Rows)
                {
                    CheckBox chk = row.FindControl("Chkbox") as CheckBox;
                    if (chk.Checked)
                    {
                        Label lblid = row.FindControl("lblpid") as Label;
                        int temp = clsA.UpdateLoading(lblid.Text, status, Session["AID"].ToString());
                        if (temp > 0)
                        {
                            i = i + 1;
                        }
                    }
                }
                if (i > 0)
                {
                    CommonFunction.MessageBox(this, "S", "Loading Yes Update successfully");
                    BindData();
                }
                else
                {
                    CommonFunction.MessageBox(this, "E", "Select atleast one record to update");
                    BindData();
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void btnloadNo_Click(object sender, EventArgs e)
        {
            int status = 0;
            int i = 0;
            try
            {
                foreach (GridViewRow row in GridView1.Rows)
                {
                    CheckBox chk = row.FindControl("Chkbox") as CheckBox;
                    if (chk.Checked)
                    {
                        Label lblid = row.FindControl("lblpid") as Label;
                        int temp = clsA.UpdateLoading(lblid.Text, status, Session["AID"].ToString());
                        if (temp > 0)
                        {
                            i = i + 1;
                        }
                    }
                }
                if (i > 0)
                {
                    CommonFunction.MessageBox(this, "S", "Loading No Update successfully");
                    BindData();
                }
                else
                {
                    CommonFunction.MessageBox(this, "E", "Select atleast one record to update");
                    BindData();
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }

        }

        protected void btnSurrYes_Click(object sender, EventArgs e)
        {
            string data = "";
            string Shipname = "";
            int status = 1;
            int i = 0;
            try
            {
                foreach (GridViewRow row in GridView1.Rows)
                {
                    CheckBox chk = row.FindControl("Chkbox") as CheckBox;
                    if (chk.Checked)
                    {
                        Label lblid = row.FindControl("lblpid") as Label;
                        Label lblchno = row.FindControl("lblchno") as Label;
                        Label lblpname = row.FindControl("lblpname") as Label;
                        Label lblcname = row.FindControl("lblcname") as Label;
                        Label lblShipname = row.FindControl("lblShipname") as Label;                        
                        int temp = clsA.UpdateSurrender(lblid.Text, status, Session["AID"].ToString());
                        if (temp > 0)
                        {
                            Shipname = lblShipname.Text;
                            i = i + 1;
                            string body = $@"
                                <div style='max-width: 600px; margin: 0 auto; padding: 20px; border: 1px solid rgba(221, 221, 221, 1); border-radius: 5px'>
                                <img src='http://www.bizupon.com/images/logo.png' alt='Sayyarah Cars Logo' style='width:120px;height:60px;' />
                                 <hr style='border-top: 1px solid rgba(221, 221, 221, 1);' />
                                  <p>Good day!<br/><br/>
                                  The surrender data of <b>1 car</b> on ship was updated and car details are given below.<br/><br/></p>

                                <table cellspacing='3' bgcolor='#000000' style='width:100%; border-collapse: collapse;'>
                                <tr bgcolor='#000000' style='color:#ffffff; text-align:left;'>
                                <th style='padding:6px;'>S.No.</th>
                                <th style='padding:6px;'>Chassis</th>
                                <th style='padding:6px;'>Surrender</th>
                                <th style='padding:6px;'>Car Name</th>
                                <th style='padding:6px;'>Client Name</th>
                                <th style='padding:6px;'>Ship Name</th>
           
                                </tr>
                                <tr bgcolor='#ffffff'>
                                <td style='padding:6px;'>{i}</td>
                                <td style='padding:6px;'>{lblchno.Text}</td>
                                <td style='padding:6px;'>Yes</td>
                                <td style='padding:6px;'>{lblpname.Text}</td>
                                <td style='padding:6px;'>{lblcname.Text}</td>
                                <td style='padding:6px;'>{lblShipname.Text}</td>
                                </tr>
                                </table>
                                <br/><br/>
                                <p>Please check your account.<br/>Thank you for your cooperation.</p>
                                <p>Best regards,<br/><b>Bizupon Co. Ltd</b></p>
                                <hr style='border-top: 1px solid rgba(221, 221, 221, 1); margin: 20px 0' />
                                <p style='font-size: 12px; color: rgba(153, 153, 153, 1)'>This is an automated message, please do not reply to this email.</p>
                                </div>";
                                sm.SendMailtoUser(HiddenField2.Value, "99bizupon@gmail.com", "Product Surrender information", body);
                        }
                    }
                }
                if (i > 0)
                {
                    
                    CommonFunction.MessageBox(this, "S", "Surrender Yes Update successfully");
                    BindData();

                }
                else
                {
                    CommonFunction.MessageBox(this, "E", "Select atleast one record to update");
                    BindData();
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)ViewState["DataTable"];
                CreateExcelFile(dt);
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        public void CreateExcelFile(DataTable Excel)
        {
            try
            {
                Response.ClearContent();
                Response.AddHeader("content-disposition", string.Format("attachment; filename=Update-Loading-Surrender.xls"));
                Response.ContentEncoding = System.Text.Encoding.Unicode;
                Response.ContentType = "application/ms-excel";
                Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
                string space = "";
                foreach (DataColumn dcolumn in Excel.Columns)
                {
                    Response.Write(space + dcolumn.ColumnName);
                    space = "\t";
                }
                Response.Write("\n");
                int countcolumn;
                foreach (DataRow dr in Excel.Rows)
                {
                    space = "";
                    for (countcolumn = 0; countcolumn < Excel.Columns.Count; countcolumn++)
                    {
                        Response.Write(space + dr[countcolumn].ToString().Trim());
                        space = "\t";
                    }
                    Response.Write("\n");
                }
                HttpContext.Current.Response.End();
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }
    }
}
