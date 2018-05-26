using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using DTcms.DBUtility;
using DTcms.Common;
namespace DTcms.Web.Plugin.Forum.DAL
{
    //dt_Forum_Group
        //------------------------------------------------------
    // 插件官方地址 www.dtcms-forum.net
    // 本插件开源，支持个人对插件源码修改及非盈利性平台使用
    // 如用于商业盈利性平台，需支付授权费,具体参见官网
    // 我们承接新项目开发或插件二次开发 QQ 271478027
    //------------------------------------------------------
    public partial class Forum_Group
    {
        private string databaseprefix; //数据库表名前缀
        private string column;
        public Forum_Group(string _databaseprefix)
        {
            databaseprefix = _databaseprefix;
            this.column = " Id, Name, System, Type, CreditLower, CreditHigher, [Order], Color, Image, OnlineImage ,IsDefault ";
        }
        #region 基本方法================================
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "Forum_Group");
            strSql.Append(" where ");
            strSql.Append(" Id = @Id  ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 返回数据总数
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H ");
            strSql.Append(" from " + databaseprefix + "Forum_Group");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.Forum_Group model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + databaseprefix + "Forum_Group(");
            strSql.Append("Name,System,Type,CreditLower,CreditHigher,[Order],Color,Image,OnlineImage,IsDefault");
            strSql.Append(") values (");
            strSql.Append("@Name,@System,@Type,@CreditLower,@CreditHigher,@Order,@Color,@Image,@OnlineImage,@IsDefault");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@Name", SqlDbType.NVarChar,32) ,            
                        new SqlParameter("@System", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@Type", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@CreditLower", SqlDbType.Int,4) ,            
                        new SqlParameter("@CreditHigher", SqlDbType.Int,4) ,            
                        new SqlParameter("@Order", SqlDbType.Int,4) ,            
                        new SqlParameter("@Color", SqlDbType.NVarChar,8) ,            
                        new SqlParameter("@Image", SqlDbType.NVarChar,256) ,            
                        new SqlParameter("@OnlineImage", SqlDbType.NVarChar,256),
                        new SqlParameter("@IsDefault", SqlDbType.Int,4) 
              
            };

            parameters[0].Value = model.Name;
            parameters[1].Value = model.System;
            parameters[2].Value = model.Type;
            parameters[3].Value = model.CreditLower;
            parameters[4].Value = model.CreditHigher;
            parameters[5].Value = model.Order;
            parameters[6].Value = model.Color;
            parameters[7].Value = model.Image;
            parameters[8].Value = model.OnlineImage;
            parameters[9].Value = model.IsDefault;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {

                int _id = Convert.ToInt32(obj);

                UpdateIsDefault(_id, model.IsDefault);

                return _id;

            }

        }

        /// <summary>
        /// 设定激活
        /// </summary>
        /// <param name="_id"></param>
        /// <param name="_isdefault"></param>
        public void UpdateIsDefault(int _id, int _isdefault)
        {
            if (_isdefault != 0)
            {
                string strSql = "UPDATE [" + databaseprefix + "Forum_Group] SET [IsDefault] = 0 ; UPDATE [" + databaseprefix + "Forum_Group] SET [IsDefault] = 1 WHERE ID=" + _id;

                DbHelperSQL.Query(strSql.ToString());
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.Forum_Group model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "Forum_Group set ");

            strSql.Append(" Name = @Name , ");
            strSql.Append(" System = @System , ");
            strSql.Append(" Type = @Type , ");
            strSql.Append(" CreditLower = @CreditLower , ");
            strSql.Append(" CreditHigher = @CreditHigher , ");
            strSql.Append(" [Order] = @Order , ");
            strSql.Append(" Color = @Color , ");
            strSql.Append(" Image = @Image , ");
            strSql.Append(" OnlineImage = @OnlineImage , ");
            strSql.Append(" IsDefault = @IsDefault  ");
            strSql.Append(" where Id=@Id ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Name", SqlDbType.NVarChar,32) ,            
                        new SqlParameter("@System", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@Type", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@CreditLower", SqlDbType.Int,4) ,            
                        new SqlParameter("@CreditHigher", SqlDbType.Int,4) ,            
                        new SqlParameter("@Order", SqlDbType.Int,4) ,            
                        new SqlParameter("@Color", SqlDbType.NVarChar,8) ,            
                        new SqlParameter("@Image", SqlDbType.NVarChar,256) ,            
                        new SqlParameter("@OnlineImage", SqlDbType.NVarChar,256) ,
                        new SqlParameter("@IsDefault", SqlDbType.TinyInt,1)
              
            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.System;
            parameters[3].Value = model.Type;
            parameters[4].Value = model.CreditLower;
            parameters[5].Value = model.CreditHigher;
            parameters[6].Value = model.Order;
            parameters[7].Value = model.Color;
            parameters[8].Value = model.Image;
            parameters[9].Value = model.OnlineImage;
            parameters[10].Value = model.IsDefault;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                UpdateIsDefault(model.Id, model.IsDefault);

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
        public bool UpdateField(int Id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "Forum_Group set " + strValue);
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;

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
        public bool Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "Forum_Group ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;


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
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string Idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "Forum_Group ");
            strSql.Append(" where ID in (" + Idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public Model.Forum_Group GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select " + column);
            strSql.Append("  from " + databaseprefix + "Forum_Group ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;


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
        public Model.Forum_Group GetModel(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select " + column);
            strSql.Append("  from " + databaseprefix + "Forum_Group ");
            strSql.Append(" where " + strWhere);

            DataSet ds = DbHelperSQL.Query(strSql.ToString());

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
        public Model.Forum_Group DataRowToModel(DataRow row)
        {

            if (row != null)
            {
                Model.Forum_Group model = new Model.Forum_Group();

                if (row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                model.Name = row["Name"].ToString();
                if (row["System"].ToString() != "")
                {
                    model.System = int.Parse(row["System"].ToString());
                }
                if (row["Type"].ToString() != "")
                {
                    model.Type = int.Parse(row["Type"].ToString());
                }

                if (row["IsDefault"].ToString() != "")
                {
                    model.IsDefault = int.Parse(row["IsDefault"].ToString());
                }
                if (row["CreditLower"].ToString() != "")
                {
                    model.CreditLower = int.Parse(row["CreditLower"].ToString());
                }
                if (row["CreditHigher"].ToString() != "")
                {
                    model.CreditHigher = int.Parse(row["CreditHigher"].ToString());
                }
                if (row["Order"].ToString() != "")
                {
                    model.Order = int.Parse(row["Order"].ToString());
                }
                model.Color = row["Color"].ToString();
                model.Image = row["Image"].ToString();
                model.OnlineImage = row["OnlineImage"].ToString();

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

            row["Id"] = int.Parse(dr[i]["Id"].ToString());
            row["Name"] = dr[i]["Name"].ToString();

            row["System"] = int.Parse(dr[i]["System"].ToString());

            row["Type"] = int.Parse(dr[i]["Type"].ToString());
            row["IsDefault"] = int.Parse(dr[i]["IsDefault"].ToString());

            row["CreditLower"] = int.Parse(dr[i]["CreditLower"].ToString());

            row["CreditHigher"] = int.Parse(dr[i]["CreditHigher"].ToString());

            row["Order"] = int.Parse(dr[i]["Order"].ToString());
            row["Color"] = dr[i]["Color"].ToString();
            row["Image"] = dr[i]["Image"].ToString();
            row["OnlineImage"] = dr[i]["OnlineImage"].ToString();


        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM " + databaseprefix + "Forum_Group ");
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
            strSql.Append(" FROM " + databaseprefix + "Forum_Group ");
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
            strSql.Append("select * FROM " + databaseprefix + "Forum_Group ");
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

