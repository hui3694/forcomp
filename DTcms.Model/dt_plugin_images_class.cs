using System;

namespace DTcms.Model
{
    /// <summary>
    /// 模型层
    /// <summary>
    [Serializable]
    public class dt_plugin_images_class
    {
        public dt_plugin_images_class() { }

        private int _id = 0;
        private string _title = string.Empty;
        private string _call_index = string.Empty;
        private int _num = 0;
        private int _width = 0;
        private int _height = 0;
        private int _sort_id = 0;
        private int _is_sys = 0;
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
        /// 标题
        /// </summary>
        public string title
        {
           set { _title = value; }
           get { return _title; }
        }
        /// <summary>
        /// 调用名称
        /// </summary>
        public string call_index
        {
           set { _call_index = value; }
           get { return _call_index; }
        }
        public int num
        {
           set { _num = value; }
           get { return _num; }
        }
        /// <summary>
        /// 宽度
        /// </summary>
        public int width
        {
           set { _width = value; }
           get { return _width; }
        }
        /// <summary>
        /// 高
        /// </summary>
        public int height
        {
           set { _height = value; }
           get { return _height; }
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
