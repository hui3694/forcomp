using System;

namespace DTcms.Model
{
    /// <summary>
    /// 模型层
    /// <summary>
    [Serializable]
    public class pro_category
    {
        public pro_category() { }

        private int _id = 0;
        private string _title = string.Empty;
        private string _img = string.Empty;
        private string _img2 = string.Empty;
        private int _parent_id = 0;
        private int _sort = 0;
        private int _is_sys = 0;

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
        public string img
        {
           set { _img = value; }
           get { return _img; }
        }
        public string img2
        {
           set { _img2 = value; }
           get { return _img2; }
        }
        /// <summary>
        /// 父类ID
        /// </summary>
        public int parent_id
        {
           set { _parent_id = value; }
           get { return _parent_id; }
        }
        public int sort
        {
           set { _sort = value; }
           get { return _sort; }
        }
        /// <summary>
        /// 是否集成
        /// </summary>
        public int is_sys
        {
           set { _is_sys = value; }
           get { return _is_sys; }
        }

        #endregion
    }
}
