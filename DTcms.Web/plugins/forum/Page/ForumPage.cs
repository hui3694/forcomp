using DTcms.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace DTcms.Web.Plugin.Forum.Page
{
    //------------------------------------------------------
    // 插件官方地址 www.dtcms-forum.net
    // 本插件开源，支持个人对插件源码修改及非盈利性平台使用
    // 如用于商业盈利性平台，需支付授权费,具体参见官网
    // 我们承接新项目开发或插件二次开发 QQ 271478027
    //------------------------------------------------------

    public class ForumPage : Web.UI.BasePage
    {
        protected Model.Forum_UserExtended modelUserExtended;

        /// <summary>
        /// 重写父类的虚方法,此方法将在Init事件前执行
        /// </summary>
        protected override void ShowPage()
        {
            this.Init += new EventHandler(Page_Init); //加入IInit事件            
        }

        /// <summary>
        /// OnInit事件,检查用户是否登录
        /// </summary>
        void Page_Init(object sender, EventArgs e)
        {

            //今日统计
            Global.BoardTodayTopicCount(false);
            //获得登录用户信息
            GetOnlineUser();

            InitPage();
        }


        /// <summary>
        /// 构建一个虚方法，供子类重写
        /// </summary>
        protected virtual void InitPage()
        {
            //无任何代码
        }


        /// <summary>
        /// 获取统计数据，首页中的计数，每减少数据库的操作，每24小时实际读取一次数据库,参数默认 false 不用强制更新数据
        /// </summary>
        /// <param name="bol"></param>
        public void GetStatistics(bool bol = false)
        {
            DateTime dt = DateTime.Now;
            TimeSpan ts = dt - Model.Statistic.RefreshTime;

            if (ts.TotalSeconds > 86400.0)
            {
                bol = true;
            }

            if (bol)
            {
                Model.Statistic.TotalUser = new BLL.Forum_UserExtended().GetTotal(" 1=1 ");

                //贴子
                Model.Statistic.TotalPost = new BLL.Forum_Topic().GetTotal(" 1=1 ");
                //昨日
                Model.Statistic.YesterdayPost = new BLL.Forum_Topic().GetTotal(" PostDatetime>'" + System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd 00:00:01") + "' and  PostDatetime<'" + System.DateTime.Now.ToString("yyyy-MM-dd 00:00:01") + "' ");
                //今日
                Model.Statistic.TodayPost = new BLL.Forum_Topic().GetTotal(" PostDatetime>'" + System.DateTime.Now.ToString("yyyy-MM-dd 00:00:01") + "' ");

                System.Data.DataTable dtUser = new DTcms.BLL.users().GetList(1, " status=0  ", " id desc ").Tables[0];

                if (dtUser.Rows.Count != 0)
                {
                    Model.Statistic.LastUserId = Convert.ToInt32(dtUser.Rows[0]["id"].ToString());
                    Model.Statistic.LastUserNickname = string.IsNullOrEmpty(dtUser.Rows[0]["nick_name"].ToString()) ? dtUser.Rows[0]["user_name"].ToString() : dtUser.Rows[0]["nick_name"].ToString();
                }

                Model.Statistic.RefreshTime = System.DateTime.Now;

            }
        }

        /// <summary>
        /// 获取当前在线会员
        /// </summary>
        /// <returns></returns>
        public Model.Forum_UserExtended GetOnlineUser()
        {
            DTcms.Model.users model = GetUserInfo();

            if (model != null)
            {
                //论坛扩展当前在线用户是否存在
                if (HttpContext.Current.Session["SESSION_USER_EXTENDED"] != null)
                {
                    modelUserExtended = (Model.Forum_UserExtended)HttpContext.Current.Session["SESSION_USER_EXTENDED"];

                    //论坛与DTcms 是否一致
                    if (modelUserExtended.UserId != model.id)
                    {
                        modelUserExtended = null;
                    }
                }


                if (modelUserExtended == null)
                {
                    modelUserExtended = new BLL.Forum_UserExtended().GetModel(model.id);

                    if (modelUserExtended != null)
                    {
                        //组名提取
                        modelUserExtended.GroupName = new BLL.Forum_Group().GetModel(modelUserExtended.GroupId).Name;
                        modelUserExtended.UserName = model.user_name;
                    }
                    else
                    {
                        //新增

                        modelUserExtended = new Model.Forum_UserExtended();

                        modelUserExtended.UserId = model.id;
                        modelUserExtended.UserName = model.user_name;
                        modelUserExtended.Nickname = string.IsNullOrEmpty(model.nick_name) ? model.user_name : model.nick_name;
                        modelUserExtended.Birthday = model.birthday.ToString();
                        modelUserExtended.Credit = 0;
                        modelUserExtended.CreditTotal = 0;

                        modelUserExtended.Gender = ChangeSex(model.sex);

                        modelUserExtended.QQ = model.qq;
                        modelUserExtended.Photo = model.avatar;
                        modelUserExtended.MSN = model.msn;
                        modelUserExtended.GroupId = 0;
                        modelUserExtended.OnlineUpdateTime = System.DateTime.Now;
                        modelUserExtended.OnlineTime = 1;


                        System.Data.DataTable dt = new BLL.Forum_Group().GetList("IsDefault=1").Tables[0];

                        if (dt.Rows.Count != 0)
                        {
                            modelUserExtended.GroupId = Convert.ToInt32(dt.Rows[0]["id"]);
                            modelUserExtended.GroupName = dt.Rows[0]["Name"].ToString();
                        }

                        new BLL.Forum_UserExtended().Add(modelUserExtended);

                        Model.Statistic.LastUserNickname = string.IsNullOrEmpty(model.nick_name) ? model.user_name : model.nick_name;
                        Model.Statistic.LastUserId = model.id;
                    }
                }


                int _sex = ChangeSex(model.sex);

                bool bol = false;

                //性别有改动
                if (modelUserExtended.Gender != _sex)
                {
                    modelUserExtended.Gender = _sex;
                    bol = true;
                }

                //昵称有改动
                if (modelUserExtended.Nickname != model.nick_name)
                {
                    if (!string.IsNullOrEmpty(model.nick_name))
                    {
                        modelUserExtended.Nickname = model.nick_name;
                        bol = true;
                    }
                }

                if (bol)
                {
                    new BLL.Forum_UserExtended().Update(modelUserExtended);
                }

                HttpContext.Current.Session["SESSION_USER_EXTENDED"] = modelUserExtended;

            }
            else
            {
                HttpContext.Current.Session["SESSION_USER_EXTENDED"] = null;
                modelUserExtended = null;
            }

            return modelUserExtended;
        }


        /// <summary>
        /// 性别 汉字转数字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public int ChangeSex(string str)
        {

            if (str == "保密")
            {
                return -1;
            }
            else if (str == "男")
            {
                return 1;
            }
            else if (str == "女")
            {
                return 0;
            }

            return -1;
        }

        /// <summary>
        /// 当前用户是否对标题有权限操作
        /// </summary>
        /// <returns></returns>
        public bool CheckOperate(int BoardId)
        {
            bool bol = false;

            Model.Forum_UserExtended model = GetOnlineUser();

            if (model != null)
            {
                Model.Forum_Group modelGroup = new BLL.Forum_Group().GetModel(model.GroupId);

                if (modelGroup.Type <= 2)
                {
                    bol = true;
                }
                else
                {
                    bol = new BLL.Forum_Moderator().Exists(BoardId, model.UserId);
                }
            }

            return bol;
        }


        #region 显示分页
        /// <summary>
        /// 返回分页页码
        /// </summary>
        /// <param name="pageSize">页面大小</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="totalCount">总记录数</param>
        /// <param name="linkUrl">链接地址，__id__代表页码</param>
        /// <param name="centSize">中间页码数量</param>
        /// <returns></returns>
        public static string OutPageList(int pageSize, int pageIndex, int totalCount, string linkUrl, int centSize)
        {
            //计算页数
            if (totalCount < 1 || pageSize < 1)
            {
                return "";
            }
            int pageCount = totalCount / pageSize;
            if (pageCount < 1)
            {
                pageCount = 1;
            }
            else if (totalCount % pageSize > 0)
            {
                pageCount += 1;
            }

            if (pageIndex == 900000)
            {
                pageIndex = pageCount;
            }

            //if (pageCount <= 1)
            //{
            //    return "";
            //}
            StringBuilder pageStr = new StringBuilder();
            string pageId = "__id__";
            //string firstBtn = "<a href=\"" + Utils.ReplaceStr(linkUrl, pageId, (pageIndex - 1).ToString()) + "\">上一页</a>";
            //string lastBtn = "<a href=\"" + Utils.ReplaceStr(linkUrl, pageId, (pageIndex + 1).ToString()) + "\">下一页</a>";
            string firstStr = "<li><a href=\"" + Utils.ReplaceStr(linkUrl, pageId, "1") + "\">1</a></li>";
            string lastStr = "<li><a href=\"" + Utils.ReplaceStr(linkUrl, pageId, pageCount.ToString()) + "\">" + pageCount.ToString() + "</a></li>";

            if (pageIndex <= 1)
            {
                //firstBtn = "<span class=\"disabled\">上一页</span>";
            }
            if (pageIndex >= pageCount)
            {
                //lastBtn = "<span class=\"disabled\">下一页</span>";
            }
            if (pageCount > 1)
            {
                if (pageIndex == 1)
                {
                    firstStr = "<li class=\"cur\"><strong>1</strong></li>";
                }
                if (pageIndex == pageCount)
                {
                    lastStr = "<li class=\"cur\"><strong>" + pageCount.ToString() + "</strong></li>";
                }
                int firstNum = pageIndex - (centSize / 2); //中间开始的页码
                if (pageIndex < centSize)
                    firstNum = 2;
                int lastNum = pageIndex + centSize - ((centSize / 2) + 1); //中间结束的页码
                if (lastNum >= pageCount)
                    lastNum = pageCount - 1;
                //pageStr.Append("<span>共" + totalCount + "记录</span>");
                pageStr.Append(firstStr);
                if (pageIndex >= centSize)
                {
                    pageStr.Append("<li style=\"border: none;\"><span>...</span>\n</li>");
                }
                for (int i = firstNum; i <= lastNum; i++)
                {
                    if (i == pageIndex)
                    {
                        pageStr.Append("<li class=\"cur\"><strong>" + i + "</strong></li>");
                    }
                    else
                    {
                        pageStr.Append("<li><a href=\"" + Utils.ReplaceStr(linkUrl, pageId, i.ToString()) + "\">" + i + "</a></li>");
                    }
                }
                if (pageCount - pageIndex > centSize - ((centSize / 2)))
                {
                    pageStr.Append("<li style=\"border: none;\"><span>...</span></li>");
                }
                pageStr.Append(lastStr);
            }
            else
            {
                pageStr.Append("<li><strong>1</strong></li>");
            }
            return pageStr.ToString();
        }
        #endregion



        /// <summary>
        /// 获取所有板块列表
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable get_board_list(int parent_id)
        {
            DataTable dt = new DataTable();
            dt = new BLL.Forum_Board().GetAllList(parent_id);
            return dt;
        }

        /// <summary>
        /// 路径地址
        /// </summary>
        /// <returns></returns>
        public string get_location(int board_id = 0, int topic_id = 0, string title = "", string action = "")
        {

            StringBuilder str = new StringBuilder();

            str.Append("<a href='" + linkurl("forum_index", "index") + "' class='home'> 官方论坛</a>");

            if (board_id == 0 && Request.QueryString["keys"] != null)
            {

                str.Append("<span class='separator'>&gt;</span><a href='#'>搜索结果</a>");

                return str.ToString();

            }


            //取所有版块
            System.Data.DataTable dt = new BLL.Forum_Board().GetList("1=1").Tables[0];

            System.Data.DataRow[] drs = dt.Select("Id=" + board_id);

            string[] ids = drs[0]["ClassList"].ToString().Split(',');

            for (int i = 0; i < ids.Length; i++)
            {
                if (!string.IsNullOrEmpty(ids[i]))
                {

                    System.Data.DataRow[] _dr = dt.Select("Id=" + ids[i]);

                    str.Append("<span class='separator'>&gt;</span><a href='" + linkurl("forum_board", _dr[0]["Id"]) + "'>" + _dr[0]["Name"] + "</a>");

                }
            }

            if (topic_id != 0)
            {
                str.Append("<span class='separator'>&gt;</span><a href='" + linkurl("forum_topic", topic_id) + "'>" + title + "</a>");
            }

            if (!string.IsNullOrEmpty(action))
            {

                string actionTxt = "";

                switch (action)
                {
                    //新主题
                    case "create":

                        actionTxt = "新主题";

                        break;
                    //编主题
                    case "update":

                        actionTxt = "编辑主题";

                        break;
                    //新回复
                    case "reply":

                        actionTxt = "写回复";

                        break;
                    //编回复
                    case "editor":

                        actionTxt = "编辑回复";

                        break;
                }

                str.Append("<span class='separator'>&gt;</span><a href='#'>" + actionTxt + "</a>");
            }

            return str.ToString();
        }


    }
}