<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="builder_index.aspx.cs" Inherits="DTcms.Web.admin.lucene.builder_index" %>
<%@ Import namespace="DTcms.Common" %>
<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>索引管理</title>
<link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
<script type="text/javascript" src="../../scripts/artdialog/dialog-plus-min.js"></script>
<script type="text/javascript" src="../js/laymain.js"></script>
<script type="text/javascript" src="../js/common.js"></script>
<script type="text/javascript">
    function ajaxCreateSearchIndex(create) {
        var d = top.dialog({
            title: '提示',
            content: "此操作将会消耗大量的资源，确认要继续吗？",
            okValue: '确定',
            ok: function () {
                CreateIndex(create);
                d.close().remove();
                return false;
            }
        });
        d.show();
    }
    function CreateIndex(create, objmsg){
        var msg = "正在生成索引文件，请稍后...";
        if (arguments.length == 2) {
            msg = objmsg;
        }
        var dd = top.dialog({
                content: msg,
                cancel: false
            }).show();
            $.ajax({
                type: "get",
                dataType: "json",
                data: "action=create_index&create=" + create,
                url: "../../tools/lucene.ashx?clienttime=" + Math.random(),
                success: function (data) {
                    if (data.status == 1) {
                        dd.content("更新索引文件成功！");
                        setTimeout(function () {
                            dd.close().remove();
                            window.location.reload();
                        }, 2000);
                    } else if (data.status == 2) {
                        dd.close().remove();
                        CreateIndex(0, data.msg);
                    } else {
                        dd.content("更新失败！");
                        setTimeout(function () {
                            dd.close().remove();
                        }, 2000);
                    }
                }
            });
    }
</script>
</head>
<body class="mainbody">
<form id="form1" runat="server">
<!--导航栏-->
<div class="location">
  <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <span>Lucene.Net</span>
  <i class="arrow"></i>
  <span>索引管理</span>
</div>

<div id="floatHead" class="content-tab-wrap">
  <div class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
        <li><a class="selected" href="javascript:;">生成索引</a></li>
        <li><a href="javascript:;">索引配置</a></li>
      </ul>
    </div>
  </div>
</div>

<div class="tab-content lucene">
    <dl>
        <dt>更新索引</dt>
        <dd>
          <input type="button" value="更新" class="btn" onclick="ajaxCreateSearchIndex(0);" />
          <span class="Validform_checktip">如果有新增的内容，需要更新</span>
        </dd>
    </dl>
    <dl>
        <dt>全新索引</dt>
        <dd>
          <input type="button" value="更新" class="btn" onclick="ajaxCreateSearchIndex(1);" />
          <span class="Validform_checktip">如果对旧的内容进行了修改或删除，需要更新</span>
        </dd>
    </dl>
</div>
<div class="tab-content" style="display:none;">
    <table border="0" cellspacing="0" cellpadding="0" class="border-table" width="100%">
        <thead>
            <tr>
                <th width="120" style="text-align:left;">频道名称</th>
                <th width="150" style="text-align:left;">是否生成索引</th>
                <th width="150" style="text-align:left;">最后生成ID</th>
                <th style="text-align:left;">最后生成时间</th>
            </tr>
        </thead>
        <tbody id="ChannelPannel" runat="server">
        </tbody>
    </table>
    <!--工具栏-->
    <div class="page-footer">
        <div class="btn-wrap">
            <asp:Button ID="btnSubmit" runat="server" Text="保存配置" CssClass="btn" onclick="btnSubmit_Click" />
            <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript:history.back(-1);" />
        </div>
    </div>
    <!--/工具栏-->
</div>
</form>
</body>
</html>