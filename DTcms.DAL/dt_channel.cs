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
    public partial class dt_channel
    {
        private string column;
        private string databaseprefix; 
        public dt_channel(string _databaseprefix)
        {
            this.databaseprefix = _databaseprefix;
            this.column = "id,site_id,name,title,is_albums,is_attach,is_spec,sort_id,seo_title,seo_keywords,seo_description,is_type,is_attribute,is_comment,height,width,is_recycle";
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
            return DbHelperSQL.Exists("select count(1) from [" + databaseprefix + "dt_channel] where id=@id", parameters);
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
            return DbHelperSQL.Exists("select count(1) from [" + databaseprefix + "dt_channel] where title=@title", parameters);
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
            object obj = DbHelperSQL.GetSingle("select title from [" + databaseprefix + "dt_channel] where id=@id", parameters);
            if (null != obj)
            {
                return obj.ToString();
            }
            return "";
        }

        /// <summary>
        /// 返回名称
        /// </summary>
        /// <param name="id">ID号</param>
        /// <returns>名称</returns>
        public string GetName(int id)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;
            object obj = DbHelperSQL.GetSingle("select name from [" + databaseprefix + "dt_channel] where id=@id", parameters);
            if (null != obj)
            {
                return obj.ToString();
            }
            return "";
        }

        /// <summary>
        /// 根据名称查询ID
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns>ID</returns>
        public int GetId(string name)
        {
            SqlParameter[] parameters = {
        					new SqlParameter("@name", SqlDbType.VarChar,50)};
            parameters[0].Value = name;
            object obj = DbHelperSQL.GetSingle("select id from [" + databaseprefix + "dt_channel] where name=@name ", parameters);
            if (null != obj)
            {
                return Convert.ToInt32(obj);
            }
            return 0;
        }
        /// <summary>
        /// 返回数据总数
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns>总数</returns>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H from [" + databaseprefix + "dt_channel]");
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
        /// <param name="model">Model.dt_channel</param>
        /// <returns>ID</returns>
        public int Add(Model.dt_channel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [" + databaseprefix + "dt_channel](");
            strSql.Append("site_id,name,title,is_albums,is_attach,is_spec,sort_id,seo_title,seo_keywords,seo_description,is_type,is_attribute,is_comment,height,width,is_recycle");
            strSql.Append(") values(");
            strSql.Append("@site_id,@name,@title,@is_albums,@is_attach,@is_spec,@sort_id,@seo_title,@seo_keywords,@seo_description,@is_type,@is_attribute,@is_comment,@height,@width,@is_recycle)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                new SqlParameter("@site_id", SqlDbType.Int,4),
                new SqlParameter("@name", SqlDbType.VarChar,50),
                new SqlParameter("@title", SqlDbType.VarChar,100),
                new SqlParameter("@is_albums", SqlDbType.TinyInt,1),
                new SqlParameter("@is_attach", SqlDbType.TinyInt,1),
                new SqlParameter("@is_spec", SqlDbType.TinyInt,1),
                new SqlParameter("@sort_id", SqlDbType.Int,4),
                new SqlParameter("@seo_title", SqlDbType.NVarChar,255),
                new SqlParameter("@seo_keywords", SqlDbType.NVarChar,255),
                new SqlParameter("@seo_description", SqlDbType.NVarChar,255),
                new SqlParameter("@is_type", SqlDbType.TinyInt,1),
                new SqlParameter("@is_attribute", SqlDbType.TinyInt,1),
                new SqlParameter("@is_comment", SqlDbType.TinyInt,1),
                new SqlParameter("@height", SqlDbType.Int,4),
                new SqlParameter("@width", SqlDbType.Int,4),
				new SqlParameter("@is_recycle", SqlDbType.TinyInt,1)
            };
            parameters[0].Value = model.site_id;
            parameters[1].Value = model.name;
            parameters[2].Value = model.title;
            parameters[3].Value = model.is_albums;
            parameters[4].Value = model.is_attach;
            parameters[5].Value = model.is_spec;
            parameters[6].Value = model.sort_id;
            parameters[7].Value = model.seo_title;
            parameters[8].Value = model.seo_keywords;
            parameters[9].Value = model.seo_description;
            parameters[10].Value = model.is_type;
            parameters[11].Value = model.is_attribute;
            parameters[12].Value = model.is_comment;
            parameters[13].Value = model.height;
            parameters[14].Value = model.width;
            parameters[15].Value = model.is_recycle;
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
            DbHelperSQL.ExecuteSql("update [" + databaseprefix + "dt_channel] set " + strValue + " where id=" + id);
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">Model.dt_channel</param>
        /// <returns>True or False</returns>
        public bool Update(Model.dt_channel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [" + databaseprefix + "dt_channel] set ");
            strSql.Append("site_id=@site_id,");
            strSql.Append("name=@name,");
            strSql.Append("title=@title,");
            strSql.Append("is_albums=@is_albums,");
            strSql.Append("is_attach=@is_attach,");
            strSql.Append("is_spec=@is_spec,");
            strSql.Append("sort_id=@sort_id,");
            strSql.Append("seo_title=@seo_title,");
            strSql.Append("seo_keywords=@seo_keywords,");
            strSql.Append("seo_description=@seo_description,");
            strSql.Append("is_type=@is_type,");
            strSql.Append("is_attribute=@is_attribute,");
            strSql.Append("is_comment=@is_comment,");
            strSql.Append("height=@height,");
            strSql.Append("width=@width,");
            strSql.Append("is_recycle=@is_recycle");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                new SqlParameter("@site_id", SqlDbType.Int,4),
                new SqlParameter("@name", SqlDbType.VarChar,50),
                new SqlParameter("@title", SqlDbType.VarChar,100),
                new SqlParameter("@is_albums", SqlDbType.TinyInt,1),
                new SqlParameter("@is_attach", SqlDbType.TinyInt,1),
                new SqlParameter("@is_spec", SqlDbType.TinyInt,1),
                new SqlParameter("@sort_id", SqlDbType.Int,4),
                new SqlParameter("@seo_title", SqlDbType.NVarChar,255),
                new SqlParameter("@seo_keywords", SqlDbType.NVarChar,255),
                new SqlParameter("@seo_description", SqlDbType.NVarChar,255),
                new SqlParameter("@is_type", SqlDbType.TinyInt,1),
                new SqlParameter("@is_attribute", SqlDbType.TinyInt,1),
                new SqlParameter("@is_comment", SqlDbType.TinyInt,1),
                new SqlParameter("@height", SqlDbType.Int,4),
                new SqlParameter("@width", SqlDbType.Int,4),
				new SqlParameter("@is_recycle", SqlDbType.TinyInt,1),
                new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = model.site_id;
            parameters[1].Value = model.name;
            parameters[2].Value = model.title;
            parameters[3].Value = model.is_albums;
            parameters[4].Value = model.is_attach;
            parameters[5].Value = model.is_spec;
            parameters[6].Value = model.sort_id;
            parameters[7].Value = model.seo_title;
            parameters[8].Value = model.seo_keywords;
            parameters[9].Value = model.seo_description;
            parameters[10].Value = model.is_type;
            parameters[11].Value = model.is_attribute;
            parameters[12].Value = model.is_comment;
            parameters[13].Value = model.height;
            parameters[14].Value = model.width;
            parameters[15].Value = model.is_recycle;
            parameters[16].Value = model.id;
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
            int rows = DbHelperSQL.ExecuteSql("delete from [" + databaseprefix + "dt_channel] where id=@id", parameters);
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
        /// <returns>Model.dt_channel</returns>
        public Model.dt_channel GetModel(int id)
        {
            SqlParameter[] parameters = {
            		new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;
            DataSet ds = DbHelperSQL.Query("select " + this.column + " from [" + databaseprefix + "dt_channel] where id=@id", parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 按名称返回一个对象实体
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns>Model.dt_channel</returns>
        public Model.dt_channel GetModel(string name)
        {
            SqlParameter[] parameters = {
        					new SqlParameter("@name", SqlDbType.NVarChar,50)};
            parameters[0].Value = nav_name;
            object obj = DbHelperSQL.GetSingle("select id from [" + databaseprefix + "dt_channel] where name=@name", parameters);
            if (!string.IsNullOrEmpty(obj.ToString()))
            {
                return GetModel(Convert.ToInt32(obj));
            }
            return null;
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
            strSql.Append(this.column + " from [" + databaseprefix + "dt_channel]");
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
            strSql.Append("select * from [" + databaseprefix + "dt_channel]");
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
        /// <returns>Model.dt_channel</returns>
        private Model.dt_channel DataRowToModel(DataRow row)
        {
            Model.dt_channel model = new Model.dt_channel();
            if (row != null)
            {
            	if (null != row["id"] && "" != row["id"].ToString())
            	{
            		model.id = int.Parse(row["id"].ToString());
            	}
            	if (null != row["site_id"] && "" != row["site_id"].ToString())
            	{
            		model.site_id = int.Parse(row["site_id"].ToString());
            	}
            	if (null != row["name"])
            	{
            		model.name = row["name"].ToString();
            	}
            	if (null != row["title"])
            	{
            		model.title = row["title"].ToString();
            	}
            	if (null != row["is_albums"] && "" != row["is_albums"].ToString())
            	{
            		model.is_albums = int.Parse(row["is_albums"].ToString());
            	}
            	if (null != row["is_attach"] && "" != row["is_attach"].ToString())
            	{
            		model.is_attach = int.Parse(row["is_attach"].ToString());
            	}
            	if (null != row["is_spec"] && "" != row["is_spec"].ToString())
            	{
            		model.is_spec = int.Parse(row["is_spec"].ToString());
            	}
            	if (null != row["sort_id"] && "" != row["sort_id"].ToString())
            	{
            		model.sort_id = int.Parse(row["sort_id"].ToString());
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
            	if (null != row["is_type"] && "" != row["is_type"].ToString())
            	{
            		model.is_type = int.Parse(row["is_type"].ToString());
            	}
            	if (null != row["is_attribute"] && "" != row["is_attribute"].ToString())
            	{
            		model.is_attribute = int.Parse(row["is_attribute"].ToString());
            	}
            	if (null != row["is_comment"] && "" != row["is_comment"].ToString())
            	{
            		model.is_comment = int.Parse(row["is_comment"].ToString());
            	}
            	if (null != row["height"] && "" != row["height"].ToString())
            	{
            		model.height = int.Parse(row["height"].ToString());
            	}
            	if (null != row["width"] && "" != row["width"].ToString())
            	{
            		model.width = int.Parse(row["width"].ToString());
            	}
            	if (null != row["is_recycle"] && "" != row["is_recycle"].ToString())
            	{
            		model.is_recycle = int.Parse(row["is_recycle"].ToString());
            	}
            }
            return model;
        }
        #endregion
    }
}
