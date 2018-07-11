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
    public partial class dt_channel_site
    {
        private string column;
        private string databaseprefix; 
        public dt_channel_site(string _databaseprefix)
        {
            this.databaseprefix = _databaseprefix;
            this.column = "id,title,build_path,templet_path,domain,name,logo,company,address,tel,fax,email,crod,copyright,seo_title,seo_keyword,seo_description,is_mobile,is_default,sort_id,inherit_id,bdsend,bdtoken";
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
            return DbHelperSQL.Exists("select count(1) from [" + databaseprefix + "dt_channel_site] where id=@id", parameters);
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
            return DbHelperSQL.Exists("select count(1) from [" + databaseprefix + "dt_channel_site] where title=@title", parameters);
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
            object obj = DbHelperSQL.GetSingle("select title from [" + databaseprefix + "dt_channel_site] where id=@id", parameters);
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
            object obj = DbHelperSQL.GetSingle("select name from [" + databaseprefix + "dt_channel_site] where id=@id", parameters);
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
            object obj = DbHelperSQL.GetSingle("select id from [" + databaseprefix + "dt_channel_site] where name=@name ", parameters);
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
            strSql.Append("select count(*) as H from [" + databaseprefix + "dt_channel_site]");
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
        /// <param name="model">Model.dt_channel_site</param>
        /// <returns>ID</returns>
        public int Add(Model.dt_channel_site model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [" + databaseprefix + "dt_channel_site](");
            strSql.Append("title,build_path,templet_path,domain,name,logo,company,address,tel,fax,email,crod,copyright,seo_title,seo_keyword,seo_description,is_mobile,is_default,sort_id,inherit_id,bdsend,bdtoken");
            strSql.Append(") values(");
            strSql.Append("@title,@build_path,@templet_path,@domain,@name,@logo,@company,@address,@tel,@fax,@email,@crod,@copyright,@seo_title,@seo_keyword,@seo_description,@is_mobile,@is_default,@sort_id,@inherit_id,@bdsend,@bdtoken)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                new SqlParameter("@title", SqlDbType.NVarChar,100),
                new SqlParameter("@build_path", SqlDbType.NVarChar,100),
                new SqlParameter("@templet_path", SqlDbType.NVarChar,100),
                new SqlParameter("@domain", SqlDbType.NVarChar,255),
                new SqlParameter("@name", SqlDbType.NVarChar,255),
                new SqlParameter("@logo", SqlDbType.NVarChar,255),
                new SqlParameter("@company", SqlDbType.NVarChar,255),
                new SqlParameter("@address", SqlDbType.NVarChar,255),
                new SqlParameter("@tel", SqlDbType.NVarChar,30),
                new SqlParameter("@fax", SqlDbType.NVarChar,30),
                new SqlParameter("@email", SqlDbType.NVarChar,50),
                new SqlParameter("@crod", SqlDbType.NVarChar,100),
                new SqlParameter("@copyright", SqlDbType.Text),
                new SqlParameter("@seo_title", SqlDbType.NVarChar,255),
                new SqlParameter("@seo_keyword", SqlDbType.NVarChar,255),
                new SqlParameter("@seo_description", SqlDbType.NVarChar,500),
                new SqlParameter("@is_mobile", SqlDbType.TinyInt,1),
                new SqlParameter("@is_default", SqlDbType.TinyInt,1),
                new SqlParameter("@sort_id", SqlDbType.Int,4),
                new SqlParameter("@inherit_id", SqlDbType.Int,4),
                new SqlParameter("@bdsend", SqlDbType.TinyInt,1),
				new SqlParameter("@bdtoken", SqlDbType.VarChar,100)
            };
            parameters[0].Value = model.title;
            parameters[1].Value = model.build_path;
            parameters[2].Value = model.templet_path;
            parameters[3].Value = model.domain;
            parameters[4].Value = model.name;
            parameters[5].Value = model.logo;
            parameters[6].Value = model.company;
            parameters[7].Value = model.address;
            parameters[8].Value = model.tel;
            parameters[9].Value = model.fax;
            parameters[10].Value = model.email;
            parameters[11].Value = model.crod;
            parameters[12].Value = model.copyright;
            parameters[13].Value = model.seo_title;
            parameters[14].Value = model.seo_keyword;
            parameters[15].Value = model.seo_description;
            parameters[16].Value = model.is_mobile;
            parameters[17].Value = model.is_default;
            parameters[18].Value = model.sort_id;
            parameters[19].Value = model.inherit_id;
            parameters[20].Value = model.bdsend;
            parameters[21].Value = model.bdtoken;
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
            DbHelperSQL.ExecuteSql("update [" + databaseprefix + "dt_channel_site] set " + strValue + " where id=" + id);
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">Model.dt_channel_site</param>
        /// <returns>True or False</returns>
        public bool Update(Model.dt_channel_site model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [" + databaseprefix + "dt_channel_site] set ");
            strSql.Append("title=@title,");
            strSql.Append("build_path=@build_path,");
            strSql.Append("templet_path=@templet_path,");
            strSql.Append("domain=@domain,");
            strSql.Append("name=@name,");
            strSql.Append("logo=@logo,");
            strSql.Append("company=@company,");
            strSql.Append("address=@address,");
            strSql.Append("tel=@tel,");
            strSql.Append("fax=@fax,");
            strSql.Append("email=@email,");
            strSql.Append("crod=@crod,");
            strSql.Append("copyright=@copyright,");
            strSql.Append("seo_title=@seo_title,");
            strSql.Append("seo_keyword=@seo_keyword,");
            strSql.Append("seo_description=@seo_description,");
            strSql.Append("is_mobile=@is_mobile,");
            strSql.Append("is_default=@is_default,");
            strSql.Append("sort_id=@sort_id,");
            strSql.Append("inherit_id=@inherit_id,");
            strSql.Append("bdsend=@bdsend,");
            strSql.Append("bdtoken=@bdtoken");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                new SqlParameter("@title", SqlDbType.NVarChar,100),
                new SqlParameter("@build_path", SqlDbType.NVarChar,100),
                new SqlParameter("@templet_path", SqlDbType.NVarChar,100),
                new SqlParameter("@domain", SqlDbType.NVarChar,255),
                new SqlParameter("@name", SqlDbType.NVarChar,255),
                new SqlParameter("@logo", SqlDbType.NVarChar,255),
                new SqlParameter("@company", SqlDbType.NVarChar,255),
                new SqlParameter("@address", SqlDbType.NVarChar,255),
                new SqlParameter("@tel", SqlDbType.NVarChar,30),
                new SqlParameter("@fax", SqlDbType.NVarChar,30),
                new SqlParameter("@email", SqlDbType.NVarChar,50),
                new SqlParameter("@crod", SqlDbType.NVarChar,100),
                new SqlParameter("@copyright", SqlDbType.Text),
                new SqlParameter("@seo_title", SqlDbType.NVarChar,255),
                new SqlParameter("@seo_keyword", SqlDbType.NVarChar,255),
                new SqlParameter("@seo_description", SqlDbType.NVarChar,500),
                new SqlParameter("@is_mobile", SqlDbType.TinyInt,1),
                new SqlParameter("@is_default", SqlDbType.TinyInt,1),
                new SqlParameter("@sort_id", SqlDbType.Int,4),
                new SqlParameter("@inherit_id", SqlDbType.Int,4),
                new SqlParameter("@bdsend", SqlDbType.TinyInt,1),
				new SqlParameter("@bdtoken", SqlDbType.VarChar,100),
                new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = model.title;
            parameters[1].Value = model.build_path;
            parameters[2].Value = model.templet_path;
            parameters[3].Value = model.domain;
            parameters[4].Value = model.name;
            parameters[5].Value = model.logo;
            parameters[6].Value = model.company;
            parameters[7].Value = model.address;
            parameters[8].Value = model.tel;
            parameters[9].Value = model.fax;
            parameters[10].Value = model.email;
            parameters[11].Value = model.crod;
            parameters[12].Value = model.copyright;
            parameters[13].Value = model.seo_title;
            parameters[14].Value = model.seo_keyword;
            parameters[15].Value = model.seo_description;
            parameters[16].Value = model.is_mobile;
            parameters[17].Value = model.is_default;
            parameters[18].Value = model.sort_id;
            parameters[19].Value = model.inherit_id;
            parameters[20].Value = model.bdsend;
            parameters[21].Value = model.bdtoken;
            parameters[22].Value = model.id;
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
            int rows = DbHelperSQL.ExecuteSql("delete from [" + databaseprefix + "dt_channel_site] where id=@id", parameters);
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
        /// <returns>Model.dt_channel_site</returns>
        public Model.dt_channel_site GetModel(int id)
        {
            SqlParameter[] parameters = {
            		new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;
            DataSet ds = DbHelperSQL.Query("select " + this.column + " from [" + databaseprefix + "dt_channel_site] where id=@id", parameters);
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
        /// <returns>Model.dt_channel_site</returns>
        public Model.dt_channel_site GetModel(string name)
        {
            SqlParameter[] parameters = {
        					new SqlParameter("@name", SqlDbType.NVarChar,50)};
            parameters[0].Value = nav_name;
            object obj = DbHelperSQL.GetSingle("select id from [" + databaseprefix + "dt_channel_site] where name=@name", parameters);
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
            strSql.Append(this.column + " from [" + databaseprefix + "dt_channel_site]");
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
            strSql.Append("select * from [" + databaseprefix + "dt_channel_site]");
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
        /// <returns>Model.dt_channel_site</returns>
        private Model.dt_channel_site DataRowToModel(DataRow row)
        {
            Model.dt_channel_site model = new Model.dt_channel_site();
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
            	if (null != row["build_path"])
            	{
            		model.build_path = row["build_path"].ToString();
            	}
            	if (null != row["templet_path"])
            	{
            		model.templet_path = row["templet_path"].ToString();
            	}
            	if (null != row["domain"])
            	{
            		model.domain = row["domain"].ToString();
            	}
            	if (null != row["name"])
            	{
            		model.name = row["name"].ToString();
            	}
            	if (null != row["logo"])
            	{
            		model.logo = row["logo"].ToString();
            	}
            	if (null != row["company"])
            	{
            		model.company = row["company"].ToString();
            	}
            	if (null != row["address"])
            	{
            		model.address = row["address"].ToString();
            	}
            	if (null != row["tel"])
            	{
            		model.tel = row["tel"].ToString();
            	}
            	if (null != row["fax"])
            	{
            		model.fax = row["fax"].ToString();
            	}
            	if (null != row["email"])
            	{
            		model.email = row["email"].ToString();
            	}
            	if (null != row["crod"])
            	{
            		model.crod = row["crod"].ToString();
            	}
            	if (null != row["copyright"])
            	{
            		model.copyright = row["copyright"].ToString();
            	}
            	if (null != row["seo_title"])
            	{
            		model.seo_title = row["seo_title"].ToString();
            	}
            	if (null != row["seo_keyword"])
            	{
            		model.seo_keyword = row["seo_keyword"].ToString();
            	}
            	if (null != row["seo_description"])
            	{
            		model.seo_description = row["seo_description"].ToString();
            	}
            	if (null != row["is_mobile"] && "" != row["is_mobile"].ToString())
            	{
            		model.is_mobile = int.Parse(row["is_mobile"].ToString());
            	}
            	if (null != row["is_default"] && "" != row["is_default"].ToString())
            	{
            		model.is_default = int.Parse(row["is_default"].ToString());
            	}
            	if (null != row["sort_id"] && "" != row["sort_id"].ToString())
            	{
            		model.sort_id = int.Parse(row["sort_id"].ToString());
            	}
            	if (null != row["inherit_id"] && "" != row["inherit_id"].ToString())
            	{
            		model.inherit_id = int.Parse(row["inherit_id"].ToString());
            	}
            	if (null != row["bdsend"] && "" != row["bdsend"].ToString())
            	{
            		model.bdsend = int.Parse(row["bdsend"].ToString());
            	}
            	if (null != row["bdtoken"])
            	{
            		model.bdtoken = row["bdtoken"].ToString();
            	}
            }
            return model;
        }
        #endregion
    }
}
