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
    public partial class product
    {
        private string column;
        private string databaseprefix; 
        public product(string _databaseprefix)
        {
            this.databaseprefix = _databaseprefix;
            this.column = "id,category,title,img,cont,lat,lon,city,addr,user_id,status,pass_time,add_time";
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
            return DbHelperSQL.Exists("select count(1) from [" + databaseprefix + "product] where id=@id", parameters);
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
            return DbHelperSQL.Exists("select count(1) from [" + databaseprefix + "product] where title=@title", parameters);
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
            object obj = DbHelperSQL.GetSingle("select title from [" + databaseprefix + "product] where id=@id", parameters);
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
            strSql.Append("select count(*) as H from [" + databaseprefix + "product]");
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
        /// <param name="model">Model.product</param>
        /// <returns>ID</returns>
        public int Add(Model.product model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [" + databaseprefix + "product](");
            strSql.Append("category,title,img,cont,lat,lon,city,addr,user_id,status,pass_time,add_time");
            strSql.Append(") values(");
            strSql.Append("@category,@title,@img,@cont,@lat,@lon,@city,@addr,@user_id,@status,@pass_time,@add_time)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                new SqlParameter("@category", SqlDbType.Int,4),
                new SqlParameter("@title", SqlDbType.NVarChar,100),
                new SqlParameter("@img", SqlDbType.NVarChar,200),
                new SqlParameter("@cont", SqlDbType.NText),
                new SqlParameter("@lat", SqlDbType.NVarChar,30),
                new SqlParameter("@lon", SqlDbType.NVarChar,30),
                new SqlParameter("@city", SqlDbType.NVarChar,50),
                new SqlParameter("@addr", SqlDbType.NVarChar,200),
                new SqlParameter("@user_id", SqlDbType.Int,4),
                new SqlParameter("@status", SqlDbType.Int,4),
                new SqlParameter("@pass_time", SqlDbType.DateTime),
				new SqlParameter("@add_time", SqlDbType.DateTime)
            };
            parameters[0].Value = model.category;
            parameters[1].Value = model.title;
            parameters[2].Value = model.img;
            parameters[3].Value = model.cont;
            parameters[4].Value = model.lat;
            parameters[5].Value = model.lon;
            parameters[6].Value = model.city;
            parameters[7].Value = model.addr;
            parameters[8].Value = model.user_id;
            parameters[9].Value = model.status;
            parameters[10].Value = model.pass_time;
            parameters[11].Value = model.add_time;
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
            DbHelperSQL.ExecuteSql("update [" + databaseprefix + "product] set " + strValue + " where id=" + id);
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">Model.product</param>
        /// <returns>True or False</returns>
        public bool Update(Model.product model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [" + databaseprefix + "product] set ");
            strSql.Append("category=@category,");
            strSql.Append("title=@title,");
            strSql.Append("img=@img,");
            strSql.Append("cont=@cont,");
            strSql.Append("lat=@lat,");
            strSql.Append("lon=@lon,");
            strSql.Append("city=@city,");
            strSql.Append("addr=@addr,");
            strSql.Append("user_id=@user_id,");
            strSql.Append("status=@status,");
            strSql.Append("pass_time=@pass_time,");
            strSql.Append("add_time=@add_time");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                new SqlParameter("@category", SqlDbType.Int,4),
                new SqlParameter("@title", SqlDbType.NVarChar,100),
                new SqlParameter("@img", SqlDbType.NVarChar,200),
                new SqlParameter("@cont", SqlDbType.NText),
                new SqlParameter("@lat", SqlDbType.NVarChar,30),
                new SqlParameter("@lon", SqlDbType.NVarChar,30),
                new SqlParameter("@city", SqlDbType.NVarChar,50),
                new SqlParameter("@addr", SqlDbType.NVarChar,200),
                new SqlParameter("@user_id", SqlDbType.Int,4),
                new SqlParameter("@status", SqlDbType.Int,4),
                new SqlParameter("@pass_time", SqlDbType.DateTime),
				new SqlParameter("@add_time", SqlDbType.DateTime),
                new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = model.category;
            parameters[1].Value = model.title;
            parameters[2].Value = model.img;
            parameters[3].Value = model.cont;
            parameters[4].Value = model.lat;
            parameters[5].Value = model.lon;
            parameters[6].Value = model.city;
            parameters[7].Value = model.addr;
            parameters[8].Value = model.user_id;
            parameters[9].Value = model.status;
            parameters[10].Value = model.pass_time;
            parameters[11].Value = model.add_time;
            parameters[12].Value = model.id;
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
            int rows = DbHelperSQL.ExecuteSql("delete from [" + databaseprefix + "product] where id=@id", parameters);
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
        /// <returns>Model.product</returns>
        public Model.product GetModel(int id)
        {
            SqlParameter[] parameters = {
            		new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;
            DataSet ds = DbHelperSQL.Query("select " + this.column + " from [" + databaseprefix + "product] where id=@id", parameters);
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
            strSql.Append(this.column + " from [" + databaseprefix + "product]");
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
            strSql.Append("select * from [" + databaseprefix + "product]");
            if ("" != strWhere.Trim())
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
        #endregion

        public DataSet GetCityList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select distinct(city) from [" + databaseprefix + "product]");
            return DbHelperSQL.Query(strSql.ToString());
        }

        #region 私有方法
        /// <summary>
        /// 组合成对象实体
        /// </summary>
        /// <param name="row">一行数据</param>
        /// <returns>Model.product</returns>
        private Model.product DataRowToModel(DataRow row)
        {
            Model.product model = new Model.product();
            if (row != null)
            {
            	if (null != row["id"] && "" != row["id"].ToString())
            	{
            		model.id = int.Parse(row["id"].ToString());
            	}
            	if (null != row["category"] && "" != row["category"].ToString())
            	{
            		model.category = int.Parse(row["category"].ToString());
            	}
            	if (null != row["title"])
            	{
            		model.title = row["title"].ToString();
            	}
            	if (null != row["img"])
            	{
            		model.img = row["img"].ToString();
            	}
            	if (null != row["cont"])
            	{
            		model.cont = row["cont"].ToString();
            	}
            	if (null != row["lat"])
            	{
            		model.lat = row["lat"].ToString();
            	}
            	if (null != row["lon"])
            	{
            		model.lon = row["lon"].ToString();
            	}
            	if (null != row["city"])
            	{
            		model.city = row["city"].ToString();
            	}
            	if (null != row["addr"])
            	{
            		model.addr = row["addr"].ToString();
            	}
            	if (null != row["user_id"] && "" != row["user_id"].ToString())
            	{
            		model.user_id = int.Parse(row["user_id"].ToString());
            	}
            	if (null != row["status"] && "" != row["status"].ToString())
            	{
            		model.status = int.Parse(row["status"].ToString());
            	}
            	if (null != row["pass_time"] && "" != row["pass_time"].ToString())
            	{
            		model.pass_time = DateTime.Parse(row["pass_time"].ToString());
            	}
            	if (null != row["add_time"] && "" != row["add_time"].ToString())
            	{
            		model.add_time = DateTime.Parse(row["add_time"].ToString());
            	}
            }
            return model;
        }
        #endregion
    }
}
