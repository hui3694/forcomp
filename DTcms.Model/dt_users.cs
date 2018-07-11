using System;

namespace DTcms.Model
{
    /// <summary>
    /// 模型层
    /// <summary>
    [Serializable]
    public class dt_users
    {
        public dt_users() { }

        private int _id = 0;
        private int _group_id = 0;
        private string _user_name = string.Empty;
        private string _salt = string.Empty;
        private string _password = string.Empty;
        private string _mobile = string.Empty;
        private string _email = string.Empty;
        private string _avatar = string.Empty;
        private string _nick_name = string.Empty;
        private string _sex = string.Empty;
        private DateTime _birthday = DateTime.Now;
        private string _telphone = string.Empty;
        private string _area = string.Empty;
        private string _address = string.Empty;
        private string _qq = string.Empty;
        private string _msn = string.Empty;
        private decimal _amount = 0M;
        private int _point = 0;
        private int _exp = 0;
        private int _status = 0;
        private DateTime _reg_time = DateTime.Now;
        private string _reg_ip = string.Empty;
        private int _site_id = 0;

        #region Model

        /// <summary>
        /// ID号
        /// </summary>
        public int id
        {
           set { _id = value; }
           get { return _id; }
        }
        public int group_id
        {
           set { _group_id = value; }
           get { return _group_id; }
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
        /// 密匙
        /// </summary>
        public string salt
        {
           set { _salt = value; }
           get { return _salt; }
        }
        /// <summary>
        /// 密码
        /// </summary>
        public string password
        {
           set { _password = value; }
           get { return _password; }
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
        public string avatar
        {
           set { _avatar = value; }
           get { return _avatar; }
        }
        public string nick_name
        {
           set { _nick_name = value; }
           get { return _nick_name; }
        }
        public string sex
        {
           set { _sex = value; }
           get { return _sex; }
        }
        public DateTime birthday
        {
           set { _birthday = value; }
           get { return _birthday; }
        }
        public string telphone
        {
           set { _telphone = value; }
           get { return _telphone; }
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
        /// QQ
        /// </summary>
        public string qq
        {
           set { _qq = value; }
           get { return _qq; }
        }
        public string msn
        {
           set { _msn = value; }
           get { return _msn; }
        }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal amount
        {
           set { _amount = value; }
           get { return _amount; }
        }
        /// <summary>
        /// 积分
        /// </summary>
        public int point
        {
           set { _point = value; }
           get { return _point; }
        }
        public int exp
        {
           set { _exp = value; }
           get { return _exp; }
        }
        /// <summary>
        /// 状态
        /// </summary>
        public int status
        {
           set { _status = value; }
           get { return _status; }
        }
        public DateTime reg_time
        {
           set { _reg_time = value; }
           get { return _reg_time; }
        }
        public string reg_ip
        {
           set { _reg_ip = value; }
           get { return _reg_ip; }
        }
        /// <summary>
        /// 站点ID
        /// </summary>
        public int site_id
        {
           set { _site_id = value; }
           get { return _site_id; }
        }

        #endregion
    }
}
