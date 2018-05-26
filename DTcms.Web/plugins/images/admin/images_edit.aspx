<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="images_edit.aspx.cs" Inherits="DTcms.Web.Plugin.Images.admin.images_edit" ValidateRequest="false" %>
<%@ Import namespace="DTcms.Common" %>

<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>编辑橱窗内容</title>
<link href="../../../scripts/colpick/colpick.css" rel="stylesheet" type="text/css" />
<link href="../../../<%=siteConfig.webmanagepath %>/skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../../../scripts/jquery/jquery-1.11.2.min.js"></script>
<script type="text/javascript" src="../../../scripts/jquery/Validform_v5.3.2_min.js"></script>
<script type="text/javascript" src="../../../scripts/ueditor/ueditor.config.js"></script>
<script type="text/javascript" src="../../../scripts/ueditor/ueditor.all.min.js"></script>
<script type="text/javascript" src="../../../scripts/ueditor/lang/zh-cn/zh-cn.js"></script>
<script type="text/javascript" src="../../../scripts/webuploader/webuploader.min.js"></script>
<script type="text/javascript" src="../../../<%=siteConfig.webmanagepath %>/js/uploader.js"></script>
<script type="text/javascript" src="../../../<%=siteConfig.webmanagepath %>/js/laymain.js"></script>
<script type="text/javascript" src="../../../<%=siteConfig.webmanagepath %>/js/common.js"></script>
<script type="text/javascript" src="../../../scripts/colpick/colpick.js"></script>

<script type="text/javascript">
    var contentType = <%=contentType%>;
    $(function () {
        //初始化表单验证
        $("#form1").initValidform();
        //标签内容类型
        $("#ddlType").change(function () {
            if ($(this).val() == "1") {
                deleteEditor();
            } else {
                createEditor();
            }
        });
        //是否加载编辑器
        if(contentType==0){
            createEditor();
        }
        //初始化上传控件
        $(".upload-img").InitUploader({ sendurl: "../../../tools/upload_ajax.ashx", swf: "../../../scripts/webuploader/uploader.swf" });
    });
    //绑定编辑器
    function createEditor() {
        UE.getEditor('txtContent');
    }
    //删除编辑器
    function deleteEditor() {
        UE.getEditor('txtContent').destroy();
    }
</script>
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
  <span>编辑橱窗内容</span>
</div>
<!--/导航栏-->
    
<!--内容-->
<div id="floatHead" class="content-tab-wrap">
  <div class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
        <li><a class="selected" href="javascript:;">图片信息</a></li>
        <li><a href="javascript:;">扩展选项</a></li>
      </ul>
    </div>
  </div>
</div>

<div class="tab-content">
  <dl>
    <dt>图片名称</dt>
    <dd><asp:TextBox ID="txtName" runat="server" CssClass="input normal" datatype="*2-20" sucmsg=" " /><span class="Validform_checktip">*</span></dd>
  </dl>
  <dl>
    <dt>链接地址</dt>
    <dd><asp:TextBox ID="txtUrl" runat="server" CssClass="input normal" /></dd>
  </dl>
  <dl>
    <dt>打开方式</dt>
    <dd>
        <div class="rule-multi-radio">
            <asp:RadioButtonList ID="rblTarget" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                <asp:ListItem Value="_blank">_blank</asp:ListItem>
                <asp:ListItem Value="_self" Selected="True">_self</asp:ListItem>
                <asp:ListItem Value="_parent">_parent</asp:ListItem>
                <asp:ListItem Value="_top">_top</asp:ListItem>
            </asp:RadioButtonList>
        </div>
    </dd>
  </dl>
  <dl>
    <dt>图片</dt>
    <dd>
      <asp:TextBox ID="txtImgUrl" runat="server" CssClass="input normal upload-path" />
      <div class="upload-box upload-img"></div>
    </dd>
    <dd id="divImg" class="imgdiv" runat="server" visible="false">
        <asp:Image runat="server" ID="imgUrl" />
    </dd>
  </dl>
  <dl>
    <dt>橱窗位</dt>
    <dd>
        <div class="rule-single-select">
            <asp:DropDownList ID="ddlClassId" runat="server"  CssClass="cssselect" datatype="*" sucmsg=" "></asp:DropDownList>
        </div>
    </dd>
  </dl>
  <dl>
    <dt>排序</dt>
    <dd><asp:TextBox ID="txtSort" runat="server" CssClass="input small" datatype="n" sucmsg=" " Text="99" /><span class="Validform_checktip">*</span></dd>
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
  </div>
  <div class="tab-content" style="display:none">
  <dl>
    <dt>颜色</dt>
    <dd><asp:TextBox ID="txtColor" runat="server" CssClass="input normal"/><span class="Validform_checktip">*颜色(扩展功能)</span></dd>
  </dl>
  <dl>
    <dt>图标</dt>
    <dd>
      <asp:TextBox ID="txtIconUrl" runat="server" CssClass="input normal upload-path" />
      <div class="upload-box upload-img"></div>
    </dd>
    <dd id="divIcon" class="imgdiv" runat="server" visible="false">
        <asp:Image runat="server" ID="imgIcon" />
    </dd>
  </dl>
  <dl>
    <dt>内容类型</dt>
    <dd>
        <div class="rule-single-select">
            <asp:DropDownList ID="ddlType" runat="server">
              <asp:ListItem Value="0" Selected="True">内容编辑器</asp:ListItem>
              <asp:ListItem Value="1">纯文本内容</asp:ListItem>
            </asp:DropDownList>
         </div>
    </dd>
  </dl>
  <dl>
    <dt>内容</dt>
    <dd><textarea id="txtContent" style=" height:260px; width:100%;" runat="server"></textarea></dd>
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
