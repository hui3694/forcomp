using System;

namespace DTcms.Model
{
    /// <summary>
    /// 模型层
    /// <summary>
    [Serializable]
    public class dt_manager
    {
        public dt_manager() { }

        private int _id = 0;
        private int _role_id = 0;
        private int _role_type = 0;
        private string _user_name = string.Empty;
        private string _password = string.Empty;
        private string _salt = string.Empty;
        private string _real_name = string.Empty;
        private string _telephone = string.Empty;
        private string _email = string.Empty;
        private int _is_lock = 0;
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
        /// 角色ID
        /// </summary>
        public int role_id
        {
           set { _role_id = value; }
           get { return _role_id; }
        }
        /// <summary>
        /// 角色类型
        /// </summary>
        public int role_type
        {
           set { _role_type = value; }
           get { return _role_type; }
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
        /// 密码
        /// </summary>
        public string password
        {
           set { _password = value; }
           get { return _password; }
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
        /// 真实姓名
        /// </summary>
        public string real_name
        {
           set { _real_name = value; }
           get { return _real_name; }
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string telephone
        {
           set { _telephone = value; }
           get { return _telephone; }
        }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string email
        {
           set { _email = value; }
           get { return _email; }
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
