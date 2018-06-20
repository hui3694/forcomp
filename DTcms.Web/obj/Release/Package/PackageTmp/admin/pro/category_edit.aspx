<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="category_edit.aspx.cs" Inherits="DTcms.Web.admin.pro.category_edit" %>
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
    <script type="text/javascript" charset="utf-8" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../scripts/artdialog/dialog-plus-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../scripts/webuploader/webuploader.min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../scripts/ueditor/ueditor.config.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../scripts/ueditor/ueditor.all.min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../scripts/ueditor/lang/zh-cn/zh-cn.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/uploader.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
    <script type="text/javascript">
        $(function () {
            //初始化表单验证
            $("#form1").initValidform();
            //初始化上传控件
            $(".upload-img").InitUploader({ sendurl: "../../tools/upload_ajax.ashx", swf: "../../scripts/webuploader/uploader.swf" });
        });
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
    <!--导航栏-->
    <div class="location">
      <a href="category_list.aspx" class="back"><i></i><span>返回列表页</span></a>
      <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
      <i class="arrow"></i>
      <a href="category_list.aspx"><span>内容类别</span></a>
      <i class="arrow"></i>
      <span>编辑分类</span>
    </div>
    <div class="line10"></div>
    <!--/导航栏-->

    <!--内容-->
    <div id="floatHead" class="content-tab-wrap">
      <div class="content-tab">
        <div class="content-tab-ul-wrap">
          <ul>
            <li><a class="selected" href="javascript:;">基本信息</a></li>
          </ul>
        </div>
      </div>
    </div>

    <div class="tab-content">
      <dl runat="server" id="div_parent">
        <dt>所属父类别</dt>
        <dd>
          <div class="rule-single-select">
            <asp:DropDownList id="ddlParentId" runat="server" datatype="*"></asp:DropDownList>
          </div>
        </dd>
      </dl>
      <dl>
        <dt>排序数字</dt>
        <dd>
          <asp:TextBox ID="txtSortId" runat="server" CssClass="input mark" datatype="n" sucmsg=" ">99</asp:TextBox>
          <span class="Validform_checktip">*数字，越小越向前</span>
        </dd>
      </dl>
      <dl>
        <dt>类别名称</dt>
        <dd><asp:TextBox ID="txtTitle" runat="server" CssClass="input normal" datatype="*1-100" sucmsg=" "></asp:TextBox> <span class="Validform_checktip">*类别中文名称，100字符内</span></dd>
      </dl>
      <dl>
        <dt>图标</dt>
        <dd>
          <asp:TextBox ID="txtImgUrl" runat="server" CssClass="input normal upload-path" />
          <div class="upload-box upload-img"></div>
        </dd>
        <dd id="ImgDiv" class="imgdiv" runat="server" visible="false">
            <asp:Image runat="server" ID="ImgUrl" />
        </dd>
      </dl>
     <dl runat="server" id="div_img2">
        <dt>图标2</dt>
        <dd>
          <asp:TextBox ID="txtImgUrl2" runat="server" CssClass="input normal upload-path" />
          <div class="upload-box upload-img"></div>
        </dd>
        <dd id="ImgDiv2" class="imgdiv" runat="server" visible="false">
            <asp:Image runat="server" ID="ImgUrl2" />
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
