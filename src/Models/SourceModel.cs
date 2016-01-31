using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text.RegularExpressions;

namespace Ext.Net.MVC.Examples
{
    public class SourceModel
    {
        private static string[] excludeFolders = new[] { ".svn", "_svn" };
        private static string[] excludeList = new[] { "config.xml" };
        private static string[] excludeExtensions = new[] { ".png", ".jpg", ".gif", ".bmp", ".psd" };

        public static TabPanel BuildSourceTabs(string idSuffix, string url)
        {
            List<FileInfo> files = SourceModel.GetFiles(url, false);

            TabPanel tabs = new TabPanel
            {
                ID = "tpw" + idSuffix,
                Border = false,
                ActiveTabIndex = 0
            };

            int i = 0;
            foreach (FileInfo fileInfo in files)
            {
                Panel panel = new Panel();
                panel.ID = "tptw" + idSuffix + i++;
                panel.Title = fileInfo.Name;

                switch (fileInfo.Extension)
                {
                    case ".aspx":
                    case ".cshtml":
                    case ".ascx":
                        panel.Icon = Icon.PageWhiteCode;
                        break;
                    case ".cs":
                        panel.Icon = Icon.PageWhiteCsharp;
                        break;
                    case ".xml":
                    case ".xsl":
                        panel.Icon = Icon.ScriptCodeRed;
                        break;
                    case ".js":
                        panel.Icon = Icon.Script;
                        break;
                    case ".css":
                        panel.Icon = Icon.Css;
                        break;
                }
                panel.Loader = new ComponentLoader();
                panel.Loader.Url = ExamplesModel.ApplicationRoot + "/Source/GetSourceFile";
                panel.Loader.Mode = LoadMode.Frame;
                panel.Loader.Params.Add(new Parameter("file", SourceModel.PhysicalToVirtual(fileInfo.FullName), ParameterMode.Value));
                panel.Loader.LoadMask.ShowMask = true;

                tabs.Items.Add(panel);
            }

            return tabs;
        }

        private static string PhysicalToVirtual(string physicalPath)
        {
            string pathOfWebRoot = HttpContext.Current.Server.MapPath("~/").ToLower();

            int index = physicalPath.IndexOf(pathOfWebRoot, StringComparison.InvariantCultureIgnoreCase);

            if (index == -1)
            {
                throw new Exception("Physical path can't be mapped to the current application.");
            }

            string relUrl = Path.DirectorySeparatorChar.ToString();

            index += pathOfWebRoot.Length;
            relUrl += physicalPath.Substring(index);

            relUrl = relUrl.Replace("\\", "/");

            return ExamplesModel.ApplicationRoot + relUrl;
        }

        private static Regex example_RE = new Regex("^/(\\w+)/(\\w+)/$", RegexOptions.Compiled | RegexOptions.Singleline);
        public static List<FileInfo> GetFiles(string url, bool download)
        {
            var list = new List<FileInfo>();
            var match = SourceModel.example_RE.Match(url);
            if (!match.Success)
            {
                return list;
            }

            var area = match.Groups[1].Value;
            var controller = match.Groups[2].Value;

            string path = HttpContext.Current.Server.MapPath(ExamplesModel.ExamplesRoot + area);
            list.Add(new FileInfo(string.Concat(path, "/Controllers/", controller, "Controller.cs")));

            var model = string.Concat(path, "/Models/", controller, "Model.cs");
            if (File.Exists(model))
            {
                list.Add(new FileInfo(model));
            }

            string configPath = path + "\\Views\\" + controller + "\\config.xml";

            if (File.Exists(configPath))
            {
                ExampleConfig cfg = new ExampleConfig(configPath, true);
                foreach (string file in cfg.OuterFiles)
                {
                    list.Add(new FileInfo(file));
                }
            }

            model = path + "/Models/SharedModel.cs";
            if (File.Exists(model))
            {
                list.Add(new FileInfo(model));
            }

            DirectoryInfo viewFolder = new DirectoryInfo(string.Concat(path, "/Views/", controller));
            FileInfo[] filesInfo = viewFolder.GetFiles();

            int dIndex = 0;
            int len = list.Count;
            for (int ind = 0; ind < filesInfo.Length; ind++)
            {
                var fileInfo = filesInfo[ind];

                if (Path.GetFileNameWithoutExtension(fileInfo.Name).ToLowerInvariant() == "index")
                {
                    dIndex = ind + len;
                }

                if (excludeList.Contains(fileInfo.Name) || (!download && excludeExtensions.Contains(fileInfo.Extension.ToLowerInvariant())))
                {
                    len--;
                    continue;
                }

                list.Add(fileInfo);
            }

            if (download)
            {
                foreach (DirectoryInfo folder in viewFolder.GetDirectories())
                {
                    if (excludeFolders.Contains(folder.Name.ToLower()) || folder.Name.StartsWith("_"))
                    {
                        continue;
                    }

                    SourceModel.GetSubFiles(list, folder);
                }
            }

            if (dIndex > 0)
            {
                FileInfo fi = list[dIndex];
                list.RemoveAt(dIndex);
                list.Insert(0, fi);
            }

            return list;
        }

        private static void GetSubFiles(List<FileInfo> fileList, DirectoryInfo dir)
        {
            FileInfo[] filesInfo = dir.GetFiles();

            foreach (FileInfo file in filesInfo)
            {
                if (excludeExtensions.Contains(file.Extension.ToLower()))
                {
                    continue;
                }
                fileList.Add(file);
            }

            DirectoryInfo[] folders = dir.GetDirectories();
            foreach (DirectoryInfo folder in folders)
            {
                if (excludeFolders.Contains(folder.Name.ToLower()) || folder.Name.StartsWith("_"))
                {
                    continue;
                }

                SourceModel.GetSubFiles(fileList, folder);
            }
        }
    }
}