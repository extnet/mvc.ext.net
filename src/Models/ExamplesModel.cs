using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Xml;
using Ext.Net.Utilities;
using Ext.Net.MVC.Examples.Models;

namespace Ext.Net.MVC.Examples
{
    public class ExamplesModel
    {
        internal static string ExamplesRoot = "~/Areas/";

        public static NodeCollection GetExamplesNodes()
        {
            var nodes = new NodeCollection();
            string path = HttpContext.Current.Server.MapPath(ExamplesModel.ExamplesRoot);

            return ExamplesModel.BuildAreasLevel();
        }

        public static string ApplicationRoot
        {
            get
            {
                string root = HttpContext.Current.Request.ApplicationPath;
                return root == "/" ? "" : root;
            }
        }

        private static readonly string[] excludeList = { ".svn", "_svn", "Shared" };

        private static NodeCollection BuildAreasLevel()
        {
            string path = HttpContext.Current.Server.MapPath(ExamplesModel.ExamplesRoot);
            DirectoryInfo root = new DirectoryInfo(path);
            DirectoryInfo[] folders = root.GetDirectories();
            folders = ExamplesModel.SortFolders(root, folders);

            NodeCollection nodes = new NodeCollection(false);

            var staticIcons = new StaticNodeIcon(path);

            foreach (DirectoryInfo folder in folders)
            {
                if ((folder.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden ||
                    excludeList.Contains(folder.Name) || folder.Name.StartsWith("_"))
                {
                    continue;
                }

                ExampleConfig cfg = new ExampleConfig(folder.FullName + "\\config.xml");

                string iconCls = string.IsNullOrEmpty(cfg.IconCls) ? "" : cfg.IconCls;
                Node node = null;
                var index = folder.Name.IndexOf('_');

                if (cfg.MainGroup || index < 0)
                {
                    node = new Node();
                    node.NodeID = BaseControl.GenerateID();
                    node.Text = folder.Name.Replace("_", " ");

                    nodes.Add(node);

                    if (String.IsNullOrWhiteSpace(iconCls)) {
                        staticIcons.TryGetIconCLS(out iconCls, folder.Name);
                    }

                    node.IconCls = iconCls;

                    flagNode(ref node, folder.FullName);
                }
                else
                {
                    string otherIconCls;
                    var mainGroupName = folder.Name.Substring(0, index);
                    node = nodes.FirstOrDefault(n => n.Text == mainGroupName);

                    if (node == null)
                    {
                        node = new Node();
                        node.NodeID = BaseControl.GenerateID();
                        node.Text = mainGroupName;
                        nodes.Add(node);
                    }

                    if (staticIcons.TryGetIconCLS(out otherIconCls, mainGroupName))
                    {
                        node.IconCls = otherIconCls;
                    }

                    flagNode(ref node, folder.FullName);

                    var groupNode = new Node();
                    var subGroupNodeName = folder.Name.Substring(index + 1);

                    groupNode.NodeID = BaseControl.GenerateID();
                    groupNode.Text = subGroupNodeName.Replace("_", " ");

                    if (iconCls.IsNotEmpty())
                    {
                        groupNode.IconCls = iconCls;
                    }
                    else if (staticIcons.TryGetIconCLS(out otherIconCls, mainGroupName, subGroupNodeName))
                    {
                        groupNode.IconCls = otherIconCls;
                    }

                    flagNode(ref node, folder.FullName);

                    node.Children.Add(groupNode);
                    node = groupNode;
                }

                ExamplesModel.BuildViewsLevel(folder, node);
            }

            return nodes;
        }

        private static void BuildViewsLevel(DirectoryInfo area, Node areaNode)
        {
            DirectoryInfo[] folders = new DirectoryInfo(area.FullName + "\\Views").GetDirectories();

            folders = ExamplesModel.SortFolders(area, folders);

            foreach (DirectoryInfo folder in folders)
            {
                if ((folder.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden ||
                    excludeList.Contains(folder.Name) || folder.Name.StartsWith("_"))
                {
                    continue;
                }

                ExampleConfig cfg = new ExampleConfig(folder.FullName + "\\config.xml");

                string iconCls = string.IsNullOrEmpty(cfg.IconCls) ? "" : cfg.IconCls;
                Node node = new Node();

                string folderName = folder.Name.Replace("_", " ");

                node.Text = folderName;

                flagNode(ref node, folder.FullName);

                node.IconCls = iconCls;
                string url = string.Concat(ExamplesModel.ApplicationRoot, "/", area.Name, "/", folder.Name, "/");
                node.NodeID = "e" + Math.Abs(url.ToLower().GetHashCode());
                //node.Href = url;
                node.CustomAttributes.Add(new ConfigItem("url", url));

                node.Leaf = true;

                node.CustomAttributes.Add(new { tags = cfg.Tags.Select(item => item.ToLower()) });

                areaNode.Children.Add(node);
            }
        }

        private static ExampleConfig rootCfg;

        public static bool ClearExamplesTree()
        {
            rootCfg = null;

            return true;
        }

        private static bool IsNew(string folder)
        {
            if (ExamplesModel.rootCfg == null)
            {
                ExamplesModel.rootCfg = new ExampleConfig(new DirectoryInfo(HttpContext.Current.Server.MapPath(ExamplesModel.ExamplesRoot)) + "\\config.xml");
            }

            foreach (string newFolder in rootCfg.NewFolders)
            {
                string newPath = string.Concat(HttpContext.Current.Server.MapPath(ExamplesModel.ExamplesRoot), newFolder);

                if (newPath.StartsWith(folder, StringComparison.CurrentCultureIgnoreCase))
                {
                    string end = newPath.Substring(folder.Length);

                    if ((end.StartsWith("\\") || end.Equals("")))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static bool IsUpdated(string folder)
        {
            if (rootCfg == null)
            {
                rootCfg = new ExampleConfig(new DirectoryInfo(HttpContext.Current.Server.MapPath(ExamplesModel.ExamplesRoot)) + "\\config.xml", false);
            }

            foreach (string updFolder in rootCfg.UpdFolders)
            {
                string updPath = string.Concat(HttpContext.Current.Server.MapPath(ExamplesModel.ExamplesRoot), updFolder);

                if (updPath.StartsWith(folder, StringComparison.CurrentCultureIgnoreCase))
                {
                    string end = updPath.Substring(folder.Length);

                    if ((end.StartsWith("\\") || end.Equals("")))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static void flagNode(ref Node node, string folder)
        {
            string flag = string.Empty;

            if (IsNew(folder))
            {
                flag = "n";
            }
            else if (IsUpdated(folder))
            {
                flag = "u";
            }

            if (flag != string.Empty)
            {
                node.CustomAttributes.Add(new ConfigItem("flags", flag));
            }
        }

        private static DirectoryInfo[] SortFolders(DirectoryInfo root, DirectoryInfo[] folders)
        {
            string cfgPath = root.FullName + "\\config.xml";

            if (File.Exists(root.FullName + "\\config.xml"))
            {
                ExampleConfig rootCfg = new ExampleConfig(cfgPath);

                if (rootCfg.OrderFolders.Count > 0)
                {
                    List<DirectoryInfo> list = new List<DirectoryInfo>(folders);
                    int pasteIndex = 0;

                    foreach (string orderFolder in rootCfg.OrderFolders)
                    {
                        int dIndex = 0;

                        for (int ind = 0; ind < list.Count; ind++)
                        {
                            if (list[ind].Name.ToLower() == orderFolder)
                            {
                                dIndex = ind;
                            }
                        }

                        if (dIndex > 0)
                        {
                            DirectoryInfo di = list[dIndex];
                            list.RemoveAt(dIndex);
                            list.Insert(pasteIndex++, di);
                        }
                    }

                    folders = list.ToArray();
                }
            }

            return folders;
        }
    }

    public class ExampleConfig
    {
        public static string ApplicationRoot
        {
            get
            {
                string root = HttpContext.Current.Request.ApplicationPath;
                return root == "/" ? "" : root;
            }
        }

        public static string PhysicalToAbsolute(string physicalPath)
        {
            HttpRequest r = HttpContext.Current.Request;

            return r.Url.Scheme + "://" + r.Url.Authority + PhysicalToVirtual(physicalPath);
        }

        public static string PhysicalToVirtual(string physicalPath)
        {
            string pathOfWebRoot = HttpContext.Current.Server.MapPath("~/").ToLower();

            int index = physicalPath.IndexOf(pathOfWebRoot, StringComparison.InvariantCultureIgnoreCase);

            if (index == -1)
                throw new Exception("Physical path can't be mapped to the current application.");

            string relUrl = Path.DirectorySeparatorChar.ToString();

            index += pathOfWebRoot.Length;
            relUrl += physicalPath.Substring(index);

            relUrl = relUrl.Replace("\\", "/");

            return ExampleConfig.ApplicationRoot + relUrl;
        }

        private string path;
        private bool includeDescriptors;

        public ExampleConfig(string path, bool includeDescriptors = false)
        {
            this.path = path;
            this.includeDescriptors = includeDescriptors;
            this.Load();
        }

        private void Load()
        {
            this.Description = "No description";
            XmlDocument xml = new XmlDocument();

            if (File.Exists(path))
            {
                try
                {
                    xml.Load(path);
                }
                catch (FileNotFoundException)
                {
                    return;
                }
            }

            XmlNode root = xml.SelectSingleNode("example");

            if (root == null)
            {
                return;
            }

            XmlAttribute iconCls = root.Attributes["iconCls"];

            if (iconCls != null)
            {
                this.IconCls = iconCls.Value;
            }

            XmlAttribute mainGroup = root.Attributes["group"];

            if (mainGroup != null)
            {
                this.MainGroup = mainGroup.Value == "1";
            }

            XmlNode desc = root.SelectSingleNode("description");

            if (desc != null)
            {
                this.Description = desc.InnerText;
            }

            XmlNodeList folders = root.SelectNodes("order/folder");

            if (folders != null)
            {
                foreach (XmlNode folder in folders)
                {
                    XmlAttribute urlAttr = folder.Attributes["name"];

                    if (urlAttr != null && !string.IsNullOrEmpty(urlAttr.InnerText))
                    {
                        string folderName = urlAttr.InnerText;
                        this.OrderFolders.Add(folderName.ToLower());
                    }
                }
            }

            // This will match only new items for the current version a.b.c.
            folders = root.SelectNodes("new[@version = \"" + ExtNetVersion.WithBuild + "\"]/folder");

            if (folders != null)
            {
                foreach (XmlNode folder in folders)
                {
                    XmlAttribute urlAttr = folder.Attributes["name"];

                    if (urlAttr != null && !string.IsNullOrEmpty(urlAttr.InnerText))
                    {
                        string folderName = urlAttr.InnerText;
                        this.NewFolders.Add(folderName.ToLower());
                    }
                }
            }

            // This will match only new items for the current version a.b.c.
            folders = root.SelectNodes("updated[@version = \"" + ExtNetVersion.WithBuild + "\"]/folder");

            if (folders != null)
            {
                foreach (XmlNode folder in folders)
                {
                    XmlAttribute urlAttr = folder.Attributes["name"];

                    if (urlAttr != null && !string.IsNullOrEmpty(urlAttr.InnerText))
                    {
                        string folderName = urlAttr.InnerText;
                        this.UpdFolders.Add(folderName.ToLower());
                    }
                }
            }

            XmlNode tagsNode = root.SelectSingleNode("tags");

            if (tagsNode != null)
            {
                this.Tags.AddRange(tagsNode.InnerText.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
            }

            XmlNodeList files = root.SelectNodes("include/file");

            if (files != null)
            {
                string url = ExampleConfig.PhysicalToAbsolute(path);
                foreach (XmlNode file in files)
                {
                    XmlAttribute urlAttr = file.Attributes["url"];
                    XmlAttribute zipAttr = file.Attributes["zip"];

                    if (urlAttr != null && !string.IsNullOrEmpty(urlAttr.InnerText))
                    {
                        string fileUrl = urlAttr.InnerText;
                        Uri uri = new Uri(new Uri(url, UriKind.Absolute), fileUrl);
                        this.OuterFiles.Add(HttpContext.Current.Server.MapPath(uri.AbsolutePath));
                    }
                }
            }
        }

        public string IconCls { get; private set; }

        public bool MainGroup { get; private set; }

        public string Title { get; private set; }

        public string Description { get; private set; }

        private List<string> orderFolders;

        public List<string> OrderFolders
        {
            get
            {
                if (this.orderFolders == null)
                {
                    this.orderFolders = new List<string>();
                }
                return this.orderFolders;
            }
        }

        private List<string> newFolders;

        public List<string> NewFolders
        {
            get
            {
                if (this.newFolders == null)
                {
                    this.newFolders = new List<string>();
                }
                return this.newFolders;
            }
        }

        private List<string> updFolders;
        public List<string> UpdFolders
        {
            get
            {
                if (this.updFolders == null)
                {
                    this.updFolders = new List<string>();
                }
                return this.updFolders;
            }
        }

        private List<string> tags;

        public List<string> Tags
        {
            get
            {
                if (this.tags == null)
                {
                    this.tags = new List<string>();
                }
                return this.tags;
            }
        }

        private List<string> outerFiles;

        public List<string> OuterFiles
        {
            get
            {
                if (this.outerFiles == null)
                {
                    this.outerFiles = new List<string>();
                }
                return outerFiles;
            }
        }
    }
}