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
    public partial class dt_article_attach
    {
        private string column;
        private string databaseprefix; 
        public dt_article_attach(string _databaseprefix)
        {
            this.databaseprefix = _databaseprefix;
            this.column = "id,article_id,file_name,file_path,file_size,file_ext,down_num,point,add_time";
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
            return DbHelperSQL.Exists("select count(1) from [" + databaseprefix + "dt_article_attach] where id=@id", parameters);
        }
        /// <summary>
        /// 返回数据总数
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns>总数</returns>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H from [" + databaseprefix + "dt_article_attach]");
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
        /// <param name="model">Model.dt_article_attach</param>
        /// <returns>ID</returns>
        public int Add(Model.dt_article_attach model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [" + databaseprefix + "dt_article_attach](");
            strSql.Append("article_id,file_name,file_path,file_size,file_ext,down_num,point,add_time");
            strSql.Append(") values(");
            strSql.Append("@article_id,@file_name,@file_path,@file_size,@file_ext,@down_num,@point,@add_time)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                new SqlParameter("@article_id", SqlDbType.Int,4),
                new SqlParameter("@file_name", SqlDbType.NVarChar,255),
                new SqlParameter("@file_path", SqlDbType.NVarChar,255),
                new SqlParameter("@file_size", SqlDbType.Int,4),
                new SqlParameter("@file_ext", SqlDbType.NVarChar,20),
                new SqlParameter("@down_num", SqlDbType.Int,4),
                new SqlParameter("@point", SqlDbType.Int,4),
				new SqlParameter("@add_time", SqlDbType.DateTime)
            };
            parameters[0].Value = model.article_id;
            parameters[1].Value = model.file_name;
            parameters[2].Value = model.file_path;
            parameters[3].Value = model.file_size;
            parameters[4].Value = model.file_ext;
            parameters[5].Value = model.down_num;
            parameters[6].Value = model.point;
            parameters[7].Value = model.add_time;
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
            DbHelperSQL.ExecuteSql("update [" + databaseprefix + "dt_article_attach] set " + strValue + " where id=" + id);
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">Model.dt_article_attach</param>
        /// <returns>True or False</returns>
        public bool Update(Model.dt_article_attach model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [" + databaseprefix + "dt_article_attach] set ");
            strSql.Append("article_id=@article_id,");
            strSql.Append("file_name=@file_name,");
            strSql.Append("file_path=@file_path,");
            strSql.Append("file_size=@file_size,");
            strSql.Append("file_ext=@file_ext,");
            strSql.Append("down_num=@down_num,");
            strSql.Append("point=@point,");
            strSql.Append("add_time=@add_time");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                new SqlParameter("@article_id", SqlDbType.Int,4),
                new SqlParameter("@file_name", SqlDbType.NVarChar,255),
                new SqlParameter("@file_path", SqlDbType.NVarChar,255),
                new SqlParameter("@file_size", SqlDbType.Int,4),
                new SqlParameter("@file_ext", SqlDbType.NVarChar,20),
                new SqlParameter("@down_num", SqlDbType.Int,4),
                new SqlParameter("@point", SqlDbType.Int,4),
				new SqlParameter("@add_time", SqlDbType.DateTime),
                new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = model.article_id;
            parameters[1].Value = model.file_name;
            parameters[2].Value = model.file_path;
            parameters[3].Value = model.file_size;
            parameters[4].Value = model.file_ext;
            parameters[5].Value = model.down_num;
            parameters[6].Value = model.point;
            parameters[7].Value = model.add_time;
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
            int rows = DbHelperSQL.ExecuteSql("delete from [" + databaseprefix + "dt_article_attach] where id=@id", parameters);
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
        /// <returns>Model.dt_article_attach</returns>
        public Model.dt_article_attach GetModel(int id)
        {
            SqlParameter[] parameters = {
            		new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;
            DataSet ds = DbHelperSQL.Query("select " + this.column + " from [" + databaseprefix + "dt_article_attach] where id=@id", parameters);
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
            strSql.Append(this.column + " from [" + databaseprefix + "dt_article_attach]");
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
            strSql.Append("select * from [" + databaseprefix + "dt_article_attach]");
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
        /// <returns>Model.dt_article_attach</returns>
        private Model.dt_article_attach DataRowToModel(DataRow row)
        {
            Model.dt_article_attach model = new Model.dt_article_attach();
            if (row != null)
            {
            	if (null != row["id"] && "" != row["id"].ToString())
            	{
            		model.id = int.Parse(row["id"].ToString());
            	}
            	if (null != row["article_id"] && "" != row["article_id"].ToString())
            	{
            		model.article_id = int.Parse(row["article_id"].ToString());
            	}
            	if (null != row["file_name"])
            	{
            		model.file_name = row["file_name"].ToString();
            	}
            	if (null != row["file_path"])
            	{
            		model.file_path = row["file_path"].ToString();
            	}
            	if (null != row["file_size"] && "" != row["file_size"].ToString())
            	{
            		model.file_size = int.Parse(row["file_size"].ToString());
            	}
            	if (null != row["file_ext"])
            	{
            		model.file_ext = row["file_ext"].ToString();
            	}
            	if (null != row["down_num"] && "" != row["down_num"].ToString())
            	{
            		model.down_num = int.Parse(row["down_num"].ToString());
            	}
            	if (null != row["point"] && "" != row["point"].ToString())
            	{
            		model.point = int.Parse(row["point"].ToString());
            	}
            	if (null != row["add_time"] && "" != row["add_time"].ToString())
            	{
            		model.add_time = DateTime.Parse(row["add_time"].ToString());
            	}
            }
            return model;
        }
        #endregion
    }
}
