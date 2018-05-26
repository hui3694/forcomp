<%@ Page Language="C#" AutoEventWireup="true" Inherits="DTcms.Web.UI.Page.article" ValidateRequest="false" %>
<%@ Import namespace="System.Collections.Generic" %>
<%@ Import namespace="System.Text" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="DTcms.Common" %>
<script runat="server">
private const int site_id = 4;
private const string channel = "video";
override protected void OnInit(EventArgs e)
{
	base.OnInit(e);
	string cacheKey = config.cachekey + "_main_video";
	string outHtml = null;
	set_channel_model(channel);
	if (config.systemcache == 1){
		outHtml = PageCache.GetCache(cacheKey);
	}
	if(null == outHtml){
		StringBuilder templateBuilder = new StringBuilder(220000);
		
	templateBuilder.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n<head>\r\n<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />\r\n<title>");
	templateBuilder.Append(Utils.ObjectToStr(model.seo_title));
	templateBuilder.Append(" - ");
	templateBuilder.Append(Utils.ObjectToStr(site.name));
	templateBuilder.Append("</title>\r\n<meta name=\"keywords\" content=\"");
	templateBuilder.Append(Utils.ObjectToStr(model.seo_keywords));
	templateBuilder.Append("\" />\r\n<meta name=\"description\" content=\"");
	templateBuilder.Append(Utils.ObjectToStr(model.seo_description));
	templateBuilder.Append("\" />\r\n<link href=\"");
	templateBuilder.Append("/templates/main");
	templateBuilder.Append("/css/style.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n<script type=\"text/javascript\" charset=\"utf-8\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/jquery/jquery-1.11.2.min.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" charset=\"utf-8\" src=\"");
	templateBuilder.Append("/templates/main");
	templateBuilder.Append("/js/jquery.flexslider-min.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" charset=\"utf-8\" src=\"");
	templateBuilder.Append("/templates/main");
	templateBuilder.Append("/js/common.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\">\r\n$(function(){\r\n$(\".focusbox\").flexslider({\r\ndirectionNav: false,\r\npauseOnAction: false\r\n});\r\n});\r\n</");
	templateBuilder.Append("script>\r\n</head>\r\n<body>\r\n<!--Header-->\r\n");

	templateBuilder.Append("<div class=\"header\">\r\n<div class=\"header-wrap\">\r\n<div class=\"section\">\r\n<div class=\"left-box\">\r\n<a class=\"logo\" href=\"");
	templateBuilder.Append(linkurl("index"));

	templateBuilder.Append("\">");
	templateBuilder.Append(Utils.ObjectToStr(site.name));
	templateBuilder.Append("</a>\r\n<p class=\"nav\">\r\n<a href=\"");
	templateBuilder.Append(linkurl("news"));

	templateBuilder.Append("\">资讯</a>\r\n<a href=\"");
	templateBuilder.Append(linkurl("goods"));

	templateBuilder.Append("\">商城</a>\r\n<a href=\"");
	templateBuilder.Append(linkurl("video"));

	templateBuilder.Append("\">视频</a>\r\n<a href=\"");
	templateBuilder.Append(linkurl("photo"));

	templateBuilder.Append("\">图片</a>\r\n<a href=\"");
	templateBuilder.Append(linkurl("down"));

	templateBuilder.Append("\">下载</a>\r\n<a href=\"");
	templateBuilder.Append(linkurl("forum_index","index"));

	templateBuilder.Append("\">论坛</a>\r\n</p>\r\n</div>\r\n<div class=\"search\">\r\n<input id=\"keywords\" name=\"keywords\" class=\"input\" type=\"text\" onkeydown=\"if(event.keyCode==13){SiteSearch('");
	templateBuilder.Append(linkurl("search"));

	templateBuilder.Append("', '#keywords');return false};\" placeholder=\"输入回车搜索\" x-webkit-speech=\"\" />\r\n<input class=\"submit\" type=\"submit\" onclick=\"SiteSearch('");
	templateBuilder.Append(linkurl("search"));

	templateBuilder.Append("', '#keywords');\" value=\"搜索\" />\r\n</div>\r\n<div class=\"right-box\">\r\n<script type=\"text/javascript\">\r\n$.ajax({\r\ntype: \"POST\",\r\nurl: \"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/submit_ajax.ashx?action=user_check_login\",\r\ndataType: \"json\",\r\ntimeout: 20000,\r\nsuccess: function (data, textStatus) {\r\nif (data.status == 1) {\r\n$(\"#menu\").prepend('<li class=\"line\"><a href=\"");
	templateBuilder.Append(linkurl("usercenter","exit"));

	templateBuilder.Append("\">退出</a></li>');\r\n$(\"#menu\").prepend('<li class=\"login\"><em></em><a href=\"");
	templateBuilder.Append(linkurl("usercenter","index"));

	templateBuilder.Append("\">会员中心</a></li>');\r\n} else {\r\n$(\"#menu\").prepend('<li class=\"line\"><a href=\"");
	templateBuilder.Append(linkurl("register"));

	templateBuilder.Append("\">注册</a></li>');\r\n$(\"#menu\").prepend('<li class=\"login\"><em></em><a href=\"");
	templateBuilder.Append(linkurl("login"));

	templateBuilder.Append("\">登录</a></li>');\r\n}\r\n}\r\n});\r\n</");
	templateBuilder.Append("script>\r\n<ul id=\"menu\">\r\n<li>\r\n<a href=\"");
	templateBuilder.Append(linkurl("cart"));

	templateBuilder.Append("\">购物车<span id=\"shoppingCartCount\"><script type=\"text/javascript\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/submit_ajax.ashx?action=view_cart_count\"></");
	templateBuilder.Append("script></span>件</a>\r\n</li>\r\n<li><a href=\"");
	templateBuilder.Append(linkurl("content","contact"));

	templateBuilder.Append("\">联系我们</a></li>\r\n</ul>\r\n</div>\r\n</div>\r\n</div>\r\n</div>");


	templateBuilder.Append("\r\n<!--/Header-->\r\n<div class=\"section clearfix\">\r\n<div class=\"line15\"></div>\r\n<div class=\"wrapper clearfix\">\r\n<div class=\"main-left\">\r\n<div class=\"focusbox\">\r\n<ul class=\"slides\">\r\n");
	DataTable focusList = get_article_list(channel, 0, 5, "status=0 and is_slide=1");

	foreach(DataRow dr in focusList.Rows)
	{

	templateBuilder.Append("\r\n<li>\r\n<a title=\"" + Utils.ObjectToStr(dr["title"]) + "\" href=\"");
	templateBuilder.Append(linkurl("video_show",Utils.ObjectToStr(dr["id"])));

	templateBuilder.Append("\">\r\n<span class=\"note-bg\"></span>\r\n<span class=\"note-txt\">" + Utils.ObjectToStr(dr["title"]) + "</span>\r\n<img src=\"" + Utils.ObjectToStr(dr["img_url"]) + "\" />\r\n</a>\r\n</li>\r\n");
	}	//end for if

	templateBuilder.Append("\r\n</ul>\r\n</div>\r\n</div>\r\n<div class=\"main-right\">\r\n<ul class=\"img-list ilist\">\r\n");
	DataTable redList = get_article_list(channel, 0, 6, "status=0 and is_red=1");

	foreach(DataRow dr in redList.Rows)
	{

	templateBuilder.Append("\r\n<li>\r\n<a title=\"" + Utils.ObjectToStr(dr["title"]) + "\" href=\"");
	templateBuilder.Append(linkurl("video_show",Utils.ObjectToStr(dr["id"])));

	templateBuilder.Append("\">\r\n<em></em>\r\n<span class=\"abs-bg\"></span>\r\n<span class=\"txt1\">" + Utils.ObjectToStr(dr["title"]) + "</span>\r\n<span class=\"txt2\">\r\n<p>" + Utils.ObjectToStr(dr["sub_title"]) + "</p>\r\n</span>\r\n<img src=\"" + Utils.ObjectToStr(dr["img_url"]) + "\" />\r\n</a>\r\n</li>\r\n");
	}	//end for if

	templateBuilder.Append("\r\n</ul>\r\n</div>\r\n</div>\r\n</div>\r\n<!--分类列表-->\r\n");
	DataTable categoryList = get_category_child_list(channel,0);

	foreach(DataRow cdr in categoryList.Rows)
	{

	templateBuilder.Append("\r\n<div class=\"section clearfix\">\r\n<div class=\"ntitle\">\r\n<h2>\r\n<a href=\"");
	templateBuilder.Append(linkurl("video_list",Utils.ObjectToStr(cdr["id"])));

	templateBuilder.Append("\">" + Utils.ObjectToStr(cdr["title"]) + "<em></em></a>\r\n</h2>\r\n<p>\r\n<!--小类-->\r\n");
	DataTable bcategoryList = get_category_child_list(channel,Utils.StrToInt(Utils.ObjectToStr(cdr["id"]), 0));

	int cdr2__loop__id=0;
	foreach(DataRow cdr2 in bcategoryList.Rows)
	{
		cdr2__loop__id++;


	if (cdr2__loop__id==1)
	{

	templateBuilder.Append("\r\n<a class=\"no-bg\" href=\"");
	templateBuilder.Append(linkurl("video_list",Utils.ObjectToStr(cdr2["id"])));

	templateBuilder.Append("\">" + Utils.ObjectToStr(cdr2["title"]) + "</a>\r\n");
	}
	else
	{

	templateBuilder.Append("\r\n<a href=\"");
	templateBuilder.Append(linkurl("video_list",Utils.ObjectToStr(cdr2["id"])));

	templateBuilder.Append("\">" + Utils.ObjectToStr(cdr2["title"]) + "</a>\r\n");
	}	//end for if

	}	//end for if

	templateBuilder.Append("\r\n</p>\r\n</div>\r\n<div class=\"wrapper clearfix\">\r\n<ul class=\"img-list high ilist\">\r\n");
	DataTable dt = get_article_list(channel, Utils.StrToInt(Utils.ObjectToStr(cdr["id"]), 0), 5, "status=0");

	foreach(DataRow dr1 in dt.Rows)
	{

	templateBuilder.Append("\r\n<li>\r\n<a title=\"" + Utils.ObjectToStr(dr1["title"]) + "\" href=\"");
	templateBuilder.Append(linkurl("video_show",Utils.ObjectToStr(dr1["id"])));

	templateBuilder.Append("\">\r\n<em></em>\r\n<span class=\"abs-bg\"></span>\r\n<span class=\"txt1\">" + Utils.ObjectToStr(dr1["title"]) + "</span>\r\n<span class=\"txt2\">\r\n<p>" + Utils.ObjectToStr(dr1["sub_title"]) + "</p>\r\n</span>\r\n<img src=\"" + Utils.ObjectToStr(dr1["img_url"]) + "\" />\r\n</a>\r\n</li>\r\n");
	}	//end for if

	templateBuilder.Append("\r\n</ul>\r\n</div>\r\n</div>\r\n");
	}	//end for if

	templateBuilder.Append("\r\n<!--/分类列表-->\r\n<!--Footer-->\r\n");

	templateBuilder.Append("<div class=\"footer clearfix\">\r\n<div class=\"foot-nav\">\r\n");
	DataTable footMenu = get_plugin_method("DTcms.Web.Plugin.Menu", "menu", "get_menu_list", 3, 0);

	foreach(DataRow dr in footMenu.Rows)
	{

	templateBuilder.Append("\r\n<a href=\"" + Utils.ObjectToStr(dr["link_url"]) + "\" target=\"" + Utils.ObjectToStr(dr["target"]) + "\" title=\"" + Utils.ObjectToStr(dr["title"]) + "\">" + Utils.ObjectToStr(dr["title"]) + "</a>\r\n");
	}	//end for if

	templateBuilder.Append("\r\n</div>\r\n<div class=\"copyright\">\r\n<p>版权所有 ");
	templateBuilder.Append(site.company.ToString());

	templateBuilder.Append(" <a href=\"http://www.miibeian.gov.cn/\" target=\"_blank\" rel=\"nofollow\">");
	templateBuilder.Append(Utils.ObjectToStr(site.crod));
	templateBuilder.Append("</a> DTcms版本号：");
	templateBuilder.Append(Utils.GetVersion().ToString());

	templateBuilder.Append("</p>\r\n<p>");
	templateBuilder.Append(site.copyright.ToString());

	templateBuilder.Append("</p>\r\n<p><script src=\"http://s24.cnzz.com/stat.php?id=1996164&web_id=1996164&show=pic\" language=\"javascript\"></");
	templateBuilder.Append("script></p>\r\n</div>\r\n</div>\r\n<script src=\"/plugins/qqonline/skin/js/qqonline.js\" language=\"javascript\"></");
	templateBuilder.Append("script>");


	templateBuilder.Append("\r\n<!--/Footer-->\r\n</body>\r\n</html>");
		outHtml = templateBuilder.ToString();
		PageCache.WriteCache(outHtml, config.systemcache, config.cachetime, cacheKey, config.fomatpage);
	}
	Response.Write(outHtml);
}
</script>