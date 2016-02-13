using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace Ext.Net.MVC.Examples.Models
{
    class StaticNodeIcon
    {
        private Dictionary<string, Dictionary<string, string>> entryList;

        public StaticNodeIcon(string path)
        {
            entryList = new Dictionary<string, Dictionary<string, string>>();

            var xmlConf = new XmlDocument();

            try
            {
                xmlConf.Load(path + Path.DirectorySeparatorChar + "config.xml");
            }
            catch (FileNotFoundException)
            {
                return;
            }

            var iconsNode = xmlConf.SelectSingleNode("example/icons");
            if (iconsNode != null)
            {
                Dictionary<string, string> subEntries;
                XmlAttribute nodeAttribute;

                var firstLevelNodes = iconsNode.SelectNodes("folder");

                if (firstLevelNodes != null)
                {
                    foreach (XmlNode firstLevelNode in firstLevelNodes)
                    {
                        subEntries = new Dictionary<string, string>();

                        nodeAttribute = firstLevelNode.Attributes["name"];

                        if (nodeAttribute != null && !String.IsNullOrWhiteSpace(nodeAttribute.Value))
                        {
                            nodeAttribute = firstLevelNode.Attributes["iconCls"];
                            if (nodeAttribute != null && !String.IsNullOrWhiteSpace(nodeAttribute.Value) &&
                                !subEntries.ContainsKey(String.Empty))
                            {
                                subEntries.Add(String.Empty, nodeAttribute.Value);
                            }

                            var secondLevelNodes = firstLevelNode.SelectNodes("folder");
                            if (secondLevelNodes != null)
                            {
                                foreach (XmlNode secondLevelNode in secondLevelNodes)
                                {
                                    nodeAttribute = secondLevelNode.Attributes["name"];
                                    if (nodeAttribute != null && !String.IsNullOrWhiteSpace(nodeAttribute.Value))
                                    {
                                        nodeAttribute = secondLevelNode.Attributes["iconCls"];
                                        if (nodeAttribute != null && !String.IsNullOrWhiteSpace(nodeAttribute.Value) &&
                                            !subEntries.ContainsKey(secondLevelNode.Attributes["name"].Value))
                                        {
                                            subEntries.Add(secondLevelNode.Attributes["name"].Value, nodeAttribute.Value);
                                        }
                                    }
                                }
                            }

                            // Avoid re-adding an entry if it happens more than once in the .xml file.
                            if (!entryList.ContainsKey(firstLevelNode.Attributes["name"].Value))
                            {
                                entryList.Add(firstLevelNode.Attributes["name"].Value, subEntries);
                            }
                        }
                    }
                }
            }
        }

        public bool TryGetIconCLS(out string placeHolder, string firstLevel, string secondLevel = null)
        {
            Dictionary<string, string> firstLevelResult;
            if (!String.IsNullOrWhiteSpace(firstLevel) && entryList.TryGetValue(firstLevel, out firstLevelResult))
            {
                return firstLevelResult.TryGetValue((String.IsNullOrWhiteSpace(secondLevel) ? String.Empty : secondLevel), out placeHolder);
            }

            placeHolder = null;
            return false;
        }
    }
}
