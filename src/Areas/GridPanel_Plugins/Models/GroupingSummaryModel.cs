using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_Plugins.Models
{
    public class Project
    {
        public Project(int projectId, string name, int taskId, string description, int estimate, double rate, double cost, DateTime due)
        {
            this.ProjectID = projectId;
            this.Name = name;
            this.TaskID = taskId;
            this.Description = description;
            this.Estimate = estimate;
            this.Rate = rate;
            this.Due = due;
        }

        public int ProjectID { get; set; }
        public string Name { get; set; }
        public int TaskID { get; set; }
        public string Description { get; set; }
        public int Estimate { get; set; }
        public double Rate { get; set; }
        public double Cost { get; set; }
        public DateTime Due { get; set; }

        public static List<Project> Data
        {
            get
            {
                return new List<Project> 
                 { 
                    new Project(100, "Ext Forms: Field Anchoring", 112, "Integrate 2.0 Forms with 2.0 Layouts", 6, 150, 0, new DateTime(2007, 06, 24)),
                    new Project(100, "Ext Forms: Field Anchoring", 113, "Implement AnchorLayout", 4, 150, 0, new DateTime(2007, 06, 25)),
                    new Project(100, "Ext Forms: Field Anchoring", 114, "Add support for multiple types of anchors", 4, 150, 0, new DateTime(2007, 06, 27)),
                    new Project(100, "Ext Forms: Field Anchoring", 115, "Testing and debugging", 8, 0, 0, new DateTime(2007, 06, 29)),
                    new Project(101, "Ext Grid: Single-level Grouping", 101, "Add required rendering \"hooks\" to GridView", 6, 100, 0, new DateTime(2007, 07, 01)),
                    new Project(101, "Ext Grid: Single-level Grouping", 102, "Extend GridView and override rendering functions", 6, 100, 0, new DateTime(2007, 07, 03)),
                    new Project(101, "Ext Grid: Single-level Grouping", 103, "Extend Store with grouping functionality", 4, 100, 0, new DateTime(2007, 07, 04)),
                    new Project(101, "Ext Grid: Single-level Grouping", 121, "Default CSS Styling", 2, 100, 0, new DateTime(2007, 07, 05)),
                    new Project(101, "Ext Grid: Single-level Grouping", 104, "Testing and debugging", 6, 100, 0, new DateTime(2007, 07, 06)),
                    new Project(102, "Ext Grid: Summary Rows", 105, "Ext Grid plugin integration", 4, 125, 0, new DateTime(2007, 07, 01)),
                    new Project(102, "Ext Grid: Summary Rows", 106, "Summary creation during rendering phase", 4, 125, 0, new DateTime(2007, 07, 02)),
                    new Project(102, "Ext Grid: Summary Rows", 107, "Dynamic summary updates in editor grids", 6, 125, 0, new DateTime(2007, 07, 05)),
                    new Project(102, "Ext Grid: Summary Rows", 108, "Remote summary integration", 4, 125, 0, new DateTime(2007, 07, 05)),
                    new Project(102, "Ext Grid: Summary Rows", 109, "Summary renderers and calculators", 4, 125, 0, new DateTime(2007, 07, 06)),
                    new Project(102, "Ext Grid: Summary Rows", 110, "Integrate summaries with GroupingView", 10, 125, 0, new DateTime(2007, 07, 11)),
                    new Project(102, "Ext Grid: Summary Rows", 111, "Testing and debugging", 8, 125, 0, new DateTime(2007, 07, 15))
                 };
            }
        }
    }
}