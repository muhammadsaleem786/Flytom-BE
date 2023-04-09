using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Common.Helpers;
using Logger.Interfaces;
using Service.Interfaces;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.tool.xml;

using iTextSharp.text.html.simpleparser;



using System.Text;

using System.Web;
using Microsoft.AspNetCore.Http;
using Org.BouncyCastle.Crypto.Macs;

namespace Service.Implementations
{
    class EmailServices : IEmailServices
    {
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IEventLogger eventLogger;

        public EmailServices(IHostingEnvironment hostingEnvironment, IEventLogger eventLogger)
        {
            this.hostingEnvironment = hostingEnvironment;
            this.eventLogger = eventLogger;
        }
        public async Task<bool> SendConfirmEmail(string ToName, string ToEmail, string Token)
        {
            try
            {
                MailMessage message = new MailMessage(new MailAddress(AppSettingHelper.GetSmtpEmailAddress(), AppSettingHelper.GetSmtpEmailFrom()), new MailAddress(ToEmail, ToName));
                message.Subject = $"QUAMFY Account: Confirm email";
                message.IsBodyHtml = true;

                string htmlbody = "";
                string pathToFile = hostingEnvironment.WebRootPath +
                    Path.DirectorySeparatorChar + "html" +
                    Path.DirectorySeparatorChar + "emails" +
                    Path.DirectorySeparatorChar + "confirmemail.html";
                using (StreamReader SourceReader = File.OpenText(pathToFile))
                {
                    htmlbody = SourceReader.ReadToEnd();
                }
                htmlbody = htmlbody.Replace("{link}", Token);
                message.Body = htmlbody;
                return await SendEmail(message);
            }
            catch (Exception ex)
            {
                //await eventLogger.LogEvent(ToEmail, "User", "Sign up Email ERROR", new { ex = ex });
                return false;
            }
        }

        public async Task<bool> SendEmailWithPdf(string ToName, string ToEmail)
        {
            try
            {
                MailMessage message = new MailMessage(new MailAddress(AppSettingHelper.GetSmtpEmailAddress(), AppSettingHelper.GetSmtpEmailFrom()), new MailAddress(ToEmail, ToName));
                message.Subject = $"QUAMFY Account: Confirm email";
                message.IsBodyHtml = true;

                string htmlbody = "";
                string pathToFile = hostingEnvironment.WebRootPath +
                    Path.DirectorySeparatorChar + "html" +
                    Path.DirectorySeparatorChar + "emails" +
                    Path.DirectorySeparatorChar + "Moving.html";
                using (StreamReader SourceReader = File.OpenText(pathToFile))
                {
                    htmlbody = SourceReader.ReadToEnd();
                }
                htmlbody = htmlbody.Replace("{link}", "test");

                // Convert HTML to PDF
                string HTMLContent = htmlbody; //"Hello <b>World</b>";// Put your html tempelate here

                MemoryStream ms = new MemoryStream();
                TextReader txtReader = new StringReader(HTMLContent);

                // 1: create object of a itextsharp document class  
                Document doc = new Document(PageSize.A4, 25, 25, 25, 25);

                // 2: we create a itextsharp pdfwriter that listens to the document and directs a XML-stream to a file  
                PdfWriter PdfWriter = PdfWriter.GetInstance(doc, ms);
                PdfWriter.CloseStream = false;

                // 3: we create a worker parse the document  
                HTMLWorker htmlWorker = new HTMLWorker(doc);

                // 4: we open document and start the worker on the document  
                doc.Open();
                htmlWorker.StartDocument();


                // 5: parse the html into the document  
                htmlWorker.Parse(txtReader);
                // 6: close the document and the worker  
                htmlWorker.EndDocument();
                htmlWorker.Close();
                doc.Close();

                ms.Flush(); //Always catches me out
                ms.Position = 0; //Not sure if this is required

                // Convert the HTML template to PDF

                //iTextSharp.text.Document document = new iTextSharp.text.Document();
                //StringBuilder strBody = new StringBuilder();
                //using (StringWriter sw = new StringWriter())
                //{
                //    strBody.Append(htmlbody);
                //    PdfWriter.GetInstance(document, new FileStream(pathToFile, FileMode.Create));
                //    document.Open();
                //    List<iTextSharp.text.IElement> htmlarraylist = HTMLWorker.ParseToList(new StringReader(strBody.ToString()), null);
                //    for (int k = 0; k < htmlarraylist.Count; k++)
                //    {
                //        document.Add((iTextSharp.text.IElement)htmlarraylist[k]);
                //    }
                //}



                //var renderer = new HtmlToPdf();
                //var pdf = renderer.RenderHtmlAsPdf(htmlbody);

                //// Save PDF to a temporary file
                //var pdfFilePath = Path.GetTempFileName() + ".pdf";
                //pdf.SaveAs(pdfFilePath);

                // Attach PDF file to email
                //Attachment attachment = new Attachment(pdfFilePath);
                //message.Attachments.Add(attachment);

                message.Body = htmlbody;
                message.Attachments.Add(new Attachment(ms, "template.pdf", "application/pdf"));

                return await SendEmail(message);
            }
            catch (Exception ex)
            {
                //await eventLogger.LogEvent(ToEmail, "User", "Sign up Email ERROR", new { ex = ex });
                return false;
            }
        }


