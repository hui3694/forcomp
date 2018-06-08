<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="news_edit.aspx.cs" Inherits="DTcms.Web.admin.news.news_edit" ValidateRequest="false" %>
<%@ Import namespace="DTcms.Common" %>

<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>编辑内容</title>
<link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" charset="utf-8" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
<script type="text/javascript" charset="utf-8" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
<script type="text/javascript" charset="utf-8" src="../../scripts/datepicker/WdatePicker.js"></script>
<script type="text/javascript" charset="utf-8" src="../../scripts/artdialog/dialog-plus-min.js"></script>
<script type="text/javascript" charset="utf-8" src="../../scripts/webuploader/webuploader.min.js"></script>
<script type="text/javascript" charset="utf-8" src="../../scripts/ueditor/ueditor.config.js"></script>
<script type="text/javascript" charset="utf-8" src="../../scripts/ueditor/ueditor.all.min.js"></script>
<script type="text/javascript" charset="utf-8" src="../../scripts/ueditor/lang/zh-cn/zh-cn.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/tagsinput.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/uploader.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
<script type="text/javascript">
    $(function () {
        //操作类型
        var Control_Type = "<%=action%>";

        //初始化表单验证
        $("#form1").initValidform();

        //初始化ueditor
        var ue = UE.getEditor('txtContent');

        //tags
        $("#txtTags").tagsInput();

        //初始化上传控件
        $(".upload-img").InitUploader({ filesize: "<%=siteConfig.imgsize %>", sendurl: "../../tools/upload_ajax.ashx", swf: "../../scripts/webuploader/uploader.swf", filetypes: "<%=siteConfig.fileextension.Replace(".","") %>" });
        $(".upload-video").InitUploader({ filesize: "<%=siteConfig.videosize %>", sendurl: "../../tools/upload_ajax.ashx", swf: "../../scripts/webuploader/uploader.swf", filetypes: "<%=siteConfig.videoextension.Replace(".","") %>", type:2 });

        //设置封面图片的样式
        $(".photo-list ul li .img-box img").each(function () {
            if ($(this).attr("src") == $("#hidFocusPhoto").val()) {
                $(this).parent().addClass("selected");
            }
        });

        //创建上传附件
        $(".attach-btn").click(function () {
            showAttachDialog();
        });

        //创建商品规格
        $(".spec-btn").click(function () {
            showSpecDialog();
        });

        //赋值规格市场价格
        $("#field_control_market_price").blur(function () {
            $("#div_spec__container").find("input[name='spec_market_price']").val($(this).val());
        });
        //赋值规格销售价格
        $("#field_control_sell_price").blur(function () {
            $("#div_spec__container").find("input[name='spec_sell_price']").val($(this).val());
        });
    });

    //创建同类选择窗口
    function showChooseDialog(obj, sidername) {
        var d = top.dialog({
            id: 'dialogChoose',
            title: '相关信息选择',
            url: 'dialog/dialog_choose.aspx?sidername=' + sidername,
            width: 800,
            onclose: function () {
                var liHtml = this.returnValue; //获取返回值
                if (liHtml.length > 0) {
                    var box = $(obj).parent().parent();
                    //判断是否存在tbody
                    if (box.find("tbody").length <= 0) {
                        box.find("table").html("<tbody></tbody>")
                    }
                    box.find("tbody").append(liHtml);
                }
            }
        }).showModal();
    }
    //清除选择
    function remoreThis(obj) {
        $(obj).parent().parent().remove();
    }

    //初始化附件窗口
    function showAttachDialog(obj) {
        var objNum = arguments.length;
        var attachDialog = top.dialog({
            id: 'attachDialogId',
            title: "上传附件",
            url: 'dialog/dialog_attach.aspx',
            width: 500,
            height: 180,
            onclose: function () {
                var liHtml = this.returnValue; //获取返回值
                if (liHtml.length > 0) {
                    $("#showAttachList").children("ul").append(liHtml);
                }
            }
        }).showModal();
        //如果是修改状态，将对象传进去
        if (objNum == 1) {
            attachDialog.data = obj;
        }
    }
    //删除附件节点
    function delAttachNode(obj) {
        $(obj).parent().remove();
    }

    //初始化规格窗口
    function showSpecDialog() {
        var d = top.dialog({
            id: 'specDialogId',
            padding: 0,
            title: "商品规格",
            url: 'dialog/dialog_spec_item.aspx'
        }).showModal();
        //将容器对象传进去
        d.data = $("#item_box");
    }
    //初始化会员组价格窗口
    function showPriceDialog(obj) {
        var d = top.dialog({
            padding: 0,
            title: "会员组价格",
            url: 'dialog/dialog_group_price.aspx',
            width: 400
        }).showModal();
        //将对象传进去
        d.data = obj;
    }
    //计算出最小的市场价格
    function countMarketPrice(obj) {
        var objName = $(obj).attr("name");
        var minValue = parseFloat($(obj).val());
        $("input[name='" + objName + "']").each(function () {
            if ($(this).val().length > 0) {
                if (parseFloat($(this).val()) < minValue) {
                    minValue = parseFloat($(this).val());
                }
            }
        });
        $("#field_control_market_price").val(minValue);
    }
    //计算最小的销售价格
    function countSellPrice(obj) {
        var objName = $(obj).attr("name");
        var minValue = parseFloat($(obj).val());
        $("input[name='" + objName + "']").each(function () {
            if ($(this).val().length > 0) {
                if (parseFloat($(this).val()) < minValue) {
                    minValue = parseFloat($(this).val());
                }
            }
        });
        $("#field_control_sell_price").val(minValue);
    }
    //计算库存总数量
    function countStockQuantity(obj) {
        var objName = $(obj).attr("name");
        var countValue = 0;
        $("input[name='" + objName + "']").each(function () {
            if ($(this).val().length > 0) {
                countValue += parseFloat($(this).val());
            }
        });
        $("#field_control_stock_quantity").val(countValue);
    }
    //图片排序
    var Compositor = function () {

        var box = $("#photo-list").find("li");

        box.each(function (index) {
            $(this).find(".hid_photo_sort").val(index);
        });
    }
    //前移
    function forward(o) {
        $(o).parent("li").prev("li").insertAfter($(o).parent("li"));
        Compositor();
    }
    //后移
    function behind(o) {
        $(o).parent("li").next("li").insertBefore($(o).parent("li"));
        Compositor();
    }
    //弹出显示图片
    function ajaxLoadImg(obj) {
        var url = $(obj).parent().find("img").attr("bigsrc");
        top.dialog({
            title: url,
            content: '<img src="' + url + '" style="max-width:800px; max-height:600px;" />'
        }).showModal();
    }
    //添加扩展参数一行
    function addAttribute() {
        var liHtml = '<li>'
            + '<input name="hid_attribute_name" class="input small" onkeydown="onColumn(this)" placeholder="名称" type="text" />'
            + '<input name="hid_attribute_value" class="input normal" onkeydown="onColumn(this)" placeholder="内容" type="text" />'
            + '<a href="javascript:;" onclick="delAttributeNode(this);" class="del" title="删除">删除</a>'
            + '</li>';
        $("#showAttributeList").children("ul").append(liHtml);
    }
    //删除附件节点
    function delAttributeNode(obj) {
        $(obj).parent().remove();
    }
