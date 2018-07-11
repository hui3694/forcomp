using System;

namespace DTcms.Model
{
    /// <summary>
    /// 模型层
    /// <summary>
    [Serializable]
    public class dt_advert_banner
    {
        public dt_advert_banner() { }

        private int _id = 0;
        private int _aid = 0;
        private string _title = string.Empty;
        private DateTime _start_time = DateTime.Now;
        private DateTime _end_time = DateTime.Now;
        private string _file_path = string.Empty;
        private string _link_url = string.Empty;
        private string _content = string.Empty;
        private int _sort_id = 0;
        private int _is_lock = 0;
        private DateTime _add_time = DateTime.Now;

        #region Model

        /// <summary>
        /// ID号
        /// </summary>
        public int id
        {
           set { _id = value; }
           get { return _id; }
        }
        public int aid
        {
           set { _aid = value; }
           get { return _aid; }
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
        /// 起始时间
        /// </summary>
        public DateTime start_time
        {
           set { _start_time = value; }
           get { return _start_time; }
        }
        /// <summary>
        /// 终止时间
        /// </summary>
        public DateTime end_time
        {
           set { _end_time = value; }
           get { return _end_time; }
        }
        /// <summary>
        /// 文件路径
        /// </summary>
        public string file_path
        {
           set { _file_path = value; }
           get { return _file_path; }
        }
        /// <summary>
        /// 键接地址
        /// </summary>
        public string link_url
        {
           set { _link_url = value; }
           get { return _link_url; }
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
        /// 排序
        /// </summary>
        public int sort_id
        {
           set { _sort_id = value; }
           get { return _sort_id; }
        }
        /// <summary>
        /// 是否锁定
        /// </summary>
        public int is_lock
        {
           set { _is_lock = value; }
           get { return _is_lock; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime add_time
        {
           set { _add_time = value; }
           get { return _add_time; }
        }

        #endregion
    }
}
