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
    public partial class dt_users
    {
        private string column;
        private string databaseprefix; 
        public dt_users(string _databaseprefix)
        {
            this.databaseprefix = _databaseprefix;
            this.column = "id,group_id,user_name,salt,password,mobile,email,avatar,nick_name,sex,birthday,telphone,area,address,qq,msn,amount,point,exp,status,reg_time,reg_ip,site_id";
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
            return DbHelperSQL.Exists("select count(1) from [" + databaseprefix + "dt_users] where id=@id", parameters);
        }
        /// <summary>
        /// 返回数据总数
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns>总数</returns>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H from [" + databaseprefix + "dt_users]");
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
        /// <param name="model">Model.dt_users</param>
        /// <returns>ID</returns>
        public int Add(Model.dt_users model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [" + databaseprefix + "dt_users](");
            strSql.Append("group_id,user_name,salt,password,mobile,email,avatar,nick_name,sex,birthday,telphone,area,address,qq,msn,amount,point,exp,status,reg_time,reg_ip,site_id");
            strSql.Append(") values(");
            strSql.Append("@group_id,@user_name,@salt,@password,@mobile,@email,@avatar,@nick_name,@sex,@birthday,@telphone,@area,@address,@qq,@msn,@amount,@point,@exp,@status,@reg_time,@reg_ip,@site_id)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                new SqlParameter("@group_id", SqlDbType.Int,4),
                new SqlParameter("@user_name", SqlDbType.NVarChar,100),
                new SqlParameter("@salt", SqlDbType.NVarChar,20),
                new SqlParameter("@password", SqlDbType.NVarChar,100),
                new SqlParameter("@mobile", SqlDbType.NVarChar,20),
                new SqlParameter("@email", SqlDbType.NVarChar,50),
                new SqlParameter("@avatar", SqlDbType.NVarChar,255),
                new SqlParameter("@nick_name", SqlDbType.NVarChar,100),
                new SqlParameter("@sex", SqlDbType.NVarChar,20),
                new SqlParameter("@birthday", SqlDbType.DateTime),
                new SqlParameter("@telphone", SqlDbType.NVarChar,50),
                new SqlParameter("@area", SqlDbType.NVarChar,255),
                new SqlParameter("@address", SqlDbType.NVarChar,255),
                new SqlParameter("@qq", SqlDbType.NVarChar,20),
                new SqlParameter("@msn", SqlDbType.NVarChar,100),
                new SqlParameter("@amount", SqlDbType.Decimal,13),
                new SqlParameter("@point", SqlDbType.Int,4),
                new SqlParameter("@exp", SqlDbType.Int,4),
                new SqlParameter("@status", SqlDbType.TinyInt,1),
                new SqlParameter("@reg_time", SqlDbType.DateTime),
                new SqlParameter("@reg_ip", SqlDbType.NVarChar,20),
				new SqlParameter("@site_id", SqlDbType.Int,4)
            };
            parameters[0].Value = model.group_id;
            parameters[1].Value = model.user_name;
            parameters[2].Value = model.salt;
            parameters[3].Value = model.password;
            parameters[4].Value = model.mobile;
            parameters[5].Value = model.email;
            parameters[6].Value = model.avatar;
            parameters[7].Value = model.nick_name;
            parameters[8].Value = model.sex;
            parameters[9].Value = model.birthday;
            parameters[10].Value = model.telphone;
            parameters[11].Value = model.area;
            parameters[12].Value = model.address;
            parameters[13].Value = model.qq;
            parameters[14].Value = model.msn;
            parameters[15].Value = model.amount;
            parameters[16].Value = model.point;
            parameters[17].Value = model.exp;
            parameters[18].Value = model.status;
            parameters[19].Value = model.reg_time;
            parameters[20].Value = model.reg_ip;
            parameters[21].Value = model.site_id;
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
            DbHelperSQL.ExecuteSql("update [" + databaseprefix + "dt_users] set " + strValue + " where id=" + id);
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">Model.dt_users</param>
        /// <returns>True or False</returns>
        public bool Update(Model.dt_users model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [" + databaseprefix + "dt_users] set ");
            strSql.Append("group_id=@group_id,");
            strSql.Append("user_name=@user_name,");
            strSql.Append("salt=@salt,");
            strSql.Append("password=@password,");
            strSql.Append("mobile=@mobile,");
            strSql.Append("email=@email,");
            strSql.Append("avatar=@avatar,");
            strSql.Append("nick_name=@nick_name,");
            strSql.Append("sex=@sex,");
            strSql.Append("birthday=@birthday,");
            strSql.Append("telphone=@telphone,");
            strSql.Append("area=@area,");
            strSql.Append("address=@address,");
            strSql.Append("qq=@qq,");
            strSql.Append("msn=@msn,");
            strSql.Append("amount=@amount,");
            strSql.Append("point=@point,");
            strSql.Append("exp=@exp,");
            strSql.Append("status=@status,");
            strSql.Append("reg_time=@reg_time,");
            strSql.Append("reg_ip=@reg_ip,");
            strSql.Append("site_id=@site_id");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                new SqlParameter("@group_id", SqlDbType.Int,4),
                new SqlParameter("@user_name", SqlDbType.NVarChar,100),
                new SqlParameter("@salt", SqlDbType.NVarChar,20),
                new SqlParameter("@password", SqlDbType.NVarChar,100),
                new SqlParameter("@mobile", SqlDbType.NVarChar,20),
                new SqlParameter("@email", SqlDbType.NVarChar,50),
                new SqlParameter("@avatar", SqlDbType.NVarChar,255),
                new SqlParameter("@nick_name", SqlDbType.NVarChar,100),
                new SqlParameter("@sex", SqlDbType.NVarChar,20),
                new SqlParameter("@birthday", SqlDbType.DateTime),
                new SqlParameter("@telphone", SqlDbType.NVarChar,50),
                new SqlParameter("@area", SqlDbType.NVarChar,255),
                new SqlParameter("@address", SqlDbType.NVarChar,255),
                new SqlParameter("@qq", SqlDbType.NVarChar,20),
                new SqlParameter("@msn", SqlDbType.NVarChar,100),
                new SqlParameter("@amount", SqlDbType.Decimal,13),
                new SqlParameter("@point", SqlDbType.Int,4),
                new SqlParameter("@exp", SqlDbType.Int,4),
                new SqlParameter("@status", SqlDbType.TinyInt,1),
                new SqlParameter("@reg_time", SqlDbType.DateTime),
                new SqlParameter("@reg_ip", SqlDbType.NVarChar,20),
				new SqlParameter("@site_id", SqlDbType.Int,4),
                new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = model.group_id;
            parameters[1].Value = model.user_name;
            parameters[2].Value = model.salt;
            parameters[3].Value = model.password;
            parameters[4].Value = model.mobile;
            parameters[5].Value = model.email;
            parameters[6].Value = model.avatar;
            parameters[7].Value = model.nick_name;
            parameters[8].Value = model.sex;
            parameters[9].Value = model.birthday;
            parameters[10].Value = model.telphone;
            parameters[11].Value = model.area;
            parameters[12].Value = model.address;
            parameters[13].Value = model.qq;
            parameters[14].Value = model.msn;
            parameters[15].Value = model.amount;
            parameters[16].Value = model.point;
            parameters[17].Value = model.exp;
            parameters[18].Value = model.status;
            parameters[19].Value = model.reg_time;
            parameters[20].Value = model.reg_ip;
            parameters[21].Value = model.site_id;
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
            int rows = DbHelperSQL.ExecuteSql("delete from [" + databaseprefix + "dt_users] where id=@id", parameters);
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
        /// <returns>Model.dt_users</returns>
        public Model.dt_users GetModel(int id)
        {
            SqlParameter[] parameters = {
            		new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;
            DataSet ds = DbHelperSQL.Query("select " + this.column + " from [" + databaseprefix + "dt_users] where id=@id", parameters);
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
            strSql.Append(this.column + " from [" + databaseprefix + "dt_users]");
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
            strSql.Append("select * from [" + databaseprefix + "dt_users]");
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
        /// <returns>Model.dt_users</returns>
        private Model.dt_users DataRowToModel(DataRow row)
        {
            Model.dt_users model = new Model.dt_users();
            if (row != null)
            {
            	if (null != row["id"] && "" != row["id"].ToString())
            	{
            		model.id = int.Parse(row["id"].ToString());
            	}
            	if (null != row["group_id"] && "" != row["group_id"].ToString())
            	{
            		model.group_id = int.Parse(row["group_id"].ToString());
            	}
            	if (null != row["user_name"])
            	{
            		model.user_name = row["user_name"].ToString();
            	}
            	if (null != row["salt"])
            	{
            		model.salt = row["salt"].ToString();
            	}
            	if (null != row["password"])
            	{
            		model.password = row["password"].ToString();
            	}
            	if (null != row["mobile"])
            	{
            		model.mobile = row["mobile"].ToString();
            	}
            	if (null != row["email"])
            	{
            		model.email = row["email"].ToString();
            	}
            	if (null != row["avatar"])
            	{
            		model.avatar = row["avatar"].ToString();
            	}
            	if (null != row["nick_name"])
            	{
            		model.nick_name = row["nick_name"].ToString();
            	}
            	if (null != row["sex"])
            	{
            		model.sex = row["sex"].ToString();
            	}
            	if (null != row["birthday"] && "" != row["birthday"].ToString())
            	{
            		model.birthday = DateTime.Parse(row["birthday"].ToString());
            	}
            	if (null != row["telphone"])
            	{
            		model.telphone = row["telphone"].ToString();
            	}
            	if (null != row["area"])
            	{
            		model.area = row["area"].ToString();
            	}
            	if (null != row["address"])
            	{
            		model.address = row["address"].ToString();
            	}
            	if (null != row["qq"])
            	{
            		model.qq = row["qq"].ToString();
            	}
            	if (null != row["msn"])
            	{
            		model.msn = row["msn"].ToString();
            	}
            	if (null != row["amount"] && "" != row["amount"].ToString())
            	{
            		model.amount = decimal.Parse(row["amount"].ToString());
            	}
            	if (null != row["point"] && "" != row["point"].ToString())
            	{
            		model.point = int.Parse(row["point"].ToString());
            	}
            	if (null != row["exp"] && "" != row["exp"].ToString())
            	{
            		model.exp = int.Parse(row["exp"].ToString());
            	}
            	if (null != row["status"] && "" != row["status"].ToString())
            	{
            		model.status = int.Parse(row["status"].ToString());
            	}
            	if (null != row["reg_time"] && "" != row["reg_time"].ToString())
            	{
            		model.reg_time = DateTime.Parse(row["reg_time"].ToString());
            	}
            	if (null != row["reg_ip"])
            	{
            		model.reg_ip = row["reg_ip"].ToString();
            	}
            	if (null != row["site_id"] && "" != row["site_id"].ToString())
            	{
            		model.site_id = int.Parse(row["site_id"].ToString());
            	}
            }
            return model;
        }
        #endregion
    }
}
