﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="online_list.aspx.cs" Inherits="DTcms.Web.Plugin.QQOnline.admin.online_list" ValidateRequest="false" %>
<%@ Import namespace="DTcms.Common" %>
<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>QQ在线客服管理</title>
<link href="../../../<%=siteConfig.webmanagepath %>/skin/default/style.css" rel="stylesheet" type="text/css" />
<link href="../../../css/pagination.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../../../scripts/jquery/jquery-1.11.2.min.js"></script>
<script type="text/javascript" src="../../../<%=siteConfig.webmanagepath %>/js/common.js"></script>
<script type="text/javascript">
    //弹出提示
    function MsgTip() {
        top.dialog({
            title: "调用地址",
            width: 450,
            content: '<div class="msgtips"><h3>JS引用</h3><textarea rows="2" cols="20" class="input" style="width:100%;height:60px;"><%=siteConfig.webpath %>plugins/qqonline/skin/js/qqonline.js</textarea><h3 style="margin:5px 0;">JSON</h3><textarea rows="2" cols="20" class="input" style="width:100%;height:60px;"><%=siteConfig.webpath %>plugins/qqonline/tools/ajax.ashx</textarea></div>'
        }).show();
    }
</script>
</head>
<body class="mainbody">
<form id="form1" runat="server">
<!--导航栏-->
<div class="location">
  <a href="../../../<%=siteConfig.webmanagepath %>/center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <span>插件管理</span>
  <i class="arrow"></i>
  <span>QQ在线客服</span>
</div>
<div class="line10"></div>
<!--/导航栏-->
<!--工具栏-->
<div id="floatHead" class="toolbar-wrap">
  <div class="toolbar">
    <div class="box-wrap">
      <a class="menu-btn"></a>
      <div class="l-list">
        <ul class="icon-list">
          <li><a class="add" href="online_edit.aspx?action=<%=DTEnums.ActionEnum.Add %>&backurl=<%=DTRequest.GetUrlParameter() %>"><i></i><span>新增</span></a></li>
          <li runat="server" id="savePannel"><asp:LinkButton ID="btnSave" runat="server" CssClass="save" onclick="btnSave_Click"><i></i><span>保存</span></asp:LinkButton></li>
          <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
          <li runat="server" id="delPannel"><asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete','删除后无法恢复，是否继续？');" onclick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
          <li><a class="list" href="javascript:;" onclick="MsgTip();"><i></i><span>调用方法</span></a></li>
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
      <th align="left">显示昵称</th>
      <th width="15%" align="left">QQ号</th>
      <th width="10%" align="left">颜色</th>
      <th width="10%" align="center">头像</th>
      <th width="10%" align="center">状态</th>
      <th width="12%" align="center">排序</th>
      <th width="10%" align="center">操作</th>
    </tr>
  </HeaderTemplate>
  <ItemTemplate>
    <tr>
      <td align="center">
        <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" style="vertical-align:middle;" />
        <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
      </td>
      <td align="left"><%#Eval("username")%></td>
      <td align="left"><%#Eval("qq")%></a></td>
      <td align="left"><%#Eval("color")%></td>
      <td align="center"><img src="../skin/qqface/<%#Eval("img_url") %>" /></td>
      <td align="center"><%# Convert.ToInt32(Eval("is_lock")) == 0 ? "√" : "×"%></td>
      <td align="center"><asp:TextBox ID="txtSortId" runat="server" Text='<%#Eval("sort_id")%>' CssClass="sort" onkeydown="return checkNumber(event);" /></td>
      <td align="center">
          <a href="online_edit.aspx?action=<%#DTEnums.ActionEnum.Edit %>&id=<%#Eval("id")%>&backurl=<%=DTRequest.GetUrlParameter() %>">修改</a>
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
        <span>显示</span><asp:TextBox ID="txtPageNum" runat="server" CssClass="pagenum" onkeydown="return checkNumber(event);" OnTextChanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox><span>条/页</span>
    </div>
    <div id="PageContent" runat="server" class="default"></div>
</div>
<!--/内容底部-->
</form>
</body>
</html>