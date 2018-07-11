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
    public partial class dt_plugin_images
    {
        private string column;
        private string databaseprefix; 
        public dt_plugin_images(string _databaseprefix)
        {
            this.databaseprefix = _databaseprefix;
            this.column = "id,class_id,title,target,img_url,link_url,content,sort_id,back_color,is_lock,add_time,is_type";
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
            return DbHelperSQL.Exists("select count(1) from [" + databaseprefix + "dt_plugin_images] where id=@id", parameters);
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
            return DbHelperSQL.Exists("select count(1) from [" + databaseprefix + "dt_plugin_images] where title=@title", parameters);
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
            object obj = DbHelperSQL.GetSingle("select title from [" + databaseprefix + "dt_plugin_images] where id=@id", parameters);
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
            strSql.Append("select count(*) as H from [" + databaseprefix + "dt_plugin_images]");
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
        /// <param name="model">Model.dt_plugin_images</param>
        /// <returns>ID</returns>
        public int Add(Model.dt_plugin_images model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [" + databaseprefix + "dt_plugin_images](");
            strSql.Append("class_id,title,target,img_url,link_url,content,sort_id,back_color,is_lock,add_time,is_type");
            strSql.Append(") values(");
            strSql.Append("@class_id,@title,@target,@img_url,@link_url,@content,@sort_id,@back_color,@is_lock,@add_time,@is_type)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                new SqlParameter("@class_id", SqlDbType.Int,4),
                new SqlParameter("@title", SqlDbType.NVarChar,255),
                new SqlParameter("@target", SqlDbType.NVarChar,20),
                new SqlParameter("@img_url", SqlDbType.NVarChar,255),
                new SqlParameter("@link_url", SqlDbType.NVarChar,255),
                new SqlParameter("@content", SqlDbType.NText),
                new SqlParameter("@sort_id", SqlDbType.Int,4),
                new SqlParameter("@back_color", SqlDbType.NVarChar,20),
                new SqlParameter("@is_lock", SqlDbType.TinyInt,1),
                new SqlParameter("@add_time", SqlDbType.DateTime),
				new SqlParameter("@is_type", SqlDbType.TinyInt,1)
            };
            parameters[0].Value = model.class_id;
            parameters[1].Value = model.title;
            parameters[2].Value = model.target;
            parameters[3].Value = model.img_url;
            parameters[4].Value = model.link_url;
            parameters[5].Value = model.content;
            parameters[6].Value = model.sort_id;
            parameters[7].Value = model.back_color;
            parameters[8].Value = model.is_lock;
            parameters[9].Value = model.add_time;
            parameters[10].Value = model.is_type;
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
            DbHelperSQL.ExecuteSql("update [" + databaseprefix + "dt_plugin_images] set " + strValue + " where id=" + id);
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">Model.dt_plugin_images</param>
        /// <returns>True or False</returns>
        public bool Update(Model.dt_plugin_images model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [" + databaseprefix + "dt_plugin_images] set ");
            strSql.Append("class_id=@class_id,");
            strSql.Append("title=@title,");
            strSql.Append("target=@target,");
            strSql.Append("img_url=@img_url,");
            strSql.Append("link_url=@link_url,");
            strSql.Append("content=@content,");
            strSql.Append("sort_id=@sort_id,");
            strSql.Append("back_color=@back_color,");
            strSql.Append("is_lock=@is_lock,");
            strSql.Append("add_time=@add_time,");
            strSql.Append("is_type=@is_type");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                new SqlParameter("@class_id", SqlDbType.Int,4),
                new SqlParameter("@title", SqlDbType.NVarChar,255),
                new SqlParameter("@target", SqlDbType.NVarChar,20),
                new SqlParameter("@img_url", SqlDbType.NVarChar,255),
                new SqlParameter("@link_url", SqlDbType.NVarChar,255),
                new SqlParameter("@content", SqlDbType.NText),
                new SqlParameter("@sort_id", SqlDbType.Int,4),
                new SqlParameter("@back_color", SqlDbType.NVarChar,20),
                new SqlParameter("@is_lock", SqlDbType.TinyInt,1),
                new SqlParameter("@add_time", SqlDbType.DateTime),
				new SqlParameter("@is_type", SqlDbType.TinyInt,1),
                new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = model.class_id;
            parameters[1].Value = model.title;
            parameters[2].Value = model.target;
            parameters[3].Value = model.img_url;
            parameters[4].Value = model.link_url;
            parameters[5].Value = model.content;
            parameters[6].Value = model.sort_id;
            parameters[7].Value = model.back_color;
            parameters[8].Value = model.is_lock;
            parameters[9].Value = model.add_time;
            parameters[10].Value = model.is_type;
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
            int rows = DbHelperSQL.ExecuteSql("delete from [" + databaseprefix + "dt_plugin_images] where id=@id", parameters);
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
        /// <returns>Model.dt_plugin_images</returns>
        public Model.dt_plugin_images GetModel(int id)
        {
            SqlParameter[] parameters = {
            		new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;
            DataSet ds = DbHelperSQL.Query("select " + this.column + " from [" + databaseprefix + "dt_plugin_images] where id=@id", parameters);
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
            strSql.Append(this.column + " from [" + databaseprefix + "dt_plugin_images]");
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
            strSql.Append("select * from [" + databaseprefix + "dt_plugin_images]");
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
        /// <returns>Model.dt_plugin_images</returns>
        private Model.dt_plugin_images DataRowToModel(DataRow row)
        {
            Model.dt_plugin_images model = new Model.dt_plugin_images();
            if (row != null)
            {
            	if (null != row["id"] && "" != row["id"].ToString())
            	{
            		model.id = int.Parse(row["id"].ToString());
            	}
            	if (null != row["class_id"] && "" != row["class_id"].ToString())
            	{
            		model.class_id = int.Parse(row["class_id"].ToString());
            	}
            	if (null != row["title"])
            	{
            		model.title = row["title"].ToString();
            	}
            	if (null != row["target"])
            	{
            		model.target = row["target"].ToString();
            	}
            	if (null != row["img_url"])
            	{
            		model.img_url = row["img_url"].ToString();
            	}
            	if (null != row["link_url"])
            	{
            		model.link_url = row["link_url"].ToString();
            	}
            	if (null != row["content"])
            	{
            		model.content = row["content"].ToString();
            	}
            	if (null != row["sort_id"] && "" != row["sort_id"].ToString())
            	{
            		model.sort_id = int.Parse(row["sort_id"].ToString());
            	}
            	if (null != row["back_color"])
            	{
            		model.back_color = row["back_color"].ToString();
            	}
            	if (null != row["is_lock"] && "" != row["is_lock"].ToString())
            	{
            		model.is_lock = int.Parse(row["is_lock"].ToString());
            	}
            	if (null != row["add_time"] && "" != row["add_time"].ToString())
            	{
            		model.add_time = DateTime.Parse(row["add_time"].ToString());
            	}
            	if (null != row["is_type"] && "" != row["is_type"].ToString())
            	{
            		model.is_type = int.Parse(row["is_type"].ToString());
            	}
            }
            return model;
        }
        #endregion
    }
}
