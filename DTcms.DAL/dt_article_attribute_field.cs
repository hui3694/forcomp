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
    public partial class dt_article_attribute_field
    {
        private string column;
        private string databaseprefix; 
        public dt_article_attribute_field(string _databaseprefix)
        {
            this.databaseprefix = _databaseprefix;
            this.column = "id,name,title,control_type,data_type,data_length,data_place,item_option,default_value,is_required,is_password,is_html,editor_type,valid_tip_msg,valid_error_msg,valid_pattern,sort_id,is_sys";
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
            return DbHelperSQL.Exists("select count(1) from [" + databaseprefix + "dt_article_attribute_field] where id=@id", parameters);
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
            return DbHelperSQL.Exists("select count(1) from [" + databaseprefix + "dt_article_attribute_field] where title=@title", parameters);
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
            object obj = DbHelperSQL.GetSingle("select title from [" + databaseprefix + "dt_article_attribute_field] where id=@id", parameters);
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
            object obj = DbHelperSQL.GetSingle("select name from [" + databaseprefix + "dt_article_attribute_field] where id=@id", parameters);
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
            object obj = DbHelperSQL.GetSingle("select id from [" + databaseprefix + "dt_article_attribute_field] where name=@name ", parameters);
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
            strSql.Append("select count(*) as H from [" + databaseprefix + "dt_article_attribute_field]");
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
        /// <param name="model">Model.dt_article_attribute_field</param>
        /// <returns>ID</returns>
        public int Add(Model.dt_article_attribute_field model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [" + databaseprefix + "dt_article_attribute_field](");
            strSql.Append("name,title,control_type,data_type,data_length,data_place,item_option,default_value,is_required,is_password,is_html,editor_type,valid_tip_msg,valid_error_msg,valid_pattern,sort_id,is_sys");
            strSql.Append(") values(");
            strSql.Append("@name,@title,@control_type,@data_type,@data_length,@data_place,@item_option,@default_value,@is_required,@is_password,@is_html,@editor_type,@valid_tip_msg,@valid_error_msg,@valid_pattern,@sort_id,@is_sys)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                new SqlParameter("@name", SqlDbType.NVarChar,100),
                new SqlParameter("@title", SqlDbType.NVarChar,100),
                new SqlParameter("@control_type", SqlDbType.NVarChar,50),
                new SqlParameter("@data_type", SqlDbType.NVarChar,50),
                new SqlParameter("@data_length", SqlDbType.Int,4),
                new SqlParameter("@data_place", SqlDbType.TinyInt,1),
                new SqlParameter("@item_option", SqlDbType.NText),
                new SqlParameter("@default_value", SqlDbType.NText),
                new SqlParameter("@is_required", SqlDbType.TinyInt,1),
                new SqlParameter("@is_password", SqlDbType.TinyInt,1),
                new SqlParameter("@is_html", SqlDbType.TinyInt,1),
                new SqlParameter("@editor_type", SqlDbType.TinyInt,1),
                new SqlParameter("@valid_tip_msg", SqlDbType.NVarChar,255),
                new SqlParameter("@valid_error_msg", SqlDbType.NVarChar,255),
                new SqlParameter("@valid_pattern", SqlDbType.NVarChar,500),
                new SqlParameter("@sort_id", SqlDbType.Int,4),
				new SqlParameter("@is_sys", SqlDbType.TinyInt,1)
            };
            parameters[0].Value = model.name;
            parameters[1].Value = model.title;
            parameters[2].Value = model.control_type;
            parameters[3].Value = model.data_type;
            parameters[4].Value = model.data_length;
            parameters[5].Value = model.data_place;
            parameters[6].Value = model.item_option;
            parameters[7].Value = model.default_value;
            parameters[8].Value = model.is_required;
            parameters[9].Value = model.is_password;
            parameters[10].Value = model.is_html;
            parameters[11].Value = model.editor_type;
            parameters[12].Value = model.valid_tip_msg;
            parameters[13].Value = model.valid_error_msg;
            parameters[14].Value = model.valid_pattern;
            parameters[15].Value = model.sort_id;
            parameters[16].Value = model.is_sys;
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
            DbHelperSQL.ExecuteSql("update [" + databaseprefix + "dt_article_attribute_field] set " + strValue + " where id=" + id);
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">Model.dt_article_attribute_field</param>
        /// <returns>True or False</returns>
        public bool Update(Model.dt_article_attribute_field model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [" + databaseprefix + "dt_article_attribute_field] set ");
            strSql.Append("name=@name,");
            strSql.Append("title=@title,");
            strSql.Append("control_type=@control_type,");
            strSql.Append("data_type=@data_type,");
            strSql.Append("data_length=@data_length,");
            strSql.Append("data_place=@data_place,");
            strSql.Append("item_option=@item_option,");
            strSql.Append("default_value=@default_value,");
            strSql.Append("is_required=@is_required,");
            strSql.Append("is_password=@is_password,");
            strSql.Append("is_html=@is_html,");
            strSql.Append("editor_type=@editor_type,");
            strSql.Append("valid_tip_msg=@valid_tip_msg,");
            strSql.Append("valid_error_msg=@valid_error_msg,");
            strSql.Append("valid_pattern=@valid_pattern,");
            strSql.Append("sort_id=@sort_id,");
            strSql.Append("is_sys=@is_sys");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                new SqlParameter("@name", SqlDbType.NVarChar,100),
                new SqlParameter("@title", SqlDbType.NVarChar,100),
                new SqlParameter("@control_type", SqlDbType.NVarChar,50),
                new SqlParameter("@data_type", SqlDbType.NVarChar,50),
                new SqlParameter("@data_length", SqlDbType.Int,4),
                new SqlParameter("@data_place", SqlDbType.TinyInt,1),
                new SqlParameter("@item_option", SqlDbType.NText),
                new SqlParameter("@default_value", SqlDbType.NText),
                new SqlParameter("@is_required", SqlDbType.TinyInt,1),
                new SqlParameter("@is_password", SqlDbType.TinyInt,1),
                new SqlParameter("@is_html", SqlDbType.TinyInt,1),
                new SqlParameter("@editor_type", SqlDbType.TinyInt,1),
                new SqlParameter("@valid_tip_msg", SqlDbType.NVarChar,255),
                new SqlParameter("@valid_error_msg", SqlDbType.NVarChar,255),
                new SqlParameter("@valid_pattern", SqlDbType.NVarChar,500),
                new SqlParameter("@sort_id", SqlDbType.Int,4),
				new SqlParameter("@is_sys", SqlDbType.TinyInt,1),
                new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = model.name;
            parameters[1].Value = model.title;
            parameters[2].Value = model.control_type;
            parameters[3].Value = model.data_type;
            parameters[4].Value = model.data_length;
            parameters[5].Value = model.data_place;
            parameters[6].Value = model.item_option;
            parameters[7].Value = model.default_value;
            parameters[8].Value = model.is_required;
            parameters[9].Value = model.is_password;
            parameters[10].Value = model.is_html;
            parameters[11].Value = model.editor_type;
            parameters[12].Value = model.valid_tip_msg;
            parameters[13].Value = model.valid_error_msg;
            parameters[14].Value = model.valid_pattern;
            parameters[15].Value = model.sort_id;
            parameters[16].Value = model.is_sys;
            parameters[17].Value = model.id;
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
            int rows = DbHelperSQL.ExecuteSql("delete from [" + databaseprefix + "dt_article_attribute_field] where id=@id", parameters);
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
        /// <returns>Model.dt_article_attribute_field</returns>
        public Model.dt_article_attribute_field GetModel(int id)
        {
            SqlParameter[] parameters = {
            		new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;
            DataSet ds = DbHelperSQL.Query("select " + this.column + " from [" + databaseprefix + "dt_article_attribute_field] where id=@id", parameters);
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
        /// <returns>Model.dt_article_attribute_field</returns>
        public Model.dt_article_attribute_field GetModel(string name)
        {
            SqlParameter[] parameters = {
        					new SqlParameter("@name", SqlDbType.NVarChar,50)};
            parameters[0].Value = nav_name;
            object obj = DbHelperSQL.GetSingle("select id from [" + databaseprefix + "dt_article_attribute_field] where name=@name", parameters);
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
            strSql.Append(this.column + " from [" + databaseprefix + "dt_article_attribute_field]");
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
            strSql.Append("select * from [" + databaseprefix + "dt_article_attribute_field]");
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
        /// <returns>Model.dt_article_attribute_field</returns>
        private Model.dt_article_attribute_field DataRowToModel(DataRow row)
        {
            Model.dt_article_attribute_field model = new Model.dt_article_attribute_field();
            if (row != null)
            {
            	if (null != row["id"] && "" != row["id"].ToString())
            	{
            		model.id = int.Parse(row["id"].ToString());
            	}
            	if (null != row["name"])
            	{
            		model.name = row["name"].ToString();
            	}
            	if (null != row["title"])
            	{
            		model.title = row["title"].ToString();
            	}
            	if (null != row["control_type"])
            	{
            		model.control_type = row["control_type"].ToString();
            	}
            	if (null != row["data_type"])
            	{
            		model.data_type = row["data_type"].ToString();
            	}
            	if (null != row["data_length"] && "" != row["data_length"].ToString())
            	{
            		model.data_length = int.Parse(row["data_length"].ToString());
            	}
            	if (null != row["data_place"] && "" != row["data_place"].ToString())
            	{
            		model.data_place = int.Parse(row["data_place"].ToString());
            	}
            	if (null != row["item_option"])
            	{
            		model.item_option = row["item_option"].ToString();
            	}
            	if (null != row["default_value"])
            	{
            		model.default_value = row["default_value"].ToString();
            	}
            	if (null != row["is_required"] && "" != row["is_required"].ToString())
            	{
            		model.is_required = int.Parse(row["is_required"].ToString());
            	}
            	if (null != row["is_password"] && "" != row["is_password"].ToString())
            	{
            		model.is_password = int.Parse(row["is_password"].ToString());
            	}
            	if (null != row["is_html"] && "" != row["is_html"].ToString())
            	{
            		model.is_html = int.Parse(row["is_html"].ToString());
            	}
            	if (null != row["editor_type"] && "" != row["editor_type"].ToString())
            	{
            		model.editor_type = int.Parse(row["editor_type"].ToString());
            	}
            	if (null != row["valid_tip_msg"])
            	{
            		model.valid_tip_msg = row["valid_tip_msg"].ToString();
            	}
            	if (null != row["valid_error_msg"])
            	{
            		model.valid_error_msg = row["valid_error_msg"].ToString();
            	}
            	if (null != row["valid_pattern"])
            	{
            		model.valid_pattern = row["valid_pattern"].ToString();
            	}
            	if (null != row["sort_id"] && "" != row["sort_id"].ToString())
            	{
            		model.sort_id = int.Parse(row["sort_id"].ToString());
            	}
            	if (null != row["is_sys"] && "" != row["is_sys"].ToString())
            	{
            		model.is_sys = int.Parse(row["is_sys"].ToString());
            	}
            }
            return model;
        }
        #endregion
    }
}
