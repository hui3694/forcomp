<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="user_list.aspx.cs" Inherits="DTcms.Web.admin.user.user_list" %>
<%@ Import namespace="DTcms.Common" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>内容管理</title>
<link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<link href="../../css/pagination.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
<script type="text/javascript" src="../../scripts/jquery/jquery.lazyload.min.js"></script>
<script type="text/javascript" src="../../scripts/artdialog/dialog-plus-min.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
    <style>
        .ltable td font{
            display:inline-block;
            line-height:64px;
            vertical-align:bottom;
        }
    </style>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
    <!--导航栏-->
        <div class="location">
          <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
          <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
          <i class="arrow"></i>
          <span>用户列表</span>
        </div>
        <!--/导航栏-->

        <!--工具栏-->
        <div id="floatHead" class="toolbar-wrap">
          <div class="toolbar">
            <div class="box-wrap">
              <a class="menu-btn"></a>
              <div class="l-list">
                <ul class="icon-list">
                  <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                  <li runat="server" id="delBtnPannel"><asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete','是否确定删除产品？');" onclick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
                </ul>
              </div>
                <div class="r-list">
                <asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" />
                <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" onclick="btnSearch_Click">查询</asp:LinkButton>
              </div>
            </div>
          </div>
        </div>
        <!--/工具栏-->


        <!--列表-->
        <div class="table-container">
          <asp:Repeater ID="rptList" runat="server">
          <HeaderTemplate>
          <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
            <tr>
              <th width="5%">选择</th>
              <th align="left" width="5%">编号</th>
              <th align="left" width="">用户</th>
              <th align="left" width="10%">手机号</th>
              <th align="left" width="10%">邮箱</th>
              <th align="left" width="5%">余额</th>
              <th align="left" width="5%">状态</th>
              <th align="left" width="15%">上次登录时间</th>
              <th align="left" width="15%">注册时间</th>
              <th width="10%">操作</th>
            </tr>
          </HeaderTemplate>
          <ItemTemplate>
            <tr>
              <td align="center">
                <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" style="vertical-align:middle;" />
                <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
              </td>
              <td><%#Eval("id")%></td>
              <td>
                  <a href="user_edit.aspx?id=<%#Eval("id") %>">
                      <image src="<%#Eval("avatar") %>" width="64" height="64" />
                      <font><%#Eval("nickname") %></font>
                    </a>
              </td>
              <td><%#Eval("phone") %></td>
              <td><%#Eval("email") %></td>
              <td><%#Eval("amount") %></td>
              <td><%#GetStatus(Convert.ToInt32(Eval("status"))) %></td>
              <td><%#Eval("login_time")==DBNull.Value?"":Convert.ToDateTime(Eval("login_time")).ToString("yyyy-MM-dd HH:mm:ss") %></td>
                <td><%#Eval("reg_time")==DBNull.Value?"":Convert.ToDateTime(Eval("reg_time")).ToString("yyyy-MM-dd HH:mm:ss") %></td>
              <td align="center">
                <a href="user_edit.aspx?action=<%#DTEnums.ActionEnum.Edit %>&id=<%#Eval("id")%>">修改</a>
              </td>
            </tr>
          </ItemTemplate>
          <FooterTemplate>
            <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"10\">暂无记录</td></tr>" : ""%>
          </table>
          </FooterTemplate>
          </asp:Repeater>
        </div>
        <!--/列表-->

        <!--内容底部-->
        <div class="line20"></div>
        <div class="pagelist">
          <div class="l-btns">
            <span>显示</span><asp:TextBox ID="txtPageNum" runat="server" CssClass="pagenum" onkeydown="return checkNumber(event);"
                        OnTextChanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox><span>条/页</span>
          </div>
          <div id="PageContent" runat="server" class="default"></div>
        </div>
        <!--/内容底部-->

    </form>
</body>
</html>
