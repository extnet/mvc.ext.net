<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<script runat="server">
    private object[] TestData
    {
        get
        {
            return new object[]
            {
                new object[] { "3m Co", 71.72, 0.02, 0.03 },
                new object[] { "Alcoa Inc", 29.01, 0.42, 1.47 },
                new object[] { "Altria Group Inc", 83.81, 0.28, 0.34 },
                new object[] { "American Express Company", 52.55, 0.01, 0.02 },
                new object[] { "American International Group, Inc.", 64.13, 0.31, 0.49 },
                new object[] { "AT&T Inc.", 31.61, -0.48, -1.54 },
                new object[] { "Boeing Co.", 75.43, 0.53, 0.71 },
                new object[] { "Caterpillar Inc.", 67.27, 0.92, 1.39 },
                new object[] { "Citigroup, Inc.", 49.37, 0.02, 0.04 },
                new object[] { "E.I. du Pont de Nemours and Company", 40.48, 0.51, 1.28 },
                new object[] { "Exxon Mobil Corp", 68.1, -0.43, -0.64 },
                new object[] { "General Electric Company", 34.14, -0.08, -0.23 },
                new object[] { "General Motors Corporation", 30.27, 1.09, 3.74 },
                new object[] { "Hewlett-Packard Co.", 36.53, -0.03, -0.08 },
                new object[] { "Honeywell Intl Inc", 38.77, 0.05, 0.13 },
                new object[] { "Intel Corporation", 19.88, 0.31, 1.58 },
                new object[] { "International Business Machines", 81.41, 0.44, 0.54 },
                new object[] { "Johnson & Johnson", 64.72, 0.06, 0.09 },
                new object[] { "JP Morgan & Chase & Co", 45.73, 0.07, 0.15 },
                new object[] { "McDonald\"s Corporation", 36.76, 0.86, 2.40 },
                new object[] { "Merck & Co., Inc.", 40.96, 0.41, 1.01 },
                new object[] { "Microsoft Corporation", 25.84, 0.14, 0.54 },
                new object[] { "Pfizer Inc", 27.96, 0.4, 1.45 },
                new object[] { "The Coca-Cola Company", 45.07, 0.26, 0.58 },
                new object[] { "The Home Depot, Inc.", 34.64, 0.35, 1.02 },
                new object[] { "The Procter & Gamble Company", 61.91, 0.01, 0.02 },
                new object[] { "United Technologies Corporation", 63.26, 0.55, 0.88 },
                new object[] { "Verizon Communications", 35.57, 0.39, 1.11 },
                new object[] { "Wal-Mart Stores, Inc.", 45.45, 0.73, 1.63 }
            };
        }
    }
</script>

<ext:DesktopModuleProxy runat="server">
    <Module ModuleID="grid-win">
        <Shortcut Name="Grid Window" IconCls="x-grid-shortcut" SortIndex="1" />
        <Launcher Text="Grid Window" Icon="Table" />
        <Window>
            <ext:Window runat="server"
                Icon="Table" 
                Width="740" 
                Height="480"                
                Layout="Fit"
                Title="Grid Window">
                <TopBar>
                    <ext:Toolbar runat="server">
                        <Items>
                            <ext:Button runat="server" Text="Add Something" Icon="Add" ToolTip="Add a new row">
                            </ext:Button>

                            <ext:ToolbarSeparator runat="server" />

                            <ext:Button runat="server" Text="Options" Icon="Plugin">
                            </ext:Button>

                            <ext:ToolbarSeparator runat="server" />

                            <ext:Button runat="server" Text="Remove Something" ToolTip="Remove the selected item" Icon="Decline">
                                <QTipCfg Text="Remove the selected user" />
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </TopBar>

                <Items>
                    <ext:GridPanel runat="server"
                        Border="false">
                        <Store>
                            <ext:Store runat="server" Data="<%# TestData %>" AutoDataBind="true">
                                <Model>
                                    <ext:Model runat="server">
                                        <Fields>
                                            <ext:ModelField Name="Company" />
                                            <ext:ModelField Name="Price" Type="Float" />
                                            <ext:ModelField Name="Change" Type="Float" />
                                            <ext:ModelField Name="PctChange" Type="Float" />
                                        </Fields>
                                    </ext:Model>
                                </Model>
                                <Reader>
                                    <ext:ArrayReader />
                                </Reader>
                            </ext:Store>
                        </Store>

                        <ColumnModel>
                            <Columns>
                                <ext:RowNumbererColumn runat="server" />
                                <ext:Column runat="server" Text="Company" Flex="1" Sortable="true" DataIndex="Company" />
                                <ext:Column runat="server" Text="Price" Width="70" Sortable="true" DataIndex="Price">
                                    <Renderer Format="UsMoney" />
                                </ext:Column>
                                <ext:Column runat="server" Text="Change" Width="70" Sortable="true" DataIndex="Change" />
                                <ext:Column runat="server" Text="% Change" Width="70" Sortable="true" DataIndex="PctChange" />
                            </Columns>
                        </ColumnModel>
                    </ext:GridPanel>
                </Items>
            </ext:Window>
        </Window>
    </Module>
</ext:DesktopModuleProxy>