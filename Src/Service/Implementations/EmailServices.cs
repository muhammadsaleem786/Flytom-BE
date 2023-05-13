﻿using Microsoft.AspNetCore.Hosting;
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
using iTextSharp.tool.xml.css;
using iTextSharp.tool.xml.html;
using iTextSharp.tool.xml.parser;
using iTextSharp.tool.xml.pipeline.css;
using iTextSharp.tool.xml.pipeline.end;
using iTextSharp.tool.xml.pipeline.html;
using DTO.Models;

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

        public async Task<bool> SendEmailWithPdf(MovingOffer make)
        {
            try
            {
                MailMessage message = new MailMessage(new MailAddress(AppSettingHelper.GetSmtpEmailAddress(), AppSettingHelper.GetSmtpEmailFrom()), new MailAddress(make.Email, make.Email));
                message.Subject = $"Flyttom Account: Confirm email";
                message.IsBodyHtml = true;

                string htmlbody = "";
                string pathToFile = hostingEnvironment.WebRootPath +
                    Path.DirectorySeparatorChar + "html" +
                    Path.DirectorySeparatorChar + "emails" +
                    Path.DirectorySeparatorChar + "Order.html";
                using (StreamReader SourceReader = File.OpenText(pathToFile))
                {
                    htmlbody = SourceReader.ReadToEnd();
                }
                htmlbody = htmlbody.Replace("{Name}", make.Name);
                htmlbody = htmlbody.Replace("{Email}", make.Email);
                htmlbody = htmlbody.Replace("{Telephone}", make.Phone);
                htmlbody = htmlbody.Replace("{MovingLoaction}", "-");
                htmlbody = htmlbody.Replace("{FlexibleMovingDt}", DateTime.UtcNow.ToString("MM/dd/yyyy"));
                htmlbody = htmlbody.Replace("{FlexibilityDate}", "-");
                htmlbody = htmlbody.Replace("{AgencyTo}", "-");
                htmlbody = htmlbody.Replace("{StoreObject}", "-");
                htmlbody = htmlbody.Replace("{CurrentHome}", "-");
                htmlbody = htmlbody.Replace("{InsureMoving}", "-");
                htmlbody = htmlbody.Replace("{MovingLoad}", make.sys_drop_down_value1.Value);
                htmlbody = htmlbody.Replace("{NoOfPeople}", make.sys_drop_down_value2.Value);
                htmlbody = htmlbody.Replace("{CurrentAdd}", make.CurrentAddress);
                htmlbody = htmlbody.Replace("{NOST}", make.StreetNo);
                htmlbody = htmlbody.Replace("{HomeSize}", make.SizeOfHome);
                htmlbody = htmlbody.Replace("{RoomNo}", make.sys_drop_down_value3.Value);
                htmlbody = htmlbody.Replace("{HousingTpe}", make.sys_drop_down_value4.Value);
                htmlbody = htmlbody.Replace("{MovingDt}", "-");
                htmlbody = htmlbody.Replace("{MovingFromStor}", "-");
                htmlbody = htmlbody.Replace("{MovingFrom}", "-");
                htmlbody = htmlbody.Replace("{DistanceToPark}", make.ParkingDistance);
                htmlbody = htmlbody.Replace("{NAddress}", make.NewAddress);
                htmlbody = htmlbody.Replace("{STNO}", make.NewStreetNo);
                htmlbody = htmlbody.Replace("{PostalCod}", make.PostalCode);
                htmlbody = htmlbody.Replace("{NORooms}", "-");
                htmlbody = htmlbody.Replace("{HousingTyp}", "-");
                htmlbody = htmlbody.Replace("{FloorNumber}", "-");
                htmlbody = htmlbody.Replace("{LiftAvail}", "-");
                htmlbody = htmlbody.Replace("{DistanceTo}", make.NewParkingDistance);
                htmlbody = htmlbody.Replace("{FloorNo}", make.NewStreetNo);
                htmlbody = htmlbody.Replace("{MovingObj}", "-");
                htmlbody = htmlbody.Replace("{Fragile}", "-");
                htmlbody = htmlbody.Replace("{AdditionalInfo}", make.AdditionalInfo);
                // Convert HTML to PDF
                string HTMLContent = htmlbody;
                var ms = GeneratePDF(HTMLContent);
                ms.Position = 0;
                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(ms, "Order.pdf");
                message.Attachments.Add(attachment);
                message.Body = htmlbody;
                return await SendEmail(message);
            }
            catch (Exception ex)
            {
                //await eventLogger.LogEvent(ToEmail, "User", "Sign up Email ERROR", new { ex = ex });
                return false;
            }
        }
        public static MemoryStream GeneratePDF(string html)
        {
            var pdfDoc = new Document(PageSize.A3);
            var memoryStream = new MemoryStream();
            PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, memoryStream);

            pdfWriter.RgbTransparencyBlending = true;
            pdfDoc.Open();

            var cssResolver = new StyleAttrCSSResolver();
            XMLWorkerFontProvider fontProvider = new XMLWorkerFontProvider(XMLWorkerFontProvider.DONTLOOKFORFONTS);
            //Following line will be required in case of lanuguages other than english i.e I have added following for arabic font.
            //fontProvider.Register(HttpContext.Server.MapPath("~/Tahoma Regular font.ttf"));
            CssAppliers cssAppliers = new CssAppliersImpl(fontProvider);
            HtmlPipelineContext htmlContext = new HtmlPipelineContext(cssAppliers);
            htmlContext.SetTagFactory(Tags.GetHtmlTagProcessorFactory());
            // Pipelines
            PdfWriterPipeline pdf = new PdfWriterPipeline(pdfDoc, pdfWriter);
            HtmlPipeline html1 = new HtmlPipeline(htmlContext, pdf);
            CssResolverPipeline css = new CssResolverPipeline(cssResolver, html1);
            // XML Worker
            XMLWorker worker = new XMLWorker(css, true);
            XMLParser p = new XMLParser(worker);
            p.Parse(new StringReader(html));
            pdfWriter.CloseStream = false;
            pdfDoc.Close();
            memoryStream.Position = 0;
            return memoryStream;

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
