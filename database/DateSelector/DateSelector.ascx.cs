using COMMON;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Collections.Generic;

namespace SayyarahCars.Contents
{
    public partial class DateSelector : System.Web.UI.UserControl
    {
        CommonFunction cmf = new CommonFunction();

        #region Flatpickr Properties
        public string FPDateFormat { get; set; } = "d/m/Y";   // default date format
        public string FPMinDate { get; set; } = "";
        public string FPMaxDate { get; set; } = "";
        public bool FPAllowInput { get; set; } = true;
        public bool FPEnableTime { get; set; } = false;
        public bool FPNoCalendar { get; set; } = false;   // For time-only mode
        public string FPDefaultDate { get; set; } = "";
        public bool FPDisablePast { get; set; } = false;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindFlatpickrOptions();
            }
        }

        private void BindFlatpickrOptions()
        {
            string effectiveFormat = FPDateFormat;

            if (string.IsNullOrEmpty(FPDateFormat))
            {
                if (FPEnableTime && FPNoCalendar)
                    effectiveFormat = "hh:ii tt";              // Time only
                else if (FPEnableTime)
                    effectiveFormat = "dd/MM/yyyy hh:ii tt";        // Date + Time
                else
                    effectiveFormat = "dd/MM/yyyy";            // Date only
            }

            var options = new Dictionary<string, object>();

            options["dateFormat"] = effectiveFormat;
            options["allowInput"] = FPAllowInput;
            options["enableTime"] = FPEnableTime;
            options["noCalendar"] = FPNoCalendar;

            if (!string.IsNullOrEmpty(FPDefaultDate))
                options["defaultDate"] = FPDefaultDate;

            if (FPDisablePast)
                options["minDate"] = "today";
            else if (!string.IsNullOrEmpty(FPMinDate))
                options["minDate"] = FPMinDate;

            if (!string.IsNullOrEmpty(FPMaxDate))
                options["maxDate"] = FPMaxDate;

            JavaScriptSerializer js = new JavaScriptSerializer();
            hiddenOptions.Value = js.Serialize(options);
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
                    txt_Date.Text =cmf.dateConvert(value);
                }
            }

        }
        public string Text
        {
            get { return cmf.dateConvert(txt_Date.Text); }
            set
            {
                if (!string.IsNullOrEmpty(value))
                { txt_Date.Text = cmf.dateConvert(value); }
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
    }
}
