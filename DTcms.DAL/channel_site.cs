﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;
using DTcms.Common;

namespace DTcms.DAL
{
	/// <summary>
	/// 数据访问类:频道站点
	/// </summary>
	public partial class channel_site
	{
        private string column;
        private string databaseprefix;
        public channel_site(string _databaseprefix)
        {
            databaseprefix = _databaseprefix;
            this.column = "id,title,build_path,templet_path,domain,name,logo,company,address,tel,fax,email,crod,copyright,seo_title,seo_keyword,seo_description,is_mobile,is_default,sort_id,inherit_id,bdsend,bdtoken";
        }

        #region 基本方法================================
        /// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "channel_site");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

        /// <summary>
        /// 查询生成目录名是否存在
        /// </summary>
        public bool Exists(string build_path)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "channel_site");
            strSql.Append(" where build_path=@build_path ");
            SqlParameter[] parameters = {
					new SqlParameter("@build_path", SqlDbType.NVarChar,100)};
            parameters[0].Value = build_path;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Model.channel_site model)
		{
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        //判断当前是否为默认，如果是，取消其它默认数据
                        if (model.is_default > 0)
                        {
                            UpDefault(conn, trans);
                        }
                        //添加主表信息
			            StringBuilder strSql=new StringBuilder();
                        strSql.Append("insert into [" + databaseprefix + "channel_site](");
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

                        object obj = DbHelperSQL.GetSingle(conn, trans, strSql.ToString(), parameters); //带事务
                        model.id = Convert.ToInt32(obj);

                        //如果非移动站点则添加导航菜单
                        if (model.is_mobile == 0)
                        {
                            new DAL.navigation(databaseprefix).Add(conn, trans, "sys_contents", "channel_" + model.build_path, model.title, "", model.sort_id, 0, "Show");
                        }
                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        return 0;
                    }
                }
            }
            return model.id;
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(Model.channel_site model, string old_build_path)
		{
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        //判断当前是否为默认，如果是，取消其它默认数据
                        if (model.is_default > 0)
                        {
                            UpDefault(conn, trans);
                        }
                        //修改主表信息
			            StringBuilder strSql=new StringBuilder();
                        strSql.Append("update " + databaseprefix + "channel_site set ");
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
			            DbHelperSQL.ExecuteSql(conn, trans, strSql.ToString(),parameters);

                        //检查旧导航是否存在
                        if (new DAL.navigation(databaseprefix).GetModel(conn, trans, "channel_" + old_build_path) != null)
                        {
                            //如果非移动站点则修改导航菜单，是移动站点则删除旧导航
                            if (model.is_mobile == 0)
                            {
                                new DAL.navigation(databaseprefix).Update(conn, trans, "channel_" + old_build_path, "channel_" + model.build_path, model.title, model.sort_id);
                            }
                            else
                            {
                                new DAL.navigation(databaseprefix).Delete(conn, trans, "channel_" + old_build_path);
                            }
                        }
                        else if (model.is_mobile == 0) //没有旧菜单而非移动站需要添加新导航菜单
                        {
                            new DAL.navigation(databaseprefix).Add(conn, trans, "sys_contents", "channel_" + model.build_path, model.title, "", model.sort_id, 0, "Show");
                        }

                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        return false;
                    }
                }
            }
            return true;
		}

        /// <summary>
        /// 更新数据不为默认
        /// </summary>
        public void UpDefault(SqlConnection conn, SqlTransaction trans)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [" + databaseprefix + "channel_site] set is_default=0 where is_default=1");
            DbHelperSQL.ExecuteSql(conn, trans, strSql.ToString());
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
            string build_path = GetBuildPath(id);
            if (string.IsNullOrEmpty(build_path))
            {
                return false;
            }
            //取得要删除的所有导航ID
            string navIds = new navigation(databaseprefix).GetIds("channel_" + build_path);

            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        //删除导航
                        if (!string.IsNullOrEmpty(navIds))
                        {
                            DbHelperSQL.ExecuteSql(conn, trans, "delete from [" + databaseprefix + "navigation] where id in(" + navIds + ")");
                        }
                        //删除站点
			            StringBuilder strSql=new StringBuilder();
                        strSql.Append("delete from " + databaseprefix + "channel_site ");
			            strSql.Append(" where id=@id");
			            SqlParameter[] parameters = {
					            new SqlParameter("@id", SqlDbType.Int,4)};
			            parameters[0].Value = id;
                        DbHelperSQL.ExecuteSql(conn, trans, strSql.ToString(), parameters);

                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        return false;
                    }
                }
            }
            return true;
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public Model.channel_site GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select " + this.column + " from [" + databaseprefix + "channel_site] where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            Model.channel_site model = new Model.channel_site();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
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
        public Model.channel_site GetModel(string build_path)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select " + this.column + " from [" + databaseprefix + "channel_site] where build_path=@build_path");
            SqlParameter[] parameters = {
					new SqlParameter("@build_path", SqlDbType.NVarChar,50)};
            parameters[0].Value = build_path;

            Model.channel_site model = new Model.channel_site();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
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
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
            strSql.Append(this.column + " from [" + databaseprefix + "channel_site]");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
            strSql.Append("select * from [" + databaseprefix + "channel_site]");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
		#endregion

        #region 扩展方法================================
        /// <summary>
        /// 返回站点名称
        /// </summary>
        public string GetTitle(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 title from " + databaseprefix + "channel_site");
            strSql.Append(" where id=" + id);
            string title = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
            if (string.IsNullOrEmpty(title))
            {
                return "";
            }
            return title;
        }

        /// <summary>
        /// 返回站点名称
        /// </summary>
        public string GetTitle(string build_path)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 title from " + databaseprefix + "channel_site");
            strSql.Append(" where build_path=@build_path");
            SqlParameter[] parameters = {
                    new SqlParameter("@build_path", SqlDbType.NVarChar,100)};
            parameters[0].Value = build_path;
            string title = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString(), parameters));
            if (string.IsNullOrEmpty(title))
            {
                return "";
            }
            return title;
        }

        /// <summary>
        /// 返回站点的生成目录名
        /// </summary>
        public string GetBuildPath(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 build_path from " + databaseprefix + "channel_site");
            strSql.Append(" where id=" + id);
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj != null)
            {
                return Convert.ToString(obj);
            }
            return string.Empty;
        }

        /// <summary>
        /// 返回站点对应的导航ID
        /// </summary>
        public int GetSiteNavId(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select N.id from " + databaseprefix + "navigation as N," + databaseprefix + "channel_site as S");
            strSql.Append(" where 'channel_'+S.build_path=N.name and S.id=" + id);
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj != null)
            {
                return Convert.ToInt32(obj);
            }
            return 0;
        }

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public bool UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "channel_site set " + strValue);
            strSql.Append(" where id=" + id);
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        /// 修改一列数据
        /// </summary>
        public bool UpdateField(string build_path, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "channel_site set " + strValue);
            strSql.Append(" where build_path=@build_path");
            SqlParameter[] parameters = {
                    new SqlParameter("@build_path", SqlDbType.NVarChar,100)};
            parameters[0].Value = build_path;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        /// 将对象转换为实体
        /// </summary>
        public Model.channel_site DataRowToModel(DataRow row)
        {
            Model.channel_site model = new Model.channel_site();
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
                if (null != row["bdsend"] && "" != row["bdsend"].ToString())
                {
                    model.bdsend = int.Parse(row["bdsend"].ToString());
                }
                if (null != row["bdtoken"])
                {
                    model.bdtoken = row["bdtoken"].ToString();
                }
                if (null != row["sort_id"] && "" != row["sort_id"].ToString())
                {
                    model.sort_id = int.Parse(row["sort_id"].ToString());
                }
                if (null != row["inherit_id"] && "" != row["inherit_id"].ToString())
                {
                    model.inherit_id = int.Parse(row["inherit_id"].ToString());
                }
            }
            return model;
        }
        #endregion

    }
}

