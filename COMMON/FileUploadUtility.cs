using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls;

namespace COMMON
{
    public static class FileUploadUtility
    {
        #region Native MIME Detection

        [DllImport("urlmon.dll", CharSet = CharSet.Unicode, ExactSpelling = true, SetLastError = false)]
        private static extern int FindMimeFromData(
            IntPtr pBC,
            [MarshalAs(UnmanagedType.LPWStr)] string pwzUrl,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.I1, SizeParamIndex = 3)] byte[] pBuffer,
            int cbSize,
            [MarshalAs(UnmanagedType.LPWStr)] string pwzMimeProposed,
            int dwMimeFlags,
            out string ppwzMimeOut,
            int dwReserved);

        public static string GetMimeType(byte[] fileData)
        {
            string mime;
            FindMimeFromData(IntPtr.Zero, null, fileData, 256, null, 0, out mime, 0);
            return mime.ToLower();
        }

        #endregion

        public static int ValidateFile(FileUpload uploadControl, string docName, string[] allowedMimeTypes, int maxSizeKB, out string message)
        {
            message = "";
            if (!uploadControl.HasFile || string.IsNullOrWhiteSpace(uploadControl.FileName))
            {
                message = $"Please select a <b>{docName}</b> file to upload.";
                return 1;
            }

            byte[] fileBytes = new byte[uploadControl.PostedFile.ContentLength];
            uploadControl.PostedFile.InputStream.Read(fileBytes, 0, fileBytes.Length);

            string mimeType = GetMimeType(fileBytes);

            if (Array.IndexOf(allowedMimeTypes, mimeType) == -1)
            {
                message = $"Only the following types are allowed for <b>{docName}</b>: {string.Join(", ", allowedMimeTypes)}.";
                return 1;
            }

            if ((fileBytes.Length / 1024) > maxSizeKB)
            {
                message = $"<b>{docName}</b> must be less than {maxSizeKB} KB.";
                return 1;
            }

            Regex fileNameRegex = new Regex(@"^[a-zA-Z0-9_\- \(\)&']+\.(pdf|jpg|jpeg|png|docx|doc|xlsx)$", RegexOptions.IgnoreCase);
            if (!fileNameRegex.IsMatch(uploadControl.FileName))
            {
                message = $"Invalid file name for <b>{docName}</b>. Special characters are not allowed.";
                return 1;
            }

            return 0;
        }

        public static string UploadFile(FileUpload uploadControl, string docLabel, string configKey, out string message)
        {
            message = "";
            if (!uploadControl.HasFile)
            {
                message = "No file to upload.";
                return "";
            }

            Random rnd = new Random();
            string strHash = Generatehash512(rnd.ToString() + DateTime.Now.ToString("ddMMyyyyhhmmss"));
            string regId = strHash.ToString().Substring(0, 15);

            string rootPath = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings[configKey]);
            if (!Directory.Exists(rootPath))
                Directory.CreateDirectory(rootPath);

            string extension = Path.GetExtension(uploadControl.FileName);
            string newFileName = $"{docLabel}_{regId}{extension}";
            string fullPath = Path.Combine(rootPath, newFileName);

            uploadControl.SaveAs(fullPath);

            // If it's a PDF, check for malicious content
            if (extension.Equals(".pdf", StringComparison.OrdinalIgnoreCase))
            {
                if (!IsPdfSafe(fullPath))
                {
                    File.Delete(fullPath);
                    message = "Malicious PDF detected. Upload rejected.";
                    return "";
                }
            }

            return $"{ConfigurationManager.AppSettings[configKey]}/{newFileName}";
        }

        #region Multiple File Upload

        public static int ValidateFile(HttpPostedFile postedFile, string docName, string[] allowedMimeTypes, int maxSizeKB, out string message)
        {
            message = "";
            if (postedFile == null || string.IsNullOrWhiteSpace(postedFile.FileName))
            {
                message = $"Please select a file to upload.";
                return 1;
            }

            byte[] fileBytes = new byte[postedFile.ContentLength];
            postedFile.InputStream.Read(fileBytes, 0, fileBytes.Length);

            string mimeType = GetMimeType(fileBytes);

            if (Array.IndexOf(allowedMimeTypes, mimeType) == -1)
            {
                message = $"Only the following types are allowed : {string.Join(", ", allowedMimeTypes)}.";
                return 1;
            }

            if ((fileBytes.Length / 1024) > maxSizeKB)
            {
                message = $"<b>File</b> must be less than {maxSizeKB} KB.";
                return 1;
            }

            Regex fileNameRegex = new Regex(@"^[a-zA-Z0-9_\- \(\)&']+\.(pdf|jpg|jpeg|png|docx|doc|xlsx)$", RegexOptions.IgnoreCase);
            if (!fileNameRegex.IsMatch(postedFile.FileName))
            {
                message = $"Special characters are not allowed.";
                return 1;
            }

            return 0;
        }
        public static string UploadFile(HttpPostedFile postedFile, string docLabel, string configKey, out string message)
        {
            message = "";
            if (postedFile == null || postedFile.ContentLength == 0)
            {
                message = "No file to upload.";
                return "";
            }

            Random rnd = new Random();
            string strHash = Generatehash512(rnd.ToString() + DateTime.Now.ToString("ddMMyyyyhhmmss"));
            string regId = strHash.Substring(0, 15);

            string rootPath = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings[configKey]);
            if (!Directory.Exists(rootPath))
                Directory.CreateDirectory(rootPath);

            string extension = Path.GetExtension(postedFile.FileName);
            string newFileName = $"{docLabel}_{regId}{extension}";
            string fullPath = Path.Combine(rootPath, newFileName);

            postedFile.SaveAs(fullPath);

            if (extension.Equals(".pdf", StringComparison.OrdinalIgnoreCase))
            {
                if (!IsPdfSafe(fullPath))
                {
                    File.Delete(fullPath);
                    message = "Malicious PDF detected. Upload rejected.";
                    return "";
                }
            }

            return $"{ConfigurationManager.AppSettings[configKey]}/{newFileName}";
        }

        public static List<string> UploadMultipleFiles(FileUpload fileControl, string docLabel, string configKey, string[] allowedMimeTypes, int maxSizeKB, out List<string> messages)
        {
            messages = new List<string>();
            List<string> uploadedPaths = new List<string>();

            if (fileControl == null || !fileControl.HasFile)
            {
                messages.Add("No files selected for upload.");
                return uploadedPaths;
            }

            foreach (HttpPostedFile file in fileControl.PostedFiles)
            {
                if (file == null || file.ContentLength == 0)
                    continue;

                string validationMsg;
                int result = ValidateFile(file, docLabel, allowedMimeTypes, maxSizeKB, out validationMsg);
                if (result == 0)
                {
                    string uploadMsg;
                    string path = UploadFile(file, docLabel, configKey, out uploadMsg);
                    if (!string.IsNullOrEmpty(path))
                    {
                        uploadedPaths.Add(path);
                    }
                    else
                    {
                        messages.Add($"Error uploading {Path.GetFileName(file.FileName)}: {uploadMsg}");
                    }
                }
                else
                {
                    messages.Add($"Validation failed for {Path.GetFileName(file.FileName)}: {validationMsg}");
                }
            }
            return uploadedPaths;
        }

        #endregion

        private static bool IsPdfSafe(string path)
        {
            try
            {
                using (var reader = new PdfReader(path))
                {
                    for (int i = 0; i < reader.XrefSize; i++)
                    {
                        PdfDictionary dict = reader.GetPdfObject(i) as PdfDictionary;
                        if (dict == null) continue;

                        if (dict.Get(PdfName.JS) != null || dict.Get(PdfName.AA) != null || dict.Get(PdfName.JAVASCRIPT) != null)
                            return false;
                    }
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        public static string Generatehash512(string text)
        {
            byte[] message = Encoding.UTF8.GetBytes(text);
            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] hashValue;
            SHA512Managed hashString = new SHA512Managed();
            string hex = "";
            hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hex += String.Format("{0:x2}", x);
            }
            return hex;
        }





        #region How to use class



        //    string message;

        //    string[] allowedMimeTypes = { "application/pdf", "image/jpeg", "image/png" };
        //    int result = FileUploadUtility.ValidateFile(FileUpload1, "Document Name", allowedMimeTypes, 2048, out message);
        //    if (result == 0)
        //    {
        //        string path = FileUploadUtility.UploadFile(FileUpload1, "DocumentName", "UploadPath", out message);
        //        if (string.IsNullOrEmpty(path))
        //        {
        //            MessageBox(message, "E");
        //        }
        //        else
        //        {
        //            MessageBox("File uploaded successfully: " + path, "S");
        //        }
        //    }
        //    else
        //    {
        //        MessageBox(message, "E");
        //    }


        #endregion
    }

}
