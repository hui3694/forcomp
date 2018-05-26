<%@ Page Language="C#" AutoEventWireup="true" Inherits="DTcms.Web.Plugin.Forum.Page.index" ValidateRequest="false" %>
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
	templateBuilder.Append(Utils.ObjectToStr(site.name));
	templateBuilder.Append("</title>\r\n<meta name=\"keywords\" content=\"");
	templateBuilder.Append(Utils.ObjectToStr(site.seo_keyword));
	templateBuilder.Append("\" />\r\n<meta name=\"description\" content=\"");
	templateBuilder.Append(Utils.ObjectToStr(site.seo_description));
	templateBuilder.Append("\" />\r\n<meta name=\"generator\" content=\"DTcms Forum\" />\r\n<meta name=\"author\" content=\"DTcms\" />\r\n<meta name=\"copyright\" content=\"dtcms-forum.net\" />\r\n<meta name=\"MSSmartTagsPreventParsing\" content=\"True\" />\r\n<meta http-equiv=\"MSThemeCompatible\" content=\"Yes\" />\r\n<!--<link rel=\"shortcut icon\" href=\"");
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
	templateBuilder.Append("script>\r\n<link rel=\"alternate\" type=\"application/rss+xml\" title=\"RSS订阅\" href=\"/rss.aspx\" />\r\n</head>\r\n<body>\r\n<!--页面头部-->\r\n");

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


	templateBuilder.Append("\r\n<!--/页面头部-->\r\n<div class=\"wrap\">\r\n<div class=\"globalInfo sp clearfix\">\r\n<div class=\"forumInfo\"> 今日: <cite>");
	templateBuilder.Append(DTcms.Web.Plugin.Forum.Model.Statistic.TodayPost.ToString());

	templateBuilder.Append("</cite>,\r\n昨日: <cite>");
	templateBuilder.Append(DTcms.Web.Plugin.Forum.Model.Statistic.YesterdayPost.ToString());

	templateBuilder.Append("</cite>,\r\n帖子: <em>");
	templateBuilder.Append(DTcms.Web.Plugin.Forum.Model.Statistic.TotalPost.ToString());

	templateBuilder.Append("</em>,\r\n会员: <em>");
	templateBuilder.Append(DTcms.Web.Plugin.Forum.Model.Statistic.TotalUser.ToString());

	templateBuilder.Append("</em> ,\r\n");
	if (DTcms.Web.Plugin.Forum.Model.Statistic.LastUserId>0)
	{

	templateBuilder.Append("\r\n欢迎新会员: <a href=\"#");
	templateBuilder.Append(DTcms.Web.Plugin.Forum.Model.Statistic.LastUserId.ToString());

	templateBuilder.Append("\" title=\"最新注册的会员\">");
	templateBuilder.Append(DTcms.Web.Plugin.Forum.Model.Statistic.LastUserNickname.ToString());

	templateBuilder.Append("</a> </div>\r\n");
	}	//end for if

	templateBuilder.Append("\r\n<div class=\"userInfo\" style=\"display:none;\"> <a href=\"#\" title=\"订阅 RSS\" class=\"rss\">RSS</a> <span class=\"pipe\">|</span> <a href=\"#\" title=\"查看最新的帖子列表\">最新回复</a> <span class=\"pipe\">|</span> <a href=\"#\" title=\"查看精华帖子列表\">精华主题</a> </div>\r\n</div>\r\n<style type=\"text/css\">\r\n#jfp_ht {\r\n}\r\n#jfp_ht table {\r\nwidth: 100%;\r\nborder: none;\r\npadding: 0;\r\nmargin: 0;\r\nborder-collapse: collapse;\r\nborder-spacing: 0;\r\n}\r\n#jfp_ht tbody {\r\nborder: none;\r\npadding: 0;\r\nmargin: 0;\r\nvertical-align: top;\r\n}\r\n#jfp_ht td {\r\nborder: none;\r\npadding: 0;\r\nmargin: 0;\r\nvertical-align: top;\r\n}\r\n#jfp_ht .box_panel_context {\r\nline-height: 2em;\r\n}\r\n#jfp_ht .box_panel_context ul,\r\n#jfp_ht .box_panel_context ol {\r\nmargin: 5px 0;\r\npadding-left: 30px;\r\n}\r\n#jfp_ht .info_line {\r\nwidth: 10px;\r\ndisplay: block;\r\n}\r\n#jfp_ht .info_bk {\r\n}\r\n#jfp_ht .info_a {\r\nwidth: 330px;\r\n}\r\n#jfp_ht .info_b {\r\nwidth: 50%;\r\n}\r\n#jfp_ht .info_c {\r\nwidth: 50%;\r\n}\r\n</style>\r\n<div id=\"jfp_ht\" class=\"sp clearfix\">\r\n<table border=\"0\">\r\n<tr>\r\n<td class=\"info_a info_bk\">\r\n<script type=\"text/javascript\" src=\"/plugins/advert/advert_js.ashx?id=1\"></");
	templateBuilder.Append("script>\r\n</td>\r\n<td class=\"info_line\">&nbsp;</td>\r\n<td class=\"info_b info_bk\"><div class=\"box_panel list_panel board_panel\">\r\n<div class=\"box_panel_title clearfix\"> <a href=\"#\">最新主题</a> </div>\r\n<div class=\"box_panel_context\">\r\n<ul>\r\n");
	DataTable dtNewList = new DTcms.Web.Plugin.Forum.Label().get_topic_list(10, " [Close]=0 ", "id desc");
