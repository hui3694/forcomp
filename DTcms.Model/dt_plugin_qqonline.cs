using System;

namespace DTcms.Model
{
    /// <summary>
    /// 模型层
    /// <summary>
    [Serializable]
    public class dt_plugin_qqonline
    {
        public dt_plugin_qqonline() { }

        private int _id = 0;
        private string _qq = string.Empty;
        private string _username = string.Empty;
        private string _img_url = string.Empty;
        private string _link_url = string.Empty;
        private int _is_lock = 0;
        private int _sort_id = 0;
        private string _color = string.Empty;
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
        /// <summary>
        /// QQ
        /// </summary>
        public string qq
        {
           set { _qq = value; }
           get { return _qq; }
        }
        public string username
        {
           set { _username = value; }
           get { return _username; }
        }
        /// <summary>
        /// 图片地址
        /// </summary>
        public string img_url
        {
           set { _img_url = value; }
           get { return _img_url; }
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
        /// 是否锁定
        /// </summary>
        public int is_lock
        {
           set { _is_lock = value; }
           get { return _is_lock; }
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
        /// 颜色
        /// </summary>
        public string color
        {
           set { _color = value; }
           get { return _color; }
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
