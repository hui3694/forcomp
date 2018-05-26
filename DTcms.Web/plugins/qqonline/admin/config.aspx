<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="config.aspx.cs" Inherits="DTcms.Web.Plugin.QQOnline.admin.config" ValidateRequest="false" %>
<%@ Import namespace="DTcms.Common" %>
<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>QQ在线客服参数配置</title>
<link href="../../../<%=siteConfig.webmanagepath %>/skin/default/style.css" rel="stylesheet" type="text/css" />
<link href="../skin/css/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../../../scripts/jquery/jquery-1.11.2.min.js"></script>
<script type="text/javascript" src="../../../scripts/jquery/Validform_v5.3.2_min.js"></script>
<script type="text/javascript" src="../../../scripts/webuploader/webuploader.min.js"></script>
<script type="text/javascript" src="../../../<%=siteConfig.webmanagepath %>/js/uploader.js"></script>
<script type="text/javascript" src="../../../<%=siteConfig.webmanagepath %>/js/common.js"></script>
<script type="text/javascript">
    $(function () {
        //只能选中一项
        $(".checkall input").click(function () {
            $(".checkall input").prop("checked", false);
            $("#hidPattern").val($(this).parent().attr("title"));
            $(this).prop("checked", true);
        });
        $("#form1").initValidform();
        $(".upload-img").InitUploader({ sendurl: "../../../tools/upload_ajax.ashx", swf: "../../../scripts/webuploader/uploader.swf" });
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
  <span>参数配置</span>
</div>
<div class="line10"></div>
<!--/导航栏-->

<!--内容-->
<div id="floatHead" class="content-tab-wrap">
    <div class="content-tab">
        <div class="content-tab-ul-wrap">
            <ul>
            	<li><a class="selected" href="javascript:;">参数配置</a></li>
            </ul>
        </div>
    </div>
</div>
<div class="tab-content">
    <dl>
        <dt>是否启用</dt>
        <dd>
            <div class="rule-single-checkbox">
            <asp:CheckBox ID="cbStatus" runat="server" />
            </div>
            <span class="Validform_checktip">*前端只有在开启时，才会显示。</span>
        </dd>
    </dl>
    <dl>
        <dt>二维码</dt>
        <dd>
            <asp:TextBox ID="txtImgUrl" runat="server" maxlength="255"  CssClass="input normal upload-path" />
            <div class="upload-box upload-img"></div>
            <span class="Validform_checktip">仅在支持二维码样式的情况下才有效。</span>
         </dd>
         <dd id="ImgDiv" class="imgdiv" runat="server" visible="false"><asp:Image runat="server" ID="ImgUrl" /></dd>
    </dl>
    <dl>
        <dt>显示位置</dt>
        <dd>
            <div class="rule-multi-radio">
                <asp:RadioButtonList ID="rblPosition" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem Value="0">左</asp:ListItem>
                    <asp:ListItem Value="1">上</asp:ListItem>
                    <asp:ListItem Value="2">右</asp:ListItem>
                    <asp:ListItem Value="3">下</asp:ListItem>
                    <asp:ListItem Value="4">中</asp:ListItem>
                </asp:RadioButtonList>
            </div>
        </dd>
    </dl>
    <dl>
        <dt>描述(支持HTML)</dt>
        <dd>
            <asp:TextBox ID="txtRemark" runat="server" CssClass="input normal" TextMode="MultiLine"/>
            <span class="Validform_checktip"></span>
        </dd>
    </dl>
    <dl>
        <dt>样式</dt>
        <dd>
            <asp:HiddenField ID="hidPattern" Value="" runat="server" />
            <div class="qqonline">
                <ul class="list">
                    <asp:Repeater ID="rptList1" runat="server">
                    <ItemTemplate>
                    <li>
                        <div class="check">
                            <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" style="vertical-align:middle;" Checked='<%#bool.Parse((Convert.ToInt32(Eval("lock"))==1 ).ToString())%>' ToolTip='<%#Eval("pattern")%>' />
                            
                        </div>
                        <div class="box">
                            <div class="pic"><i></i><img src="<%#Eval("img_url") %>" /></div>
                        </div>
                    </li>
                    </ItemTemplate>
                  </asp:Repeater>
                </ul>
            </div>
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