        public async Task<bool> SendEmail(MailMessage Body)
        {
            try
            {
                var smtp = new SmtpClient
                {
                    Host = AppSettingHelper.GetSmtpServerName(),
                    Port = AppSettingHelper.GetSmtpServerPort(),
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    EnableSsl = true,
                    Credentials = new NetworkCredential(AppSettingHelper.GetSmtpEmailAddress(), AppSettingHelper.GetSmtpEmailPassword())
                };
                await smtp.SendMailAsync(Body);
                Body.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> SendForgotEmailAsync(string ToName, string ToEmail, string Token)
        {
            try
            {
                MailMessage message = new MailMessage(new MailAddress(AppSettingHelper.GetSmtpEmailAddress(), AppSettingHelper.GetSmtpEmailFrom()), new MailAddress(ToEmail, ToName));
                message.Subject = $"QUAMFY Account: Forgot Password";
                message.IsBodyHtml = true;

                string htmlbody = "";
                string pathToFile = hostingEnvironment.WebRootPath +
                    Path.DirectorySeparatorChar + "html" +
                    Path.DirectorySeparatorChar + "emails" +
                    Path.DirectorySeparatorChar + "forgotemail.html";
                using (StreamReader SourceReader = File.OpenText(pathToFile))
                {
                    htmlbody = SourceReader.ReadToEnd();
                }
                htmlbody = htmlbody.Replace("{link}", Token);
                message.Body = htmlbody;
                return await SendEmail(message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error sending confirm email");
            }
        }

        public async Task<bool> SendOPTEmail(string ToName, string ToEmail, string opt)
        {
            try
            {
                MailMessage message = new MailMessage(new MailAddress(AppSettingHelper.GetSmtpEmailAddress(), AppSettingHelper.GetSmtpEmailFrom()), new MailAddress(ToEmail, ToName));
                message.Subject = $"Verde Account: OTP Code";
                message.IsBodyHtml = true;

                string htmlbody = "";
                string pathToFile = hostingEnvironment.WebRootPath +
                    Path.DirectorySeparatorChar + "html" +
                    Path.DirectorySeparatorChar + "emails" +
                    Path.DirectorySeparatorChar + "otpemail.html";
                using (StreamReader SourceReader = System.IO.File.OpenText(pathToFile))
                {
                    htmlbody = SourceReader.ReadToEnd();
                }
                htmlbody = htmlbody.Replace("{link}", opt);
                message.Body = htmlbody;
                return await SendEmail(message);
            }
            catch (Exception ex)
            {
                //await eventLogger.LogEvent(ToEmail, "User", "Sign up Email ERROR", new { ex = ex });
                return false;
            }
        }
    }
}
