<%@ Page Language="C#" AutoEventWireup="true" Inherits="DTcms.Web.Plugin.Forum.Page.board" ValidateRequest="false" %>
<%@ Import namespace="System.Collections.Generic" %>
<%@ Import namespace="System.Text" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="DTcms.Common" %>
<script runat="server">
override protected void OnInit(EventArgs e)
{
	base.OnInit(e);
	StringBuilder templateBuilder = new StringBuilder(220000);
	
	templateBuilder.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\" >\r\n<head>\r\n<meta http-equiv=\"Content-Type\" content=\"text/html;charset=utf-8\" />\r\n<title>");
	templateBuilder.Append(Utils.ObjectToStr(modelBoard.Name));
	templateBuilder.Append(" - ");
	templateBuilder.Append(Utils.ObjectToStr(site.name));
	templateBuilder.Append("</title>\r\n<meta name=\"keywords\" content=\"");
	templateBuilder.Append(Utils.ObjectToStr(site.seo_keyword));
	templateBuilder.Append("\" />\r\n<meta name=\"description\" content=\"");
	templateBuilder.Append(Utils.ObjectToStr(site.seo_description));
	templateBuilder.Append("\" />\r\n<meta name=\"generator\" content=\"dtcms forum\" />\r\n<meta name=\"author\" content=\"DTcms\" />\r\n<meta name=\"copyright\" content=\"dtcms-forum.net\" />\r\n<meta name=\"MSSmartTagsPreventParsing\" content=\"True\" />\r\n<meta http-equiv=\"MSThemeCompatible\" content=\"Yes\" />\r\n<!--<link rel=\"shortcut icon\" href=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("plugins/forum/templet/Default/images/favicon.ico\" />\r\n<link rel=\"icon\" type=\"image/ico\" href=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("plugins/forum/templet/Default/images/favicon.ico\" />-->\r\n<link rel=\"stylesheet\" type=\"text/css\" media=\"all\" href=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("plugins/forum/templet/Default/Styles/Common.css\" />\r\n<link rel=\"stylesheet\" type=\"text/css\" media=\"all\" href=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("plugins/forum/templet/Default/Styles/Base.css\" />\r\n<link rel=\"stylesheet\" type=\"text/css\" media=\"all\" href=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("plugins/forum/templet/Default/Styles/Stylesheet.css\" />\r\n<link href=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("plugins/forum/templet/Default/scripts/scrollup/css/themes/image.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n<link rel=\"stylesheet\" type=\"text/css\" media=\"all\" href=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("plugins/forum/templet/Default/scripts/jquery.ex/jquery.ex.css\" />\r\n<script src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("plugins/forum/templet/Default/scripts/jquery.js\" type=\"text/javascript\"></");
	templateBuilder.Append("script>\r\n<script src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("plugins/forum/templet/Default/scripts/jquery.ex/jquery.ex.js\" type=\"text/javascript\"></");
	templateBuilder.Append("script>\r\n<script src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("plugins/forum/templet/Default/scripts/jquery.cookie.js\" type=\"text/javascript\"></");
	templateBuilder.Append("script>\r\n<script src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("plugins/forum/templet/Default/scripts/scrollup/js/jquery.scrollup.js\" type=\"text/javascript\"></");
	templateBuilder.Append("script>\r\n</head>\r\n<body>\r\n<!--页面头部-->\r\n");

	templateBuilder.Append("\r\n<div class=\"wrap\">\r\n<link rel=\"stylesheet\" type=\"text/css\" media=\"all\" href=\"/plugins/forum/Static/AttachmentMsg/Main.css\" />\r\n<div> </div>\r\n<div class=\"header clearfix\">\r\n<div class=\"header_logo\">\r\n<h1><a href=\"/index.aspx\">论坛</a></h1>\r\n</div>\r\n<div class=\"header_user clearfix\">\r\n<div class=\"header_user_nav\">\r\n");
	if (modelUserExtended==null)
	{

	templateBuilder.Append("\r\n<div class=\"header_user_nav_line\"> <a href=\"");
	templateBuilder.Append(linkurl("login"));

	templateBuilder.Append("\">登录</a> <span class=\"pipe\">|</span> <a href=\"");
	templateBuilder.Append(linkurl("register"));

	templateBuilder.Append("\">注册</a> </div>\r\n<div class=\"header_user_nav_line\"> <a href=\"");
	templateBuilder.Append(linkurl("repassword"));

	templateBuilder.Append("\">找回密码</a> </div>\r\n");
	}
	else
	{

	templateBuilder.Append("\r\n<div class=\"header_user_nav_line\">\r\n<cite>\r\n<a href=\"#\">\r\n");
	templateBuilder.Append(Utils.ObjectToStr(modelUserExtended.Nickname));
	templateBuilder.Append("\r\n</a>\r\n</cite>\r\n<span class=\"pipe\">|</span>\r\n<a href=\"");
	templateBuilder.Append(linkurl("usercenter","index"));

	templateBuilder.Append("\">会员中心</a>\r\n<span class=\"pipe\">|</span>\r\n<a href=\"");
	templateBuilder.Append(linkurl("usercenter","exit"));

	templateBuilder.Append("\" onclick=\"javascript:return window.confirm('确定要退出吗?');\">登出</a>\r\n</div>\r\n<div class=\"header_user_nav_line\">\r\n金币：");
	templateBuilder.Append(Convert.ToInt32(modelUserExtended.Credit).ToString());

	templateBuilder.Append("\r\n<span class=\"pipe\">|</span>\r\n用户组：\r\n");
	templateBuilder.Append(Utils.ObjectToStr(modelUserExtended.GroupName));
	templateBuilder.Append("\r\n</div>\r\n");
	}	//end for if

	templateBuilder.Append("\r\n</div>\r\n");
	if (modelUserExtended==null)
	{

	templateBuilder.Append("\r\n<div class=\"header_avatar\"> <img src=\"/plugins/forum/handler/avatar.ashx?uid=0&size=50\" onerror=\"this.onerror=null;this.src='/plugins/forum/templet/Default/Images/avatar_none_50.jpg'\" alt=\"游客\" title=\"游客\" /> </div>\r\n");
	}
	else
	{

	templateBuilder.Append("\r\n<div class=\"header_avatar\"> <img src=\"/plugins/forum/handler/avatar.ashx?uid=");
	templateBuilder.Append(Utils.ObjectToStr(modelUserExtended.UserId));
	templateBuilder.Append("&size=50\" onerror=\"this.onerror=null;this.src='/plugins/forum/templet/Default/Images/avatar_none_50.jpg'\" alt=\"");
	templateBuilder.Append(Utils.ObjectToStr(modelUserExtended.Nickname));
	templateBuilder.Append("\" title=\"");
	templateBuilder.Append(Utils.ObjectToStr(modelUserExtended.Nickname));
	templateBuilder.Append("\" /> </div>\r\n");
	}	//end for if

	templateBuilder.Append("\r\n</div>\r\n</div>\r\n<div class=\"menu sp clearfix\">\r\n<div class=\"fl\">&nbsp;</div>\r\n<div class=\"fr\">&nbsp;</div>\r\n<div class=\"menu_context\">\r\n<ul>\r\n<li><a href=\"/index.aspx\" target=\"_blank\" >首页</a></li>\r\n<li><a href=\"");
	templateBuilder.Append(linkurl("forum_index","index"));

	templateBuilder.Append("\" >论坛</a></li>\r\n</ul>\r\n</div>\r\n</div>\r\n<div class=\"menuex clearfix\">\r\n<div class=\"search\">\r\n<form method=\"get\" action=\"#\" target=\"_blank\">\r\n<input type=\"text\" name=\"keys\" id=\"SearchKeys\" autocomplete=\"off\" x-webkit-speech=\"\" speech=\"\" placeholder=\"请输入搜索内容\" />\r\n<button type=\"button\" onclick=\"search($('#SearchKeys').val(),'");
	templateBuilder.Append(linkurl("forum_search"));

	templateBuilder.Append("')\">搜索</button>\r\n</form>\r\n</div>\r\n<div class=\"hoskeywords clearfix\">\r\n<ul>\r\n<li class=\"pipe\">|</li>\r\n<li><strong>热搜：</strong></li>\r\n<li><a href=\"");
	templateBuilder.Append(linkurl("forum_search"));

	templateBuilder.Append("?keys=API\" target=\"_blank\">API</a></li>\r\n<li><a href=\"");
	templateBuilder.Append(linkurl("forum_search"));

	templateBuilder.Append("?keys=Notify\" target=\"_blank\">Notify</a></li>\r\n<li><a href=\"");
	templateBuilder.Append(linkurl("forum_search"));

	templateBuilder.Append("?keys=.NET\" target=\"_blank\">.net</a></li>\r\n<li><a href=\"");
	templateBuilder.Append(linkurl("forum_search"));

	templateBuilder.Append("?keys=SQL\" target=\"_blank\">SQL</a></li>\r\n</ul>\r\n</div>\r\n</div>\r\n");
	if (Request.Url.ToString().ToLower().IndexOf("index.")==-1)
	{

	templateBuilder.Append("\r\n<style>.topic_list_panel .author{width:160px; }</style>\r\n<div class=\"location\">\r\n");
	templateBuilder.Append(get_location(board_id).ToString());

	templateBuilder.Append("\r\n</div>\r\n");
	}	//end for if

	templateBuilder.Append("\r\n<noscript>\r\n<div class=\"ginfo sp\" style=\"display: block; text-align: center;\"> 本站由于需要 Javascript 才能正常运行。建议您开启 Javascript 支持或使用有 Javascript 支持的浏览器。 </div>\r\n</noscript>\r\n</div>");


	templateBuilder.Append("\r\n<!--/页面头部-->\r\n<div class=\"wrap\">\r\n<div class=\"box_panel box_panel__color_easy sp board_rule_panel\">\r\n<div class=\"board_rule_panel_title clearfix\">\r\n<div class=\"fl\">\r\n<ul class=\"clearfix\">\r\n<li>\r\n<h2>");
	templateBuilder.Append(Utils.ObjectToStr(modelBoard.Name));
	templateBuilder.Append("</h2>\r\n</li>\r\n<li class=\"board_rule_panel_count\"> 今日：<strong>");
	templateBuilder.Append(Utils.ObjectToStr(modelBoard.TodayTopicCount));
	templateBuilder.Append("</strong> <samp>|</samp> 主题：<cite>");
	templateBuilder.Append(Utils.ObjectToStr(modelBoard.TopicCount));
	templateBuilder.Append("</cite> <samp>|</samp> 回复：<cite>");
	templateBuilder.Append(Utils.ObjectToStr(modelBoard.PostCount));
	templateBuilder.Append("</cite> </li>\r\n</ul>\r\n</div>\r\n<div class=\"fr\" style=\"display:none;\">\r\n<ul class=\"clearfix\">\r\n<li class=\"board_rule_panel_favorite\"><a href=\"#\">收藏本版</a></li>\r\n<li class=\"board_rule_panel_rss\"><a href=\"#\">RSS</a></li>\r\n</ul>\r\n</div>\r\n</div>\r\n<div class=\"sp\">\r\n<p>");
	templateBuilder.Append(Utils.ObjectToStr(modelBoard.Description));
	templateBuilder.Append("</p>\r\n</div>\r\n");
	if (drModeratorList.Length!=0)
	{

	templateBuilder.Append("\r\n<div class=\"sp master\"> 版主:\r\n");
	foreach(DataRow dr in drModeratorList)
	{

	templateBuilder.Append("\r\n<img src=\"/plugins/forum/handler/avatar.ashx?uid=" + Utils.ObjectToStr(dr["UserId"]) + "&size=50\" onerror=\"this.onerror=null;this.src='/plugins/forum/templet/Default/Images/avatar_none_50.jpg'\" alt=\"" + Utils.ObjectToStr(dr["Nickname"]) + "\" title=\"" + Utils.ObjectToStr(dr["Nickname"]) + "\" /> <a href=\"#" + Utils.ObjectToStr(dr["UserId"]) + "\">" + Utils.ObjectToStr(dr["Nickname"]) + "</a>\r\n");
	}	//end for if

	templateBuilder.Append("\r\n</div>\r\n");
	}	//end for if

	templateBuilder.Append("\r\n<div class=\"sp board_rule_panel_message\"> ");
	templateBuilder.Append(Utils.ObjectToStr(modelBoard.Rule));
	templateBuilder.Append(" </div>\r\n</div>\r\n");
	DataTable dtBoardList = get_board_list(board_id);

	System.Data.DataRow[] drBoardList = dtBoardList.Select("ClassLayer="+(modelBoard.ClassLayer+1).ToString(), "SortId asc");
	

	if (modelBoard.ChildCount!=0)
	{

	templateBuilder.Append("\r\n<div class=\"box_panel list_panel sp board_panel\">\r\n<div class=\"box_panel_title\"> ");
	templateBuilder.Append(Utils.ObjectToStr(modelBoard.Name));
	templateBuilder.Append(" 子版块 </div>\r\n<div class=\"box_panel_context\" >\r\n<div class=\"list_panel_cut\">\r\n");
	if (modelBoard.ChildCount!=0&&modelBoard.ChildCol<2)
	{

	templateBuilder.Append("\r\n<!--普通版-->\r\n<table>\r\n<thead>\r\n<tr>\r\n<td class=\"board\">标题</td>\r\n<td class=\"topic_reply\"> 主题\r\n/\r\n帖子 </td>\r\n<td class=\"last\">最后发表</td>\r\n</tr>\r\n</thead>\r\n<tbody>\r\n");
	foreach(DataRow drSub in drBoardList)
	{

	templateBuilder.Append("\r\n<tr>\r\n<td class=\"board\"><div class=\"single_board clearfix\">\r\n<div class=\"icon\"> <a href=\"");
	templateBuilder.Append(linkurl("forum_board",Utils.ObjectToStr(drSub["id"])));

	templateBuilder.Append("\"> <img src=\"");
	templateBuilder.Append(string.IsNullOrEmpty(drSub["Icon"].ToString())?"/plugins/forum/templet/Default/Images/board_state_standard.gif":drSub["Icon"].ToString().ToString());

	templateBuilder.Append("\" alt=\"" + Utils.ObjectToStr(drSub["Name"]) + "\" /> </a> </div>\r\n<div class=\"sbc clearfix\"> <strong> <a href=\"");
	templateBuilder.Append(linkurl("forum_board",Utils.ObjectToStr(drSub["id"])));

	templateBuilder.Append("\">" + Utils.ObjectToStr(drSub["Name"]) + "</a> </strong>\r\n<div class=\"description\">\r\n<p>" + Utils.ObjectToStr(drSub["Description"]) + "</p>\r\n</div>\r\n</div>\r\n</div></td>\r\n<td class=\"topic_reply\"> " + Utils.ObjectToStr(drSub["TopicCount"]) + "\r\n/ <i>" + Utils.ObjectToStr(drSub["PostCount"]) + "</i> </td>\r\n<td class=\"last\">");
	if (Utils.StrToInt(Utils.ObjectToStr(drSub["LastTopicId"]), 0)!=0)
	{

	templateBuilder.Append("\r\n<ul>\r\n<li> <a href=\"");
	templateBuilder.Append(linkurl("forum_topic",Utils.ObjectToStr(drSub["LastTopicId"]),1));

	templateBuilder.Append("\" title=\"" + Utils.ObjectToStr(drSub["LastTopicTitle"]) + "\">" + Utils.ObjectToStr(drSub["LastTopicTitle"]) + "</a> </li>\r\n<li>By: <a href=\"#\">" + Utils.ObjectToStr(drSub["LastPostNickname"]) + "</a> , <a href=\"");
	templateBuilder.Append(linkurl("forum_topic",Utils.ObjectToStr(drSub["LastTopicId"]),1));

	templateBuilder.Append("\" title=\"" + Utils.ObjectToStr(drSub["LastTopicTitle"]) + " By:" + Utils.ObjectToStr(drSub["LastPostNickname"]) + "\"> <span title=\"" + Utils.ObjectToStr(drSub["UpdateTime"]) + "\">" + Utils.ObjectToStr(drSub["UpdateTime"]) + "</span> </a> </li>\r\n</ul>\r\n");
	}
	else
	{

	templateBuilder.Append("\r\n-\r\n");
	}	//end for if

	templateBuilder.Append("\r\n</td>\r\n</tr>\r\n");
	}	//end for if

	templateBuilder.Append("\r\n</tbody>\r\n</table>\r\n");
	}
	else if (modelBoard.ChildCount!=0&&modelBoard.ChildCol>1)
	{

	templateBuilder.Append("\r\n<!--小版块-->\r\n<table>\r\n<tbody>\r\n");
	int l = Convert.ToInt32(Math.Ceiling(Convert.ToDouble( modelBoard.ChildCount / modelBoard.ChildCol)));
	string ids = "0";
	string width =( 100 / modelBoard.ChildCol).ToString();
	

	for(int i=0;i<=l;i++)
	{

	System.Data.DataRow[] drSubList = dtBoardList.Select("id not in (" + ids + ") ", "SortId asc");
	

	templateBuilder.Append("\r\n<tr class=\"info\">\r\n");
	int s = 0;

	int r = 0;

	foreach(DataRow drSub in drSubList)
	{

	templateBuilder.Append("\r\n<td style=\"width:");
	templateBuilder.Append(width.ToString());

	templateBuilder.Append("%;\" class=\"info board\"><div class=\"single_board clearfix\">\r\n<div class=\"icon\"> <a href=\"");
	templateBuilder.Append(linkurl("forum_board",Utils.ObjectToStr(drSub["id"])));

	templateBuilder.Append("\"> <img src=\"");
	templateBuilder.Append(string.IsNullOrEmpty(drSub["Icon"].ToString())?"/plugins/forum/templet/Default/Images/board_state_standard.gif":drSub["Icon"].ToString().ToString());

	templateBuilder.Append("\" alt=\"" + Utils.ObjectToStr(drSub["Name"]) + "\" /> </a> </div>\r\n<div class=\"sbc clearfix\"> <strong> <a href=\"");
	templateBuilder.Append(linkurl("forum_board",Utils.ObjectToStr(drSub["id"])));

	templateBuilder.Append("\">" + Utils.ObjectToStr(drSub["Name"]) + "</a> </strong>\r\n<p> 主题:" + Utils.ObjectToStr(drSub["TopicCount"]) + ",帖子:" + Utils.ObjectToStr(drSub["PostCount"]) + " </p>\r\n");
	if (Utils.StrToInt(Utils.ObjectToStr(drSub["LastTopicId"]), 0)!=0)
	{

	templateBuilder.Append("\r\n<p> 最后发表: <a href=\"");
	templateBuilder.Append(linkurl("forum_topic",Utils.ObjectToStr(drSub["LastTopicId"]),1));

	templateBuilder.Append("\" title=\"" + Utils.ObjectToStr(drSub["LastTopicTitle"]) + " By:" + Utils.ObjectToStr(drSub["LastPostNickname"]) + "\"> " + Utils.ObjectToStr(drSub["UpdateTime"]) + " </a> </p>\r\n");
	}	//end for if

	templateBuilder.Append("\r\n</div>\r\n</div></td>\r\n");
	ids+=","+drSub["id"].ToString();
	s+=1;
	r=modelBoard.ChildCol-s;
	if(s==modelBoard.ChildCol)
	{
	break;
	}
	

	}	//end for if

	if (r!=0)
	{

	for(int y=0;y<=r-1;y++)
	{

	templateBuilder.Append("\r\n<td style=\"width:");
	templateBuilder.Append(width.ToString());

	templateBuilder.Append("%;\" class=\"info\">&nbsp;</td>\r\n");
	}	//end for if

	}	//end for if

	templateBuilder.Append("\r\n</tr>\r\n");
	}	//end for if

	templateBuilder.Append("\r\n</tbody>\r\n</table>\r\n");
	}	//end for if

	templateBuilder.Append("\r\n</div>\r\n</div>\r\n</div>\r\n");
	}	//end for if

	if (modelBoard.ChildCount==0)
	{

	templateBuilder.Append("\r\n<div class=\"sp clearfix\">\r\n<div class=\"button_panel fl\">\r\n<ul>\r\n");
	if (modelUserExtended!=null)
	{

	templateBuilder.Append("\r\n<li> <a href=\"");
	templateBuilder.Append(linkurl("forum_post","create",modelBoard.Id));

	templateBuilder.Append("\"><img src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("plugins/forum/templet/Default/images/post_button.png\" alt=\"发帖\" /></a> </li>\r\n");
	if (bolOperate)
	{

	templateBuilder.Append("\r\n<li class=\"mypop\" data-pop-id=\"manage_panel\"> <a href=\"javascript:void(0);\"><img src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("plugins/forum/templet/Default/images/manage_button.png\" alt=\"管理\" /></a> </li>\r\n");
	}	//end for if

	}
	else
	{

	templateBuilder.Append("\r\n<li> <span class=\"no_ct\"> 您所在分组(<strong>游客</strong>)无法在此版发表主题\r\n，您可以进行<a href=\"");
	templateBuilder.Append(linkurl("login"));

	templateBuilder.Append("\">登录</a>或<a href=\"");
	templateBuilder.Append(linkurl("register"));

	templateBuilder.Append("\">注册</a> </span></li>\r\n");
	}	//end for if

	templateBuilder.Append("\r\n</ul>\r\n</div>\r\n<div class=\"page_panel fr\">\r\n<ul class=\"fl\">\r\n");
	templateBuilder.Append(Utils.ObjectToStr(pagelist));
	templateBuilder.Append("\r\n</ul>\r\n</div>\r\n</div>\r\n<div class=\"box_panel sp topic_list_panel\">\r\n<div class=\"box_panel_title clearfix\">\r\n<div class=\"fl\"> ");
	templateBuilder.Append(Utils.ObjectToStr(modelBoard.Name));
	templateBuilder.Append(" </div>\r\n<ul class=\"fr\">\r\n</ul>\r\n</div>\r\n<div class=\"box_panel_context\">\r\n<form method=\"post\" name=\"moderate\" action=\"#\">\r\n");
	if (bolOperate)
	{

	templateBuilder.Append("\r\n<input name=\"board_id\" type=\"hidden\" value=\"");
	templateBuilder.Append(board_id.ToString());

	templateBuilder.Append("\" />\r\n<input name=\"turl\" type=\"hidden\" value=\"");
	templateBuilder.Append(Utils.ObjectToStr(turl));
	templateBuilder.Append("\" />\r\n<div id=\"manage_panel\" class=\"pop_panel manage_pop_panel\">\r\n<div class=\"content\">\r\n<h3>批量主题管理</h3>\r\n<ul>\r\n<li>\r\n<input id=\"topic_select_all\" type=\"checkbox\" class=\"select_all\" />\r\n<label for=\"topic_select_all\">全选</label>\r\n</li>\r\n</ul>\r\n<ul>\r\n<li><a href=\"");
	templateBuilder.Append(linkurl("forum_manage","top"));

	templateBuilder.Append("\" class=\"manage_action\">主题置顶/取消</a></li>\r\n<li><a href=\"");
	templateBuilder.Append(linkurl("forum_manage","digest"));

	templateBuilder.Append("\" class=\"manage_action\">精华设置/取消</a></li>\r\n<li><a href=\"");
	templateBuilder.Append(linkurl("forum_manage","close"));

	templateBuilder.Append("\" class=\"manage_action\">主题打开/关闭</a></li>\r\n<li><a href=\"");
	templateBuilder.Append(linkurl("forum_manage","highlight"));

	templateBuilder.Append("\" class=\"manage_action\">主题高亮</a></li>\r\n<li><a href=\"");
	templateBuilder.Append(linkurl("forum_manage","ban"));

	templateBuilder.Append("\" class=\"manage_action\">主题屏蔽</a></li>\r\n<li><a href=\"");
	templateBuilder.Append(linkurl("forum_manage","delete"));

	templateBuilder.Append("\" class=\"manage_action\">删除主题</a></li>\r\n<li><a href=\"");
	templateBuilder.Append(linkurl("forum_manage","move"));

	templateBuilder.Append("\" class=\"manage_action\">移动主题</a></li>\r\n<li><a href=\"");
	templateBuilder.Append(linkurl("forum_manage","type"));

	templateBuilder.Append("\" class=\"manage_action\" style=\"display:none;\">主题分类</a></li>\r\n</ul>\r\n<h3 style=\"display:none;\">版块综合管理</h3>\r\n<ul style=\"display:none;\">\r\n<li><a href=\"");
	templateBuilder.Append(linkurl("forum_manage","wtopics"));

	templateBuilder.Append("\">主题审核</a></li>\r\n<li><a href=\"");
	templateBuilder.Append(linkurl("forum_manage","wreplys"));

	templateBuilder.Append("\">回复审核</a></li>\r\n</ul>\r\n</div>\r\n</div>\r\n<div id=\"manageTopic\" class=\"box_panel box_panel__color_easy post_manage_panel\">\r\n<div class=\"box_panel_title clearfix\">\r\n<div class=\"fl\">选择了<span id=\"manageTopicCount\">0</span>个主题</div>\r\n<div class=\"fr\">\r\n<input id=\"flex_post_select_all\" type=\"checkbox\" class=\"select_all\" />\r\n<label for=\"flex_post_select_all\">全选</label>\r\n<span class=\"pipe\">|</span> <span class=\"select_all_cancel\">取消</span> </div>\r\n</div>\r\n<div class=\"box_panel_context\">\r\n<ul>\r\n<li><a href=\"");
	templateBuilder.Append(linkurl("forum_manage","top"));

	templateBuilder.Append("\" class=\"manage_action\">主题置顶/取消</a></li>\r\n<li><a href=\"");
	templateBuilder.Append(linkurl("forum_manage","digest"));

	templateBuilder.Append("\" class=\"manage_action\">精华设置/取消</a></li>\r\n<li><a href=\"");
	templateBuilder.Append(linkurl("forum_manage","close"));

	templateBuilder.Append("\" class=\"manage_action\">主题打开/关闭</a></li>\r\n<li><a href=\"");
	templateBuilder.Append(linkurl("forum_manage","highlight"));

	templateBuilder.Append("\" class=\"manage_action\">主题高亮</a></li>\r\n<li><a href=\"");
	templateBuilder.Append(linkurl("forum_manage","ban"));

	templateBuilder.Append("\" class=\"manage_action\">主题屏蔽</a></li>\r\n<li><a href=\"");
	templateBuilder.Append(linkurl("forum_manage","delete"));

	templateBuilder.Append("\" class=\"manage_action\">删除主题</a></li>\r\n<li><a href=\"");
	templateBuilder.Append(linkurl("forum_manage","move"));

	templateBuilder.Append("\" class=\"manage_action\">移动主题</a></li>\r\n<li><a href=\"");
	templateBuilder.Append(linkurl("forum_manage","type"));

	templateBuilder.Append("\" class=\"manage_action\" style=\"display:none;\">主题分类</a></li>\r\n</ul>\r\n</div>\r\n</div>\r\n");
	}	//end for if

	templateBuilder.Append("\r\n<div class=\"list_panel\">\r\n<table>\r\n<thead>\r\n<tr>\r\n<td colspan=\"2\" class=\"title\"> 标题 </td>\r\n<td class=\"author\">作者</td>\r\n<td class=\"nums\">回复/查看</td>\r\n<td class=\"last\">最后发表</td>\r\n</tr>\r\n</thead>\r\n<tbody>\r\n");
	foreach(DataRow dr in drTopList)
	{

	templateBuilder.Append("\r\n<tr>\r\n<td class=\"icon\"><a href=\"");
	templateBuilder.Append(linkurl("forum_topic",Utils.ObjectToStr(dr["id"]),1));

	templateBuilder.Append("\" target=\"_blank\"> <img src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("plugins/forum/templet/Default/images/topic_state_standard.gif\" title=\"普通帖\" alt=\"普通帖\" /> </a> </td>\r\n<td class=\"title clearfix\"><span class=\"topic_title\" > <a href=\"");
	templateBuilder.Append(linkurl("forum_topic",Utils.ObjectToStr(dr["id"]),1));

	templateBuilder.Append("\" title=\"" + Utils.ObjectToStr(dr["Title"]) + "\" style=\"");
	templateBuilder.Append(DTcms.Web.Plugin.Forum.Label.get_highLight_style(Utils.ObjectToStr(dr["HighLight"])).ToString());

	templateBuilder.Append("\"> " + Utils.ObjectToStr(dr["Title"]) + " </a> </span>\r\n");
	if (Utils.ObjectToStr(dr["Attachment"])!="0")
	{

	templateBuilder.Append("\r\n<span class=\"attachment_file\" title=\"附件\">[附件]</span>\r\n");
	}	//end for if

	if ((System.DateTime.Now-Convert.ToDateTime(Utils.ObjectToStr(dr["PostDatetime"]))).TotalHours<48)
	{

	templateBuilder.Append("\r\n<span class=\"topic_new\" title=\"新\">[新]</span>\r\n");
	}	//end for if

	if (Utils.ObjectToStr(dr["Digest"])!="0")
	{

	templateBuilder.Append("\r\n<span class=\"topic_digest\" title=\"精\">[精]</span>\r\n");
	}	//end for if

	if (Convert.ToInt32(Utils.ObjectToStr(dr["ReplayCount"]))>=50)
	{

	templateBuilder.Append("\r\n<span class=\"topic_hot\" title=\"火\">[火]</span>\r\n");
	}	//end for if

	if (Utils.ObjectToStr(dr["Close"])!="0")
	{

	templateBuilder.Append("\r\n<span class=\"topic_close\" title=\"闭\">[闭]</span>\r\n");
	}	//end for if

	templateBuilder.Append("\r\n</td>\r\n<td class=\"author\"><img src=\"/plugins/forum/handler/avatar.ashx?uid=" + Utils.ObjectToStr(dr["PostUserId"]) + "&size=50\" style=\"background-color: #fff;padding:2px;border: 1px solid #eee;margin: 2px 5px 0 0;width: 32px;height: 32px;float: left;\" />\r\n<div> <cite> <a href=\"#\"><span style=\"color:#0066ff;\">" + Utils.ObjectToStr(dr["PostNickname"]) + "</span></a> </cite> <em title=\"" + Utils.ObjectToStr(dr["PostDatetime"]) + "\"> " + Utils.ObjectToStr(dr["PostDatetime"]) + " </em> </div></td>\r\n<td class=\"nums\"><em>" + Utils.ObjectToStr(dr["ViewCount"]) + "</em> <em>" + Utils.ObjectToStr(dr["ReplayCount"]) + "</em> </td>\r\n<td class=\"last\"><cite> <a href=\"#" + Utils.ObjectToStr(dr["LastPostUserId"]) + "\"><span style=\"color:#0066ff;\">" + Utils.ObjectToStr(dr["LastPostNickname"]) + "</span></a> </cite> <em title=\"" + Utils.ObjectToStr(dr["LastPostDatetime"]) + "\"> <a href=\"");
	templateBuilder.Append(linkurl("forum_topic",Utils.ObjectToStr(dr["id"]),-1));

	templateBuilder.Append("\">" + Utils.ObjectToStr(dr["LastPostDatetime"]) + "</a> </em> </td>\r\n</tr>\r\n");
	}	//end for if

	templateBuilder.Append("\r\n</tbody>\r\n");
	if (drTopList.Length!=0)
	{

	templateBuilder.Append("\r\n<tbody class=\"sptitle\">\r\n<tr>\r\n<td colspan=\"5\">版块主题</td>\r\n</tr>\r\n</tbody>\r\n");
	}	//end for if

	templateBuilder.Append("\r\n<tbody>\r\n");
	foreach(DataRow dr in drTopicList)
	{

	templateBuilder.Append("\r\n<tr>\r\n<td class=\"icon\"><a href=\"");
	templateBuilder.Append(linkurl("forum_topic",Utils.ObjectToStr(dr["id"]),1));

	templateBuilder.Append("\" target=\"_blank\"> <img src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("plugins/forum/templet/Default/images/topic_state_standard.gif\" title=\"普通帖\" alt=\"普通帖\" /> </a> </td>\r\n<td class=\"title clearfix\">");
	if (bolOperate)
	{

	templateBuilder.Append("\r\n<input type=\"checkbox\" value=\"" + Utils.ObjectToStr(dr["id"]) + "\" name=\"tids\"/>\r\n");
	}	//end for if

	templateBuilder.Append("\r\n<span class=\"topic_title\"> <a href=\"");
	templateBuilder.Append(linkurl("forum_topic",Utils.ObjectToStr(dr["id"]),1));

	templateBuilder.Append("\" title=\"" + Utils.ObjectToStr(dr["Title"]) + "\" style=\"");
	templateBuilder.Append(DTcms.Web.Plugin.Forum.Label.get_highLight_style(Utils.ObjectToStr(dr["HighLight"])).ToString());

	templateBuilder.Append("\"> " + Utils.ObjectToStr(dr["Title"]) + " </a> </span>\r\n");
	if (Utils.ObjectToStr(dr["Attachment"])!="0")
	{

	templateBuilder.Append("\r\n<span class=\"attachment_file\" title=\"附件\">[附件]</span>\r\n");
	}	//end for if

	if ((System.DateTime.Now-Convert.ToDateTime(Utils.ObjectToStr(dr["PostDatetime"]))).TotalHours<48)
	{

	templateBuilder.Append("\r\n<span class=\"topic_new\" title=\"新\">[新]</span>\r\n");
	}	//end for if

	if (Utils.ObjectToStr(dr["Digest"])!="0")
	{

	templateBuilder.Append("\r\n<span class=\"topic_digest\" title=\"精\">[精]</span>\r\n");
	}	//end for if

	if (Convert.ToInt32(Utils.ObjectToStr(dr["ReplayCount"]))>=50)
	{

	templateBuilder.Append("\r\n<span class=\"topic_hot\" title=\"火\">[火]</span>\r\n");
	}	//end for if

	if (Utils.ObjectToStr(dr["Close"])!="0")
	{

	templateBuilder.Append("\r\n<span class=\"topic_close\" title=\"闭\">[闭]</span>\r\n");
	}	//end for if

	templateBuilder.Append("\r\n</td>\r\n<td class=\"author\"><img src=\"/plugins/forum/handler/avatar.ashx?uid=" + Utils.ObjectToStr(dr["PostUserId"]) + "&size=50\" style=\"background-color: #fff;padding:2px;border: 1px solid #eee;margin: 2px 5px 0 0;width: 32px;height: 32px;float: left;\" />\r\n<div> <cite> <a href=\"#\"><span style=\"color:#0066ff;\">" + Utils.ObjectToStr(dr["PostNickname"]) + "</span></a> </cite> <em title=\"" + Utils.ObjectToStr(dr["PostDatetime"]) + "\"> " + Utils.ObjectToStr(dr["PostDatetime"]) + " </em> </div></td>\r\n<td class=\"nums\"><em>" + Utils.ObjectToStr(dr["ViewCount"]) + "</em> <em>" + Utils.ObjectToStr(dr["ReplayCount"]) + "</em> </td>\r\n<td class=\"last\"><cite> <a href=\"#" + Utils.ObjectToStr(dr["LastPostUserId"]) + "\"><span style=\"color:#0066ff;\">" + Utils.ObjectToStr(dr["LastPostNickname"]) + "</span></a> </cite> <em title=\"" + Utils.ObjectToStr(dr["LastPostDatetime"]) + "\"> <a href=\"");
	templateBuilder.Append(linkurl("forum_topic",Utils.ObjectToStr(dr["id"]),-1));

	templateBuilder.Append("\">" + Utils.ObjectToStr(dr["LastPostDatetime"]) + "</a> </em> </td>\r\n</tr>\r\n");
	}	//end for if

	templateBuilder.Append("\r\n</tbody>\r\n</table>\r\n</div>\r\n</form>\r\n</div>\r\n</div>\r\n<div class=\"sp clearfix\">\r\n<div class=\"page_panel fr\">\r\n<ul class=\"fl\">\r\n");
	templateBuilder.Append(Utils.ObjectToStr(pagelist));
	templateBuilder.Append("\r\n</ul>\r\n</div>\r\n</div>\r\n");
	}	//end for if

	templateBuilder.Append("\r\n</div>\r\n<script src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("plugins/forum/templet/Default/scripts/common.js\" type=\"text/javascript\"></");
	templateBuilder.Append("script>\r\n<script src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("plugins/forum/templet/Default/scripts/Board.js\" type=\"text/javascript\"></");
	templateBuilder.Append("script>\r\n<!--页面底部-->\r\n");

	templateBuilder.Append("<div class=\"wrap\">\r\n<!--<div>\r\n</div>\r\n<div class=\"footer\">\r\n<div class=\"link\">\r\n<p>\r\n<a href=\"http://www.dtcms.net\" target=\"_blank\">DTcms 官方站</a>\r\n|\r\n<a href=\"http://www.dtcms-forum.net/\" target=\"_blank\">论坛源码</a>\r\n|\r\n<a href=\"http://www.dtcms-forum.net/\" target=\"_blank\">联系我们</a>\r\n|\r\n<a href=\"javascript:alert('仅支持群主拉入');\" target=\"_blank\">QQ交流群</a>\r\n</p>\r\n<p>\r\n<a href=\"/\">DTcms 论坛插件</a>\r\n|\r\n<a href=\"javascript:void(0);\" onclick=\"javascript:widthauto(this);\">切换到宽版</a>\r\n</p>\r\n</div>\r\n<p>\r\nPowered by <strong>DTcms Forum</strong> <em>1.0</em> (c) 2016-2025 <a href=\"http://www.DTcms-Forum.net/\" target=\"_blank\">dtcms-forum.net</a>\r\n</p>\r\n<p>Server time ");
	templateBuilder.Append(System.DateTime.Now.ToString().ToString());

	templateBuilder.Append("</p>\r\n</div>-->\r\n<script src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("plugins/forum/templet/Default/scripts/common.js\" type=\"text/javascript\"></");
	templateBuilder.Append("script>\r\n<script src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("plugins/forum/templet/Default/scripts/Board.js\" type=\"text/javascript\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\">\r\nvar CSSLOADED = [];\r\nfunction loadcss(cssname) {\r\nif (!CSSLOADED[cssname]) {\r\nif ($('#css_' + cssname).length <= 0) {\r\ncss = document.createElement('link');\r\ncss.id = 'css_' + cssname,\r\ncss.type = 'text/css';\r\ncss.rel = 'stylesheet';\r\ncss.href = '");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("plugins/forum/templet/Default/styles/' + cssname + '.css';\r\nvar headNode = document.getElementsByTagName(\"head\")[0];\r\nheadNode.appendChild(css);\r\n} else {\r\n$('#css_' + cssname).href = '");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("plugins/forum/templet/Default/styles/' + cssname + '.css';\r\n}\r\nCSSLOADED[cssname] = 1;\r\n}\r\n}\r\nfunction widthauto(obj) {\r\nif ($('#css_width_auto').length > 0) {\r\nCSSLOADED['width_auto'] = 1;\r\n}\r\nif (!CSSLOADED['width_auto'] || $('#css_width_auto').attr(\"disabled\")) {\r\nif (!CSSLOADED['width_auto']) {\r\nloadcss('width_auto');\r\n} else {\r\n$('#css_width_auto').removeAttr(\"disabled\");\r\n}\r\n//HTMLNODE.className += ' widthauto';\r\n$.cookie('DTcms_Forum_1_width_auto', 'true', { expires: 100, path: '/' });\r\nobj.innerHTML = '切换到窄版';\r\n} else {\r\n$('#css_width_auto').attr(\"disabled\", \"disabled\");\r\n//HTMLNODE.className = HTMLNODE.className.replace(' widthauto', '');\r\n$.cookie('DTcms_Forum_1_width_auto', 'false', { expires: 100, path: '/' });\r\nobj.innerHTML = '切换到宽版';\r\n}\r\n}\r\n$(function () {\r\n$.scrollUp({\r\nscrollName: 'scrollUp',\r\nscrollDistance: 300,\r\nscrollFrom: 'top',\r\nscrollSpeed: 300,\r\neasingType: 'linear',\r\nanimation: 'fade',\r\nanimationInSpeed: 200,\r\nanimationOutSpeed: 200,\r\nscrollText: '回到顶部',\r\nscrollTitle: false,\r\nscrollImg: true,\r\nactiveOverlay: false,\r\nzIndex: 2147483647\r\n});\r\n$(\"a[data-href]\").click(function () {\r\nvar url = $(this).data('href');\r\nif (window.confirm(\"您将要访问的网址不属于 DTcms 官方论坛 ，我们无法确认该网页是否安全。是否要继续访问？\"))\r\nwindow.open(url);\r\nreturn false;\r\n});\r\n});\r\n</");
	templateBuilder.Append("script>\r\n</div>");


	templateBuilder.Append("\r\n<!--/页面底部-->\r\n</body>\r\n</html>\r\n");
	Response.Write(templateBuilder.ToString());
}
</script>