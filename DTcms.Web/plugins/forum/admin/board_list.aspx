<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="board_list.aspx.cs" Inherits="DTcms.Web.Plugin.Forum.admin.board_list" ValidateRequest="false" %>

<%@ Import Namespace="DTcms.Common" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>dt_Forum_Board列表</title>
    <link href="../../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="../../../<%=siteConfig.webmanagepath %>/skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../../../css/pagination.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" charset="utf-8" src="../../../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../../scripts/artdialog/dialog-plus-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../../<%=siteConfig.webmanagepath %>/js/laymain.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../../<%=siteConfig.webmanagepath %>/js/common.js"></script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <a href="../../../<%=siteConfig.webmanagepath %>/center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>插件管理</span>
            <i class="arrow"></i>
            <span>论坛管理</span>
            <i class="arrow"></i>
            <span>版块管理</span>
        </div>

        <!--/导航栏-->
        <!--工具栏-->
        <div id="floatHead" class="toolbar-wrap">
            <div class="toolbar">
                <div class="box-wrap">
                    <a class="menu-btn"></a>
                    <div class="l-list">
                        <ul class="icon-list">
                            <li><a class="add" href="board_edit.aspx?action=<%=DTEnums.ActionEnum.Add %>"><i></i><span>新增</span></a></li>
                            <li><asp:LinkButton ID="btnSave" runat="server" CssClass="save" onclick="btnSave_Click"><i></i><span>保存</span></asp:LinkButton></li>       
                            <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                            <li>
                                <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete');" OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
                        </ul>
                    </div>
                    <div class="r-list">
                        
                    </div>
                </div>
            </div>
        </div>
        <!--/工具栏-->

        <!--列表-->
        <div class="table-container">
            <asp:Repeater ID="rptList" runat="server" onitemdatabound="rptList_ItemDataBound">
                <HeaderTemplate>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                        <tr>
                            <th width="8%">选择</th>

                            <th align="left" width="6%">编号</th>
                            <th align="left">版块名称</th>                         
                            <th align="left" width="10%">排序</th>
                            <th align="left" width="10%">状态</th>
                            <th width="25%">操作</th>


                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td align="center">
                            <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                            <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
                            <asp:HiddenField ID="hidLayer" Value='<%#Eval("classLayer") %>' runat="server" />
                        </td>
                        <td><%# Eval("Id") %></td>
                        <td>
                            <asp:Literal ID="LitFirst" runat="server"></asp:Literal>
                            <a href="board_edit.aspx?action=<%#DTEnums.ActionEnum.Edit %>&id=<%#Eval("id")%>"><%#Eval("Name")%></a>
                        </td>

                        <td>
                            <asp:TextBox ID="txtSortId" runat="server" Text='<%#Eval("sortId")%>' CssClass="sort" onkeydown="return checkNumber(event);" /></td>
                        <td><%# Convert.ToInt32(Eval("Show")) == 0 ? "关闭" : "正常"%></td>
                        <td align="right">
                            <%# Convert.ToInt32(Eval("classLayer")) == 1 ? "<a href=\"board_edit.aspx?action=" + DTEnums.ActionEnum.Add + "&id=" + Eval("id") + "\">添子版块</a>" : ""%>
                            <a style="margin-left:10px" href="board_edit.aspx?action=<%#DTEnums.ActionEnum.Edit %>&class_layer=<%#Eval("classLayer")%>&id=<%#Eval("id")%>">修改</a>
                            <a style="margin-left:10px" href="board_action_point_list.aspx?board_id=<%#Eval("id")%>">积分</a>
                                                                                    
                            <a style="margin-left:10px; <%# Convert.ToInt32(Eval("ChildCount")) == 0 ? "" : "display:none;" %>" href="board_permission.aspx?board_id=<%#Eval("id")%>&board_name=<%#Eval("Name")%>">权限</a>                          

                             <a style="margin:0 10px" href="moderator_list.aspx?board_id=<%#Eval("id")%>">版主</a>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"6\">暂无记录</td></tr>" : ""%>
  </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <!--/列表-->

        <!--内容底部-->
        <div class="line20"></div>

        <!--/内容底部-->
    </form>
</body>
</html>
