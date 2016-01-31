<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<ext:Panel 
    runat="server" 
    Title='<%# ViewData["title"] %>' 
    Border="false" 
    Html='<%# ViewData["html"] %>' 
    AutoDataBind="true"
    />