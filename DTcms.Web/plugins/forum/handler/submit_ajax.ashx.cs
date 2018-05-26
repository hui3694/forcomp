using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;
using System.Web.SessionState;
using DTcms.Web.UI;
using DTcms.Common;
using Newtonsoft.Json;

namespace DTcms.Web.Plugin.Forum.handler
{
    //------------------------------------------------------
    // 插件官方地址 www.dtcms-forum.net
    // 本插件开源，支持个人对插件源码修改及非盈利性平台使用
    // 如用于商业盈利性平台，需支付授权费,具体参见官网
    // 我们承接新项目开发或插件二次开发 QQ 271478027
    //------------------------------------------------------

    /// <summary>
    /// submit_ajax 的摘要说明
    /// </summary>
    public class submit_ajax : IHttpHandler, IRequiresSessionState
    {
        DTcms.Model.siteconfig siteConfig = new DTcms.BLL.siteconfig().loadConfig();
        DTcms.Model.userconfig userConfig = new DTcms.BLL.userconfig().loadConfig();

        Model.Forum_UserExtended modelUser;

        int board_id, topic_id, post_id, signature, autoUrl, send_message;
        string title, message, attachment_ids, turl, reason, tids, rids, user_ids, vc;

        public void ProcessRequest(HttpContext context)
        {
            //取得处事类型
            string action = DTRequest.GetQueryString("action");

            modelUser = new Page.ForumPage().GetOnlineUser();

            //除了获取会员信息外，所有都需登陆
            if (action.ToLower() != "users")
            {
                if (modelUser == null)
                {
                    JsonHelper.WriteJson(context, new
                    {
                        error = 1,
                        description = "超时了，请重新登陆！"
                    });

                    return;
                }
            }

            //公用
            turl = DTRequest.GetString("turl");
            board_id = DTRequest.GetFormIntValue("board_id", 0);
            topic_id = DTRequest.GetFormIntValue("topic_id", 0);
            post_id = DTRequest.GetFormIntValue("post_id", 0);
            vc = DTRequest.GetString("vc");
            //发贴回贴编辑贴
            title = DTRequest.GetString("title");
            message = DTRequest.GetString("message");
            attachment_ids = DTRequest.GetString("attachment_ids");
            signature = DTRequest.GetFormIntValue("signature", 0);
            autoUrl = DTRequest.GetFormIntValue("AutoUrl", 0);
            //管理贴
            tids = DTRequest.GetString("tids");
            rids = DTRequest.GetString("rids");
            send_message = DTRequest.GetFormIntValue("send_message", 0);
            reason = DTRequest.GetString("reason");

            user_ids = DTRequest.GetString("user_ids").Replace("'", "");

            switch (action)
            {
                //新主题
                case "create":
                    create(context);
                    break;
                //编主题
                case "update":
                    update(context);
                    break;
                //新回复
                case "reply":
                    reply(context);
                    break;
                //编回复
                case "editor":
                    editor(context);
                    break;

                //个人删除回复
                case "selfdelete":
                    selfdelete(context);
                    break;

                //个人删除主题
                case "selftopicdelete":
                    selftopicdelete(context);
                    break;

                //获取会员列表
                case "users":
                    users(context);
                    break;

                //金币兑换
                case "user_credit_convert":
                    user_credit_convert(context);
                    break;

                //主题置顶--------------分隔线-------------
                case "top":
                    top(context);
                    break;
                //精华设置
                case "digest":
                    digest(context);
                    break;
                //主题设置
                case "close":
                    close(context);
                    break;
                //主题高亮
                case "highlight":
                    highlight(context);
                    break;
                //主题屏蔽
                case "ban":
                    ban(context);
                    break;
                //删除主题
                case "delete":
                    delete(context);
                    break;
                //移动主题
                case "move":
                    move(context);
                    break;
                //主题分类
                case "type":
                    type(context);
                    break;
                //屏蔽回复
                case "banreply":
                    banreply(context);
                    break;
                //批删除回复
                case "deletereply":
                    deletereply(context);
                    break;
            }
        }


