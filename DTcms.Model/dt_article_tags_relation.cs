using System;

namespace DTcms.Model
{
    /// <summary>
    /// 模型层
    /// <summary>
    [Serializable]
    public class dt_article_tags_relation
    {
        public dt_article_tags_relation() { }

        private int _id = 0;
        private int _article_id = 0;
        private int _tag_id = 0;

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
        /// 新闻ID
        /// </summary>
        public int article_id
        {
           set { _article_id = value; }
           get { return _article_id; }
        }
        public int tag_id
        {
           set { _tag_id = value; }
           get { return _tag_id; }
        }

        #endregion
    }
}
