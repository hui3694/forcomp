<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="settings_edit.aspx.cs" Inherits="DTcms.Web.Plugin.Forum.admin.settings_edit" ValidateRequest="false" %>
<%@ Import namespace="DTcms.Common" %>
<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>编辑dt_Forum_Settings</title>
<link type="text/css" rel="stylesheet" href="../../../scripts/artdialog/ui-dialog.css" />
<link type="text/css" rel="stylesheet" href="../../../<%=siteConfig.webmanagepath %>/skin/default/style.css" />
<script type="text/javascript" charset="utf-8" src="../../../scripts/jquery/jquery-1.11.2.min.js"></script>
<script type="text/javascript" charset="utf-8" src="../../../scripts/jquery/Validform_v5.3.2_min.js"></script>
<script type="text/javascript" charset="utf-8" src="../../../scripts/datepicker/WdatePicker.js"></script>
<script type="text/javascript" charset="utf-8" src="../../../scripts/artdialog/dialog-plus-min.js"></script>
<script type="text/javascript" charset="utf-8" src="../../../scripts/webuploader/webuploader.min.js"></script>
<script type="text/javascript" charset="utf-8" src="../../../<%=siteConfig.webmanagepath %>/js/uploader.js"></script>
<script type="text/javascript" charset="utf-8" src="../../../<%=siteConfig.webmanagepath %>/js/laymain.js"></script>
<script type="text/javascript" charset="utf-8" src="../../../scripts/ueditor/ueditor.config.js"></script>
<script type="text/javascript" charset="utf-8" src="../../../scripts/ueditor/ueditor.all.min.js"></script>
<script type="text/javascript" charset="utf-8" src="../../../scripts/ueditor/lang/zh-cn/zh-cn.js"></script>
<script type="text/javascript" charset="utf-8" src="../../../<%=siteConfig.webmanagepath %>/js/common.js"></script>
<script type="text/javascript">
    $(function () {
        //初始化表单验证
        $("#form1").initValidform();
        //初始化上传控件
        $(".upload-img").InitUploader({ sendurl: "../../../tools/upload_ajax.ashx", swf: "../../../scripts/webuploader/uploader.swf", filetypes: "jpg,jpge,png,gif,<%=siteConfig.videoextension %>" });
        //初始化百度编辑器
        var ue = UE.getEditor('txtContent');
    });
</script>
</head>
<body class="mainbody">
<form id="form1" runat="server">
<!--导航栏-->
<div class="location">
  <a href="Forum_Settings_list.aspx" class="back"><i></i><span>返回列表页</span></a>
  <a href="../../../<%=siteConfig.webmanagepath %>/center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <span>插件管理</span>
  <i class="arrow"></i>
  <span>全局管理</span>
  <i class="arrow"></i>
  <span>常量设置</span>
</div>
<div class="line10"></div>

<!--/导航栏-->

<!--内容-->
<div id="floatHead" class="content-tab-wrap">
  <div class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
      <li><a class="selected" href="javascript:;"> 常量信息</a></li>
      </ul>
    </div>
  </div>
</div>
<div class="tab-content">
    <dl>
        <dt style="color:red;">>>:</dt>
        <dd style="color:red;">此处添加修改与程序对应，如不了解请勿操作</dd>
    </dl>



   <dl>
    <dt>归属</dt>
    <dd>
         <div class="rule-single-select">
        <asp:DropDownList ID="ddlGroup" runat="server" AutoPostBack="False" >
            <asp:ListItem Text="隐藏组" Value="-1" />
            <asp:ListItem Text="系统组" Value="1" />
        </asp:DropDownList>
        </div>
    </dd>
  </dl>

	<dl>
    <dt>标题</dt>
    <dd>
      <asp:TextBox ID="txtTitle" runat="server" CssClass="input normal" datatype="" sucmsg=" " 
      ajaxurl=""></asp:TextBox> <span class="Validform_checktip">*必填项</span>
    </dd>
  </dl>

	<dl>
    <dt>说明</dt>
    <dd>
      <asp:TextBox ID="txtDescription" runat="server" CssClass="input normal" TextMode="MultiLine" Height="100"  datatype="" sucmsg=" " 
      ajaxurl=""></asp:TextBox>
    </dd>
  </dl>

    	<dl>
    <dt>常量名</dt>
    <dd>
      <asp:TextBox ID="txtVariable" runat="server" CssClass="input normal" datatype="" sucmsg=" " 
      ajaxurl=""></asp:TextBox> <span class="Validform_checktip">*此项与程序内部变量对应，非开发人员勿改动</span>
    </dd>
  </dl>
	<dl>
    <dt>默认值</dt>
    <dd>
      <asp:TextBox ID="txtValue" runat="server" CssClass="input normal" datatype="" sucmsg=" " 
      ajaxurl=""></asp:TextBox> <span class="Validform_checktip">*必填项</span>
    </dd>
  </dl>

	<dl>
    <dt>排序</dt>
    <dd>
      <asp:TextBox ID="txtSortId" runat="server" CssClass="input small" datatype="n" sucmsg=" ">99</asp:TextBox> <span class="Validform_checktip">*必填项</span>
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