        #region 新主题===========================
        private void create(HttpContext context)
        {

            string _v = verify_code(context, vc);

            if (_v != "success")
            {
                JsonHelper.WriteJson(context, new
                {
                    error = 1,
                    description = _v
                });
            }

            if (string.IsNullOrEmpty(title))
            {
                JsonHelper.WriteJson(context, new
                {
                    error = 1,
                    description = "标题不能不填哦！"
                });
            }

            if (string.IsNullOrEmpty(message))
            {
                JsonHelper.WriteJson(context, new
                {
                    error = 1,
                    description = "内容不写你打算做什么呢！"
                });
            }

            if (!BLL.Forum_BoardPermission.CheckPermission(board_id + "|" + modelUser.GroupId, "PostTopic"))
            {
                JsonHelper.WriteJson(context, new
                {
                    error = 1,
                    description = "您当前还没有权限哦！"
                });
            }

            title = FilterWord(title);
            message = FilterWord(message);


            Model.Forum_Topic modelTopic = new Model.Forum_Topic();

            modelTopic.BoardId = board_id;
            modelTopic.Title = title;
            modelTopic.Message = message;

            modelTopic.PostUserId = modelUser.UserId;
            modelTopic.PostUsername = modelUser.UserName;
            modelTopic.PostNickname = modelUser.Nickname;

            modelTopic.LastPostUserId = modelUser.UserId;
            modelTopic.LastPostUsername = modelUser.UserName;
            modelTopic.LastPostNickname = modelUser.Nickname;

            modelTopic.LastPostDatetime = System.DateTime.Now;
            modelTopic.PostDatetime = System.DateTime.Now;

            int _subTable_id = 0, _post_id = 0;

            modelTopic.Id = new BLL.Forum_Topic().Add(modelTopic, out _subTable_id, out _post_id);
            modelTopic.PostId = _post_id;

            int attachment_count = 0;

            foreach (string item in context.Request.Form.AllKeys)
            {
                if (item.ToLower().IndexOf("attachment_description_") != -1)
                {
                    attachment_count += 1;

                    string strDescription = context.Request.Form[item].ToString();

                    string _id = item.ToLower().Replace("attachment_description_", "").Replace("'", "");

                    new BLL.Forum_Attachment().UpdateField("Id=" + _id, " [TopicId]=" + modelTopic.Id + ",[PostId]=" + _post_id + ",Description='" + strDescription + "' ");
                }
            }

            //new BLL.Forum_Attachment().UpdateField(" [BoardId]=" + board_id + " and [UserId]=" + modelUser.UserId + " and  [PostId]=0 ", " [TopicId]=" + modelTopic.Id + ",[PostId]=" + _post_id + " ");

            new BLL.Forum_Topic().UpdateField(modelTopic.Id, " Attachment=" + attachment_count);
            new BLL.Forum_Post(_subTable_id).UpdateField(_post_id, "Attachment=" + attachment_count);

            //统计
            DTcms.Web.Plugin.Forum.Model.Statistic.TodayPost += 1;


            //重新计算组
            HttpContext.Current.Session["SESSION_USER_EXTENDED"] = new BLL.Forum_UserExtended().SetGroupId(modelUser);


            JsonHelper.WriteJson(context, new
                   {
                       tid = modelTopic.Id,
                       turl = new DTcms.Web.UI.BasePage().linkurl("forum_topic", modelTopic.Id, 1) + "#reply_" + _post_id
                   });

        }
        #endregion

