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
    public partial class dt_weixin_response_content
    {
        private string column;
        private string databaseprefix; 
        public dt_weixin_response_content(string _databaseprefix)
        {
            this.databaseprefix = _databaseprefix;
            this.column = "id,account_id,openid,request_type,request_content,response_type,reponse_content,create_time,xml_content,add_time";
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
            return DbHelperSQL.Exists("select count(1) from [" + databaseprefix + "dt_weixin_response_content] where id=@id", parameters);
        }
        /// <summary>
        /// 返回数据总数
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns>总数</returns>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H from [" + databaseprefix + "dt_weixin_response_content]");
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
        /// <param name="model">Model.dt_weixin_response_content</param>
        /// <returns>ID</returns>
        public int Add(Model.dt_weixin_response_content model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [" + databaseprefix + "dt_weixin_response_content](");
            strSql.Append("account_id,openid,request_type,request_content,response_type,reponse_content,create_time,xml_content,add_time");
            strSql.Append(") values(");
            strSql.Append("@account_id,@openid,@request_type,@request_content,@response_type,@reponse_content,@create_time,@xml_content,@add_time)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                new SqlParameter("@account_id", SqlDbType.Int,4),
                new SqlParameter("@openid", SqlDbType.NVarChar,100),
                new SqlParameter("@request_type", SqlDbType.NVarChar,50),
                new SqlParameter("@request_content", SqlDbType.NVarChar,2000),
                new SqlParameter("@response_type", SqlDbType.NVarChar,50),
                new SqlParameter("@reponse_content", SqlDbType.NVarChar,2000),
                new SqlParameter("@create_time", SqlDbType.NVarChar,50),
                new SqlParameter("@xml_content", SqlDbType.NVarChar,2000),
				new SqlParameter("@add_time", SqlDbType.DateTime)
            };
            parameters[0].Value = model.account_id;
            parameters[1].Value = model.openid;
            parameters[2].Value = model.request_type;
            parameters[3].Value = model.request_content;
            parameters[4].Value = model.response_type;
            parameters[5].Value = model.reponse_content;
            parameters[6].Value = model.create_time;
            parameters[7].Value = model.xml_content;
            parameters[8].Value = model.add_time;
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
            DbHelperSQL.ExecuteSql("update [" + databaseprefix + "dt_weixin_response_content] set " + strValue + " where id=" + id);
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">Model.dt_weixin_response_content</param>
        /// <returns>True or False</returns>
        public bool Update(Model.dt_weixin_response_content model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [" + databaseprefix + "dt_weixin_response_content] set ");
            strSql.Append("account_id=@account_id,");
            strSql.Append("openid=@openid,");
            strSql.Append("request_type=@request_type,");
            strSql.Append("request_content=@request_content,");
            strSql.Append("response_type=@response_type,");
            strSql.Append("reponse_content=@reponse_content,");
            strSql.Append("create_time=@create_time,");
            strSql.Append("xml_content=@xml_content,");
            strSql.Append("add_time=@add_time");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                new SqlParameter("@account_id", SqlDbType.Int,4),
                new SqlParameter("@openid", SqlDbType.NVarChar,100),
                new SqlParameter("@request_type", SqlDbType.NVarChar,50),
                new SqlParameter("@request_content", SqlDbType.NVarChar,2000),
                new SqlParameter("@response_type", SqlDbType.NVarChar,50),
                new SqlParameter("@reponse_content", SqlDbType.NVarChar,2000),
                new SqlParameter("@create_time", SqlDbType.NVarChar,50),
                new SqlParameter("@xml_content", SqlDbType.NVarChar,2000),
				new SqlParameter("@add_time", SqlDbType.DateTime),
                new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = model.account_id;
            parameters[1].Value = model.openid;
            parameters[2].Value = model.request_type;
            parameters[3].Value = model.request_content;
            parameters[4].Value = model.response_type;
            parameters[5].Value = model.reponse_content;
            parameters[6].Value = model.create_time;
            parameters[7].Value = model.xml_content;
            parameters[8].Value = model.add_time;
            parameters[9].Value = model.id;
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
            int rows = DbHelperSQL.ExecuteSql("delete from [" + databaseprefix + "dt_weixin_response_content] where id=@id", parameters);
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
        /// <returns>Model.dt_weixin_response_content</returns>
        public Model.dt_weixin_response_content GetModel(int id)
        {
            SqlParameter[] parameters = {
            		new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;
            DataSet ds = DbHelperSQL.Query("select " + this.column + " from [" + databaseprefix + "dt_weixin_response_content] where id=@id", parameters);
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
            strSql.Append(this.column + " from [" + databaseprefix + "dt_weixin_response_content]");
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
            strSql.Append("select * from [" + databaseprefix + "dt_weixin_response_content]");
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
        /// <returns>Model.dt_weixin_response_content</returns>
        private Model.dt_weixin_response_content DataRowToModel(DataRow row)
        {
            Model.dt_weixin_response_content model = new Model.dt_weixin_response_content();
            if (row != null)
            {
            	if (null != row["id"] && "" != row["id"].ToString())
            	{
            		model.id = int.Parse(row["id"].ToString());
            	}
            	if (null != row["account_id"] && "" != row["account_id"].ToString())
            	{
            		model.account_id = int.Parse(row["account_id"].ToString());
            	}
            	if (null != row["openid"])
            	{
            		model.openid = row["openid"].ToString();
            	}
            	if (null != row["request_type"])
            	{
            		model.request_type = row["request_type"].ToString();
            	}
            	if (null != row["request_content"])
            	{
            		model.request_content = row["request_content"].ToString();
            	}
            	if (null != row["response_type"])
            	{
            		model.response_type = row["response_type"].ToString();
            	}
            	if (null != row["reponse_content"])
            	{
            		model.reponse_content = row["reponse_content"].ToString();
            	}
            	if (null != row["create_time"])
            	{
            		model.create_time = row["create_time"].ToString();
            	}
            	if (null != row["xml_content"])
            	{
            		model.xml_content = row["xml_content"].ToString();
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
