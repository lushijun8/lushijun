<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConnectionStringFormat.aspx.cs" Inherits="Web.ConnectionStringFormat" validateRequest=false %>

<%@ Register assembly="Com" namespace="Com.UserControl" tagprefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height:100%">    
        <asp:TextBox ID="txtXml" runat="server" Height="300px" TextMode="MultiLine" Width="100%">&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
&lt;!--
  有关如何配置 ASP.NET 应用程序的详细信息，请访问
  http://go.microsoft.com/fwlink/?LinkId=169433
  --&gt;
&lt;configuration&gt;
  &lt;configSections&gt;
    &lt;!-- For more information on Entity Framework configuration, visit http://go.microsoft.com/fwlink/?LinkID=237468 --&gt;
    &lt;section name=&quot;entityFramework&quot; type=&quot;System.Data.Entity.Internal.ConfigFile.EntityFrameworkSection, EntityFramework, Version=4.4.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089&quot; requirePermission=&quot;false&quot; /&gt;
  &lt;/configSections&gt;
  &lt;connectionStrings&gt;
    &lt;add name=&quot;DefaultConnection&quot; providerName=&quot;System.Data.SqlClient&quot; connectionString=&quot;Data Source=(LocalDb)\v11.0;Initial Catalog=aspnet-ECWap-20150417182623;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\aspnet-ECWap-20150417182623.mdf&quot; /&gt;
  &lt;/connectionStrings&gt;
  &lt;appSettings&gt;   
    &lt;add key=&quot;NetDebugConnection&quot; value=&quot;Data Source=124.251.44.244;database=channelsales_stats;uid=channelsales_stats_w;pwd=Eeuu7f7t;&quot; /&gt;
    &lt;add key=&quot;SqlDebug&quot; value=&quot;true&quot; /&gt;
    &lt;!--日志数据库读取--&gt;
    &lt;add key=&quot;ConnectionString_RecordRead&quot; value=&quot;Data Source=124.251.44.233;database=xft_login_log;uid=xft_login_log_r;pwd=crEs46hb;&quot;/&gt;
    &lt;add key=&quot;ConnectionString_RecordWrite&quot; value=&quot;Data Source=124.251.44.233;database=xft_login_log;uid=xft_login_log_w;pwd=gBj62fej;&quot;/&gt;
    &lt;!--EC正式数据库读取--&gt;
    &lt;add key=&quot;ConnectionString_tuan_Read_MainDB&quot; value=&quot;Data Source=124.251.44.220;database=tuan;uid=tuan_channel_r;pwd=Fdxb7jcs;&quot; /&gt;
    &lt;add key=&quot;ConnectionString_tuan_Read&quot; value=&quot;(Data Source=124.251.44.59;database=tuan;uid=tuan_channel_r;pwd=Fdxb7jcs;)(Data Source=124.251.44.251;database=tuan;uid=tuan_channel_r;pwd=Fdxb7jcs;)(Data Source=124.251.44.253;database=tuan;uid=tuan_channel_r;pwd=Fdxb7jcs;)&quot; /&gt;
    &lt;add key=&quot;ConnectionString_tuan_Writer&quot; value=&quot;Data Source=124.251.44.245;database=tuan;uid=tuan_channel_w;pwd=Kmbjhqb5;&quot; /&gt;
    &lt;!--渠道电商测试库--&gt;
    &lt;add key=&quot;ConnectionString_channelsales_Read_MainDB&quot; value=&quot;database=channelsales;user id=channelsales_r;pwd=yxaq4bQ8;server=124.251.44.248;&quot; /&gt;
    &lt;add key=&quot;ConnectionString_channelsales_Read&quot; value=&quot;(database=channelsales;user id=channelsales_r;pwd=yxaq4bQ8;server=124.251.44.59;)(database=channelsales;user id=channelsales_r;pwd=yxaq4bQ8;server=124.251.44.251;)(database=channelsales;user id=channelsales_r;pwd=yxaq4bQ8;server=124.251.44.253;)&quot; /&gt;
    &lt;add key=&quot;ConnectionString_channelsales_ReadStatic&quot; value=&quot;(database=channelsales;user id=channelsales_r;pwd=yxaq4bQ8;server=124.251.44.59;)(database=channelsales;user id=channelsales_r;pwd=yxaq4bQ8;server=124.251.44.251;)(database=channelsales;user id=channelsales_r;pwd=yxaq4bQ8;server=124.251.44.253;)&quot; /&gt;
    &lt;add key=&quot;ConnectionString_channelsales_Writer&quot; value=&quot;database=channelsales;user id=channelsales_w;pwd=hiarcR3c;server=124.251.44.248;&quot; /&gt;
    &lt;add key=&quot;ConnectionString_channelsales_stats_Read&quot; value=&quot;database=channelsales_stats;user id=channelsales_stats_admin;pwd=Qy5rpuq5;server=124.251.44.244;&quot; /&gt;
    &lt;add key=&quot;ConnectionString_glht_monitor_Read&quot; value=&quot;database=glht_monitor;user id=glht_monitor_r;pwd=st43Trxb;server=124.251.44.84;&quot; /&gt;
