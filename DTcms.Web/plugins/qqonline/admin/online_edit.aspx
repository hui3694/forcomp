<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="online_edit.aspx.cs" Inherits="DTcms.Web.Plugin.QQOnline.admin.online_edit" ValidateRequest="false" %>
<%@ Import namespace="DTcms.Common" %>
<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>编辑客服</title>
<link href="../../../scripts/colpick/colpick.css" rel="stylesheet" type="text/css" />
<link href="../../../<%=siteConfig.webmanagepath %>/skin/default/style.css" rel="stylesheet" type="text/css" />
<link href="../skin/css/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../../../scripts/jquery/jquery-1.11.2.min.js"></script>
<script type="text/javascript" src="../../../scripts/jquery/Validform_v5.3.2_min.js"></script>
<script type="text/javascript" src="../../../<%=siteConfig.webmanagepath %>/js/common.js"></script>
<script type="text/javascript" src="../../../scripts/colpick/colpick.js"></script>
<script type="text/javascript">
    $(function () {
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
        //遍历显示图像
        $("#rblPicList label").each(function (index) {
            $(this).html('<img src="../skin/qqface/' + $(this).html() + '"/>')
        });
    });
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
  <a href="qq_list.aspx">QQ在线客服</a>
  <i class="arrow"></i>
  <span>编辑客服</span>
</div>
<div class="line10"></div>
<!--/导航栏-->

<!--内容-->
<div id="floatHead" class="content-tab-wrap">
    <div class="content-tab">
        <div class="content-tab-ul-wrap">
            <ul>
            	<li><a class="selected" href="javascript:;">编辑客服信息</a></li>
            </ul>
        </div>
    </div>
</div>
<div class="tab-content">
    <dl>
        <dt>显示昵称</dt>
        <dd><asp:TextBox ID="txtUserName" runat="server" CssClass="input normal" datatype="*2-20" sucmsg=" " /><span class="Validform_checktip">*</span></dd>
    </dl>
    <dl>
        <dt>QQ号码</dt>
        <dd><asp:TextBox ID="txtQQ" runat="server" CssClass="input normal" datatype="n5-12" sucmsg=" " /><span class="Validform_checktip">*</span></dd>
    </dl>
    <dl>
        <dt>字体颜色</dt>
        <dd><asp:TextBox ID="txtColor" runat="server" CssClass="input mark" /><span class="Validform_checktip">可为空，不填为系统默认颜色。</span></dd>
    </dl>
    <dl>
        <dt>是否启用</dt>
        <dd>
            <div class="rule-single-checkbox">
            <asp:CheckBox ID="cbStatus" runat="server" Checked="True" />
            </div>
            <span class="Validform_checktip">*前端只有在开启时，才会显示。</span>
        </dd>
    </dl>
    <dl>
        <dt>排序</dt>
        <dd><asp:TextBox ID="txtSort" runat="server" CssClass="input small" datatype="n" sucmsg=" " Text="99" /><span class="Validform_checktip">*</span></dd>
    </dl>
    <dl>
        <dt>链接</dt>
        <dd>
            <asp:TextBox ID="txtUrl" runat="server" CssClass="input normal" />
            <span class="Validform_checktip">默认为空，不填为系统默认提供地址</span>
        </dd>
    </dl>
    <dl>
        <dt>头像</dt>
        <dd class="qqonline">
            <div class="opt"><asp:RadioButtonList ID="rblPicList" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal"></asp:RadioButtonList></div>
        </dd>
    </dl>
</div>
<!--/内容-->

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