System.Data.DataRow[] drNewList = dtNewList.Select("1=1","id desc"); 

	foreach(DataRow dr in drNewList)
	{

	templateBuilder.Append("\r\n<li><a href=\"");
	templateBuilder.Append(linkurl("forum_topic",Utils.ObjectToStr(dr["id"]),1));

	templateBuilder.Append("\" title=\"" + Utils.ObjectToStr(dr["Title"]) + "\">" + Utils.ObjectToStr(dr["Title"]) + "</a></li>\r\n");
	}	//end for if

	templateBuilder.Append("\r\n</ul>\r\n</div>\r\n</div></td>\r\n<td class=\"info_line\">&nbsp;</td>\r\n<td class=\"info_c info_bk\"><div class=\"box_panel list_panel board_panel\">\r\n<div class=\"box_panel_title clearfix\"> <a href=\"#\">精华主题</a> </div>\r\n<div class=\"box_panel_context\">\r\n<ul>\r\n");
	DataTable dtDigestList = new DTcms.Web.Plugin.Forum.Label().get_topic_list(10, " [Close]=0 and Digest=1 ", "id desc");
System.Data.DataRow[] drDigestList = dtDigestList.Select("1=1 and Digest=1 ","id desc"); 

	foreach(DataRow dr in drDigestList)
	{

	templateBuilder.Append("\r\n<li><a href=\"");
	templateBuilder.Append(linkurl("forum_topic",Utils.ObjectToStr(dr["id"]),1));

	templateBuilder.Append("\" title=\"" + Utils.ObjectToStr(dr["Title"]) + "\">" + Utils.ObjectToStr(dr["Title"]) + "</a></li>\r\n");
	}	//end for if

	templateBuilder.Append("\r\n</ul>\r\n</div>\r\n</div></td>\r\n</tr>\r\n</table>\r\n</div>\r\n");
	DataTable dtBoardList = get_board_list(0);

	System.Data.DataRow[] drBoardList = dtBoardList.Select("ClassLayer=1", "SortId asc"); 

	foreach(DataRow dr in drBoardList)
	{

	templateBuilder.Append("\r\n<div class=\"box_panel list_panel sp board_panel\">\r\n<input type=\"hidden\" name=\"cookie_board_id\" value=\"" + Utils.ObjectToStr(dr["id"]) + "\" />\r\n<div class=\"box_panel_title clearfix\">\r\n<div class=\"fl\"> <a href=\"");
	templateBuilder.Append(linkurl("forum_board",Utils.ObjectToStr(dr["id"])));

	templateBuilder.Append("\">" + Utils.ObjectToStr(dr["Name"]) + "</a> </div>\r\n<div class=\"fr\"> <a title=\"展开/收起\" href=\"javascript:void(0);\"> <img id=\"board_" + Utils.ObjectToStr(dr["id"]) + "_ci\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("plugins/forum/templet/Default/images/collapsed_no.gif\" alt=\"展开与收起\" /> </a> </div>\r\n</div>\r\n<div class=\"box_panel_context\" id=\"board_" + Utils.ObjectToStr(dr["id"]) + "\">\r\n<div class=\"list_panel_cut\">\r\n");
	if (Utils.StrToInt(Utils.ObjectToStr(dr["ChildCount"]), 0)==0)
	{

	templateBuilder.Append("\r\n<!--无子版-->\r\n<table>\r\n<tbody>\r\n<tr>\r\n<td class=\"info board\"><div class=\"single_board clearfix\">\r\n<div class=\"icon\"> <a href=\"");
	templateBuilder.Append(linkurl("forum_board",Utils.ObjectToStr(dr["id"])));

	templateBuilder.Append("\"> <img src=\"");
	templateBuilder.Append(string.IsNullOrEmpty(dr["Icon"].ToString())?"/plugins/forum/templet/Default/Images/board_state_standard.gif":dr["Icon"].ToString().ToString());

	templateBuilder.Append("\" alt=\"" + Utils.ObjectToStr(dr["Name"]) + "\" /> </a> </div>\r\n<div class=\"sbc clearfix\">\r\n<div class=\"description\">\r\n<p>" + Utils.ObjectToStr(dr["Description"]) + "</p>\r\n</div>\r\n<p> 主题:" + Utils.ObjectToStr(dr["TopicCount"]) + ",\r\n帖子:" + Utils.ObjectToStr(dr["PostCount"]) + " </p>\r\n<p>\r\n");
	if (Utils.StrToInt(Utils.ObjectToStr(dr["LastTopicId"]), 0)!=0)
	{

	templateBuilder.Append("\r\n最后发表: <a href=\"");
	templateBuilder.Append(linkurl("forum_topic",Utils.ObjectToStr(dr["LastTopicId"]),1));

	templateBuilder.Append("\" title=\"" + Utils.ObjectToStr(dr["LastTopicTitle"]) + " By:" + Utils.ObjectToStr(dr["LastPostNickname"]) + "\"> " + Utils.ObjectToStr(dr["UpdateTime"]) + " </a>\r\n");
	}
	else
	{

	templateBuilder.Append("\r\n-\r\n");
	}	//end for if

	templateBuilder.Append("\r\n</p>\r\n</div>\r\n</div></td>\r\n</tr>\r\n</tbody>\r\n</table>\r\n");
	}
	else if (Utils.StrToInt(Utils.ObjectToStr(dr["ChildCount"]), 0)!=0&&Utils.StrToInt(Utils.ObjectToStr(dr["ChildCol"]), 0)<2)
	{

	templateBuilder.Append("\r\n<!--普通版-->\r\n<table>\r\n<thead>\r\n<tr>\r\n<td class=\"board\">标题</td>\r\n<td class=\"topic_reply\"> 主题\r\n/\r\n帖子 </td>\r\n<td class=\"last\">最后发表</td>\r\n</tr>\r\n</thead>\r\n<tbody>\r\n"); System.Data.DataRow[] drSubList = dtBoardList.Select("ParentId="+Utils.ObjectToStr(dr["id"]), "SortId asc"); 

	foreach(DataRow drSub in drSubList)
	{

	templateBuilder.Append("\r\n<tr>\r\n<td class=\"board\"><div class=\"single_board clearfix\">\r\n<div class=\"icon\"> <a href=\"");
	templateBuilder.Append(linkurl("forum_board",Utils.ObjectToStr(drSub["id"])));

	templateBuilder.Append("\"> <img src=\"");
	templateBuilder.Append(string.IsNullOrEmpty(drSub["Icon"].ToString())?"/plugins/forum/templet/Default/Images/board_state_standard.gif":drSub["Icon"].ToString().ToString());

	templateBuilder.Append("\" alt=\"" + Utils.ObjectToStr(drSub["Name"]) + "\" /> </a> </div>\r\n<div class=\"sbc clearfix\"> <strong> <a href=\"");
	templateBuilder.Append(linkurl("forum_board",Utils.ObjectToStr(drSub["id"])));

	templateBuilder.Append("\">" + Utils.ObjectToStr(drSub["Name"]) + "</a> </strong>\r\n<div class=\"description\">\r\n<p>" + Utils.ObjectToStr(drSub["Description"]) + "</p>\r\n</div>\r\n</div>\r\n</div></td>\r\n<td class=\"topic_reply\"> " + Utils.ObjectToStr(drSub["TopicCount"]) + "\r\n/ <i>" + Utils.ObjectToStr(drSub["PostCount"]) + "</i> </td>\r\n<td class=\"last\">\r\n");
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
	else if (Utils.StrToInt(Utils.ObjectToStr(dr["ChildCount"]), 0)!=0&&Utils.StrToInt(Utils.ObjectToStr(dr["ChildCol"]), 0)>1)
	{

	templateBuilder.Append("\r\n<!--小版块-->\r\n<table>\r\n<tbody>\r\n");
	int l = Convert.ToInt32(Math.Ceiling(Convert.ToDouble( Convert.ToInt32(dr["ChildCount"]) / Convert.ToInt32(dr["ChildCol"]))));
	string ids = "0";
	string width =( 100 / Convert.ToInt32(dr["ChildCol"])).ToString();
	

	for(int i=0;i<=l;i++)
	{

	System.Data.DataRow[] drSubList = dtBoardList.Select("id not in (" + ids + ") and ParentId="+Utils.ObjectToStr(dr["id"]), "SortId asc");
	

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
	r=Convert.ToInt32(dr["ChildCol"])-s;
	if(s==Convert.ToInt32(dr["ChildCol"]))
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

	templateBuilder.Append("\r\n</div>\r\n<!--页面底部-->\r\n");

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