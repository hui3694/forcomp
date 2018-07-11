using System;
using System.Collections.Generic;
using System.Data;

namespace DTcms.BLL
{
    /// <summary>
    /// 业务逻辑层
    /// </summary>
    public class share_log
    {
        private readonly Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig();
        private readonly DAL.share_log dal;

        public share_log()  
        {
              dal = new DAL.share_log("fg_");
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
        /// <param name="model">Model.share_log</param>
        /// <returns>ID</returns>
        public int Add(Model.share_log model)
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
        /// <param name="model">Model.share_log</param>
        /// <returns>True Or False</returns>
        public bool Update(Model.share_log model)
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
        /// <returns>Model.share_log</returns>
        public Model.share_log GetModel(int id)
        {
              return dal.GetModel(id);
        }
        #endregion

        #region 获得前几行数据
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
