<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<ext:Window 
    runat="server" 
    Width="200" 
    Height="200" 
    Icon="Clock" 
    Title="Server Time" 
    Padding="10" 
    CloseAction="Destroy">
    <Content>
        <%= DateTime.Now.ToLongTimeString() %>
    </Content>
</ext:Window>