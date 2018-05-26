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
    public partial class plugin_feedback
    {
        private string column;
        private string databaseprefix; 
        public plugin_feedback(string _databaseprefix)
        {
            this.databaseprefix = _databaseprefix;
            this.column = "id,site_path,title,content,user_name,user_tel,user_qq,user_email,add_time,reply_content,reply_time,is_lock";
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
            return DbHelperSQL.Exists("select count(1) from [" + databaseprefix + "plugin_feedback] where id=@id", parameters);
        }
        /// <summary>
        /// 返回数据总数
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns>总数</returns>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H from [" + databaseprefix + "plugin_feedback]");
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
        /// <param name="model">Model.plugin_feedback</param>
        /// <returns>ID</returns>
        public int Add(Model.plugin_feedback model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [" + databaseprefix + "plugin_feedback](");
            strSql.Append("site_path,title,content,user_name,user_tel,user_qq,user_email,add_time,reply_content,reply_time,is_lock");
            strSql.Append(") values(");
            strSql.Append("@site_path,@title,@content,@user_name,@user_tel,@user_qq,@user_email,@add_time,@reply_content,@reply_time,@is_lock)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                new SqlParameter("@site_path", SqlDbType.NVarChar,100),
                new SqlParameter("@title", SqlDbType.NVarChar,100),
                new SqlParameter("@content", SqlDbType.NText),
                new SqlParameter("@user_name", SqlDbType.NVarChar,50),
                new SqlParameter("@user_tel", SqlDbType.NVarChar,30),
                new SqlParameter("@user_qq", SqlDbType.NVarChar,30),
                new SqlParameter("@user_email", SqlDbType.NVarChar,100),
                new SqlParameter("@add_time", SqlDbType.DateTime),
                new SqlParameter("@reply_content", SqlDbType.NText),
                new SqlParameter("@reply_time", SqlDbType.DateTime),
				new SqlParameter("@is_lock", SqlDbType.TinyInt,1)
            };
            parameters[0].Value = model.site_path;
            parameters[1].Value = model.title;
            parameters[2].Value = model.content;
            parameters[3].Value = model.user_name;
            parameters[4].Value = model.user_tel;
            parameters[5].Value = model.user_qq;
            parameters[6].Value = model.user_email;
            parameters[7].Value = model.add_time;
            parameters[8].Value = model.reply_content;
            parameters[9].Value = model.reply_time;
            parameters[10].Value = model.is_lock;
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [" + databaseprefix + "plugin_feedback] set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">Model.plugin_feedback</param>
        /// <returns>True or False</returns>
        public bool Update(Model.plugin_feedback model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [" + databaseprefix + "plugin_feedback] set ");
            strSql.Append("site_path=@site_path,");
            strSql.Append("title=@title,");
            strSql.Append("content=@content,");
            strSql.Append("user_name=@user_name,");
            strSql.Append("user_tel=@user_tel,");
            strSql.Append("user_qq=@user_qq,");
            strSql.Append("user_email=@user_email,");
            strSql.Append("add_time=@add_time,");
            strSql.Append("reply_content=@reply_content,");
            strSql.Append("reply_time=@reply_time,");
            strSql.Append("is_lock=@is_lock");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                new SqlParameter("@site_path", SqlDbType.NVarChar,100),
                new SqlParameter("@title", SqlDbType.NVarChar,100),
                new SqlParameter("@content", SqlDbType.NText),
                new SqlParameter("@user_name", SqlDbType.NVarChar,50),
                new SqlParameter("@user_tel", SqlDbType.NVarChar,30),
                new SqlParameter("@user_qq", SqlDbType.NVarChar,30),
                new SqlParameter("@user_email", SqlDbType.NVarChar,100),
                new SqlParameter("@add_time", SqlDbType.DateTime),
                new SqlParameter("@reply_content", SqlDbType.NText),
                new SqlParameter("@reply_time", SqlDbType.DateTime),
				new SqlParameter("@is_lock", SqlDbType.TinyInt,1),
                new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = model.site_path;
            parameters[1].Value = model.title;
            parameters[2].Value = model.content;
            parameters[3].Value = model.user_name;
            parameters[4].Value = model.user_tel;
            parameters[5].Value = model.user_qq;
            parameters[6].Value = model.user_email;
            parameters[7].Value = model.add_time;
            parameters[8].Value = model.reply_content;
            parameters[9].Value = model.reply_time;
            parameters[10].Value = model.is_lock;
            parameters[11].Value = model.id;
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
            int rows = DbHelperSQL.ExecuteSql("delete from [" + databaseprefix + "plugin_feedback] where id=@id", parameters);
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
        /// <returns>Model.plugin_feedback</returns>
        public Model.plugin_feedback GetModel(int id)
        {
            SqlParameter[] parameters = {
            		new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;
            DataSet ds = DbHelperSQL.Query("select " + this.column + " from [" + databaseprefix + "plugin_feedback] where id=@id", parameters);
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
            strSql.Append(this.column + " from [" + databaseprefix + "plugin_feedback]");
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
            strSql.Append("select * from [" + databaseprefix + "plugin_feedback]");
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
        /// <returns>Model.plugin_feedback</returns>
        private Model.plugin_feedback DataRowToModel(DataRow row)
        {
            Model.plugin_feedback model = new Model.plugin_feedback();
            if (row != null)
            {
            	if (null != row["id"] && "" != row["id"].ToString())
            	{
            		model.id = int.Parse(row["id"].ToString());
            	}
            	if (null != row["site_path"])
            	{
            		model.site_path = row["site_path"].ToString();
            	}
            	if (null != row["title"])
            	{
            		model.title = row["title"].ToString();
            	}
            	if (null != row["content"])
            	{
            		model.content = row["content"].ToString();
            	}
            	if (null != row["user_name"])
            	{
            		model.user_name = row["user_name"].ToString();
            	}
            	if (null != row["user_tel"])
            	{
            		model.user_tel = row["user_tel"].ToString();
            	}
            	if (null != row["user_qq"])
            	{
            		model.user_qq = row["user_qq"].ToString();
            	}
            	if (null != row["user_email"])
            	{
            		model.user_email = row["user_email"].ToString();
            	}
            	if (null != row["add_time"] && "" != row["add_time"].ToString())
            	{
            		model.add_time = DateTime.Parse(row["add_time"].ToString());
            	}
            	if (null != row["reply_content"])
            	{
            		model.reply_content = row["reply_content"].ToString();
            	}
            	if (null != row["reply_time"] && "" != row["reply_time"].ToString())
            	{
            		model.reply_time = DateTime.Parse(row["reply_time"].ToString());
            	}
            	if (null != row["is_lock"] && "" != row["is_lock"].ToString())
            	{
            		model.is_lock = int.Parse(row["is_lock"].ToString());
            	}
            }
            return model;
        }
        #endregion
    }
}
