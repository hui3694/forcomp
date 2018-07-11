using System;

namespace DTcms.Model
{
    /// <summary>
    /// 模型层
    /// <summary>
    [Serializable]
    public class dt_plugin_menu_class
    {
        public dt_plugin_menu_class() { }

        private int _id = 0;
        private string _title = string.Empty;
        private int _is_lock = 0;
        private int _sort_id = 0;
        private int _is_sys = 0;
        private string _color = string.Empty;

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
        /// 标题
        /// </summary>
        public string title
        {
           set { _title = value; }
           get { return _title; }
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
        /// 是否集成
        /// </summary>
        public int is_sys
        {
           set { _is_sys = value; }
           get { return _is_sys; }
        }
        /// <summary>
        /// 颜色
        /// </summary>
        public string color
        {
           set { _color = value; }
           get { return _color; }
        }

        #endregion
    }
}
