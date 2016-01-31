<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" />
</head>
<body>
    <ext:ResourceManager runat="server" />

    <ext:FormPanel runat="server" 
        Layout="FormLayout" 
        Width="350"
        BodyPadding="10"
        Frame="true">
        <FieldDefaults LabelWidth="150" />

        <Items>
            <ext:TextField runat="server" ControlFor="TextValue" />
            <ext:DateField runat="server" ControlFor="DateTimeValue" />
            <ext:ComboBox runat="server" ControlFor="ComboValue1">
                <Items>
                    <ext:ListItem Text="Item 1" Value="1" />
                    <ext:ListItem Text="Item 2" Value="2" />
                    <ext:ListItem Text="Item 3" Value="3" />
                </Items>
            </ext:ComboBox>
            <ext:ComboBox runat="server" ControlFor="ComboValue2">
                <Items>
                    <ext:ListItem Text="Item 1" Value="1" />
                    <ext:ListItem Text="Item 2" Value="2" />
                    <ext:ListItem Text="Item 3" Value="3" />
                </Items>
            </ext:ComboBox>
            <ext:ComboBox runat="server" ControlFor="ComboValue3">
                <Items>
                    <ext:ListItem Text="Item 1" Value="1" />
                    <ext:ListItem Text="Item 2" Value="2" />
                    <ext:ListItem Text="Item 3" Value="3" />
                </Items>
            </ext:ComboBox>
            <ext:Checkbox runat="server" ControlFor="CheckboxValue" />
            <ext:NumberField runat="server" ControlFor="NumberValue" />
            <ext:Slider runat="server" ControlFor="MultiSliderValue" />
        </Items>
    </ext:FormPanel>
</body>
</html>