        #region 编主题===========================
        private void update(HttpContext context)
        {

            string _v = verify_code(context, vc);

            if (_v != "success")
            {
                JsonHelper.WriteJson(context, new
                {
                    error = 1,
                    description = _v
                });
            }

            if (string.IsNullOrEmpty(title))
            {
                JsonHelper.WriteJson(context, new
                {
                    error = 1,
                    description = "标题不能不填哦！"
                });
            }

            if (string.IsNullOrEmpty(message))
            {
                JsonHelper.WriteJson(context, new
                {
                    error = 1,
                    description = "内容不写你打算做什么呢！"
                });
            }

            if (!BLL.Forum_BoardPermission.CheckPermission(board_id + "|" + modelUser.GroupId, "UpdateMyselfTopic"))
            {
                JsonHelper.WriteJson(context, new
                {
                    error = 1,
                    description = "您当前还没有权限哦！"
                });
            }


            title = FilterWord(title);
            message = FilterWord(message);

            Model.Forum_Topic modelTopic = new BLL.Forum_Topic().GetModel(topic_id);

            Model.Forum_Post modelPost = new BLL.Forum_Post(modelTopic.PostSubTable).GetModel(post_id);

            modelTopic.Title = title;
            modelTopic.Message = message;

            modelPost.Title = title;
            modelPost.Message = message;


            foreach (string item in context.Request.Form.AllKeys)
            {
                if (item.ToLower().IndexOf("attachment_description_") != -1)
                {

                    string strDescription = context.Request.Form[item].ToString();

                    string _id = item.ToLower().Replace("attachment_description_", "").Replace("'", "");

                    new BLL.Forum_Attachment().UpdateField("Id=" + _id, " Description='" + strDescription + "' ");
                }
            }


            //上传图片的张数
            int attachment_count = new BLL.Forum_Attachment().GetCount(" [BoardId]=" + board_id + " and [UserId]=" + modelUser.UserId + " and  [PostId]=" + post_id + " ");

            modelTopic.Attachment = attachment_count;
            modelPost.Attachment = attachment_count;

            new BLL.Forum_Topic().Update(modelTopic, modelPost);

            JsonHelper.WriteJson(context, new
            {
                tid = modelTopic.Id,
                turl = new DTcms.Web.UI.BasePage().linkurl("forum_topic", modelTopic.Id, 1) + "#reply_" + post_id
            });

        }
        #endregion

        #region 新回复===========================
        private void reply(HttpContext context)
        {

            string _v = verify_code(context, vc);

            if (_v != "success")
            {
                JsonHelper.WriteJson(context, new
                {
                    error = 1,
                    description = _v
                });
            }


            if (string.IsNullOrEmpty(message))
            {
                JsonHelper.WriteJson(context, new
                {
                    error = 1,
                    description = "内容不写你打算做什么呢！"
                });
            }

            if (!BLL.Forum_BoardPermission.CheckPermission(board_id + "|" + modelUser.GroupId, "PostReply"))
            {
                JsonHelper.WriteJson(context, new
                {
                    error = 1,
                    description = "您当前还没有权限哦！"
                });
            }

            message = FilterWord(message);

            Model.Forum_Topic modelTopic = new BLL.Forum_Topic().GetModel(topic_id);

            int _post_id = new BLL.Forum_PostId().Add(new Model.Forum_PostId { TopicId = topic_id });

            int attachment_count = 0;

            foreach (string item in context.Request.Form.AllKeys)
            {
                if (item.ToLower().IndexOf("attachment_description_") != -1)
                {
                    attachment_count += 1;

                    string strDescription = context.Request.Form[item].ToString().Replace("'", "");

                    string _id = item.ToLower().Replace("attachment_description_", "").Replace("'", "");

                    new BLL.Forum_Attachment().UpdateField("Id=" + _id, " [TopicId]=" + modelTopic.Id + ",[PostId]=" + _post_id + " , Description='" + strDescription + "' ");
                }
            }

            //int attachment_count = new BLL.Forum_Attachment().UpdateField(" [BoardId]=" + board_id + " and [UserId]=" + modelUser.UserId + " and  [PostId]=0 ", " [TopicId]=" + modelTopic.Id + ",[PostId]=" + _post_id + " ");

            Model.Forum_Post modelPost = new Model.Forum_Post();

            modelPost.BoardId = modelTopic.BoardId;
            modelPost.Title = modelTopic.Title;
            modelPost.Signature = signature;
            modelPost.Url = autoUrl;
            modelPost.Message = message;
            modelPost.TopicId = topic_id;

            modelPost.PostUserId = modelUser.UserId;
            modelPost.PostUsername = modelUser.UserName;
            modelPost.PostNickname = modelUser.Nickname;
            modelPost.PostDateTime = System.DateTime.Now;
            modelPost.Id = _post_id;
            modelPost.Attachment = attachment_count;

            BLL.Forum_Post bll = new BLL.Forum_Post(modelTopic.PostSubTable);

            //引用
            if (post_id != 0)
            {
                Model.Forum_Post modelQuotePost = bll.GetModel(post_id);

                if (modelQuotePost != null)
                {
                    if (string.IsNullOrEmpty(modelQuotePost.QuotePostIds))
                    {
                        modelPost.QuotePostIds = modelQuotePost.Id.ToString();
                    }
                    else
                    {
                        //拼接
                        modelPost.QuotePostIds = modelQuotePost.QuotePostIds + "," + modelQuotePost.Id.ToString();
                    }

                    modelPost.QuoteUserId = modelQuotePost.PostUserId;
                    modelPost.QuoteNickname = modelQuotePost.PostNickname;
                    modelPost.QuoteMessage = modelQuotePost.Message;
                }

            }

            bll.Add(modelTopic, modelPost);

            HttpContext.Current.Session["SESSION_USER_EXTENDED"] = new BLL.Forum_UserExtended().SetGroupId(modelUser);

            JsonHelper.WriteJson(context, new
            {
                tid = modelTopic.Id,
                turl = new DTcms.Web.UI.BasePage().linkurl("forum_topic", modelTopic.Id, -_post_id) + "#reply_" + _post_id
            });

        }
        #endregion

