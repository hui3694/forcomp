using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTcms.DBUtility;
using DTcms.Common;

namespace DTcms.DAL
{
    /// <summary>
    /// 金额
    /// </summary>
    public partial class amount
    {
        private string column;
        private string databaseprefix; 
        public amount(string _databaseprefix)
        {
            this.databaseprefix = _databaseprefix;
            this.column = "id,user_id,type,amount,remark,time";
        }

        #region 基本方法
        /// <summary>
        /// 按ID号查询是否存在记录
        /// </summary>
        /// <param name="id">ID号</param>
        /// <returns>True or False</returns>
        public bool Exists(int id)
        {
            SqlParameter[] parameters = {
            	new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;
            return DbHelperSQL.Exists("select count(1) from [" + databaseprefix + "amount] where id=@id", parameters);
        }
        /// <summary>
        /// 返回数据总数
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns>总数</returns>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H from [" + databaseprefix + "amount]");
            if ("" != strWhere.Trim())
            {
            	strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model">Model.amount</param>
        /// <returns>ID</returns>
        public int Add(Model.amount model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [" + databaseprefix + "amount](");
            strSql.Append("user_id,type,amount,remark,time");
            strSql.Append(") values(");
            strSql.Append("@user_id,@type,@amount,@remark,@time)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                new SqlParameter("@user_id", SqlDbType.Int,4),
                new SqlParameter("@type", SqlDbType.Int,4),
                new SqlParameter("@amount", SqlDbType.Decimal,13),
                new SqlParameter("@remark", SqlDbType.NText),
				new SqlParameter("@time", SqlDbType.DateTime)
            };
            parameters[0].Value = model.user_id;
            parameters[1].Value = model.type;
            parameters[2].Value = model.Amount;
            parameters[3].Value = model.remark;
            parameters[4].Value = model.time;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (null != obj)
            {
                return Convert.ToInt32(obj);
            }
            else
            {
                return 0;
            }
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
            DbHelperSQL.ExecuteSql("update [" + databaseprefix + "amount] set " + strValue + " where id=" + id);
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">Model.amount</param>
        /// <returns>True or False</returns>
        public bool Update(Model.amount model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [" + databaseprefix + "amount] set ");
            strSql.Append("user_id=@user_id,");
            strSql.Append("type=@type,");
            strSql.Append("amount=@amount,");
            strSql.Append("remark=@remark,");
            strSql.Append("time=@time");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                new SqlParameter("@user_id", SqlDbType.Int,4),
                new SqlParameter("@type", SqlDbType.Int,4),
                new SqlParameter("@amount", SqlDbType.Decimal,13),
                new SqlParameter("@remark", SqlDbType.NText),
				new SqlParameter("@time", SqlDbType.DateTime),
                new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = model.user_id;
            parameters[1].Value = model.type;
            parameters[2].Value = model.Amount;
            parameters[3].Value = model.remark;
            parameters[4].Value = model.time;
            parameters[5].Value = model.id;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region 删除一条数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="id">ID号</param>
        /// <returns>True or False</returns>
        public bool Delete(int id)
        {
            SqlParameter[] parameters = {
            		new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;
            int rows = DbHelperSQL.ExecuteSql("delete from [" + databaseprefix + "amount] where id=@id", parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 返回一个实体
        /// <summary>
        /// 按ID返回一个实体
        /// </summary>
        /// <param name="id">ID号</param>
        /// <returns>Model.amount</returns>
        public Model.amount GetModel(int id)
        {
            SqlParameter[] parameters = {
            		new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;
            DataSet ds = DbHelperSQL.Query("select " + this.column + " from [" + databaseprefix + "amount] where id=@id", parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
              strSql.Append(" top " + Top.ToString()+" ");
            }
            strSql.Append(this.column + " from [" + databaseprefix + "amount]");
            if ("" != strWhere.Trim())
            {
              strSql.Append(" where " + strWhere);
            }
            if ("" != filedOrder.Trim())
            {
              strSql.Append(" order by " + filedOrder);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion

        #region 获得查询分页数据
        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        /// <param name="pageSize">分页数量</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="strWhere">条件</param>
        /// <param name="filedOrder">排序</param>
        /// <param name="recordCount">返回数据总数</param>
        /// <returns>DataTable</returns>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from [" + databaseprefix + "amount]");
            if ("" != strWhere.Trim())
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 组合成对象实体
        /// </summary>
        /// <param name="row">一行数据</param>
        /// <returns>Model.amount</returns>
        private Model.amount DataRowToModel(DataRow row)
        {
            Model.amount model = new Model.amount();
            if (row != null)
            {
            	if (null != row["id"] && "" != row["id"].ToString())
            	{
            		model.id = int.Parse(row["id"].ToString());
            	}
            	if (null != row["user_id"] && "" != row["user_id"].ToString())
            	{
            		model.user_id = int.Parse(row["user_id"].ToString());
            	}
            	if (null != row["type"] && "" != row["type"].ToString())
            	{
            		model.type = int.Parse(row["type"].ToString());
            	}
            	if (null != row["amount"] && "" != row["amount"].ToString())
            	{
            		model.Amount = decimal.Parse(row["amount"].ToString());
            	}
            	if (null != row["remark"])
            	{
            		model.remark = row["remark"].ToString();
            	}
            	if (null != row["time"] && "" != row["time"].ToString())
            	{
            		model.time = DateTime.Parse(row["time"].ToString());
            	}
            }
            return model;
        }
        #endregion
    }
}
