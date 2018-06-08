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
    public partial class news
    {
        private string column;
        private string databaseprefix; 
        public news(string _databaseprefix)
        {
            this.databaseprefix = _databaseprefix;
            this.column = "id,title,zhaiyao,cont,img,sort,click,is_msg,is_hide,time";
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
            return DbHelperSQL.Exists("select count(1) from [" + databaseprefix + "news] where id=@id", parameters);
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
            return DbHelperSQL.Exists("select count(1) from [" + databaseprefix + "news] where title=@title", parameters);
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
            object obj = DbHelperSQL.GetSingle("select title from [" + databaseprefix + "news] where id=@id", parameters);
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
            strSql.Append("select count(*) as H from [" + databaseprefix + "news]");
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
        /// <param name="model">Model.news</param>
        /// <returns>ID</returns>
        public int Add(Model.news model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [" + databaseprefix + "news](");
            strSql.Append("title,zhaiyao,cont,img,sort,click,is_msg,is_hide,time");
            strSql.Append(") values(");
            strSql.Append("@title,@zhaiyao,@cont,@img,@sort,@click,@is_msg,@is_hide,@time)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                new SqlParameter("@title", SqlDbType.VarChar,100),
                new SqlParameter("@zhaiyao", SqlDbType.VarChar,255),
                new SqlParameter("@cont", SqlDbType.NText),
                new SqlParameter("@img", SqlDbType.VarChar,255),
                new SqlParameter("@sort", SqlDbType.Int,4),
                new SqlParameter("@click", SqlDbType.Int,4),
                new SqlParameter("@is_msg", SqlDbType.TinyInt,1),
                new SqlParameter("@is_hide", SqlDbType.TinyInt,1),
				new SqlParameter("@time", SqlDbType.DateTime)
            };
            parameters[0].Value = model.title;
            parameters[1].Value = model.zhaiyao;
            parameters[2].Value = model.cont;
            parameters[3].Value = model.img;
            parameters[4].Value = model.sort;
            parameters[5].Value = model.click;
            parameters[6].Value = model.is_msg;
            parameters[7].Value = model.is_hide;
            parameters[8].Value = model.time;
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
            DbHelperSQL.ExecuteSql("update [" + databaseprefix + "news] set " + strValue + " where id=" + id);
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">Model.news</param>
        /// <returns>True or False</returns>
        public bool Update(Model.news model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [" + databaseprefix + "news] set ");
            strSql.Append("title=@title,");
            strSql.Append("zhaiyao=@zhaiyao,");
            strSql.Append("cont=@cont,");
            strSql.Append("img=@img,");
            strSql.Append("sort=@sort,");
            strSql.Append("click=@click,");
            strSql.Append("is_msg=@is_msg,");
            strSql.Append("is_hide=@is_hide,");
            strSql.Append("time=@time");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                new SqlParameter("@title", SqlDbType.VarChar,100),
                new SqlParameter("@zhaiyao", SqlDbType.VarChar,255),
                new SqlParameter("@cont", SqlDbType.NText),
                new SqlParameter("@img", SqlDbType.VarChar,255),
                new SqlParameter("@sort", SqlDbType.Int,4),
                new SqlParameter("@click", SqlDbType.Int,4),
                new SqlParameter("@is_msg", SqlDbType.TinyInt,1),
                new SqlParameter("@is_hide", SqlDbType.TinyInt,1),
				new SqlParameter("@time", SqlDbType.DateTime),
                new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = model.title;
            parameters[1].Value = model.zhaiyao;
            parameters[2].Value = model.cont;
            parameters[3].Value = model.img;
            parameters[4].Value = model.sort;
            parameters[5].Value = model.click;
            parameters[6].Value = model.is_msg;
            parameters[7].Value = model.is_hide;
            parameters[8].Value = model.time;
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
            int rows = DbHelperSQL.ExecuteSql("delete from [" + databaseprefix + "news] where id=@id", parameters);
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
        /// <returns>Model.news</returns>
        public Model.news GetModel(int id)
        {
            SqlParameter[] parameters = {
            		new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;
            DataSet ds = DbHelperSQL.Query("select " + this.column + " from [" + databaseprefix + "news] where id=@id", parameters);
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
            strSql.Append(this.column + " from [" + databaseprefix + "news]");
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
            strSql.Append("select * from [" + databaseprefix + "news]");
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
        /// <returns>Model.news</returns>
        private Model.news DataRowToModel(DataRow row)
        {
            Model.news model = new Model.news();
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
            	if (null != row["zhaiyao"])
            	{
            		model.zhaiyao = row["zhaiyao"].ToString();
            	}
            	if (null != row["cont"])
            	{
            		model.cont = row["cont"].ToString();
            	}
            	if (null != row["img"])
            	{
            		model.img = row["img"].ToString();
            	}
            	if (null != row["sort"] && "" != row["sort"].ToString())
            	{
            		model.sort = int.Parse(row["sort"].ToString());
            	}
            	if (null != row["click"] && "" != row["click"].ToString())
            	{
            		model.click = int.Parse(row["click"].ToString());
            	}
            	if (null != row["is_msg"] && "" != row["is_msg"].ToString())
            	{
            		model.is_msg = int.Parse(row["is_msg"].ToString());
            	}
            	if (null != row["is_hide"] && "" != row["is_hide"].ToString())
            	{
            		model.is_hide = int.Parse(row["is_hide"].ToString());
            	}
            	if (null != row["time"] && "" != row["time"].ToString())
            	{
            		model.time = DateTime.Parse(row["time"].ToString());
            	}
            }
            return model;
        }
        #endregion
    }
}
