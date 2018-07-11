using System;

namespace DTcms.Model
{
    /// <summary>
    /// 模型层
    /// <summary>
    [Serializable]
    public class dt_user_amount_log
    {
        public dt_user_amount_log() { }

        private int _id = 0;
        private int _user_id = 0;
        private string _user_name = string.Empty;
        private int _payment_id = 0;
        private decimal _value = 0M;
        private string _remark = string.Empty;
        private DateTime _add_time = DateTime.Now;

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
        /// 用户ID
        /// </summary>
        public int user_id
        {
           set { _user_id = value; }
           get { return _user_id; }
        }
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string user_name
        {
           set { _user_name = value; }
           get { return _user_name; }
        }
        /// <summary>
        /// 支付ID
        /// </summary>
        public int payment_id
        {
           set { _payment_id = value; }
           get { return _payment_id; }
        }
        /// <summary>
        /// 值
        /// </summary>
        public decimal value
        {
           set { _value = value; }
           get { return _value; }
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
        /// 添加时间
        /// </summary>
        public DateTime add_time
        {
           set { _add_time = value; }
           get { return _add_time; }
        }

        #endregion
    }
}
