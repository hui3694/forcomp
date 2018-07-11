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
    public partial class dt_orders
    {
        private string column;
        private string databaseprefix; 
        public dt_orders(string _databaseprefix)
        {
            this.databaseprefix = _databaseprefix;
            this.column = "id,order_no,trade_no,user_id,user_name,payment_id,payment_fee,payment_status,payment_time,express_id,express_no,express_fee,express_status,express_time,accept_name,post_code,telphone,mobile,email,area,address,message,remark,is_invoice,invoice_title,invoice_taxes,payable_amount,real_amount,order_amount,point,status,add_time,confirm_time,complete_time";
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
            return DbHelperSQL.Exists("select count(1) from [" + databaseprefix + "dt_orders] where id=@id", parameters);
        }
        /// <summary>
        /// 返回数据总数
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns>总数</returns>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H from [" + databaseprefix + "dt_orders]");
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
        /// <param name="model">Model.dt_orders</param>
        /// <returns>ID</returns>
        public int Add(Model.dt_orders model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [" + databaseprefix + "dt_orders](");
            strSql.Append("order_no,trade_no,user_id,user_name,payment_id,payment_fee,payment_status,payment_time,express_id,express_no,express_fee,express_status,express_time,accept_name,post_code,telphone,mobile,email,area,address,message,remark,is_invoice,invoice_title,invoice_taxes,payable_amount,real_amount,order_amount,point,status,add_time,confirm_time,complete_time");
            strSql.Append(") values(");
            strSql.Append("@order_no,@trade_no,@user_id,@user_name,@payment_id,@payment_fee,@payment_status,@payment_time,@express_id,@express_no,@express_fee,@express_status,@express_time,@accept_name,@post_code,@telphone,@mobile,@email,@area,@address,@message,@remark,@is_invoice,@invoice_title,@invoice_taxes,@payable_amount,@real_amount,@order_amount,@point,@status,@add_time,@confirm_time,@complete_time)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                new SqlParameter("@order_no", SqlDbType.NVarChar,100),
                new SqlParameter("@trade_no", SqlDbType.NVarChar,100),
                new SqlParameter("@user_id", SqlDbType.Int,4),
                new SqlParameter("@user_name", SqlDbType.NVarChar,100),
                new SqlParameter("@payment_id", SqlDbType.Int,4),
                new SqlParameter("@payment_fee", SqlDbType.Decimal,13),
                new SqlParameter("@payment_status", SqlDbType.TinyInt,1),
                new SqlParameter("@payment_time", SqlDbType.DateTime),
                new SqlParameter("@express_id", SqlDbType.Int,4),
                new SqlParameter("@express_no", SqlDbType.NVarChar,100),
                new SqlParameter("@express_fee", SqlDbType.Decimal,13),
                new SqlParameter("@express_status", SqlDbType.TinyInt,1),
                new SqlParameter("@express_time", SqlDbType.DateTime),
                new SqlParameter("@accept_name", SqlDbType.NVarChar,50),
                new SqlParameter("@post_code", SqlDbType.NVarChar,20),
                new SqlParameter("@telphone", SqlDbType.NVarChar,30),
                new SqlParameter("@mobile", SqlDbType.NVarChar,20),
                new SqlParameter("@email", SqlDbType.NVarChar,30),
                new SqlParameter("@area", SqlDbType.NVarChar,100),
                new SqlParameter("@address", SqlDbType.NVarChar,500),
                new SqlParameter("@message", SqlDbType.NVarChar,500),
                new SqlParameter("@remark", SqlDbType.NVarChar,500),
                new SqlParameter("@is_invoice", SqlDbType.TinyInt,1),
                new SqlParameter("@invoice_title", SqlDbType.VarChar,100),
                new SqlParameter("@invoice_taxes", SqlDbType.Decimal,13),
                new SqlParameter("@payable_amount", SqlDbType.Decimal,13),
                new SqlParameter("@real_amount", SqlDbType.Decimal,13),
                new SqlParameter("@order_amount", SqlDbType.Decimal,13),
                new SqlParameter("@point", SqlDbType.Int,4),
                new SqlParameter("@status", SqlDbType.TinyInt,1),
                new SqlParameter("@add_time", SqlDbType.DateTime),
                new SqlParameter("@confirm_time", SqlDbType.DateTime),
				new SqlParameter("@complete_time", SqlDbType.DateTime)
            };
            parameters[0].Value = model.order_no;
            parameters[1].Value = model.trade_no;
            parameters[2].Value = model.user_id;
            parameters[3].Value = model.user_name;
            parameters[4].Value = model.payment_id;
            parameters[5].Value = model.payment_fee;
            parameters[6].Value = model.payment_status;
            parameters[7].Value = model.payment_time;
            parameters[8].Value = model.express_id;
            parameters[9].Value = model.express_no;
            parameters[10].Value = model.express_fee;
            parameters[11].Value = model.express_status;
            parameters[12].Value = model.express_time;
            parameters[13].Value = model.accept_name;
            parameters[14].Value = model.post_code;
            parameters[15].Value = model.telphone;
            parameters[16].Value = model.mobile;
            parameters[17].Value = model.email;
            parameters[18].Value = model.area;
            parameters[19].Value = model.address;
            parameters[20].Value = model.message;
            parameters[21].Value = model.remark;
            parameters[22].Value = model.is_invoice;
            parameters[23].Value = model.invoice_title;
            parameters[24].Value = model.invoice_taxes;
            parameters[25].Value = model.payable_amount;
            parameters[26].Value = model.real_amount;
            parameters[27].Value = model.order_amount;
            parameters[28].Value = model.point;
            parameters[29].Value = model.status;
            parameters[30].Value = model.add_time;
            parameters[31].Value = model.confirm_time;
            parameters[32].Value = model.complete_time;
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
            DbHelperSQL.ExecuteSql("update [" + databaseprefix + "dt_orders] set " + strValue + " where id=" + id);
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">Model.dt_orders</param>
        /// <returns>True or False</returns>
        public bool Update(Model.dt_orders model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [" + databaseprefix + "dt_orders] set ");
            strSql.Append("order_no=@order_no,");
            strSql.Append("trade_no=@trade_no,");
            strSql.Append("user_id=@user_id,");
            strSql.Append("user_name=@user_name,");
            strSql.Append("payment_id=@payment_id,");
            strSql.Append("payment_fee=@payment_fee,");
            strSql.Append("payment_status=@payment_status,");
            strSql.Append("payment_time=@payment_time,");
            strSql.Append("express_id=@express_id,");
            strSql.Append("express_no=@express_no,");
            strSql.Append("express_fee=@express_fee,");
            strSql.Append("express_status=@express_status,");
            strSql.Append("express_time=@express_time,");
            strSql.Append("accept_name=@accept_name,");
            strSql.Append("post_code=@post_code,");
            strSql.Append("telphone=@telphone,");
            strSql.Append("mobile=@mobile,");
            strSql.Append("email=@email,");
            strSql.Append("area=@area,");
            strSql.Append("address=@address,");
            strSql.Append("message=@message,");
            strSql.Append("remark=@remark,");
            strSql.Append("is_invoice=@is_invoice,");
            strSql.Append("invoice_title=@invoice_title,");
            strSql.Append("invoice_taxes=@invoice_taxes,");
            strSql.Append("payable_amount=@payable_amount,");
            strSql.Append("real_amount=@real_amount,");
            strSql.Append("order_amount=@order_amount,");
            strSql.Append("point=@point,");
            strSql.Append("status=@status,");
            strSql.Append("add_time=@add_time,");
            strSql.Append("confirm_time=@confirm_time,");
            strSql.Append("complete_time=@complete_time");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                new SqlParameter("@order_no", SqlDbType.NVarChar,100),
                new SqlParameter("@trade_no", SqlDbType.NVarChar,100),
                new SqlParameter("@user_id", SqlDbType.Int,4),
                new SqlParameter("@user_name", SqlDbType.NVarChar,100),
                new SqlParameter("@payment_id", SqlDbType.Int,4),
                new SqlParameter("@payment_fee", SqlDbType.Decimal,13),
                new SqlParameter("@payment_status", SqlDbType.TinyInt,1),
                new SqlParameter("@payment_time", SqlDbType.DateTime),
                new SqlParameter("@express_id", SqlDbType.Int,4),
                new SqlParameter("@express_no", SqlDbType.NVarChar,100),
                new SqlParameter("@express_fee", SqlDbType.Decimal,13),
                new SqlParameter("@express_status", SqlDbType.TinyInt,1),
                new SqlParameter("@express_time", SqlDbType.DateTime),
                new SqlParameter("@accept_name", SqlDbType.NVarChar,50),
                new SqlParameter("@post_code", SqlDbType.NVarChar,20),
                new SqlParameter("@telphone", SqlDbType.NVarChar,30),
                new SqlParameter("@mobile", SqlDbType.NVarChar,20),
                new SqlParameter("@email", SqlDbType.NVarChar,30),
                new SqlParameter("@area", SqlDbType.NVarChar,100),
                new SqlParameter("@address", SqlDbType.NVarChar,500),
                new SqlParameter("@message", SqlDbType.NVarChar,500),
                new SqlParameter("@remark", SqlDbType.NVarChar,500),
                new SqlParameter("@is_invoice", SqlDbType.TinyInt,1),
                new SqlParameter("@invoice_title", SqlDbType.VarChar,100),
                new SqlParameter("@invoice_taxes", SqlDbType.Decimal,13),
                new SqlParameter("@payable_amount", SqlDbType.Decimal,13),
                new SqlParameter("@real_amount", SqlDbType.Decimal,13),
                new SqlParameter("@order_amount", SqlDbType.Decimal,13),
                new SqlParameter("@point", SqlDbType.Int,4),
                new SqlParameter("@status", SqlDbType.TinyInt,1),
                new SqlParameter("@add_time", SqlDbType.DateTime),
                new SqlParameter("@confirm_time", SqlDbType.DateTime),
				new SqlParameter("@complete_time", SqlDbType.DateTime),
                new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = model.order_no;
            parameters[1].Value = model.trade_no;
            parameters[2].Value = model.user_id;
            parameters[3].Value = model.user_name;
            parameters[4].Value = model.payment_id;
            parameters[5].Value = model.payment_fee;
            parameters[6].Value = model.payment_status;
            parameters[7].Value = model.payment_time;
            parameters[8].Value = model.express_id;
            parameters[9].Value = model.express_no;
            parameters[10].Value = model.express_fee;
            parameters[11].Value = model.express_status;
            parameters[12].Value = model.express_time;
            parameters[13].Value = model.accept_name;
            parameters[14].Value = model.post_code;
            parameters[15].Value = model.telphone;
            parameters[16].Value = model.mobile;
            parameters[17].Value = model.email;
            parameters[18].Value = model.area;
            parameters[19].Value = model.address;
            parameters[20].Value = model.message;
            parameters[21].Value = model.remark;
            parameters[22].Value = model.is_invoice;
            parameters[23].Value = model.invoice_title;
            parameters[24].Value = model.invoice_taxes;
            parameters[25].Value = model.payable_amount;
            parameters[26].Value = model.real_amount;
            parameters[27].Value = model.order_amount;
            parameters[28].Value = model.point;
            parameters[29].Value = model.status;
            parameters[30].Value = model.add_time;
            parameters[31].Value = model.confirm_time;
            parameters[32].Value = model.complete_time;
            parameters[33].Value = model.id;
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
            int rows = DbHelperSQL.ExecuteSql("delete from [" + databaseprefix + "dt_orders] where id=@id", parameters);
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
        /// <returns>Model.dt_orders</returns>
        public Model.dt_orders GetModel(int id)
        {
            SqlParameter[] parameters = {
            		new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;
            DataSet ds = DbHelperSQL.Query("select " + this.column + " from [" + databaseprefix + "dt_orders] where id=@id", parameters);
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
            strSql.Append(this.column + " from [" + databaseprefix + "dt_orders]");
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
            strSql.Append("select * from [" + databaseprefix + "dt_orders]");
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
        /// <returns>Model.dt_orders</returns>
        private Model.dt_orders DataRowToModel(DataRow row)
        {
            Model.dt_orders model = new Model.dt_orders();
            if (row != null)
            {
            	if (null != row["id"] && "" != row["id"].ToString())
            	{
            		model.id = int.Parse(row["id"].ToString());
            	}
            	if (null != row["order_no"])
            	{
            		model.order_no = row["order_no"].ToString();
            	}
            	if (null != row["trade_no"])
            	{
            		model.trade_no = row["trade_no"].ToString();
            	}
            	if (null != row["user_id"] && "" != row["user_id"].ToString())
            	{
            		model.user_id = int.Parse(row["user_id"].ToString());
            	}
            	if (null != row["user_name"])
            	{
            		model.user_name = row["user_name"].ToString();
            	}
            	if (null != row["payment_id"] && "" != row["payment_id"].ToString())
            	{
            		model.payment_id = int.Parse(row["payment_id"].ToString());
            	}
            	if (null != row["payment_fee"] && "" != row["payment_fee"].ToString())
            	{
            		model.payment_fee = decimal.Parse(row["payment_fee"].ToString());
            	}
            	if (null != row["payment_status"] && "" != row["payment_status"].ToString())
            	{
            		model.payment_status = int.Parse(row["payment_status"].ToString());
            	}
            	if (null != row["payment_time"] && "" != row["payment_time"].ToString())
            	{
            		model.payment_time = DateTime.Parse(row["payment_time"].ToString());
            	}
            	if (null != row["express_id"] && "" != row["express_id"].ToString())
            	{
            		model.express_id = int.Parse(row["express_id"].ToString());
            	}
            	if (null != row["express_no"])
            	{
            		model.express_no = row["express_no"].ToString();
            	}
            	if (null != row["express_fee"] && "" != row["express_fee"].ToString())
            	{
            		model.express_fee = decimal.Parse(row["express_fee"].ToString());
            	}
            	if (null != row["express_status"] && "" != row["express_status"].ToString())
            	{
            		model.express_status = int.Parse(row["express_status"].ToString());
            	}
            	if (null != row["express_time"] && "" != row["express_time"].ToString())
            	{
            		model.express_time = DateTime.Parse(row["express_time"].ToString());
            	}
            	if (null != row["accept_name"])
            	{
            		model.accept_name = row["accept_name"].ToString();
            	}
            	if (null != row["post_code"])
            	{
            		model.post_code = row["post_code"].ToString();
            	}
            	if (null != row["telphone"])
            	{
            		model.telphone = row["telphone"].ToString();
            	}
            	if (null != row["mobile"])
            	{
            		model.mobile = row["mobile"].ToString();
            	}
            	if (null != row["email"])
            	{
            		model.email = row["email"].ToString();
            	}
            	if (null != row["area"])
            	{
            		model.area = row["area"].ToString();
            	}
            	if (null != row["address"])
            	{
            		model.address = row["address"].ToString();
            	}
            	if (null != row["message"])
            	{
            		model.message = row["message"].ToString();
            	}
            	if (null != row["remark"])
            	{
            		model.remark = row["remark"].ToString();
            	}
            	if (null != row["is_invoice"] && "" != row["is_invoice"].ToString())
            	{
            		model.is_invoice = int.Parse(row["is_invoice"].ToString());
            	}
            	if (null != row["invoice_title"])
            	{
            		model.invoice_title = row["invoice_title"].ToString();
            	}
            	if (null != row["invoice_taxes"] && "" != row["invoice_taxes"].ToString())
            	{
            		model.invoice_taxes = decimal.Parse(row["invoice_taxes"].ToString());
            	}
            	if (null != row["payable_amount"] && "" != row["payable_amount"].ToString())
            	{
            		model.payable_amount = decimal.Parse(row["payable_amount"].ToString());
            	}
            	if (null != row["real_amount"] && "" != row["real_amount"].ToString())
            	{
            		model.real_amount = decimal.Parse(row["real_amount"].ToString());
            	}
            	if (null != row["order_amount"] && "" != row["order_amount"].ToString())
            	{
            		model.order_amount = decimal.Parse(row["order_amount"].ToString());
            	}
            	if (null != row["point"] && "" != row["point"].ToString())
            	{
            		model.point = int.Parse(row["point"].ToString());
            	}
            	if (null != row["status"] && "" != row["status"].ToString())
            	{
            		model.status = int.Parse(row["status"].ToString());
            	}
            	if (null != row["add_time"] && "" != row["add_time"].ToString())
            	{
            		model.add_time = DateTime.Parse(row["add_time"].ToString());
            	}
            	if (null != row["confirm_time"] && "" != row["confirm_time"].ToString())
            	{
            		model.confirm_time = DateTime.Parse(row["confirm_time"].ToString());
            	}
            	if (null != row["complete_time"] && "" != row["complete_time"].ToString())
            	{
            		model.complete_time = DateTime.Parse(row["complete_time"].ToString());
            	}
            }
            return model;
        }
        #endregion
    }
}
