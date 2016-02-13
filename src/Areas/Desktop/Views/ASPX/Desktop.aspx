<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<%@ Register Src="AccordionWindow.ascx" TagPrefix="mod" TagName="AccordionWindow" %>
<%@ Register Src="GridWindow.ascx" TagPrefix="mod" TagName="GridWindow" %>
<%@ Register Src="WhatsNew.ascx" TagPrefix="mod" TagName="WhatsNew" %>
<%@ Register Src="SystemStatus.ascx" TagPrefix="mod" TagName="SystemStatus" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Ext.NET Examples</title>

    <link href="/Areas/Desktop/Content/desktop.css" rel="stylesheet" />

    <script>
        var tile = function () {
            Ext.net.Desktop.desktop.tileWindows();
        };

        var cascade = function () {
            Ext.net.Desktop.desktop.cascadeWindows();
        };

        var initSlidePanel = function () {
            this.setHeight(Ext.net.Desktop.desktop.body.getHeight());

            if (!this.windowListen) {
                this.windowListen = true;

                this.el.alignTo(Ext.net.Desktop.desktop.body, 'tl-tr', [0, 0]);
                Ext.on("resize", initSlidePanel, this);
            }
        };
    </script>
</head>
<body>
        <ext:ResourceManager runat="server" />

        <ext:Desktop ID="Desktop1" runat="server">
            <Modules>
                <ext:DesktopModule ModuleID="Hello" AutoRun="true">
                    <Window>
                        <ext:Window runat="server"
                            Plain="true"
                            Padding="10"
                            Width="150"
                            Height="100"
                            Title="Greeting"
                            CloseAction="Destroy"
                            Maximizable="false"
                            Minimizable="false">
                            <Content>
                                Welcome to Ext.Net desktop!
                            </Content>
                        </ext:Window>
                    </Window>
                </ext:DesktopModule>

                <ext:DesktopModule ModuleID="notepad">
                    <Shortcut Name="Notepad" IconCls="x-notepad-shortcut"  SortIndex="2" />
                    <Launcher Text="Notepad" Icon="ApplicationForm" />
                    <Window>
                        <ext:Window runat="server"
                            Title="Notepad"
                            Width="800"
                            Height="400"
                            Icon="ApplicationForm"
                            AnimCollapse="false"
                            Border="false"
                            HideMode="Offsets"
                            Layout="FitLayout"
                            CloseAction="Destroy">
                            <Items>
                                <ext:HtmlEditor runat="server" Text="Some <b>rich</b> <font color='red'>text</font> goes <u>here</u><br>Give it a try!">
                                </ext:HtmlEditor>
                            </Items>
                        </ext:Window>
                    </Window>
                </ext:DesktopModule>

                <ext:DesktopModule ModuleID="create-module">
                    <Shortcut Name="Create window" Handler="function() {#{DirectMethods}.CreateWindow();}" SortIndex="3">
                    </Shortcut>
                </ext:DesktopModule>

                <ext:DesktopModule ModuleID="add-module">
                    <Shortcut Name="Render dynamic module" Handler="function() {#{DirectMethods}.AddNewModule();}" X="200" Y="100" TextCls="x-long-label">
                    </Shortcut>
                </ext:DesktopModule>

                <ext:DesktopModule ModuleID="add1-module">
                    <Shortcut Name="Render another module" Handler="function() {#{DirectMethods}.AddAnotherModule();}" X="200" Y="300" TextCls="x-long-label">
                    </Shortcut>
                </ext:DesktopModule>
            </Modules>

            <DesktopConfig Wallpaper="~/Areas/Desktop/Content/wallpapers/blue.jpg" ShortcutDragSelector="true">
                <ShortcutDefaults IconCls="x-default-shortcut" />
                <ContextMenu>
                    <ext:Menu runat="server">
                        <Items>
                            <ext:MenuItem runat="server" Text="Change Settings" />
                            <ext:MenuSeparator runat="server" />
                            <ext:MenuItem runat="server" Text="Tile" Handler="tile" Icon="ApplicationTileVertical" />
                            <ext:MenuItem runat="server" Text="Cascade" Handler="cascade" Icon="ApplicationCascade" />
                        </Items>
                    </ext:Menu>
                </ContextMenu>

                <Content>
                   <ext:Image runat="server" ImageUrl="~/Areas/Desktop/Content/logo.png" StyleSpec="position:absolute;top: 50%;left: 50%;width: 77px; height: 78px;margin-top: -39px; margin-left: -39px;"/>
                   <ext:Image runat="server" ImageUrl="~/Areas/Desktop/Content/powered.png" StyleSpec="position:absolute;right:10px;bottom:20px;width:300px;height:39px;"/>

                    <ext:DisplayField runat="server" Text="You can place controls to desktop" FieldStyle="color:white;font-size:24px;" StyleSpec="position:absolute;left: 50%; bottom: 100px;margin-left: -180px;"/>
                   <ext:DisplayField runat="server" Text="Move mouse to the right edge -->" FieldStyle="color:white;font-size:24px;" StyleSpec="position:absolute;right:50px;top:50px;"/>

                   <ext:Toolbar runat="server" Width="320" Floating="true" ClassicButtonStyle="true" Flat="true" Border="false" Shadow="false">
                        <Defaults>
                            <ext:Parameter Name="IconAlign" Value="top" />
                            <ext:Parameter Name="Width" Value="60" />
                            <ext:Parameter Name="Icon" Value='<%# Url.Content("~/Areas/Desktop/Content/cmd.png") %>' AutoDataBind="true" />
                            <ext:Parameter Name="Scale" Value="large" />
                            <ext:Parameter Name="Handler" Value="function(){Ext.Msg.alert('Launch', this.text);}" Mode="Raw" />
                        </Defaults>
                        <Items>
                            <ext:Button runat="server" Text="Word" />
                            <ext:Button runat="server" Text="Excel" />
                            <ext:Button runat="server" Text="Notepad" />
                            <ext:Button runat="server" Text="Paint" />
                            <ext:Button runat="server" Text="Explorer" />
                        </Items>
                        <MessageBusListeners>
                            <ext:MessageBusListener Name="App.Desktop.ready" Handler="this.el.anchorTo(Ext.net.Desktop.desktop.body, 'c-b', [0, -50]);" />
                        </MessageBusListeners>
                    </ext:Toolbar>
                </Content>
            </DesktopConfig>

            <StartMenu Title="Ext.Net Desktop" Icon="Application" Height="300">
                <ToolConfig>
                    <ext:Toolbar runat="server" Width="100">
                        <Items>
                            <ext:Button runat="server" Text="Settings" Icon="Cog" />
                            <ext:Button runat="server" Text="Logout" Icon="Key">
                                <DirectEvents>
                                    <Click Action="Logout">
                                        <EventMask ShowMask="true" Msg="Good Bye..." MinDelay="1000" />
                                    </Click>
                                </DirectEvents>
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </ToolConfig>
            </StartMenu>

            <TaskBar TrayWidth="110">
                <QuickStart>
                    <ext:Toolbar runat="server" Width="70">
                        <Items>
                            <ext:Button runat="server" Handler="tile" Icon="ApplicationTileVertical">
                                <QTipCfg Text="Tile windows" />
                            </ext:Button>

                            <ext:Button runat="server" Handler="cascade" Icon="ApplicationCascade">
                                <QTipCfg Text="Cascade windows" />
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </QuickStart>

                <Tray>
                    <ext:Toolbar runat="server">
                        <Items>
                            <ext:Button ID="LangButton" runat="server" Text="EN" ArrowVisible="false" Cls="x-bold-text" MenuAlign="br-tr">
                                <Menu>
                                    <ext:Menu runat="server">
                                        <Items>
                                            <ext:CheckMenuItem runat="server" Group="lang" Text="English" Checked="true" CheckHandler="function(item, checked) {checked && #{LangButton}.setText('EN');}" />
                                            <ext:CheckMenuItem runat="server" Group="lang" Text="French" CheckHandler="function(item, checked) {checked && #{LangButton}.setText('FR');}" />
                                            <ext:MenuSeparator runat="server" />
                                            <ext:MenuItem runat="server" Text="Show the Language Bar" />
                                        </Items>
                                    </ext:Menu>
                                </Menu>
                            </ext:Button>
                            <ext:ToolbarFill runat="server" />
                        </Items>
                    </ext:Toolbar>
                </Tray>
            </TaskBar>
            <Listeners>
                <Ready BroadcastOnBus="App.Desktop.ready" />
            </Listeners>
        </ext:Desktop>

        <ext:Panel runat="server" Title="Slide panel" Frame="true" Width="250" Layout="AccordionLayout" Floating="true" Shadow="false">
            <Items>
                <ext:Panel runat="server" Title="Section 1" Icon="User" />
                <ext:Panel runat="server" Title="Section 2" Icon="UserB" />
                <ext:Panel runat="server" Title="Section 3" Icon="UserB" />
                <ext:Panel runat="server" Title="Section 4" Icon="UserB" />
                <ext:Panel runat="server" Title="Section 5" Icon="UserB" />
            </Items>
            <MessageBusListeners>
                <ext:MessageBusListener Name="App.Desktop.ready" Fn="initSlidePanel" />
            </MessageBusListeners>
            <Plugins>
                <ext:MouseDistanceSensor runat="server" Opacity="false" Threshold="25">
                    <Listeners>
                        <Near Handler="this.component.el.alignTo(Ext.net.Desktop.desktop.body, 'tr-tr', [0, 0], true);" />
                        <Far Handler="this.component.el.alignTo(Ext.net.Desktop.desktop.body, 'tl-tr', [0, 0], true);" />
                    </Listeners>
                </ext:MouseDistanceSensor>
            </Plugins>
        </ext:Panel>

        <%--Modules from User controls--%>
        <mod:AccordionWindow runat="server" />
        <mod:GridWindow runat="server" />
        <mod:SystemStatus runat="server" />
        <mod:WhatsNew runat="server" />
</body>
</html>