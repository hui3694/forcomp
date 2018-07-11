using System;

namespace DTcms.Model
{
    /// <summary>
    /// 模型层
    /// <summary>
    [Serializable]
    public class dt_article_attribute_value
    {
        public dt_article_attribute_value() { }

        private int _article_id = 0;
        private string _sub_title = string.Empty;
        private string _source = string.Empty;
        private string _author = string.Empty;
        private string _goods_no = string.Empty;
        private int _stock_quantity = 0;
        private decimal _market_price = 0M;
        private decimal _sell_price = 0M;
        private int _point = 0;
        private string _video_src = string.Empty;
        private string _tonglei = string.Empty;

        #region Model

        /// <summary>
        /// 新闻ID
        /// </summary>
        public int article_id
        {
           set { _article_id = value; }
           get { return _article_id; }
        }
        /// <summary>
        /// 子标题
        /// </summary>
        public string sub_title
        {
           set { _sub_title = value; }
           get { return _sub_title; }
        }
        /// <summary>
        /// 来源
        /// </summary>
        public string source
        {
           set { _source = value; }
           get { return _source; }
        }
        /// <summary>
        /// 作者
        /// </summary>
        public string author
        {
           set { _author = value; }
           get { return _author; }
        }
        public string goods_no
        {
           set { _goods_no = value; }
           get { return _goods_no; }
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
        /// <summary>
        /// 积分
        /// </summary>
        public int point
        {
           set { _point = value; }
           get { return _point; }
        }
        public string video_src
        {
           set { _video_src = value; }
           get { return _video_src; }
        }
        public string tonglei
        {
           set { _tonglei = value; }
           get { return _tonglei; }
        }

        #endregion
    }
}
