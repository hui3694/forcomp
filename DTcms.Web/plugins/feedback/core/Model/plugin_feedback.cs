using System;

namespace DTcms.Model
{
    /// <summary>
    /// 留言实体类
    /// <summary>
    [Serializable]
    public class plugin_feedback
    {
        public plugin_feedback() { }

        private int _id = 0;
        private string _site_path = string.Empty;
        private string _title = string.Empty;
        private string _content = string.Empty;
        private string _user_name = string.Empty;
        private string _user_tel = string.Empty;
        private string _user_qq = string.Empty;
        private string _user_email = string.Empty;
        private DateTime _add_time = DateTime.Now;
        private string _reply_content = string.Empty;
        private DateTime _reply_time = DateTime.Now;
        private int _is_lock = 0;

        #region Model
        /// <summary>
        /// ID号
        /// </summary>
        public int id
        {
           set { _id = value; }
           get { return _id; }
        }
        /// <summary>
        /// 站点目录
        /// </summary>
        public string site_path
        {
           set { _site_path = value; }
           get { return _site_path; }
        }
        /// <summary>
        /// 留言标题
        /// </summary>
        public string title
        {
           set { _title = value; }
           get { return _title; }
        }
        /// <summary>
        /// 内容
        /// </summary>
        public string content
        {
           set { _content = value; }
           get { return _content; }
        }
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string user_name
        {
           set { _user_name = value; }
           get { return _user_name; }
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string user_tel
        {
           set { _user_tel = value; }
           get { return _user_tel; }
        }
        /// <summary>
        /// 联系QQ
        /// </summary>
        public string user_qq
        {
           set { _user_qq = value; }
           get { return _user_qq; }
        }
        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string user_email
        {
           set { _user_email = value; }
           get { return _user_email; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime add_time
        {
           set { _add_time = value; }
           get { return _add_time; }
        }
        /// <summary>
        /// 回复内容
        /// </summary>
        public string reply_content
        {
           set { _reply_content = value; }
           get { return _reply_content; }
        }
        /// <summary>
        /// 回复时间
        /// </summary>
        public DateTime reply_time
        {
           set { _reply_time = value; }
           get { return _reply_time; }
        }
        /// <summary>
        /// 是否锁定
        /// </summary>
        public int is_lock
        {
           set { _is_lock = value; }
           get { return _is_lock; }
        }
        #endregion
    }
}
