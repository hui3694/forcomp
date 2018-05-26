using DTcms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace DTcms.Web.Plugin.Forum.Page
{
    //------------------------------------------------------
    // 插件官方地址 www.dtcms-forum.net
    // 本插件开源，支持个人对插件源码修改及非盈利性平台使用
    // 如用于商业盈利性平台，需支付授权费,具体参见官网
    // 我们承接新项目开发或插件二次开发 QQ 271478027
    //------------------------------------------------------

    public class search : ForumPage
    {

        protected int board_id = 0;//版块
        protected int page = 0;
        protected int totalcount;   //OUT数据总数
        protected string turl = "";
        protected string pagelist = "";
        protected string keys = "";//搜索

        protected bool bolOperate = false;//操作权限

        protected System.Data.DataRow[] drTopicList = null; //普通贴        

        /// <summary>
        /// 重写虚方法,此方法在Init事件执行
        /// </summary>
        protected override void InitPage()
        {
            board_id = DTRequest.GetQueryInt("board_id",0);

            keys = DTRequest.GetQueryString("keys").Replace("'", "");

            page = DTRequest.GetQueryInt("page", 1);

            string strWhere = " [Close]=0 ";

            if (board_id != 0)
            {
                strWhere += " and BoardId=" + board_id;
            }

            if (!string.IsNullOrEmpty(keys))
            {
                strWhere += " and Title like '%" + keys + "%'";
            }

            drTopicList = new BLL.Forum_Topic().GetList(25, page, strWhere, " LastPostDatetime desc ", out totalcount).Tables[0].Select(" 1=1 ", " LastPostDatetime desc ");

            pagelist = OutPageList(25, page, totalcount, linkurl("forum_search", "?keys=" + Server.UrlEncode(keys) + "&board_id=" + board_id + "&page=__id__"), 10);
            
        }
    }
}