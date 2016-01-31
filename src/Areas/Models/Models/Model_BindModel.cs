using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Ext.Net;

namespace Ext.Net.MVC.Examples.Areas.Models
{
    public class Model_BindModel
    {
        [Field(FieldLabel="TextField")]
        public string TextValue
        {
            get;
            set;
        }

        [Field(FieldLabel = "DateField")]
        public DateTime DateTimeValue
        {
            get;
            set;
        }

        [Field(FieldLabel = "ComboBox 1")]
        public ListItem ComboValue1
        {
            get;
            set;
        }

        [Field(FieldLabel = "ComboBox 2")]
        public IEnumerable<ListItem> ComboValue2
        {
            get;
            set;
        }

        [Field(FieldLabel = "ComboBox 3")]
        public string ComboValue3
        {
            get;
            set;
        }

        [Field(FieldLabel = "CheckBox")]
        public bool CheckboxValue
        {
            get;
            set;
        }

        [Field(FieldLabel = "NumberField")]
        public int NumberValue
        {
            get;
            set;
        }

        [Field(FieldLabel = "MultiSlider")]
        public int[] MultiSliderValue
        {
            get;
            set;
        }

        public IEnumerable<ListItem> Data
        {
            get;
            set;
        }
    }
}