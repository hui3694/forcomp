<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pro_edit.aspx.cs" Inherits="DTcms.Web.admin.pro.pro_edit" %>

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
    <script type="text/javascript" charset="utf-8" src="../../scripts/datepicker/WdatePicker.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../scripts/artdialog/dialog-plus-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../scripts/ueditor/lang/zh-cn/zh-cn.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/uploader.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
    <script type="text/javascript">
        $(function () {
            //初始化表单验证
            $("#form1").initValidform();
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
      <a href="category_list.aspx"><span>产品管理</span></a>
      <i class="arrow"></i>
      <span>编辑产品</span>
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
        <dt>类别</dt>
        <dd>
          <div class="rule-single-select">
            <asp:DropDownList id="ddlCategoryId" runat="server" datatype="*"></asp:DropDownList>
          </div>
        </dd>
      </dl>
      <dl>
        <dt>排序数字</dt>
        <dd>
          <asp:TextBox ID="txtSort" runat="server" CssClass="input mark" datatype="n" sucmsg=" ">99</asp:TextBox>
          <span class="Validform_checktip">*数字，越小越向前</span>
        </dd>
      </dl>
        <dl>
        <dt>标题</dt>
        <dd><asp:TextBox ID="txtTitle" runat="server" CssClass="input normal" datatype="*1-100" sucmsg=" "></asp:TextBox> <span class="Validform_checktip">*类别中文名称，100字符内</span></dd>
      </dl>
        <dl>
        <dt>城市</dt>
        <dd>
            <asp:TextBox ID="txtCity" runat="server" CssClass="input mark" datatype="*" sucmsg=" "></asp:TextBox> 
            <span class="Validform_checktip">*类别中文名称，100字符内</span>
        </dd>
      </dl>
      <dl>
        <dt>定位</dt>
        <dd>
            <asp:TextBox ID="txtLat" runat="server" CssClass="input mark" datatype="*" sucmsg=" "></asp:TextBox> ,
            <asp:TextBox ID="txtLon" runat="server" CssClass="input mark" datatype="*" sucmsg=" "></asp:TextBox> 
            <span class="Validform_checktip">*类别中文名称，100字符内</span>
        </dd>
      </dl>
      
      
      <dl>
        <dt>详细地址</dt>
        <dd>
            <asp:TextBox ID="txtAddr" runat="server" CssClass="input normal" datatype="*" sucmsg=" "></asp:TextBox> 
            <span class="Validform_checktip">*类别中文名称，100字符内</span>
        </dd>
      </dl>
      
      <dl>
        <dt>内容</dt>
        <dd>
            <asp:TextBox ID="txtCont" runat="server" CssClass="input normal" TextMode="MultiLine" datatype="*" sucmsg=" "></asp:TextBox> 
            <span class="Validform_checktip">*类别中文名称，100字符内</span>
        </dd>
      </dl>
      <dl>
        <dt>添加时间</dt>
        <dd>
            <asp:TextBox ID="txtAddTime" runat="server" CssClass="input rule-date-input" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}\s{1}(\d{1,2}:){2}\d{1,2}$/" errormsg="请选择正确的日期" sucmsg=" " /></asp:TextBox> 
            <span class="Validform_checktip">*类别中文名称，100字符内</span>
        </dd>
      </dl>
      <dl>
        <dt>通过时间</dt>
        <dd>
            <asp:TextBox ID="txtPassTime" runat="server" CssClass="input rule-date-input" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}\s{1}(\d{1,2}:){2}\d{1,2}$/" errormsg="请选择正确的日期" sucmsg=" " /></asp:TextBox> 
            <span class="Validform_checktip">*类别中文名称，100字符内</span>
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
