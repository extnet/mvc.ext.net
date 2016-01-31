<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Tuple<string>>" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<ext:Panel runat="server" Title='<%# Model.Item1 + "1" %>' AutoDataBind="true" />
<ext:Panel runat="server" Title='<%# Model.Item1 + "2" %>' AutoDataBind="true" />
<ext:Panel runat="server" Title='<%# Model.Item1 + "3" %>' AutoDataBind="true" />
<ext:Panel runat="server" Title='<%# Model.Item1 + "4" %>' AutoDataBind="true" />
<ext:Panel runat="server" Title='<%# Model.Item1 + "5" %>' AutoDataBind="true" />