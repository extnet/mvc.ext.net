<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HighLighterButton.ascx.cs" Inherits="Ext.Net.Examples.HighLighter.HighLighterButton" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<ext:ResourceManagerProxy runat="server" />

<ext:Button  ID="btnSource" runat="server" Text="Source" Icon="PageWhiteCode">
    <DirectEvents>
        <Click OnEvent="btnSource_Click" />
    </DirectEvents>
</ext:Button>

<ext:Window 
    ID="winSource" 
    runat="server" 
    Title="Source"
    CloseAction="Hide" 
    Collapsible="true" 
    Height="600px" 
    AutoScroll="true"
    BodyStyle="background-color: #fff;"
    BodyPadding="6"
    Icon="PageWhiteCode"
    Width="900"
    ShowOnLoad="false"     
    AnimateTarget="btnSource"
    />
