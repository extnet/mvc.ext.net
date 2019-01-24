namespace Ext.Net.MVC.Examples.Areas.Kitchen_Sink_GridPanels.Models
{
    public class PropertyModel
    {
        public static PropertyGridParameterCollection GetUpdatedPropData()
        {
            return new PropertyGridParameterCollection()
            {
                new PropertyGridParameter()
                {
                    Name = "(name)",
                    Value = "Property GridPanel"
                },
                new PropertyGridParameter()
                {
                    Name = "grouping",
                    Value = "false"
                },
                new PropertyGridParameter()
                {
                    Name = "autoFitColumns",
                    Value = "true"
                },
                new PropertyGridParameter()
                {
                    Name = "productionQuality",
                    Value = "true"
                },
                new PropertyGridParameter()
                {
                    Name = "created",
                    Value = "new Date()",
                    Mode = ParameterMode.Raw
                },
                new PropertyGridParameter()
                {
                    Name = "tested",
                    Value = "false"
                },
                new PropertyGridParameter()
                {
                    Name = "version",
                    Value = "0.8"
                },
                new PropertyGridParameter()
                {
                    Name = "borderWidth",
                    Value = "2"
                }
            };
        }

        public static PropertyGridParameterCollection GetNewPropData()
        {
            return new PropertyGridParameterCollection()
            {
                new PropertyGridParameter()
                {
                    Name = "firstName",
                    Value = "Mike",
                    DisplayName = "First Name"
                },
                new PropertyGridParameter()
                {
                    Name = "lastName",
                    Value = "Bray",
                    DisplayName = "Last Name"
                },
                new PropertyGridParameter()
                {
                    Name = "dob",
                    Value = "new Date(1986, 3, 15)",
                    Mode = ParameterMode.Raw,
                    DisplayName = "D.O.B"
                },
                new PropertyGridParameter()
                {
                    Name = "color",
                    Value = "Red",
                    DisplayName = "Color",
                    Editor =
                    {
                        new ComboBox()
                        {
                            Items =
                            {
                                new Ext.Net.ListItem("Red"),
                                new Ext.Net.ListItem("Green"),
                                new Ext.Net.ListItem("Blue")
                            },
                            ForceSelection = true
                        }
                    },
                    Renderer =
                    {
                        Handler = "return Ext.String.format('<span style=\"color: {0};\">{1}</span>', value.toLowerCase(), value)"
                    }
                },
                new PropertyGridParameter()
                {
                    Name = "score",
                    Value = "null",
                    DisplayName = "Score",
                    EditorType = PropertyGridEditorType.Number
                }
            };
        }
    }
}