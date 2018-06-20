<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pangu.aspx.cs" Inherits="DTcms.Web.admin.lucene.pangu" %>
<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>词库管理</title>
<link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
<script type="text/javascript" src="../../scripts/artdialog/dialog-plus-min.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
<script type="text/javascript">
    var att = {};
    $(function () {
        //赋值
        att = {
            sel: $("#btnSearch"),
            add: $("#BtnAdd"),
            edit: $("#BtnEdit"),
            del: $("#BtnDelete"),
            crt: $("#BtnCreate"),
            all: $("#BtnAddAll"),
            count: $("#Count"),
            key: $("#keywords"),
            rec: $("#Record"),
            list: $("#listBox"),
            word: $("#txtWord"),
            frequency: $("#txtFrequency"),
            ctr: $("#PosCtrl")
        };
        //默认词性
        att.ctr.find("input:last").prop("checked", true).next("label").addClass("red");
        //获取词库总数
        $.get("../../tools/lucene.ashx?action=get_dic_count", function (data) {
            att.count.text(data.count);
        }, "json");
        //关键词
        att.key.keydown(function (e) {
            if (e.keyCode == 13) {
                AjaxSearch();
            }
        });
        att.word.keydown(function (e) {
            if (e.keyCode == 13) {
                if (att.add.attr("disabled") == undefined) {
                    AjaxAdd();
                } else {
                    AjaxEdit();
                }
            }
        });
        att.frequency.keydown(function (e) {
            if (e.keyCode == 13) {
                if (att.add.attr("disabled") == undefined) {
                    AjaxAdd();
                } else {
                    AjaxEdit();
                }
            }
        });
        //查询
        att.sel.click(function () {
            AjaxSearch();
        });
        //添加
        att.add.click(function () {
            AjaxAdd();
        });
        //修改
        att.edit.click(function () {
            AjaxEdit();
        });
        //删除词语
        att.del.click(function () {
            AjaxDelete()
        });
        //重建数据库
        att.crt.click(function () {
            var winDialog = top.dialog({
                title: '提示',
                width: 320,
                content: '操作提示信息：<br />1、禁止非专业人员执行重建词库操作；<br />2、执行本操作会操作区域查询系统无法使用；<br />3、请问是否继续操作！',
                okValue: '确定重建词库',
                ok: function () {
                    winDialog.close().remove();
                    $.post("../../tools/lucene.ashx?action=create_dictionaries", function (data) {
                        var tipdialog = dialog({ content: data.msg }).show();
                        setTimeout(function () {
                            tipdialog.close().remove();
                            location.reload();
                        }, 2000);
                    }, "json");
                    return false;
                },
                cancelValue: '取消',
                cancel: function () { }
            }).showModal();
        });
        //批量添加
        att.all.click(function () {
            var b = top.dialog({
                title: "批量添加",
                content: '<div class="dic_addall"><label for="textarea">词语列表</label><p><textarea name="txtWordBox" id="txtWordBox" cols="45" rows="5"></textarea></p></div>',
                okValue: "确定",
                ok: function () {
                    $.ajax({
                        type: "POST",
                        dataType: "json",
                        url: "../../tools/lucene.ashx?action=add_dic_word_all",
                        data: {
                            k: $("#txtWordBox", parent.document).val(),
                            f: att.frequency.val(),
                            p: att.ctr.find("input[type=checkbox]:checked").val()
                        },
                        success: function (data) {
                            msgbox(data.msg);
                            b.close().remove();
                        },
                        error: function () {
                            msgbox("加载失败，请稍后重试！")
                        }
                    });
                    return false
                },
                cancelValue: "取消",
                cancel: function () { }
            }).showModal();
        });
        //动态查询
        att.word.on('input propertychange', function () {
            $.post("../../tools/lucene.ashx?action=get_dic_attr", { k: $(this).val() }, function (data) {
                if (parseInt(data.status) == 1) {
                    //词频
                    att.frequency.val(data.frequency);
                    //清空词性
                    att.ctr.find("input:enabled").prop("checked", false).next("label").removeClass("red");
                    //词性
                    att.ctr.find("input[value=" + data.pos + "]").prop("checked", true).next("label").addClass("red");
                    //启用控件
                    att.add.attr("disabled", "disabled");
                    att.edit.removeAttr("disabled");
                    att.del.removeAttr("disabled");
                } else {
                    att.frequency.val(0);
                    att.add.removeAttr("disabled");
                    att.edit.attr("disabled", "disabled");
                    att.del.attr("disabled", "disabled");
                    //默认词性
                    att.ctr.find("input:enabled").prop("checked", false).next("label").removeClass("red");
                    att.ctr.find("input:last").prop("checked", true).next("label").addClass("red");
                }
            }, "json");
        });
        //词性
        att.ctr.find("input").click(function () {
            att.ctr.find("input:enabled").prop("checked", false);
            $(this).prop("checked", true);
        });
    });

    //添加方法
    function AjaxAdd() {
        $.post("../../tools/lucene.ashx?action=add_dic_word", { k: att.word.val(), f: att.frequency.val(), p: att.ctr.find("input[type=checkbox]:checked").val() }, function (data) {
            if (parseInt(data.status) == 1) {
                //按键
                att.add.attr("disabled", "disabled");
                att.edit.removeAttr("disabled");
                att.del.removeAttr("disabled");
                //词总数
                att.count.text(parseInt(att.count.text()) + 1);
            }
            top.dialog({
                title: '提示',
                content: data.msg,
                width: 200,
                okValue: '确定',
                ok: function () { }
            }).showModal();
        }, "json");
    }

    //修改方法
    function AjaxEdit() {
        $.post("../../tools/lucene.ashx?action=edit_dic_word", { k: att.word.val(), f: att.frequency.val(), p: att.ctr.find("input[type=checkbox]:checked").val() }, function (data) {
            top.dialog({
                title: '提示',
                content: data.msg,
                width: 200,
                okValue: '确定',
                ok: function () { }
            }).showModal();
        }, "json");
    }

    //删除方法
    function AjaxDelete() {
        var winDialog = top.dialog({
            title: '提示',
            width: 280,
            content: '您正在执行删除操作，请问是否继续?',
            okValue: '确定删除',
            ok: function () {
                winDialog.close().remove();
                $.post("../../tools/lucene.ashx?action=del_dic_word", { k: att.word.val() }, function (data) {
                    if (parseInt(data.status) == 1) {
                        att.word.val('');
                        att.frequency.val(0);
                        att.add.removeAttr("disabled");
                        att.edit.attr("disabled", "disabled");
                        att.del.attr("disabled", "disabled");
                        //默认词性
                        att.ctr.find("input:enabled").prop("checked", false).next("label").removeClass("red");
                        att.ctr.find("input:last").prop("checked", true).next("label").addClass("red");
                        //词总数
                        att.count.text(parseInt(att.count.text()) - 1);
                    }
                    top.dialog({
                        title: '提示',
                        content: data.msg,
                        width: 200,
                        okValue: '确定',
                        ok: function () { }
                    }).showModal();
                }, "json");
                return false;
            },
            cancelValue: '取消',
            cancel: function () { }
        }).showModal();
    }

    //查询加载
    function AjaxSearch() {
        var keywords = att.key.val();
        if (keywords.length > 0) {
            $.ajax({
                type: "POST",
                dataType: "json",
                url: "../../tools/lucene.ashx?action=get_search_prompt",
                data: { k: keywords },
                success: function (data) {
                    if (parseInt(data.status) == 1) {
                        att.rec.text(data.count);
                        var html, json = data.list;
                        for (i = 0; i < json.length; i++) {
                            html += "<option value=\"" + json[i] + "\">" + json[i] + "</option>";
                        }
                        att.list.html(html);
                        //绑定事件
                        bindSelect();
                    } else {
                        att.list.empty();
                    }
                },
                error: function () {
                    msgbox("Sorry，加载失败，请联系管理员！");
                }
            });
        } else {
            att.list.empty();
        }
    }
    //绑定选择
    function bindSelect() {
        att.list.find("option").unbind("dblclick").bind("dblclick", function () {
            $.post("../../tools/lucene.ashx?action=get_dic_attr", { k: $(this).val() }, function (data) {
                //关键词
                att.word.val(data.key);
                //词频
                att.frequency.val(data.frequency);
                //清空词性
                att.ctr.find("input:enabled").prop("checked", false).next("label").removeClass("red");
                //词性
                att.ctr.find("input[value=" + data.pos + "]").prop("checked", true).next("label").addClass("red");
                //启用控件
                att.add.attr("disabled", "disabled");
                att.edit.removeAttr("disabled");
                att.del.removeAttr("disabled");
            }, "json");
        });
    }

    //提示
    function msgbox(content) {
        var d = top.dialog({ content: content }).show();
        setTimeout(function () {
            d.close().remove();
        }, 2000);
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
  <span>词库管理</span>
</div>
<!--/导航栏-->

<!--词库管理-->
<div class="dictmanage">
    <div class="hd">
        <input name="keywords" type="text" id="keywords" class="txt" />
        <input type="button" name="btnSearch" id="btnSearch" class="search" value="查询" />
        <span class="tips">单词总数<asp:Label ID="Count" runat="server" Text="0"></asp:Label>符合记录总数<asp:Label ID="Record" runat="server" Text="0"></asp:Label></span>
    </div>
    <div class="bd">
        <div class="left">
            <select name="listBox" size="20" id="listBox" class="listbox">
            </select>
        </div>
        <div class="right">
            <div class="hd">
                <input name="oldword" type="hidden" id="oldWord" value="1" />
                单词：<input name="word" type="text" id="txtWord" class="txt" />
                词频：<input name="frequency" type="text" id="txtFrequency" class="txt small center" value="0" />
            </div>
            <div class="poslist">
                <asp:CheckBoxList ID="PosCtrl" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="cbllist"></asp:CheckBoxList>
            </div>
            <div class="button">
                <input type="button" id="BtnAdd" class="search" value="添加"/>
                <input type="button" id="BtnEdit" class="search" value="修改" disabled="disabled" />
                <input type="button" id="BtnDelete" class="search" value="删除" disabled="disabled" />
                <input type="button" id="BtnCreate" class="search" value="重建词库" />
                <input type="button" id="BtnAddAll" class="search" value="批量添加" />
            </div>
        </div>
    </div>
</div>
<!--/词库管理-->
</form>
</body>
</html>