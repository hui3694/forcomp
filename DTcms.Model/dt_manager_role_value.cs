using System;

namespace DTcms.Model
{
    /// <summary>
    /// 模型层
    /// <summary>
    [Serializable]
    public class dt_manager_role_value
    {
        public dt_manager_role_value() { }

        private int _id = 0;
        private int _role_id = 0;
        private string _nav_name = string.Empty;
        private string _action_type = string.Empty;

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
        /// 菜单名称
        /// </summary>
        public string nav_name
        {
           set { _nav_name = value; }
           get { return _nav_name; }
        }
        /// <summary>
        /// 操作类型
        /// </summary>
        public string action_type
        {
           set { _action_type = value; }
           get { return _action_type; }
        }

        #endregion
    }
}
