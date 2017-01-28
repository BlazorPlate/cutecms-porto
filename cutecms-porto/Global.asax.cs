using cutecms_porto.Areas.CMS.Models.DBModel;
using cutecms_porto.Areas.Config.Models.DBModel;
using cutecms_porto.Helpers;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Threading;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Optimization;
using System.Web.Routing;

namespace cutecms_porto
{
    public class MvcApplication : System.Web.HttpApplication
    {
        #region Methods
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;
            DefaultModelBinder.ResourceClassKey = "ValidationResources";
            ClientDataTypeModelValidatorProvider.ResourceClassKey = "ValidationResources";
            ValidationExtensions.ResourceClassKey = "ValidationResources";
            // Removing all the view engines
            ViewEngines.Engines.Clear();
            //Add Razor Engine (which we are using)
            ViewEngines.Engines.Add(new RazorViewEngine());
        }
        protected void Session_Start()
        {
            //string userIPAddress = null;
            //userIPAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            //if (userIPAddress == "" || userIPAddress == null)
            //    userIPAddress = Request.ServerVariables["REMOTE_ADDR"];
            //DataTable locationDT = new DataTable();
            //locationDT = GeoIPHelper.GetLocation(userIPAddress);
            //CMSEntities db = new CMSEntities();
            //Statistic statistic = new Statistic();
            //statistic.IP = locationDT.Rows[0]["IP"].ToString();
            //statistic.CountryCode = locationDT.Rows[0]["CountryCode"].ToString();
            //statistic.CountryName = locationDT.Rows[0]["CountryName"].ToString();
            //statistic.RegionCode = locationDT.Rows[0]["RegionCode"].ToString();
            //statistic.RegionName = locationDT.Rows[0]["RegionName"].ToString();
            //statistic.City = locationDT.Rows[0]["City"].ToString();
            //statistic.TimeZone = locationDT.Rows[0]["TimeZone"].ToString();
            //statistic.Latitude = Convert.ToDecimal(locationDT.Rows[0]["Latitude"]);
            //statistic.Longitude = Convert.ToDecimal(locationDT.Rows[0]["Longitude"]);
            //statistic.MetroCode = locationDT.Rows[0]["MetroCode"].ToString();
            //statistic.RequestDate = DateTime.UtcNow.ToLocalTime();
            //db.Statistics.Add(statistic);
            //db.SaveChanges();
            //Application.Lock();
            //Application["VistorCounter"] = db.Statistics.Count();
            //Application.UnLock();
        }
        protected void Application_Error(object sender, EventArgs e)
        {
            var httpContext = ((MvcApplication)sender).Context;
            var currentController = "";
            var currentAction = "";
            var currentRouteData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));
            var currentArea = currentRouteData?.DataTokens["area"];
            if (currentArea == null)
                currentArea = string.Empty;
            if (currentRouteData != null)
            {
                if (currentRouteData.Values["controller"] != null && !String.IsNullOrEmpty(currentRouteData.Values["controller"].ToString()))
                {
                    if (!httpContext.Response.IsRequestBeingRedirected)
                        currentController = currentRouteData.Values["controller"].ToString();
                }

                if (currentRouteData.Values["action"] != null && !String.IsNullOrEmpty(currentRouteData.Values["action"].ToString()))
                {
                    if (!httpContext.Response.IsRequestBeingRedirected)
                        currentAction = currentRouteData.Values["action"].ToString();
                }
            }
            var exception = Server.GetLastError();
            string culture = HttpContext.Current.Request.RequestContext.RouteData.Values["culture"]?.ToString();
            ShowCustomErrorPage(exception, httpContext, culture, currentArea.ToString(), currentController, currentAction);
        }
        private void Application_EndRequest(object sender, EventArgs e)
        {
            HttpRequest request = HttpContext.Current.Request;
            HttpResponse response = HttpContext.Current.Response;
            int[] sucessCodes = { 200, 201, 202, 203, 204, 205, 206 };
            int[] redirectCodes = { 301, 302, 303, 304, 305, 306, 307 };
            int[] errorCodes = { 400, 404, 500, 601, 602 };
            if (!sucessCodes.Any(s => s.Equals(response.StatusCode)) && !redirectCodes.Any(s => s.Equals(response.StatusCode)))
            {
                var httpContext = ((MvcApplication)sender).Context;
                var currentRouteData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));
                var currentArea = currentRouteData.DataTokens["area"];
                if (currentArea == null)
                    currentArea = string.Empty;
                var currentController = "";
                var currentAction = "";
                if (currentRouteData != null)
                {
                    if (currentRouteData.Values["controller"] != null && !String.IsNullOrEmpty(currentRouteData.Values["controller"].ToString()))
                    {
                        if (!httpContext.Response.IsRequestBeingRedirected)
                            currentController = currentRouteData.Values["controller"].ToString();
                    }

                    if (currentRouteData.Values["action"] != null && !String.IsNullOrEmpty(currentRouteData.Values["action"].ToString()))
                    {
                        if (!httpContext.Response.IsRequestBeingRedirected)
                            currentAction = currentRouteData.Values["action"].ToString();
                    }
                }
                Exception exception = new Exception(response.StatusCode + "." + response.SubStatusCode + " " + response.StatusDescription);
                httpContext.ClearError();
                httpContext.Response.Clear();
                httpContext.Response.TrySkipIisCustomErrors = true;
                string culture = HttpContext.Current.Request.RequestContext.RouteData.Values["culture"].ToString();
                ShowCustomErrorPage(exception, httpContext, culture, currentArea.ToString(), currentController, currentAction);
            }
        }
        private void ShowCustomErrorPage(Exception exception, HttpContext httpContext, string culture, string currentArea, string currentController, string currentAction)
        {
            if (exception is HttpException)
            {
                var httpEx = exception as HttpException;
                httpContext.ClearError();
                httpContext.Response.Clear();
                httpContext.Response.StatusCode = exception is HttpException ? ((HttpException)exception).GetHttpCode() : 500;
                httpContext.Response.TrySkipIisCustomErrors = true;
                switch (httpEx.GetHttpCode())
                {
                    case 400:
                    case 404:
                        httpContext.Response.Redirect("~/" + culture + "/" + currentArea + "/Error/NotFound");
                        break;
                    case 601:
                        httpContext.Response.Redirect("~/" + culture + "/" + currentArea + "/Error/NotPublished");
                        break;
                    case 602:
                        httpContext.Response.Redirect("~/" + culture + "/" + currentArea + "/Error/NotTranslated");
                        break;
                    default:
                        if (exception is HttpAntiForgeryException)
                        {
                            Response.Clear();
                            Server.ClearError(); //make sure you log the exception first
                            httpContext.Response.Redirect("~/" + culture + "/" + currentArea + "/Home/Index");
                        }
                        else
                        {
                            NotifyDeveloper((exception != null ? exception : exception = new Exception()), currentArea.ToString(), currentController, currentAction, (exception.StackTrace != null ? exception.StackTrace : "N/A"));
                            httpContext.Response.Redirect("~/" + culture + "/" + currentArea + "/Error/Index");
                        }
                        break;
                }
            }
            else
            {
                NotifyDeveloper((exception != null ? exception : exception = new Exception()), currentArea.ToString(), currentController, currentAction, (exception.StackTrace != null ? exception.StackTrace : "N/A"));
                httpContext.Response.Redirect("~/" + culture + "/" + currentArea + "/Error/Index");
            }
        }
        private void NotifyDeveloper(Exception Exception, string area, string controller, string action, string lastErrorStackTrace)
        {
            var db = new ConfigEntities();
            var notification = db.Notifications.Include("SMTPSetting").Include("NotificationTerms").Include("NotificationTerms.Language").Where(c => c.NotificationCode.Code.Trim().Equals("ERROR")).FirstOrDefault();
            if (notification != null && notification.SMTPSetting != null)
            {
                string ToAddress = notification.SMTPSetting.RecipientEmail;
                string FromAddress = notification.SMTPSetting.SenderEmail;
                string FromAddressPasswordHash = notification.SMTPSetting.SenderPasswordHash;
                string Subject = "An Error Has Occurred @ " + Request.Url.Host;

                Type lastErrorType = Exception.GetType();
                string lastErrorMessage = Exception.Message;
                string InnerMessage = Exception.InnerException == null ? "N/A" : Exception.InnerException.ToString();

                // Create the MailMessage object
                MailMessage message = new MailMessage(FromAddress, ToAddress);
                message.Subject = Subject;
                message.IsBodyHtml = true;
                message.Priority = MailPriority.High;
                message.Body = string.Format(@"
        <html>
        <body>
          <h1>An Error Has Occurred!</h1>
          <table cellpadding=""5"" cellspacing=""0"" border=""1"">
          <tr>
          <tdtext-align: right;font-weight: bold"">Host Name:</td>
          <td>{0}</td>
          </tr>
          <tr>
          <tdtext-align: right;font-weight: bold"">URL:</td>
          <td>{1}</td>
          </tr>
          <tr>
          <tdtext-align: right;font-weight: bold"">Area/Contoller/Action:</td>
          <td>{2}</td>
          </tr>
          <tr>
          <tdtext-align: right;font-weight: bold"">Exception Type:</td>
          <td>{3}</td>
          </tr>
          <tr>
          <tdtext-align: right;font-weight: bold"">Message:</td>
          <td>{4}</td>
          </tr>
          <tr>
          <tdtext-align: right;font-weight: bold"">Inner Message:</td>
          <td>{5}</td>
          </tr>
          <tr>
          <tdtext-align: right;font-weight: bold"">Stack Trace:</td>
          <td>{6}</td>
          </tr>
          </table>
        </body>
        </html>",
                    Request.Url.Host,
                    Request.Url,
                    area + "/" + controller + "/" + action,
                    lastErrorType,
                    lastErrorMessage,
                    InnerMessage,
                    lastErrorStackTrace.Replace(Environment.NewLine, "<br />"));
                // Attach the Yellow Screen of Death for this error
                //string YSODmarkup = lastErrorWrapper.GetHtmlErrorMessage();
                //if (!string.IsNullOrEmpty(YSODmarkup))
                //{
                //    Attachment YSOD = Attachment.CreateAttachmentFromString(YSODmarkup, "YSOD.htm");
                //    message.Attachments.Add(YSOD);
                //}
                // Send the email
                // Send: Configure the client:
                using (var client = new SmtpClient(notification.SMTPSetting.SMTP))
                {
                    client.Port = notification.SMTPSetting.Port;
                    client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    // Create the credentials:
                    System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(FromAddress, FromAddressPasswordHash);
                    client.EnableSsl = notification.SMTPSetting.EnableSsl;
                    client.Credentials = credentials;
                    // Create the message:
                    var mail = new System.Net.Mail.MailMessage(notification.SMTPSetting.SenderEmail, ToAddress);
                    mail.Subject = message.Subject;
                    mail.Body = message.Body;
                    mail.IsBodyHtml = true;
                    try
                    {
                        client.Send(mail);
                    }
                    catch
                    {
                    }
                }
            }
        }
        public override string GetVaryByCustomString(HttpContext context, string arg)
        {
            if (arg == "culture")
                return HttpContext.Current.Request.RequestContext.RouteData.Values["culture"].ToString();
            return String.Empty;
        }
        #endregion Methods

    }
}