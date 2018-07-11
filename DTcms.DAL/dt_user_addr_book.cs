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
    public partial class dt_user_addr_book
    {
        private string column;
        private string databaseprefix; 
        public dt_user_addr_book(string _databaseprefix)
        {
            this.databaseprefix = _databaseprefix;
            this.column = "id,user_id,user_name,accept_name,area,address,mobile,telphone,email,post_code,is_default,add_time";
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
            return DbHelperSQL.Exists("select count(1) from [" + databaseprefix + "dt_user_addr_book] where id=@id", parameters);
        }
        /// <summary>
        /// 返回数据总数
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns>总数</returns>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H from [" + databaseprefix + "dt_user_addr_book]");
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
        /// <param name="model">Model.dt_user_addr_book</param>
        /// <returns>ID</returns>
        public int Add(Model.dt_user_addr_book model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [" + databaseprefix + "dt_user_addr_book](");
            strSql.Append("user_id,user_name,accept_name,area,address,mobile,telphone,email,post_code,is_default,add_time");
            strSql.Append(") values(");
            strSql.Append("@user_id,@user_name,@accept_name,@area,@address,@mobile,@telphone,@email,@post_code,@is_default,@add_time)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                new SqlParameter("@user_id", SqlDbType.Int,4),
                new SqlParameter("@user_name", SqlDbType.NVarChar,100),
                new SqlParameter("@accept_name", SqlDbType.NVarChar,100),
                new SqlParameter("@area", SqlDbType.NVarChar,100),
                new SqlParameter("@address", SqlDbType.NVarChar,500),
                new SqlParameter("@mobile", SqlDbType.NVarChar,20),
                new SqlParameter("@telphone", SqlDbType.NVarChar,30),
                new SqlParameter("@email", SqlDbType.NVarChar,50),
                new SqlParameter("@post_code", SqlDbType.NVarChar,20),
                new SqlParameter("@is_default", SqlDbType.TinyInt,1),
				new SqlParameter("@add_time", SqlDbType.DateTime)
            };
            parameters[0].Value = model.user_id;
            parameters[1].Value = model.user_name;
            parameters[2].Value = model.accept_name;
            parameters[3].Value = model.area;
            parameters[4].Value = model.address;
            parameters[5].Value = model.mobile;
            parameters[6].Value = model.telphone;
            parameters[7].Value = model.email;
            parameters[8].Value = model.post_code;
            parameters[9].Value = model.is_default;
            parameters[10].Value = model.add_time;
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
            DbHelperSQL.ExecuteSql("update [" + databaseprefix + "dt_user_addr_book] set " + strValue + " where id=" + id);
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">Model.dt_user_addr_book</param>
        /// <returns>True or False</returns>
        public bool Update(Model.dt_user_addr_book model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [" + databaseprefix + "dt_user_addr_book] set ");
            strSql.Append("user_id=@user_id,");
            strSql.Append("user_name=@user_name,");
            strSql.Append("accept_name=@accept_name,");
            strSql.Append("area=@area,");
            strSql.Append("address=@address,");
            strSql.Append("mobile=@mobile,");
            strSql.Append("telphone=@telphone,");
            strSql.Append("email=@email,");
            strSql.Append("post_code=@post_code,");
            strSql.Append("is_default=@is_default,");
            strSql.Append("add_time=@add_time");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                new SqlParameter("@user_id", SqlDbType.Int,4),
                new SqlParameter("@user_name", SqlDbType.NVarChar,100),
                new SqlParameter("@accept_name", SqlDbType.NVarChar,100),
                new SqlParameter("@area", SqlDbType.NVarChar,100),
                new SqlParameter("@address", SqlDbType.NVarChar,500),
                new SqlParameter("@mobile", SqlDbType.NVarChar,20),
                new SqlParameter("@telphone", SqlDbType.NVarChar,30),
                new SqlParameter("@email", SqlDbType.NVarChar,50),
                new SqlParameter("@post_code", SqlDbType.NVarChar,20),
                new SqlParameter("@is_default", SqlDbType.TinyInt,1),
				new SqlParameter("@add_time", SqlDbType.DateTime),
                new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = model.user_id;
            parameters[1].Value = model.user_name;
            parameters[2].Value = model.accept_name;
            parameters[3].Value = model.area;
            parameters[4].Value = model.address;
            parameters[5].Value = model.mobile;
            parameters[6].Value = model.telphone;
            parameters[7].Value = model.email;
            parameters[8].Value = model.post_code;
            parameters[9].Value = model.is_default;
            parameters[10].Value = model.add_time;
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
            int rows = DbHelperSQL.ExecuteSql("delete from [" + databaseprefix + "dt_user_addr_book] where id=@id", parameters);
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
        /// <returns>Model.dt_user_addr_book</returns>
        public Model.dt_user_addr_book GetModel(int id)
        {
            SqlParameter[] parameters = {
            		new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;
            DataSet ds = DbHelperSQL.Query("select " + this.column + " from [" + databaseprefix + "dt_user_addr_book] where id=@id", parameters);
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
            strSql.Append(this.column + " from [" + databaseprefix + "dt_user_addr_book]");
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
            strSql.Append("select * from [" + databaseprefix + "dt_user_addr_book]");
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
        /// <returns>Model.dt_user_addr_book</returns>
        private Model.dt_user_addr_book DataRowToModel(DataRow row)
        {
            Model.dt_user_addr_book model = new Model.dt_user_addr_book();
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
            	if (null != row["user_name"])
            	{
            		model.user_name = row["user_name"].ToString();
            	}
            	if (null != row["accept_name"])
            	{
            		model.accept_name = row["accept_name"].ToString();
            	}
            	if (null != row["area"])
            	{
            		model.area = row["area"].ToString();
            	}
            	if (null != row["address"])
            	{
            		model.address = row["address"].ToString();
            	}
            	if (null != row["mobile"])
            	{
            		model.mobile = row["mobile"].ToString();
            	}
            	if (null != row["telphone"])
            	{
            		model.telphone = row["telphone"].ToString();
            	}
            	if (null != row["email"])
            	{
            		model.email = row["email"].ToString();
            	}
            	if (null != row["post_code"])
            	{
            		model.post_code = row["post_code"].ToString();
            	}
            	if (null != row["is_default"] && "" != row["is_default"].ToString())
            	{
            		model.is_default = int.Parse(row["is_default"].ToString());
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
