<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<script runat="server">
    public static string[] MemoryColors = new string[]{ "rgb(244, 16, 0)", "rgb(248, 130, 1)", "rgb(0, 7, 255)", "rgb(84, 254, 0)" };
    
    protected void Page_Load(object sender, EventArgs e)
    {
        var data = new Ext.Net.MVC.Examples.Areas.Desktop.Models.SystemStatusData(true, this.CPULoadStore, this.MemoryStore, this.ProcessStore);
        Ext.Net.MVC.Examples.Areas.Desktop.Models.SystemStatusModel.UpdateCharts(data);    
    }    
</script>

<script>
    var processRenderer = function (sprite, config, rendererData, index) {
        var lowColor = Ext.draw.Color.fromString('#b1da5a'),
            record = rendererData.store.getAt(index),
            value = record.get('Memory'),
            color;

        if (value > 5) {
            color = lowColor.createDarker((value - 5) / 15).toString();
        } else {
            color = lowColor.createLighter(((5 - value) / 20)).toString();
        }

        if (value >= 8) {
            color = '#CD0000';
        }

        return {
            fillStyle: color
        };
    };
</script>

<ext:DesktopModuleProxy runat="server">
    <Module ModuleID="systemstatus">
        <Shortcut Name="System Status" IconCls="x-status-shortcut" SortIndex="2" />
        <Window>
            <ext:Window ID="SystemStatusWnd" runat="server"
                Width="800" 
                Height="600" 
                Border="false"      
                CloseAction="Destroy" 
                Layout="Fit"
                Title="System Status">
                <Bin>                    
                    <ext:Store ID="CPULoadStore" runat="server">
                        <Model>
                            <ext:Model runat="server">
                                <Fields>
                                    <ext:ModelField Name="Core1" />
                                    <ext:ModelField Name="Core2" />
                                    <ext:ModelField Name="Time" />
                                </Fields>
                            </ext:Model>
                        </Model>
                    </ext:Store>

                    <ext:Store ID="MemoryStore" runat="server">
                        <Model>
                            <ext:Model runat="server">
                                <Fields>
                                    <ext:ModelField Name="Name" />
                                    <ext:ModelField Name="Memory" />
                                </Fields>
                            </ext:Model>
                        </Model>
                    </ext:Store>

                    <ext:Store ID="ProcessStore" runat="server">
                        <Model>
                            <ext:Model runat="server">
                                <Fields>
                                    <ext:ModelField Name="Name" />
                                    <ext:ModelField Name="Memory" />
                                </Fields>
                            </ext:Model>
                        </Model>
                    </ext:Store>

                    <ext:TaskManager ID="TaskManager1" runat="server">
                        <Tasks>
                            <ext:Task TaskID="updateCharts" WaitPreviousRequest="true" AutoRun="false" Interval="2000">
                                <DirectEvents>
                                    <Update Action="UpdateTask" />
                                </DirectEvents>
                            </ext:Task>
                        </Tasks>
                    </ext:TaskManager>

                    <ext:ChartTheme runat="server" ThemeName="Memory" 
                        Colors="<%# MemoryColors %>"
                        AutoDataBind="true" />
                </Bin>
                <Items>
                    <ext:Panel runat="server">
                        <LayoutConfig>
                            <ext:HBoxLayoutConfig Align="Stretch" />
                        </LayoutConfig>
                        <Items>
                            <ext:Container runat="server" 
                                Flex="1">
                                <LayoutConfig>
                                    <ext:VBoxLayoutConfig Align="Stretch" />
                                </LayoutConfig>
                                <Items>
                                    <ext:CartesianChart ID="CPUChart1" runat="server"
                                        Flex="1"
                                        StandardTheme="Category1"
                                        Animation="false" 
                                        Legend="true"
                                        StoreID="CPULoadStore">
                                        <Axes>
                                            <ext:NumericAxis 
                                                Position="Left"
                                                Minimum="0"
                                                Maximum="100"
                                                Fields="Core1"
                                                Title="CPU Load"
                                                Grid="true">
                                                <TitleConfig Font="13px Arial" />
                                                <Label Font="11px Arial" />
                                            </ext:NumericAxis>
                                        </Axes>
                                        <Series>
                                            <ext:LineSeries
                                                Title="Core 1 (3.4GHz)"
                                                ShowMarkers="false"
                                                Fill="true"
                                                XField="Time"
                                                YField="Core1">
                                                <StyleSpec>
                                                    <ext:Sprite LineWidth="1" />
                                                </StyleSpec>
                                            </ext:LineSeries>
                                        </Series>
                                    </ext:CartesianChart>

                                    <ext:CartesianChart  ID="CPUChart2" runat="server"
                                        Flex="1"
                                        StandardTheme="Category2"
                                        Animation="false"
                                        Legend="true"
                                        StoreID="CPULoadStore">
                                        <Axes>
                                            <ext:NumericAxis 
                                                Position="Left"
                                                Minimum="0"
                                                Maximum="100"
                                                Fields="Core2"
                                                Title="CPU Load"
                                                Grid="true">
                                                <TitleConfig Font="13px Arial" />
                                                <Label Font="11px Arial" />
                                            </ext:NumericAxis>
                                        </Axes>
                                        <Series>
                                            <ext:LineSeries
                                                Title="Core 2 (3.4GHz)"
                                                Fill="true"
                                                XField="Time"
                                                YField="Core2">
                                                <StyleSpec>
                                                    <ext:Sprite LineWidth="1" />
                                                </StyleSpec>
                                            </ext:LineSeries>
                                        </Series>
                                    </ext:CartesianChart>
                                </Items>
                            </ext:Container>

                            <ext:Container runat="server" 
                                Flex="1">
                                <LayoutConfig>
                                    <ext:VBoxLayoutConfig Align="Stretch" />
                                </LayoutConfig>
                                <Items>
                                    <ext:PolarChart ID="MemoryChart" runat="server"
                                        Flex="1"
                                        StoreID="MemoryStore"
                                        InnerPadding="20"
                                        Shadow="true"
                                        Animation="true"
                                        Theme="Memory">                                        
                                        <LegendConfig runat="server" Dock="Right" />
                                        <Series>
                                            <ext:PieSeries
                                                Donut="30"
                                                AngleField="Memory"
                                                ShowInLegend="true"
                                                Highlight="true"
                                                HighlightMargin="20">
                                                <Tooltip 
                                                    runat="server"
                                                    TrackMouse="true"
                                                    Width="140"
                                                    Height="28">
                                                    <Renderer Handler="toolTip.setTitle(record.get('Name') + ': ' + Math.round(record.get('Memory') / #{MemoryStore}.sum('Memory') * 100) + '%');" />
                                                </Tooltip>                    
                                                <Label Field="Name" Display="Rotate" Font="12px Arial" />
                                            </ext:PieSeries>
                                        </Series>
                                    </ext:PolarChart>

                                    <ext:CartesianChart runat="server"
                                        Flex="1"
                                        StandardTheme="Category1"
                                        StoreID="ProcessStore">
                                        <AnimationConfig Easing="EaseInOut" Duration="750" />
                                        <Axes>
                                            <ext:NumericAxis
                                                Position="Left"
                                                Minimum="0"
                                                Maximum="10"
                                                Fields="Memory"
                                                Title="Memory">
                                                <TitleConfig Font="13px Arial" />
                                                <Label Font="11px Arial" />
                                            </ext:NumericAxis>

                                            <ext:CategoryAxis
                                                Position="Bottom"
                                                Fields="Name"
                                                Title="System Processes">
                                                <TitleConfig Font="bold 14px Arial" />
                                                <Label RotationDegrees="45" />
                                            </ext:CategoryAxis>
                                        </Axes>
                                        <Series>
                                            <ext:BarSeries
                                                Title="Processes"
                                                XField="Name"
                                                YField="Memory">
                                                <Renderer Fn="processRenderer" />
                                                <StyleSpec>
                                                    <ext:Sprite LineWidth="1" />
                                                </StyleSpec>
                                            </ext:BarSeries>
                                        </Series>
                                    </ext:CartesianChart>
                                </Items>
                            </ext:Container>
                        </Items>
                    </ext:Panel>
                </Items>   
                <Listeners>
                    <AfterRender Handler="#{TaskManager1}.startTask('updateCharts');" />
                </Listeners>             
            </ext:Window>
        </Window>
    </Module>
</ext:DesktopModuleProxy>