<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="user_email.aspx.cs" Inherits="DTcms.Web.admin.users.user_email" ValidateRequest="false" %>
<%@ Import namespace="DTcms.Common" %>

<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>邮件通知</title>
<link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
<script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
<script type="text/javascript" src="../../scripts/artdialog/dialog-plus-min.js"></script>
<script type="text/javascript" charset="utf-8" src="../../scripts/ueditor/ueditor.config.js"></script>
<script type="text/javascript" charset="utf-8" src="../../scripts/ueditor/ueditor.all.min.js"></script>
<script type="text/javascript" charset="utf-8" src="../../scripts/ueditor/lang/zh-cn/zh-cn.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
<script type="text/javascript">
    $(function () {
        //初始化表单验证
        $("#form1").initValidform();
        //编辑器
        UE.getEditor('txtContent');
    });
</script>
<body class="mainbody">
<form id="form1" runat="server">
<!--导航栏-->
<div class="location">
  <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <a href="user_list.aspx"><span>会员管理</span></a>
  <i class="arrow"></i>
  <span>邮件通知</span>
</div>
<div class="line10"></div>
<!--/导航栏-->

<!--内容-->
<div id="floatHead" class="content-tab-wrap">
  <div class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
        <li><a class="selected" href="javascript:;">批量短信通知</a></li>
      </ul>
    </div>
  </div>
</div>

<div class="tab-content">
  <dl>
    <dt>输入类型</dt>
    <dd>
      <div class="rule-multi-radio">
        <asp:RadioButtonList ID="rblSmsType" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" AutoPostBack="True" onselectedindexchanged="rblSmsType_SelectedIndexChanged">
          <asp:ListItem Value="1">手动输入</asp:ListItem>
          <asp:ListItem Value="2">批量通知</asp:ListItem>
        </asp:RadioButtonList>
      </div>
    </dd>
  </dl>
  <dl id="div_group" runat="server" visible="false">
    <dt>会员组别</dt>
    <dd>
      <div class="rule-multi-porp">
        <asp:CheckBoxList ID="cblGroupId" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"></asp:CheckBoxList>
      </div>
    </dd>
  </dl>
  <dl id="div_email" runat="server" visible="false">
    <dt>邮箱地址</dt>
    <dd>
      <asp:TextBox ID="txtEmailList" runat="server" CssClass="input" style="padding:0;width:98%;height:150px;" datatype="/^(([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5}){1,25})+([,.](([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5}){1,25})+)*$/" tip="以英文“,”逗号分隔开" nullmsg="请填写邮箱地址，多个邮箱以“,”号分隔开！" errormsg="请填写正确的邮箱地址，多个邮箱地址号以“,”号分隔开！" TextMode="MultiLine"></asp:TextBox>
      <div class="clear"></div>
      <span class="Validform_checktip">*多个邮箱号码以英文“,”逗号分隔开</span>
    </dd>
  </dl>
  <dl>
    <dt>邮件标题</dt>
    <dd>
      <asp:TextBox ID="txtTitle" runat="server" CssClass="input normal" datatype="*" nullmsg="请填写邮件标题！"></asp:TextBox>
      <span class="Validform_checktip">*</span>
    </dd>
  </dl>
  <dl>
    <dt>邮件内容</dt>
    <dd>
      <textarea id="txtContent" style="height:260px; width:100%;" runat="server"></textarea>
      <span class="Validform_checktip">*</span>
    </dd>
  </dl>
</div>
<!--/内容-->

<!--工具栏-->
<div class="page-footer">
  <div class="btn-wrap">
    <asp:Button ID="btnSubmit" runat="server" Text="提交发送" CssClass="btn" onclick="btnSubmit_Click" />
    <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript:history.back(-1);" />
  </div>
</div>
<!--/工具栏-->

</form>
</body>
</html>