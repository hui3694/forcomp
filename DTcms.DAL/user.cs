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
    public partial class user
    {
        private string column;
        private string databaseprefix; 
        public user(string _databaseprefix)
        {
            this.databaseprefix = _databaseprefix;
            this.column = "id,avatar,nickname,openid,unionid,point,img,level,parent_id,phone,email,sex,area,status,reg_time,login_time";
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
            return DbHelperSQL.Exists("select count(1) from [" + databaseprefix + "user] where id=@id", parameters);
        }
        /// <summary>
        /// 返回数据总数
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns>总数</returns>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H from [" + databaseprefix + "user]");
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
        /// <param name="model">Model.user</param>
        /// <returns>ID</returns>
        public int Add(Model.user model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [" + databaseprefix + "user](");
            strSql.Append("avatar,nickname,openid,unionid,point,img,level,parent_id,phone,email,sex,area,status,reg_time,login_time");
            strSql.Append(") values(");
            strSql.Append("@avatar,@nickname,@openid,@unionid,@point,@img,@level,@parent_id,@phone,@email,@sex,@area,@status,@reg_time,@login_time)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                new SqlParameter("@avatar", SqlDbType.VarChar,100),
                new SqlParameter("@nickname", SqlDbType.VarChar,100),
                new SqlParameter("@openid", SqlDbType.VarChar,50),
                new SqlParameter("@unionid", SqlDbType.VarChar,50),
                new SqlParameter("@point", SqlDbType.Int,4),
                new SqlParameter("@img", SqlDbType.VarChar,100),
                new SqlParameter("@level", SqlDbType.Int,4),
                new SqlParameter("@parent_id", SqlDbType.Int,4),
                new SqlParameter("@phone", SqlDbType.VarChar,20),
                new SqlParameter("@email", SqlDbType.VarChar,32),
                new SqlParameter("@sex", SqlDbType.Int,4),
                new SqlParameter("@area", SqlDbType.VarChar,100),
                new SqlParameter("@status", SqlDbType.Int,4),
                new SqlParameter("@reg_time", SqlDbType.DateTime),
				new SqlParameter("@login_time", SqlDbType.DateTime)
            };
            parameters[0].Value = model.avatar;
            parameters[1].Value = model.nickname;
            parameters[2].Value = model.openid;
            parameters[3].Value = model.unionid;
            parameters[4].Value = model.point;
            parameters[5].Value = model.img;
            parameters[6].Value = model.level;
            parameters[7].Value = model.parent_id;
            parameters[8].Value = model.phone;
            parameters[9].Value = model.email;
            parameters[10].Value = model.sex;
            parameters[11].Value = model.area;
            parameters[12].Value = model.status;
            parameters[13].Value = model.reg_time;
            parameters[14].Value = model.login_time;
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
            DbHelperSQL.ExecuteSql("update [" + databaseprefix + "user] set " + strValue + " where id=" + id);
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">Model.user</param>
        /// <returns>True or False</returns>
        public bool Update(Model.user model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [" + databaseprefix + "user] set ");
            strSql.Append("avatar=@avatar,");
            strSql.Append("nickname=@nickname,");
            strSql.Append("openid=@openid,");
            strSql.Append("unionid=@unionid,");
            strSql.Append("point=@point,");
            strSql.Append("img=@img,");
            strSql.Append("level=@level,");
            strSql.Append("parent_id=@parent_id,");
            strSql.Append("phone=@phone,");
            strSql.Append("email=@email,");
            strSql.Append("sex=@sex,");
            strSql.Append("area=@area,");
            strSql.Append("status=@status,");
            strSql.Append("reg_time=@reg_time,");
            strSql.Append("login_time=@login_time");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                new SqlParameter("@avatar", SqlDbType.VarChar,100),
                new SqlParameter("@nickname", SqlDbType.VarChar,100),
                new SqlParameter("@openid", SqlDbType.VarChar,50),
                new SqlParameter("@unionid", SqlDbType.VarChar,50),
                new SqlParameter("@point", SqlDbType.Int,4),
                new SqlParameter("@img", SqlDbType.VarChar,100),
                new SqlParameter("@level", SqlDbType.Int,4),
                new SqlParameter("@parent_id", SqlDbType.Int,4),
                new SqlParameter("@phone", SqlDbType.VarChar,20),
                new SqlParameter("@email", SqlDbType.VarChar,32),
                new SqlParameter("@sex", SqlDbType.Int,4),
                new SqlParameter("@area", SqlDbType.VarChar,100),
                new SqlParameter("@status", SqlDbType.Int,4),
                new SqlParameter("@reg_time", SqlDbType.DateTime),
				new SqlParameter("@login_time", SqlDbType.DateTime),
                new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = model.avatar;
            parameters[1].Value = model.nickname;
            parameters[2].Value = model.openid;
            parameters[3].Value = model.unionid;
            parameters[4].Value = model.point;
            parameters[5].Value = model.img;
            parameters[6].Value = model.level;
            parameters[7].Value = model.parent_id;
            parameters[8].Value = model.phone;
            parameters[9].Value = model.email;
            parameters[10].Value = model.sex;
            parameters[11].Value = model.area;
            parameters[12].Value = model.status;
            parameters[13].Value = model.reg_time;
            parameters[14].Value = model.login_time;
            parameters[15].Value = model.id;
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
            int rows = DbHelperSQL.ExecuteSql("delete from [" + databaseprefix + "user] where id=@id", parameters);
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
        /// <returns>Model.user</returns>
        public Model.user GetModel(int id)
        {
            SqlParameter[] parameters = {
            		new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;
            DataSet ds = DbHelperSQL.Query("select " + this.column + " from [" + databaseprefix + "user] where id=@id", parameters);
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
            strSql.Append(this.column + " from [" + databaseprefix + "user]");
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
            strSql.Append("select * from [" + databaseprefix + "user]");
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
        /// <returns>Model.user</returns>
        private Model.user DataRowToModel(DataRow row)
        {
            Model.user model = new Model.user();
            if (row != null)
            {
            	if (null != row["id"] && "" != row["id"].ToString())
            	{
            		model.id = int.Parse(row["id"].ToString());
            	}
            	if (null != row["avatar"])
            	{
            		model.avatar = row["avatar"].ToString();
            	}
            	if (null != row["nickname"])
            	{
            		model.nickname = row["nickname"].ToString();
            	}
            	if (null != row["openid"])
            	{
            		model.openid = row["openid"].ToString();
            	}
            	if (null != row["unionid"])
            	{
            		model.unionid = row["unionid"].ToString();
            	}
            	if (null != row["point"] && "" != row["point"].ToString())
            	{
            		model.point = int.Parse(row["point"].ToString());
            	}
            	if (null != row["img"])
            	{
            		model.img = row["img"].ToString();
            	}
            	if (null != row["level"] && "" != row["level"].ToString())
            	{
            		model.level = int.Parse(row["level"].ToString());
            	}
            	if (null != row["parent_id"] && "" != row["parent_id"].ToString())
            	{
            		model.parent_id = int.Parse(row["parent_id"].ToString());
            	}
            	if (null != row["phone"])
            	{
            		model.phone = row["phone"].ToString();
            	}
            	if (null != row["email"])
            	{
            		model.email = row["email"].ToString();
            	}
            	if (null != row["sex"] && "" != row["sex"].ToString())
            	{
            		model.sex = int.Parse(row["sex"].ToString());
            	}
            	if (null != row["area"])
            	{
            		model.area = row["area"].ToString();
            	}
            	if (null != row["status"] && "" != row["status"].ToString())
            	{
            		model.status = int.Parse(row["status"].ToString());
            	}
            	if (null != row["reg_time"] && "" != row["reg_time"].ToString())
            	{
            		model.reg_time = DateTime.Parse(row["reg_time"].ToString());
            	}
            	if (null != row["login_time"] && "" != row["login_time"].ToString())
            	{
            		model.login_time = DateTime.Parse(row["login_time"].ToString());
            	}
            }
            return model;
        }
        #endregion
    }
}
