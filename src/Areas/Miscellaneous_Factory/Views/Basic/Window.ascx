<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<ext:Window runat="server"     
    FactoryAlias="mywindow1">
    <MessageBusListeners>
        <ext:MessageBusListener Name="MyWindow.SubmitForm" Handler="App.direct.SendEmail({formId : data.formId});" />
    </MessageBusListeners>
</ext:Window>