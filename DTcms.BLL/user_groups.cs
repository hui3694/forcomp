using System;
using System.Data;
using System.Collections.Generic;

namespace DTcms.BLL
{
    /// <summary>
    /// 用户组别
    /// </summary>
    public partial class user_groups
    {
        private readonly Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(); //获得站点配置信息
        private readonly DAL.user_groups dal;

        public user_groups()
        {
            dal = new DAL.user_groups(siteConfig.sysdatabaseprefix);
        }

        #region 基本方法===============================
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.user_groups model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.user_groups model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {
            return dal.Delete(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.user_groups GetModel(int id)
        {
            return dal.GetModel(id);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }

        #endregion  Method

        #region 扩展方法===============================
        /// <summary>
        /// 返回用户组名称
        /// </summary>
        public string GetTitle(int id)
        {
            return dal.GetTitle(id);
        }

        /// <summary>
        /// 获取会员组折扣
        /// </summary>
        public int GetDiscount(int id)
        {
            return dal.GetDiscount(id);
        }

        /// <summary>
        /// 取得默认组别实体
        /// </summary>
        public Model.user_groups GetDefault()
        {
            return dal.GetDefault();
        }

        /// <summary>
        /// 根据经验值返回升级的组别实体
        /// </summary>
        public Model.user_groups GetUpgrade(int group_id, int exp)
        {
            return dal.GetUpgrade(group_id, exp);
        }

        /// <summary>
        /// 根据充值金额返回升级的组别实体
        /// </summary>
        public Model.user_groups GetUpgradePrice(int group_id, decimal price)
        {
            return dal.GetUpgradePrice(group_id, price);
        }
        #endregion
    }
}