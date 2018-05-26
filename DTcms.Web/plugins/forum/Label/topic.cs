using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DTcms.Web.Plugin.Forum
{
    //------------------------------------------------------
    // 插件官方地址 www.dtcms-forum.net
    // 本插件开源，支持个人对插件源码修改及非盈利性平台使用
    // 如用于商业盈利性平台，需支付授权费,具体参见官网
    // 我们承接新项目开发或插件二次开发 QQ 271478027
    //------------------------------------------------------
    public partial class Label : System.Web.UI.Page
    {
        private readonly DTcms.Model.siteconfig siteConfig = new DTcms.BLL.siteconfig().loadConfig(); //获得站点配置信息 
        /// <summary>
        /// 获取主题列表
        /// </summary>
        /// <returns></returns>
        public DataTable get_topic_list(int top, string strwhere, string orderby)
        {
            DataTable dt = new DataTable();

            if (!string.IsNullOrEmpty(strwhere))
            {
                strwhere += " and ";
            }

            strwhere += " BoardId in (SELECT [Id] FROM [" + siteConfig.sysdatabaseprefix + "Forum_Board] where Show=1)";

            dt = new BLL.Forum_Topic().GetList(top, strwhere, orderby).Tables[0];

            return dt;
        }


        /// <summary>
        /// 内部是从 myTopic 获取 ，目前作用于 会员中心
        /// </summary>
        /// <returns></returns>
        public DataTable get_user_topic_list(int pageSize, int pageIndex, string strwhere, string filedOrder, out int recordCount)
        {
            DataTable dt = new DataTable();

            dt = new BLL.Forum_MyTopic().GetList(pageSize, pageIndex, strwhere, filedOrder, out  recordCount).Tables[0];

            return dt;
        }

        /// <summary>
        /// 内部是从 myPost 获取，目前作用于 会员中心
        /// </summary>
        /// <returns></returns>
        public DataTable get_user_post_list(int pageSize, int pageIndex, string strwhere, string filedOrder, out int recordCount)
        {
            DataTable dt = new DataTable();

            dt = new BLL.Forum_MyPost().GetList(pageSize, pageIndex, strwhere, filedOrder, out  recordCount).Tables[0];

            return dt;
        }

        /// <summary>
        /// 勋章，缓存，是否需要重新获取，目前作用于贴子列表
        /// </summary>
        /// <returns></returns>
        public DataTable get_medal_list(bool bol = false)
        {
            if (Model.Statistic.MedalList == null)
            {
                bol = true;
            }

            if (bol)
            {
                Model.Statistic.MedalList = new BLL.Forum_Medal().GetList(" 1=1  ").Tables[0];
            }

            return Model.Statistic.MedalList;
        }


        /// <summary>
        ///  获取附件，目前作用于帖子列表中
        /// </summary>
        /// <returns></returns>
        public DataTable get_attachment_list(int _userId, int _boardId, int _topicId, int _postId)
        {

            DataTable dt = new DataTable();

            dt = new BLL.Forum_Attachment().GetList(" [UserId]=" + _userId + " and  [BoardId]=" + _boardId + " and [TopicId]=" + _topicId + " and  [PostId]=" + _postId + " ").Tables[0];

            return dt;

        }

        /// <summary>
        /// 高亮返回的样式
        /// </summary>
        /// <returns></returns>
        public static string get_highLight_style(string str)
        {
            string _style = "";

            if (!string.IsNullOrEmpty(str))
            {
                string[] Att = str.Split(',');
                
                //粗
                if (Att[0]=="1")
                {
                    _style += "font-weight: bold;";
                }

                //斜
                if (Att[1] == "1")
                {
                    _style += "font-style: oblique;";
                }

                //删
                if (Att[2] == "1")
                {
                    _style += "text-decoration:line-through;";
                }

                //色
                if (!string.IsNullOrEmpty(Att[3]))
                {
                    _style += "color: " + Att[3] + ";";
                }

            }

            return _style;
        }

    }
}