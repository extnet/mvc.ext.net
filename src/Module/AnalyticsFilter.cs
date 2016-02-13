using System;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Configuration;

namespace Ext.Net.MVC.Examples
{
    public class AnalyticsFilter : Stream
    {
        private readonly Stream response;
        private readonly StringBuilder html;

        public const string ANALYTIC_SCRIPT = @"
    <script type=""text/javascript"">
        (function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){
        (i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o),
        m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)
        })(window,document,'script','//www.google-analytics.com/analytics.js','ga');

        ga('create', 'UA-19135912-8', 'ext.net');
        ga('send', 'pageview');
    </script>";

        public AnalyticsFilter(Stream stream)
        {
            this.response = stream;
            this.html = new StringBuilder();
        }

        public override void Flush()
        {
            if (this.html.Length == 0)
            {
                this.response.Flush();
                return;
            }

            string html = this.html.ToString();

            if (Convert.ToBoolean(WebConfigurationManager.AppSettings["GoogleAnalytics"]))
            {
                int index = html.LastIndexOf("</body>", StringComparison.InvariantCultureIgnoreCase);

                if (index >= 0)
                {
                    this.html.Insert(index, ANALYTIC_SCRIPT);
                }
            }

            byte[] data = System.Text.Encoding.UTF8.GetBytes(this.html.ToString());
            this.response.Write(data, 0, data.Length);
            this.response.Flush();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            this.html.Append(HttpContext.Current.Response.ContentEncoding.GetString(buffer, offset, count));
        }

        public override bool CanRead
        {
            get { return true; }
        }

        public override bool CanSeek
        {
            get { return true; }
        }

        public override bool CanWrite
        {
            get { return true; }
        }

        public override void Close()
        {
            this.response.Close();
        }

        public override long Length
        {
            get { return 0; }
        }

        private long position;

        public override long Position
        {
            get { return this.position; }
            set { this.position = value; }
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return this.response.Seek(offset, origin);
        }

        public override void SetLength(long length)
        {
            this.response.SetLength(length);
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return this.response.Read(buffer, offset, count);
        }
    }
}
