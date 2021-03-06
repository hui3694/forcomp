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
    public partial class user_pm
    {
        private string column;
        private string databaseprefix; 
        public user_pm(string _databaseprefix)
        {
            this.databaseprefix = _databaseprefix;
            this.column = "id,user_id,name,sex,origin,phone,comname,job,year,jobimg,img,status,add_time,pass_time";
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
            return DbHelperSQL.Exists("select count(1) from [" + databaseprefix + "user_pm] where id=@id", parameters);
        }

        /// <summary>
        /// 按名称查询是否存在记录
        /// </summary>
        /// <param name="title">标题</param>
        /// <returns>True or False</returns>
        public bool Exists(string name)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@name", SqlDbType.VarChar,200)
            };
            parameters[0].Value = name;
            return DbHelperSQL.Exists("select count(1) from [" + databaseprefix + "user_pm] where name=@name", parameters);
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
            object obj = DbHelperSQL.GetSingle("select name from [" + databaseprefix + "user_pm] where id=@id", parameters);
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
            object obj = DbHelperSQL.GetSingle("select id from [" + databaseprefix + "user_pm] where name=@name ", parameters);
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
            strSql.Append("select count(*) as H from [" + databaseprefix + "user_pm]");
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
        /// <param name="model">Model.user_pm</param>
        /// <returns>ID</returns>
        public int Add(Model.user_pm model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [" + databaseprefix + "user_pm](");
            strSql.Append("user_id,name,sex,origin,phone,comname,job,year,jobimg,img,status,add_time");
            strSql.Append(") values(");
            strSql.Append("@user_id,@name,@sex,@origin,@phone,@comname,@job,@year,@jobimg,@img,@status,@add_time)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                new SqlParameter("@user_id", SqlDbType.Int,4),
                new SqlParameter("@name", SqlDbType.VarChar,100),
                new SqlParameter("@sex", SqlDbType.Int,4),
                new SqlParameter("@origin", SqlDbType.NVarChar,100),
                new SqlParameter("@phone", SqlDbType.NVarChar,100),
                new SqlParameter("@comname", SqlDbType.NVarChar,100),
                new SqlParameter("@job", SqlDbType.NVarChar,100),
                new SqlParameter("@year", SqlDbType.Int,4),
                new SqlParameter("@jobimg", SqlDbType.NText),
                new SqlParameter("@img", SqlDbType.NText),
                new SqlParameter("@status", SqlDbType.Int,4),
                new SqlParameter("@add_time", SqlDbType.DateTime)
            };
            parameters[0].Value = model.user_id;
            parameters[1].Value = model.name;
            parameters[2].Value = model.sex;
            parameters[3].Value = model.origin;
            parameters[4].Value = model.phone;
            parameters[5].Value = model.comname;
            parameters[6].Value = model.job;
            parameters[7].Value = model.year;
            parameters[8].Value = model.jobimg;
            parameters[9].Value = model.img;
            parameters[10].Value = model.status;
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
            DbHelperSQL.ExecuteSql("update [" + databaseprefix + "user_pm] set " + strValue + " where id=" + id);
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">Model.user_pm</param>
        /// <returns>True or False</returns>
        public bool Update(Model.user_pm model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [" + databaseprefix + "user_pm] set ");
            strSql.Append("user_id=@user_id,");
            strSql.Append("name=@name,");
            strSql.Append("sex=@sex,");
            strSql.Append("origin=@origin,");
            strSql.Append("phone=@phone,");
            strSql.Append("comname=@comname,");
            strSql.Append("job=@job,");
            strSql.Append("year=@year,");
            strSql.Append("jobimg=@jobimg,");
            strSql.Append("img=@img,");
            strSql.Append("status=@status,");
            strSql.Append("add_time=@add_time,");
            strSql.Append("pass_time=@pass_time");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                new SqlParameter("@user_id", SqlDbType.Int,4),
                new SqlParameter("@name", SqlDbType.VarChar,100),
                new SqlParameter("@sex", SqlDbType.Int,4),
                new SqlParameter("@origin", SqlDbType.NVarChar,100),
                new SqlParameter("@phone", SqlDbType.NVarChar,100),
                new SqlParameter("@comname", SqlDbType.NVarChar,100),
                new SqlParameter("@job", SqlDbType.NVarChar,100),
                new SqlParameter("@year", SqlDbType.Int,4),
                new SqlParameter("@jobimg", SqlDbType.NText),
                new SqlParameter("@img", SqlDbType.NText),
                new SqlParameter("@status", SqlDbType.Int,4),
                new SqlParameter("@add_time", SqlDbType.DateTime),
				new SqlParameter("@pass_time", SqlDbType.DateTime),
                new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = model.user_id;
            parameters[1].Value = model.name;
            parameters[2].Value = model.sex;
            parameters[3].Value = model.origin;
            parameters[4].Value = model.phone;
            parameters[5].Value = model.comname;
            parameters[6].Value = model.job;
            parameters[7].Value = model.year;
            parameters[8].Value = model.jobimg;
            parameters[9].Value = model.img;
            parameters[10].Value = model.status;
            parameters[11].Value = model.add_time;
            parameters[12].Value = model.pass_time;
            parameters[13].Value = model.id;
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
            int rows = DbHelperSQL.ExecuteSql("delete from [" + databaseprefix + "user_pm] where id=@id", parameters);
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
        /// <returns>Model.user_pm</returns>
        public Model.user_pm GetModel(int id)
        {
            SqlParameter[] parameters = {
            		new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;
            DataSet ds = DbHelperSQL.Query("select " + this.column + " from [" + databaseprefix + "user_pm] where id=@id", parameters);
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
        /// <returns>Model.user_pm</returns>
        public Model.user_pm GetModel(string name)
        {
            SqlParameter[] parameters = {
        					new SqlParameter("@name", SqlDbType.NVarChar,50)};
            parameters[0].Value = name;
            object obj = DbHelperSQL.GetSingle("select id from [" + databaseprefix + "user_pm] where name=@name", parameters);
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
            strSql.Append(this.column + " from [" + databaseprefix + "user_pm]");
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
            strSql.Append("select * from [" + databaseprefix + "user_pm]");
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
        /// <returns>Model.user_pm</returns>
        private Model.user_pm DataRowToModel(DataRow row)
        {
            Model.user_pm model = new Model.user_pm();
            if (row != null)
            {
            	if (null != row["id"] && "" != row["id"].ToString())
            	{
            		model.id = int.Parse(row["id"].ToString());
            	}
            	if (null != row["user_id"] && "" != row["user_id"].ToString())
            	{
            		model.user_id = int.Parse(row["user_id"].ToString());
            	}
            	if (null != row["name"])
            	{
            		model.name = row["name"].ToString();
            	}
            	if (null != row["sex"] && "" != row["sex"].ToString())
            	{
            		model.sex = int.Parse(row["sex"].ToString());
            	}
            	if (null != row["origin"])
            	{
            		model.origin = row["origin"].ToString();
            	}
            	if (null != row["phone"])
            	{
            		model.phone = row["phone"].ToString();
            	}
            	if (null != row["comname"])
            	{
            		model.comname = row["comname"].ToString();
            	}
            	if (null != row["job"])
            	{
            		model.job = row["job"].ToString();
            	}
            	if (null != row["year"] && "" != row["year"].ToString())
            	{
            		model.year = int.Parse(row["year"].ToString());
            	}
            	if (null != row["jobimg"])
            	{
            		model.jobimg = row["jobimg"].ToString();
            	}
            	if (null != row["img"])
            	{
            		model.img = row["img"].ToString();
            	}
            	if (null != row["status"] && "" != row["status"].ToString())
            	{
            		model.status = int.Parse(row["status"].ToString());
            	}
            	if (null != row["add_time"] && "" != row["add_time"].ToString())
            	{
            		model.add_time = DateTime.Parse(row["add_time"].ToString());
            	}
            	if (null != row["pass_time"] && "" != row["pass_time"].ToString())
            	{
            		model.pass_time = DateTime.Parse(row["pass_time"].ToString());
            	}
            }
            return model;
        }
        #endregion
    }
}