&lt;add key=&quot;ConnectionString_glht_monitor_Read&quot; value=&quot;database=glht_monitor;user id=glht_monitor_r;pwd=st43Trxb;server=124.251.44.84;&quot; /&gt;
    &lt;!--北方楼盘数据库连接--&gt;
    &lt;add key=&quot;ConnectionString_North_Realty_Read&quot; value=&quot;database={0};user id=realty_csales_w;pwd=7d3157c9F9;server=123.103.35.219;&quot; /&gt;
    &lt;add key=&quot;ConnectionString_North_Realty_Write&quot; value=&quot;database={0};user id=realty_csales_w;pwd=7d3157c9F9;server=123.103.35.219;&quot; /&gt;
    &lt;!--南方楼盘数据库连接--&gt;
    &lt;add key=&quot;ConnectionString_South_Realty_Read&quot; value=&quot;database={0};user id=realty_csales_w;pwd=7d3157c9F9;server=220.181.149.62;&quot; /&gt;
    &lt;add key=&quot;ConnectionString_South_Realty_Write&quot; value=&quot;database={0};user id=realty_csales_w;pwd=7d3157c9F9;server=220.181.149.62;;&quot; /&gt;
    &lt;!--楼盘UV、pv、排行数据库--&gt;
    &lt;add key=&quot;ConnectionString_newhousedata_Read&quot; value=&quot;Data Source=124.251.46.47;Port=3327;database=newhousedata;uid=nh_data_r;pwd=IjKr78Re;allow zero datetime=true;&quot; /&gt;
    &lt;!--Redis读写配置--&gt;
    &lt;add key=&quot;Redis_Read&quot; value=&quot;10.2.137.133,6379,soufun&quot; /&gt;
    &lt;add key=&quot;Redis_Write&quot; value=&quot;10.2.137.133,6379,soufun&quot; /&gt;
    &lt;!--新房帮路径地址测试站--&gt;
    &lt;add key=&quot;XFBUrl&quot; value=&quot;http://xinfangbangadmin.fang.com/managerbang/interface_phone.php&quot;/&gt;     
    &lt;!--客服--&gt;
    &lt;add key=&quot;kefuManager&quot; value=&quot;7&quot; /&gt;
    &lt;!--客服主管--&gt;
    &lt;add key=&quot;subManager&quot; value=&quot;22&quot; /&gt;
    &lt;!--分公司经理--&gt;
    &lt;add key=&quot;finance&quot; value=&quot;11&quot; /&gt;
  &lt;/appSettings&gt;
  &lt;system.web&gt;
    &lt;compilation debug=&quot;true&quot; targetFramework=&quot;4.0&quot; /&gt;
    &lt;authentication mode=&quot;Forms&quot;&gt;
      &lt;forms loginUrl=&quot;~/Account/Login&quot; timeout=&quot;2880&quot; /&gt;
    &lt;/authentication&gt;
    &lt;pages&gt;
      &lt;namespaces&gt;
        &lt;add namespace=&quot;System.Web.Helpers&quot; /&gt;
        &lt;add namespace=&quot;System.Web.Mvc&quot; /&gt;
        &lt;add namespace=&quot;System.Web.Mvc.Ajax&quot; /&gt;
        &lt;add namespace=&quot;System.Web.Mvc.Html&quot; /&gt;
        &lt;add namespace=&quot;System.Web.Optimization&quot; /&gt;
        &lt;add namespace=&quot;System.Web.Routing&quot; /&gt;
        &lt;add namespace=&quot;System.Web.WebPages&quot; /&gt;
      &lt;/namespaces&gt;
    &lt;/pages&gt;
    &lt;profile defaultProvider=&quot;DefaultProfileProvider&quot;&gt;
      &lt;providers&gt;
        &lt;add name=&quot;DefaultProfileProvider&quot; type=&quot;System.Web.Providers.DefaultProfileProvider, System.Web.Providers, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35&quot; connectionStringName=&quot;DefaultConnection&quot; applicationName=&quot;/&quot; /&gt;
      &lt;/providers&gt;
    &lt;/profile&gt;
    &lt;membership defaultProvider=&quot;DefaultMembershipProvider&quot;&gt;
      &lt;providers&gt;
        &lt;add name=&quot;DefaultMembershipProvider&quot; type=&quot;System.Web.Providers.DefaultMembershipProvider, System.Web.Providers, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35&quot; connectionStringName=&quot;DefaultConnection&quot; enablePasswordRetrieval=&quot;false&quot; enablePasswordReset=&quot;true&quot; requiresQuestionAndAnswer=&quot;false&quot; requiresUniqueEmail=&quot;false&quot; maxInvalidPasswordAttempts=&quot;5&quot; minRequiredPasswordLength=&quot;6&quot; minRequiredNonalphanumericCharacters=&quot;0&quot; passwordAttemptWindow=&quot;10&quot; applicationName=&quot;/&quot; /&gt;
      &lt;/providers&gt;
    &lt;/membership&gt;
    &lt;roleManager defaultProvider=&quot;DefaultRoleProvider&quot;&gt;
      &lt;providers&gt;
        &lt;add name=&quot;DefaultRoleProvider&quot; type=&quot;System.Web.Providers.DefaultRoleProvider, System.Web.Providers, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35&quot; connectionStringName=&quot;DefaultConnection&quot; applicationName=&quot;/&quot; /&gt;
      &lt;/providers&gt;
    &lt;/roleManager&gt;
    &lt;!--
            If you are deploying to a cloud environment that has multiple web server instances,
            you should change session state mode from &quot;InProc&quot; to &quot;Custom&quot;. In addition,
            change the connection string named &quot;DefaultConnection&quot; to connect to an instance
            of SQL Server (including SQL Azure and SQL  Compact) instead of to SQL Server Express.
      --&gt;
    &lt;sessionState mode=&quot;InProc&quot; customProvider=&quot;DefaultSessionProvider&quot;&gt;
      &lt;providers&gt;
        &lt;add name=&quot;DefaultSessionProvider&quot; type=&quot;System.Web.Providers.DefaultSessionStateProvider, System.Web.Providers, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35&quot; connectionStringName=&quot;DefaultConnection&quot; /&gt;
      &lt;/providers&gt;
    &lt;/sessionState&gt;
  &lt;/system.web&gt;
  &lt;system.webServer&gt;
    &lt;validation validateIntegratedModeConfiguration=&quot;false&quot; /&gt;
    &lt;modules runAllManagedModulesForAllRequests=&quot;true&quot; /&gt;
    &lt;handlers&gt;
      &lt;remove name=&quot;ExtensionlessUrlHandler-ISAPI-4.0_32bit&quot; /&gt;
      &lt;remove name=&quot;ExtensionlessUrlHandler-ISAPI-4.0_64bit&quot; /&gt;
      &lt;remove name=&quot;ExtensionlessUrlHandler-Integrated-4.0&quot; /&gt;
      &lt;add name=&quot;ExtensionlessUrlHandler-ISAPI-4.0_32bit&quot; path=&quot;*.&quot; verb=&quot;GET,HEAD,POST,DEBUG,PUT,DELETE,PATCH,OPTIONS&quot; modules=&quot;IsapiModule&quot; scriptProcessor=&quot;%windir%\Microsoft.NET\Framework\v4.0.30319\aspnet_isapi.dll&quot; preCondition=&quot;classicMode,runtimeVersionv4.0,bitness32&quot; responseBufferLimit=&quot;0&quot; /&gt;
      &lt;add name=&quot;ExtensionlessUrlHandler-ISAPI-4.0_64bit&quot; path=&quot;*.&quot; verb=&quot;GET,HEAD,POST,DEBUG,PUT,DELETE,PATCH,OPTIONS&quot; modules=&quot;IsapiModule&quot; scriptProcessor=&quot;%windir%\Microsoft.NET\Framework64\v4.0.30319\aspnet_isapi.dll&quot; preCondition=&quot;classicMode,runtimeVersionv4.0,bitness64&quot; responseBufferLimit=&quot;0&quot; /&gt;
      &lt;add name=&quot;ExtensionlessUrlHandler-Integrated-4.0&quot; path=&quot;*.&quot; verb=&quot;GET,HEAD,POST,DEBUG,PUT,DELETE,PATCH,OPTIONS&quot; type=&quot;System.Web.Handlers.TransferRequestHandler&quot; preCondition=&quot;integratedMode,runtimeVersionv4.0&quot; /&gt;
    &lt;/handlers&gt;
  &lt;/system.webServer&gt;
  &lt;runtime&gt;
    &lt;assemblyBinding xmlns=&quot;urn:schemas-microsoft-com:asm.v1&quot;&gt;
      &lt;dependentAssembly&gt;
        &lt;assemblyIdentity name=&quot;System.Web.Helpers&quot; publicKeyToken=&quot;31bf3856ad364e35&quot; /&gt;
        &lt;bindingRedirect oldVersion=&quot;1.0.0.0-2.0.0.0&quot; newVersion=&quot;2.0.0.0&quot; /&gt;
      &lt;/dependentAssembly&gt;
      &lt;dependentAssembly&gt;
        &lt;assemblyIdentity name=&quot;System.Web.Mvc&quot; publicKeyToken=&quot;31bf3856ad364e35&quot; /&gt;
        &lt;bindingRedirect oldVersion=&quot;1.0.0.0-4.0.0.0&quot; newVersion=&quot;4.0.0.0&quot; /&gt;
      &lt;/dependentAssembly&gt;
      &lt;dependentAssembly&gt;
        &lt;assemblyIdentity name=&quot;System.Web.WebPages&quot; publicKeyToken=&quot;31bf3856ad364e35&quot; /&gt;
        &lt;bindingRedirect oldVersion=&quot;1.0.0.0-2.0.0.0&quot; newVersion=&quot;2.0.0.0&quot; /&gt;
      &lt;/dependentAssembly&gt;
      &lt;dependentAssembly&gt;
        &lt;assemblyIdentity name=&quot;WebGrease&quot; publicKeyToken=&quot;31bf3856ad364e35&quot; /&gt;
        &lt;bindingRedirect oldVersion=&quot;1.0.0.0-1.3.0.0&quot; newVersion=&quot;1.3.0.0&quot; /&gt;
      &lt;/dependentAssembly&gt;
    &lt;/assemblyBinding&gt;
  &lt;/runtime&gt;
  &lt;entityFramework&gt;
    &lt;defaultConnectionFactory type=&quot;System.Data.Entity.Infrastructure.SqlConnectionFactory, EntityFramework&quot; /&gt;
  &lt;/entityFramework&gt;
