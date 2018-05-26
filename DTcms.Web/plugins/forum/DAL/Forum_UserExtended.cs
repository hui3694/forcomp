using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using DTcms.DBUtility;
using DTcms.Common;
namespace DTcms.Web.Plugin.Forum.DAL
{
    //dt_Forum_UserExtended
        //------------------------------------------------------
    // 插件官方地址 www.dtcms-forum.net
    // 本插件开源，支持个人对插件源码修改及非盈利性平台使用
    // 如用于商业盈利性平台，需支付授权费,具体参见官网
    // 我们承接新项目开发或插件二次开发 QQ 271478027
    //------------------------------------------------------
    public partial class Forum_UserExtended
    {
        private string databaseprefix; //数据库表名前缀
        private string column;
        public Forum_UserExtended(string _databaseprefix)
        {
            databaseprefix = _databaseprefix;
            this.column = " UserId, QQ, MSN, Gender, Birthday, Bio, Address, Site, Signature, Nickname, LastPostDateTime, GroupId, LastActivity, TopicCount, PostCount, PostDigestCount, Medal, OnlineTime, OnlineUpdateTime, Verify, Hometown, Nonlocal, Specialty, Credit,CreditTotal  ";
        }
        #region 基本方法================================
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int UserId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "Forum_UserExtended");
            strSql.Append(" where ");
            strSql.Append(" UserId = @UserId  ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4)			};
            parameters[0].Value = UserId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 返回数据总数
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H ");
            strSql.Append(" from " + databaseprefix + "Forum_UserExtended");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }

