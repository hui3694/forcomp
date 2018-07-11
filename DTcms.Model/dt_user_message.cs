using System;

namespace DTcms.Model
{
    /// <summary>
    /// 模型层
    /// <summary>
    [Serializable]
    public class dt_user_message
    {
        public dt_user_message() { }

        private int _id = 0;
        private int _type = 0;
        private string _post_user_name = string.Empty;
        private string _accept_user_name = string.Empty;
        private int _is_read = 0;
        private string _title = string.Empty;
        private string _content = string.Empty;
        private DateTime _post_time = DateTime.Now;
        private DateTime _read_time = DateTime.Now;

        #region Model

        /// <summary>
        /// ID号
        /// </summary>
        public int id
        {
           set { _id = value; }
           get { return _id; }
        }
        public int type
        {
           set { _type = value; }
           get { return _type; }
        }
        /// <summary>
        /// 发件人
        /// </summary>
        public string post_user_name
        {
           set { _post_user_name = value; }
           get { return _post_user_name; }
        }
        /// <summary>
        /// 收件人
        /// </summary>
        public string accept_user_name
        {
           set { _accept_user_name = value; }
           get { return _accept_user_name; }
        }
        public int is_read
        {
           set { _is_read = value; }
           get { return _is_read; }
        }
        /// <summary>
        /// 标题
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
        public DateTime post_time
        {
           set { _post_time = value; }
           get { return _post_time; }
        }
        public DateTime read_time
        {
           set { _read_time = value; }
           get { return _read_time; }
        }

        #endregion
    }
}
