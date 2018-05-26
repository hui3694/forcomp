using DTcms.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace DTcms.Web.Plugin.Forum.handler
{
    //------------------------------------------------------
    // 插件官方地址 www.dtcms-forum.net
    // 本插件开源，支持个人对插件源码修改及非盈利性平台使用
    // 如用于商业盈利性平台，需支付授权费,具体参见官网
    // 我们承接新项目开发或插件二次开发 QQ 271478027
    //------------------------------------------------------

    /// <summary>
    /// attachment_preview 的摘要说明
    /// </summary>
    public class attachment : IHttpHandler, IRequiresSessionState
    {

        DTcms.Model.siteconfig siteConfig = new DTcms.BLL.siteconfig().loadConfig();
        DTcms.Model.userconfig userConfig = new DTcms.BLL.userconfig().loadConfig();
        BLL.Forum_Attachment bll = new BLL.Forum_Attachment();

        Model.Forum_UserExtended modelUser;

        int aid = 0, thumb = 0;
        string sitepath = "";

        public void ProcessRequest(HttpContext context)
        {

            //取得处事类型
            string action = DTRequest.GetQueryString("action");

            modelUser = new Page.ForumPage().GetOnlineUser();

            aid = DTRequest.GetQueryInt("aid", 0);
            thumb = DTRequest.GetQueryInt("thumb", 0);
            sitepath = DTRequest.GetQueryString("site");

            if (string.IsNullOrEmpty(sitepath))
            {
                context.Response.Write("出错了，站点传输参数不正确！");
                return;
            }

            switch (action)
            {
                //下载
                case "down":
                    down(context);
                    break;
                //编主题
                case "delete":
                    delete(context);
                    break;
            }


        }

        private void down(HttpContext context)
        {

            Model.Forum_Attachment model = bll.GetModel(aid);

            if (!BLL.Forum_BoardPermission.CheckPermission(model.BoardId + "|" + modelUser.GroupId, "ViewAttachment"))
            {
                context.Response.Redirect(new Web.UI.BasePage().getlink(sitepath,
                        new Web.UI.BasePage().linkurl("error", "?msg=" + Utils.UrlEncode("出错了，你还没有下载附件的权限呢！"))));

                return;
            }


            if (model != null)
            {

                //取得文件物理路径
                string fullFileName = Utils.GetMapPath(model.FileName);
                if (!File.Exists(fullFileName))
                {
                    context.Response.Redirect(new Web.UI.BasePage().getlink(sitepath,
                        new Web.UI.BasePage().linkurl("error", "?msg=" + Utils.UrlEncode("出错了，您要下载的文件不存在或已经被删除！"))));
                    return;
                }

                model.Download += 1;
                bll.Update(model);

                FileInfo file = new FileInfo(fullFileName);//路径
                context.Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8"); //解决中文乱码
                context.Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(model.Name)); //解决中文文件名乱码    
                context.Response.AddHeader("Content-length", file.Length.ToString());
                context.Response.ContentType = "application/zip";
                context.Response.WriteFile(file.FullName);
                context.Response.End();
            }
        }

        private void delete(HttpContext context)
        {

            if (modelUser != null)
            {
                Model.Forum_Attachment model = bll.GetModel(aid);

                if (model.UserId == modelUser.UserId)
                {
                    bll.Delete(model, aid);
                    context.Response.AddHeader("Content-Type", "text/html");
                    context.Response.Write("ok!");
                    context.Response.End();
                }
            }
        }


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}