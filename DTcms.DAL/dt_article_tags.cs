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
    public partial class dt_article_tags
    {
        private string column;
        private string databaseprefix; 
        public dt_article_tags(string _databaseprefix)
        {
            this.databaseprefix = _databaseprefix;
            this.column = "id,title,is_red,sort_id,add_time,site_id,call_index,seo_title,seo_keywords,seo_description,click,content";
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
            return DbHelperSQL.Exists("select count(1) from [" + databaseprefix + "dt_article_tags] where id=@id", parameters);
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
            return DbHelperSQL.Exists("select count(1) from [" + databaseprefix + "dt_article_tags] where title=@title", parameters);
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
            object obj = DbHelperSQL.GetSingle("select title from [" + databaseprefix + "dt_article_tags] where id=@id", parameters);
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
            strSql.Append("select count(*) as H from [" + databaseprefix + "dt_article_tags]");
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
        /// <param name="model">Model.dt_article_tags</param>
        /// <returns>ID</returns>
        public int Add(Model.dt_article_tags model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [" + databaseprefix + "dt_article_tags](");
            strSql.Append("title,is_red,sort_id,add_time,site_id,call_index,seo_title,seo_keywords,seo_description,click,content");
            strSql.Append(") values(");
            strSql.Append("@title,@is_red,@sort_id,@add_time,@site_id,@call_index,@seo_title,@seo_keywords,@seo_description,@click,@content)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                new SqlParameter("@title", SqlDbType.NVarChar,100),
                new SqlParameter("@is_red", SqlDbType.TinyInt,1),
                new SqlParameter("@sort_id", SqlDbType.Int,4),
                new SqlParameter("@add_time", SqlDbType.DateTime),
                new SqlParameter("@site_id", SqlDbType.Int,4),
                new SqlParameter("@call_index", SqlDbType.NVarChar,50),
                new SqlParameter("@seo_title", SqlDbType.NVarChar,255),
                new SqlParameter("@seo_keywords", SqlDbType.NVarChar,255),
                new SqlParameter("@seo_description", SqlDbType.NVarChar,255),
                new SqlParameter("@click", SqlDbType.Int,4),
				new SqlParameter("@content", SqlDbType.NText)
            };
            parameters[0].Value = model.title;
            parameters[1].Value = model.is_red;
            parameters[2].Value = model.sort_id;
            parameters[3].Value = model.add_time;
            parameters[4].Value = model.site_id;
            parameters[5].Value = model.call_index;
            parameters[6].Value = model.seo_title;
            parameters[7].Value = model.seo_keywords;
            parameters[8].Value = model.seo_description;
            parameters[9].Value = model.click;
            parameters[10].Value = model.content;
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
            DbHelperSQL.ExecuteSql("update [" + databaseprefix + "dt_article_tags] set " + strValue + " where id=" + id);
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">Model.dt_article_tags</param>
        /// <returns>True or False</returns>
        public bool Update(Model.dt_article_tags model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [" + databaseprefix + "dt_article_tags] set ");
            strSql.Append("title=@title,");
            strSql.Append("is_red=@is_red,");
            strSql.Append("sort_id=@sort_id,");
            strSql.Append("add_time=@add_time,");
            strSql.Append("site_id=@site_id,");
            strSql.Append("call_index=@call_index,");
            strSql.Append("seo_title=@seo_title,");
            strSql.Append("seo_keywords=@seo_keywords,");
            strSql.Append("seo_description=@seo_description,");
            strSql.Append("click=@click,");
            strSql.Append("content=@content");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                new SqlParameter("@title", SqlDbType.NVarChar,100),
                new SqlParameter("@is_red", SqlDbType.TinyInt,1),
                new SqlParameter("@sort_id", SqlDbType.Int,4),
                new SqlParameter("@add_time", SqlDbType.DateTime),
                new SqlParameter("@site_id", SqlDbType.Int,4),
                new SqlParameter("@call_index", SqlDbType.NVarChar,50),
                new SqlParameter("@seo_title", SqlDbType.NVarChar,255),
                new SqlParameter("@seo_keywords", SqlDbType.NVarChar,255),
                new SqlParameter("@seo_description", SqlDbType.NVarChar,255),
                new SqlParameter("@click", SqlDbType.Int,4),
				new SqlParameter("@content", SqlDbType.NText),
                new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = model.title;
            parameters[1].Value = model.is_red;
            parameters[2].Value = model.sort_id;
            parameters[3].Value = model.add_time;
            parameters[4].Value = model.site_id;
            parameters[5].Value = model.call_index;
            parameters[6].Value = model.seo_title;
            parameters[7].Value = model.seo_keywords;
            parameters[8].Value = model.seo_description;
            parameters[9].Value = model.click;
            parameters[10].Value = model.content;
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
            int rows = DbHelperSQL.ExecuteSql("delete from [" + databaseprefix + "dt_article_tags] where id=@id", parameters);
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
        /// <returns>Model.dt_article_tags</returns>
        public Model.dt_article_tags GetModel(int id)
        {
            SqlParameter[] parameters = {
            		new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;
            DataSet ds = DbHelperSQL.Query("select " + this.column + " from [" + databaseprefix + "dt_article_tags] where id=@id", parameters);
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
            strSql.Append(this.column + " from [" + databaseprefix + "dt_article_tags]");
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
            strSql.Append("select * from [" + databaseprefix + "dt_article_tags]");
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
        /// <returns>Model.dt_article_tags</returns>
        private Model.dt_article_tags DataRowToModel(DataRow row)
        {
            Model.dt_article_tags model = new Model.dt_article_tags();
            if (row != null)
            {
            	if (null != row["id"] && "" != row["id"].ToString())
            	{
            		model.id = int.Parse(row["id"].ToString());
            	}
            	if (null != row["title"])
            	{
            		model.title = row["title"].ToString();
            	}
            	if (null != row["is_red"] && "" != row["is_red"].ToString())
            	{
            		model.is_red = int.Parse(row["is_red"].ToString());
            	}
            	if (null != row["sort_id"] && "" != row["sort_id"].ToString())
            	{
            		model.sort_id = int.Parse(row["sort_id"].ToString());
            	}
            	if (null != row["add_time"] && "" != row["add_time"].ToString())
            	{
            		model.add_time = DateTime.Parse(row["add_time"].ToString());
            	}
            	if (null != row["site_id"] && "" != row["site_id"].ToString())
            	{
            		model.site_id = int.Parse(row["site_id"].ToString());
            	}
            	if (null != row["call_index"])
            	{
            		model.call_index = row["call_index"].ToString();
            	}
            	if (null != row["seo_title"])
            	{
            		model.seo_title = row["seo_title"].ToString();
            	}
            	if (null != row["seo_keywords"])
            	{
            		model.seo_keywords = row["seo_keywords"].ToString();
            	}
            	if (null != row["seo_description"])
            	{
            		model.seo_description = row["seo_description"].ToString();
            	}
            	if (null != row["click"] && "" != row["click"].ToString())
            	{
            		model.click = int.Parse(row["click"].ToString());
            	}
            	if (null != row["content"])
            	{
            		model.content = row["content"].ToString();
            	}
            }
            return model;
        }
        #endregion
    }
}
