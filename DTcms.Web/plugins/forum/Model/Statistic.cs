using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DTcms.Web.Plugin.Forum.Model
{
    public static class Statistic
    {

        private static int _todaypost = 0;
        private static int _yesterdaypost = 0;
        private static int _totalpost = 0;
        private static int _totaluser = 0;
        private static int _lastuserid = 0;
        private static string _lastusernickname = "";
        private static DateTime _refreshtime = Convert.ToDateTime("2010-10-10 10:10:10");
        private static DataTable _medallist = null;

        /// <summary>
        /// 勋章列表，缓存中，没有必要一直刷新
        /// </summary>
        public static DataTable MedalList
        {
            get { return _medallist; }
            set { _medallist = value; }
        }

        /// <summary>
        /// 数据刷新时间,默认时间为 2010-10-10 10:10:10
        /// </summary>
        public static DateTime RefreshTime
        {
            get { return _refreshtime; }
            set { _refreshtime = value; }
        }

        /// <summary>
        /// 今日
        /// </summary>
        public static int TodayPost
        {
            get { return _todaypost; }
            set { _todaypost = value; }
        }

        /// <summary>
        /// 昨日
        /// </summary>
        public static int YesterdayPost
        {
            get { return _yesterdaypost; }
            set { _yesterdaypost = value; }
        }

        /// <summary>
        /// 帖子
        /// </summary>
        public static int TotalPost
        {
            get { return _totalpost; }
            set { _totalpost = value; }
        }

        /// <summary>
        /// 会员
        /// </summary>
        public static int TotalUser
        {
            get { return _totaluser; }
            set { _totaluser = value; }
        }

        /// <summary>
        /// 欢迎新会员ID
        /// </summary>
        public static int LastUserId
        {
            get { return _lastuserid; }
            set { _lastuserid = value; }
        }

        /// <summary>
        /// 欢迎新会员
        /// </summary>
        public static string LastUserNickname
        {
            get { return _lastusernickname; }
            set { _lastusernickname = value; }
        }



    }
}