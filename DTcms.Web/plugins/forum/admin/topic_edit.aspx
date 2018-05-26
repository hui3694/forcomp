<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="topic_edit.aspx.cs" Inherits="DTcms.Web.Plugin.Forum.admin.topic_edit" ValidateRequest="false" %>

<%@ Import Namespace="DTcms.Common" %>
<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>编辑dt_Forum_Topic</title>
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
        var ue = UE.getEditor('txtMessage');
    });
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="Forum_Topic_list.aspx" class="back"><i></i><span>返回列表页</span></a>
            <a href="../../../<%=siteConfig.webmanagepath %>/center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>插件管理</span>
            <i class="arrow"></i>
            <span>论坛管理</span>
            <i class="arrow"></i>
            <span>编辑主题</span>
        </div>
        <div class="line10"></div>

        <!--/导航栏-->

        <!--内容-->
        <div id="floatHead" class="content-tab-wrap">
            <div class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a class="selected" href="javascript:;">主题信息</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="tab-content">

            <dl>
                <dt>所属版块</dt>
                <dd>

                      <div class="rule-single-select">
                    <asp:DropDownList ID="ddlBoardId" runat="server" AutoPostBack="False" ></asp:DropDownList>
                    </div>
                </dd>
            </dl>
            <dl style="display:none;">
                <dt>TopicTypeId</dt>
                <dd>
                    <asp:TextBox ID="txtTopicTypeId" runat="server" CssClass="input normal" datatype="" sucmsg=" "
                        ajaxurl="">0</asp:TextBox>
                    <span class="Validform_checktip">*必填项</span>
                </dd>
            </dl>

             

            <dl>
                <dt>标题</dt>
                <dd>
                    <asp:TextBox ID="txtTitle" runat="server" CssClass="input normal" datatype="" sucmsg=" "
                        ajaxurl=""></asp:TextBox>
                    <span class="Validform_checktip">*必填项</span>
                </dd>
            </dl>

            <dl>
                <dt>内容</dt>
                <dd>


                    <asp:TextBox ID="txtMessage" runat="server" Height="300px" Width="100%" TextMode="MultiLine" datatype="" sucmsg=" "
                        ajaxurl=""></asp:TextBox>

                </dd>
            </dl>

            <dl>
                <dt>状态</dt>
                <dd>
                    <div class="rule-multi-checkbox">
                        <asp:CheckBoxList ID="cblItem" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Value="1">精华</asp:ListItem>
                            <asp:ListItem Value="1">置顶</asp:ListItem>
                            <asp:ListItem Value="1">屏蔽</asp:ListItem>        
                        </asp:CheckBoxList>
                    </div>
                </dd>
            </dl>

            <dl>
                <dt>访问</dt>
                <dd>
                    <asp:TextBox ID="txtViewCount" runat="server" CssClass="input normal small" datatype="" sucmsg=" "
                        ajaxurl="">0</asp:TextBox>
                    <span class="Validform_checktip">*次</span>
                </dd>
            </dl>
            <dl>
                <dt>发布时间</dt>
                <dd>
                    <asp:TextBox ID="txtPostDatetime" runat="server" CssClass="input rule-date-input" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}\s{1}(\d{1,2}:){2}\d{1,2}$/" errormsg="请选择正确的日期" sucmsg=" " />
                    <span class="Validform_checktip">不选择默认当前发布时间</span>
                </dd>
            </dl>


            <dl>
                <dt>会员编号</dt>
                <dd>
                    <asp:TextBox ID="txtUserId" runat="server" CssClass="input normal small" datatype="" sucmsg=" "
                        ajaxurl=""></asp:TextBox>
                    <span class="Validform_checktip">*贴子归属的会员编号，建议一般不修改</span>
                </dd>
            </dl>

            <dl>
                <dt>关闭</dt>
                <dd>
                    <div class="rule-multi-radio">
                        <asp:RadioButtonList ID="rblClose" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Value="1" >是</asp:ListItem>
                            <asp:ListItem Value="0" Selected="True">否</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </dd>
            </dl>


        </div>
        <!--/内容-->

        <!--工具栏-->
        <div class="page-footer">
            <div class="btn-wrap">
                <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" />
                <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
            </div>
        </div>
        <!--/工具栏-->
    </form>
</body>
</html>
