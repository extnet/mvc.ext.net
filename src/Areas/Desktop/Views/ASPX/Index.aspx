<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Desktop - Ext.NET MVC Examples</title>
</head>
<body>
    <ext:ResourceManager runat="server" />

    <ext:Window
        runat="server"
        Closable="false"
        Resizable="false"
        Height="200"
        Icon="Lock"
        Title="Login"
        Draggable="false"
        Width="350"
        Modal="true"
        BodyPadding="5"
        Layout="FitLayout">
        <Items>
            <ext:FormPanel runat="server" Layout="FormLayout" Border="false" BodyStyle="background-color:transparent;">
                <Items>
                    <ext:TextField
                        ID="txtUsername"
                        runat="server"
                        ReadOnly="true"
                        FieldLabel="Username"
                        AllowBlank="false"
                        BlankText="Your username is required."
                        Text="Demo"
                        />
                    <ext:TextField
                        ID="txtPassword"
                        runat="server"
                        ReadOnly="true"
                        InputType="Password"
                        FieldLabel="Password"
                        AllowBlank="false"
                        BlankText="Your password is required."
                        Text="Demo"
                        />
                </Items>
            </ext:FormPanel>
        </Items>
        <Buttons>
            <ext:Button ID="Button1" runat="server" Text="Login" Icon="Accept">
                <DirectEvents>
                    <Click Action="Login" Success="this.up('window').close();" FormID="#(return this.up('window').down('form');)">
                        <EventMask ShowMask="true" Msg="Verifying..." MinDelay="1000" />
                    </Click>
                </DirectEvents>
            </ext:Button>
        </Buttons>
    </ext:Window>
</body>
</html>