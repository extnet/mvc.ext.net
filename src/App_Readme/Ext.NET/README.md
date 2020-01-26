| Product | Ext.NET Enterprise |
| :---- | :---- |
| Release Date | 2020-01-26 |
| Current Version | 5.1.0 |
| Issue Tracker | [Ext.NET](https://github.com/extnet/Ext.NET/issues) on GitHub |

## Contents

1. [System Requirements](#1-system-requirements)
2. [Installation Instructions](#2-installation-instructions)
3. [Revisions and Breaking Changes](#3-revisions-and-breaking-changes)
4. [Sample Web.config](#4-sample-webconfig)
5. [Browser Support](#5-browser-support)
6. [Web.config Global Configuration Properties](#6-webconfig-global-configuration-properties)
7. [MVC Installation Tips](#7-mvc-installation-tips)
8. [Credits](#8-credits)

## 1. System Requirements

1. Visual Studio 2015, 2017, 2019, or
2. Visual Studio Community 2015, 2017, 2019
3. .NET Framework 4.0, 4.5, 4.5.2 and 4.6

## 2. Installation Instructions

[Getting Started](https://www.nuget.org/packages/ext.net) (NuGet)

The easiest and quickest way to install Ext.NET is using [NuGet](https://www.nuget.org/packages/ext.net). Run the following command in Visual Studio Command panel, or seach for "Ext.NET" in NuGet Package Manager.

```
Install-Package Ext.NET
```

[Getting Started](https://forums.ext.net/showthread.php?11027-Install-and-Setup-Guide-for-Visual-Studio) (Manual Installation with Videos)

## 3. Revisions and Breaking Changes

See [CHANGELOG.md](https://github.com/extnet/Premium/blob/master/CHANGELOG.md), or view in the Examples Explorers:

 - [WebForms Examples Explorer](https://examples.ext.net/#/Getting_Started/Release_Documents/README/)
 - [MVC Examples Explorer](https://examples.ext.net/#/Getting_Started/Release_Documents/BREAKING_CHANGES/)

## 4. Sample Web.config

```xml
<?xml version="1.0"?>
<configuration>
  <configSections>
    <section name="extnet" type="Ext.Net.GlobalConfig" requirePermission="false" />
  </configSections>

  <extnet theme="Triton" licenseKey="** Ext.NET LICENSE KEY HERE **" initScriptMode="Linked" />
  
  <system.web>
    <!-- This httpHandlers config only required if using IIS6 (or lower) -->
    <!--
    <httpHandlers>
      <add path="*/ext.axd" verb="*" type="Ext.Net.ResourceHandler" validate="false" />
    </httpHandlers>
    -->

    <!-- This httpModules config only required if using IIS6 (or lower) -->
    <!--
    <httpModules>
      <add name="DirectRequestModule" type="Ext.Net.DirectRequestModule, Ext.Net" />
    </httpModules>
    -->

    <pages>
      <controls>
        <add assembly="Ext.Net" namespace="Ext.Net" tagPrefix="ext" />
      </controls>
      <namespaces>
        <add namespace="Ext.Net"/>
        <!--<add namespace="Ext.Net.MVC"/>-->
      </namespaces>      
    </pages>
  </system.web>

  <system.webServer>
    <validation validateIntegratedModeConfiguration="false" />
    
    <modules>
      <add name="DirectRequestModule" preCondition="managedHandler" type="Ext.Net.DirectRequestModule, Ext.Net" />
    </modules>
    
    <handlers>
      <add name="DirectRequestHandler" verb="*" path="*/ext.axd" preCondition="integratedMode" type="Ext.Net.ResourceHandler" />
    </handlers>
  </system.webServer>

  <runtime>
    <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
      <dependentAssembly>
        <assemblyIdentity name="Newtonsoft.Json" publicKeyToken="30ad4fe6b2a6aeed" />
        <bindingRedirect oldVersion="0.0.0.0-12.0.3.0" newVersion="12.0.3.0" />
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name="Ext.Net.Utilities" publicKeyToken="2c34ac34702a3c23" />
        <bindingRedirect oldVersion="0.0.0.0-2.5.0" newVersion="2.5.0" />
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name="Transformer.NET" publicKeyToken="e274d618e7c603a7" />
        <bindingRedirect oldVersion="0.0.0.0-2.1.1" newVersion="2.1.1" />
      </dependentAssembly>

      <!--MVC 4-->
      <!--
      <dependentAssembly>
        <assemblyIdentity name="System.Web.Helpers" publicKeyToken="31bf3856ad364e35" />
        <bindingRedirect oldVersion="1.0.0.0-2.0.0.0" newVersion="2.0.0.0" />
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name="System.Web.WebPages" publicKeyToken="31bf3856ad364e35" />
        <bindingRedirect oldVersion="1.0.0.0-2.0.0.0" newVersion="2.0.0.0" />
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name="System.Web.Mvc" publicKeyToken="31bf3856ad364e35" />
        <bindingRedirect oldVersion="0.0.0.0-4.0.40804" newVersion="4.0.40804" />
      </dependentAssembly>
      -->

      <!--MVC 5-->
      <!--
      <dependentAssembly>
        <assemblyIdentity name="System.Web.Helpers" publicKeyToken="31bf3856ad364e35"/>
        <bindingRedirect oldVersion="1.0.0.0-3.0.0.0" newVersion="3.0.0.0"/>
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name="System.Web.WebPages" publicKeyToken="31bf3856ad364e35"/>
        <bindingRedirect oldVersion="1.0.0.0-3.0.0.0" newVersion="3.0.0.0"/>
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name="System.Web.Mvc" publicKeyToken="31bf3856ad364e35"/>
        <bindingRedirect oldVersion="1.0.0.0-5.2.7.0" newVersion="5.2.7.0"/>
      </dependentAssembly>
      -->
    </assemblyBinding>
  </runtime>
</configuration>
```

## 5. Browser Support

Official Ext JS [browser support](http://docs.sencha.com/extjs/6.2.1/guides/supported_browsers.html).

| Platform | Browser | Version |
| ---- | ---- | ---- |
| Desktop | | |
| | IE8+ | Strict DOCTYPE |
| | Microsoft Edge | Latest 2 Versions |
| | Firefox | Latest 2 Versions |
| | Chrome | Latest 2 Versions |
| | Opera | Latest 2 Versions |
| | Safari | 7+ |
| Tablet | | |
| | Safari | 7+ iPad |
| | Android | 4.0+ Chrome |
| | Android | 4.4+ Native |
| | Windows 8 Touch Screen | IE10+ |

## 6. Web.config Global Configuration Properties

| Name | Type | Description |
| :---- | :---- | :---- |
| ajaxTimeout | int | Sets the default Timeout in milliseconds for all AJAX operations: DirectEvents, DirectMethods, loading data to Stores via AJAX (PageProxy, AjaxProxy). Default is `30000`. |
| ajaxViewStateMode | ViewStateMode | Specifies whether the ViewState should be returned and updated on the client during an DirectEvent. The Default value is to Exclude the ViewState from the Response. Default is `Default`. Options include [`Default` \| `Exclude` \| `Include`] |
| cleanResourceUrl | bool | The Ext.NET controls can clean up the autogenerated WebResource URL so they look presentable. Default is `True`. Options include [`True` \| `False`] |
| dateTimeZoneHandling | DateTimeZoneHandling | Specifies how to treat the time value when converting between string and DateTime. This is a Json.NET setting. [More details](http://james.newtonking.com/json/help/index.html?topic=html/SerializeDateTimeZoneHandling.htm) |
| disableViewState | bool | Specifies whether remove ViewState from page's rendering or not. Defaults is `True` (removes ViewState). |
| directEventUrl | string | The url to request for all DirectEvents. Default is `""`.
| directMethodProxy | ClientProxy | Specifies whether server-side Methods marked with the `[DirectMethod]` attribute will output configuration script to the client. If not, the DirectMethods can still be called, but the DirectMethod proxies are not automatically generated. Default is `Default` (it creates the proxy for each DirectMethod). Options include [`Default` \| `Include` \| `Ignore`] |
| directMethodNamespace | string | Specifies a custom namespace prefix to use for the DirectMethods. Defaults to `App.direct`. |
| enableAria | bool | Set to true to enable Accessibility (ARIA). Defaults to `True`. |
| enableAriaButtons | bool | Set to false to disable WAI-ARIA compatibility checks for buttons. Defaults to `True`. |
| enableAriaPanels | bool | Set to false to disable WAI-ARIA compatibility checks for panels. Defaults to `True`. |
| enableKeyboardMode | bool | When set to 'true', focus styling will be applied to focused elements based on the user interaction mode. |
| glyphFontFamily | string | Sets the default font-family to use for components that support a glyph config. Default is `""`. |
| gzip | bool | Whether to automatically render scripts with gzip compression. Only works when `renderScripts="Embedded"` and/or `renderStyles="Embedded"`. Default is `True`. Options include [`True` \| `False`] |
| idMode | IDMode | Manages how a control's id is rendered to the client. Default is `Explicit`. Options include [`Client` \| `Explicit` \| `Ignore` \| `Inherit` \| `Legacy` \| `Parent` \| `Predictable` \| `Static`] |
| initScriptMode | InitScriptMode | Specifies how to render the Ext.NET initialization script. The options are self-explanatory. Default is 'Linked'. Options include [`Inline` \| `Linked` \| `LinkedJS`] |
| licenseKey | string | Your Ext.NET License key |
| locale | string | Specifies the language of the Ext.NET localization resources to use. For example, `en-GB`, `fr-CA`, `ru`. Default is English. |
| namespace | string | The application's JavaScript namespace. Default is `App`. |
| renderScripts | ResourceLocationType | Whether to have the Ext.NET controls output the required JavaScript includes or not. Gives a developer the option of manually including the required `&lt;script>` files. Default is `Embedded`. Options include [`Embedded` \| `File` \| `CDN` \| `None`] |
| renderStyles | ResourceLocationType | Whether to have the Ext.NET controls output the required StyleSheet includes or not. Provides a developer with the option to include the required `&lt;script>` files manually. Default is `Embedded`. Options include [`Embedded` \| `File` \| `CDN` \| `None`] |
| resourcePath | string | Specifies the prefix of the URL path to the base `~/Ext.Net/` folder containing the resources files for this project. The path can be Absolute or Relative. |
| resourcesStrategyType | string | The class name with the logic to map Ext.NET resources to arbitrary URLs, i.e. to provide custom functionality for registering of resources (JavaScript, CSS). Returning `null` for a specific resource means the default URL. Returning an empty string means to prevent registering of a specific resource at all. The default strategy is in this file: **src\Core\ResourcesStrategy.cs**. |
| resetStyles | bool | Set as `True` to reset default browser styles. Default is `False`. Options include [`True` \| `False`] |
| rethrowAjaxExceptions | bool | Rethrow AJAX exceptions from catch sections. Default is `False`. Options include [`True` \| `False`] |
| rtl | bool | True to layout the page in `rtl` (right-to-left) mode. Default is `False`. Options include [`True` \| `False`] |
| scriptMode | ScriptMode | Specifies whether the Scripts should be rendered in Release (minified), Debug (non-minified). Default is `Release`. Options include [`Release` \| `Debug`] |
| separateUIStyles | bool | Set to `True` to separate the CSS files required for each UI style into individual files. Each UI CSS file will be rendered to the Page as a separate include. So, if some UI pattern is not used, its CSS styles are not loaded. If false, all the UI styles are combined into the only .css file. So, the styles for all UI patterns are loaded regadless it is actually used or not. Default is `True`. Options include [`True` \| `False`] |
| showWarningOnAjaxFailure | bool | Show a warning dialog on ajax event failure or not. Default is 'True'. Options include [`True` \| `False`] |
| sourceFormatting | bool | Specifies whether the Ext.NET initializaztion script rendered to the page should be formatted. 'True' = formatted/non-minified, 'False' = minified/compressed. Default is 'False'. Options include [`True` \| `False`] |
| stateProvider | StateProvider | Specifies the current state provider to maintain the controls' state. Default is `PostBack`. Options include [`PostBack` \| `Cookie` \| `None`] |
| submitDisabled | bool | If `False` then disabled fields will not be submitted. Default is 'False'. Options include [`True` \| `False`] |
| theme | Theme | Specifies the embedded theme to use. Default is `Default` (blue theme). Options include [`Aria` \| `Crisp` \| `CrispTouch` \| `Default` \| `Gray` \| `Neptune` \| `NeptuneTouch` \| `Triton` \| `None`] |
| themePath | string | Configure the path to the custom theme .css and .js (if required) file globally across the entire application. This will override any `.Theme` setting. You can specify several files by delimiting them with `|`. For example, `some.css|another.css|some.js|another.js`. Regularly, you will need to specify the only .css file, for example, `some.css` or two files - one .css and one .js - `some.js|some.css`. Default is `""`. |
| quickTips | bool | Specifies whether to render the QuickTips. Provides attractive and customizable tooltips for any element. Default is 'True'. Options include [`True` \| `False`] |

## 7. MVC Installation Tips

If manually installing Ext.NET MVC into your project, the following `IgnoreRoute` config is required.

```csharp
public static void RegisterRoutes(RouteCollection routes)
{
    // Ignore all ext.axd embedded resource paths
    routes.IgnoreRoute("{extnet-root}/{extnet-file}/ext.axd");
}
```

This `IgnoreRoute` is automatically inserted if using the NuGet package [installer](https://www.nuget.org/packages/ext.net). 

## 8. Credits

1. [FamFamFam](http://www.famfamfam.com/lab/icons/silk/) Icons provided by Mark James ([LICENSE](https://github.com/extnet/Premium/blob/master/.build/licenses/FamFamFam.md))
1. [Flag icons](http://www.famfamfam.com/lab/icons/flags/) provided by Mark James ([LICENSE](https://github.com/extnet/Premium/blob/master/.build/licenses/FlagIcons.md))
1. [Silk](http://damieng.com/creative/icons/silk-companion-1-icons) companion icon set #1 - "More Silk!" provided by Damien Guard ([LICENSE](https://github.com/extnet/Premium/blob/master/.build/licenses/Newtonsoft.Json.md))
1. [Json.NET](http://json.net/) provided by James Newton-King ([LICENSE](https://github.com/extnet/Premium/blob/master/.build/licenses/Newtonsoft.Json.md))
1. [Ext JS](http://www.sencha.com/products/js/) JavaScript Library with Commercial License provided by Sencha, Inc. ([LICENSE](https://github.com/extnet/Premium/blob/master/.build/licenses/Sencha.md))

Copyright 2008-2020 [Object.NET](https://object.net/), Inc., All rights reserved.
