﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="menu_list.aspx.cs" Inherits="DTcms.Web.Plugin.Menu.admin.menu_list" %>
<%@ Import namespace="DTcms.Common" %>

<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>菜单广告管理</title>
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
  <span>导航菜单</span>
</div>
<!--/导航栏-->

<!--工具栏-->
<div id="floatHead" class="toolbar-wrap">
  <div class="toolbar">
    <div class="box-wrap">
      <a class="menu-btn"></a>
      <div class="l-list">
        <ul class="icon-list">
          <li><a class="add" href="menu_edit.aspx?action=<%=DTEnums.ActionEnum.Add %>&class_id=<%=class_id %>&backurl=<%=DTRequest.GetUrlParameter() %>"><i></i><span>新增</span></a></li>
          <li><asp:LinkButton ID="btnSave" runat="server" CssClass="save" onclick="btnSave_Click"><i></i><span>保存</span></asp:LinkButton></li>
          <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
          <li><asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete','删除后无法恢复，是否继续？');" onclick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
        </ul>
        <div class="menu-list">
          <div class="rule-single-select">
              <asp:DropDownList ID="ddlClass" runat="server" AutoPostBack="True" onselectedindexchanged="ddlClass_SelectedIndexChanged" CssClass="mt2 ml10 cssselect"></asp:DropDownList>
          </div>
        </div>
      </div>
      <div class="r-list">
        <asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" AutoPostBack="True" ontextchanged="btnSearch_Click" />
        <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" onclick="btnSearch_Click">查询</asp:LinkButton>
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
      <th width="6%" align="center">选择</th>
      <th width="6%" align="left">ID</th>
      <th width="12%" align="left">菜单名称</th>
      <th align="left">链接</th>
      <th width="10%" align="left">类别</th>
      <th width="10%" align="left">样式</th>
      <th width="8%" align="left">方式</th>
      <th width="8%" align="left">排序</th>
      <th width="6%" align="left">状态</th>
      <th width="10%" align="center">操作</th>
    </tr>
  </HeaderTemplate>
  <ItemTemplate>
    <tr>
      <td align="center">
        <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" style="vertical-align:middle;" /><asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
        <asp:HiddenField ID="hidLayer" Value='<%#Eval("class_layer") %>' runat="server" />
      </td>
      <td align="left"><%#Eval("id")%></td>
      <td align="left">
        <asp:Literal ID="LitFirst" runat="server"></asp:Literal><%#Eval("title")%>
      </td>
      <td align="left"><a href="<%#Eval("link_url")%>" target="_blank"><%#Eval("link_url")%></a></td>
      <td align="left"><span style="padding:3px 5px;<%# Eval("class_color").ToString() != "" ? "background-color:" + Eval("class_color") : ""%>"><%#Eval("class_title")%></span></td>
      <td align="left"><%#Eval("css_txt")%></td>
      <td align="left"><%#Eval("target")%></td>
      <td align="left"><asp:TextBox ID="txtSortId" runat="server" Text='<%#Eval("sort_id")%>' CssClass="sort" onkeydown="return checkNumber(event);" /></td>
      <td align="left"><%# Convert.ToInt32(Eval("is_lock")) == 0 ? "√" : "×"%></td>
      <td align="center">
          <a href="menu_edit.aspx?action=<%#DTEnums.ActionEnum.Add %>&class_id=<%#class_id %>&id=<%#Eval("id")%>&backurl=<%=DTRequest.GetUrlParameter() %>">添加子类</a>
          <a href="menu_edit.aspx?action=<%#DTEnums.ActionEnum.Edit %>&class_id=<%#class_id %>&id=<%#Eval("id")%>&backurl=<%=DTRequest.GetUrlParameter() %>">修改</a>
      </td>
    </tr>
  </ItemTemplate>
  <FooterTemplate>
    <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"10\">暂无记录</td></tr>" : ""%>
  </table>
  </FooterTemplate>
  </asp:Repeater>
</div>
<!--/列表-->

</form>
</body>
</html>