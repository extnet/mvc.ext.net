<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<ext:DesktopModuleProxy runat="server">
    <Module ModuleID="tab-win">
        <Shortcut Name="Tab Window" />
        <Launcher Text="Tab Window" Icon="Tab" />
        <Window>
            <ext:Window runat="server"
                Icon="Tab"
                Width="740" 
                Height="480" 
                ConstrainHeader="true"         
                Border="false"       
                Layout="Fit"
                Title="Tab Window">
                <Items>
                    <ext:TabPanel runat="server" ActiveTabIndex="0" BodyStyle="padding:5px;">
                        <Items>
                            <ext:Panel runat="server" Title="Tab Text 1" Border="false" Html="<p>Something useful would be in here.</p>">                            
                            </ext:Panel>

                            <ext:Panel runat="server" Title="Tab Text 2" Border="false" Html="<p>Something useful would be in here.</p>">                            
                            </ext:Panel>

                            <ext:Panel runat="server" Title="Tab Text 3" Border="false" Html="<p>Something useful would be in here.</p>">                            
                            </ext:Panel>

                            <ext:Panel runat="server" Title="Tab Text 4" Border="false" Html="<p>Something useful would be in here.</p>">                            
                            </ext:Panel>
                        </Items>
                    </ext:TabPanel>
                </Items>
            </ext:Window>
        </Window>
    </Module>
</ext:DesktopModuleProxy>