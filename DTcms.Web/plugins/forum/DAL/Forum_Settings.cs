using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using DTcms.DBUtility;
using DTcms.Common;
namespace DTcms.Web.Plugin.Forum.DAL
{
    //dt_Forum_Settings
        //------------------------------------------------------
    // 插件官方地址 www.dtcms-forum.net
    // 本插件开源，支持个人对插件源码修改及非盈利性平台使用
    // 如用于商业盈利性平台，需支付授权费,具体参见官网
    // 我们承接新项目开发或插件二次开发 QQ 271478027
    //------------------------------------------------------
    public partial class Forum_Settings
    {
        private string databaseprefix; //数据库表名前缀
        private string column;
        public Forum_Settings(string _databaseprefix)
        {
            databaseprefix = _databaseprefix;
            this.column = " Variable, Value, Title, [Group], Description, SortId  ";
        }
        #region 基本方法================================
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string Variable)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "Forum_Settings");
            strSql.Append(" where ");
            strSql.Append(" Variable = @Variable  ");
            SqlParameter[] parameters = {
					new SqlParameter("@Variable", SqlDbType.NVarChar,128)			};
            parameters[0].Value = Variable;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 返回数据总数
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H ");
            strSql.Append(" from " + databaseprefix + "Forum_Settings");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Model.Forum_Settings model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + databaseprefix + "Forum_Settings(");
            strSql.Append("Variable,Value,Title,[Group],Description,SortId");
            strSql.Append(") values (");
            strSql.Append("@Variable,@Value,@Title,@Group,@Description,@SortId");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Variable", SqlDbType.NVarChar,128) ,            
                        new SqlParameter("@Value", SqlDbType.NText) ,            
                        new SqlParameter("@Title", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@Group", SqlDbType.Int,4) ,            
                        new SqlParameter("@Description", SqlDbType.NVarChar,255) ,            
                        new SqlParameter("@SortId", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = model.Variable;
            parameters[1].Value = model.Value;
            parameters[2].Value = model.Title;
            parameters[3].Value = model.Group;
            parameters[4].Value = model.Description;
            parameters[5].Value = model.SortId;


            int bol = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

            if (bol != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.Forum_Settings model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "Forum_Settings set ");

            strSql.Append(" Variable = @Variable , ");
            strSql.Append(" Value = @Value , ");
            strSql.Append(" Title = @Title , ");
            strSql.Append(" [Group] = @Group , ");
            strSql.Append(" Description = @Description , ");
            strSql.Append(" SortId = @SortId  ");
            strSql.Append(" where Variable=@VariableOld  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Variable", SqlDbType.NVarChar,128) ,            
                        new SqlParameter("@Value", SqlDbType.NText) ,            
                        new SqlParameter("@Title", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@Group", SqlDbType.Int,4) ,            
                        new SqlParameter("@Description", SqlDbType.NVarChar,255) ,            
                        new SqlParameter("@SortId", SqlDbType.Int,4)  ,
                        new SqlParameter("@VariableOld", SqlDbType.NVarChar,128) 
              
            };

            parameters[0].Value = model.Variable;
            parameters[1].Value = model.Value;
            parameters[2].Value = model.Title;
            parameters[3].Value = model.Group;
            parameters[4].Value = model.Description;
            parameters[5].Value = model.SortId;
            parameters[6].Value = model.VariableOld;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public bool UpdateField(string Variable, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "Forum_Settings set " + strValue);
            strSql.Append(" where Variable=@Variable ");
            SqlParameter[] parameters = {
					new SqlParameter("@Variable", SqlDbType.NVarChar,128)			};
            parameters[0].Value = Variable;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string Variable)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "Forum_Settings ");
            strSql.Append(" where Variable=@Variable ");
            SqlParameter[] parameters = {
					new SqlParameter("@Variable", SqlDbType.NVarChar,128)			};
            parameters[0].Value = Variable;


            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.Forum_Settings GetModel(string Variable)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select " + column);
            strSql.Append("  from " + databaseprefix + "Forum_Settings ");
            strSql.Append(" where Variable=@Variable ");
            SqlParameter[] parameters = {
					new SqlParameter("@Variable", SqlDbType.NVarChar,128)			};
            parameters[0].Value = Variable;


            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

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
        /// 得到一个对象实体
        /// </summary>				
        public Model.Forum_Settings DataRowToModel(DataRow row)
        {

            if (row != null)
            {
                Model.Forum_Settings model = new Model.Forum_Settings();

                model.Variable = row["Variable"].ToString();
                model.Value = row["Value"].ToString();
                model.Title = row["Title"].ToString();
                if (row["Group"].ToString() != "")
                {
                    model.Group = int.Parse(row["Group"].ToString());
                }
                model.Description = row["Description"].ToString();
                if (row["SortId"].ToString() != "")
                {
                    model.SortId = int.Parse(row["SortId"].ToString());
                }

                return model;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        ///  
        /// </summary>				
        public void DataRowToRow(DataRow row, DataRow[] dr, int i)
        {



            row["Variable"] = dr[i]["Variable"].ToString();
            row["Value"] = dr[i]["Value"].ToString();
            row["Title"] = dr[i]["Title"].ToString();

            row["Group"] = int.Parse(dr[i]["Group"].ToString());
            row["Description"] = dr[i]["Description"].ToString();

            row["SortId"] = int.Parse(dr[i]["SortId"].ToString());


        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM " + databaseprefix + "Forum_Settings ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM " + databaseprefix + "Forum_Settings ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM " + databaseprefix + "Forum_Settings ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
        #endregion

    }
}

