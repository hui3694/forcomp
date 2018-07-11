using System;

namespace DTcms.Model
{
    /// <summary>
    /// 模型层
    /// <summary>
    [Serializable]
    public class dt_express
    {
        public dt_express() { }

        private int _id = 0;
        private string _title = string.Empty;
        private string _express_code = string.Empty;
        private decimal _express_fee = 0M;
        private string _website = string.Empty;
        private string _remark = string.Empty;
        private int _sort_id = 0;
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
        public string express_code
        {
           set { _express_code = value; }
           get { return _express_code; }
        }
        public decimal express_fee
        {
           set { _express_fee = value; }
           get { return _express_fee; }
        }
        public string website
        {
           set { _website = value; }
           get { return _website; }
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
