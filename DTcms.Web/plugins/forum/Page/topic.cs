using DTcms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DTcms.Web.Plugin.Forum.Page
{
    //------------------------------------------------------
    // 插件官方地址 www.dtcms-forum.net
    // 本插件开源，支持个人对插件源码修改及非盈利性平台使用
    // 如用于商业盈利性平台，需支付授权费,具体参见官网
    // 我们承接新项目开发或插件二次开发 QQ 271478027
    //------------------------------------------------------

    public class topic : ForumPage
    {

        protected int board_id = 0;
        protected int topic_id = 0;
        protected int page = 0;
        protected int totalcount;   //OUT数据总数
        protected string turl = "";
        protected string pagelist = "";
        protected bool bolOperate = false;//操作权限

        protected System.Data.DataRow[] drPostList = null;

        protected Model.Forum_Board modelBoard = new Model.Forum_Board();
        protected Model.Forum_Topic modelTopic = new Model.Forum_Topic();


        /// <summary>
        /// 重写虚方法,此方法在Init事件执行
        /// </summary>
        protected override void InitPage()
        {

            topic_id = DTRequest.GetQueryInt("topic_id", 0);
            page = DTRequest.GetQueryInt("page", 1);

            if (page < 0)
            {
                page = 900000;
            }

            if (topic_id != 0)
            {

                BLL.Forum_Topic bllTopic = new BLL.Forum_Topic();


                modelTopic = bllTopic.GetModel(topic_id);

                if (modelTopic == null)
                {
                    HttpContext.Current.Response.Redirect(linkurl("error", "?msg=" + Utils.UrlEncode("我的天，贴子没啦！")));

                    return;

                    //modelTopic = new Model.Forum_Topic();
                }

                int _groupId = 0;

                if (modelUserExtended != null)
                {
                    _groupId = modelUserExtended.GroupId;
                }

                if (!BLL.Forum_BoardPermission.CheckPermission(modelTopic.BoardId + "|" + _groupId, "VisitTopic"))
                {
                    HttpContext.Current.Response.Redirect(linkurl("error", "?msg=" + Utils.UrlEncode("不好意思，目前您还没有权限进入！")));
                    return;
                }


                bool bolViewCount = false;

                //禁止过于频繁的过度刷新
                if (HttpContext.Current.Session["SESSION_FORUM_TOPIC"] == null)
                {
                    HttpContext.Current.Session["SESSION_FORUM_TOPIC"] = topic_id;

                    bolViewCount = true;
                }
                else if (Convert.ToInt32(HttpContext.Current.Session["SESSION_FORUM_TOPIC"]) != topic_id)
                {
                    bolViewCount = true;
                }

                if (bolViewCount)
                {
                    bllTopic.UpdateField(topic_id, "ViewCount=ViewCount+1");
                }

                board_id = modelTopic.BoardId;
            }

            modelBoard = new BLL.Forum_Board().GetModel(board_id);

            if (modelBoard == null)
            {
                modelBoard = new Model.Forum_Board();
            }

            drPostList = new BLL.Forum_Post(modelTopic.PostSubTable).GetList(20, page, "", topic_id, "id asc", out totalcount).Tables[0].Select(" 1=1 ", "id asc");

            pagelist = OutPageList(20, page, totalcount, linkurl("forum_topic", topic_id, "__id__"), 10);

            //权限
            bolOperate = CheckOperate(board_id);

        }

    }
}