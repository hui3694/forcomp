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
    /// 数据库访问层
    /// </summary>
    public partial class dt_user_login_log
    {
        private string column;
        private string databaseprefix; 
        public dt_user_login_log(string _databaseprefix)
        {
            this.databaseprefix = _databaseprefix;
            this.column = "id,user_id,user_name,remark,login_time,login_ip";
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
            return DbHelperSQL.Exists("select count(1) from [" + databaseprefix + "dt_user_login_log] where id=@id", parameters);
        }
        /// <summary>
        /// 返回数据总数
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns>总数</returns>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H from [" + databaseprefix + "dt_user_login_log]");
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
        /// <param name="model">Model.dt_user_login_log</param>
        /// <returns>ID</returns>
        public int Add(Model.dt_user_login_log model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [" + databaseprefix + "dt_user_login_log](");
            strSql.Append("user_id,user_name,remark,login_time,login_ip");
            strSql.Append(") values(");
            strSql.Append("@user_id,@user_name,@remark,@login_time,@login_ip)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                new SqlParameter("@user_id", SqlDbType.Int,4),
                new SqlParameter("@user_name", SqlDbType.NVarChar,100),
                new SqlParameter("@remark", SqlDbType.NVarChar,255),
                new SqlParameter("@login_time", SqlDbType.DateTime),
				new SqlParameter("@login_ip", SqlDbType.NVarChar,50)
            };
            parameters[0].Value = model.user_id;
            parameters[1].Value = model.user_name;
            parameters[2].Value = model.remark;
            parameters[3].Value = model.login_time;
            parameters[4].Value = model.login_ip;
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
            DbHelperSQL.ExecuteSql("update [" + databaseprefix + "dt_user_login_log] set " + strValue + " where id=" + id);
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">Model.dt_user_login_log</param>
        /// <returns>True or False</returns>
        public bool Update(Model.dt_user_login_log model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [" + databaseprefix + "dt_user_login_log] set ");
            strSql.Append("user_id=@user_id,");
            strSql.Append("user_name=@user_name,");
            strSql.Append("remark=@remark,");
            strSql.Append("login_time=@login_time,");
            strSql.Append("login_ip=@login_ip");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                new SqlParameter("@user_id", SqlDbType.Int,4),
                new SqlParameter("@user_name", SqlDbType.NVarChar,100),
                new SqlParameter("@remark", SqlDbType.NVarChar,255),
                new SqlParameter("@login_time", SqlDbType.DateTime),
				new SqlParameter("@login_ip", SqlDbType.NVarChar,50),
                new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = model.user_id;
            parameters[1].Value = model.user_name;
            parameters[2].Value = model.remark;
            parameters[3].Value = model.login_time;
            parameters[4].Value = model.login_ip;
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
            int rows = DbHelperSQL.ExecuteSql("delete from [" + databaseprefix + "dt_user_login_log] where id=@id", parameters);
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
        /// <returns>Model.dt_user_login_log</returns>
        public Model.dt_user_login_log GetModel(int id)
        {
            SqlParameter[] parameters = {
            		new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;
            DataSet ds = DbHelperSQL.Query("select " + this.column + " from [" + databaseprefix + "dt_user_login_log] where id=@id", parameters);
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
            strSql.Append(this.column + " from [" + databaseprefix + "dt_user_login_log]");
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
            strSql.Append("select * from [" + databaseprefix + "dt_user_login_log]");
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
        /// <returns>Model.dt_user_login_log</returns>
        private Model.dt_user_login_log DataRowToModel(DataRow row)
        {
            Model.dt_user_login_log model = new Model.dt_user_login_log();
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
            	if (null != row["user_name"])
            	{
            		model.user_name = row["user_name"].ToString();
            	}
            	if (null != row["remark"])
            	{
            		model.remark = row["remark"].ToString();
            	}
            	if (null != row["login_time"] && "" != row["login_time"].ToString())
            	{
            		model.login_time = DateTime.Parse(row["login_time"].ToString());
            	}
            	if (null != row["login_ip"])
            	{
            		model.login_ip = row["login_ip"].ToString();
            	}
            }
            return model;
        }
        #endregion
    }
}
