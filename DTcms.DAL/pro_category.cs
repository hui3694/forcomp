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
    public partial class pro_category
    {
        private string column;
        private string databaseprefix; 
        public pro_category(string _databaseprefix)
        {
            this.databaseprefix = _databaseprefix;
            this.column = "id,title,img,img2,parent_id,sort,is_sys";
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
            return DbHelperSQL.Exists("select count(1) from [" + databaseprefix + "pro_category] where id=@id", parameters);
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
            return DbHelperSQL.Exists("select count(1) from [" + databaseprefix + "pro_category] where title=@title", parameters);
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
            object obj = DbHelperSQL.GetSingle("select title from [" + databaseprefix + "pro_category] where id=@id", parameters);
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
            strSql.Append("select count(*) as H from [" + databaseprefix + "pro_category]");
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
        /// <param name="model">Model.pro_category</param>
        /// <returns>ID</returns>
        public int Add(Model.pro_category model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [" + databaseprefix + "pro_category](");
            strSql.Append("title,img,img2,parent_id,sort,is_sys");
            strSql.Append(") values(");
            strSql.Append("@title,@img,@img2,@parent_id,@sort,@is_sys)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                new SqlParameter("@title", SqlDbType.VarChar,100),
                new SqlParameter("@img", SqlDbType.NText),
                new SqlParameter("@img2", SqlDbType.NText),
                new SqlParameter("@parent_id", SqlDbType.Int,4),
                new SqlParameter("@sort", SqlDbType.Int,4),
				new SqlParameter("@is_sys", SqlDbType.TinyInt,1)
            };
            parameters[0].Value = model.title;
            parameters[1].Value = model.img;
            parameters[2].Value = model.img2;
            parameters[3].Value = model.parent_id;
            parameters[4].Value = model.sort;
            parameters[5].Value = model.is_sys;
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
            DbHelperSQL.ExecuteSql("update [" + databaseprefix + "pro_category] set " + strValue + " where id=" + id);
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">Model.pro_category</param>
        /// <returns>True or False</returns>
        public bool Update(Model.pro_category model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [" + databaseprefix + "pro_category] set ");
            strSql.Append("title=@title,");
            strSql.Append("img=@img,");
            strSql.Append("img2=@img2,");
            strSql.Append("parent_id=@parent_id,");
            strSql.Append("sort=@sort,");
            strSql.Append("is_sys=@is_sys");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                new SqlParameter("@title", SqlDbType.VarChar,100),
                new SqlParameter("@img", SqlDbType.NText),
                new SqlParameter("@img2", SqlDbType.NText),
                new SqlParameter("@parent_id", SqlDbType.Int,4),
                new SqlParameter("@sort", SqlDbType.Int,4),
				new SqlParameter("@is_sys", SqlDbType.TinyInt,1),
                new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = model.title;
            parameters[1].Value = model.img;
            parameters[2].Value = model.img2;
            parameters[3].Value = model.parent_id;
            parameters[4].Value = model.sort;
            parameters[5].Value = model.is_sys;
            parameters[6].Value = model.id;
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
            int rows = DbHelperSQL.ExecuteSql("delete from [" + databaseprefix + "pro_category] where id=@id", parameters);
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
        /// <returns>Model.pro_category</returns>
        public Model.pro_category GetModel(int id)
        {
            SqlParameter[] parameters = {
            		new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;
            DataSet ds = DbHelperSQL.Query("select " + this.column + " from [" + databaseprefix + "pro_category] where id=@id", parameters);
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
            strSql.Append(this.column + " from [" + databaseprefix + "pro_category]");
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
            strSql.Append("select * from [" + databaseprefix + "pro_category]");
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
        /// <returns>Model.pro_category</returns>
        private Model.pro_category DataRowToModel(DataRow row)
        {
            Model.pro_category model = new Model.pro_category();
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
            	if (null != row["img"])
            	{
            		model.img = row["img"].ToString();
            	}
            	if (null != row["img2"])
            	{
            		model.img2 = row["img2"].ToString();
            	}
            	if (null != row["parent_id"] && "" != row["parent_id"].ToString())
            	{
            		model.parent_id = int.Parse(row["parent_id"].ToString());
            	}
            	if (null != row["sort"] && "" != row["sort"].ToString())
            	{
            		model.sort = int.Parse(row["sort"].ToString());
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
