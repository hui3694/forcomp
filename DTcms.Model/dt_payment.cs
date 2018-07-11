using System;

namespace DTcms.Model
{
    /// <summary>
    /// 模型层
    /// <summary>
    [Serializable]
    public class dt_payment
    {
        public dt_payment() { }

        private int _id = 0;
        private string _title = string.Empty;
        private string _img_url = string.Empty;
        private string _remark = string.Empty;
        private int _type = 0;
        private int _poundage_type = 0;
        private decimal _poundage_amount = 0M;
        private int _sort_id = 0;
        private int _is_mobile = 0;
        private int _is_lock = 0;
        private string _api_path = string.Empty;

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
        public int type
        {
           set { _type = value; }
           get { return _type; }
        }
        public int poundage_type
        {
           set { _poundage_type = value; }
           get { return _poundage_type; }
        }
        public decimal poundage_amount
        {
           set { _poundage_amount = value; }
           get { return _poundage_amount; }
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
        /// 移动设备
        /// </summary>
        public int is_mobile
        {
           set { _is_mobile = value; }
           get { return _is_mobile; }
        }
        /// <summary>
        /// 是否锁定
        /// </summary>
        public int is_lock
        {
           set { _is_lock = value; }
           get { return _is_lock; }
        }
        /// <summary>
        /// 接口目录
        /// </summary>
        public string api_path
        {
           set { _api_path = value; }
           get { return _api_path; }
        }

        #endregion
    }
}
