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

    public class board : ForumPage
    {

        protected int board_id = 0;
        protected int page = 0;
        protected int totalcount;   //OUT数据总数
        protected string turl = "";
        protected string pagelist = "";
        protected bool bolOperate = false;//操作权限

        protected Model.Forum_Board modelBoard;

        protected System.Data.DataRow[] drTopList = null; //置顶贴
        protected System.Data.DataRow[] drTopicList = null; //普通贴
        protected System.Data.DataRow[] drModeratorList = null;

        /// <summary>
        /// 重写虚方法,此方法在Init事件执行
        /// </summary>
        protected override void InitPage()
        {
            board_id = DTRequest.GetQueryInt("board_id");

            modelBoard = new BLL.Forum_Board().GetModel(board_id);

            //显示列表时
            if (modelBoard.ChildCount == 0)
            {
                int _groupId = 0;

                if (modelUserExtended != null)
                {
                    _groupId = modelUserExtended.GroupId;
                }

                if (!BLL.Forum_BoardPermission.CheckPermission(board_id + "|" + _groupId, "VisitBoard"))
                {
                    HttpContext.Current.Response.Redirect(linkurl("error", "?msg=" + Utils.UrlEncode("不好意思，目前您还没有权限进入！")));
                    return;
                }
            }


            page = DTRequest.GetQueryInt("page", 1);

            drTopList = new BLL.Forum_Topic().GetTopList(board_id).Select(" 1=1 ");

            drTopicList = new BLL.Forum_Topic().GetList(25, page, " BoardId=" + board_id + " and [Top]=0 and [Id] not in (" + Global.GetForumTopTopicIds(board_id) + ")", " LastPostDatetime desc ", out totalcount).Tables[0].Select(" 1=1 ", " LastPostDatetime desc ");

            drModeratorList = new BLL.Forum_Moderator().GetList("BoardId=" + board_id).Tables[0].Select(" 1=1 ");

            pagelist = OutPageList(25, page, totalcount, linkurl("forum_board", board_id, "__id__"), 10);

            //权限
            bolOperate = CheckOperate(board_id);
        }
    }
}