</script>
</head>

<body class="mainbody">
<form id="form1" runat="server">
<!--导航栏-->
<div class="location">
  <a href="news_list.aspx" class="back"><i></i><span>返回列表页</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <a href="news_list.aspx"><span>内容管理</span></a>
  <i class="arrow"></i>
  <span>编辑内容</span>
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
  <dl>
    <dt>内容标题</dt>
    <dd>
      <asp:TextBox ID="txtTitle" runat="server" CssClass="input normal" datatype="*2-100" sucmsg=" " />
      <span class="Validform_checktip">*标题最多100个字符</span>
    </dd>
  </dl>
  <dl>
    <dt>显示状态</dt>
    <dd>
      <div class="rule-multi-radio">
        <asp:RadioButtonList ID="rblIsHide" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
        <asp:ListItem Value="0" Selected="True">正常</asp:ListItem>
        <asp:ListItem Value="1">隐藏</asp:ListItem>
        </asp:RadioButtonList>
      </div>
    </dd>
  </dl>
  <dl>
    <dt>允许评论</dt>
    <dd>
      <div class="rule-multi-radio">
        <asp:RadioButtonList ID="rblIsMsg" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
        <asp:ListItem Value="0">禁止</asp:ListItem>
        <asp:ListItem Value="1" Selected="True">允许</asp:ListItem>
        </asp:RadioButtonList>
      </div>
    </dd>
  </dl>

  <dl>
    <dt>封面图片</dt>
    <dd>
      <asp:TextBox ID="txtImg" runat="server" CssClass="input normal upload-path" />
      <div class="upload-box upload-img"></div>
    </dd>
    <dd id="ImgDiv" class="imgdiv" runat="server" visible="false">
        <asp:Image runat="server" ID="ImgUrl" />
    </dd>
  </dl>
  <dl>
    <dt>&nbsp;</dt>
    <dd>
      <asp:CheckBox ID="autoImg" runat="server" />
      <label for="autoImg">自动提取内容第一张图片为缩略图</label>
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
    <dt>浏览次数</dt>
    <dd>
      <asp:TextBox ID="txtClick" runat="server" CssClass="input mark" datatype="n" sucmsg=" ">0</asp:TextBox>
      <span class="Validform_checktip">点击浏览该信息自动+1</span>
    </dd>
  </dl>
  <dl>
    <dt>发布时间</dt>
    <dd>
      <asp:TextBox ID="txtTime" runat="server" CssClass="input rule-date-input" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}\s{1}(\d{1,2}:){2}\d{1,2}$/" errormsg="请选择正确的日期" sucmsg=" " />
      <span class="Validform_checktip">不选择默认当前发布时间</span>
    </dd>
  </dl>
  <dl>
    <dt>内容摘要</dt>
    <dd>
      <asp:TextBox ID="txtZhaiyao" runat="server" CssClass="input" TextMode="MultiLine" datatype="*0-255" sucmsg=" "></asp:TextBox>
      <span class="Validform_checktip">不填写则自动截取内容前255字符</span>
    </dd>
  </dl>
  <dl>
    <dt>内容描述</dt>
    <dd>
      <textarea id="txtContent" style="height:300px; width:100%;" runat="server"></textarea>
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