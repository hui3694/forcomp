using System;

namespace DTcms.Model
{
    /// <summary>
    /// 模型层
    /// <summary>
    [Serializable]
    public class dt_orders
    {
        public dt_orders() { }

        private int _id = 0;
        private string _order_no = string.Empty;
        private string _trade_no = string.Empty;
        private int _user_id = 0;
        private string _user_name = string.Empty;
        private int _payment_id = 0;
        private decimal _payment_fee = 0M;
        private int _payment_status = 0;
        private DateTime _payment_time = DateTime.Now;
        private int _express_id = 0;
        private string _express_no = string.Empty;
        private decimal _express_fee = 0M;
        private int _express_status = 0;
        private DateTime _express_time = DateTime.Now;
        private string _accept_name = string.Empty;
        private string _post_code = string.Empty;
        private string _telphone = string.Empty;
        private string _mobile = string.Empty;
        private string _email = string.Empty;
        private string _area = string.Empty;
        private string _address = string.Empty;
        private string _message = string.Empty;
        private string _remark = string.Empty;
        private int _is_invoice = 0;
        private string _invoice_title = string.Empty;
        private decimal _invoice_taxes = 0M;
        private decimal _payable_amount = 0M;
        private decimal _real_amount = 0M;
        private decimal _order_amount = 0M;
        private int _point = 0;
        private int _status = 0;
        private DateTime _add_time = DateTime.Now;
        private DateTime _confirm_time = DateTime.Now;
        private DateTime _complete_time = DateTime.Now;

        #region Model

        /// <summary>
        /// ID号
        /// </summary>
        public int id
        {
           set { _id = value; }
           get { return _id; }
        }
        public string order_no
        {
           set { _order_no = value; }
           get { return _order_no; }
        }
        public string trade_no
        {
           set { _trade_no = value; }
           get { return _trade_no; }
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
        public decimal payment_fee
        {
           set { _payment_fee = value; }
           get { return _payment_fee; }
        }
        public int payment_status
        {
           set { _payment_status = value; }
           get { return _payment_status; }
        }
        public DateTime payment_time
        {
           set { _payment_time = value; }
           get { return _payment_time; }
        }
        public int express_id
        {
           set { _express_id = value; }
           get { return _express_id; }
        }
        public string express_no
        {
           set { _express_no = value; }
           get { return _express_no; }
        }
        public decimal express_fee
        {
           set { _express_fee = value; }
           get { return _express_fee; }
        }
        public int express_status
        {
           set { _express_status = value; }
           get { return _express_status; }
        }
        public DateTime express_time
        {
           set { _express_time = value; }
           get { return _express_time; }
        }
        public string accept_name
        {
           set { _accept_name = value; }
           get { return _accept_name; }
        }
        public string post_code
        {
           set { _post_code = value; }
           get { return _post_code; }
        }
        public string telphone
        {
           set { _telphone = value; }
           get { return _telphone; }
        }
        /// <summary>
        /// 手机
        /// </summary>
        public string mobile
        {
           set { _mobile = value; }
           get { return _mobile; }
        }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string email
        {
           set { _email = value; }
           get { return _email; }
        }
        public string area
        {
           set { _area = value; }
           get { return _area; }
        }
        /// <summary>
        /// 地址
        /// </summary>
        public string address
        {
           set { _address = value; }
           get { return _address; }
        }
        public string message
        {
           set { _message = value; }
           get { return _message; }
        }
        /// <summary>
        /// 描述
        /// </summary>
        public string remark
        {
           set { _remark = value; }
           get { return _remark; }
        }
        public int is_invoice
        {
           set { _is_invoice = value; }
           get { return _is_invoice; }
        }
        public string invoice_title
        {
           set { _invoice_title = value; }
           get { return _invoice_title; }
        }
        public decimal invoice_taxes
        {
           set { _invoice_taxes = value; }
           get { return _invoice_taxes; }
        }
        public decimal payable_amount
        {
           set { _payable_amount = value; }
           get { return _payable_amount; }
        }
        public decimal real_amount
        {
           set { _real_amount = value; }
           get { return _real_amount; }
        }
        public decimal order_amount
        {
           set { _order_amount = value; }
           get { return _order_amount; }
        }
        /// <summary>
        /// 积分
        /// </summary>
        public int point
        {
           set { _point = value; }
           get { return _point; }
        }
        /// <summary>
        /// 状态
        /// </summary>
        public int status
        {
           set { _status = value; }
           get { return _status; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime add_time
        {
           set { _add_time = value; }
           get { return _add_time; }
        }
        public DateTime confirm_time
        {
           set { _confirm_time = value; }
           get { return _confirm_time; }
        }
        /// <summary>
        /// 完成时间
        /// </summary>
        public DateTime complete_time
        {
           set { _complete_time = value; }
           get { return _complete_time; }
        }

        #endregion
    }
}
