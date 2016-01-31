<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<script>
    var aspButtonHandler = function () {
        Ext.Msg.alert("ASP.NET button", "Hello");
    };
    
    var extButtonHandler = function () {
        Ext.Msg.alert("Ext.NET button", "Hello");
    };
</script>

<div style="padding:10px;">
    <h1>It is a partial view</h1>
    <asp:Button runat="server" Text="ASP.NET button - click" OnClientClick="aspButtonHandler(); return false;" />
    <ext:Button runat="server" Icon="Application" Text="Ext.Net button - click" OnClientClick="extButtonHandler();" />
</div>