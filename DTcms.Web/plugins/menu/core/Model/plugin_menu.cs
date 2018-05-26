using System;

namespace DTcms.Model
{
    /// <summary>
    /// 模型层
    /// <summary>
    [Serializable]
    public class plugin_menu
    {
        public plugin_menu() { }

        private int _id = 0;
        private int _class_id = 0;
        private string _title = string.Empty;
        private string _link_url = string.Empty;
        private int _parent_id = 0;
        private string _class_list = string.Empty;
        private int _class_layer = 0;
        private string _target = string.Empty;
        private int _sort_id = 0;
        private string _css_txt = string.Empty;
        private string _img_url = string.Empty;
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
        /// 键接地址
        /// </summary>
        public string link_url
        {
           set { _link_url = value; }
           get { return _link_url; }
        }
        /// <summary>
        /// 父类ID
        /// </summary>
        public int parent_id
        {
           set { _parent_id = value; }
           get { return _parent_id; }
        }
        /// <summary>
        /// 分类列表
        /// </summary>
        public string class_list
        {
           set { _class_list = value; }
           get { return _class_list; }
        }
        /// <summary>
        /// 深度
        /// </summary>
        public int class_layer
        {
           set { _class_layer = value; }
           get { return _class_layer; }
        }
        public string target
        {
           set { _target = value; }
           get { return _target; }
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
        /// CSS文本
        /// </summary>
        public string css_txt
        {
           set { _css_txt = value; }
           get { return _css_txt; }
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
