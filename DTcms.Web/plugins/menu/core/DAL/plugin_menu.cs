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
    public partial class plugin_menu
    {
        private string column;
        private string databaseprefix; 
        public plugin_menu(string _databaseprefix)
        {
            this.databaseprefix = _databaseprefix;
            this.column = "id,class_id,title,link_url,parent_id,class_list,class_layer,target,sort_id,css_txt,img_url,is_lock,add_time";
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
            return DbHelperSQL.Exists("select count(1) from [" + databaseprefix + "plugin_menu] where id=@id", parameters);
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
            return DbHelperSQL.Exists("select count(1) from [" + databaseprefix + "plugin_menu] where title=@title", parameters);
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
            object obj = DbHelperSQL.GetSingle("select title from [" + databaseprefix + "plugin_menu] where id=@id", parameters);
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
            strSql.Append("select count(*) as H from [" + databaseprefix + "plugin_menu]");
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
        /// <param name="model">Model.plugin_menu</param>
        /// <returns>ID</returns>
        public int Add(Model.plugin_menu model)
        {
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("insert into [" + databaseprefix + "plugin_menu](");
                        strSql.Append("class_id,title,link_url,parent_id,class_list,class_layer,target,sort_id,css_txt,img_url,is_lock,add_time");
                        strSql.Append(") values(");
                        strSql.Append("@class_id,@title,@link_url,@parent_id,@class_list,@class_layer,@target,@sort_id,@css_txt,@img_url,@is_lock,@add_time)");
                        strSql.Append(";select @@IDENTITY");
                        SqlParameter[] parameters = {
                            new SqlParameter("@class_id", SqlDbType.Int,4),
                            new SqlParameter("@title", SqlDbType.NVarChar,255),
                            new SqlParameter("@link_url", SqlDbType.NVarChar,255),
                            new SqlParameter("@parent_id", SqlDbType.Int,4),
                            new SqlParameter("@class_list", SqlDbType.NVarChar,500),
                            new SqlParameter("@class_layer", SqlDbType.Int,4),
                            new SqlParameter("@target", SqlDbType.NVarChar,20),
                            new SqlParameter("@sort_id", SqlDbType.Int,4),
                            new SqlParameter("@css_txt", SqlDbType.NVarChar,50),
                            new SqlParameter("@img_url", SqlDbType.NVarChar,200),
                            new SqlParameter("@is_lock", SqlDbType.TinyInt,1),
                            new SqlParameter("@add_time", SqlDbType.DateTime)
                        };
                        parameters[0].Value = model.class_id;
                        parameters[1].Value = model.title;
                        parameters[2].Value = model.link_url;
                        parameters[3].Value = model.parent_id;
                        parameters[4].Value = model.class_list;
                        parameters[5].Value = model.class_layer;
                        parameters[6].Value = model.target;
                        parameters[7].Value = model.sort_id;
                        parameters[8].Value = model.css_txt;
                        parameters[9].Value = model.img_url;
                        parameters[10].Value = model.is_lock;
                        parameters[11].Value = model.add_time;
            			object obj = DbHelperSQL.GetSingle(conn, trans, strSql.ToString(), parameters); //带事务
            			model.id = Convert.ToInt32(obj);
            			if (model.parent_id > 0)
            			{
            				Model.plugin_menu model2 = GetModel(conn, trans, model.parent_id); //带事务
            				model.class_list = model2.class_list + model.id + ",";
            				model.class_layer = model2.class_layer + 1;
            			}
            			else
            			{
            				model.class_list = "," + model.id + ",";
            				model.class_layer = 1;
            			}
            			//修改节点列表和深度
            			DbHelperSQL.ExecuteSql(conn, trans, "update [" + databaseprefix + "plugin_menu] set class_list='" + model.class_list + "', class_layer=" + model.class_layer + " where id=" + model.id); //带事务
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
            strSql.Append("update [" + databaseprefix + "plugin_menu] set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">Model.plugin_menu</param>
        /// <returns>True or False</returns>
        public bool Update(Model.plugin_menu model)
        {
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
            			//先判断选中的父节点是否被包含
            			if (IsContainNode(model.id, model.parent_id))
            			{
            				//查找旧数据
            				Model.plugin_menu oldModel = GetModel(model.id);
            				//查找旧父节点数据
            				string class_list = "," + model.parent_id + ",";
            				int class_layer = 1;
            				if (oldModel.parent_id > 0)
            				{
            					Model.plugin_menu oldParentModel = GetModel(conn, trans, oldModel.parent_id); //带事务
            					class_list = oldParentModel.class_list + model.parent_id + ",";
            					class_layer = oldParentModel.class_layer + 1;
            				}
            				//先提升选中的父节点
            				DbHelperSQL.ExecuteSql(conn, trans, "update [" + databaseprefix + "plugin_menu] set parent_id=" + oldModel.parent_id + ",class_list='" + class_list + "', class_layer=" + class_layer + " where id=" + model.parent_id); //带事务
            				UpdateChilds(conn, trans, model.parent_id); //带事务
            			}
            			//更新子节点
            			if (model.parent_id > 0)
            			{
            				Model.plugin_menu model2 = GetModel(conn, trans, model.parent_id); //带事务
            				model.class_list = model2.class_list + model.id + ",";
            				model.class_layer = model2.class_layer + 1;
            			}
            			else
            			{
            				model.class_list = "," + model.id + ",";
            				model.class_layer = 1;
            			}
            			StringBuilder strSql = new StringBuilder();
            			strSql.Append("update [" + databaseprefix + "plugin_menu] set ");
            			strSql.Append("class_id=@class_id,");
            			strSql.Append("title=@title,");
            			strSql.Append("link_url=@link_url,");
            			strSql.Append("parent_id=@parent_id,");
            			strSql.Append("class_list=@class_list,");
            			strSql.Append("class_layer=@class_layer,");
            			strSql.Append("target=@target,");
            			strSql.Append("sort_id=@sort_id,");
            			strSql.Append("css_txt=@css_txt,");
            			strSql.Append("img_url=@img_url,");
            			strSql.Append("is_lock=@is_lock,");
            			strSql.Append("add_time=@add_time");
            			strSql.Append(" where id=@id");
            			SqlParameter[] parameters = {
                            new SqlParameter("@class_id", SqlDbType.Int,4),
                            new SqlParameter("@title", SqlDbType.NVarChar,255),
                            new SqlParameter("@link_url", SqlDbType.NVarChar,255),
                            new SqlParameter("@parent_id", SqlDbType.Int,4),
                            new SqlParameter("@class_list", SqlDbType.NVarChar,500),
                            new SqlParameter("@class_layer", SqlDbType.Int,4),
                            new SqlParameter("@target", SqlDbType.NVarChar,20),
                            new SqlParameter("@sort_id", SqlDbType.Int,4),
                            new SqlParameter("@css_txt", SqlDbType.NVarChar,50),
                            new SqlParameter("@img_url", SqlDbType.NVarChar,200),
                            new SqlParameter("@is_lock", SqlDbType.TinyInt,1),
                            new SqlParameter("@add_time", SqlDbType.DateTime),
            			    new SqlParameter("@id", SqlDbType.Int,4)
            			};
                        parameters[0].Value = model.class_id;
                        parameters[1].Value = model.title;
                        parameters[2].Value = model.link_url;
                        parameters[3].Value = model.parent_id;
                        parameters[4].Value = model.class_list;
                        parameters[5].Value = model.class_layer;
                        parameters[6].Value = model.target;
                        parameters[7].Value = model.sort_id;
                        parameters[8].Value = model.css_txt;
                        parameters[9].Value = model.img_url;
                        parameters[10].Value = model.is_lock;
                        parameters[11].Value = model.add_time;
            			parameters[12].Value = model.id;
            			DbHelperSQL.ExecuteSql(conn, trans, strSql.ToString(), parameters);
            			//更新子节点
            			UpdateChilds(conn, trans, model.id);
            			trans.Commit();
                    }
                    catch (Exception ex)
                    {
            			trans.Rollback();
            			return false;
            			throw ex;
                    }
                }
            }
            return true;
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
            int rows = DbHelperSQL.ExecuteSql("delete from [" + databaseprefix + "plugin_menu] where id=@id", parameters);
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
        /// <returns>Model.plugin_menu</returns>
        public Model.plugin_menu GetModel(int id)
        {
            SqlParameter[] parameters = {
            		new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;
            DataSet ds = DbHelperSQL.Query("select " + this.column + " from [" + databaseprefix + "plugin_menu] where id=@id", parameters);
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
        /// 得到一个对象实体(重载，带事务)
        /// </summary>
        /// <param name="conn">SQL连接</param>
        /// <param name="trans">T-SQL事务</param>
        /// <param name="id">ID号</param>
        public Model.plugin_menu GetModel(SqlConnection conn, SqlTransaction trans, int id)
        {
            SqlParameter[] parameters = {
        					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;
            DataSet ds = DbHelperSQL.Query(conn, trans, "select " + this.column + " from [" + databaseprefix + "plugin_menu] where id=@id", parameters);
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
            strSql.Append(this.column + " from [" + databaseprefix + "plugin_menu]");
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

        #region 取得所有列表
        /// <summary>
        /// 取得所有列表
        /// </summary>
        /// <param name="Top">数量</param>
        /// <param name="parent_id">父类ID</param>
        /// <param name="strWhere">条件</param>
        /// <param name="filedOrder">排序</param>
        /// <returns>DataTable</returns>
        public DataTable GetList(int Top, int parent_id, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString()+" ");
            }
            strSql.Append(this.column + " from [" + databaseprefix + "plugin_menu]");
            if ("" != strWhere.Trim())
            {
                strSql.Append(" where " + strWhere);
            }
            if ("" != filedOrder.Trim())
            {
                strSql.Append(" order by " + filedOrder);
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            DataTable oldData = ds.Tables[0] as DataTable;
            if (null == oldData)
            {
                return null;
            }
            //复制结构
            DataTable newData = oldData.Clone();
            //调用迭代组合成DataTable
            GetChilds(oldData, newData, parent_id);
            return newData;
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 组合成对象实体
        /// </summary>
        /// <param name="row">一行数据</param>
        /// <returns>Model.plugin_menu</returns>
        private Model.plugin_menu DataRowToModel(DataRow row)
        {
            Model.plugin_menu model = new Model.plugin_menu();
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
            	if (null != row["link_url"])
            	{
            		model.link_url = row["link_url"].ToString();
            	}
            	if (null != row["parent_id"] && "" != row["parent_id"].ToString())
            	{
            		model.parent_id = int.Parse(row["parent_id"].ToString());
            	}
            	if (null != row["class_list"])
            	{
            		model.class_list = row["class_list"].ToString();
            	}
            	if (null != row["class_layer"] && "" != row["class_layer"].ToString())
            	{
            		model.class_layer = int.Parse(row["class_layer"].ToString());
            	}
            	if (null != row["target"])
            	{
            		model.target = row["target"].ToString();
            	}
            	if (null != row["sort_id"] && "" != row["sort_id"].ToString())
            	{
            		model.sort_id = int.Parse(row["sort_id"].ToString());
            	}
            	if (null != row["css_txt"])
            	{
            		model.css_txt = row["css_txt"].ToString();
            	}
            	if (null != row["img_url"])
            	{
            		model.img_url = row["img_url"].ToString();
            	}
            	if (null != row["is_lock"] && "" != row["is_lock"].ToString())
            	{
            		model.is_lock = int.Parse(row["is_lock"].ToString());
            	}
            	if (null != row["add_time"] && "" != row["add_time"].ToString())
            	{
            		model.add_time = DateTime.Parse(row["add_time"].ToString());
            	}
            }
            return model;
        }

        /// <summary>
        /// 从内存中取得所有下级类别列表（自身迭代）
        /// </summary>
        /// <param name="parent_id">父类ID</param>
        private void GetChilds(DataTable oldData, DataTable newData, int parent_id)
        {
            DataRow[] dr = oldData.Select("parent_id=" + parent_id);
            for (int i = 0; i < dr.Length; i++)
            {
                //添加一行数据
                DataRow row = newData.NewRow();
            	row["id"] = int.Parse(dr[i]["id"].ToString());
            	row["class_id"] = int.Parse(dr[i]["class_id"].ToString());
            	row["title"] = dr[i]["title"].ToString();
            	row["link_url"] = dr[i]["link_url"].ToString();
            	row["parent_id"] = int.Parse(dr[i]["parent_id"].ToString());
            	row["class_list"] = dr[i]["class_list"].ToString();
            	row["class_layer"] = int.Parse(dr[i]["class_layer"].ToString());
            	row["target"] = dr[i]["target"].ToString();
            	row["sort_id"] = int.Parse(dr[i]["sort_id"].ToString());
            	row["css_txt"] = dr[i]["css_txt"].ToString();
            	row["img_url"] = dr[i]["img_url"].ToString();
            	row["is_lock"] = int.Parse(dr[i]["is_lock"].ToString());
            	row["add_time"] = DateTime.Parse(dr[i]["add_time"].ToString());
                newData.Rows.Add(row);
                //调用自身迭代
                this.GetChilds(oldData, newData, int.Parse(dr[i]["id"].ToString()));
            }
        }

        /// <summary>
        /// 修改子节点的ID列表及深度（自身迭代）
        /// </summary>
        /// <param name="parent_id">父类ID</param>
        private void UpdateChilds(SqlConnection conn, SqlTransaction trans, int parent_id)
        {
            //查找父节点信息
            Model.plugin_menu model = GetModel(conn, trans, parent_id);
            if (null != model)
            {
        		//查找子节点
        		string strSql = "select id from [" + databaseprefix + "plugin_menu] where parent_id=" + parent_id;
        		DataSet ds = DbHelperSQL.Query(conn, trans, strSql); //带事务
        		foreach (DataRow dr in ds.Tables[0].Rows)
        		{
        			//修改子节点的ID列表及深度
        			int id = int.Parse(dr["id"].ToString());
        			string class_list = model.class_list + id + ",";
        			int class_layer = model.class_layer + 1;
        			DbHelperSQL.ExecuteSql(conn, trans, "update [" + databaseprefix + "plugin_menu] set class_list='" + class_list + "', class_layer=" + class_layer + " where id=" + id); //带事务
        			//调用自身迭代
        			this.UpdateChilds(conn, trans, id); //带事务
        		}
            }
        }

        /// <summary>
        /// 验证节点是否被包含
        /// </summary>
        /// <param name="id">ID号</param>
        /// <param name="parent_id">父类ID</param>
        /// <returns></returns>
        private bool IsContainNode(int id, int parent_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [" + databaseprefix + "plugin_menu] where class_list like '%," + id + ",%' and id=" + parent_id);
            return DbHelperSQL.Exists(strSql.ToString());
        }
        #endregion
    }
}
