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

    public class manage : ForumPage
    {
        protected int board_id = 0;
        protected int topic_id = 0;
        protected int post_id = 0;
        protected string action = "";
        protected string turl = "";

        protected string tids = "";//多标题
        protected string rids = "";//多回复

        protected System.Data.DataRow[] drSubList = null;//版块        
        protected System.Data.DataRow[] drTopicList = null;//标题 
        protected System.Data.DataRow[] drPostList = null;//贴子

        protected Model.Forum_Topic modelTopic = new Model.Forum_Topic();

        /// <summary>
        /// 重写虚方法,此方法在Init事件执行
        /// </summary>
        protected override void InitPage()
        {

            board_id = DTRequest.GetFormIntValue("board_id", 0);
            topic_id = DTRequest.GetFormIntValue("topic_id", 0);
            post_id = DTRequest.GetFormIntValue("post_id", 0);

            tids = DTRequest.GetString("tids");
            rids = DTRequest.GetString("rids");

            action = DTRequest.GetQueryString("action");


            if (string.IsNullOrEmpty(tids))
            {
                tids = topic_id.ToString();
            }

            if (string.IsNullOrEmpty(rids))
            {
                rids = post_id.ToString();
            }

            Model.Forum_Topic modelTopic = new Model.Forum_Topic();

            if (topic_id != 0)
            {
                modelTopic = new BLL.Forum_Topic().GetModel(topic_id);

                if (modelTopic == null)
                {
                    modelTopic = new Model.Forum_Topic();
                }
            }

            if (action == "move")
            {
                drSubList = new BLL.Forum_Board().GetAllList(0).Select(" 1=1 ", "SortId asc");
            }                       

            if (action != "deletereply" && action != "banreply")
            {
                drTopicList = new BLL.Forum_Topic().GetList(" id in (" + tids + ") ").Tables[0].Select(" 1=1 ", "Id asc");
            }
            else
            {
                drPostList = new BLL.Forum_Post(modelTopic.PostSubTable).GetList(" id in (" + rids + ") ").Tables[0].Select(" 1=1 ", "Id asc");
            }

            turl = Request.UrlReferrer.ToString();
        }
    }
}