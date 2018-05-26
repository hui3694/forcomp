<%@ Page Language="C#" AutoEventWireup="true" Inherits="DTcms.Web.Plugin.Forum.Page.post" ValidateRequest="false" %>
<%@ Import namespace="System.Collections.Generic" %>
<%@ Import namespace="System.Text" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="DTcms.Common" %>
<script runat="server">
override protected void OnInit(EventArgs e)
{
	base.OnInit(e);
	StringBuilder templateBuilder = new StringBuilder(220000);
	
	templateBuilder.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\" >\r\n<head>\r\n<meta http-equiv=\"Content-Type\" content=\"text/html;charset=utf-8\" />\r\n<title>主题 - ");
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


	templateBuilder.Append("\r\n<!--/页面头部-->\r\n<script src=\"");
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
	templateBuilder.Append("plugins/forum/templet/Default/scripts/json2.js\" type=\"text/javascript\"></");
	templateBuilder.Append("script>\r\n<script src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("plugins/forum/templet/Default/scripts/jquery-tmpl/jquery.tmpl.js\" type=\"text/javascript\"></");
	templateBuilder.Append("script>\r\n");
	if (action=="selfdelete")
	{

	templateBuilder.Append("\r\n<form id=\"delPost\" method=\"post\" action=\"#\" >\r\n<input name=\"board_id\" type=\"hidden\" value=\"");
	templateBuilder.Append(board_id.ToString());

	templateBuilder.Append("\" />\r\n<input name=\"topic_id\" type=\"hidden\" value=\"");
	templateBuilder.Append(topic_id.ToString());

	templateBuilder.Append("\" />\r\n<input name=\"post_id\" type=\"hidden\" value=\"");
	templateBuilder.Append(post_id.ToString());

	templateBuilder.Append("\" />\r\n<input name=\"action\" type=\"hidden\" value=\"");
	templateBuilder.Append(action.ToString());

	templateBuilder.Append("\" />\r\n<input name=\"turl\" type=\"hidden\" value=\"");
	templateBuilder.Append(Utils.ObjectToStr(turl));
	templateBuilder.Append("\" />\r\n<div class=\"wrap\">\r\n<div class=\"box_panel message_panel\">\r\n<div class=\"box_panel_title\"> 提示 </div>\r\n<div class=\"box_panel_context\">\r\n<p class=\"info\">删除成功</p>\r\n<p><a href=\"");
	templateBuilder.Append(Utils.ObjectToStr(turl));
	templateBuilder.Append("\">3 秒后未自动跳转,请点击这里.</a></p>\r\n<p class=\"b sp\"> <a href=\"/\">返回首页</a> </p>\r\n</div>\r\n</div>\r\n</div>\r\n<script type=\"text/javascript\">\r\n$(document).ready(function () {\r\nsetTimeout(function(){\r\nSubmitForm();\r\n},2000)\r\n});\r\nfunction SubmitForm()\r\n{\r\nvar formParam = $(\"#delPost\").serialize();\r\n$.ajax({\r\ntype: 'POST',\r\nurl: \"/plugins/forum/handler/submit_ajax.ashx?action=");
	templateBuilder.Append(action.ToString());

	templateBuilder.Append("\",\r\ndata: formParam ,\r\ndataType:'json',\r\nsuccess:function(responseText) {\r\nif (!responseText.error) {\r\nwindow.top.location.replace(responseText.turl);\r\nreturn;\r\n}\r\neasyDialog.open({ container: { header: '提示', content: responseText.description, noFn: true } });\r\n},\r\nerror : function() {\r\neasyDialog.open({ container: { header: '提示', content: '服务器通讯失败', noFn: true } });\r\n}\r\n});\r\n}\r\n</");
	templateBuilder.Append("script>\r\n</form>\r\n");
	}
	else if (action=="selftopicdelete")
	{

	templateBuilder.Append("\r\n<form id=\"delTopic\" method=\"post\" action=\"#\" >\r\n<input name=\"board_id\" type=\"hidden\" value=\"");
	templateBuilder.Append(board_id.ToString());

	templateBuilder.Append("\" />\r\n<input name=\"topic_id\" type=\"hidden\" value=\"");
	templateBuilder.Append(topic_id.ToString());

	templateBuilder.Append("\" />\r\n<input name=\"post_id\" type=\"hidden\" value=\"");
	templateBuilder.Append(post_id.ToString());

	templateBuilder.Append("\" />\r\n<input name=\"action\" type=\"hidden\" value=\"");
	templateBuilder.Append(action.ToString());

	templateBuilder.Append("\" />\r\n<input name=\"turl\" type=\"hidden\" value=\"");
	templateBuilder.Append(Utils.ObjectToStr(turl));
	templateBuilder.Append("\" />\r\n<div class=\"wrap\">\r\n<div class=\"box_panel message_panel\">\r\n<div class=\"box_panel_title\"> 提示 </div>\r\n<div class=\"box_panel_context\">\r\n<p class=\"info\">删除成功</p>\r\n<p><a href=\"");
	templateBuilder.Append(Utils.ObjectToStr(turl));
	templateBuilder.Append("\">3 秒后未自动跳转,请点击这里.</a></p>\r\n<p class=\"b sp\"> <a href=\"/\">返回首页</a> </p>\r\n</div>\r\n</div>\r\n</div>\r\n<script type=\"text/javascript\">\r\n$(document).ready(function () {\r\nsetTimeout(function(){\r\nSubmitForm();\r\n},2000)\r\n});\r\nfunction SubmitForm()\r\n{\r\nvar formParam = $(\"#delTopic\").serialize();\r\n$.ajax({\r\ntype: 'POST',\r\nurl: \"/plugins/forum/handler/submit_ajax.ashx?action=");
	templateBuilder.Append(action.ToString());

	templateBuilder.Append("\",\r\ndata: formParam ,\r\ndataType:'json',\r\nsuccess:function(responseText) {\r\nif (!responseText.error) {\r\nwindow.top.location.replace(responseText.turl);\r\nreturn;\r\n}\r\neasyDialog.open({ container: { header: '提示', content: responseText.description, noFn: true } });\r\n},\r\nerror : function() {\r\neasyDialog.open({ container: { header: '提示', content: '服务器通讯失败', noFn: true } });\r\n}\r\n});\r\n}\r\n</");
	templateBuilder.Append("script>\r\n</form>\r\n");
	}
	else
	{

	templateBuilder.Append("\r\n<form id=\"post\" method=\"post\" action=\"#\" onsubmit=\"return nsubmit();\">\r\n<input id=\"board_id\" name=\"board_id\" type=\"hidden\" value=\"");
	templateBuilder.Append(board_id.ToString());

	templateBuilder.Append("\" />\r\n<input id=\"topic_id\" name=\"topic_id\" type=\"hidden\" value=\"");
	templateBuilder.Append(topic_id.ToString());

	templateBuilder.Append("\" />\r\n<input id=\"post_id\" name=\"post_id\" type=\"hidden\" value=\"");
	templateBuilder.Append(post_id.ToString());

	templateBuilder.Append("\" />\r\n<input id=\"action\" name=\"action\" type=\"hidden\" value=\"");
	templateBuilder.Append(action.ToString());

	templateBuilder.Append("\" />\r\n<input id=\"turl\" name=\"turl\" type=\"hidden\" value=\"");
	templateBuilder.Append(Utils.ObjectToStr(turl));
	templateBuilder.Append("\" />\r\n<div class=\"wrap\">\r\n<div class=\"box_panel postTopicPanel sp\">\r\n<div class=\"box_panel_title\">\r\n");
	if (action=="create")
	{

	templateBuilder.Append("\r\n主题\r\n");
	}
	else if (action=="update")
	{

	templateBuilder.Append("\r\n编辑主题\r\n");
	}
	else if (action=="reply")
	{

	if (post_id==0)
	{

	templateBuilder.Append("\r\n回复\r\n");
	}
	else
	{

	templateBuilder.Append("\r\n引用回复\r\n");
	}	//end for if

	}
	else if (action=="editor")
	{

	templateBuilder.Append("\r\n编辑回复\r\n");
	}	//end for if

	templateBuilder.Append("\r\n</div>\r\n<div class=\"box_panel_context\">\r\n<div class=\"editor_mainx\">\r\n<div class=\"name\">\r\n");
	if (action=="create")
	{

	if (modelBoard.ChildCount!=0)
	{

	templateBuilder.Append("\r\n<select name=\"topic_type_id\">\r\n");
	foreach(DataRow drSub in drSubList)
	{

	templateBuilder.Append("\r\n<option value=\"" + Utils.ObjectToStr(drSub["id"]) + "\">" + Utils.ObjectToStr(drSub["Name"]) + "</option>\r\n");
	}	//end for if

	templateBuilder.Append("\r\n</select>\r\n");
	}	//end for if

	}	//end for if

	templateBuilder.Append("\r\n<input class=\"text\" id=\"input_title\" name=\"title\" size=\"60\" type=\"text\" ");
	templateBuilder.Append(action=="reply"?"disabled='disabled'":"".ToString());

	templateBuilder.Append(action=="editor"?"disabled='disabled'":"".ToString());

	templateBuilder.Append(" value=\"");
	templateBuilder.Append(Utils.ObjectToStr(modelTopic.Title));
	templateBuilder.Append("\" />\r\n</div>\r\n<div class=\"editor\">\r\n<script type=\"text/plain\" id=\"postEditor\" style=\"width:100%;height:240px;\">");
	templateBuilder.Append(Utils.ObjectToStr(modelPost.Message));
	templateBuilder.Append("</");
	templateBuilder.Append("script>\r\n<div class=\"editor_loading\">&nbsp;</div>\r\n<textarea name=\"message\" id = \"textarea_message\" class = \"TextField editor\" cols = \"60\" rows = \"20\" style=\"visibility: hidden; display: none;\"></textarea>\r\n</div>\r\n<div class=\"options clearfix\" style=\"display:none;\">\r\n<ul>\r\n<li>\r\n<label>\r\n<input name=\"signature\" type=\"checkbox\" value=\"1\" ");
	templateBuilder.Append(modelPost.Signature==1?"checked":"".ToString());

	templateBuilder.Append("/>\r\n设置 签名 </label>\r\n</li>\r\n<li>\r\n<label>\r\n<input name=\"AutoUrl\" type=\"checkbox\" value=\"1\" ");
	templateBuilder.Append(modelPost.Url==1?"checked":"".ToString());

	templateBuilder.Append(" />\r\n网址自动识别 </label>\r\n</li>\r\n</ul>\r\n</div>\r\n<div id=\"attachment_list\" style=\"");
	templateBuilder.Append(!bolAttachment?"display:none;":"".ToString());

	templateBuilder.Append("\" class=\"attachment_list\">\r\n<div class=\"attachment_msg\"> <span id=\"spanSWFUploadButton\">上传附件</span> </div>\r\n<div class=\"aaa\">\r\n<table cellspacing=\"0\" cellpadding=\"0\" class=\"line\" width=\"100%\">\r\n<thead>\r\n<tr class=\"title\">\r\n<td class=\"title\" width=\"400\"> 附件文件 </td>\r\n<td class=\"title\"> 描述 </td>\r\n<td class=\"title\" style=\"width:80px;\">操作</td>\r\n</tr>\r\n</thead>\r\n<tbody id=\"attachment\">\r\n</tbody>\r\n</table>\r\n</div>\r\n<div id=\"attachment_queue\">\r\n<!--\r\n<div class=\"attachment_item\">\r\n<div class=\"attachment_file\">xxx</div>\r\n<div class=\"attachment_action\">cancel</div>\r\n<div class=\"progress\"><div class=\"progress_bar\"></div></div>\r\n</div>\r\n-->\r\n</div>\r\n<div class=\"attachment_msg\" style=\"display:none;\"> 您今日还可上传 <font color=\"red\">1 MB</font> </div>\r\n</div>\r\n<div class=\"options\">\r\n<input class=\"vc text\" id=\"vc\" name=\"vc\" size=\"4\" style=\"text-transform:uppercase;\" tabindex=\"3\" type=\"text\" value=\"\" />\r\n<img id=\"vcimg\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("plugins/forum/templet/Default/images/loading.gif\" alt=\"Loading\" /> <a href=\"#\" id=\"vcimgc\" tabindex=\"6\">看不清,换一张</a> </div>\r\n</div>\r\n<div class=\"action\">\r\n<button type=\"submit\" name=\"Ok\" class=\"button skyblue\">确认发布</button>\r\n[可以编辑内容区,完成编辑后可按 Ctrl+Enter 发布] </div>\r\n</div>\r\n</div>\r\n</div>\r\n<script src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("plugins/forum/templet/Default/scripts/shadowbox/shadowbox.js\" type=\"text/javascript\"></");
	templateBuilder.Append("script>\r\n<script src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("plugins/forum/templet/Default/scripts/jquery.swfupload/swfupload.js\" type=\"text/javascript\"></");
	templateBuilder.Append("script>\r\n<script src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("plugins/forum/templet/Default/scripts/jquery.swfupload/plugins/swfupload.queue.js\" type=\"text/javascript\"></");
	templateBuilder.Append("script>\r\n<script src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("plugins/forum/templet/Default/scripts/jquery.swfupload/plugins/swfupload.swfobject.js\" type=\"text/javascript\"></");
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
	templateBuilder.Append("script>\r\n<script id=\"attathmentRowTemplate\" type=\"text/x-jquery-tmpl\">\r\n<tr id=\"att_$");
	templateBuilder.Append("{".ToString());

	templateBuilder.Append("aid}\">\r\n<td>\r\n<a href=\"#\" data-attachment-act=\"insert\">$");
	templateBuilder.Append("{".ToString());

	templateBuilder.Append("name}</a>\r\n");
	templateBuilder.Append("{{".ToString());

	templateBuilder.Append("if isimage==true}}\r\n<!--\r\n<a class=\"attachment_image\" data-pop-id=\"ei_$");
	templateBuilder.Append("{".ToString());

	templateBuilder.Append("aid}\" title=\"预览\">[预览]</a>\r\n<div id=\"ei_$");
	templateBuilder.Append("{".ToString());

	templateBuilder.Append("aid}\" class=\"pop_panel\">\r\n<div class=\"content\" style=\"padding:5px;font-size:0;line-height:0;\">\r\n<img src=\"$");
	templateBuilder.Append("{".ToString());

	templateBuilder.Append("turl}\" />\r\n</div>\r\n</div>\r\n-->\r\n");
	templateBuilder.Append("{{".ToString());

	templateBuilder.Append("/if}}\r\n<input type=\"hidden\" name=\"attachment_ids\" value=\"$");
	templateBuilder.Append("{".ToString());

	templateBuilder.Append("aid}\">\r\n</td>\r\n<td>\r\n<input type=\"text\" name=\"attachment_description_$");
	templateBuilder.Append("{".ToString());

	templateBuilder.Append("aid}\" class=\"TextField\" style=\"width:100%;\" value=\"$");
	templateBuilder.Append("{".ToString());

	templateBuilder.Append("description}\" />\r\n</td>\r\n<td>\r\n<!--<a href=\"#\" title=\"插入到内容中\" data-attachment-act=\"insert\" >插入</a>&nbsp;|&nbsp;-->\r\n<a href=\"#\" title=\"删除\" data-attachment-act=\"remove\" >删除</a>\r\n</td>\r\n</tr>\r\n</");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\">\r\nfunction set_attachment(add_attachment)\r\n{\r\n");
	if (action!="reply")
	{

	if (post_id!=0)
	{

	foreach(DataRow dr in drAttList)
	{

	templateBuilder.Append("\r\nadd_attachment({ aid: " + Utils.ObjectToStr(dr["id"]) + ", isimage: " + Utils.ObjectToStr(dr["isimage"]) + ", name: \"" + Utils.ObjectToStr(dr["name"]) + "\", description: \"" + Utils.ObjectToStr(dr["description"]) + "\", cost: \"" + Utils.ObjectToStr(dr["cost"]) + "\" });\r\n");
	}	//end for if

	}	//end for if

	}	//end for if

	templateBuilder.Append("\r\n}\r\n</");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("plugins/forum/templet/Default/Scripts/Post.js\"></");
	templateBuilder.Append("script>\r\n</form>\r\n");
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