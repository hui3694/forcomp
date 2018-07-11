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
    public partial class dt_user_message
    {
        private string column;
        private string databaseprefix; 
        public dt_user_message(string _databaseprefix)
        {
            this.databaseprefix = _databaseprefix;
            this.column = "id,type,post_user_name,accept_user_name,is_read,title,content,post_time,read_time";
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
            return DbHelperSQL.Exists("select count(1) from [" + databaseprefix + "dt_user_message] where id=@id", parameters);
        }

        /// <summary>
        /// 按名称查询是否存在记录
        /// </summary>
        /// <param name="title">标题</param>
        /// <returns>True or False</returns>
        public bool Exists(string title)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@title", SqlDbType.VarChar,200)
            };
            parameters[0].Value = title;
            return DbHelperSQL.Exists("select count(1) from [" + databaseprefix + "dt_user_message] where title=@title", parameters);
        }

        /// <summary>
        /// 返回标题
        /// </summary>
        /// <param name="id">ID号</param>
        /// <returns>标题</returns>
        public string GetTitle(int id)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;
            object obj = DbHelperSQL.GetSingle("select title from [" + databaseprefix + "dt_user_message] where id=@id", parameters);
            if (null != obj)
            {
                return obj.ToString();
            }
            return "";
        }
        /// <summary>
        /// 返回数据总数
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns>总数</returns>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H from [" + databaseprefix + "dt_user_message]");
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
        /// <param name="model">Model.dt_user_message</param>
        /// <returns>ID</returns>
        public int Add(Model.dt_user_message model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [" + databaseprefix + "dt_user_message](");
            strSql.Append("type,post_user_name,accept_user_name,is_read,title,content,post_time,read_time");
            strSql.Append(") values(");
            strSql.Append("@type,@post_user_name,@accept_user_name,@is_read,@title,@content,@post_time,@read_time)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                new SqlParameter("@type", SqlDbType.TinyInt,1),
                new SqlParameter("@post_user_name", SqlDbType.NVarChar,100),
                new SqlParameter("@accept_user_name", SqlDbType.NVarChar,100),
                new SqlParameter("@is_read", SqlDbType.TinyInt,1),
                new SqlParameter("@title", SqlDbType.NVarChar,100),
                new SqlParameter("@content", SqlDbType.NText),
                new SqlParameter("@post_time", SqlDbType.DateTime),
				new SqlParameter("@read_time", SqlDbType.DateTime)
            };
            parameters[0].Value = model.type;
            parameters[1].Value = model.post_user_name;
            parameters[2].Value = model.accept_user_name;
            parameters[3].Value = model.is_read;
            parameters[4].Value = model.title;
            parameters[5].Value = model.content;
            parameters[6].Value = model.post_time;
            parameters[7].Value = model.read_time;
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
            DbHelperSQL.ExecuteSql("update [" + databaseprefix + "dt_user_message] set " + strValue + " where id=" + id);
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">Model.dt_user_message</param>
        /// <returns>True or False</returns>
        public bool Update(Model.dt_user_message model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [" + databaseprefix + "dt_user_message] set ");
            strSql.Append("type=@type,");
            strSql.Append("post_user_name=@post_user_name,");
            strSql.Append("accept_user_name=@accept_user_name,");
            strSql.Append("is_read=@is_read,");
            strSql.Append("title=@title,");
            strSql.Append("content=@content,");
            strSql.Append("post_time=@post_time,");
            strSql.Append("read_time=@read_time");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                new SqlParameter("@type", SqlDbType.TinyInt,1),
                new SqlParameter("@post_user_name", SqlDbType.NVarChar,100),
                new SqlParameter("@accept_user_name", SqlDbType.NVarChar,100),
                new SqlParameter("@is_read", SqlDbType.TinyInt,1),
                new SqlParameter("@title", SqlDbType.NVarChar,100),
                new SqlParameter("@content", SqlDbType.NText),
                new SqlParameter("@post_time", SqlDbType.DateTime),
				new SqlParameter("@read_time", SqlDbType.DateTime),
                new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = model.type;
            parameters[1].Value = model.post_user_name;
            parameters[2].Value = model.accept_user_name;
            parameters[3].Value = model.is_read;
            parameters[4].Value = model.title;
            parameters[5].Value = model.content;
            parameters[6].Value = model.post_time;
            parameters[7].Value = model.read_time;
            parameters[8].Value = model.id;
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
            int rows = DbHelperSQL.ExecuteSql("delete from [" + databaseprefix + "dt_user_message] where id=@id", parameters);
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
        /// <returns>Model.dt_user_message</returns>
        public Model.dt_user_message GetModel(int id)
        {
            SqlParameter[] parameters = {
            		new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;
            DataSet ds = DbHelperSQL.Query("select " + this.column + " from [" + databaseprefix + "dt_user_message] where id=@id", parameters);
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
            strSql.Append(this.column + " from [" + databaseprefix + "dt_user_message]");
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
            strSql.Append("select * from [" + databaseprefix + "dt_user_message]");
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
        /// <returns>Model.dt_user_message</returns>
        private Model.dt_user_message DataRowToModel(DataRow row)
        {
            Model.dt_user_message model = new Model.dt_user_message();
            if (row != null)
            {
            	if (null != row["id"] && "" != row["id"].ToString())
            	{
            		model.id = int.Parse(row["id"].ToString());
            	}
            	if (null != row["type"] && "" != row["type"].ToString())
            	{
            		model.type = int.Parse(row["type"].ToString());
            	}
            	if (null != row["post_user_name"])
            	{
            		model.post_user_name = row["post_user_name"].ToString();
            	}
            	if (null != row["accept_user_name"])
            	{
            		model.accept_user_name = row["accept_user_name"].ToString();
            	}
            	if (null != row["is_read"] && "" != row["is_read"].ToString())
            	{
            		model.is_read = int.Parse(row["is_read"].ToString());
            	}
            	if (null != row["title"])
            	{
            		model.title = row["title"].ToString();
            	}
            	if (null != row["content"])
            	{
            		model.content = row["content"].ToString();
            	}
            	if (null != row["post_time"] && "" != row["post_time"].ToString())
            	{
            		model.post_time = DateTime.Parse(row["post_time"].ToString());
            	}
            	if (null != row["read_time"] && "" != row["read_time"].ToString())
            	{
            		model.read_time = DateTime.Parse(row["read_time"].ToString());
            	}
            }
            return model;
        }
        #endregion
    }
}
