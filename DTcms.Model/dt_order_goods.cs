using System;

namespace DTcms.Model
{
    /// <summary>
    /// 模型层
    /// <summary>
    [Serializable]
    public class dt_order_goods
    {
        public dt_order_goods() { }

        private int _id = 0;
        private int _article_id = 0;
        private int _order_id = 0;
        private int _goods_id = 0;
        private string _goods_no = string.Empty;
        private string _goods_title = string.Empty;
        private string _img_url = string.Empty;
        private string _spec_text = string.Empty;
        private decimal _goods_price = 0M;
        private decimal _real_price = 0M;
        private int _quantity = 0;
        private int _point = 0;

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
        /// <summary>
        /// 订单ID
        /// </summary>
        public int order_id
        {
           set { _order_id = value; }
           get { return _order_id; }
        }
        public int goods_id
        {
           set { _goods_id = value; }
           get { return _goods_id; }
        }
        public string goods_no
        {
           set { _goods_no = value; }
           get { return _goods_no; }
        }
        public string goods_title
        {
           set { _goods_title = value; }
           get { return _goods_title; }
        }
        /// <summary>
        /// 图片地址
        /// </summary>
        public string img_url
        {
           set { _img_url = value; }
           get { return _img_url; }
        }
        public string spec_text
        {
           set { _spec_text = value; }
           get { return _spec_text; }
        }
        public decimal goods_price
        {
           set { _goods_price = value; }
           get { return _goods_price; }
        }
        public decimal real_price
        {
           set { _real_price = value; }
           get { return _real_price; }
        }
        public int quantity
        {
           set { _quantity = value; }
           get { return _quantity; }
        }
        /// <summary>
        /// 积分
        /// </summary>
        public int point
        {
           set { _point = value; }
           get { return _point; }
        }

        #endregion
    }
}
