using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;

namespace Ext.Net.MVC.Examples
{
    public class ZipResult : ActionResult
    {
        private List<FileInfo> files;
        private string fileName;
        private string folder;

        public ZipResult(List<FileInfo> files, string fileName)
        {
            this.files = files;
            this.fileName = fileName;
        }

        public ZipResult(string folder, string fileName)
        {
            this.folder = folder;
            this.fileName = fileName;
        }

        private ZipOutputStream oZipStream;
        public override void ExecuteResult(ControllerContext context)
        {
            var hContext = context.HttpContext;
            hContext.Response.ContentType = "application/octet-stream";
            hContext.Response.AppendHeader("Connection", "keep-alive");
            hContext.Response.AppendHeader("Content-Disposition", string.Concat(" attachment; filename = ", fileName, ".zip"));

            FileStream ostream;
            byte[] obuffer;

            oZipStream = new ZipOutputStream(hContext.Response.OutputStream);

            oZipStream.SetLevel(6);
            ZipEntry oZipEntry;

            if (this.folder != null)
            {
                int folderOffset = this.folder.Length + (this.folder.EndsWith("\\") ? 0 : 1);
                this.CompressFolder(this.folder, folderOffset);
            }
            else
            {
                foreach (FileInfo file in this.files)
                {
                    oZipEntry = new ZipEntry(file.Name);
                    oZipStream.PutNextEntry(oZipEntry);

                    ostream = File.OpenRead(file.FullName);
                    obuffer = new byte[ostream.Length];
                    ostream.Read(obuffer, 0, obuffer.Length);
                    oZipStream.Write(obuffer, 0, obuffer.Length);
                }
            }
            
            oZipStream.Finish();
            oZipStream.Close();
            
            hContext.Response.End();
        }

        protected void CompressFolder(string folder, int folderOffset)
        {
            DirectoryInfo di = new DirectoryInfo(folder);

            foreach (DirectoryInfo item in di.GetDirectories())
            {
                this.CompressFolder(item.FullName, folderOffset);
            }

            foreach (FileInfo item in di.GetFiles())
            {
                if (item.Name == "config.xml")
                {
                    continue;
                }

                FileStream fs = File.OpenRead(item.FullName);
                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);
                string entryName = item.FullName.Substring(folderOffset);
                entryName = ZipEntry.CleanName(entryName);
                ZipEntry entry = new ZipEntry(entryName);
                this.oZipStream.PutNextEntry(entry);
                this.oZipStream.Write(buffer, 0, buffer.Length);
                fs.Close();
            }
        }
    }
}