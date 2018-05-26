<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="group_extended_edit.aspx.cs" Inherits="DTcms.Web.Plugin.Forum.admin.group_extended_edit" ValidateRequest="false" %>

<%@ Import Namespace="DTcms.Common" %>
<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>编辑dt_Forum_GroupExtended</title>
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
            <a href="Forum_GroupExtended_list.aspx" class="back"><i></i><span>返回列表页</span></a>
            <a href="../../../<%=siteConfig.webmanagepath %>/center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>插件管理</span>
            <i class="arrow"></i>
            <span>论坛管理</span>
            <i class="arrow"></i>
            <span>编辑组权限</span>
        </div>
        <div class="line10"></div>

        <!--/导航栏-->

        <!--内容-->
        <div id="floatHead" class="content-tab-wrap">
            <div class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a class="selected" href="javascript:;">组权限</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="tab-content">
            
            <dl>
                <dt>显示ip段数</dt>
                <dd>
                    <asp:TextBox ID="txtViewIpField" runat="server" CssClass="input normal" datatype="" sucmsg=" "
                        ajaxurl=""></asp:TextBox>
                    <span class="Validform_checktip">*必填项</span>
                </dd>
            </dl>
            <dl>
                <dt>附件扩展名</dt>
                <dd>
                    <asp:TextBox ID="txtAttachmentExtension" runat="server" CssClass="input normal" datatype="" sucmsg=" "
                        ajaxurl=""></asp:TextBox>
                    <span class="Validform_checktip">*格式如：jpg,png,gif</span>
                </dd>
            </dl>
            <dl>
                <dt>日上传附件最大量</dt>
                <dd>
                    <asp:TextBox ID="txtDayAttachmentSize" runat="server" CssClass="input normal" datatype="" sucmsg=" "
                        ajaxurl=""></asp:TextBox>
                    <span class="Validform_checktip">* K(1024K=1M)如果不限至当天上传附件量，单位为K，这里可以填0表示无限制。</span>
                </dd>
            </dl>
            <dl>
                <dt>发帖间隔时间</dt>
                <dd>
                    <asp:TextBox ID="txtPostIntervalSecond" runat="server" CssClass="input normal" datatype="" sucmsg=" "
                        ajaxurl=""></asp:TextBox>
                    <span class="Validform_checktip">*秒</span>
                </dd>
            </dl>
            <dl>
                <dt>使用搜索</dt>
                <dd>

                    <div class="rule-multi-radio">
                        <asp:RadioButtonList ID="rblSearch" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Value="1" Selected="True">允许</asp:ListItem>
                            <asp:ListItem Value="0">禁止</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>

                </dd>
            </dl>
            <dl>
                <dt>查看会员列表</dt>
                <dd>

                    <div class="rule-multi-radio">
                        <asp:RadioButtonList ID="rblMemberList" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Value="1" Selected="True">允许</asp:ListItem>
                            <asp:ListItem Value="0">禁止</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>

                </dd>
            </dl>
            <dl>
                <dt>发帖审核</dt>
                <dd>

                    <div class="rule-single-select">
                        <asp:DropDownList ID="ddlPostCheck" runat="server">

                            <asp:ListItem Text="不需审核" Value="0" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="发主题与回复都需审核" Value="1"></asp:ListItem>
                            <asp:ListItem Text="发主题需审核" Value="2"></asp:ListItem>
                            <asp:ListItem Text="发回复需审核" Value="3"></asp:ListItem>

                        </asp:DropDownList>
                    </div>

                </dd>
            </dl>
            <dl>
                <dt>出售附件</dt>
                <dd>

                    <div class="rule-multi-radio">
                        <asp:RadioButtonList ID="rblCost" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Value="1" Selected="True">允许</asp:ListItem>
                            <asp:ListItem Value="0">禁止</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>


                </dd>
            </dl>
            <dl>
                <dt>出售上限</dt>
                <dd>
                    <asp:TextBox ID="txtCostMax" runat="server" CssClass="input normal" datatype="" sucmsg=" "
                        ajaxurl="">0</asp:TextBox>
                    <span class="Validform_checktip">元</span>
                </dd>
            </dl>
            <dl>
                <dt>帖子编辑痕迹</dt>
                <dd>


                    <div class="rule-single-select">
                        <asp:DropDownList ID="ddlPostUpdateLog" runat="server">

                            <asp:ListItem Text="编辑帖子后不留下编辑痕迹" Value="0" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="编辑帖子后留下编辑痕迹" Value="1"></asp:ListItem>
                            <asp:ListItem Text="让编辑者选择是否留下编辑痕迹" Value="2"></asp:ListItem>

                        </asp:DropDownList>
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
