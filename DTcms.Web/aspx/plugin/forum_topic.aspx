<%@ Page Language="C#" AutoEventWireup="true" Inherits="DTcms.Web.Plugin.Forum.Page.topic" ValidateRequest="false" %>
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
	templateBuilder.Append(Utils.ObjectToStr(modelTopic.Title));
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
	templateBuilder.Append("plugins/forum/templet/Default/scripts/jquery.ex/jquery.ex.css\" />\r\n<link href=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("plugins/forum/templet/Default/scripts/easydialog/easydialog.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n<link href=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("plugins/forum/templet/Default/scripts/shadowbox/shadowbox.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n<script src=\"");
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
	templateBuilder.Append("script>\r\n<link href=\"#\" rel=\"canonical\" />\r\n</head>\r\n<body>\r\n<!--页面头部-->\r\n");

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


	templateBuilder.Append("\r\n<!--/页面头部-->\r\n<div class=\"wrap\">\r\n<div class=\"sp clearfix\">\r\n<div class=\"button_panel fl\">\r\n<ul class=\"fl\">\r\n");
	if (modelUserExtended!=null)
	{

	templateBuilder.Append("\r\n<li> <a href=\"");
	templateBuilder.Append(linkurl("forum_post","create",modelBoard.Id));

	templateBuilder.Append("\"> <img src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("plugins/forum/templet/Default/images/post_button.png\" alt=\"发帖\" /> </a> </li>\r\n<li> <a href=\"");
	templateBuilder.Append(linkurl("forum_post","reply",modelBoard.Id,modelTopic.Id));

	templateBuilder.Append("\"> <img src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("plugins/forum/templet/Default/images/reply_button.png\" alt=\"回复\" /> </a> </li>\r\n");
	if (bolOperate)
	{

	templateBuilder.Append("\r\n<li> <a href=\"javascript:void(0);\"> <img class=\"mypop\" data-pop-id=\"manage_panel\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("plugins/forum/templet/Default/images/manage_button.png\" alt=\"管理\" /> </a> </li>\r\n");
	}	//end for if

	}
	else
	{

	templateBuilder.Append("\r\n<li> <span class=\"no_ct\"> 您所在分组(<strong>游客</strong>)还不能进行回复\r\n，您可以进行<a href=\"");
	templateBuilder.Append(linkurl("login"));

	templateBuilder.Append("\">登录</a>或<a href=\"");
	templateBuilder.Append(linkurl("register"));

	templateBuilder.Append("\">注册</a> </span> </li>\r\n");
	}	//end for if

	templateBuilder.Append("\r\n</ul>\r\n</div>\r\n<div class=\"page_panel fr\">\r\n<ul class=\"fl\">\r\n");
	templateBuilder.Append(Utils.ObjectToStr(pagelist));
	templateBuilder.Append("\r\n</ul>\r\n</div>\r\n</div>\r\n<div id=\"top_reply\" class=\"box_panel sp post_list_panel\">\r\n<form id=\"moderate\" method=\"post\" action=\"#\">\r\n");
	if (bolOperate)
	{

	templateBuilder.Append("\r\n<input name=\"board_id\" type=\"hidden\" value=\"");
	templateBuilder.Append(board_id.ToString());

	templateBuilder.Append("\" />\r\n<input name=\"topic_id\" type=\"hidden\" value=\"");
	templateBuilder.Append(topic_id.ToString());

	templateBuilder.Append("\" />\r\n<input name=\"post_id\" type=\"hidden\" value=\"");
	templateBuilder.Append(modelTopic.PostId.ToString());

	templateBuilder.Append("\" />\r\n<input name=\"turl\" type=\"hidden\" value=\"");
	templateBuilder.Append(Utils.ObjectToStr(turl));
	templateBuilder.Append("\" />\r\n<div id=\"manage_panel\" class=\"pop_panel manage_pop_panel\">\r\n<div class=\"content\">\r\n<h3>主题管理</h3>\r\n<ul>\r\n<li><a href=\"");
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

	templateBuilder.Append("\" class=\"manage_action\" style=\"display:none;\">主题分类</a></li>\r\n</ul>\r\n<h3>批量回复管理</h3>\r\n<ul>\r\n<li>\r\n<input id=\"post_select_all\" type=\"checkbox\" class=\"select_all\" />\r\n<label for=\"post_select_all\">全部回复</label>\r\n</li>\r\n</ul>\r\n<ul>\r\n<li><a href=\"");
	templateBuilder.Append(linkurl("forum_manage","banreply"));

	templateBuilder.Append("\" class=\"manage_action\">屏蔽回复</a></li>\r\n<li><a href=\"");
	templateBuilder.Append(linkurl("forum_manage","deletereply"));

	templateBuilder.Append("\" class=\"manage_action\">删除回复</a></li>\r\n</ul>\r\n</div>\r\n</div>\r\n<div id=\"manageTopic\" class=\"box_panel box_panel__color_easy post_manage_panel\">\r\n<div class=\"box_panel_title clearfix\">\r\n<div class=\"fl\">选择了<span id=\"manageTopicCount\">0</span>个回复</div>\r\n<div class=\"fr\">\r\n<input id=\"flex_post_select_all\" type=\"checkbox\" class=\"select_all\" />\r\n<label for=\"flex_post_select_all\">全部回复</label>\r\n<span class=\"pipe\">|</span> <span class=\"select_all_cancel\">取消</span> </div>\r\n</div>\r\n<div class=\"box_panel_context\">\r\n<ul>\r\n<li><a href=\"");
	templateBuilder.Append(linkurl("forum_manage","banreply"));

	templateBuilder.Append("\" class=\"manage_action\">屏蔽回复</a></li>\r\n<li><a href=\"");
	templateBuilder.Append(linkurl("forum_manage","deletereply"));

	templateBuilder.Append("\" class=\"manage_action\">删除回复</a></li>\r\n</ul>\r\n</div>\r\n</div>\r\n");
	}	//end for if

	templateBuilder.Append("\r\n<div class=\"thread_bar clearfix\">\r\n<div class=\"thread_info\">\r\n<ul>\r\n<li> <em>");
	templateBuilder.Append(Utils.ObjectToStr(modelTopic.ViewCount));
	templateBuilder.Append("</em> 阅读 </li>\r\n<li> <em>");
	templateBuilder.Append(Utils.ObjectToStr(modelTopic.ReplayCount));
	templateBuilder.Append("</em> 回复 </li>\r\n</ul>\r\n</div>\r\n<h1> ");
	templateBuilder.Append(Utils.ObjectToStr(modelTopic.Title));
	templateBuilder.Append(" </h1>\r\n<div class=\"post_size_control\"> <em onclick=\"$('.msg').removeClass().addClass('msg t_bigfont')\">大</em> <span class=\"pipe\">|</span> <em onclick=\"$('.msg').removeClass().addClass('msg t_msgfont')\">中</em> <span class=\"pipe\">|</span> <em onclick=\"$('.msg').removeClass().addClass('msg t_smallfont')\">小</em> </div>\r\n</div>\r\n");
	foreach(DataRow dr in drPostList)
	{

	templateBuilder.Append("\r\n<div class=\"wline\">\r\n<div class=\"left_bg\">&nbsp;</div>\r\n</div>\r\n<div id=\"reply_" + Utils.ObjectToStr(dr["id"]) + "\" class=\"post\">\r\n<table class=\"pt\">\r\n<tr>\r\n<td rowspan=\"2\" class=\"user_info\" data-userId=\"" + Utils.ObjectToStr(dr["PostUserId"]) + "\" ><div class=\"user_pop clearfix\" id=\"user_pop_" + Utils.ObjectToStr(dr["id"]) + "\">\r\n<div class=\"userex\">\r\n<div class=\"avatar\"> <img src=\"/plugins/forum/handler/avatar.ashx?uid=" + Utils.ObjectToStr(dr["PostUserId"]) + "&size=120\" onerror=\"this.onerror=null;this.src='");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("plugins/forum/templet/Default/images/avatar_none_120.jpg'\" alt=\"<!--Nickname-->\" /> </div>\r\n");
	if (modelUserExtended!=null)
	{

	templateBuilder.Append("\r\n<div class=\"post_pm\" style=\"line-height:25px;\"> <a target=\"_blank\" href=\"");
	templateBuilder.Append(linkurl("usermessage","add"));

	templateBuilder.Append("#" + Utils.ObjectToStr(dr["PostUsername"]) + "\">发送短消息</a> </div>\r\n");
	}	//end for if

	templateBuilder.Append("\r\n</div>\r\n<div class=\"popex\">\r\n<ul class=\"attr\">\r\n<li>\r\n<label>UID:</label>\r\n<!--UserId-->\r\n</li>\r\n<li>\r\n<label>性别:</label>\r\n<!--Gender-->\r\n</li>\r\n<li>\r\n<label>IP:</label>\r\n<!--LoginIp-->\r\n</li>\r\n<li>\r\n<label>金币:</label>\r\n<!--Credit-->\r\n</li>\r\n<li>\r\n<label>主题:</label>\r\n<!--TopicCount-->\r\n</li>\r\n<li>\r\n<label>帖子:</label>\r\n<!--PostCount-->\r\n</li>\r\n<li>\r\n<label>精华:</label>\r\n<!--PostDigestCount-->\r\n</li>\r\n<li>\r\n<label>注册日期:</label>\r\n<!--RegTime-->\r\n</li>\r\n<li>\r\n<label>最后登录:</label>\r\n<!--LoginTime-->\r\n</li>\r\n</ul>\r\n</div>\r\n</div>\r\n");
	if (Utils.StrToInt(Utils.ObjectToStr(dr["PostUserId"]), 0)==modelTopic.PostUserId)
	{

	templateBuilder.Append("\r\n<div class=\"man_icon\">楼主帖</div>\r\n");
	}	//end for if

	templateBuilder.Append("\r\n<div class=\"avatar UserInfoPanelEx\" data-exid=\"user_pop_" + Utils.ObjectToStr(dr["id"]) + "\"> <img src=\"/plugins/forum/handler/avatar.ashx?uid=" + Utils.ObjectToStr(dr["PostUserId"]) + "&size=120\" onerror=\"this.onerror=null;this.src='");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("plugins/forum/templet/Default/images/avatar_none_120.jpg'\" alt=\"<!--Nickname-->\" /> </div>\r\n<div class=\"username\"> <span class=\"user_online_icon user_offline_male\" title=\"离线\" style=\"display:none;\"></span> <a href=\"#" + Utils.ObjectToStr(dr["PostUserId"]) + "\"><span style=\"color:#0066ff;\">\r\n<!--Nickname-->\r\n</span></a> </div>\r\n<div class=\"exinfo\">\r\n<ul class=\"attr\">\r\n<li>\r\n<label>金币:</label>\r\n<!--Credit-->\r\n</li>\r\n</ul>\r\n<div class=\"xz\" data-medal=\"<!--Medal-->\"> </div>\r\n</div></td>\r\n<td class=\"post_info\"><div class=\"post_toolbar clearfix\">\r\n<div class=\"fl\">\r\n");
	if (Utils.StrToInt(Utils.ObjectToStr(dr["row_number"]), 0)!=1&&bolOperate)
	{

	templateBuilder.Append("\r\n<input id=\"post_" + Utils.ObjectToStr(dr["id"]) + "_select\" type=\"checkbox\" value=\"" + Utils.ObjectToStr(dr["id"]) + "\" name=\"rids\"/>\r\n<label for=\"post_" + Utils.ObjectToStr(dr["id"]) + "_select\">管理</label>\r\n<span class=\"pipe\">|</span>\r\n");
	}	//end for if

	templateBuilder.Append("\r\n发表于: <span title=\"" + Utils.ObjectToStr(dr["PostDateTime"]) + "\"> " + Utils.ObjectToStr(dr["PostDateTime"]) + " </span> </div>\r\n<div class=\"fr\">\r\n");
	if (modelUserExtended!=null)
	{

	if (Utils.StrToInt(Utils.ObjectToStr(dr["row_number"]), 0)==1)
	{

	if (Utils.StrToInt(Utils.ObjectToStr(dr["PostUserId"]), 0)==modelUserExtended.UserId)
	{

	templateBuilder.Append("\r\n<a href=\"");
	templateBuilder.Append(linkurl("forum_post","update",modelBoard.Id,modelTopic.Id,Utils.ObjectToStr(dr["id"])));

	templateBuilder.Append("\">编辑</a>\r\n");
	}	//end for if

	}
	else
	{

	if (Utils.StrToInt(Utils.ObjectToStr(dr["PostUserId"]), 0)==modelUserExtended.UserId)
	{

	templateBuilder.Append("\r\n<a href=\"");
	templateBuilder.Append(linkurl("forum_post","editor",modelBoard.Id,modelTopic.Id,Utils.ObjectToStr(dr["id"])));

	templateBuilder.Append("\">编辑</a>\r\n");
	}	//end for if

	}	//end for if

	}	//end for if

	templateBuilder.Append("\r\n<span class=\"pipe\">|</span> <strong>" + Utils.ObjectToStr(dr["row_number"]) + " 楼</strong> </div>\r\n</div>\r\n<div class=\"post_main\">\r\n");
	if (Utils.StrToInt(Utils.ObjectToStr(dr["Ban"]), 0)==1)
	{

	templateBuilder.Append("\r\n<div class=\"mb\">提示:该帖被管理员人员屏蔽，限有管理权限的成员或发帖用户可见</div>\r\n");
	}
	else
	{

	templateBuilder.Append("\r\n<div id=\"postMessage_" + Utils.ObjectToStr(dr["id"]) + "\" class=\"msg t_msgfont\">\r\n<div class=\"adright\" style=\"display:none;\"> <a href=\"#\" target=\"_blank\"><img src=\"#\" /></a> </div>\r\n");
	if (Utils.ObjectToStr(dr["QuotePostIds"])!="")
	{

	templateBuilder.Append("\r\n<blockquote> 引用[" + Utils.ObjectToStr(dr["QuoteNickname"]) + "]:<br />\r\n" + Utils.ObjectToStr(dr["QuoteMessage"]) + "</blockquote>\r\n");
	}	//end for if

	templateBuilder.Append("\r\n" + Utils.ObjectToStr(dr["Message"]) + " </div>\r\n");
	if (Utils.ObjectToStr(dr["Attachment"])!="0")
	{

	DataTable dtAttList = new DTcms.Web.Plugin.Forum.Label().get_attachment_list(Utils.StrToInt(Utils.ObjectToStr(dr["PostUserId"]), 0),Utils.StrToInt(Utils.ObjectToStr(dr["BoardId"]), 0),Utils.StrToInt(Utils.ObjectToStr(dr["TopicId"]), 0),Utils.StrToInt(Utils.ObjectToStr(dr["Id"]), 0));

	System.Data.DataRow[] drAttList = dtAttList.Select("1=1","id asc");
	

	if (drAttList.Length!=0)
	{

	templateBuilder.Append("\r\n<div class=\"lastedit\" style=\"display:none;\"> **** 于 <span title=\"2013-04-13 15:03\">2013-04-13 15:03</span> 编辑过此帖 </div>\r\n<div class=\"list_panel rate_list_panel\">\r\n<table>\r\n<thead>\r\n<tr>\r\n<td>附件列表</td>\r\n</tr>\r\n</thead>\r\n<tbody>\r\n");
	foreach(DataRow dr2 in drAttList)
	{

	string tempSize = "";

	templateBuilder.Append("\r\n<tr>\r\n<td><span id=\"attachment_" + Utils.ObjectToStr(dr2["id"]) + "\" class=\"att attachment\" data-pop-id=\"attachment_" + Utils.ObjectToStr(dr2["id"]) + "_tip\">\r\n<div id=\"attachment_" + Utils.ObjectToStr(dr2["id"]) + "_tip\" class=\"attachment_tip\" style=\"display:none;\">\r\n<p>文件：" + Utils.ObjectToStr(dr2["Name"]) + "</p>\r\n<p>大小：\r\n");
	if (Utils.StrToInt(Utils.ObjectToStr(dr2["FileSize"]), 0)>1024)
	{

	tempSize = (Utils.StrToInt(Utils.ObjectToStr(dr2["FileSize"]), 0)/1024f).ToString("#.##");
	

	templateBuilder.Append("\r\n");
	templateBuilder.Append(Utils.ObjectToStr(tempSize));
	templateBuilder.Append("MB\r\n");
	}
	else
	{

	templateBuilder.Append("\r\n" + Utils.ObjectToStr(dr2["FileSize"]) + "KB\r\n");
	}	//end for if

	templateBuilder.Append("\r\n</p>\r\n<p>描述：" + Utils.ObjectToStr(dr2["Description"]) + "</p>\r\n<p>下载：" + Utils.ObjectToStr(dr2["Download"]) + " 次</p>\r\n<p><a href=\"/plugins/forum/handler/attachment.ashx?site=main&action=down&aid=" + Utils.ObjectToStr(dr2["id"]) + "\" target=\"_blank\">下载</a></p>\r\n</div>\r\n<a href=\"/plugins/forum/handler/attachment.ashx?site=main&action=down&aid=" + Utils.ObjectToStr(dr2["id"]) + "\" target=\"_blank\" class=\"post_attachs\">" + Utils.ObjectToStr(dr2["Name"]) + "</a>\r\n<span class=\"att_size\"> (\r\n");
	if (Utils.StrToInt(Utils.ObjectToStr(dr2["FileSize"]), 0)>1024)
	{

	templateBuilder.Append("\r\n");
	templateBuilder.Append(Utils.ObjectToStr(tempSize));
	templateBuilder.Append("MB\r\n");
	}
	else
	{

	templateBuilder.Append("\r\n" + Utils.ObjectToStr(dr2["FileSize"]) + "KB\r\n");
	}	//end for if

	templateBuilder.Append("\r\n) </span></span> </td>\r\n</tr>\r\n");
	}	//end for if

	templateBuilder.Append("\r\n</tbody>\r\n</table>\r\n</div>\r\n");
	}	//end for if

	}	//end for if

	}	//end for if

	templateBuilder.Append("\r\n</div></td>\r\n</tr>\r\n<tr>\r\n<td class=\"ex\"><div class=\"signatures\" data-userId=\"" + Utils.ObjectToStr(dr["PostUserId"]) + "\" style=\"_overflow:hidden;_height:100px;max-height:100px; display:none;\"> </div></td>\r\n</tr>\r\n<tr>\r\n<td>&nbsp;</td>\r\n<td class=\"post_tool_a\"><div class=\"post_tool clearfix\">\r\n<div class=\"fl\">\r\n<ul>\r\n<li class=\"action_reply\"><a href=\"");
	templateBuilder.Append(linkurl("forum_post","reply",modelBoard.Id,modelTopic.Id));

	templateBuilder.Append("\">回复</a></li>\r\n<li class=\"action_quote\"><a href=\"");
	templateBuilder.Append(linkurl("forum_post","reply",modelBoard.Id,modelTopic.Id,Utils.ObjectToStr(dr["id"])));

	templateBuilder.Append("\">引用</a></li>\r\n");
	if (modelUserExtended!=null)
	{

	templateBuilder.Append("\r\n<li class=\"action_update\">\r\n");
	if (Utils.StrToInt(Utils.ObjectToStr(dr["row_number"]), 0)==1)
	{

	if (Utils.StrToInt(Utils.ObjectToStr(dr["PostUserId"]), 0)==modelUserExtended.UserId)
	{

	templateBuilder.Append("\r\n<a href=\"");
	templateBuilder.Append(linkurl("forum_post","update",modelBoard.Id,modelTopic.Id,Utils.ObjectToStr(dr["id"])));

	templateBuilder.Append("\">编辑</a>\r\n");
	}	//end for if

	}
	else
	{

	if (Utils.StrToInt(Utils.ObjectToStr(dr["PostUserId"]), 0)==modelUserExtended.UserId)
	{

	templateBuilder.Append("\r\n<a href=\"");
	templateBuilder.Append(linkurl("forum_post","editor",modelBoard.Id,modelTopic.Id,Utils.ObjectToStr(dr["id"])));

	templateBuilder.Append("\">编辑</a>\r\n");
	}	//end for if

	}	//end for if

	templateBuilder.Append("\r\n</li>\r\n");
	if (Utils.StrToInt(Utils.ObjectToStr(dr["First"]), 0)!=1)
	{

	if (Utils.StrToInt(Utils.ObjectToStr(dr["PostUserId"]), 0)==modelUserExtended.UserId)
	{

	templateBuilder.Append("\r\n<li class=\"action_delete\"> <a href=\"");
	templateBuilder.Append(linkurl("forum_post","selfdelete",modelBoard.Id,modelTopic.Id,Utils.ObjectToStr(dr["id"])));

	templateBuilder.Append("\" onclick = \"javascript:return window.confirm('确定要删除吗?');\">删除我的回复</a> </li>\r\n");
	}	//end for if

	}
	else
	{

	if (Utils.StrToInt(Utils.ObjectToStr(dr["PostUserId"]), 0)==modelUserExtended.UserId)
	{

	templateBuilder.Append("\r\n<li class=\"action_delete\"> <a href=\"");
	templateBuilder.Append(linkurl("forum_post","selftopicdelete",modelBoard.Id,modelTopic.Id,Utils.ObjectToStr(dr["id"])));

	templateBuilder.Append("\" onclick = \"javascript:return window.confirm('确定要删除吗?');\">删除我的主题</a> </li>\r\n");
	}	//end for if

	}	//end for if

	}	//end for if

	templateBuilder.Append("\r\n</ul>\r\n</div>\r\n<div class=\"fr\"> <a href=\"#top_reply\">返回顶部</a> </div>\r\n</div></td>\r\n</tr>\r\n</table>\r\n</div>\r\n");
	}	//end for if

	templateBuilder.Append("\r\n</form>\r\n</div>\r\n<div class=\"sp clearfix\">\r\n<div class=\"button_panel fl\">\r\n<ul class=\"fl\">\r\n");
	if (modelUserExtended!=null)
	{

	templateBuilder.Append("\r\n<li> <a href=\"");
	templateBuilder.Append(linkurl("forum_post","create",modelBoard.Id));

	templateBuilder.Append("\"> <img src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("plugins/forum/templet/Default/images/post_button.png\" alt=\"发帖\" /> </a> </li>\r\n<li> <a href=\"");
	templateBuilder.Append(linkurl("forum_post","reply",modelBoard.Id,modelTopic.Id));

	templateBuilder.Append("\"> <img src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("plugins/forum/templet/Default/images/reply_button.png\" alt=\"回复\" /> </a> </li>\r\n");
	}
	else
	{

	templateBuilder.Append("\r\n<li> <span class=\"no_ct\"> 您所在分组(<strong>游客</strong>)还不能进行回复\r\n，您可以进行<a href=\"");
	templateBuilder.Append(linkurl("login"));

	templateBuilder.Append("\">登录</a>或<a href=\"");
	templateBuilder.Append(linkurl("register"));

	templateBuilder.Append("\">注册</a> </span> </li>\r\n");
	}	//end for if

	templateBuilder.Append("\r\n</ul>\r\n</div>\r\n<div class=\"page_panel fr\">\r\n<ul class=\"fl\">\r\n");
	templateBuilder.Append(Utils.ObjectToStr(pagelist));
	templateBuilder.Append("\r\n</ul>\r\n</div>\r\n</div>\r\n");
	if (modelUserExtended!=null)
	{

	templateBuilder.Append("\r\n<div class=\"box_panel sp\">\r\n<div class=\"box_panel_title clearfix\">\r\n<div class=\"fl\">快速回复</div>\r\n<div class=\"fr\"><a href=\"");
	templateBuilder.Append(linkurl("forum_post","reply",modelBoard.Id,modelTopic.Id));

	templateBuilder.Append("\">使用高级回帖</a>（可批量传图、插入附件等）</div>\r\n</div>\r\n<div class=\"box_panel_context quickly_create_reply\">\r\n<form id=\"post\" method=\"post\" action=\"#\" onsubmit=\"return nsubmit();\">\r\n<input id=\"smile\" name=\"smile\" type=\"hidden\" value=\"1\" />\r\n<input id=\"signature\" name=\"signature\" type=\"hidden\" value=\"1\" />\r\n<input id=\"AutoUrl\" name=\"AutoUrl\" type=\"hidden\" value=\"1\" />\r\n<input type=\"hidden\" name=\"url\" value=\"\" />\r\n<input id=\"title\" name=\"title\" type=\"hidden\" value=\"");
	templateBuilder.Append(Utils.ObjectToStr(modelTopic.Title));
	templateBuilder.Append("\" />\r\n<input id=\"board_id\" name=\"board_id\" type=\"hidden\" value=\"");
	templateBuilder.Append(board_id.ToString());

	templateBuilder.Append("\" />\r\n<input id=\"topic_id\" name=\"topic_id\" type=\"hidden\" value=\"");
	templateBuilder.Append(topic_id.ToString());

	templateBuilder.Append("\" />\r\n<input id=\"action\" name=\"action\" type=\"hidden\" value=\"reply\" />\r\n<input id=\"turl\" name=\"turl\" type=\"hidden\" value=\"");
	templateBuilder.Append(Utils.ObjectToStr(turl));
	templateBuilder.Append("\" />\r\n<table>\r\n<tr>\r\n<td class=\"author\"><div class=\"username\">");
	templateBuilder.Append(Utils.ObjectToStr(modelUserExtended.Nickname));
	templateBuilder.Append("</div>\r\n<div class=\"avatar\"> <img src=\"/plugins/forum/handler/avatar.ashx?uid=");
	templateBuilder.Append(Utils.ObjectToStr(modelUserExtended.UserId));
	templateBuilder.Append("&size=120\" onerror=\"this.onerror=null;this.src='/plugins/forum/templet/Default/Images/avatar_none_120.jpg'\" alt=\"");
	templateBuilder.Append(Utils.ObjectToStr(modelUserExtended.Nickname));
	templateBuilder.Append("\" /> </div></td>\r\n<td class=\"quickly_create_reply_main\"><script type=\"text/plain\" id=\"postEditor\" style=\"width:100%;height:340px;\"></");
	templateBuilder.Append("script>\r\n<div class=\"editor_loading\">&nbsp;</div>\r\n<div class=\"editor\">\r\n<div>\r\n<textarea name=\"message\" id = \"textarea_message\" class = \"TextField\" cols = \"60\" rows = \"20\" style=\"visibility: hidden; display: none;\"></textarea>\r\n</div>\r\n<div class=\"options\">\r\n<input class=\"vc text\" id=\"vc\" name=\"vc\" size=\"4\" style=\"text-transform:uppercase;\" tabindex=\"3\" type=\"text\" value=\"\">\r\n<img id=\"vcimg\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("plugins/forum/templet/Default/images/loading.gif\" alt=\"code\"> <a href=\"#\" id=\"vcimgc\" tabindex=\"6\">看不清,换一张</a> </div>\r\n<div class=\"action\">\r\n<button type=\"submit\" name=\"Ok\" class=\"button skyblue\">确认发布</button>\r\n[在内容区直接按 Ctrl+Enter 可完成发布] </div>\r\n</div></td>\r\n</tr>\r\n</table>\r\n</form>\r\n</div>\r\n</div>\r\n");
	}	//end for if

	templateBuilder.Append("\r\n</div>\r\n<script src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("plugins/forum/templet/Default/scripts/common.js\" type=\"text/javascript\"></");
	templateBuilder.Append("script>\r\n<script src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("plugins/forum/templet/Default/scripts/jquery.lazyload.js\" type=\"text/javascript\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\">\r\n$(function () {\r\n//加载图像\r\n$(\"img[data-lasy]\").lazyload({\r\ndata_attribute: \"lasy\",\r\nfailure_limit: 10,\r\nskip_invisible: false,\r\neffect: \"fadeIn\"\r\n});\r\n});\r\n</");
	templateBuilder.Append("script>\r\n<script src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("plugins/forum/templet/Default/scripts/shadowbox/shadowbox.js\" type=\"text/javascript\"></");
	templateBuilder.Append("script>\r\n<script src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("plugins/forum/templet/Default/scripts/easydialog/easydialog.js\" type=\"text/javascript\"></");
	templateBuilder.Append("script>\r\n<script src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("plugins/forum/templet/Default/scripts/jquery.form.js\" type=\"text/javascript\"></");
	templateBuilder.Append("script>\r\n<link href=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("plugins/forum/templet/Default/UMeditor/umeditor.css\" type=\"text/css\" rel=\"stylesheet\">\r\n<script type=\"text/javascript\" charset=\"utf-8\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("plugins/forum/templet/Default/UMeditor/umeditor.config.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" charset=\"utf-8\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("plugins/forum/templet/Default/UMeditor/umeditor.min.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("plugins/forum/templet/Default/UMeditor/zh-cn.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("plugins/forum/templet/Default/Scripts/Post.js\"></");
	templateBuilder.Append("script>\r\n");
	DataTable dtMedalList = new DTcms.Web.Plugin.Forum.Label().get_medal_list();

	System.Data.DataRow[] drMedalList = dtMedalList.Select("1=1");
	

	foreach(DataRow dr in drMedalList)
	{

	templateBuilder.Append("\r\n<input id=\"Medal" + Utils.ObjectToStr(dr["id"]) + "\" type=\"hidden\" data-name=\"" + Utils.ObjectToStr(dr["Name"]) + "\" data-description=\"" + Utils.ObjectToStr(dr["Description"]) + "\" data-url=\"" + Utils.ObjectToStr(dr["Url"]) + "\" data-available=\"" + Utils.ObjectToStr(dr["Available"]) + "\" value=\"" + Utils.ObjectToStr(dr["Image"]) + "\"/>\r\n");
	}	//end for if

	templateBuilder.Append("\r\n<!--页面底部-->\r\n");

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