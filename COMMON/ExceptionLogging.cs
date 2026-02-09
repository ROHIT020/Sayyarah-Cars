using System;
using System.IO;
using System.Linq;
using System.Web;
using context = System.Web.HttpContext;
namespace COMMON
{
    public static class ExceptionLogging
    {

        public static void SendErrorToText(Exception ex)
        {
            try
            {
                string line = Environment.NewLine + Environment.NewLine;

                string errorLineNo = GetLastLineFromStackTrace(ex.StackTrace);
                string errorMsg = ex.Message ?? "No Message";
                string exType = ex.GetType().ToString();
                string exUrl = "Unknown URL";
                string hostIp = Fetch_UserIP();

                var context = HttpContext.Current;
                if (context != null)
                {
                    exUrl = context.Request?.Url?.ToString() ?? "Unknown URL";
                }

                string filepath = context?.Server.MapPath("~/ExceptionDetailsFile/")
                                 ?? Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ExceptionDetailsFile");

                Directory.CreateDirectory(filepath);

                string logFile = Path.Combine(filepath, DateTime.Today.ToString("dd-MM-yy") + ".txt");

                using (StreamWriter sw = File.AppendText(logFile))
                {
                    string error = $"Log Written Date: {DateTime.Now}{line}" +
                                   $"Error Line No: {errorLineNo}{line}" +
                                   $"Error Message: {errorMsg}{line}" +
                                   $"Exception Type: {exType}{line}" +
                                   $"Error Location: {ex?.TargetSite?.DeclaringType?.FullName ?? "Unknown"}{line}" +
                                   $"Error Page Url: {exUrl}{line}" +
                                   $"User Host IP: {hostIp}{line}";

                    sw.WriteLine("-----------Exception Details-----------------");
                    sw.WriteLine("-------------------------------------------------------------------------------------");
                    sw.WriteLine(error);
                    sw.WriteLine("--------------------------------*End*------------------------------------------");
                    sw.WriteLine();
                    sw.Flush();
                }
            }
            catch
            {
                // Optional: fail silently or write to EventLog
            }
        }

        private static string GetLastLineFromStackTrace(string stackTrace)
        {
            if (string.IsNullOrEmpty(stackTrace))
                return "N/A";

            try
            {
                var lines = stackTrace.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                return lines.LastOrDefault()?.Trim() ?? "N/A";
            }
            catch
            {
                return "N/A";
            }
        }

        public static void LogError(string message)
        {
            try
            {
                string hostIp = Fetch_UserIP() ?? "Unknown";
                string exurl = "Unknown URL";
                string errorLocation = "N/A";
                string errorLineNo = "N/A";
                string errorType = "CustomLog";

                var context = HttpContext.Current;
                if (context != null)
                {
                    try
                    {
                        exurl = context.Request?.Url?.ToString() ?? "Unknown URL";
                    }
                    catch { /* avoid crash on malformed request */ }
                }

                string line = Environment.NewLine + Environment.NewLine;
                string filepath = HttpContext.Current?.Server.MapPath("~/ExceptionPerformance/")
                                 ?? Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ExceptionPerformance");

                Directory.CreateDirectory(filepath);

                string logFile = Path.Combine(filepath, DateTime.Today.ToString("dd-MM-yy") + ".txt");

                using (StreamWriter sw = File.AppendText(logFile))
                {
                    string error =
                        $"Log Written Date: {DateTime.Now}{line}" +
                        $"Error Line No: {errorLineNo}{line}" +
                        $"Error Message: {message}{line}" +
                        $"Exception Type: {errorType}{line}" +
                        $"Error Location: {errorLocation}{line}" +
                        $"Error Page Url: {exurl}{line}" +
                        $"User Host IP: {hostIp}{line}";

                    sw.WriteLine("-----------Exception Details-----------------");
                    sw.WriteLine("-------------------------------------------------------------------------------------");
                    sw.WriteLine(error);
                    sw.WriteLine("--------------------------------*End*------------------------------------------");
                    sw.WriteLine();
                    sw.Flush();
                }
            }
            catch
            {
                // Optionally log to EventViewer or silently fail to avoid recursive logging
            }
        }

        private static string Fetch_UserIP()
        {
            try
            {
                var context = HttpContext.Current;
                if (context?.Request?.UserHostAddress != null)
                {
                    return context.Request.UserHostAddress;
                }
            }
            catch { }
            return "Unknown IP";
        }
    }
}