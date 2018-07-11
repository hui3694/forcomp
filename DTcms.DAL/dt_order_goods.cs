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
    public partial class dt_order_goods
    {
        private string column;
        private string databaseprefix; 
        public dt_order_goods(string _databaseprefix)
        {
            this.databaseprefix = _databaseprefix;
            this.column = "id,article_id,order_id,goods_id,goods_no,goods_title,img_url,spec_text,goods_price,real_price,quantity,point";
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
            return DbHelperSQL.Exists("select count(1) from [" + databaseprefix + "dt_order_goods] where id=@id", parameters);
        }
        /// <summary>
        /// 返回数据总数
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns>总数</returns>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H from [" + databaseprefix + "dt_order_goods]");
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
        /// <param name="model">Model.dt_order_goods</param>
        /// <returns>ID</returns>
        public int Add(Model.dt_order_goods model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [" + databaseprefix + "dt_order_goods](");
            strSql.Append("article_id,order_id,goods_id,goods_no,goods_title,img_url,spec_text,goods_price,real_price,quantity,point");
            strSql.Append(") values(");
            strSql.Append("@article_id,@order_id,@goods_id,@goods_no,@goods_title,@img_url,@spec_text,@goods_price,@real_price,@quantity,@point)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                new SqlParameter("@article_id", SqlDbType.Int,4),
                new SqlParameter("@order_id", SqlDbType.Int,4),
                new SqlParameter("@goods_id", SqlDbType.Int,4),
                new SqlParameter("@goods_no", SqlDbType.NVarChar,50),
                new SqlParameter("@goods_title", SqlDbType.NVarChar,100),
                new SqlParameter("@img_url", SqlDbType.NVarChar,255),
                new SqlParameter("@spec_text", SqlDbType.Text),
                new SqlParameter("@goods_price", SqlDbType.Decimal,13),
                new SqlParameter("@real_price", SqlDbType.Decimal,13),
                new SqlParameter("@quantity", SqlDbType.Int,4),
				new SqlParameter("@point", SqlDbType.Int,4)
            };
            parameters[0].Value = model.article_id;
            parameters[1].Value = model.order_id;
            parameters[2].Value = model.goods_id;
            parameters[3].Value = model.goods_no;
            parameters[4].Value = model.goods_title;
            parameters[5].Value = model.img_url;
            parameters[6].Value = model.spec_text;
            parameters[7].Value = model.goods_price;
            parameters[8].Value = model.real_price;
            parameters[9].Value = model.quantity;
            parameters[10].Value = model.point;
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
            DbHelperSQL.ExecuteSql("update [" + databaseprefix + "dt_order_goods] set " + strValue + " where id=" + id);
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">Model.dt_order_goods</param>
        /// <returns>True or False</returns>
        public bool Update(Model.dt_order_goods model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [" + databaseprefix + "dt_order_goods] set ");
            strSql.Append("article_id=@article_id,");
            strSql.Append("order_id=@order_id,");
            strSql.Append("goods_id=@goods_id,");
            strSql.Append("goods_no=@goods_no,");
            strSql.Append("goods_title=@goods_title,");
            strSql.Append("img_url=@img_url,");
            strSql.Append("spec_text=@spec_text,");
            strSql.Append("goods_price=@goods_price,");
            strSql.Append("real_price=@real_price,");
            strSql.Append("quantity=@quantity,");
            strSql.Append("point=@point");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                new SqlParameter("@article_id", SqlDbType.Int,4),
                new SqlParameter("@order_id", SqlDbType.Int,4),
                new SqlParameter("@goods_id", SqlDbType.Int,4),
                new SqlParameter("@goods_no", SqlDbType.NVarChar,50),
                new SqlParameter("@goods_title", SqlDbType.NVarChar,100),
                new SqlParameter("@img_url", SqlDbType.NVarChar,255),
                new SqlParameter("@spec_text", SqlDbType.Text),
                new SqlParameter("@goods_price", SqlDbType.Decimal,13),
                new SqlParameter("@real_price", SqlDbType.Decimal,13),
                new SqlParameter("@quantity", SqlDbType.Int,4),
				new SqlParameter("@point", SqlDbType.Int,4),
                new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = model.article_id;
            parameters[1].Value = model.order_id;
            parameters[2].Value = model.goods_id;
            parameters[3].Value = model.goods_no;
            parameters[4].Value = model.goods_title;
            parameters[5].Value = model.img_url;
            parameters[6].Value = model.spec_text;
            parameters[7].Value = model.goods_price;
            parameters[8].Value = model.real_price;
            parameters[9].Value = model.quantity;
            parameters[10].Value = model.point;
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
            int rows = DbHelperSQL.ExecuteSql("delete from [" + databaseprefix + "dt_order_goods] where id=@id", parameters);
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
        /// <returns>Model.dt_order_goods</returns>
        public Model.dt_order_goods GetModel(int id)
        {
            SqlParameter[] parameters = {
            		new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;
            DataSet ds = DbHelperSQL.Query("select " + this.column + " from [" + databaseprefix + "dt_order_goods] where id=@id", parameters);
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
            strSql.Append(this.column + " from [" + databaseprefix + "dt_order_goods]");
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
            strSql.Append("select * from [" + databaseprefix + "dt_order_goods]");
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
        /// <returns>Model.dt_order_goods</returns>
        private Model.dt_order_goods DataRowToModel(DataRow row)
        {
            Model.dt_order_goods model = new Model.dt_order_goods();
            if (row != null)
            {
            	if (null != row["id"] && "" != row["id"].ToString())
            	{
            		model.id = int.Parse(row["id"].ToString());
            	}
            	if (null != row["article_id"] && "" != row["article_id"].ToString())
            	{
            		model.article_id = int.Parse(row["article_id"].ToString());
            	}
            	if (null != row["order_id"] && "" != row["order_id"].ToString())
            	{
            		model.order_id = int.Parse(row["order_id"].ToString());
            	}
            	if (null != row["goods_id"] && "" != row["goods_id"].ToString())
            	{
            		model.goods_id = int.Parse(row["goods_id"].ToString());
            	}
            	if (null != row["goods_no"])
            	{
            		model.goods_no = row["goods_no"].ToString();
            	}
            	if (null != row["goods_title"])
            	{
            		model.goods_title = row["goods_title"].ToString();
            	}
            	if (null != row["img_url"])
            	{
            		model.img_url = row["img_url"].ToString();
            	}
            	if (null != row["spec_text"])
            	{
            		model.spec_text = row["spec_text"].ToString();
            	}
            	if (null != row["goods_price"] && "" != row["goods_price"].ToString())
            	{
            		model.goods_price = decimal.Parse(row["goods_price"].ToString());
            	}
            	if (null != row["real_price"] && "" != row["real_price"].ToString())
            	{
            		model.real_price = decimal.Parse(row["real_price"].ToString());
            	}
            	if (null != row["quantity"] && "" != row["quantity"].ToString())
            	{
            		model.quantity = int.Parse(row["quantity"].ToString());
            	}
            	if (null != row["point"] && "" != row["point"].ToString())
            	{
            		model.point = int.Parse(row["point"].ToString());
            	}
            }
            return model;
        }
        #endregion
    }
}
