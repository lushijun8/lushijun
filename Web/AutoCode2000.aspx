<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AutoCode2000.aspx.cs" Inherits="Web.AutoCode2000" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Main</title><meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,user-scalable=no" />
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<FONT face="宋体">
				<TABLE id="Table1" cellSpacing="0" cellPadding="5" width="100%" border="0">
					<TR>
						<TD>数据库名称：
							<asp:DropDownList id="DATABASE" runat="server" AutoPostBack="True" DESIGNTIMEDRAGDROP="29" OnSelectedIndexChanged="DATABASE_SelectedIndexChanged">
								<asp:ListItem Value=""></asp:ListItem>
								<asp:ListItem Value="CZHOMEBBS">CZHOMEBBS</asp:ListItem>
								<asp:ListItem Value="Home_Customer_test">Home_Customer_test</asp:ListItem>
								<asp:ListItem Value="HomeDepot">HomeDepot</asp:ListItem>
							</asp:DropDownList>
							<asp:TextBox id="DATABASE1" runat="server" Width="80px">DB</asp:TextBox>实体名称：
							<asp:DropDownList id="TABLE" runat="server" AutoPostBack="True" OnSelectedIndexChanged="TABLE_SelectedIndexChanged"></asp:DropDownList>
							<asp:TextBox id="TABLE1" runat="server" Width="96px"></asp:TextBox>&nbsp;实体说明：
							<asp:TextBox id="TABLECOMMENT" runat="server" Width="296px"></asp:TextBox>
                            <asp:Button CssClass="button" ID="btnCreateImportSql" runat="server" OnClick="btnCreateImportSql_Click"
                                Text="生成导数语句" />
							<asp:Button CssClass="button" id="CREATE" runat="server" Text="生成ENTITY" OnClick="CREATE_Click"></asp:Button>&nbsp;
							<asp:Button CssClass="button" id="CREATESP" runat="server" Text="生成SP(INSERT,UPDATE,SELECT,DELETE)" OnClick="CREATESP_Click"></asp:Button></TD>
					</TR>
					<TR>
						<TD>命名空间：
							<asp:TextBox id="NAMESPACE" runat="server" Width="48px">Play</asp:TextBox>批量生成目录：<INPUT type="file" onchange="javascript:document.all['Path'].value=this.value">
							<asp:TextBox id="Path" runat="server" Width="248px"></asp:TextBox>
							<asp:Button CssClass="button" id="CREATES" runat="server" Text="批量生成ENTITY" OnClick="CREATES_Click"></asp:Button>
							<asp:Button CssClass="button" id="CREATESSP" runat="server" Text="批量生成SP(INSERT,UPDATE,SELECT,DELETE)" OnClick="CREATESSP_Click"></asp:Button></TD>
					</TR>
					<TR>
						<TD>
							<P>字段（请用","隔开）：
								<asp:TextBox id="COLUMNS" runat="server" Width="392px"></asp:TextBox></P>
						</TD>
					</TR>
					<TR>
						<TD>主键（请用","隔开）：
							<asp:TextBox id="PRIMARYKEYS" runat="server" Width="288px"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 28px">字段类型（请用","隔开）：
							<asp:TextBox id="XTYPE" runat="server" Width="392px"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 28px">字段长度（请用","隔开）：
							<asp:TextBox id="LENGTH" runat="server" Width="392px"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 28px">是否允许空NULL（请用","隔开,1:能为空;0:不可以空）：
							<asp:TextBox id="ISNULLABLE" runat="server" Width="344px"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 28px">默认值（请用","隔开）：
							<asp:TextBox id="DEFAULT" runat="server" Width="344px"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 28px">描述（请用","隔开,如果没有中文描述则用字段名替代）：
							<asp:TextBox id="DESCRIPTION" runat="server" Width="344px"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 28px">自增列：
							<asp:TextBox id="IDENTITY" runat="server" Width="152px"></asp:TextBox>
							<asp:Button CssClass="button" id="UpdateMetaData" runat="server" Text="批量更新元数据库" OnClick="UpdateMetaData_Click"></asp:Button></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 28px">
							<asp:DataGrid id="dgJoinTable" runat="server" AutoGenerateColumns="False">
								<Columns>
									<asp:TemplateColumn HeaderText="选择">
										<ItemTemplate>
											<asp:CheckBox id="cbSelect" runat="server"></asp:CheckBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="关联数据库">
										<ItemTemplate>
											<asp:TextBox id="JoinDataBase" runat="server"></asp:TextBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="关联数据表">
										<ItemTemplate>
											<asp:TextBox id="JoinTableName" runat="server"></asp:TextBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="关联数据列">
										<ItemTemplate>
											<asp:TextBox id="JoinColumnName" runat="server"></asp:TextBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="本表的列">
										<ItemTemplate>
											<asp:TextBox id="ColumnName" runat="server"></asp:TextBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="关联数据列1(可空)">
										<ItemTemplate>
											<asp:TextBox id="JoinColumnName1" runat="server"></asp:TextBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="本表的列1(可空)">
										<ItemTemplate>
											<asp:TextBox id="ColumnName1" runat="server"></asp:TextBox>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</asp:DataGrid>
							<asp:Button CssClass="button" id="AddJoinTable" runat="server" Text="添加" OnClick="AddJoinTable_Click"></asp:Button>&nbsp;
							<asp:Button CssClass="button" id="DeleteJoinTable" runat="server" Text="删除" OnClick="DeleteJoinTable_Click"></asp:Button></TD>
					</TR>
					<TR>
						<TD>
							<asp:TextBox id="CODES" runat="server" TextMode="MultiLine" Width="100%" Height="500px"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD></TD>
					</TR>
				</TABLE>
			</FONT>
		</form>
	</body>
</HTML>
