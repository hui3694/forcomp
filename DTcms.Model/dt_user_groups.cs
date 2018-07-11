using System;

namespace DTcms.Model
{
    /// <summary>
    /// 模型层
    /// <summary>
    [Serializable]
    public class dt_user_groups
    {
        public dt_user_groups() { }

        private int _id = 0;
        private string _title = string.Empty;
        private int _grade = 0;
        private int _upgrade_exp = 0;
        private decimal _amount = 0M;
        private int _point = 0;
        private int _discount = 0;
        private int _is_default = 0;
        private int _is_upgrade = 0;
        private int _is_lock = 0;
        private decimal _upgrade_price = 0M;

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
        ///  等级
        /// </summary>
        public int grade
        {
           set { _grade = value; }
           get { return _grade; }
        }
        /// <summary>
        /// 升级经验值
        /// </summary>
        public int upgrade_exp
        {
           set { _upgrade_exp = value; }
           get { return _upgrade_exp; }
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
        /// <summary>
        /// 折扣
        /// </summary>
        public int discount
        {
           set { _discount = value; }
           get { return _discount; }
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
        /// 自动升级
        /// </summary>
        public int is_upgrade
        {
           set { _is_upgrade = value; }
           get { return _is_upgrade; }
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
        /// 升级冲值金额
        /// </summary>
        public decimal upgrade_price
        {
           set { _upgrade_price = value; }
           get { return _upgrade_price; }
        }

        #endregion
    }
}
