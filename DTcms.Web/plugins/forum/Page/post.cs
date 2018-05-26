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

    public class post : ForumPage
    {
        protected int board_id = 0;
        protected int topic_id = 0;
        protected int post_id = 0;
        protected string action = "";
        protected string turl = "";

        protected System.Data.DataRow[] drSubList = null;
        protected System.Data.DataRow[] drAttList = null;

        protected Model.Forum_Board modelBoard = new Model.Forum_Board();
        protected Model.Forum_Topic modelTopic = new Model.Forum_Topic();
        protected Model.Forum_Post modelPost = new Model.Forum_Post();

        protected bool bolAttachment = false; //是否有上传附件的权限

        /// <summary>
        /// 重写虚方法,此方法在Init事件执行
        /// </summary>
        protected override void InitPage()
        {

            board_id = DTRequest.GetQueryInt("board_id", 0);
            topic_id = DTRequest.GetQueryInt("topic_id", 0);
            post_id = DTRequest.GetQueryInt("post_id", 0);
            action = DTRequest.GetQueryString("action");

            if (Request.UrlReferrer == null)
            {
                HttpContext.Current.Response.Redirect(linkurl("error", "?msg=" + Utils.UrlEncode("出错啦，源路异常请正确访问！")));

                return;
            }

            if (GetOnlineUser() == null)
            {
                Response.Write("<script> alert('对不起，您还未登录！');window.location.href='" + Request.UrlReferrer.ToString() + "';</script>");
                Response.End();
                return;
            }

            modelBoard = new BLL.Forum_Board().GetModel(board_id);

            if (modelBoard == null)
            {
                modelBoard = new Model.Forum_Board();
            }

            if (topic_id != 0)
            {
                modelTopic = new BLL.Forum_Topic().GetModel(topic_id);

                if (modelTopic == null)
                {
                    modelTopic = new Model.Forum_Topic();
                }
            }

            if (action != "reply")
            {
                if (post_id != 0)
                {
                    modelPost = new BLL.Forum_Post(modelTopic.PostSubTable).GetModel(post_id);

                    if (modelPost == null)
                    {
                        modelPost = new Model.Forum_Post();
                    }
                }

                if (post_id != 0)
                {
                    drAttList = new BLL.Forum_Attachment().GetList(" UserId=" + modelUserExtended.UserId + " and BoardId=" + board_id + " and TopicId=" + topic_id + " and PostId=" + post_id + " ").Tables[0].Select(" 1=1 ", "id asc");
                }
            }

            drSubList = new BLL.Forum_Board().GetAllList(board_id).Select(" 1=1 ", "SortId asc");

            turl = Request.UrlReferrer.ToString();
            

            int _groupId = 0;

            if (modelUserExtended != null)
            {
                _groupId = modelUserExtended.GroupId;
            }

            bolAttachment = BLL.Forum_BoardPermission.CheckPermission(board_id + "|" + _groupId, "UploadAttachment");

        }
    }
}