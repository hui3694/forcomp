using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using DTcms.DBUtility;
using DTcms.Common;
namespace DTcms.Web.Plugin.Forum.DAL
{
    //dt_Forum_Post
        //------------------------------------------------------
    // 插件官方地址 www.dtcms-forum.net
    // 本插件开源，支持个人对插件源码修改及非盈利性平台使用
    // 如用于商业盈利性平台，需支付授权费,具体参见官网
    // 我们承接新项目开发或插件二次开发 QQ 271478027
    //------------------------------------------------------
    public partial class Forum_Post
    {
        private string databaseprefix; //数据库表名前缀
        private string column;
        private int postSubTableId;
        public Forum_Post(string _databaseprefix, int _PostSubTableId)
        {
            databaseprefix = _databaseprefix;
            postSubTableId = _PostSubTableId;
            this.column = " Id, BoardId, TopicId, PostUserId, PostUsername, PostNickname, PostUserIp, PostDateTime, Title, Message, HTML, Smile, UBB, Attachment, Signature, Url, Audit, First, Invisible, Ban, Grade, Hide, UpdateUserId, UpdateUsername, UpdateNickname, UpdateTime, Support, Against, QuotePostIds, QuoteUserId, QuoteMessage, QuoteNickname  ";
        }
        #region 基本方法================================
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "Forum_Post_" + postSubTableId.ToString());
            strSql.Append(" where ");
            strSql.Append(" Id = @Id  ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)			};
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
            strSql.Append(" from " + databaseprefix + "Forum_Post_" + postSubTableId.ToString());
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Model.Forum_Post model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + databaseprefix + "Forum_Post_" + postSubTableId.ToString() + "(");
            strSql.Append("Id,BoardId,TopicId,PostUserId,PostUsername,PostNickname,PostUserIp,PostDateTime,Title,Message,HTML,Smile,UBB,Attachment,Signature,Url,Audit,First,Invisible,Ban,Grade,Hide,UpdateUserId,UpdateUsername,UpdateNickname,UpdateTime,Support,Against,QuoteUserId,QuoteMessage,QuoteNickname,QuotePostIds");
            strSql.Append(") values (");
            strSql.Append("@Id,@BoardId,@TopicId,@PostUserId,@PostUsername,@PostNickname,@PostUserIp,@PostDateTime,@Title,@Message,@HTML,@Smile,@UBB,@Attachment,@Signature,@Url,@Audit,@First,@Invisible,@Ban,@Grade,@Hide,@UpdateUserId,@UpdateUsername,@UpdateNickname,@UpdateTime,@Support,@Against,@QuoteUserId,@QuoteMessage,@QuoteNickname,@QuotePostIds");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@BoardId", SqlDbType.Int,4) ,            
                        new SqlParameter("@TopicId", SqlDbType.Int,4) ,            
                        new SqlParameter("@PostUserId", SqlDbType.Int,4) ,            
                        new SqlParameter("@PostUsername", SqlDbType.NVarChar,64) ,            
                        new SqlParameter("@PostNickname", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@PostUserIp", SqlDbType.NVarChar,32) ,            
                        new SqlParameter("@PostDateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Title", SqlDbType.NVarChar,64) ,            
                        new SqlParameter("@Message", SqlDbType.NText) ,            
                        new SqlParameter("@HTML", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@Smile", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@UBB", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@Attachment", SqlDbType.Int,4) ,            
                        new SqlParameter("@Signature", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@Url", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@Audit", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@First", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@Invisible", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@Ban", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@Grade", SqlDbType.Int,4) ,            
                        new SqlParameter("@Hide", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@UpdateUserId", SqlDbType.Int,4) ,            
                        new SqlParameter("@UpdateUsername", SqlDbType.NVarChar,32) ,            
                        new SqlParameter("@UpdateNickname", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@UpdateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Support", SqlDbType.Int,4) ,            
                        new SqlParameter("@Against", SqlDbType.Int,4) ,            
                        new SqlParameter("@QuoteUserId", SqlDbType.Int,4) ,            
                        new SqlParameter("@QuoteMessage", SqlDbType.NText) ,            
                        new SqlParameter("@QuoteNickname", SqlDbType.NVarChar,50),
                        new SqlParameter("@QuotePostIds", SqlDbType.NVarChar,50)
                        
              
            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.BoardId;
            parameters[2].Value = model.TopicId;
            parameters[3].Value = model.PostUserId;
            parameters[4].Value = model.PostUsername;
            parameters[5].Value = model.PostNickname;
            parameters[6].Value = model.PostUserIp;
            parameters[7].Value = model.PostDateTime;
            parameters[8].Value = model.Title;
            parameters[9].Value = model.Message;
            parameters[10].Value = model.HTML;
            parameters[11].Value = model.Smile;
            parameters[12].Value = model.UBB;
            parameters[13].Value = model.Attachment;
            parameters[14].Value = model.Signature;
            parameters[15].Value = model.Url;
            parameters[16].Value = model.Audit;
            parameters[17].Value = model.First;
            parameters[18].Value = model.Invisible;
            parameters[19].Value = model.Ban;
            parameters[20].Value = model.Grade;
            parameters[21].Value = model.Hide;
            parameters[22].Value = model.UpdateUserId;
            parameters[23].Value = model.UpdateUsername;
            parameters[24].Value = model.UpdateNickname;
            parameters[25].Value = model.UpdateTime;
            parameters[26].Value = model.Support;
            parameters[27].Value = model.Against;
            parameters[28].Value = model.QuoteUserId;
            parameters[29].Value = model.QuoteMessage;
            parameters[30].Value = model.QuoteNickname;
            parameters[31].Value = model.QuotePostIds;
            
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.Forum_Post model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "Forum_Post_" + postSubTableId.ToString() + " set ");

            strSql.Append(" Id = @Id , ");
            strSql.Append(" BoardId = @BoardId , ");
            strSql.Append(" TopicId = @TopicId , ");
            strSql.Append(" PostUserId = @PostUserId , ");
            strSql.Append(" PostUsername = @PostUsername , ");
            strSql.Append(" PostNickname = @PostNickname , ");
            strSql.Append(" PostUserIp = @PostUserIp , ");
            strSql.Append(" PostDateTime = @PostDateTime , ");
            strSql.Append(" Title = @Title , ");
            strSql.Append(" Message = @Message , ");
            strSql.Append(" HTML = @HTML , ");
            strSql.Append(" Smile = @Smile , ");
            strSql.Append(" UBB = @UBB , ");
            strSql.Append(" Attachment = @Attachment , ");
            strSql.Append(" Signature = @Signature , ");
            strSql.Append(" Url = @Url , ");
            strSql.Append(" Audit = @Audit , ");
            strSql.Append(" First = @First , ");
            strSql.Append(" Invisible = @Invisible , ");
            strSql.Append(" Ban = @Ban , ");
            strSql.Append(" Grade = @Grade , ");
            strSql.Append(" Hide = @Hide , ");
            strSql.Append(" UpdateUserId = @UpdateUserId , ");
            strSql.Append(" UpdateUsername = @UpdateUsername , ");
            strSql.Append(" UpdateNickname = @UpdateNickname , ");
            strSql.Append(" UpdateTime = @UpdateTime , ");
            strSql.Append(" Support = @Support , ");
            strSql.Append(" Against = @Against , ");
            strSql.Append(" QuoteUserId = @QuoteUserId , ");
            strSql.Append(" QuoteMessage = @QuoteMessage , ");
            strSql.Append(" QuoteNickname = @QuoteNickname  ");
            strSql.Append(" where Id=@Id  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@BoardId", SqlDbType.Int,4) ,            
                        new SqlParameter("@TopicId", SqlDbType.Int,4) ,            
                        new SqlParameter("@PostUserId", SqlDbType.Int,4) ,            
                        new SqlParameter("@PostUsername", SqlDbType.NVarChar,64) ,            
                        new SqlParameter("@PostNickname", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@PostUserIp", SqlDbType.NVarChar,32) ,            
                        new SqlParameter("@PostDateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Title", SqlDbType.NVarChar,64) ,            
                        new SqlParameter("@Message", SqlDbType.NText) ,            
                        new SqlParameter("@HTML", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@Smile", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@UBB", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@Attachment", SqlDbType.Int,4) ,            
                        new SqlParameter("@Signature", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@Url", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@Audit", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@First", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@Invisible", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@Ban", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@Grade", SqlDbType.Int,4) ,            
                        new SqlParameter("@Hide", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@UpdateUserId", SqlDbType.Int,4) ,            
                        new SqlParameter("@UpdateUsername", SqlDbType.NVarChar,32) ,            
                        new SqlParameter("@UpdateNickname", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@UpdateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Support", SqlDbType.Int,4) ,            
                        new SqlParameter("@Against", SqlDbType.Int,4) ,            
                        new SqlParameter("@QuoteUserId", SqlDbType.Int,4) ,            
                        new SqlParameter("@QuoteMessage", SqlDbType.NText) ,            
                        new SqlParameter("@QuoteNickname", SqlDbType.NVarChar,50)             
              
            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.BoardId;
            parameters[2].Value = model.TopicId;
            parameters[3].Value = model.PostUserId;
            parameters[4].Value = model.PostUsername;
            parameters[5].Value = model.PostNickname;
            parameters[6].Value = model.PostUserIp;
            parameters[7].Value = model.PostDateTime;
            parameters[8].Value = model.Title;
            parameters[9].Value = model.Message;
            parameters[10].Value = model.HTML;
            parameters[11].Value = model.Smile;
            parameters[12].Value = model.UBB;
            parameters[13].Value = model.Attachment;
            parameters[14].Value = model.Signature;
            parameters[15].Value = model.Url;
            parameters[16].Value = model.Audit;
            parameters[17].Value = model.First;
            parameters[18].Value = model.Invisible;
            parameters[19].Value = model.Ban;
            parameters[20].Value = model.Grade;
            parameters[21].Value = model.Hide;
            parameters[22].Value = model.UpdateUserId;
            parameters[23].Value = model.UpdateUsername;
            parameters[24].Value = model.UpdateNickname;
            parameters[25].Value = model.UpdateTime;
            parameters[26].Value = model.Support;
            parameters[27].Value = model.Against;
            parameters[28].Value = model.QuoteUserId;
            parameters[29].Value = model.QuoteMessage;
            parameters[30].Value = model.QuoteNickname;
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
        public bool UpdateField(int Id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "Forum_Post_" + postSubTableId.ToString() + " set " + strValue);
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)			};
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
            strSql.Append("delete from " + databaseprefix + "Forum_Post_" + postSubTableId.ToString() + " ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)			};
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
        public bool Delete(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "Forum_Post_" + postSubTableId.ToString() + " ");
            strSql.Append(" where " + strWhere);

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
        public Model.Forum_Post GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 " + column);
            strSql.Append("  from " + databaseprefix + "Forum_Post_" + postSubTableId.ToString() + " ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)			};
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
        /// 得到一个对象实体,内部以 order by id asc 排序 
        /// </summary>
        public Model.Forum_Post GetModel(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 " + column);
            strSql.Append("  from " + databaseprefix + "Forum_Post_" + postSubTableId.ToString() + " ");
            strSql.Append(" where  " + where + " order by id asc");

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
        public Model.Forum_Post DataRowToModel(DataRow row)
        {

            if (row != null)
            {
                Model.Forum_Post model = new Model.Forum_Post();

                if (row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["BoardId"].ToString() != "")
                {
                    model.BoardId = int.Parse(row["BoardId"].ToString());
                }
                if (row["TopicId"].ToString() != "")
                {
                    model.TopicId = int.Parse(row["TopicId"].ToString());
                }
                if (row["PostUserId"].ToString() != "")
                {
                    model.PostUserId = int.Parse(row["PostUserId"].ToString());
                }
                model.PostUsername = row["PostUsername"].ToString();
                model.PostNickname = row["PostNickname"].ToString();
                model.PostUserIp = row["PostUserIp"].ToString();
                if (row["PostDateTime"].ToString() != "")
                {
                    model.PostDateTime = DateTime.Parse(row["PostDateTime"].ToString());
                }
                model.Title = row["Title"].ToString();
                model.Message = row["Message"].ToString();
                if (row["HTML"].ToString() != "")
                {
                    model.HTML = int.Parse(row["HTML"].ToString());
                }
                if (row["Smile"].ToString() != "")
                {
                    model.Smile = int.Parse(row["Smile"].ToString());
                }
                if (row["UBB"].ToString() != "")
                {
                    model.UBB = int.Parse(row["UBB"].ToString());
                }
                if (row["Attachment"].ToString() != "")
                {
                    model.Attachment = int.Parse(row["Attachment"].ToString());
                }
                if (row["Signature"].ToString() != "")
                {
                    model.Signature = int.Parse(row["Signature"].ToString());
                }
                if (row["Url"].ToString() != "")
                {
                    model.Url = int.Parse(row["Url"].ToString());
                }
                if (row["Audit"].ToString() != "")
                {
                    model.Audit = int.Parse(row["Audit"].ToString());
                }
                if (row["First"].ToString() != "")
                {
                    model.First = int.Parse(row["First"].ToString());
                }
                if (row["Invisible"].ToString() != "")
                {
                    model.Invisible = int.Parse(row["Invisible"].ToString());
                }
                if (row["Ban"].ToString() != "")
                {
                    model.Ban = int.Parse(row["Ban"].ToString());
                }
                if (row["Grade"].ToString() != "")
                {
                    model.Grade = int.Parse(row["Grade"].ToString());
                }
                if (row["Hide"].ToString() != "")
                {
                    model.Hide = int.Parse(row["Hide"].ToString());
                }
                if (row["UpdateUserId"].ToString() != "")
                {
                    model.UpdateUserId = int.Parse(row["UpdateUserId"].ToString());
                }
                model.UpdateUsername = row["UpdateUsername"].ToString();
                model.UpdateNickname = row["UpdateNickname"].ToString();
                if (row["UpdateTime"].ToString() != "")
                {
                    model.UpdateTime = DateTime.Parse(row["UpdateTime"].ToString());
                }
                if (row["Support"].ToString() != "")
                {
                    model.Support = int.Parse(row["Support"].ToString());
                }
                if (row["Against"].ToString() != "")
                {
                    model.Against = int.Parse(row["Against"].ToString());
                }
                if (row["QuoteUserId"].ToString() != "")
                {
                    model.QuoteUserId = int.Parse(row["QuoteUserId"].ToString());
                }
                
                model.QuotePostIds = row["QuotePostIds"].ToString();
                model.QuoteMessage = row["QuoteMessage"].ToString();
                model.QuoteNickname = row["QuoteNickname"].ToString();

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

            row["BoardId"] = int.Parse(dr[i]["BoardId"].ToString());

            row["TopicId"] = int.Parse(dr[i]["TopicId"].ToString());

            row["PostUserId"] = int.Parse(dr[i]["PostUserId"].ToString());
            row["PostUsername"] = dr[i]["PostUsername"].ToString();
            row["PostNickname"] = dr[i]["PostNickname"].ToString();
            row["PostUserIp"] = dr[i]["PostUserIp"].ToString();

            row["PostDateTime"] = DateTime.Parse(dr[i]["PostDateTime"].ToString());
            row["Title"] = dr[i]["Title"].ToString();
            row["Message"] = dr[i]["Message"].ToString();

            row["HTML"] = int.Parse(dr[i]["HTML"].ToString());

            row["Smile"] = int.Parse(dr[i]["Smile"].ToString());

            row["UBB"] = int.Parse(dr[i]["UBB"].ToString());

            row["Attachment"] = int.Parse(dr[i]["Attachment"].ToString());

            row["Signature"] = int.Parse(dr[i]["Signature"].ToString());

            row["Url"] = int.Parse(dr[i]["Url"].ToString());

            row["Audit"] = int.Parse(dr[i]["Audit"].ToString());

            row["First"] = int.Parse(dr[i]["First"].ToString());

            row["Invisible"] = int.Parse(dr[i]["Invisible"].ToString());

            row["Ban"] = int.Parse(dr[i]["Ban"].ToString());

            row["Grade"] = int.Parse(dr[i]["Grade"].ToString());

            row["Hide"] = int.Parse(dr[i]["Hide"].ToString());

            row["UpdateUserId"] = int.Parse(dr[i]["UpdateUserId"].ToString());
            row["UpdateUsername"] = dr[i]["UpdateUsername"].ToString();
            row["UpdateNickname"] = dr[i]["UpdateNickname"].ToString();

            row["UpdateTime"] = DateTime.Parse(dr[i]["UpdateTime"].ToString());

            row["Support"] = int.Parse(dr[i]["Support"].ToString());

            row["Against"] = int.Parse(dr[i]["Against"].ToString());

            row["QuoteUserId"] = int.Parse(dr[i]["QuoteUserId"].ToString());
            row["QuoteMessage"] = dr[i]["QuoteMessage"].ToString();
            row["QuoteNickname"] = dr[i]["QuoteNickname"].ToString();
            row["QuotePostIds"] = dr[i]["QuotePostIds"].ToString();           


        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM " + databaseprefix + "Forum_Post_" + postSubTableId.ToString() + " ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }


        /// <summary>
        /// 实际是通过主题表 Forum_Topic 进行回贴合计，可能有些不正确但这样的速度快
        /// </summary>
        public int GetTotal(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sum([ReplayCount]) as Total ");
            strSql.Append(" FROM " + databaseprefix + "Forum_Topic ");
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
            strSql.Append(" FROM " + databaseprefix + "Forum_Post_" + postSubTableId.ToString() + " ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// TopicId 这个参数不为 0 时 where 中会多出  id in (SELECT  [Id] FROM dt_Forum_PostId] where TopicId=" + TopicId + ")
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, int TopicId, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM " + databaseprefix + "Forum_Post_" + postSubTableId.ToString() + " ");
            if (strWhere.Trim() == "")
            {
                strWhere = " 1=1 ";
            }

            strSql.Append(" where " + strWhere);

            if (TopicId != 0)
            {
                strSql.Append(" and  id in (SELECT  [Id] FROM " + databaseprefix + "Forum_PostId where TopicId=" + TopicId + ") ");
            }

            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
        #endregion

    }
}

