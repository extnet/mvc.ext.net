using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ext.Net.Utilities;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_RowExpander.Models
{
    public class MultiLevel_GridPanelModel
    {
        public static GridPanel.Builder BuildLevel(int level, string url)
        {
            // bind store
            var data = new List<object>();

            for (int i = 1; i <= 10; i++)
            {
                data.Add(new { ID = i, Name = "Level".ConcatWith(level, ": Row " + i) });
            }

            //build grid
            var grid = new GridPanel
            {
                Height = 215,
                HideHeaders = level != 1,
                DisableSelection = true,
                Store = 
                { 
                    new Store 
                    {                        
                        Model = 
                        {
                            new Model 
                            {
                                IDProperty = "ID",
                                Fields = 
                                {
                                    new ModelField("ID"),
                                    new ModelField("Name"),
                                    new ModelField
                                    {
                                        Name = "Level",
                                        DefaultValue = level.ToString()
                                    }
                                }
                            }   
                        },                        
                        DataSource = data   
                    }
                },
                ColumnModel =
                {
                    Columns =
                    {
                        new Column { DataIndex = "Name", Text = "Name", Flex = 1 }
                    }
                },
                View =
                {
                    new GridView()
                    {
                        OverItemCls = " " //to avoid the known issue #6
                    }
                }
            };

            // add expander for all levels except last (last level is 5)
            if (level < 5)
            {
                var re = new RowExpander
                {
                    ScrollOffset = 10,
                    Loader = new ComponentLoader
                    {
                        Mode = LoadMode.Component,
                        Url = url,
                        LoadMask =
                        {
                            ShowMask = true
                        },
                        Params = {
                            new Ext.Net.Parameter("level", (level + 1).ToString(), ParameterMode.Raw),
                            new Ext.Net.Parameter("id", "this.record.getId()", ParameterMode.Raw)
                        }
                    }
                };

                grid.Plugins.Add(re);
            }

            if (level == 1)
            {
                grid.Title = "MultiLevel grid";
                grid.Width = 600;
                grid.Height = 600;
                grid.ResizableConfig = new Resizer { Handles = ResizeHandle.South };
            }

            return grid.ToBuilder();
        }
    }
}