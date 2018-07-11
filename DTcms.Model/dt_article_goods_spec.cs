using System;

namespace DTcms.Model
{
    /// <summary>
    /// 模型层
    /// <summary>
    [Serializable]
    public class dt_article_goods_spec
    {
        public dt_article_goods_spec() { }

        private int _article_id = 0;
        private int _spec_id = 0;
        private int _parent_id = 0;
        private string _title = string.Empty;
        private string _img_url = string.Empty;

        #region Model

        /// <summary>
        /// 新闻ID
        /// </summary>
        public int article_id
        {
           set { _article_id = value; }
           get { return _article_id; }
        }
        public int spec_id
        {
           set { _spec_id = value; }
           get { return _spec_id; }
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

        #endregion
    }
}
