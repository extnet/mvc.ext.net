<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<ext:Window 
    runat="server"
    Title="Compose message"
    Collapsible="true"
    Maximizable="true"
    Width="550"
    Height="300"
    CloseAction="Destroy"
    Layout="Fit"
    Plain="true"
    BodyPadding="5"
    ButtonAlign="Center">
    <Items>
        <ext:FormPanel 
            runat="server"
            BaseCls="x-plain" 
            Layout="VBoxLayout">
            <LayoutConfig>
                <ext:VBoxLayoutConfig Align="Stretch" />
            </LayoutConfig>
            <Items>
                <ext:ComboBox 
                    runat="server" 
                    LabelWidth="55"
                    FieldLabel="Send To"                            
                    Name="sendTo">
                    <Items>
                        <ext:ListItem Text="test@example.com" />
                        <ext:ListItem Text="someone@example.com" />
                    </Items>
                </ext:ComboBox>

                <ext:TextField runat="server" 
                    LabelWidth="55" 
                    FieldLabel="Subject"
                    Name="subject">
                    <Plugins>
                        <ext:ClearButton runat="server" />
                    </Plugins>
                </ext:TextField>
                <ext:TextArea runat="server" 
                    Flex="1" 
                    Name="body">
                    <Plugins>
                        <ext:ClearButton runat="server" />
                    </Plugins>
                </ext:TextArea>
            </Items>
        </ext:FormPanel>
    </Items>
    <Buttons>
        <ext:Button runat="server" Text="Send" Handler="Ext.net.Bus.publish('MyWindow.SubmitForm', {formId : this.up('window').down('form').id});" />
        <ext:Button runat="server" Text="Cancel" Handler="this.up('window').close();" />
    </Buttons>
    
    <Factory Alias="mywindow1" Instance="My.Window1" />
</ext:Window>