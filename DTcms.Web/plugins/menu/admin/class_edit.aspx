<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="class_edit.aspx.cs" Inherits="DTcms.Web.Plugin.Menu.admin.class_edit" %>
<%@ Import namespace="DTcms.Common" %>

<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>编辑类别</title>
<link href="../../../scripts/colpick/colpick.css" rel="stylesheet" type="text/css" />
<link href="../../../<%=siteConfig.webmanagepath %>/skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../../../scripts/jquery/jquery-1.11.2.min.js"></script>
<script type="text/javascript" src="../../../scripts/jquery/Validform_v5.3.2_min.js"></script>
<script type="text/javascript" src="../../../<%=siteConfig.webmanagepath %>/js/common.js"></script>
<script type="text/javascript" src="../../../scripts/colpick/colpick.js"></script>
<script type="text/javascript">
    $(function () {
        //初始化表单验证
        $("#form1").initValidform();
        //颜色插件
        $("#txtColor").colpick({
            layout: 'hex',
            submit: 0,
            colorScheme: 'dark',
            onChange: function (hsb, hex, rgb, el, bySetColor) {
                if (!bySetColor) $(el).val('#' + hex);
            }
        });
    });
</script>
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
  <a href="menu_list.aspx">导航菜单</a>
  <i class="arrow"></i>
  <a href="class_list.aspx">菜单类别</a>
  <i class="arrow"></i>
  <span>编辑类别</span>
</div>
<!--/导航栏-->

<!--内容-->
<div id="floatHead" class="content-tab-wrap">
  <div class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
        <li><a class="selected" href="javascript:;">菜单类别编辑</a></li>
      </ul>
    </div>
  </div>
</div>

<div class="tab-content">
  <dl>
    <dt>类别名称</dt>
    <dd><asp:TextBox ID="txtTitle" runat="server" CssClass="input normal" datatype="*2-20" sucmsg=" " /><span class="Validform_checktip">*</span></dd>
  </dl>
  <dl>
    <dt>区分颜色</dt>
    <dd><asp:TextBox ID="txtColor" runat="server" CssClass="input mark" /></dd>
  </dl>
  <dl>
    <dt>状态</dt>
    <dd>
        <div class="rule-multi-radio">
           <asp:RadioButtonList ID="rblHide" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
            <asp:ListItem Value="0" Selected="True">正常</asp:ListItem>
            <asp:ListItem Value="1">锁定</asp:ListItem>
            </asp:RadioButtonList>
        </div>
    </dd>
  </dl>
  <dl>
    <dt>排序</dt>
    <dd><asp:TextBox ID="txtSort" runat="server" CssClass="input small" datatype="n" sucmsg=" " Text="99" /><span class="Validform_checktip">*</span></dd>
  </dl>
</div>

<!--工具栏-->
<div class="page-footer">
  <div class="btn-wrap">
    <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" onclick="btnSubmit_Click" />
    <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript:history.back(-1);" />
  </div>
</div>
<!--/工具栏-->
</form>
</body>
</html>