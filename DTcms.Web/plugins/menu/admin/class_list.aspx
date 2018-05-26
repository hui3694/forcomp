<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="class_list.aspx.cs" Inherits="DTcms.Web.Plugin.Menu.admin.class_list" %>
<%@ Import namespace="DTcms.Common" %>

<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>菜单橱窗类别管理</title>
<link href="../../../<%=siteConfig.webmanagepath %>/skin/default/style.css" rel="stylesheet" type="text/css" />
<link href="../../../css/pagination.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../../../scripts/jquery/jquery-1.11.2.min.js"></script>
<script type="text/javascript" src="../../../<%=siteConfig.webmanagepath %>/js/common.js"></script>
<script type="text/javascript">
    function MsgTip() {
        var content = '<div class="msgtips">'
                    + '<p>1、get_menu_list(int class_id, int parent_id)</p>'
                    + '<p>2、get_menu_list(int top, int class_id, int parent_id)</p>'
                    + '<p>3、get_menu_list(int top, int class_id, int parent_id, string _strWhere)</p>'
                    + '<p>4、get_menu_list(int top, int class_id, int parent_id, string _strWhere, string filedOrder)</p>'
                    +'<div class="n"><i>备注：</i>top为数量、class_id为类别ID,parent_id为父节点ID,_strWhere为自定义条件,filedOrder为自定义排序方法。</div>'
                    + '<h3>前端调用方法</h3>'
                    + '<textarea rows="5" cols="20" class="input" style="width:100%">'
                     + '<ul>\r\n'
                    + '&lt;%set DataTable MainMenu=get_plugin_method("DTcms.Web.Plugin.Menu", "menu", "get_menu_list", 1, 10)%&gt;\r\n'
                    + '&lt;%foreach(DataRow dr in MainMenu.Rows)%&gt;\r\n'
                    + '<li class="m">\r\n'
                    + '\t<span><a href="{dr[link_url]}" target="{dr[target]}" title="{dr[title]}">{dr[title]}</a></span>\r\n'
                    + '\t&lt;%set DataTable SubMenu=get_plugin_method("DTcms.Web.Plugin.Menu", "menu", "get_menu_list", 1, {strtoint({dr[id]})})%&gt;\r\n'
                    + '\t&lt;%if(SubMenu.Rows.Count>0)%&gt;\r\n'
                    + '\t\t<ul class="sub">\r\n'
                    + '\t\t\t&lt;%foreach(DataRow dr2 in SubMenu.Rows)%&gt;\r\n'
                    + '\t\t\t<li><a href="{dr2[link_url]}" target="{dr2[target]}" title="{dr2[title]}">{dr2[title]}</a></li>\r\n'
                    + '\t\t\t&lt;%/foreach%&gt;\r\n'
                    + '\t\t</ul>\r\n'
                    + '\t&lt;%/if%&gt;\r\n'
          	        + '</li>\r\n'
                    + '&lt;%/foreach%&gt;\r\n'
                    + '</ul></textarea>'
                    + '</div>';
        top.dialog({
            title: "调用方法",
            width: 800,
            content: content
        }).show();
    }
</script>
</head>
<body class="mainbody">
<form id="form1" runat="server">
<!--导航栏-->
<div class="location">
  <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页一页</span></a>
  <a href="../../../<%=siteConfig.webmanagepath %>/center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <span>插件管理</span>
  <i class="arrow"></i>
  <a href="menu_list.aspx">导航菜单</a>
  <i class="arrow"></i>
  <span>菜单类别</span>
</div>
<!--/导航栏-->

<!--工具栏-->
<div id="floatHead" class="toolbar-wrap">
  <div class="toolbar">
    <div class="box-wrap">
      <a class="menu-btn"></a>
      <div class="l-list">
        <ul class="icon-list">
          <li><a class="add" href="class_edit.aspx?action=<%=DTEnums.ActionEnum.Add %>&backurl=<%=DTRequest.GetUrlParameter() %>"><i></i><span>新增</span></a></li>
          <li runat="server" id="savePannel"><asp:LinkButton ID="btnSave" runat="server" CssClass="save" onclick="btnSave_Click"><i></i><span>保存</span></asp:LinkButton></li>
          <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
          <li runat="server" id="delPannel"><asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete','删除后无法恢复，是否继续？');" onclick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
          <li><a class="list" href="javascript:;" onclick="MsgTip();"><i></i><span>调用方法</span></a></li>
        </ul>
      </div>
      <div class="r-list">
        <asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" AutoPostBack="True" ontextchanged="btnSearch_Click" />
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
      <th width="6%" align="center">选择</th>
      <th width="6%" align="left">ID</th>
      <th align="left">名称</th>
      <th width="8%" align="left">颜色</th>
      <th width="8%" align="center">状态</th>
      <th width="10%" align="center">集成</th>
      <th width="12%" align="center">排序</th>
      <th width="10%" align="center">操作</th>
    </tr>
  </HeaderTemplate>
  <ItemTemplate>
    <tr>
      <td align="center">
        <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" style="vertical-align:middle;" Enabled='<%#bool.Parse((Convert.ToInt32(Eval("is_sys"))==0 ).ToString())%>' />
        <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
      </td>
      <td align="left"><%#Eval("id")%></td>
      <td align="left"><%#Eval("title")%></a></td>
      <td align="left"><%#Eval("color")%></td>
      <td align="center"><%# Convert.ToInt32(Eval("is_lock")) == 0 ? "√" : "×"%></td>
      <td align="center"><%# Convert.ToInt32(Eval("is_sys")) == 1 ? "√" : "×"%></td>
      <td align="center"><asp:TextBox ID="txtSortId" runat="server" Text='<%#Eval("sort_id")%>' CssClass="sort" onkeydown="return checkNumber(event);" /></td>
      <td align="center">
          <a href="class_edit.aspx?action=<%#DTEnums.ActionEnum.Edit %>&id=<%#Eval("id")%>&backurl=<%=DTRequest.GetUrlParameter() %>">修改</a>
      </td>
    </tr>
  </ItemTemplate>
  <FooterTemplate>
    <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"7\">暂无记录</td></tr>" : ""%>
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