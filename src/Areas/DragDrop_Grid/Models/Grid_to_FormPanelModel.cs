using System;
using System.Collections.Generic;

namespace Ext.Net.MVC.Examples.Areas.DragDrop_Grid.Models
{
    public class Grid_to_FormPanelModel
    {
        public IEnumerable<object> Data
        {
            get
            {
                List<object> data = new List<object>();

                for (int i = 0; i < 10; i++)
                {
                    data.Add(new
                    {
                        Name = "Rec " + i,
                        Column1 = i.ToString(),
                        Column2 = i.ToString()
                    });
                }

                return data;
            }
        }
    }
}