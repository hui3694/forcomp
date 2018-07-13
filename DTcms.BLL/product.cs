using System;
using System.Collections.Generic;
using System.Data;

namespace DTcms.BLL
{
    /// <summary>
    /// 业务逻辑层
    /// </summary>
    public class product
    {
        private readonly Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig();
        private readonly DAL.product dal;

        public product()  
        {
              dal = new DAL.product("fg_");
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
        /// 按名称查询是否存在记录
        /// </summary>
        /// <param name="title">标题</param>
        /// <returns>True Or False</returns>
        public bool Exists(string title)
        {
              return dal.Exists(title);
        }

        /// <summary>
        /// 按ID号查询标题
        /// </summary>
        /// <param name="id">ID号</param>
        /// <returns>标题</returns>
        public string GetTitle(int id)
        {
              return dal.GetTitle(id);
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
        /// <param name="model">Model.product</param>
        /// <returns>ID</returns>
        public int Add(Model.product model)
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
        /// <param name="model">Model.product</param>
        /// <returns>True Or False</returns>
        public bool Update(Model.product model)
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
        /// <returns>Model.product</returns>
        public Model.product GetModel(int id)
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

        public DataSet GetCityList(string where)
        {
            return dal.GetCityList(where);
        }

        public DataSet GetUserComment(int user_id)
        {
            return dal.GetUserComment(user_id);
        }
    }
}