        #region 编回复===========================
        private void editor(HttpContext context)
        {

            string _v = verify_code(context, vc);

            if (_v != "success")
            {
                JsonHelper.WriteJson(context, new
                {
                    error = 1,
                    description = _v
                });
            }

            if (string.IsNullOrEmpty(message))
            {
                JsonHelper.WriteJson(context, new
                {
                    error = 1,
                    description = "内容不写你打算做什么呢！"
                });
            }

            if (!BLL.Forum_BoardPermission.CheckPermission(board_id + "|" + modelUser.GroupId, "UpdateMyselfReply"))
            {
                JsonHelper.WriteJson(context, new
                {
                    error = 1,
                    description = "您当前还没有权限哦！"
                });
            }

            message = FilterWord(message);

            Model.Forum_Topic modelTopic = new BLL.Forum_Topic().GetModel(topic_id);

            foreach (string item in context.Request.Form.AllKeys)
            {
                if (item.ToLower().IndexOf("attachment_description_") != -1)
                {

                    string strDescription = context.Request.Form[item].ToString();

                    string _id = item.ToLower().Replace("attachment_description_", "").Replace("'", "");

                    new BLL.Forum_Attachment().UpdateField("Id=" + _id, " Description='" + strDescription + "' ");
                }
            }


            //上传图片的张数
            int attachment_count = new BLL.Forum_Attachment().GetCount(" [BoardId]=" + board_id + " and [UserId]=" + modelUser.UserId + " and  [PostId]=" + post_id + " ");

            Model.Forum_Post modelPost = new BLL.Forum_Post(modelTopic.PostSubTable).GetModel(post_id);

            modelPost.Signature = signature;
            modelPost.Url = autoUrl;
            modelPost.Message = message;

            modelPost.Attachment = attachment_count;

            new BLL.Forum_Post(modelTopic.PostSubTable).Update(modelPost);

            JsonHelper.WriteJson(context, new
            {
                tid = modelTopic.Id,
                turl = turl
            });

        }
        #endregion

        #region 主题置顶===========================
        private void top(HttpContext context)
        {
            tids = tids.Replace("'", "");

            int top = DTRequest.GetFormIntValue("top", 0);

            new BLL.Forum_Topic().UpdateField("id in (" + tids + ")", "[Top]=" + top);

            JsonHelper.WriteJson(context, new
            {
                url = turl
            });

        }
        #endregion

        #region 精华设置===========================
        private void digest(HttpContext context)
        {
            tids = tids.Replace("'", "");

            int digest = DTRequest.GetFormIntValue("digest", 0);

            new BLL.Forum_Topic().SetDigest(tids, digest);

            JsonHelper.WriteJson(context, new
            {
                url = turl
            });

        }
        #endregion

