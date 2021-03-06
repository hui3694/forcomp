﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pro_list.aspx.cs" Inherits="DTcms.Web.admin.pro.pro_list" %>
<%@ Import namespace="DTcms.Common" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title></title>
    <link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../../css/pagination.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/artdialog/dialog-plus-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
          <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
          <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
          <i class="arrow"></i>
          <span>产品列表</span>
        </div>
        <!--/导航栏-->

        <!--工具栏-->
        <div id="floatHead" class="toolbar-wrap">
          <div class="toolbar">
            <div class="box-wrap">
              <a class="menu-btn"></a>
              <div class="l-list">
                <ul class="icon-list">
                  <li runat="server" id="editBtnPannel"><asp:LinkButton ID="btnSave" runat="server" CssClass="save" onclick="btnSave_Click"><i></i><span>保存</span></asp:LinkButton></li>
                  <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                  <li runat="server" id="delBtnPannel"><asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete','是否确定删除产品？');" onclick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
                </ul>
              </div>
                <div class="r-list">
                <asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" />
                <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" onclick="btnSearch_Click">查询</asp:LinkButton>
              </div>
            </div>
          </div>
        </div>
        <!--/工具栏-->

        <!--列表-->
        <div class="table-container">
          <asp:Repeater ID="rptList" runat="server">
          <HeaderTemplate>
          <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
            <tr>
              <th width="6%">选择</th>
              <th align="left" width="6%">编号</th>
              <th align="left" width="8%">用户</th>
              <th align="left" width="16">标题</th>
              <th align="left" width="8%">城市</th>
              <th align="left" width="8%">排序</th>
              <th align="left" width="8%">状态</th>
              <th align="left" width="15%">审核时间</th>
              <th align="left" width="15%">提交时间</th>
              <th width="8%">操作</th>
            </tr>
          </HeaderTemplate>
          <ItemTemplate>
            <tr>
              <td align="center">
                <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" style="vertical-align:middle;" />
                <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
              </td>
              <td><%#Eval("id")%></td>
              <td><a href="#id=<%#Eval("user_id") %>"><%#Eval("username") %></a></td>
              <td><%#Eval("title") %></td>
              <td><%#Eval("city") %></td>
              <td><asp:TextBox ID="txtSortId" runat="server" Text='<%#Eval("sort")%>' CssClass="sort" onkeydown="return checkNumber(event);" /></td>
              <td><%#GetStatus(Convert.ToInt32( Eval("status")))%></td>
              <td><%#Convert.ToDateTime(Eval("pass_time")).ToString("yyyy-MM-dd HH:mm:ss") %></td>
              <td><%#Convert.ToDateTime(Eval("add_time")).ToString("yyyy-MM-dd HH:mm:ss") %></td>
              <td align="center">
                <a href="pro_edit.aspx?action=<%#DTEnums.ActionEnum.Edit %>&id=<%#Eval("id")%>">修改</a>
              </td>
            </tr>
          </ItemTemplate>
          <FooterTemplate>
            <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"8\">暂无记录</td></tr>" : ""%>
          </table>
          </FooterTemplate>
          </asp:Repeater>
        </div>
        <!--/列表-->

        <!--内容底部-->
        <div class="line20"></div>
        <div class="pagelist">
          <div class="l-btns">
            <span>显示</span><asp:TextBox ID="txtPageNum" runat="server" CssClass="pagenum" onkeydown="return checkNumber(event);"
                        OnTextChanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox><span>条/页</span>
          </div>
          <div id="PageContent" runat="server" class="default"></div>
        </div>
        <!--/内容底部-->
    </form>
</body>
</html>
