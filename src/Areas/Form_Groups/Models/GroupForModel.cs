using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ext.Net.MVC.Examples.Areas.Form_Groups.Models
{
    [Flags]
    public enum Border
    {
        [Display(Name="Top border", Order = 1)]
        Top = 1,

        [Display(Name = "Left border", Order = 3)]
        Left = 2,

        [Display(Name = "Bottom border", Order = 2)]
        Bottom = 4,

        [Display(Name = "Right border", Order = 4)]
        Right = 8
    }

    public enum Sex
    {
        Male,
        Female
    }

    public class EnumModel
    {
        public Border Borders
        {
            get;
            set;
        }

        public Sex Sex
        {
            get;
            set;
        }
    }

    public class StringModel
    {
        public string Borders
        {
            get;
            set;
        }

        public string Sex
        {
            get;
            set;
        }
    }

    public class GroupForModel
    {
        public EnumModel Enums
        {
            get;
            set;
        }

        public StringModel Strings
        {
            get;
            set;
        }
    }
}