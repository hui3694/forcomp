using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;
using DTcms.Common;

namespace DTcms.DAL
{
    /// <summary>
    /// 数据访问类:Tag标签
    /// </summary>
    public partial class article_tags
    {
        private string column;
        private string databaseprefix; //数据库表名前缀
        public article_tags(string _databaseprefix)
        {
            databaseprefix = _databaseprefix;
            this.column = "id,title,is_red,sort_id,add_time,site_id,call_index,seo_title,seo_keywords,seo_description,click,content";
        }

        #region 基本方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            SqlParameter[] parameters = {
            	new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;
            return DbHelperSQL.Exists("select count(1) from [" + databaseprefix + "article_tags] where id=@id", parameters);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string call_index)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@call_index", SqlDbType.VarChar,100)};
            parameters[0].Value = call_index;
            return DbHelperSQL.Exists("select count(1) from [" + databaseprefix + "article_tags] where call_index=@call_index", parameters);
        }

        /// <summary>
        /// 获取阅读次数
        /// </summary>
        public int GetClick(int id)
        {
            SqlParameter[] parameters = {
            	new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;
            object obj = DbHelperSQL.GetSingle("select top 1 click from [" + databaseprefix + "article_tags] where id=@id", parameters);
            if (null != obj)
            {
                return Convert.ToInt32(obj);
            }
            return 0;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.article_tags model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [" + databaseprefix + "article_tags](");
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
            object obj = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (null != obj)
            {
                return Convert.ToInt32(obj);
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "article_tags set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.article_tags model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [" + databaseprefix + "article_tags] set ");
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

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            List<CommandInfo> sqllist = new List<CommandInfo>();
            //删除Tag标签关系表
            CommandInfo cmd = new CommandInfo("delete from [" + databaseprefix + "article_tags_relation] where tag_id=@id", parameters);
            sqllist.Add(cmd);
            //删除主表
            cmd = new CommandInfo("delete from [" + databaseprefix + "article_tags]  where id=@id", parameters);
            sqllist.Add(cmd);
            int rows = DbHelperSQL.ExecuteSqlTran(sqllist);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.article_tags GetModel(int id)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;
            DataSet ds = DbHelperSQL.Query("select top 1 " + this.column + " from [" + databaseprefix + "article_tags] where id=@id", parameters);
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
        /// 得到一个对象实体
        /// </summary>
        public Model.article_tags GetModel(string call_index)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@call_index", SqlDbType.NVarChar,100)
			};
            parameters[0].Value = call_index;
            DataSet ds = DbHelperSQL.Query("select top 1 " + this.column + " from [" + databaseprefix + "article_tags] where call_index=@call_index", parameters);
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
        /// 得到一个对象实体
        /// </summary>
        public Model.article_tags GetTitleModel(string title)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,100)
			};
            parameters[0].Value = title;
            DataSet ds = DbHelperSQL.Query("select top 1 " + this.column + " from [" + databaseprefix + "article_tags] where title=@title", parameters);
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
        /// 得到一个对象实体
        /// </summary>
        public Model.article_tags DataRowToModel(DataRow row)
        {
            Model.article_tags model = new Model.article_tags();
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

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select " + this.column + ",(select count(0) from " + databaseprefix + "article_tags_relation where tag_id=" + databaseprefix + "article_tags.id) as count");
            strSql.Append(" FROM " + databaseprefix + "article_tags");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.AppendFormat(" top {0} ", Top.ToString());
            }
            strSql.Append(this.column + ",(select count(0) from " + databaseprefix + "article_tags_relation where tag_id=" + databaseprefix + "article_tags.id) as count");
            strSql.Append(" FROM " + databaseprefix + "article_tags");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *,(select count(0) from " + databaseprefix + "article_tags_relation where tag_id=" + databaseprefix + "article_tags.id) as count from " + databaseprefix + "article_tags");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
        #endregion

        #region 扩展方法
        /// <summary>
        /// 检查更新Tags标签及关系，带事务
        /// </summary>
        public void Update(SqlConnection conn, SqlTransaction trans, string tags_title, int article_id, int site_id)
        {
            int tagsId = 0;
            //检查该Tags标签是否已存在
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 id from " + databaseprefix + "article_tags");
            strSql.Append(" where title=@title");
            SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,100)};
            parameters[0].Value = tags_title;
            object obj1 = DbHelperSQL.GetSingle(conn, trans, strSql.ToString(), parameters);
            if (obj1 != null)
            {
                //存在则将ID赋值
                tagsId = Convert.ToInt32(obj1);
            }
            //如果尚未创建该Tags标签则创建
            if (tagsId == 0)
            {
                StringBuilder strSql2 = new StringBuilder();
                strSql2.Append("insert into " + databaseprefix + "article_tags(");
                strSql2.Append("title,is_red,sort_id,add_time,site_id)");
                strSql2.Append(" values (");
                strSql2.Append("@title,@is_red,@sort_id,@add_time,@site_id)");
                strSql2.Append(";select @@IDENTITY");
                SqlParameter[] parameters2 = {
					    new SqlParameter("@title", SqlDbType.NVarChar,100),
					    new SqlParameter("@is_red", SqlDbType.TinyInt,1),
					    new SqlParameter("@sort_id", SqlDbType.Int,4),
					    new SqlParameter("@add_time", SqlDbType.DateTime),
                        new SqlParameter("@site_id", SqlDbType.Int,4)
                };
                parameters2[0].Value = tags_title;
                parameters2[1].Value = 0;
                parameters2[2].Value = 99;
                parameters2[3].Value = DateTime.Now;
                parameters2[4].Value = site_id;
                object obj2 = DbHelperSQL.GetSingle(conn, trans, strSql2.ToString(), parameters2);
                if (obj2 != null)
                {
                    //插入成功后返回ID
                    tagsId = Convert.ToInt32(obj2);
                }
            }
            //匹配Tags标签与文章之间的关系
            if (tagsId > 0)
            {
                StringBuilder strSql3 = new StringBuilder();
                strSql3.Append("insert into " + databaseprefix + "article_tags_relation(");
                strSql3.Append("article_id,tag_id)");
                strSql3.Append(" values (");
                strSql3.Append("@article_id,@tag_id)");
                SqlParameter[] parameters3 = {
					    new SqlParameter("@article_id", SqlDbType.Int,4),
					    new SqlParameter("@tag_id", SqlDbType.Int,4)};
                parameters3[0].Value = article_id;
                parameters3[1].Value = tagsId;
                DbHelperSQL.GetSingle(conn, trans, strSql3.ToString(), parameters3);
            }
        }

        /// <summary>
        /// 删除文章对应的Tags标签关系
        /// </summary>
        public bool Delete(SqlConnection conn, SqlTransaction trans, int article_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "article_tags_relation");
            strSql.Append(" where article_id=@article_id");
            SqlParameter[] parameters = {
					new SqlParameter("@article_id", SqlDbType.Int,4)};
            parameters[0].Value = article_id;
            int rows = DbHelperSQL.ExecuteSql(conn, trans, strSql.ToString(), parameters);
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
    }
}