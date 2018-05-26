using DTcms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DTcms.Web.Plugin.Forum.handler
{
    //------------------------------------------------------
    // 插件官方地址 www.dtcms-forum.net
    // 本插件开源，支持个人对插件源码修改及非盈利性平台使用
    // 如用于商业盈利性平台，需支付授权费,具体参见官网
    // 我们承接新项目开发或插件二次开发 QQ 271478027
    //------------------------------------------------------

    /// <summary>
    /// avatar 的摘要说明
    /// </summary>
    public class avatar : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //取得处事类型
            int uid = DTRequest.GetQueryInt("uid", 0);
            int size = DTRequest.GetQueryInt("size", 50);

            DTcms.Model.users userModel = new DTcms.BLL.users().GetModel(uid);

            string _avatar = "/plugins/forum/templet/Default/Images/avatar_none_" + size + ".jpg";

            if (userModel != null)
            {
                if (!string.IsNullOrEmpty(userModel.avatar))
                {
                    _avatar = userModel.avatar;
                }
            }

            context.Response.Redirect(_avatar);
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