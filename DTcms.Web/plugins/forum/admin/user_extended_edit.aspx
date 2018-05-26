<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="user_extended_edit.aspx.cs" Inherits="DTcms.Web.Plugin.Forum.admin.user_extended_edit" ValidateRequest="false" %>

<%@ Import Namespace="DTcms.Common" %>
<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>编辑dt_Forum_UserExtended</title>
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
        });
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="Forum_UserExtended_list.aspx" class="back"><i></i><span>返回列表页</span></a>
            <a href="../../../<%=siteConfig.webmanagepath %>/center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>插件管理</span>
            <i class="arrow"></i>
            <span>论坛管理</span>
            <i class="arrow"></i>
            <span>编辑会员</span>
        </div>
        <div class="line10"></div>

        <!--/导航栏-->

        <!--内容-->
        <div id="floatHead" class="content-tab-wrap">
            <div class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a class="selected" href="javascript:;">会员信息</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="tab-content">
            <dl>
                <dt>会员编号</dt>
                <dd>
                    <%=modelUser.id %>
                </dd>
            </dl>

            <dl>
                <dt>会员帐号</dt>
                <dd>
                    <%=modelUser.user_name %>
                </dd>
            </dl>

            <dl>
                <dt>会员昵称</dt>
                <dd>
                    <asp:TextBox ID="txtNickname" runat="server" CssClass="input normal" datatype="" sucmsg=" "
                        ajaxurl=""></asp:TextBox>
                    <span class="Validform_checktip">*必填项</span>
                </dd>
            </dl>
            <dl>
                <dt>会员性别</dt>
                <dd>
                    <div class="rule-multi-radio">
                        <asp:RadioButtonList ID="rblGender" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Value="-1" Selected="True">保密</asp:ListItem>
                            <asp:ListItem Value="1">男</asp:ListItem>
                            <asp:ListItem Value="0">女</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>

                </dd>
            </dl>
            <dl>
                <dt>论坛归组</dt>
                <dd>                    
                    <div class="rule-single-select">
                        <asp:DropDownList ID="ddlGroupId" runat="server" datatype="*" errormsg="请选择组别" sucmsg=" "></asp:DropDownList>
                    </div>

                </dd>
            </dl>

            <dl>
                <dt>论坛勋章</dt>
                <dd>
                    <%=medalHtml %>
                </dd>
            </dl>

            <dl>
                <dt>论坛积分</dt>
                <dd>
                    <asp:TextBox ID="txtCredit" runat="server" CssClass="input small" datatype="n" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*整数</span>
                </dd>
            </dl>

        </div>

        <div class="tab-content" style="display: none;">
            <dl>
                <dt>QQ</dt>
                <dd>
                    <asp:TextBox ID="txtQQ" runat="server" CssClass="input normal" datatype="" sucmsg=" "
                        ajaxurl=""></asp:TextBox>
                    <span class="Validform_checktip">*必填项</span>
                </dd>
            </dl>
            <dl>
                <dt>MSN</dt>
                <dd>
                    <asp:TextBox ID="txtMSN" runat="server" CssClass="input normal" datatype="" sucmsg=" "
                        ajaxurl=""></asp:TextBox>
                    <span class="Validform_checktip">*必填项</span>
                </dd>
            </dl>

            <dl>
                <dt>Birthday</dt>
                <dd>
                    <asp:TextBox ID="txtBirthday" runat="server" CssClass="input normal" datatype="" sucmsg=" "
                        ajaxurl=""></asp:TextBox>
                    <span class="Validform_checktip">*必填项</span>
                </dd>
            </dl>
            <dl>
                <dt>Bio</dt>
                <dd>
                    <asp:TextBox ID="txtBio" runat="server" CssClass="input normal" datatype="" sucmsg=" "
                        ajaxurl=""></asp:TextBox>
                    <span class="Validform_checktip">*必填项</span>
                </dd>
            </dl>
            <dl>
                <dt>Address</dt>
                <dd>
                    <asp:TextBox ID="txtAddress" runat="server" CssClass="input normal" datatype="" sucmsg=" "
                        ajaxurl=""></asp:TextBox>
                    <span class="Validform_checktip">*必填项</span>
                </dd>
            </dl>
            <dl>
                <dt>Site</dt>
                <dd>
                    <asp:TextBox ID="txtSite" runat="server" CssClass="input normal" datatype="" sucmsg=" "
                        ajaxurl=""></asp:TextBox>
                    <span class="Validform_checktip">*必填项</span>
                </dd>
            </dl>
            <dl>
                <dt>Signature</dt>
                <dd>
                    <asp:TextBox ID="txtSignature" runat="server" CssClass="input normal" datatype="" sucmsg=" "
                        ajaxurl=""></asp:TextBox>
                    <span class="Validform_checktip">*必填项</span>
                </dd>
            </dl>

            <dl>
                <dt>LastPostDateTime</dt>
                <dd>
                    <asp:TextBox ID="txtLastPostDateTime" runat="server" CssClass="input normal" datatype="" sucmsg=" "
                        ajaxurl=""></asp:TextBox>
                    <span class="Validform_checktip">*必填项</span>
                </dd>
            </dl>

            <dl>
                <dt>LastActivity</dt>
                <dd>
                    <asp:TextBox ID="txtLastActivity" runat="server" CssClass="input normal" datatype="" sucmsg=" "
                        ajaxurl=""></asp:TextBox>
                    <span class="Validform_checktip">*必填项</span>
                </dd>
            </dl>
            <dl>
                <dt>TopicCount</dt>
                <dd>
                    <asp:TextBox ID="txtTopicCount" runat="server" CssClass="input normal" datatype="" sucmsg=" "
                        ajaxurl=""></asp:TextBox>
                    <span class="Validform_checktip">*必填项</span>
                </dd>
            </dl>
            <dl>
                <dt>PostCount</dt>
                <dd>
                    <asp:TextBox ID="txtPostCount" runat="server" CssClass="input normal" datatype="" sucmsg=" "
                        ajaxurl=""></asp:TextBox>
                    <span class="Validform_checktip">*必填项</span>
                </dd>
            </dl>
            <dl>
                <dt>PostDigestCount</dt>
                <dd>
                    <asp:TextBox ID="txtPostDigestCount" runat="server" CssClass="input normal" datatype="" sucmsg=" "
                        ajaxurl=""></asp:TextBox>
                    <span class="Validform_checktip">*必填项</span>
                </dd>
            </dl>

            <dl>
                <dt>OnlineTime</dt>
                <dd>
                    <asp:TextBox ID="txtOnlineTime" runat="server" CssClass="input normal" datatype="" sucmsg=" "
                        ajaxurl=""></asp:TextBox>
                    <span class="Validform_checktip">*必填项</span>
                </dd>
            </dl>
            <dl>
                <dt>OnlineUpdateTime</dt>
                <dd>
                    <asp:TextBox ID="txtOnlineUpdateTime" runat="server" CssClass="input normal" datatype="" sucmsg=" "
                        ajaxurl=""></asp:TextBox>
                    <span class="Validform_checktip">*必填项</span>
                </dd>
            </dl>
            <dl>
                <dt>Verify</dt>
                <dd>
                    <asp:TextBox ID="txtVerify" runat="server" CssClass="input normal" datatype="" sucmsg=" "
                        ajaxurl=""></asp:TextBox>
                    <span class="Validform_checktip">*必填项</span>
                </dd>
            </dl>
            <dl>
                <dt>Hometown</dt>
                <dd>
                    <asp:TextBox ID="txtHometown" runat="server" CssClass="input normal" datatype="" sucmsg=" "
                        ajaxurl=""></asp:TextBox>
                    <span class="Validform_checktip">*必填项</span>
                </dd>
            </dl>
            <dl>
                <dt>Nonlocal</dt>
                <dd>
                    <asp:TextBox ID="txtNonlocal" runat="server" CssClass="input normal" datatype="" sucmsg=" "
                        ajaxurl=""></asp:TextBox>
                    <span class="Validform_checktip">*必填项</span>
                </dd>
            </dl>
            <dl>
                <dt>Specialty</dt>
                <dd>
                    <asp:TextBox ID="txtSpecialty" runat="server" CssClass="input normal" datatype="" sucmsg=" "
                        ajaxurl=""></asp:TextBox>
                    <span class="Validform_checktip">*必填项</span>
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
