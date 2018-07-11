using System;

namespace DTcms.Model
{
    /// <summary>
    /// 模型层
    /// <summary>
    [Serializable]
    public class dt_user_addr_book
    {
        public dt_user_addr_book() { }

        private int _id = 0;
        private int _user_id = 0;
        private string _user_name = string.Empty;
        private string _accept_name = string.Empty;
        private string _area = string.Empty;
        private string _address = string.Empty;
        private string _mobile = string.Empty;
        private string _telphone = string.Empty;
        private string _email = string.Empty;
        private string _post_code = string.Empty;
        private int _is_default = 0;
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
        public string accept_name
        {
           set { _accept_name = value; }
           get { return _accept_name; }
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
        /// <summary>
        /// 手机
        /// </summary>
        public string mobile
        {
           set { _mobile = value; }
           get { return _mobile; }
        }
        public string telphone
        {
           set { _telphone = value; }
           get { return _telphone; }
        }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string email
        {
           set { _email = value; }
           get { return _email; }
        }
        public string post_code
        {
           set { _post_code = value; }
           get { return _post_code; }
        }
        /// <summary>
        /// 是否默认
        /// </summary>
        public int is_default
        {
           set { _is_default = value; }
           get { return _is_default; }
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
