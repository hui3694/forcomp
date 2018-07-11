using System;

namespace DTcms.Model
{
    /// <summary>
    /// 模型层
    /// <summary>
    [Serializable]
    public class dt_user_group_price
    {
        public dt_user_group_price() { }

        private int _id = 0;
        private int _article_id = 0;
        private int _goods_id = 0;
        private int _group_id = 0;
        private decimal _price = 0M;

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
        public int goods_id
        {
           set { _goods_id = value; }
           get { return _goods_id; }
        }
        public int group_id
        {
           set { _group_id = value; }
           get { return _group_id; }
        }
        public decimal price
        {
           set { _price = value; }
           get { return _price; }
        }

        #endregion
    }
}