&lt;/configuration&gt;</asp:TextBox>
        <asp:TextBox ID="txtTemplate" runat="server" Height="111px" TextMode="MultiLine" Width="96%">/// &lt;summary&gt;
        /// {0}
        /// &lt;/summary&gt;
        [XmlElement(ElementName = &quot;{0}&quot;)]
        [JsonProperty(&quot;{0}&quot;)]
        public {1} {0} { get; set; }</asp:TextBox>
        <asp:Button ID="btnSubmit" runat="server" Text="将xml中的连接串转换成json格式" OnClick="btnSubmit_Click" />
    &nbsp;&nbsp;
        <asp:Button ID="btnSubmit0" runat="server" Text="提取配置中的接口地址" OnClick="btnSubmit0_Click" />
    &nbsp;&nbsp;<asp:TextBox ID="txtWebSite" runat="server" Width="192px">channelsales.tao.fang.com</asp:TextBox>
&nbsp;<asp:Button ID="btnSubmit1" runat="server" Text="将json格式的数据转换成表格" OnClick="btnSubmit1_Click" />
    &nbsp;        
        <asp:Button ID="btnSubmit2" runat="server" Text="将表格数据转换成json格式" OnClick="btnSubmit2_Click" />
        <asp:Button ID="btnSubmit3" runat="server" Text="将配置转换成Apollo文本格式" OnClick="btnSubmit3_Click" /><asp:Button ID="btnSubmit4" runat="server" Text="套用模板生成代码" OnClick="btnSubmit4_Click" Width="218px" />
    &nbsp;<asp:TextBox ID="txtJson" runat="server" Height="500px" TextMode="MultiLine" Width="100%"></asp:TextBox>
        
    &nbsp;&nbsp;
    </div> 
        <br />
        <br />
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
        <br />
        <br />
    </form>
</body>
</html>
