using System;

namespace DTcms.Model
{
    /// <summary>
    /// 模型层
    /// <summary>
    [Serializable]
    public class dt_manager_role
    {
        public dt_manager_role() { }

        private int _id = 0;
        private string _role_name = string.Empty;
        private int _role_type = 0;
        private int _is_sys = 0;

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
        /// 角色名称
        /// </summary>
        public string role_name
        {
           set { _role_name = value; }
           get { return _role_name; }
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
        /// 是否集成
        /// </summary>
        public int is_sys
        {
           set { _is_sys = value; }
           get { return _is_sys; }
        }

        #endregion
    }
}
