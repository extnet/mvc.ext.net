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

    <ext:Viewport runat="server" Layout="fit">
        <Items>
            <ext:TabPanel runat="server">
                <Items>
                    <ext:Panel runat="server" Title="Load View Into Container">
                        <TopBar>
                            <ext:Toolbar runat="server">
                                <Items>
                                    <ext:Button runat="server" Text="Load">
                                        <DirectEvents>
                                            <Click Url="/Dynamic_Partial_Rendering/ASPX_Engine/View1">
                                                <ExtraParams>
                                                    <ext:Parameter Name="containerId" Value="Tab1_Div" />
                                                </ExtraParams>
                                            </Click>
                                        </DirectEvents>
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </TopBar>

                        <Content>
                            <div id="Tab1_Div">
                            </div>
                        </Content>
                    </ext:Panel>

                    <ext:Panel runat="server" Title="Load View With Layout" Layout="Border">
                        <Items>
                            <ext:Panel ID="Tab2_West" runat="server" Title="West" Width="250" Layout="AccordionLayout" Region="West" />
                            <ext:Panel runat="server" Title="Center" MarginSpec="0 0 0 5" Region="Center">
                                <Items>
                                    <ext:Button runat="server" Text="Click to load west region">
                                        <DirectEvents>
                                            <Click Url="/Dynamic_Partial_Rendering/ASPX_Engine/View2">
                                                <ExtraParams>
                                                    <ext:Parameter Name="containerId" Value="#{Tab2_West}" Mode="Value" />
                                                </ExtraParams>
                                            </Click>
                                        </DirectEvents>
                                    </ext:Button>
                                </Items>
                            </ext:Panel>
                        </Items>
                    </ext:Panel>

                    <ext:Panel ID="Tab3" runat="server" Title="Load View Via AutoLoad">
                        <Loader runat="server" Url="/Dynamic_Partial_Rendering/ASPX_Engine/View1" DisableCaching="true" TriggerEvent="activate" TriggerControl="#{Tab3}" Mode="Script">
                            <Params>
                                <ext:Parameter Name="containerId" Value="Tab3-innerCt" />
                            </Params>
                        </Loader>
                    </ext:Panel>

                    <ext:Panel runat="server" Title="Load view as tab item" Padding="10">
                        <Content>
                            <ext:Button runat="server" Text="Add tab">
                                <DirectEvents>
                                    <Click Url="/Dynamic_Partial_Rendering/ASPX_Engine/View3">
                                        <ExtraParams>
                                            <ext:Parameter Name="containerId" Value="#{Tab4_SubTabs}" Mode="Value" />
                                        </ExtraParams>
                                    </Click>
                                </DirectEvents>
                            </ext:Button>
                            <br />
                            <ext:TabPanel ID="Tab4_SubTabs" runat="server" Width="300">
                                <Listeners>
                                    <Add Handler="this.setActiveTab(component);" />
                                </Listeners>
                            </ext:TabPanel>
                        </Content>
                    </ext:Panel>

                    <ext:Panel runat="server" Title="Load Window" Padding="10">
                        <Content>
                            <ext:Button runat="server" Text="Show Window">
                                <DirectEvents>
                                    <Click Url="/Dynamic_Partial_Rendering/ASPX_Engine/View4" />
                                </DirectEvents>
                            </ext:Button>
                        </Content>
                    </ext:Panel>
                </Items>
            </ext:TabPanel>
        </Items>
    </ext:Viewport>
</body>
</html>
