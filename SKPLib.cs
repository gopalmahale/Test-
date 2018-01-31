using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.IO;

namespace SKP.Gama.BO
{
    public class SKPLib
    {
        public static bool SendMail(string strBody, string strToMailID, string strSubject, string strFileName = "", string strAttFriendlyName = "")
        {
            try
            {
                MailMessage message = new MailMessage();

                message.From = new MailAddress("BillingApp.Support@skpgroup.com");

                string[] strString = strToMailID.Split(';');

                int j = 0;

                for (int i = 0; i <= strString.Length - 1; i++)
                {
                    if (!string.IsNullOrEmpty(strString[i]))
                    {
                        message.To.Add(new MailAddress(strString[i]));
                        j = j + 1;
                    }
                }

                if (j == 0)
                {
                    message.To.Add(new MailAddress("BillingApp.Support@skpgroup.com"));
                    strBody = "Undelivered Mail - Email ID not found:<br><br><br>" + strBody;
                }

                if (!string.IsNullOrEmpty(strFileName))
                {
                    System.Net.Mail.Attachment attach = new System.Net.Mail.Attachment(strFileName);
                    if (!string.IsNullOrEmpty(strAttFriendlyName))
                    {
                        System.Net.Mime.ContentDisposition cd = default(System.Net.Mime.ContentDisposition);
                        cd = attach.ContentDisposition;
                        cd.FileName = strAttFriendlyName;
                    }
                    message.Attachments.Add(attach);
                }

                message.Subject = strSubject;
                message.IsBodyHtml = true;
                message.Body = strBody;

                SmtpClient client = new SmtpClient();
                client.Host = "skp-smtp.skpgroup.com";
                client.Port = 25;
                client.EnableSsl = false;
                client.Send(message);

                message.Dispose();
                client.Dispose();

                return true;


            }
            catch (Exception ex)
            {
                return false;

            }

        }

        public static void SendError(Exception e, string strProc = "")
        {
            string strMessage = "";
            string strTrace = "";
            string strException = "";

            if (e.Message != null)
            {
                strMessage = e.Message.ToString();
            }

            if (e.InnerException != null)
            {
                strException = e.InnerException.ToString();
            }

            if (e.StackTrace != null)
            {
                strTrace = e.StackTrace.ToString();
            }

            string strMailBody = null;

            //On Error Resume Next
            strMailBody = "<font face='Calibri' size='3'>An error has occurred on Gama Test App:<br><br><br><b>Use Login ID - </b>"
                + "<br><br><b>Use Login ID - </b>" + System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToString()
                + "<br><br><b>Date Time - </b>" + System.DateTime.Now.ToString()
                + "<br><br><b>Message - </b>" + strMessage
                + "<br><br><b>Inner Exception - </b>" + strException
                + "<br><br><b>Stack Trace - </b>" + strTrace
                + "<br><br><b>Function - </b>" + strProc + "<br><br></font>";

            SKPLib.SendMail(strMailBody, "BillingApp.Support@skpgroup.com", "Error occurred in Gama SP Test App");


        }

        public static void LogSystemError(Exception ex, string UserName="", string Procedure = "", string DeveloperComment="")
        {

            // Directory will be created at BaseDirectory
            string ErrorLogPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SystemErrorLogs");

            // Check if directory exists. If not create one.
            if (!Directory.Exists(ErrorLogPath))
            {
                Directory.CreateDirectory(ErrorLogPath);
            }

            string message = string.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
            message += Environment.NewLine;
            message += "-----------------------------------------------------------------------";
            message += Environment.NewLine;
            message += string.Format("User: {0}", UserName);
            message += Environment.NewLine;
            message += Environment.NewLine;
            message += string.Format("Procedure: {0}", Procedure);
            message += Environment.NewLine;
            message += Environment.NewLine;
            message += string.Format("Developer Comment: {0}", DeveloperComment);
            message += Environment.NewLine;
            message += Environment.NewLine;
            message += string.Format("Message: {0}", ex.Message);
            message += Environment.NewLine;
            message += Environment.NewLine;
            message += string.Format("StackTrace: {0}", ex.StackTrace);
            message += Environment.NewLine;
            message += Environment.NewLine;
            message += string.Format("Source: {0}", ex.Source);
            message += Environment.NewLine;
            message += Environment.NewLine;
            message += string.Format("TargetSite: {0}", ex.TargetSite.ToString());
            message += Environment.NewLine;
            message += Environment.NewLine;
            message += "-----------------------------------------------------------------------";
            message += Environment.NewLine;
            message += Environment.NewLine;

            try
            {
                using (StreamWriter writer = new StreamWriter(Path.Combine(ErrorLogPath, "System Errors - " + DateTime.Today.ToString("MMM yyyy") + ".txt"), true))
                {
                    writer.WriteLine(message);
                    writer.Close();
                }
            }
            catch (Exception)
            {
                return;
            }
            
        }

        public static void ProcessLog(string DeveloperComment = "", string UserName = "", string Procedure = "", bool IsStart = false)
        {

            // Directory will be created at BaseDirectory
            string ErrorLogPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ProcessLogs");

            // Check if directory exists. If not create one.
            if (!Directory.Exists(ErrorLogPath))
            {
                Directory.CreateDirectory(ErrorLogPath);
            }

            string message = "";            
            if (IsStart)
                message = string.Format("{0}", DeveloperComment);
            else
                message = string.Format("{0} | {1}", DateTime.Now.ToString("hh:mm:ss tt"), DeveloperComment);

            try
            {
                using (StreamWriter writer = new StreamWriter(Path.Combine(ErrorLogPath, "Process Log - " + DateTime.Today.ToString("MMM yyyy") + ".txt"), true))
                {
                    writer.WriteLine(message);
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                LogSystemError(ex, "", "SKPLib - ProcessLog", "Unable to write Process Log");
            }

        }
    }
}