        /// <summary>
        /// 将原 Cms User表中的用户，对应在论坛Forum_UserExtended副表中生成
        /// </summary>
        public void SysUserAdd()
        {
            string strSql = "SELECT * FROM [dbo].[" + databaseprefix + "users] where id not in (select UserId from [dbo].[" + databaseprefix + "Forum_UserExtended])";

            System.Data.DataTable dtUsers = DbHelperSQL.Query(strSql).Tables[0];

            Model.Forum_Group modelGroup = new BLL.Forum_Group().GetModel("IsDefault=1");

            if (dtUsers.Rows.Count != 0)
            {
                foreach (System.Data.DataRow row in dtUsers.Rows)
                {
                    Model.Forum_UserExtended model = UsersDataRowToModel(row);
                    model.GroupId = modelGroup.Id;
                    model.GroupName = modelGroup.Name;
                    Add(model);
                }
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.Forum_UserExtended UsersDataRowToModel(DataRow row)
        {
            Model.Forum_UserExtended model = new Model.Forum_UserExtended();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.UserId = int.Parse(row["id"].ToString());
                }

                if (row["nick_name"] != null)
                {
                    model.Nickname = row["nick_name"].ToString();
                }
                if (row["sex"] != null)
                {
                    model.Gender = (row["sex"].ToString() == "男" ? 1 : row["sex"].ToString() == "女" ? 0 : -1);
                }
                if (row["birthday"] != null && row["birthday"].ToString() != "")
                {
                    model.Birthday = row["birthday"].ToString();
                }

                if (row["address"] != null)
                {
                    model.Address = row["address"].ToString();
                }
                if (row["qq"] != null)
                {
                    model.QQ = row["qq"].ToString();
                }
                if (row["msn"] != null)
                {
                    model.MSN = row["msn"].ToString();
                }
            }
            return model;
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Model.Forum_UserExtended model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + databaseprefix + "Forum_UserExtended(");
            strSql.Append("UserId,QQ,MSN,Gender,Birthday,Bio,Address,Site,Signature,Nickname,LastPostDateTime,GroupId,LastActivity,TopicCount,PostCount,PostDigestCount,Medal,OnlineTime,OnlineUpdateTime,Verify,Hometown,Nonlocal,Specialty,Credit,CreditTotal");
            strSql.Append(") values (");
            strSql.Append("@UserId,@QQ,@MSN,@Gender,@Birthday,@Bio,@Address,@Site,@Signature,@Nickname,@LastPostDateTime,@GroupId,@LastActivity,@TopicCount,@PostCount,@PostDigestCount,@Medal,@OnlineTime,@OnlineUpdateTime,@Verify,@Hometown,@Nonlocal,@Specialty,@Credit,@CreditTotal");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@UserId", SqlDbType.Int,4) ,            
                        new SqlParameter("@QQ", SqlDbType.NVarChar,16) ,            
                        new SqlParameter("@MSN", SqlDbType.NVarChar,32) ,            
                        new SqlParameter("@Gender", SqlDbType.Int,4) ,            
                        new SqlParameter("@Birthday", SqlDbType.NVarChar,16) ,            
                        new SqlParameter("@Bio", SqlDbType.NVarChar,128) ,            
                        new SqlParameter("@Address", SqlDbType.NVarChar,64) ,            
                        new SqlParameter("@Site", SqlDbType.NVarChar,128) ,            
                        new SqlParameter("@Signature", SqlDbType.NVarChar,128) ,            
                        new SqlParameter("@Nickname", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@LastPostDateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@GroupId", SqlDbType.Int,4) ,            
                        new SqlParameter("@LastActivity", SqlDbType.DateTime) ,            
                        new SqlParameter("@TopicCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@PostCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@PostDigestCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@Medal", SqlDbType.NText) ,            
                        new SqlParameter("@OnlineTime", SqlDbType.Int,4) ,            
                        new SqlParameter("@OnlineUpdateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Verify", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@Hometown", SqlDbType.NVarChar,128) ,            
                        new SqlParameter("@Nonlocal", SqlDbType.NVarChar,128) ,            
                        new SqlParameter("@Specialty", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@Credit", SqlDbType.Money,8),
                        new SqlParameter("@CreditTotal", SqlDbType.Money,8)
                        
              
            };

            parameters[0].Value = model.UserId;
            parameters[1].Value = model.QQ;
            parameters[2].Value = model.MSN;
            parameters[3].Value = model.Gender;
            parameters[4].Value = model.Birthday;
            parameters[5].Value = model.Bio;
            parameters[6].Value = model.Address;
            parameters[7].Value = model.Site;
            parameters[8].Value = model.Signature;
            parameters[9].Value = model.Nickname;
            parameters[10].Value = model.LastPostDateTime;
            parameters[11].Value = model.GroupId;
            parameters[12].Value = model.LastActivity;
            parameters[13].Value = model.TopicCount;
            parameters[14].Value = model.PostCount;
            parameters[15].Value = model.PostDigestCount;
            parameters[16].Value = model.Medal;
            parameters[17].Value = model.OnlineTime;
            parameters[18].Value = model.OnlineUpdateTime;
            parameters[19].Value = model.Verify;
            parameters[20].Value = model.Hometown;
            parameters[21].Value = model.Nonlocal;
            parameters[22].Value = model.Specialty;
            parameters[23].Value = model.Credit;
            parameters[24].Value = model.CreditTotal;

            int bol = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

            if (bol > 0)
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
        public bool Update(Model.Forum_UserExtended model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "Forum_UserExtended set ");

            strSql.Append(" UserId = @UserId , ");
            strSql.Append(" QQ = @QQ , ");
            strSql.Append(" MSN = @MSN , ");
            strSql.Append(" Gender = @Gender , ");
            strSql.Append(" Birthday = @Birthday , ");
            strSql.Append(" Bio = @Bio , ");
            strSql.Append(" Address = @Address , ");
            strSql.Append(" Site = @Site , ");
            strSql.Append(" Signature = @Signature , ");
            strSql.Append(" Nickname = @Nickname , ");
            strSql.Append(" LastPostDateTime = @LastPostDateTime , ");
            strSql.Append(" GroupId = @GroupId , ");
            strSql.Append(" LastActivity = @LastActivity , ");
            strSql.Append(" TopicCount = @TopicCount , ");
            strSql.Append(" PostCount = @PostCount , ");
            strSql.Append(" PostDigestCount = @PostDigestCount , ");
            strSql.Append(" Medal = @Medal , ");
            strSql.Append(" OnlineTime = @OnlineTime , ");
            strSql.Append(" OnlineUpdateTime = @OnlineUpdateTime , ");
            strSql.Append(" Verify = @Verify , ");
            strSql.Append(" Hometown = @Hometown , ");
            strSql.Append(" Nonlocal = @Nonlocal , ");
            strSql.Append(" Specialty = @Specialty , ");
            strSql.Append(" Credit = @Credit,  ");
            strSql.Append(" CreditTotal = @CreditTotal  ");
            strSql.Append(" where UserId=@UserId  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@UserId", SqlDbType.Int,4) ,            
                        new SqlParameter("@QQ", SqlDbType.NVarChar,16) ,            
                        new SqlParameter("@MSN", SqlDbType.NVarChar,32) ,            
                        new SqlParameter("@Gender", SqlDbType.Int,4) ,            
                        new SqlParameter("@Birthday", SqlDbType.NVarChar,16) ,            
                        new SqlParameter("@Bio", SqlDbType.NVarChar,128) ,            
                        new SqlParameter("@Address", SqlDbType.NVarChar,64) ,            
                        new SqlParameter("@Site", SqlDbType.NVarChar,128) ,            
                        new SqlParameter("@Signature", SqlDbType.NVarChar,128) ,            
                        new SqlParameter("@Nickname", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@LastPostDateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@GroupId", SqlDbType.Int,4) ,            
                        new SqlParameter("@LastActivity", SqlDbType.DateTime) ,            
                        new SqlParameter("@TopicCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@PostCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@PostDigestCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@Medal", SqlDbType.NText) ,            
                        new SqlParameter("@OnlineTime", SqlDbType.Int,4) ,            
                        new SqlParameter("@OnlineUpdateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Verify", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@Hometown", SqlDbType.NVarChar,128) ,            
                        new SqlParameter("@Nonlocal", SqlDbType.NVarChar,128) ,            
                        new SqlParameter("@Specialty", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@Credit", SqlDbType.Money,8),
                        new SqlParameter("@CreditTotal", SqlDbType.Money,8)
              
            };

            parameters[0].Value = model.UserId;
            parameters[1].Value = model.QQ;
            parameters[2].Value = model.MSN;
            parameters[3].Value = model.Gender;
            parameters[4].Value = model.Birthday;
            parameters[5].Value = model.Bio;
            parameters[6].Value = model.Address;
            parameters[7].Value = model.Site;
            parameters[8].Value = model.Signature;
            parameters[9].Value = model.Nickname;
            parameters[10].Value = model.LastPostDateTime;
            parameters[11].Value = model.GroupId;
            parameters[12].Value = model.LastActivity;
            parameters[13].Value = model.TopicCount;
            parameters[14].Value = model.PostCount;
            parameters[15].Value = model.PostDigestCount;
            parameters[16].Value = model.Medal;
            parameters[17].Value = model.OnlineTime;
            parameters[18].Value = model.OnlineUpdateTime;
            parameters[19].Value = model.Verify;
            parameters[20].Value = model.Hometown;
            parameters[21].Value = model.Nonlocal;
            parameters[22].Value = model.Specialty;
            parameters[23].Value = model.Credit;
            parameters[24].Value = model.CreditTotal;
            
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
        public bool UpdateField(int UserId, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "Forum_UserExtended set " + strValue);
            strSql.Append(" where UserId=@UserId ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4)			};
            parameters[0].Value = UserId;

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
        public bool Delete(int UserId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "Forum_UserExtended ");
            strSql.Append(" where UserId=@UserId ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4)			};
            parameters[0].Value = UserId;


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
        public Model.Forum_UserExtended GetModel(int UserId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select " + column);
            strSql.Append("  from " + databaseprefix + "Forum_UserExtended ");
            strSql.Append(" where UserId=@UserId ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4)			};
            parameters[0].Value = UserId;


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
        public Model.Forum_UserExtended DataRowToModel(DataRow row)
        {

            if (row != null)
            {
                Model.Forum_UserExtended model = new Model.Forum_UserExtended();

                if (row["UserId"].ToString() != "")
                {
                    model.UserId = int.Parse(row["UserId"].ToString());
                }
                model.QQ = row["QQ"].ToString();
                model.MSN = row["MSN"].ToString();
                if (row["Gender"].ToString() != "")
                {
                    model.Gender = int.Parse(row["Gender"].ToString());
                }
                model.Birthday = row["Birthday"].ToString();
                model.Bio = row["Bio"].ToString();
                model.Address = row["Address"].ToString();
                model.Site = row["Site"].ToString();
                model.Signature = row["Signature"].ToString();
                model.Nickname = row["Nickname"].ToString();
                if (row["LastPostDateTime"].ToString() != "")
                {
                    model.LastPostDateTime = DateTime.Parse(row["LastPostDateTime"].ToString());
                }
                if (row["GroupId"].ToString() != "")
                {
                    model.GroupId = int.Parse(row["GroupId"].ToString());
                }
                if (row["LastActivity"].ToString() != "")
                {
                    model.LastActivity = DateTime.Parse(row["LastActivity"].ToString());
                }
                if (row["TopicCount"].ToString() != "")
                {
                    model.TopicCount = int.Parse(row["TopicCount"].ToString());
                }
                if (row["PostCount"].ToString() != "")
                {
                    model.PostCount = int.Parse(row["PostCount"].ToString());
                }
                if (row["PostDigestCount"].ToString() != "")
                {
                    model.PostDigestCount = int.Parse(row["PostDigestCount"].ToString());
                }
                model.Medal = row["Medal"].ToString();
                if (row["OnlineTime"].ToString() != "")
                {
                    model.OnlineTime = int.Parse(row["OnlineTime"].ToString());
                }
                if (row["OnlineUpdateTime"].ToString() != "")
                {
                    model.OnlineUpdateTime = DateTime.Parse(row["OnlineUpdateTime"].ToString());
                }
                if (row["Verify"].ToString() != "")
                {
                    model.Verify = int.Parse(row["Verify"].ToString());
                }
                model.Hometown = row["Hometown"].ToString();
                model.Nonlocal = row["Nonlocal"].ToString();
                model.Specialty = row["Specialty"].ToString();

                if (row["Credit"].ToString() != "")
                {
                    model.Credit = decimal.Parse(row["Credit"].ToString());
                }

                if (row["CreditTotal"].ToString() != "")
                {
                    model.CreditTotal = decimal.Parse(row["CreditTotal"].ToString());
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




            row["UserId"] = int.Parse(dr[i]["UserId"].ToString());
            row["QQ"] = dr[i]["QQ"].ToString();
            row["MSN"] = dr[i]["MSN"].ToString();

            row["Gender"] = int.Parse(dr[i]["Gender"].ToString());
            row["Birthday"] = dr[i]["Birthday"].ToString();
            row["Bio"] = dr[i]["Bio"].ToString();
            row["Address"] = dr[i]["Address"].ToString();
            row["Site"] = dr[i]["Site"].ToString();
            row["Signature"] = dr[i]["Signature"].ToString();
            row["Nickname"] = dr[i]["Nickname"].ToString();

            row["LastPostDateTime"] = DateTime.Parse(dr[i]["LastPostDateTime"].ToString());

            row["GroupId"] = int.Parse(dr[i]["GroupId"].ToString());

            row["LastActivity"] = DateTime.Parse(dr[i]["LastActivity"].ToString());

            row["TopicCount"] = int.Parse(dr[i]["TopicCount"].ToString());

            row["PostCount"] = int.Parse(dr[i]["PostCount"].ToString());

            row["PostDigestCount"] = int.Parse(dr[i]["PostDigestCount"].ToString());
            row["Medal"] = dr[i]["Medal"].ToString();

            row["OnlineTime"] = int.Parse(dr[i]["OnlineTime"].ToString());

            row["OnlineUpdateTime"] = DateTime.Parse(dr[i]["OnlineUpdateTime"].ToString());

            row["Verify"] = int.Parse(dr[i]["Verify"].ToString());
            row["Hometown"] = dr[i]["Hometown"].ToString();
            row["Nonlocal"] = dr[i]["Nonlocal"].ToString();
            row["Specialty"] = dr[i]["Specialty"].ToString();

            row["Credit"] = decimal.Parse(dr[i]["Credit"].ToString());
            row["CreditTotal"] = decimal.Parse(dr[i]["CreditTotal"].ToString());


        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM " + databaseprefix + "Forum_UserExtended ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }


        /// <summary>
        /// [dt_Forum_UserExtended] as F,[dt_users] as U  内部表
        /// </summary>
        public DataSet GetPostList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select F.*,U.Avatar,U.reg_ip as RegIp,U.reg_time as RegTime,(SELECT top 1 L.[login_time] FROM [" + databaseprefix + "user_login_log] as L where F.UserId=L.user_id order by L.id desc)as LoginTime,(SELECT top 1 L.[login_ip] FROM [" + databaseprefix + "user_login_log] as L order by L.id desc)as LoginIp");
            strSql.Append(" FROM " + databaseprefix + "Forum_UserExtended as F,[" + databaseprefix + "users] as U where U.id=F.UserId ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        



        /// <summary>
        /// 统计
        /// </summary>
        public int GetTotal(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as Total ");
            strSql.Append(" FROM " + databaseprefix + "Forum_UserExtended ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.Query(strSql.ToString()).Tables[0].Rows[0]["Total"].ToString());
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
            strSql.Append(" FROM " + databaseprefix + "Forum_UserExtended ");
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
            strSql.Append("select * FROM " + databaseprefix + "Forum_UserExtended ");
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

