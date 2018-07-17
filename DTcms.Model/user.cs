using System;

namespace DTcms.Model
{
    /// <summary>
    /// 模型层
    /// <summary>
    [Serializable]
    public class user
    {
        public user() { }

        private int _id = 0;
        private string _avatar = string.Empty;
        private string _nickname = string.Empty;
        private string _openid = string.Empty;
        private string _unionid = string.Empty;
        private int _point = 0;
        private string _img = string.Empty;
        private int _level = 0;
        private int _parent_id = 0;
        private string _phone = string.Empty;
        private string _email = string.Empty;
        private int _sex = 0;
        private string _area = string.Empty;
        private int _status = 0;
        private DateTime _reg_time = DateTime.Now;
        private DateTime _login_time = DateTime.Now;
        private decimal _amount = 0;

        #region Model

        /// <summary>
        /// ID号
        /// </summary>
        public int id
        {
           set { _id = value; }
           get { return _id; }
        }
        public string avatar
        {
           set { _avatar = value; }
           get { return _avatar; }
        }
        public string nickname
        {
           set { _nickname = value; }
           get { return _nickname; }
        }
        public string openid
        {
           set { _openid = value; }
           get { return _openid; }
        }
        public string unionid
        {
           set { _unionid = value; }
           get { return _unionid; }
        }
        /// <summary>
        /// 积分
        /// </summary>
        public int point
        {
           set { _point = value; }
           get { return _point; }
        }
        public string img
        {
           set { _img = value; }
           get { return _img; }
        }
        public int level
        {
           set { _level = value; }
           get { return _level; }
        }
        /// <summary>
        /// 父类ID
        /// </summary>
        public int parent_id
        {
           set { _parent_id = value; }
           get { return _parent_id; }
        }
        public string phone
        {
           set { _phone = value; }
           get { return _phone; }
        }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string email
        {
           set { _email = value; }
           get { return _email; }
        }
        public int sex
        {
           set { _sex = value; }
           get { return _sex; }
        }
        public string area
        {
           set { _area = value; }
           get { return _area; }
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
        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime login_time
        {
           set { _login_time = value; }
           get { return _login_time; }
        }

        public decimal amount
        {
            get
            {
                return _amount;
            }

            set
            {
                _amount = value;
            }
        }

        #endregion
    }
}
