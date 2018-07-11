using System;

namespace DTcms.Model
{
    /// <summary>
    /// 模型层
    /// <summary>
    [Serializable]
    public class dt_plugin_images
    {
        public dt_plugin_images() { }

        private int _id = 0;
        private int _class_id = 0;
        private string _title = string.Empty;
        private string _target = string.Empty;
        private string _img_url = string.Empty;
        private string _link_url = string.Empty;
        private string _content = string.Empty;
        private int _sort_id = 0;
        private string _back_color = string.Empty;
        private int _is_lock = 0;
        private DateTime _add_time = DateTime.Now;
        private int _is_type = 0;

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
        /// 分类ID
        /// </summary>
        public int class_id
        {
           set { _class_id = value; }
           get { return _class_id; }
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
        /// 打开方式
        /// </summary>
        public string target
        {
           set { _target = value; }
           get { return _target; }
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
        public string back_color
        {
           set { _back_color = value; }
           get { return _back_color; }
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
        public int is_type
        {
           set { _is_type = value; }
           get { return _is_type; }
        }

        #endregion
    }
}
