using DTcms.Common;
using System;
using System.Collections.Generic;
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
    public class Global
    {

        #region 论坛版块置顶标题Ids缓存

        /// <summary>
        /// 版块对应的置顶标题
        /// </summary>
        public static Dictionary<int, string> ForumTopTopicIds = new Dictionary<int, string>();

        /// <summary>
        /// 增加、更新版块对应置顶Ids,作用于SQL
        /// </summary>
        /// <param name="board_id"></param>
        /// <param name="ids"></param>
        public static void PutForumTopTopicIds(int board_id, string ids)
        {
            if (ForumTopTopicIds.ContainsKey(board_id))
            {
                ForumTopTopicIds[board_id] = ids;
            }
            else
            {
                ForumTopTopicIds.Add(board_id, ids);
            }
        }

        /// <summary>
        /// 获取块版应的Ids,作用于SQL
        /// </summary>
        /// <param name="board_id"></param>
        /// <returns></returns>
        public static string GetForumTopTopicIds(int board_id)
        {
            if (ForumTopTopicIds.ContainsKey(board_id))
            {
                return ForumTopTopicIds[board_id];
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region 论坛操作动作缓存

        public static Dictionary<int, string> ForumActionList = new Dictionary<int, string>();

        /// <summary>
        /// 论坛动作缓存
        /// </summary>
        /// <returns></returns>
        public static Dictionary<int, string> GetActionList()
        {
            if (ForumActionList.Count == 0)
            {
                ForumActionList.Add(1, "发主题");
                ForumActionList.Add(2, "发回复");
                ForumActionList.Add(3, "设置精华");
                ForumActionList.Add(4, "取消精华");
                ForumActionList.Add(5, "删除主题");
                ForumActionList.Add(6, "删除回复");
                ForumActionList.Add(7, "上传附件");
                ForumActionList.Add(8, "下载附件");
            }

            return ForumActionList;
        }

        #endregion

        #region 论坛敏感词过缓存

        public static Dictionary<string, string> ForumWordList = new Dictionary<string, string>();

        /// <summary>
        /// 敏感词缓存
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetWordList(bool bol = false)
        {

            if (ForumWordList.Count == 0)
            {
                bol = true;
            }

            if (bol)
            {
                ForumWordList.Clear();

                List<Model.Forum_Word> list = new BLL.Forum_Word().GetModelList(" 1=1 ");

                if (list.Count != 0)
                {
                    foreach (Model.Forum_Word item in list)
                    {
                        ForumWordList.Add(item.FindWord, item.FindWord);
                    }
                }
                else
                {
                    //默认随便加个值
                    ForumWordList.Add("~||~", "^||^");
                }
            }

            return ForumWordList;
        }

        #endregion

        #region 论坛版块权限缓存

        public static Dictionary<string, Model.Forum_BoardPermission> ForumBoardPermissionList = new Dictionary<string, Model.Forum_BoardPermission>();

        /// <summary>
        /// 块权限缓存
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, Model.Forum_BoardPermission> GetBoardPermissionList(bool bol = false)
        {

            if (ForumBoardPermissionList.Count == 0)
            {
                bol = true;
            }

            if (bol)
            {
                ForumBoardPermissionList.Clear();

                List<Model.Forum_BoardPermission> list = new BLL.Forum_BoardPermission().GetModelList(" 1=1 ");

                if (list.Count != 0)
                {
                    foreach (Model.Forum_BoardPermission item in list)
                    {
                        ForumBoardPermissionList.Add(item.BoardId + "|" + item.GroupId, item);
                    }
                }
                else
                {
                    //默认随便加个值
                    ForumBoardPermissionList.Add("0|0", null);
                }
            }

            return ForumBoardPermissionList;
        }

        #endregion

        #region 全局变量24小时更新一次

        /// <summary>
        /// 加载全局变量 24 小时重新加载一次
        /// </summary>
        public static void GlobalLoad(bool bol = false)
        {

            DateTime dt = DateTime.Now;
            TimeSpan ts = dt - GlobalRefreshTime;

            if (ts.TotalSeconds > 86400.0)
            {
                bol = true;
            }

            if (bol)
            {
                System.Data.DataTable dtSet = new BLL.Forum_Settings().GetList(" 1=1 ").Tables[0];

                for (int i = 0; i < dtSet.Rows.Count; i++)
                {
                    string _val = dtSet.Rows[i]["Variable"].ToString().ToLower();

                    //全局变量要与数据库对应
                    if (_val == "RateExchange".ToLower())
                    {
                        RateExchange = Convert.ToInt32(dtSet.Rows[i]["Value"]);
                    }
                    else if (_val == "Version".ToLower())
                    {
                        ForumVersion = dtSet.Rows[i]["Value"].ToString();
                    }
                }

                GlobalRefreshTime = System.DateTime.Now;

            }
        }

        /// <summary>
        /// 论坛积分默认5积分 兑换 DTcms 1 积分
        /// </summary>
        public static int RateExchange = 5;

        public static string ForumVersion = "4.0";

        /// <summary>
        /// 全局变量更新时间
        /// </summary>
        public static DateTime GlobalRefreshTime = Convert.ToDateTime("2010-10-10 10:10:10");

        #endregion

        #region 版块的今日统计，作用于减少数据库的操作

        public static void BoardTodayTopicCount(bool bol = false)
        {

            //没有统计过
            if (HttpContext.Current.Application["BoardTodayTopicTime"] == null)
            {
                bol = true;

                HttpContext.Current.Application["BoardTodayTopicTime"] = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy-MM-dd 00:00:01"));
            }


            DateTime dtTime = Convert.ToDateTime(HttpContext.Current.Application["BoardTodayTopicTime"]);

            TimeSpan ts = System.DateTime.Now - dtTime;


            //时间已经超过了24小时
            if (ts.TotalSeconds > 86400.0)
            {
                bol = true;
            }


            if (bol)
            {

                BLL.Forum_Board bll = new BLL.Forum_Board();

                bll.UpdateField(" 1=1 ", "TodayTopicCount=0");

                List<Model.Forum_Board> list = bll.GetModelList(" 1=1 ");

                //所有版块重新统计

                foreach (Model.Forum_Board modelBoard in list)
                {
                    int _total = new BLL.Forum_Topic().GetTotal(" BoardId=" + modelBoard.Id + " and PostDatetime>'" + System.DateTime.Now.ToString("yyyy-MM-dd 00:00:01") + "' ");

                    string strValue = "[TodayTopicCount]=[TodayTopicCount]+" + _total + "";

                    bll.UpdateField(" Id in (0" + modelBoard.ClassList + "0) ", strValue);
                }

                HttpContext.Current.Application["BoardTodayTopicTime"] = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy-MM-dd 00:00:01"));
            }

        }

        #endregion

    }
}