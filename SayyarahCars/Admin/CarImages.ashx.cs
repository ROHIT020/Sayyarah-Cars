using System;
using System.Web;
using System.Web.SessionState;
using COMMON;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace SayyarahCars.Admin
{
    /// <summary>
    /// Summary description for UploadFile
    /// </summary>
    public class CarImages : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            var json = new JavaScriptSerializer();

            try
            {
                if (context.Request.Files.Count == 0)
                {
                    context.Response.StatusCode = 400;
                    context.Response.Write(json.Serialize(new { message = "No files uploaded." }));
                    return;
                }

                string[] allowedMimeTypes = { "image/png", "image/jpeg", "image/gif" };
                int maxSizeKB = 2048; // 2MB
                string responseMessage = "";

                for (int i = 0; i < context.Request.Files.Count; i++)
                {
                    HttpPostedFile postedFile = context.Request.Files[i];

                    // Workaround to use FileUploadUtility with HttpPostedFile
                    FileUpload dummyUpload = CreateFakeFileUpload(postedFile);

                    int validationResult = FileUploadUtility.ValidateFile(dummyUpload, "Car Image", allowedMimeTypes, maxSizeKB, out responseMessage);
                    if (validationResult != 0)
                    {
                        context.Response.StatusCode = 400;
                        context.Response.Write(json.Serialize(new { message = responseMessage }));
                        return;
                    }

                    string path = FileUploadUtility.UploadFile(dummyUpload, "CarImg", "CarImageUploadPath", out responseMessage);
                    if (string.IsNullOrEmpty(path))
                    {
                        context.Response.StatusCode = 400;
                        context.Response.Write(json.Serialize(new { message = responseMessage }));
                        return;
                    }
                }

                context.Response.Write(json.Serialize(new { message = "Upload successful" }));
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                context.Response.Write(json.Serialize(new { message = "Internal Server Error: " + ex.Message }));
            }
        }

        public bool IsReusable => false;

        /// <summary>
        /// Creates a dummy FileUpload control for compatibility with your existing utility method.
        /// </summary>
        private FileUpload CreateFakeFileUpload(HttpPostedFile postedFile)
        {
            FileUpload dummy = new FileUpload();

            var field = typeof(FileUpload).GetField("_postedFile", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            if (field != null)
            {
                field.SetValue(dummy, postedFile);
            }

            return dummy;
        }

    }
}