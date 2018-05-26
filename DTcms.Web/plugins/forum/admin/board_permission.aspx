<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="board_permission.aspx.cs" Inherits="DTcms.Web.Plugin.Forum.admin.board_permission" ValidateRequest="false" %>
<%@ Import namespace="DTcms.Common" %>

<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>dt_Forum_BoardPermission列表</title>
<link href="../../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
<link href="../../../<%=siteConfig.webmanagepath %>/skin/default/style.css" rel="stylesheet" type="text/css" />
<link href="../../../css/pagination.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" charset="utf-8" src="../../../scripts/jquery/jquery-1.11.2.min.js"></script>
<script type="text/javascript" charset="utf-8" src="../../../scripts/artdialog/dialog-plus-min.js"></script>
<script type="text/javascript" charset="utf-8" src="../../../<%=siteConfig.webmanagepath %>/js/laymain.js"></script>
<script type="text/javascript" charset="utf-8" src="../../../<%=siteConfig.webmanagepath %>/js/common.js"></script>
    <script type="text/javascript">

        function  ck(obj)
        {
            $(obj).each(function () {  
                $(this).prop("checked", !$(this).prop("checked"));  
            });        
        }

    </script>
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
  <span>论坛插件</span>
  <i class="arrow"></i>
  <span>版块权限</span>
</div>

<!--/导航栏-->
<!--工具栏-->
<div id="floatHead" class="toolbar-wrap">
  <div class="toolbar">
    <div class="box-wrap">
      <a class="menu-btn"></a>
      <div class="l-list">
        <ul class="icon-list">
          <li><span><b>【<%=board_name %>】</b>版块权限</span> <input type="hidden" name="board_id" value="<%=board_id %>" /> </li>
        </ul>
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
      <th width="8%">选择</th>
            <th align="left">编号</th>
            <th align="left">会员组</th>
        
            <th align="center">访问版块</th>
            <th align="center">访问主题</th>
            <th align="center">发主题</th>
            <th align="center">发回复</th>
            <th align="center">上传附件</th>
            <th align="center">下载附件</th>
            <th align="center">编辑自己主题</th>
            <th align="center">编辑自己回复</th>
            <th align="center">删除自己主题</th>
            <th align="center">删除自己回复</th>
    </tr>
  </HeaderTemplate>
  <ItemTemplate>
    <tr>
      <td align="center">  

          <input type="checkbox" style="vertical-align:middle;" onclick="ck('.ck<%#Eval("id")%>')" />
          
      </td>
            <td><%# Eval("Id") %> </td>
            <td><%# Eval("Name") %></td>
      
        
            <td align="center"> <input class="ck<%#Eval("id")%>" <%#CheckChoose(Eval("id").ToString(),"VisitBoard") %> type="checkbox" value="1" name="VisitBoard_<%#Eval("id")%>" /></td>
            <td align="center"> <input class="ck<%#Eval("id")%>" <%#CheckChoose(Eval("id").ToString(),"VisitTopic") %> type="checkbox" value="1" name="VisitTopic_<%#Eval("id")%>" /></td>
   
            <td align="center"> <input style="<%#Convert.ToInt32(Eval("id"))==0?"display:none;":"" %>" class="ck<%#Eval("id")%>" <%#CheckChoose(Eval("id").ToString(),"PostTopic") %> type="checkbox" value="1" name="PostTopic_<%#Eval("id")%>" /></td>
            <td align="center"> <input style="<%#Convert.ToInt32(Eval("id"))==0?"display:none;":"" %>" class="ck<%#Eval("id")%>" <%#CheckChoose(Eval("id").ToString(),"PostReply") %> type="checkbox" value="1" name="PostReply_<%#Eval("id")%>" /></td>
            <td align="center"> <input style="<%#Convert.ToInt32(Eval("id"))==0?"display:none;":"" %>" class="ck<%#Eval("id")%>" <%#CheckChoose(Eval("id").ToString(),"UploadAttachment") %>  type="checkbox" value="1" name="UploadAttachment_<%#Eval("id")%>" /></td>
            <td align="center"> <input style="<%#Convert.ToInt32(Eval("id"))==0?"display:none;":"" %>" class="ck<%#Eval("id")%>" <%#CheckChoose(Eval("id").ToString(),"ViewAttachment") %> type="checkbox" value="1" name="ViewAttachment_<%#Eval("id")%>" /></td>
            <td align="center"> <input style="<%#Convert.ToInt32(Eval("id"))==0?"display:none;":"" %>" class="ck<%#Eval("id")%>" <%#CheckChoose(Eval("id").ToString(),"UpdateMyselfTopic") %> type="checkbox" value="1" name="UpdateMyselfTopic_<%#Eval("id")%>" /></td>
            <td align="center"> <input style="<%#Convert.ToInt32(Eval("id"))==0?"display:none;":"" %>" class="ck<%#Eval("id")%>" <%#CheckChoose(Eval("id").ToString(),"UpdateMyselfReply") %> type="checkbox" value="1" name="UpdateMyselfReply_<%#Eval("id")%>" /></td>
            <td align="center"> <input style="<%#Convert.ToInt32(Eval("id"))==0?"display:none;":"" %>" class="ck<%#Eval("id")%>" <%#CheckChoose(Eval("id").ToString(),"DeleteMyselfTopic") %> type="checkbox" value="1" name="DeleteMyselfTopic_<%#Eval("id")%>" /></td>
            <td align="center"> <input style="<%#Convert.ToInt32(Eval("id"))==0?"display:none;":"" %>" class="ck<%#Eval("id")%>" <%#CheckChoose(Eval("id").ToString(),"DeleteMyselfReply") %> type="checkbox" value="1" name="DeleteMyselfReply_<%#Eval("id")%>" /> </td>            
    </tr>
  </ItemTemplate>
  <FooterTemplate>
    <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"12\">暂无记录</td></tr>" : ""%>
  </table>
  </FooterTemplate>
  </asp:Repeater>
</div>
<!--/列表-->

<!--内容底部-->
<!--工具栏-->
<div class="page-footer">
  <div class="btn-wrap">
    <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" onclick="btnSubmit_Click" />
    <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
  </div>
</div>
<!--/工具栏-->
<!--/内容底部-->
</form>
</body>
</html>