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
    public partial class dt_article
    {
        private string column;
        private string databaseprefix; 
        public dt_article(string _databaseprefix)
        {
            this.databaseprefix = _databaseprefix;
            this.column = "id,channel_id,category_id,call_index,title,link_url,img_url,seo_title,seo_keywords,seo_description,tags,zhaiyao,content,sort_id,click,status,is_msg,is_top,is_red,is_hot,is_slide,is_sys,user_name,add_time,update_time,site_id";
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
            return DbHelperSQL.Exists("select count(1) from [" + databaseprefix + "dt_article] where id=@id", parameters);
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
            return DbHelperSQL.Exists("select count(1) from [" + databaseprefix + "dt_article] where title=@title", parameters);
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
            object obj = DbHelperSQL.GetSingle("select title from [" + databaseprefix + "dt_article] where id=@id", parameters);
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
            strSql.Append("select count(*) as H from [" + databaseprefix + "dt_article]");
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
        /// <param name="model">Model.dt_article</param>
        /// <returns>ID</returns>
        public int Add(Model.dt_article model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [" + databaseprefix + "dt_article](");
            strSql.Append("channel_id,category_id,call_index,title,link_url,img_url,seo_title,seo_keywords,seo_description,tags,zhaiyao,content,sort_id,click,status,is_msg,is_top,is_red,is_hot,is_slide,is_sys,user_name,add_time,update_time,site_id");
            strSql.Append(") values(");
            strSql.Append("@channel_id,@category_id,@call_index,@title,@link_url,@img_url,@seo_title,@seo_keywords,@seo_description,@tags,@zhaiyao,@content,@sort_id,@click,@status,@is_msg,@is_top,@is_red,@is_hot,@is_slide,@is_sys,@user_name,@add_time,@update_time,@site_id)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                new SqlParameter("@channel_id", SqlDbType.Int,4),
                new SqlParameter("@category_id", SqlDbType.Int,4),
                new SqlParameter("@call_index", SqlDbType.NVarChar,50),
                new SqlParameter("@title", SqlDbType.NVarChar,100),
                new SqlParameter("@link_url", SqlDbType.NVarChar,255),
                new SqlParameter("@img_url", SqlDbType.NVarChar,255),
                new SqlParameter("@seo_title", SqlDbType.NVarChar,255),
                new SqlParameter("@seo_keywords", SqlDbType.NVarChar,255),
                new SqlParameter("@seo_description", SqlDbType.NVarChar,255),
                new SqlParameter("@tags", SqlDbType.NVarChar,500),
                new SqlParameter("@zhaiyao", SqlDbType.NVarChar,255),
                new SqlParameter("@content", SqlDbType.NText),
                new SqlParameter("@sort_id", SqlDbType.Int,4),
                new SqlParameter("@click", SqlDbType.Int,4),
                new SqlParameter("@status", SqlDbType.TinyInt,1),
                new SqlParameter("@is_msg", SqlDbType.TinyInt,1),
                new SqlParameter("@is_top", SqlDbType.TinyInt,1),
                new SqlParameter("@is_red", SqlDbType.TinyInt,1),
                new SqlParameter("@is_hot", SqlDbType.TinyInt,1),
                new SqlParameter("@is_slide", SqlDbType.TinyInt,1),
                new SqlParameter("@is_sys", SqlDbType.TinyInt,1),
                new SqlParameter("@user_name", SqlDbType.NVarChar,100),
                new SqlParameter("@add_time", SqlDbType.DateTime),
                new SqlParameter("@update_time", SqlDbType.DateTime),
				new SqlParameter("@site_id", SqlDbType.Int,4)
            };
            parameters[0].Value = model.channel_id;
            parameters[1].Value = model.category_id;
            parameters[2].Value = model.call_index;
            parameters[3].Value = model.title;
            parameters[4].Value = model.link_url;
            parameters[5].Value = model.img_url;
            parameters[6].Value = model.seo_title;
            parameters[7].Value = model.seo_keywords;
            parameters[8].Value = model.seo_description;
            parameters[9].Value = model.tags;
            parameters[10].Value = model.zhaiyao;
            parameters[11].Value = model.content;
            parameters[12].Value = model.sort_id;
            parameters[13].Value = model.click;
            parameters[14].Value = model.status;
            parameters[15].Value = model.is_msg;
            parameters[16].Value = model.is_top;
            parameters[17].Value = model.is_red;
            parameters[18].Value = model.is_hot;
            parameters[19].Value = model.is_slide;
            parameters[20].Value = model.is_sys;
            parameters[21].Value = model.user_name;
            parameters[22].Value = model.add_time;
            parameters[23].Value = model.update_time;
            parameters[24].Value = model.site_id;
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
            DbHelperSQL.ExecuteSql("update [" + databaseprefix + "dt_article] set " + strValue + " where id=" + id);
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">Model.dt_article</param>
        /// <returns>True or False</returns>
        public bool Update(Model.dt_article model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [" + databaseprefix + "dt_article] set ");
            strSql.Append("channel_id=@channel_id,");
            strSql.Append("category_id=@category_id,");
            strSql.Append("call_index=@call_index,");
            strSql.Append("title=@title,");
            strSql.Append("link_url=@link_url,");
            strSql.Append("img_url=@img_url,");
            strSql.Append("seo_title=@seo_title,");
            strSql.Append("seo_keywords=@seo_keywords,");
            strSql.Append("seo_description=@seo_description,");
            strSql.Append("tags=@tags,");
            strSql.Append("zhaiyao=@zhaiyao,");
            strSql.Append("content=@content,");
            strSql.Append("sort_id=@sort_id,");
            strSql.Append("click=@click,");
            strSql.Append("status=@status,");
            strSql.Append("is_msg=@is_msg,");
            strSql.Append("is_top=@is_top,");
            strSql.Append("is_red=@is_red,");
            strSql.Append("is_hot=@is_hot,");
            strSql.Append("is_slide=@is_slide,");
            strSql.Append("is_sys=@is_sys,");
            strSql.Append("user_name=@user_name,");
            strSql.Append("add_time=@add_time,");
            strSql.Append("update_time=@update_time,");
            strSql.Append("site_id=@site_id");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                new SqlParameter("@channel_id", SqlDbType.Int,4),
                new SqlParameter("@category_id", SqlDbType.Int,4),
                new SqlParameter("@call_index", SqlDbType.NVarChar,50),
                new SqlParameter("@title", SqlDbType.NVarChar,100),
                new SqlParameter("@link_url", SqlDbType.NVarChar,255),
                new SqlParameter("@img_url", SqlDbType.NVarChar,255),
                new SqlParameter("@seo_title", SqlDbType.NVarChar,255),
                new SqlParameter("@seo_keywords", SqlDbType.NVarChar,255),
                new SqlParameter("@seo_description", SqlDbType.NVarChar,255),
                new SqlParameter("@tags", SqlDbType.NVarChar,500),
                new SqlParameter("@zhaiyao", SqlDbType.NVarChar,255),
                new SqlParameter("@content", SqlDbType.NText),
                new SqlParameter("@sort_id", SqlDbType.Int,4),
                new SqlParameter("@click", SqlDbType.Int,4),
                new SqlParameter("@status", SqlDbType.TinyInt,1),
                new SqlParameter("@is_msg", SqlDbType.TinyInt,1),
                new SqlParameter("@is_top", SqlDbType.TinyInt,1),
                new SqlParameter("@is_red", SqlDbType.TinyInt,1),
                new SqlParameter("@is_hot", SqlDbType.TinyInt,1),
                new SqlParameter("@is_slide", SqlDbType.TinyInt,1),
                new SqlParameter("@is_sys", SqlDbType.TinyInt,1),
                new SqlParameter("@user_name", SqlDbType.NVarChar,100),
                new SqlParameter("@add_time", SqlDbType.DateTime),
                new SqlParameter("@update_time", SqlDbType.DateTime),
				new SqlParameter("@site_id", SqlDbType.Int,4),
                new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = model.channel_id;
            parameters[1].Value = model.category_id;
            parameters[2].Value = model.call_index;
            parameters[3].Value = model.title;
            parameters[4].Value = model.link_url;
            parameters[5].Value = model.img_url;
            parameters[6].Value = model.seo_title;
            parameters[7].Value = model.seo_keywords;
            parameters[8].Value = model.seo_description;
            parameters[9].Value = model.tags;
            parameters[10].Value = model.zhaiyao;
            parameters[11].Value = model.content;
            parameters[12].Value = model.sort_id;
            parameters[13].Value = model.click;
            parameters[14].Value = model.status;
            parameters[15].Value = model.is_msg;
            parameters[16].Value = model.is_top;
            parameters[17].Value = model.is_red;
            parameters[18].Value = model.is_hot;
            parameters[19].Value = model.is_slide;
            parameters[20].Value = model.is_sys;
            parameters[21].Value = model.user_name;
            parameters[22].Value = model.add_time;
            parameters[23].Value = model.update_time;
            parameters[24].Value = model.site_id;
            parameters[25].Value = model.id;
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
            int rows = DbHelperSQL.ExecuteSql("delete from [" + databaseprefix + "dt_article] where id=@id", parameters);
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
        /// <returns>Model.dt_article</returns>
        public Model.dt_article GetModel(int id)
        {
            SqlParameter[] parameters = {
            		new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;
            DataSet ds = DbHelperSQL.Query("select " + this.column + " from [" + databaseprefix + "dt_article] where id=@id", parameters);
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
            strSql.Append(this.column + " from [" + databaseprefix + "dt_article]");
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
            strSql.Append("select * from [" + databaseprefix + "dt_article]");
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
        /// <returns>Model.dt_article</returns>
        private Model.dt_article DataRowToModel(DataRow row)
        {
            Model.dt_article model = new Model.dt_article();
            if (row != null)
            {
            	if (null != row["id"] && "" != row["id"].ToString())
            	{
            		model.id = int.Parse(row["id"].ToString());
            	}
            	if (null != row["channel_id"] && "" != row["channel_id"].ToString())
            	{
            		model.channel_id = int.Parse(row["channel_id"].ToString());
            	}
            	if (null != row["category_id"] && "" != row["category_id"].ToString())
            	{
            		model.category_id = int.Parse(row["category_id"].ToString());
            	}
            	if (null != row["call_index"])
            	{
            		model.call_index = row["call_index"].ToString();
            	}
            	if (null != row["title"])
            	{
            		model.title = row["title"].ToString();
            	}
            	if (null != row["link_url"])
            	{
            		model.link_url = row["link_url"].ToString();
            	}
            	if (null != row["img_url"])
            	{
            		model.img_url = row["img_url"].ToString();
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
            	if (null != row["tags"])
            	{
            		model.tags = row["tags"].ToString();
            	}
            	if (null != row["zhaiyao"])
            	{
            		model.zhaiyao = row["zhaiyao"].ToString();
            	}
            	if (null != row["content"])
            	{
            		model.content = row["content"].ToString();
            	}
            	if (null != row["sort_id"] && "" != row["sort_id"].ToString())
            	{
            		model.sort_id = int.Parse(row["sort_id"].ToString());
            	}
            	if (null != row["click"] && "" != row["click"].ToString())
            	{
            		model.click = int.Parse(row["click"].ToString());
            	}
            	if (null != row["status"] && "" != row["status"].ToString())
            	{
            		model.status = int.Parse(row["status"].ToString());
            	}
            	if (null != row["is_msg"] && "" != row["is_msg"].ToString())
            	{
            		model.is_msg = int.Parse(row["is_msg"].ToString());
            	}
            	if (null != row["is_top"] && "" != row["is_top"].ToString())
            	{
            		model.is_top = int.Parse(row["is_top"].ToString());
            	}
            	if (null != row["is_red"] && "" != row["is_red"].ToString())
            	{
            		model.is_red = int.Parse(row["is_red"].ToString());
            	}
            	if (null != row["is_hot"] && "" != row["is_hot"].ToString())
            	{
            		model.is_hot = int.Parse(row["is_hot"].ToString());
            	}
            	if (null != row["is_slide"] && "" != row["is_slide"].ToString())
            	{
            		model.is_slide = int.Parse(row["is_slide"].ToString());
            	}
            	if (null != row["is_sys"] && "" != row["is_sys"].ToString())
            	{
            		model.is_sys = int.Parse(row["is_sys"].ToString());
            	}
            	if (null != row["user_name"])
            	{
            		model.user_name = row["user_name"].ToString();
            	}
            	if (null != row["add_time"] && "" != row["add_time"].ToString())
            	{
            		model.add_time = DateTime.Parse(row["add_time"].ToString());
            	}
            	if (null != row["update_time"] && "" != row["update_time"].ToString())
            	{
            		model.update_time = DateTime.Parse(row["update_time"].ToString());
            	}
            	if (null != row["site_id"] && "" != row["site_id"].ToString())
            	{
            		model.site_id = int.Parse(row["site_id"].ToString());
            	}
            }
            return model;
        }
        #endregion
    }
}
