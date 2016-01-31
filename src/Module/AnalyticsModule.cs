using System;
using System.Globalization;
using System.Web;
using System.Web.Configuration;
using Ext.Net.Utilities;

namespace Ext.Net.MVC.Examples
{
    public class AnalyticsModule : IHttpModule
    {
        public void Init(HttpApplication app)
        {
            app.ReleaseRequestState += RequestFilter;
        }

        private void RequestFilter(object sender, EventArgs e)
        {
            if (HttpContext.Current == null || HttpContext.Current.Response == null)
            {
                return;
            }

            HttpResponse response = HttpContext.Current.Response;

            bool localLog = Convert.ToBoolean(WebConfigurationManager.AppSettings["LocalLogging"]);

            if (!RequestManager.IsAjaxRequest && (localLog || HttpContext.Current.Request.Url.Host != "localhost"))
            {
                object marker = HttpContext.Current.Items[ResourceManager.FilterMarker];
                string url = HttpContext.Current.Request.FilePath;
                bool isExample = HttpContext.Current.Items.Contains("ext.net.mvc.example");
                
                if (marker != null && (bool)marker && isExample)
                {
                    if (response.ContentType.IsNotEmpty() && response.ContentType.Equals("text/html", StringComparison.InvariantCultureIgnoreCase))
                    {
                        response.Filter = new AnalyticsFilter(response.Filter);
                    }
                }
            }
        }

        public void Dispose() { }
    }
}
