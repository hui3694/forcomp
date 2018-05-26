<%@ Page Language="C#" AutoEventWireup="true" Inherits="DTcms.Web.Plugin.Forum.Page.manage" ValidateRequest="false" %>
<%@ Import namespace="System.Collections.Generic" %>
<%@ Import namespace="System.Text" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="DTcms.Common" %>
<script runat="server">
override protected void OnInit(EventArgs e)
{
	base.OnInit(e);
	StringBuilder templateBuilder = new StringBuilder(220000);
	
	templateBuilder.Append("<!DOCTYPE HTML>\r\n<html>\r\n<head>\r\n<meta http-equiv=\"Content-Type\" content=\"text/html;charset=utf-8\" />\r\n<title> 管理 - ");
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
	templateBuilder.Append("script>\r\n<link href=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("plugins/forum/templet/Default/scripts/easydialog/easydialog.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n</head>\r\n<body>\r\n<!--页面头部-->\r\n");

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


	templateBuilder.Append("\r\n<!--/页面头部-->\r\n<div class=\"wrap\">\r\n<div class=\"box_panel manage_panel\">\r\n<div class=\"box_panel_title\">\r\n");
	if (action=="top")
	{

	templateBuilder.Append("\r\n主题置顶\r\n");
	}
	else if (action=="digest")
	{

	templateBuilder.Append("\r\n精华设置\r\n");
	}
	else if (action=="close")
	{

	templateBuilder.Append("\r\n主题设置\r\n");
	}
	else if (action=="highlight")
	{

	templateBuilder.Append("\r\n主题高亮\r\n");
	}
	else if (action=="ban")
	{

	templateBuilder.Append("\r\n主题屏蔽\r\n");
	}
	else if (action=="delete")
	{

	templateBuilder.Append("\r\n删除主题\r\n");
	}
	else if (action=="move")
	{

	templateBuilder.Append("\r\n移动主题\r\n");
	}
	else if (action=="type")
	{

	templateBuilder.Append("\r\n主题分类\r\n");
	}
	else if (action=="banreply")
	{

	templateBuilder.Append("\r\n屏蔽回复\r\n");
	}
	else if (action=="deletereply")
	{

	templateBuilder.Append("\r\n删除回复\r\n");
	}	//end for if

	templateBuilder.Append("\r\n</div>\r\n<div class=\"box_panel_context form_panel_b\">\r\n<form id=\"post\" method=\"post\" action=\"#\">\r\n<input id=\"board_id\" name=\"board_id\" type=\"hidden\" value=\"");
	templateBuilder.Append(board_id.ToString());

	templateBuilder.Append("\" />\r\n<input id=\"topic_id\" name=\"topic_id\" type=\"hidden\" value=\"");
	templateBuilder.Append(topic_id.ToString());

	templateBuilder.Append("\" />\r\n<input id=\"post_id\" name=\"post_id\" type=\"hidden\" value=\"");
	templateBuilder.Append(post_id.ToString());

	templateBuilder.Append("\" />\r\n<input id=\"action\" name=\"action\" type=\"hidden\" value=\"");
	templateBuilder.Append(action.ToString());

	templateBuilder.Append("\" />\r\n<input id=\"turl\" name=\"turl\" type=\"hidden\" value=\"");
	templateBuilder.Append(Utils.ObjectToStr(turl));
	templateBuilder.Append("\" />\r\n<dl style=\"");
	templateBuilder.Append(action=="top"?"":"display:none;".ToString());

	templateBuilder.Append("\">\r\n<dt>\r\n置顶\r\n</dt>\r\n<dd>\r\n<input id=\"top0\" name=\"top\" type=\"radio\" value=\"0\" checked=\"checked\" />\r\n<label for=\"top0\">取消</label>\r\n<input id=\"top1\" name=\"top\" type=\"radio\" value=\"1\" />\r\n<label for=\"top1\">当前版块</label>\r\n<input id=\"top2\" name=\"top\" type=\"radio\" value=\"2\" />\r\n<label for=\"top2\">当前版块及其子版块</label>\r\n<input id=\"top3\" name=\"top\" type=\"radio\" value=\"3\" />\r\n<label for=\"top3\">全站</label>\r\n<div class=\"description\">设置或取消某个主题的置顶</div>\r\n</dd>\r\n</dl>\r\n<dl style=\"");
	templateBuilder.Append(action=="digest"?"":"display:none;".ToString());

	templateBuilder.Append("\">\r\n<dt>\r\n精华\r\n</dt>\r\n<dd>\r\n<label>\r\n<input name=\"digest\" type=\"radio\" value=\"0\" />\r\n解除\r\n</label>\r\n<label>\r\n<input name=\"digest\" type=\"radio\" checked=\"checked\" value=\"1\" />\r\n精华\r\n</label>\r\n<div class=\"description\">解除或设置精华</div>\r\n</dd>\r\n</dl>\r\n<dl style=\"");
	templateBuilder.Append(action=="close"?"":"display:none;".ToString());

	templateBuilder.Append("\">\r\n<dt>打开/关闭</dt>\r\n<dd>\r\n<label>\r\n<input name=\"close\" type=\"radio\" value=\"0\" />\r\n打开\r\n</label>\r\n<label>\r\n<input name=\"close\" type=\"radio\" checked=\"checked\" value=\"1\" />\r\n关闭\r\n</label>\r\n<div class=\"description\">打开或关闭某个主题</div>\r\n</dd>\r\n</dl>\r\n<dl style=\"");
	templateBuilder.Append(action=="highlight"?"":"display:none;".ToString());

	templateBuilder.Append("\">\r\n<dt>\r\n高亮\r\n</dt>\r\n<dd>\r\n<label>\r\n<input type=\"checkbox\" value=\"1\" name=\"highlight_style_b\" />\r\n<strong>粗体</strong>\r\n</label>\r\n<label>\r\n<input type=\"checkbox\" value=\"1\" name=\"highlight_style_i\" />\r\n<em>斜体</em>\r\n</label>\r\n<label>\r\n<input type=\"checkbox\" value=\"1\" name=\"highlight_style_u\" />\r\n<u>下划线</u>\r\n</label>\r\n<select name=\"color\">\r\n<option value=\"\">颜色未选择</option>\r\n<option value=\"#EE1B2E\">#EE1B2E</option>\r\n<option value=\"#EE5023\">#EE5023</option>\r\n<option value=\"#996600\">#996600</option>\r\n<option value=\"#3C9D40\">#3C9D40</option>\r\n<option value=\"#2897C5\">#2897C5</option>\r\n<option value=\"#2B65B7\">#2B65B7</option>\r\n<option value=\"#8F2A90\">#8F2A90</option>\r\n<option value=\"#EC1282\">#EC1282</option>\r\n<option value=\"#000000\">#000000</option>\r\n</select>\r\n<div class=\"description\">设置主题标题的显示样式</div>\r\n</dd>\r\n</dl>\r\n<dl style=\"");
	templateBuilder.Append(action=="ban"||action=="banreply"?"":"display:none;".ToString());

	templateBuilder.Append("\">\r\n<dt>\r\n屏蔽操作\r\n</dt>\r\n<dd>\r\n<label>\r\n<input name=\"ban\" type=\"radio\" value=\"0\" />\r\n取消\r\n</label>\r\n<label>\r\n<input name=\"ban\" type=\"radio\" checked=\"checked\" value=\"1\" />\r\n屏蔽\r\n</label>\r\n<div class=\"description\">取消屏蔽或屏蔽某个主题</div>\r\n</dd>\r\n</dl>\r\n");
	if (action=="move")
	{

	templateBuilder.Append("\r\n<dl style=\"");
	templateBuilder.Append(action=="move"?"":"display:none;".ToString());

	templateBuilder.Append("\">\r\n<dt>\r\n目标版块\r\n</dt>\r\n<dd>\r\n<select name=\"tobid\" class=\"select\">\r\n<option value=\"0\">请选择版块</option>\r\n");
	foreach(DataRow drSub in drSubList)
	{

	if (Utils.StrToInt(Utils.ObjectToStr(drSub["ClassLayer"]), 0)==1)
	{

	templateBuilder.Append("\r\n<option value=\"" + Utils.ObjectToStr(drSub["Id"]) + "\">" + Utils.ObjectToStr(drSub["Name"]) + "</option>\r\n");
	}
	else
	{

	templateBuilder.Append("\r\n<option value=\"" + Utils.ObjectToStr(drSub["Id"]) + "\">");
	templateBuilder.Append(DTcms.Common.Utils.StringOfChar(Convert.ToInt32(drSub["ClassLayer"]) - 1, "　") + drSub["Name"].ToString().ToString());

	templateBuilder.Append(" </option>\r\n");
	}	//end for if

	}	//end for if

	templateBuilder.Append("\r\n</select>\r\n<div class=\"description\">要移动至某个版块</div>\r\n</dd>\r\n</dl>\r\n");
	}	//end for if

	templateBuilder.Append("\r\n<dl>\r\n<dt>\r\n原因\r\n</dt>\r\n<dd>\r\n<div>\r\n快捷原因：\r\n<select id=\"reson\">\r\n<option value=\"\">自定义</option>\r\n<option value=\"\">-----</option>\r\n<option value=\"广告/SPAM\">广告/SPAM</option>\r\n<option value=\"恶意灌水\">恶意灌水</option>\r\n<option value=\"违规内容\">违规内容</option>\r\n<option value=\"文不对题\">文不对题</option>\r\n<option value=\"重复发帖\">重复发帖</option>\r\n<option value=\"\">-----</option>\r\n<option value=\"我很赞同\">我很赞同</option>\r\n<option value=\"精品文章\">精品文章</option>\r\n<option value=\"原创内容很给力!\">原创内容很给力!</option>\r\n<option value=\"赞一个!\">赞一个!</option>\r\n<option value=\"山寨\">山寨</option>\r\n<option value=\"淡定\">淡定</option>\r\n<option value=\"\">-----</option>\r\n</select>\r\n</div>\r\n<div class=\"text_area\">\r\n<textarea cols=\"50\" rows=\"5\" name=\"reason\"></textarea>\r\n</div>\r\n</dd>\r\n</dl>\r\n<dl style=\"display:none;\">\r\n<dt>通知</dt>\r\n<dd>\r\n<input id=\"send_short_message\" type=\"checkbox\" name=\"send_message\" value=\"1\" checked=\"checked\" />\r\n<label for=\"send_short_message\">操作后将以站内信方式通知作者</label>\r\n</dd>\r\n</dl>\r\n<dl>\r\n<dt>\r\n相关主题\r\n</dt>\r\n<dd class=\"ul_list\">\r\n<ul>\r\n");
	if (action!="deletereply"&&action!="banreply")
	{

	foreach(DataRow dr in drTopicList)
	{

	templateBuilder.Append("\r\n<li>\r\n<input id=\"topic_" + Utils.ObjectToStr(dr["Id"]) + "\" type=\"checkbox\" name=\"tids\" value=\"" + Utils.ObjectToStr(dr["Id"]) + "\" checked=\"checked\"/>\r\n<label for=\"topic_" + Utils.ObjectToStr(dr["Id"]) + "\">" + Utils.ObjectToStr(dr["Title"]) + "</label>\r\n</li>\r\n");
	}	//end for if

	}
	else
	{

	foreach(DataRow dr in drPostList)
	{

	templateBuilder.Append("\r\n<li>\r\n<input id=\"post_" + Utils.ObjectToStr(dr["Id"]) + "\" type=\"checkbox\" name=\"rids\" value=\"" + Utils.ObjectToStr(dr["Id"]) + "\" checked=\"checked\"/>\r\n<label for=\"post_" + Utils.ObjectToStr(dr["Id"]) + "\">回复：");
	templateBuilder.Append(DTcms.Common.Utils.DropHTML(Utils.ObjectToStr(dr["Message"]),15).ToString());

	templateBuilder.Append("</label>\r\n</li>\r\n");
	}	//end for if

	}	//end for if

	templateBuilder.Append("\r\n</ul>\r\n</dd>\r\n</dl>\r\n<div class=\"control button_bar clearfix\">\r\n<ul>\r\n<li>\r\n<button type=\"submit\" name=\"ok\" value=\"ok\" class=\"button skyblue\">确认</button>\r\n</li>\r\n<li>\r\n<button type=\"button\" name=\"cancel\" value=\"cancel\" onClick=\"javascript: history.go(-1);\" class=\"button\">返回</button>\r\n</li>\r\n</ul>\r\n</div>\r\n</form>\r\n</div>\r\n</div>\r\n</div>\r\n<script src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("plugins/forum/templet/Default/scripts/common.js\" type=\"text/javascript\"></");
	templateBuilder.Append("script>\r\n<script src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("plugins/forum/templet/Default/scripts/easydialog/easydialog.js\" type=\"text/javascript\"></");
	templateBuilder.Append("script>\r\n<script src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("plugins/forum/templet/Default/scripts/jquery.form.js\" type=\"text/javascript\"></");
	templateBuilder.Append("script>\r\n<script src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("plugins/forum/templet/Default/scripts/Manage.js\" type=\"text/javascript\"></");
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