using DTcms.Common;
using System;
using System.Collections.Generic;
using System.Data;
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

    public class index : ForumPage
    {

        protected int board_id = 0;
        /// <summary>
        /// 重写虚方法,此方法将在Init事件前执行
        /// </summary>
        protected override void ShowPage()
        {
            GetStatistics(false);
            Global.GetBoardPermissionList(false);
            Global.GlobalLoad(false);
            Global.GetWordList(false);
            Global.GetActionList();
        }
    }
}