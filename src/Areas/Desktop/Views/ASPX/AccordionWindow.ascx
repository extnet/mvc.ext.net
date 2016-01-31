<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<script>
    var mimicRemoteLoading = function () {
        var tree = this.up('treepanel');
        tree.setLoading(true, tree.body);

        var root = tree.getRootNode();
        
        root.collapseChildren(true, false);
        
        Ext.Function.defer(function () { // mimic a server call
            tree.setLoading(false);
            root.expand(true, true);
        }, 1000);
    };
</script>

<ext:DesktopModuleProxy runat="server">
    <Module ModuleID="acc-win">
        <Shortcut Name="Accordion Window" IconCls="x-im-shortcut" QTip="List of Online Users" SortIndex="0" />
        <Launcher Text="Accordion Window" Icon="User" />
        <Window>
            <ext:Window runat="server" 
                Width="250" 
                Height="400" 
                Layout="AccordionLayout"
                Title="Accordion Window">
                <TopBar>
                    <ext:Toolbar runat="server" UIName="plain">
                        <Items>
                            <ext:Button runat="server" Icon="Connect">
                                <QTipCfg Title="Rich Tooltips" Text="Let your users know what they can do!" />
                            </ext:Button>

                            <ext:ToolbarSeparator runat="server" />

                            <ext:Button runat="server" Icon="UserAdd">
                                <QTipCfg Text="Add a new user" />
                            </ext:Button>

                            <ext:Button runat="server" Icon="UserDelete">
                                <QTipCfg Text="Remove the selected user" />
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </TopBar>

                <Items>
                    <ext:TreePanel ID="UsersTree" runat="server" 
                        RootVisible="false"
                        Lines="false"
                        AutoScroll="true"
                        Title="Online Users">
                        <Tools>
                            <ext:Tool runat="server" Type="Refresh" Handler="mimicRemoteLoading" />
                        </Tools>
                        <Store>
                            <ext:TreeStore runat="server">
                                <Root>
                                    <ext:Node Text="Online" Expanded="true">
                                        <Children>
                                            <ext:Node Text="Friends" Expanded="true">
                                                <Children>
                                                    <ext:Node Text="Brian" Icon="User" Leaf="true" />
                                                    <ext:Node Text="Kevin" Icon="User" Leaf="true" />
                                                    <ext:Node Text="Mark" Icon="User" Leaf="true" />
                                                    <ext:Node Text="Matt" Icon="User" Leaf="true" />
                                                    <ext:Node Text="Michael" Icon="User" Leaf="true" />
                                                    <ext:Node Text="Mike Jr" Icon="User" Leaf="true" />
                                                    <ext:Node Text="Mike Sr" Icon="User" Leaf="true" />
                                                    <ext:Node Text="JR" Icon="User" Leaf="true" />
                                                    <ext:Node Text="Rich" Icon="User" Leaf="true" />
                                                    <ext:Node Text="Brent" Icon="User" Leaf="true" />
                                                    <ext:Node Text="Zac" Icon="User" Leaf="true" />
                                                </Children>
                                            </ext:Node>

                                            <ext:Node Text="Family" Expanded="true">
                                                <Children>
                                                    <ext:Node Text="Kiana" Icon="UserFemale" Leaf="true" />
                                                    <ext:Node Text="Aubrey" Icon="UserFemale" Leaf="true" />
                                                    <ext:Node Text="Cale" Icon="UserGreen" Leaf="true" />
                                                </Children>
                                            </ext:Node>
                                        </Children>
                                    </ext:Node>
                                </Root>
                            </ext:TreeStore>
                        </Store>                        
                    </ext:TreePanel>

                    <ext:Panel runat="server" Title="Settings">
                        <Content>
                            <p>Something useful would be in here.</p>
                        </Content>
                    </ext:Panel>

                    <ext:Panel runat="server" Title="Even More Stuff">
                        <Content>
                            <p>Something useful would be in here.</p>
                        </Content>
                    </ext:Panel>

                    <ext:Panel runat="server" Title="My Stuff">
                        <Content>
                            <p>Something useful would be in here.</p>
                        </Content>
                    </ext:Panel>
                </Items>
            </ext:Window>
        </Window>
    </Module>
</ext:DesktopModuleProxy>