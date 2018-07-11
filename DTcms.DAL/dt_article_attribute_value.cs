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
    public partial class dt_article_attribute_value
    {
        private string column;
        private string databaseprefix; 
        public dt_article_attribute_value(string _databaseprefix)
        {
            this.databaseprefix = _databaseprefix;
            this.column = "article_id,sub_title,source,author,goods_no,stock_quantity,market_price,sell_price,point,video_src,tonglei";
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
            return DbHelperSQL.Exists("select count(1) from [" + databaseprefix + "dt_article_attribute_value] where id=@id", parameters);
        }
        /// <summary>
        /// 返回数据总数
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns>总数</returns>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H from [" + databaseprefix + "dt_article_attribute_value]");
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
        /// <param name="model">Model.dt_article_attribute_value</param>
        /// <returns>ID</returns>
        public int Add(Model.dt_article_attribute_value model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [" + databaseprefix + "dt_article_attribute_value](");
            strSql.Append("article_id,sub_title,source,author,goods_no,stock_quantity,market_price,sell_price,point,video_src,tonglei");
            strSql.Append(") values(");
            strSql.Append("@article_id,@sub_title,@source,@author,@goods_no,@stock_quantity,@market_price,@sell_price,@point,@video_src,@tonglei)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                new SqlParameter("@article_id", SqlDbType.Int,4),
                new SqlParameter("@sub_title", SqlDbType.NVarChar,255),
                new SqlParameter("@source", SqlDbType.NVarChar,100),
                new SqlParameter("@author", SqlDbType.NVarChar,50),
                new SqlParameter("@goods_no", SqlDbType.NVarChar,100),
                new SqlParameter("@stock_quantity", SqlDbType.Int,4),
                new SqlParameter("@market_price", SqlDbType.Decimal,13),
                new SqlParameter("@sell_price", SqlDbType.Decimal,13),
                new SqlParameter("@point", SqlDbType.Int,4),
                new SqlParameter("@video_src", SqlDbType.NVarChar,255),
				new SqlParameter("@tonglei", SqlDbType.NVarChar,200)
            };
            parameters[0].Value = model.article_id;
            parameters[1].Value = model.sub_title;
            parameters[2].Value = model.source;
            parameters[3].Value = model.author;
            parameters[4].Value = model.goods_no;
            parameters[5].Value = model.stock_quantity;
            parameters[6].Value = model.market_price;
            parameters[7].Value = model.sell_price;
            parameters[8].Value = model.point;
            parameters[9].Value = model.video_src;
            parameters[10].Value = model.tonglei;
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
            DbHelperSQL.ExecuteSql("update [" + databaseprefix + "dt_article_attribute_value] set " + strValue + " where id=" + id);
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">Model.dt_article_attribute_value</param>
        /// <returns>True or False</returns>
        public bool Update(Model.dt_article_attribute_value model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [" + databaseprefix + "dt_article_attribute_value] set ");
            strSql.Append("article_id=@article_id,");
            strSql.Append("sub_title=@sub_title,");
            strSql.Append("source=@source,");
            strSql.Append("author=@author,");
            strSql.Append("goods_no=@goods_no,");
            strSql.Append("stock_quantity=@stock_quantity,");
            strSql.Append("market_price=@market_price,");
            strSql.Append("sell_price=@sell_price,");
            strSql.Append("point=@point,");
            strSql.Append("video_src=@video_src,");
            strSql.Append("tonglei=@tonglei");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                new SqlParameter("@article_id", SqlDbType.Int,4),
                new SqlParameter("@sub_title", SqlDbType.NVarChar,255),
                new SqlParameter("@source", SqlDbType.NVarChar,100),
                new SqlParameter("@author", SqlDbType.NVarChar,50),
                new SqlParameter("@goods_no", SqlDbType.NVarChar,100),
                new SqlParameter("@stock_quantity", SqlDbType.Int,4),
                new SqlParameter("@market_price", SqlDbType.Decimal,13),
                new SqlParameter("@sell_price", SqlDbType.Decimal,13),
                new SqlParameter("@point", SqlDbType.Int,4),
                new SqlParameter("@video_src", SqlDbType.NVarChar,255),
				new SqlParameter("@tonglei", SqlDbType.NVarChar,200),
                new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = model.article_id;
            parameters[1].Value = model.sub_title;
            parameters[2].Value = model.source;
            parameters[3].Value = model.author;
            parameters[4].Value = model.goods_no;
            parameters[5].Value = model.stock_quantity;
            parameters[6].Value = model.market_price;
            parameters[7].Value = model.sell_price;
            parameters[8].Value = model.point;
            parameters[9].Value = model.video_src;
            parameters[10].Value = model.tonglei;
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
            int rows = DbHelperSQL.ExecuteSql("delete from [" + databaseprefix + "dt_article_attribute_value] where id=@id", parameters);
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
        /// <returns>Model.dt_article_attribute_value</returns>
        public Model.dt_article_attribute_value GetModel(int id)
        {
            SqlParameter[] parameters = {
            		new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;
            DataSet ds = DbHelperSQL.Query("select " + this.column + " from [" + databaseprefix + "dt_article_attribute_value] where id=@id", parameters);
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
            strSql.Append(this.column + " from [" + databaseprefix + "dt_article_attribute_value]");
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
            strSql.Append("select * from [" + databaseprefix + "dt_article_attribute_value]");
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
        /// <returns>Model.dt_article_attribute_value</returns>
        private Model.dt_article_attribute_value DataRowToModel(DataRow row)
        {
            Model.dt_article_attribute_value model = new Model.dt_article_attribute_value();
            if (row != null)
            {
            	if (null != row["article_id"] && "" != row["article_id"].ToString())
            	{
            		model.article_id = int.Parse(row["article_id"].ToString());
            	}
            	if (null != row["sub_title"])
            	{
            		model.sub_title = row["sub_title"].ToString();
            	}
            	if (null != row["source"])
            	{
            		model.source = row["source"].ToString();
            	}
            	if (null != row["author"])
            	{
            		model.author = row["author"].ToString();
            	}
            	if (null != row["goods_no"])
            	{
            		model.goods_no = row["goods_no"].ToString();
            	}
            	if (null != row["stock_quantity"] && "" != row["stock_quantity"].ToString())
            	{
            		model.stock_quantity = int.Parse(row["stock_quantity"].ToString());
            	}
            	if (null != row["market_price"] && "" != row["market_price"].ToString())
            	{
            		model.market_price = decimal.Parse(row["market_price"].ToString());
            	}
            	if (null != row["sell_price"] && "" != row["sell_price"].ToString())
            	{
            		model.sell_price = decimal.Parse(row["sell_price"].ToString());
            	}
            	if (null != row["point"] && "" != row["point"].ToString())
            	{
            		model.point = int.Parse(row["point"].ToString());
            	}
            	if (null != row["video_src"])
            	{
            		model.video_src = row["video_src"].ToString();
            	}
            	if (null != row["tonglei"])
            	{
            		model.tonglei = row["tonglei"].ToString();
            	}
            }
            return model;
        }
        #endregion
    }
}
