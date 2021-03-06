﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="class_list.aspx.cs" Inherits="DTcms.Web.Plugin.Images.admin.class_list" %>
<%@ Import namespace="DTcms.Common" %>

<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>橱窗类别管理</title>
<link href="../../../<%=siteConfig.webmanagepath %>/skin/default/style.css" rel="stylesheet" type="text/css" />
<link href="../../../css/pagination.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../../../scripts/jquery/jquery-1.11.2.min.js"></script>
<script type="text/javascript" src="../../../<%=siteConfig.webmanagepath %>/js/common.js"></script>
</head>
<body class="mainbody">
<form id="form1" runat="server">
<!--导航栏-->
<div class="location">
  <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页一页</span></a>
  <a href="../../../<%=siteConfig.webmanagepath %>/center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <span>插件管理</span>
  <i class="arrow"></i>
  <a href="images_list.aspx">广告橱窗</a>
  <i class="arrow"></i>
  <span>橱窗位管理</span>
</div>
<!--/导航栏-->

<!--工具栏-->
<div id="floatHead" class="toolbar-wrap">
  <div class="toolbar">
    <div class="box-wrap">
      <a class="menu-btn"></a>
      <div class="l-list">
        <ul class="icon-list">
          <li><a class="add" href="class_edit.aspx?action=<%=DTEnums.ActionEnum.Add %>&backurl=<%=DTRequest.GetUrlParameter() %>"><i></i><span>新增</span></a></li>
          <li><asp:LinkButton ID="btnSave" runat="server" CssClass="save" onclick="btnSave_Click"><i></i><span>保存</span></asp:LinkButton></li>
          <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
          <li><asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete','删除后无法恢复，是否继续？');" onclick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
        </ul>
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
  <asp:Repeater ID="rptList" runat="server">
  <HeaderTemplate>
  <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
    <tr>
        <th width="6%" align="center">选择</th>
        <th align="left" width="15%">标题</th>
        <th align="left">调用名称</th>
        <th width="8%" align="left">数量</th>
        <th width="12%" align="left">尺寸H/W</th>
        <th width="8%" align="left">状态</th>
        <th width="8%" align="left">集成</th>
        <th width="10%" align="left">排序</th>
        <th width="8%" align="center">操作</th>
    </tr>
  </HeaderTemplate>
  <ItemTemplate>
    <tr>
      <td align="center">
        <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" style="vertical-align:middle;" Enabled='<%#bool.Parse((Convert.ToInt32(Eval("is_sys"))==0 ).ToString())%>' />
        <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
      </td>
      <td align="left"><%#Eval("title")%></td>
      <td align="left"><%# Eval("call_index")%></td>
      <td align="left"><%# Eval("num")%></td>
      <td align="left"><%# Eval("height")%>*<%# Eval("width")%></td>
      <td align="left"><%# Convert.ToInt32(Eval("is_lock")) == 0 ? "√" : "×"%></td>
      <td align="left"><%# Convert.ToInt32(Eval("is_sys")) == 1 ? "√" : "×"%></td>
      <td align="left"><asp:TextBox ID="txtSortId" runat="server" Text='<%#Eval("sort_id")%>' CssClass="sort" onkeydown="return checkNumber(event);" /></td>
      <td align="center" class="control"><a href="class_edit.aspx?action=<%#DTEnums.ActionEnum.Edit %>&id=<%#Eval("id")%>&backurl=<%=DTRequest.GetUrlParameter() %>">修改</a></td>
    </tr>
  </ItemTemplate>
  <FooterTemplate>
    <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"9\">暂无记录</td></tr>" : ""%>
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