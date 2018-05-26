using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace DTcms.Web.Plugin.Forum.Model
{
    //dt_Forum_Topic

    public class Forum_Topic
    {

        private int _id = 0;
        private int _boardid = 0;
        private int _topictypeid = 0;
        private string _title = "";
        private int _viewcount = 0;
        private int _replaycount = 0;
        private int _todayreplaycount = 0;
        private int _attachment = 0;
        private int _tagcount = 0;
        private int _postuserid = 0;
        private string _postusername = "";
        private string _postnickname = "";
        private DateTime _postdatetime = System.DateTime.Now;
        private int _lastpostid = 0;
        private DateTime _lastpostdatetime = System.DateTime.Now;
        private int _lastpostuserid = 0;
        private string _lastpostusername = "";
        private string _lastpostnickname = "";
        private int _digest = 0;
        private int _top = 0;
        private int _audit = 0;
        private int _invisible = 0;
        private int _postsubtable = 0;
        private string _highlight = "";
        private int _close = 0;
        private int _formid = 0;
        private int _ban = 0;
        private int _lastmodid = 0;
        private int _cover = 0;
        private decimal _rate = 0;
        private string _message = "";
        private int _postid = 0;
      

        /// <summary>
        /// Id
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// BoardId
        /// </summary>
        public int BoardId
        {
            get { return _boardid; }
            set { _boardid = value; }
        }
        /// <summary>
        /// TopicTypeId
        /// </summary>
        public int TopicTypeId
        {
            get { return _topictypeid; }
            set { _topictypeid = value; }
        }
        /// <summary>
        /// Title
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        /// <summary>
        /// ViewCount
        /// </summary>
        public int ViewCount
        {
            get { return _viewcount; }
            set { _viewcount = value; }
        }
        /// <summary>
        /// ReplayCount
        /// </summary>
        public int ReplayCount
        {
            get { return _replaycount; }
            set { _replaycount = value; }
        }
        /// <summary>
        /// TodayReplayCount
        /// </summary>
        public int TodayReplayCount
        {
            get { return _todayreplaycount; }
            set { _todayreplaycount = value; }
        }
        /// <summary>
        /// Attachment
        /// </summary>
        public int Attachment
        {
            get { return _attachment; }
            set { _attachment = value; }
        }
        /// <summary>
        /// TagCount
        /// </summary>
        public int TagCount
        {
            get { return _tagcount; }
            set { _tagcount = value; }
        }
        /// <summary>
        /// PostUserId
        /// </summary>
        public int PostUserId
        {
            get { return _postuserid; }
            set { _postuserid = value; }
        }
        /// <summary>
        /// PostUsername
        /// </summary>
        public string PostUsername
        {
            get { return _postusername; }
            set { _postusername = value; }
        }
        /// <summary>
        /// PostNickname
        /// </summary>
        public string PostNickname
        {
            get { return _postnickname; }
            set { _postnickname = value; }
        }
        /// <summary>
        /// PostDatetime
        /// </summary>
        public DateTime PostDatetime
        {
            get { return _postdatetime; }
            set { _postdatetime = value; }
        }
        /// <summary>
        /// LastPostId
        /// </summary>
        public int LastPostId
        {
            get { return _lastpostid; }
            set { _lastpostid = value; }
        }
        /// <summary>
        /// LastPostDatetime
        /// </summary>
        public DateTime LastPostDatetime
        {
            get { return _lastpostdatetime; }
            set { _lastpostdatetime = value; }
        }
        /// <summary>
        /// LastPostUserId
        /// </summary>
        public int LastPostUserId
        {
            get { return _lastpostuserid; }
            set { _lastpostuserid = value; }
        }
        /// <summary>
        /// LastPostUsername
        /// </summary>
        public string LastPostUsername
        {
            get { return _lastpostusername; }
            set { _lastpostusername = value; }
        }
        /// <summary>
        /// LastPostNickname
        /// </summary>
        public string LastPostNickname
        {
            get { return _lastpostnickname; }
            set { _lastpostnickname = value; }
        }
        /// <summary>
        /// Digest
        /// </summary>
        public int Digest
        {
            get { return _digest; }
            set { _digest = value; }
        }
        /// <summary>
        /// Top
        /// </summary>
        public int Top
        {
            get { return _top; }
            set { _top = value; }
        }
        /// <summary>
        /// Audit
        /// </summary>
        public int Audit
        {
            get { return _audit; }
            set { _audit = value; }
        }
        /// <summary>
        /// Invisible
        /// </summary>
        public int Invisible
        {
            get { return _invisible; }
            set { _invisible = value; }
        }
        /// <summary>
        /// PostSubTable
        /// </summary>
        public int PostSubTable
        {
            get { return _postsubtable; }
            set { _postsubtable = value; }
        }
        /// <summary>
        /// HighLight
        /// </summary>
        public string HighLight
        {
            get { return _highlight; }
            set { _highlight = value; }
        }
        /// <summary>
        /// Close
        /// </summary>
        public int Close
        {
            get { return _close; }
            set { _close = value; }
        }
        /// <summary>
        /// FormId
        /// </summary>
        public int FormId
        {
            get { return _formid; }
            set { _formid = value; }
        }
        /// <summary>
        /// Ban
        /// </summary>
        public int Ban
        {
            get { return _ban; }
            set { _ban = value; }
        }
        /// <summary>
        /// LastModId
        /// </summary>
        public int LastModId
        {
            get { return _lastmodid; }
            set { _lastmodid = value; }
        }
        /// <summary>
        /// Cover
        /// </summary>
        public int Cover
        {
            get { return _cover; }
            set { _cover = value; }
        }
        /// <summary>
        /// Rate
        /// </summary>
        public decimal Rate
        {
            get { return _rate; }
            set { _rate = value; }
        }

        /// <summary>
        /// Message
        /// </summary>
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        /// <summary>
        /// 贴子ID 数据库中并不存在这个字段
        /// </summary>
        public int PostId
        {
            get { return _postid; }
            set { _postid = value; }
        }

        
    }
}

