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
    public partial class dt_user_groups
    {
        private string column;
        private string databaseprefix; 
        public dt_user_groups(string _databaseprefix)
        {
            this.databaseprefix = _databaseprefix;
            this.column = "id,title,grade,upgrade_exp,amount,point,discount,is_default,is_upgrade,is_lock,upgrade_price";
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
            return DbHelperSQL.Exists("select count(1) from [" + databaseprefix + "dt_user_groups] where id=@id", parameters);
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
            return DbHelperSQL.Exists("select count(1) from [" + databaseprefix + "dt_user_groups] where title=@title", parameters);
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
            object obj = DbHelperSQL.GetSingle("select title from [" + databaseprefix + "dt_user_groups] where id=@id", parameters);
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
            strSql.Append("select count(*) as H from [" + databaseprefix + "dt_user_groups]");
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
        /// <param name="model">Model.dt_user_groups</param>
        /// <returns>ID</returns>
        public int Add(Model.dt_user_groups model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [" + databaseprefix + "dt_user_groups](");
            strSql.Append("title,grade,upgrade_exp,amount,point,discount,is_default,is_upgrade,is_lock,upgrade_price");
            strSql.Append(") values(");
            strSql.Append("@title,@grade,@upgrade_exp,@amount,@point,@discount,@is_default,@is_upgrade,@is_lock,@upgrade_price)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                new SqlParameter("@title", SqlDbType.NVarChar,100),
                new SqlParameter("@grade", SqlDbType.Int,4),
                new SqlParameter("@upgrade_exp", SqlDbType.Int,4),
                new SqlParameter("@amount", SqlDbType.Decimal,13),
                new SqlParameter("@point", SqlDbType.Int,4),
                new SqlParameter("@discount", SqlDbType.Int,4),
                new SqlParameter("@is_default", SqlDbType.TinyInt,1),
                new SqlParameter("@is_upgrade", SqlDbType.TinyInt,1),
                new SqlParameter("@is_lock", SqlDbType.TinyInt,1),
				new SqlParameter("@upgrade_price", SqlDbType.Decimal,13)
            };
            parameters[0].Value = model.title;
            parameters[1].Value = model.grade;
            parameters[2].Value = model.upgrade_exp;
            parameters[3].Value = model.amount;
            parameters[4].Value = model.point;
            parameters[5].Value = model.discount;
            parameters[6].Value = model.is_default;
            parameters[7].Value = model.is_upgrade;
            parameters[8].Value = model.is_lock;
            parameters[9].Value = model.upgrade_price;
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
            DbHelperSQL.ExecuteSql("update [" + databaseprefix + "dt_user_groups] set " + strValue + " where id=" + id);
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">Model.dt_user_groups</param>
        /// <returns>True or False</returns>
        public bool Update(Model.dt_user_groups model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [" + databaseprefix + "dt_user_groups] set ");
            strSql.Append("title=@title,");
            strSql.Append("grade=@grade,");
            strSql.Append("upgrade_exp=@upgrade_exp,");
            strSql.Append("amount=@amount,");
            strSql.Append("point=@point,");
            strSql.Append("discount=@discount,");
            strSql.Append("is_default=@is_default,");
            strSql.Append("is_upgrade=@is_upgrade,");
            strSql.Append("is_lock=@is_lock,");
            strSql.Append("upgrade_price=@upgrade_price");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                new SqlParameter("@title", SqlDbType.NVarChar,100),
                new SqlParameter("@grade", SqlDbType.Int,4),
                new SqlParameter("@upgrade_exp", SqlDbType.Int,4),
                new SqlParameter("@amount", SqlDbType.Decimal,13),
                new SqlParameter("@point", SqlDbType.Int,4),
                new SqlParameter("@discount", SqlDbType.Int,4),
                new SqlParameter("@is_default", SqlDbType.TinyInt,1),
                new SqlParameter("@is_upgrade", SqlDbType.TinyInt,1),
                new SqlParameter("@is_lock", SqlDbType.TinyInt,1),
				new SqlParameter("@upgrade_price", SqlDbType.Decimal,13),
                new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = model.title;
            parameters[1].Value = model.grade;
            parameters[2].Value = model.upgrade_exp;
            parameters[3].Value = model.amount;
            parameters[4].Value = model.point;
            parameters[5].Value = model.discount;
            parameters[6].Value = model.is_default;
            parameters[7].Value = model.is_upgrade;
            parameters[8].Value = model.is_lock;
            parameters[9].Value = model.upgrade_price;
            parameters[10].Value = model.id;
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
            int rows = DbHelperSQL.ExecuteSql("delete from [" + databaseprefix + "dt_user_groups] where id=@id", parameters);
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
        /// <returns>Model.dt_user_groups</returns>
        public Model.dt_user_groups GetModel(int id)
        {
            SqlParameter[] parameters = {
            		new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;
            DataSet ds = DbHelperSQL.Query("select " + this.column + " from [" + databaseprefix + "dt_user_groups] where id=@id", parameters);
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
            strSql.Append(this.column + " from [" + databaseprefix + "dt_user_groups]");
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
            strSql.Append("select * from [" + databaseprefix + "dt_user_groups]");
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
        /// <returns>Model.dt_user_groups</returns>
        private Model.dt_user_groups DataRowToModel(DataRow row)
        {
            Model.dt_user_groups model = new Model.dt_user_groups();
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
            	if (null != row["grade"] && "" != row["grade"].ToString())
            	{
            		model.grade = int.Parse(row["grade"].ToString());
            	}
            	if (null != row["upgrade_exp"] && "" != row["upgrade_exp"].ToString())
            	{
            		model.upgrade_exp = int.Parse(row["upgrade_exp"].ToString());
            	}
            	if (null != row["amount"] && "" != row["amount"].ToString())
            	{
            		model.amount = decimal.Parse(row["amount"].ToString());
            	}
            	if (null != row["point"] && "" != row["point"].ToString())
            	{
            		model.point = int.Parse(row["point"].ToString());
            	}
            	if (null != row["discount"] && "" != row["discount"].ToString())
            	{
            		model.discount = int.Parse(row["discount"].ToString());
            	}
            	if (null != row["is_default"] && "" != row["is_default"].ToString())
            	{
            		model.is_default = int.Parse(row["is_default"].ToString());
            	}
            	if (null != row["is_upgrade"] && "" != row["is_upgrade"].ToString())
            	{
            		model.is_upgrade = int.Parse(row["is_upgrade"].ToString());
            	}
            	if (null != row["is_lock"] && "" != row["is_lock"].ToString())
            	{
            		model.is_lock = int.Parse(row["is_lock"].ToString());
            	}
            	if (null != row["upgrade_price"] && "" != row["upgrade_price"].ToString())
            	{
            		model.upgrade_price = decimal.Parse(row["upgrade_price"].ToString());
            	}
            }
            return model;
        }
        #endregion
    }
}
