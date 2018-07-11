using System;

namespace DTcms.Model
{
    /// <summary>
    /// 模型层
    /// <summary>
    [Serializable]
    public class dt_article_spec
    {
        public dt_article_spec() { }

        private int _id = 0;
        private int _parent_id = 0;
        private string _title = string.Empty;
        private string _img_url = string.Empty;
        private string _remark = string.Empty;
        private int _sort_id = 0;

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
        /// 父类ID
        /// </summary>
        public int parent_id
        {
           set { _parent_id = value; }
           get { return _parent_id; }
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
        /// 图片地址
        /// </summary>
        public string img_url
        {
           set { _img_url = value; }
           get { return _img_url; }
        }
        /// <summary>
        /// 描述
        /// </summary>
        public string remark
        {
           set { _remark = value; }
           get { return _remark; }
        }
        /// <summary>
        /// 排序
        /// </summary>
        public int sort_id
        {
           set { _sort_id = value; }
           get { return _sort_id; }
        }

        #endregion
    }
}