        #region 主题开关===========================
        private void close(HttpContext context)
        {

            tids = tids.Replace("'", "");

            int close = DTRequest.GetFormIntValue("close", 0);

            new BLL.Forum_Topic().UpdateField("id in (" + tids + ")", "[Close]=" + close);

            JsonHelper.WriteJson(context, new
            {
                url = turl
            });

        }
        #endregion

        #region 主题高亮===========================
        private void highlight(HttpContext context)
        {
            tids = tids.Replace("'", "");

            int highlight_style_b = DTRequest.GetFormIntValue("highlight_style_b", 0);
            int highlight_style_i = DTRequest.GetFormIntValue("highlight_style_i", 0);
            int highlight_style_u = DTRequest.GetFormIntValue("highlight_style_u", 0);
            string color = context.Request.Form["color"].Replace("'", "");

            bool bol = false;

            string val = "";

            if (highlight_style_b != 0)
            {
                bol = true;
            }

            if (highlight_style_i != 0)
            {
                bol = true;
            }

            if (highlight_style_u != 0)
            {
                bol = true;
            }

            if (!string.IsNullOrEmpty(color))
            {
                bol = true;
            }


            if (bol)
            {
                val = highlight_style_b + "," + highlight_style_i + "," + highlight_style_u + "," + color;
            }

            new BLL.Forum_Topic().UpdateField("id in (" + tids + ")", "[HighLight]='" + val + "'");

            JsonHelper.WriteJson(context, new
            {
                url = turl
            });
        }
        #endregion

        #region 主题屏蔽===========================
        private void ban(HttpContext context)
        {
            tids = tids.Replace("'", "");

            int ban = DTRequest.GetFormIntValue("Ban", 0);

            new BLL.Forum_Topic().SetBan(tids, ban);

            JsonHelper.WriteJson(context, new
            {
                url = turl
            });
        }
        #endregion

        #region 可批量删除主题===========================
        private void delete(HttpContext context)
        {
            tids = tids.Replace("'", "");

            new BLL.Forum_Topic().DeleteList(tids);

            JsonHelper.WriteJson(context, new
            {
                url = turl
            });

        }
        #endregion

        #region 删除一个主题===========================
        private void selftopicdelete(HttpContext context)
        {
            if (!BLL.Forum_BoardPermission.CheckPermission(board_id + "|" + modelUser.GroupId, "DeleteMyselfTopic"))
            {
                JsonHelper.WriteJson(context, new
                {
                    error = 1,
                    description = "您当前还没有权限哦！"
                });
            }

            tids = topic_id.ToString();

            turl = new DTcms.Web.UI.BasePage().linkurl("forum_board", board_id.ToString());

            new BLL.Forum_Topic().DeleteList(tids);

            JsonHelper.WriteJson(context, new
            {
                turl = turl
            });

        }
        #endregion

        #region 移动主题===========================
        private void move(HttpContext context)
        {
            tids = tids.Replace("'", "");

            int tobid = DTRequest.GetFormIntValue("tobid", 0);

            new BLL.Forum_Topic().SetMove(tids, board_id, tobid);

            JsonHelper.WriteJson(context, new
            {
                url = turl
            });

        }
        #endregion

        #region 主题分类===========================
        private void type(HttpContext context)
        {
        }
        #endregion

        #region 屏蔽回复===========================
        private void banreply(HttpContext context)
        {
            rids = rids.Replace("'", "");

            int ban = DTRequest.GetFormIntValue("Ban", 0);

            new BLL.Forum_Topic().SetBanReply(rids, ban, topic_id);

            JsonHelper.WriteJson(context, new
            {
                url = turl
            });

        }
        #endregion

        #region 批删除回复===========================

        private void deletereply(HttpContext context)
        {
            rids = rids.Replace("'", "");

            new BLL.Forum_Topic().DeleterReply(rids, topic_id);

            JsonHelper.WriteJson(context, new
            {
                url = turl
            });

        }
        #endregion

