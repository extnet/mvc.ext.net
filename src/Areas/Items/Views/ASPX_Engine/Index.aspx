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
                    <ext:Panel runat="server" Title="Load View as Content">                        
                        <Content>
                            <%= Html.ExtPartial("View1") %>
                        </Content>
                    </ext:Panel>
                    
                    <ext:Panel runat="server" Title="Load View as Items" AutoDataBind="true">
                        <Items>
                            <ext:Window ID="Tab2_Window" runat="server" 
                                Title="Items" 
                                Height="400"
                                Width="250" 
                                Constrain="true"
                                Layout="AccordionLayout">
                            </ext:Window>
                        </Items>
                        <HtmlBin>
                            <%# Html.ExtPartial("View2", mode: RenderMode.AddTo, items:true, containerId: "Tab2_Window", model: new Tuple<string>("Title "))%>
                        </HtmlBin>
                    </ext:Panel>
                    
                   <ext:Panel runat="server" Title="Load View from Action" AutoDataBind="true">
                        <Items>
                            <ext:Window ID="Tab3_Window" runat="server" 
                                Title="Items" 
                                Height="400"
                                Width="250" 
                                Constrain="true"
                                Layout="AccordionLayout">
                            </ext:Window>
                        </Items>
                        <HtmlBin>
                            <%# Html.Action("LoadView", new {containerId = "Tab3_Window", titlePrefix = "Prefix "}) %>
                        </HtmlBin>
                    </ext:Panel>
                </Items>
            </ext:TabPanel>
        </Items>
    </ext:Viewport>
</body>
</html>
