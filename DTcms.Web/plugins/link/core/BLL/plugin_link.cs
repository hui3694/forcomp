using System;
using System.Collections.Generic;
using System.Data;

namespace DTcms.BLL
{
    /// <summary>
    /// 业务逻辑层
    /// </summary>
    public class plugin_link
    {
        private readonly Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig();
        private readonly DAL.plugin_link dal;

        public plugin_link()  
        {
              dal = new DAL.plugin_link(siteConfig.sysdatabaseprefix);
        }

        #region 基本方法
        /// <summary>
        /// 按ID号查询是否存在记录
        /// </summary>
        /// <param name="id">ID号</param>
        /// <returns>True Or False</returns>
        public bool Exists(int id)
        {
              return dal.Exists(id);
        }

        /// <summary>
        /// 按条件查询数据总数
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns>总数</returns>
        public int GetCount(string strWhere)
        {
              return dal.GetCount(strWhere);
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model">Model.plugin_link</param>
        /// <returns>ID</returns>
        public int Add(Model.plugin_link model)
        {
              return dal.Add(model);
        }
        #endregion

        #region 修改一列数据
        /// <summary>
        /// 修改一列数据
        /// </summary>
        /// <param name="id">ID号</param>
        /// <param name="strValue"></param>
        public void UpdateField(int id, string strValue)
        {
              dal.UpdateField(id, strValue);
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">Model.plugin_link</param>
        /// <returns>True Or False</returns>
        public bool Update(Model.plugin_link model)
        {
              return dal.Update(model);
        }
        #endregion

        #region 删除一条数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="id">ID号</param>
        /// <returns>True Or False</returns>
        public bool Delete(int id)
        {
              return dal.Delete(id);
        }
        #endregion

        #region 返回一个实体
        /// <summary>
        /// 返回一个实体
        /// </summary>
        /// <param name="id">ID号</param>
        /// <returns>Model.plugin_link</returns>
        public Model.plugin_link GetModel(int id)
        {
              return dal.GetModel(id);
        }
        #endregion

        #region 获得前几行数据
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere)
        {
            return dal.GetList(Top, strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        /// <param name="Top">数量</param>
        /// <param name="strWhere">条件</param>
        /// <param name="filedOrder">排序</param>
        /// <returns>DataTable</returns>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
              return dal.GetList(Top, strWhere, filedOrder);
        }
        #endregion

        #region 获取分页列表
        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <param name="pageSize">分页数量</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="strWhere">条件</param>
        /// <param name="filedOrder">排序</param>
        /// <param name="recordCount">返回数据总数</param>
        /// <returns>DataTable</returns>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
              return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }
        #endregion
    }
}
