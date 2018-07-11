using System;

namespace DTcms.Model
{
    /// <summary>
    /// 模型层
    /// <summary>
    [Serializable]
    public class dt_article_goods
    {
        public dt_article_goods() { }

        private int _id = 0;
        private int _article_id = 0;
        private string _goods_no = string.Empty;
        private string _spec_ids = string.Empty;
        private string _spec_text = string.Empty;
        private int _stock_quantity = 0;
        private decimal _market_price = 0M;
        private decimal _sell_price = 0M;

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
        public string goods_no
        {
           set { _goods_no = value; }
           get { return _goods_no; }
        }
        public string spec_ids
        {
           set { _spec_ids = value; }
           get { return _spec_ids; }
        }
        public string spec_text
        {
           set { _spec_text = value; }
           get { return _spec_text; }
        }
        public int stock_quantity
        {
           set { _stock_quantity = value; }
           get { return _stock_quantity; }
        }
        /// <summary>
        /// 市场价
        /// </summary>
        public decimal market_price
        {
           set { _market_price = value; }
           get { return _market_price; }
        }
        /// <summary>
        /// 销售价
        /// </summary>
        public decimal sell_price
        {
           set { _sell_price = value; }
           get { return _sell_price; }
        }

        #endregion
    }
}
