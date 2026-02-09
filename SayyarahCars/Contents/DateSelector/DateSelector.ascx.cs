using System;
using COMMON;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SayyarahCars.Contents
{
    public partial class DateSelector : System.Web.UI.UserControl
    {
        CommonFunction cmf = new CommonFunction();
        protected void Page_Load(object sender, EventArgs e)
        {
            clickme.Attributes.Add("onclick", "scwShow(" + txt_Date.ClientID + ",event);return false;");
            txt_Date.Attributes.Add("onclick", "scwShow(" + txt_Date.ClientID + ",event);return false;");
            txt_Date.Attributes.Add("onkeyup", "return clearfield('" + txt_Date.ClientID + "')");
            txt_Date.Attributes.Add("readonly", "readonly");
        }

        #region Validation Properties
        public string DataErrorId
        {
            get { return txt_Date.Attributes["data-error-id"]; }
            set { txt_Date.Attributes["data-error-id"] = value; }
        }

        public bool DataRequired
        {
            get { return txt_Date.Attributes["data-required"] == "true"; }
            set { txt_Date.Attributes["data-required"] = value ? "true" : "false"; }
        }

        public string DataType
        {
            get { return txt_Date.Attributes["data-type"]; }
            set { txt_Date.Attributes["data-type"] = value; }
        }
        #endregion

        #region Existing Properties
        public bool CalendarEnable
        {
            set
            {
                txt_Date.Enabled = value;
                clickme.Visible = value;
            }
        }
        public string CalendarDate
        {
            get { return cmf.dateConvert(txt_Date.Text); }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    txt_Date.Text = ConvertToDateOnly(value);
                }
            }
        }
        public string Text
        {
            get { return cmf.dateConvert(txt_Date.Text); }
            set
            {
                if (!string.IsNullOrEmpty(value))
                { txt_Date.Text = ConvertToDateOnly(value); }
            }
        }
        public string CssClass
        {
            get { return txt_Date.CssClass; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    txt_Date.CssClass = value;
            }
        }

        public int dtwidth
        {
            set { btgp.Style.Add("width", value.ToString() + "px"); }
        }
        public int dtheight
        {
            set
            {
                txt_Date.Height = value;
                clickme.Style.Add("width", value.ToString() + "px");
            }
        }
        #endregion
        public string ConvertToDateOnly(string c_date)
        {
            if (string.IsNullOrWhiteSpace(c_date))
                return string.Empty;

            if (c_date == "1/1/1900 12:00:00 AM")
                return string.Empty;

            string[] strArray = c_date.Split(new char[1]{' '});
            return strArray[0];
        }
    }
}