        #region 删除一个回复

        private void selfdelete(HttpContext context)
        {

            if (!BLL.Forum_BoardPermission.CheckPermission(board_id + "|" + modelUser.GroupId, "DeleteMyselfReply"))
            {
                JsonHelper.WriteJson(context, new
                {
                    error = 1,
                    description = "您当前还没有权限哦！"
                });
            }

            rids = post_id.ToString();

            new BLL.Forum_Topic().DeleterReply(rids, topic_id);

            HttpContext.Current.Session["SESSION_USER_EXTENDED"] = new BLL.Forum_UserExtended().SetGroupId(modelUser);

            JsonHelper.WriteJson(context, new
            {
                turl = turl
            });

        }

        #endregion

        #region 获取会员信息
        private void users(HttpContext context)
        {
            System.Data.DataTable dt = new BLL.Forum_UserExtended().GetPostList("  F.UserId in(" + user_ids.Replace("'", "") + ")").Tables[0];


            JsonHelper.WriteJson(context, dt);
        }


        #endregion

        #region 用户兑换金币=================================
        private void user_credit_convert(HttpContext context)
        {
            //检查系统是否启用兑换金币功能
            if (DTcms.Web.Plugin.Forum.Global.RateExchange == 0)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，网站未开启兑换金币功能！\"}");
                return;
            }

            if (modelUser == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，用户尚未登录或已超时！\"}");
                return;
            }
            int credit = DTRequest.GetFormInt("txtCredit");

            string password = DTRequest.GetFormString("txtPassword");

            if (modelUser.Credit < DTcms.Web.Plugin.Forum.Global.RateExchange)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，您论坛金币不足！\"}");
                return;
            }

            if (modelUser.Credit < DTcms.Web.Plugin.Forum.Global.RateExchange)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，最小兑换金币为" + DTcms.Web.Plugin.Forum.Global.RateExchange + "币！\"}");
                return;
            }

            if (credit > modelUser.Credit)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，您输入的兑换的额度大于账户上的论坛余额！\"}");
                return;
            }
            if (password == "")
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，请输入您账户的密码！\"}");
                return;
            }

            DTcms.Model.users model = new DTcms.BLL.users().GetModel(modelUser.UserId);

            //验证密码
            if (DESEncrypt.Encrypt(password, model.salt) != model.password)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，您输入的密码不正确！\"}");
                return;
            }

            BLL.Forum_UserExtended bllUser = new BLL.Forum_UserExtended();
            bllUser.UpdateField(modelUser.UserId, " Credit=Credit-" + credit + " ");


            //计算兑换后的积分值
            int convertPoint = (int)(Convert.ToDecimal(credit) / DTcms.Web.Plugin.Forum.Global.RateExchange);

            //增加积分
            int pointNewId = new DTcms.BLL.user_point_log().Add(model.id, model.user_name, convertPoint, "用户兑换论坛金币", true);

            //重新计算组
            HttpContext.Current.Session["SESSION_USER_EXTENDED"] = bllUser.SetGroupId(modelUser);

            context.Response.Write("{\"status\":1, \"msg\":\"恭喜您，积分兑换成功！\"}");
            return;
        }
        #endregion

        #region 校检网站验证码===============================
        private string verify_code(HttpContext context, string strcode)
        {
            if (string.IsNullOrEmpty(strcode))
            {
                return "对不起，请输入验证码！";
            }
            if (context.Session[DTKeys.SESSION_CODE] == null)
            {
                return "对不起，验证码超时或已过期！";
            }
            if (strcode.ToLower() != (context.Session[DTKeys.SESSION_CODE].ToString()).ToLower())
            {
                return "您输入的验证码与系统的不一致！";
            }
            context.Session[DTKeys.SESSION_CODE] = null;

            return "success";
        }
        #endregion

        #region 过滤写入的词

        public string FilterWord(string str)
        {
            if (Global.ForumWordList.Count != 0)
            {
                foreach (var item in Global.ForumWordList)
                {
                    str = str.Replace(item.Key, item.Value);
                }
            }

            return str;
        }

        #endregion


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}