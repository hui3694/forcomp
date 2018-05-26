using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using DTcms.DBUtility;
using DTcms.Common;
namespace DTcms.Web.Plugin.Forum.DAL
{
    //dt_Forum_GroupExtended
        //------------------------------------------------------
    // 插件官方地址 www.dtcms-forum.net
    // 本插件开源，支持个人对插件源码修改及非盈利性平台使用
    // 如用于商业盈利性平台，需支付授权费,具体参见官网
    // 我们承接新项目开发或插件二次开发 QQ 271478027
    //------------------------------------------------------
    public partial class Forum_GroupExtended
    {
        private string databaseprefix; //数据库表名前缀
        private string column;
        public Forum_GroupExtended(string _databaseprefix)
        {
            databaseprefix = _databaseprefix;
            this.column = " GroupId, ViewIpField, AttachmentExtension, DayAttachmentSize, PostIntervalSecond, Search, MemberList, PostCheck, Cost, CostMax, PostUpdateLog  ";
        }
        #region 基本方法================================
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int GroupId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "Forum_GroupExtended");
            strSql.Append(" where ");
            strSql.Append(" GroupId = @GroupId  ");
            SqlParameter[] parameters = {
					new SqlParameter("@GroupId", SqlDbType.Int,4)			};
            parameters[0].Value = GroupId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 返回数据总数
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H ");
            strSql.Append(" from " + databaseprefix + "Forum_GroupExtended");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Model.Forum_GroupExtended model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + databaseprefix + "Forum_GroupExtended(");
            strSql.Append("GroupId,ViewIpField,AttachmentExtension,DayAttachmentSize,PostIntervalSecond,Search,MemberList,PostCheck,Cost,CostMax,PostUpdateLog");
            strSql.Append(") values (");
            strSql.Append("@GroupId,@ViewIpField,@AttachmentExtension,@DayAttachmentSize,@PostIntervalSecond,@Search,@MemberList,@PostCheck,@Cost,@CostMax,@PostUpdateLog");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@GroupId", SqlDbType.Int,4) ,            
                        new SqlParameter("@ViewIpField", SqlDbType.Int,4) ,            
                        new SqlParameter("@AttachmentExtension", SqlDbType.NVarChar,64) ,            
                        new SqlParameter("@DayAttachmentSize", SqlDbType.Int,4) ,            
                        new SqlParameter("@PostIntervalSecond", SqlDbType.Int,4) ,            
                        new SqlParameter("@Search", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@MemberList", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@PostCheck", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@Cost",SqlDbType.Int,4) ,          
                        new SqlParameter("@CostMax", SqlDbType.Money,8) ,            
                        new SqlParameter("@PostUpdateLog", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = model.GroupId;
            parameters[1].Value = model.ViewIpField;
            parameters[2].Value = model.AttachmentExtension;
            parameters[3].Value = model.DayAttachmentSize;
            parameters[4].Value = model.PostIntervalSecond;
            parameters[5].Value = model.Search;
            parameters[6].Value = model.MemberList;
            parameters[7].Value = model.PostCheck;
            parameters[8].Value = model.Cost;
            parameters[9].Value = model.CostMax;
            parameters[10].Value = model.PostUpdateLog;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.Forum_GroupExtended model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "Forum_GroupExtended set ");

            strSql.Append(" GroupId = @GroupId , ");
            strSql.Append(" ViewIpField = @ViewIpField , ");
            strSql.Append(" AttachmentExtension = @AttachmentExtension , ");
            strSql.Append(" DayAttachmentSize = @DayAttachmentSize , ");
            strSql.Append(" PostIntervalSecond = @PostIntervalSecond , ");
            strSql.Append(" Search = @Search , ");
            strSql.Append(" MemberList = @MemberList , ");
            strSql.Append(" PostCheck = @PostCheck , ");
            strSql.Append(" Cost = @Cost , ");
            strSql.Append(" CostMax = @CostMax , ");
            strSql.Append(" PostUpdateLog = @PostUpdateLog  ");
            strSql.Append(" where GroupId=@GroupId  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@GroupId", SqlDbType.Int,4) ,            
                        new SqlParameter("@ViewIpField", SqlDbType.Int,4) ,            
                        new SqlParameter("@AttachmentExtension", SqlDbType.NVarChar,64) ,            
                        new SqlParameter("@DayAttachmentSize", SqlDbType.Int,4) ,            
                        new SqlParameter("@PostIntervalSecond", SqlDbType.Int,4) ,            
                        new SqlParameter("@Search", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@MemberList", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@PostCheck", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@Cost", SqlDbType.Int,4) ,              
                        new SqlParameter("@CostMax", SqlDbType.Money,8) ,            
                        new SqlParameter("@PostUpdateLog", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = model.GroupId;
            parameters[1].Value = model.ViewIpField;
            parameters[2].Value = model.AttachmentExtension;
            parameters[3].Value = model.DayAttachmentSize;
            parameters[4].Value = model.PostIntervalSecond;
            parameters[5].Value = model.Search;
            parameters[6].Value = model.MemberList;
            parameters[7].Value = model.PostCheck;
            parameters[8].Value = model.Cost;
            parameters[9].Value = model.CostMax;
            parameters[10].Value = model.PostUpdateLog;
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
        public bool UpdateField(int GroupId, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "Forum_GroupExtended set " + strValue);
            strSql.Append(" where GroupId=@GroupId ");
            SqlParameter[] parameters = {
					new SqlParameter("@GroupId", SqlDbType.Int,4)			};
            parameters[0].Value = GroupId;

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
        public bool Delete(int GroupId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "Forum_GroupExtended ");
            strSql.Append(" where GroupId=@GroupId ");
            SqlParameter[] parameters = {
					new SqlParameter("@GroupId", SqlDbType.Int,4)			};
            parameters[0].Value = GroupId;


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
            strSql.Append("delete from " + databaseprefix + "Forum_GroupExtended ");
            strSql.Append(" where GroupId in (" + Idlist + ")  ");
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
        public Model.Forum_GroupExtended GetModel(int GroupId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select " + column);
            strSql.Append("  from " + databaseprefix + "Forum_GroupExtended ");
            strSql.Append(" where GroupId=@GroupId ");
            SqlParameter[] parameters = {
					new SqlParameter("@GroupId", SqlDbType.Int,4)			};
            parameters[0].Value = GroupId;


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
        public Model.Forum_GroupExtended DataRowToModel(DataRow row)
        {

            if (row != null)
            {
                Model.Forum_GroupExtended model = new Model.Forum_GroupExtended();

                if (row["GroupId"].ToString() != "")
                {
                    model.GroupId = int.Parse(row["GroupId"].ToString());
                }
                if (row["ViewIpField"].ToString() != "")
                {
                    model.ViewIpField = int.Parse(row["ViewIpField"].ToString());
                }
                model.AttachmentExtension = row["AttachmentExtension"].ToString();
                if (row["DayAttachmentSize"].ToString() != "")
                {
                    model.DayAttachmentSize = int.Parse(row["DayAttachmentSize"].ToString());
                }
                if (row["PostIntervalSecond"].ToString() != "")
                {
                    model.PostIntervalSecond = int.Parse(row["PostIntervalSecond"].ToString());
                }
                if (row["Search"].ToString() != "")
                {
                    model.Search = int.Parse(row["Search"].ToString());
                }
                if (row["MemberList"].ToString() != "")
                {
                    model.MemberList = int.Parse(row["MemberList"].ToString());
                }
                if (row["PostCheck"].ToString() != "")
                {
                    model.PostCheck = int.Parse(row["PostCheck"].ToString());
                }
                if (row["Cost"].ToString() != "")
                {
                    model.Cost = int.Parse(row["Cost"].ToString());
                }
                if (row["CostMax"].ToString() != "")
                {
                    model.CostMax = decimal.Parse(row["CostMax"].ToString());
                }
                if (row["PostUpdateLog"].ToString() != "")
                {
                    model.PostUpdateLog = int.Parse(row["PostUpdateLog"].ToString());
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

            row["GroupId"] = int.Parse(dr[i]["GroupId"].ToString());

            row["ViewIpField"] = int.Parse(dr[i]["ViewIpField"].ToString());

            row["AttachmentExtension"] = dr[i]["AttachmentExtension"].ToString();

            row["DayAttachmentSize"] = int.Parse(dr[i]["DayAttachmentSize"].ToString());

            row["PostIntervalSecond"] = int.Parse(dr[i]["PostIntervalSecond"].ToString());

            row["Search"] = int.Parse(dr[i]["Search"].ToString());

            row["MemberList"] = int.Parse(dr[i]["MemberList"].ToString());

            row["PostCheck"] = int.Parse(dr[i]["PostCheck"].ToString());

            row["Cost"] = int.Parse(dr[i]["Cost"].ToString());          

            row["CostMax"] = decimal.Parse(dr[i]["CostMax"].ToString());

            row["PostUpdateLog"] = int.Parse(dr[i]["PostUpdateLog"].ToString());


        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM " + databaseprefix + "Forum_GroupExtended ");
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
            strSql.Append(" FROM " + databaseprefix + "Forum_GroupExtended ");
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
            strSql.Append("select * FROM " + databaseprefix + "Forum_GroupExtended ");
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

