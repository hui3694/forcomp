<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="board_action_point_list.aspx.cs" Inherits="DTcms.Web.Plugin.Forum.admin.board_action_point_list" ValidateRequest="false" %>

<%@ Import Namespace="DTcms.Common" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>dt_Forum_BoardActionPoint列表</title>
    <link href="../../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="../../../<%=siteConfig.webmanagepath %>/skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../../../css/pagination.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" charset="utf-8" src="../../../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../../scripts/artdialog/dialog-plus-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../../<%=siteConfig.webmanagepath %>/js/laymain.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../../<%=siteConfig.webmanagepath %>/js/common.js"></script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <a href="../../../<%=siteConfig.webmanagepath %>/center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>插件管理</span>
            <i class="arrow"></i>
            <span>论坛管理</span>
            <i class="arrow"></i>
            <span>金币设置</span>
        </div>

        <!--/导航栏-->
        <!--工具栏-->
        <div id="floatHead" class="toolbar-wrap">
            <div class="toolbar" style="<%=board_id==0?"display:none;": "" %>">
                <div class="box-wrap">
                    <a class="menu-btn"></a>
                    <div class="l-list">
                        <ul class="icon-list">
                            <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                            <li style="line-height: 32px;"><span style="color: #f33b1a; margin-left: 15px; line-height: 26px; font-size: 12px;">* 当不启用时，相当于金币值为 0 </span></li>
                        </ul>
                    </div>
                </div>
            </div>

            <div style="<%=board_id==0?"": "display:none;" %>border:1px dotted #FF6600; padding: 6px 0px;">
                <ul>
                    <li><span style="color: #f33b1a; margin-left: 15px; line-height: 26px; font-size: 12px;">* 新版块都采用当前金币配额，当然你可移步至版块管理中对应独立调整 </span></li>
                </ul>
            </div>

        </div>
        <!--/工具栏-->

        <!--列表-->
        <div class="table-container">
            <asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound">
                <HeaderTemplate>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                        <tr>
                            <th width="8%" style="<%=board_id==0?"display:none;": "" %>">启用</th>
                            <th align="left" width="12%" style="padding-left: 15px;">动作</th>
                            <th align="left" width="12%">版块</th>
                            <th align="left">金币</th>

                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    
                    <tr style="<%#((KeyValuePair<int, string>)Container.DataItem).Key==7?"display:none;":""%><%#((KeyValuePair<int, string>)Container.DataItem).Key==8?"display:none;":""%>">
                        <td align="center" style="<%=board_id==0?"display:none;": "" %>">
                            <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                            <asp:HiddenField ID="hidId" Value='<%#((KeyValuePair<int, string>)Container.DataItem).Key%>' runat="server" />
                        </td>
                        <td style="padding-left: 15px;"><%#((KeyValuePair<int, string>)Container.DataItem).Value%></td>
                        <td><%#board_name%></td>
                        <td>
                            <asp:TextBox ID="txtPoint" runat="server" CssClass="input small" datatype="n"></asp:TextBox>
                        </td>

                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\""+(board_id==0?"3":"4")+"\">暂无记录</td></tr>" : ""%>
  </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <!--/列表-->


        <div style="margin-top: 10px;<%=board_id!=0?"display:none;": "" %>">

            <dl>
                <dt></dt>
                <dd>
                    <div class="rule-single-select">

                        <asp:DropDownList ID="ddlSYN" runat="server" AutoPostBack="False">
                            <asp:ListItem Text="同步" Value="1"></asp:ListItem>
                            <asp:ListItem Text="不同步" Selected="True" Value="0"></asp:ListItem>
                        </asp:DropDownList>

                    </div>
                    <span class="Validform_checktip">*所有版块都采用此配额。</span></dd>
            </dl>

        </div>

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
