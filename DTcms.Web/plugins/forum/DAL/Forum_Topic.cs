using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using DTcms.DBUtility;
using DTcms.Common;
namespace DTcms.Web.Plugin.Forum.DAL
{
    //dt_Forum_Topic
        //------------------------------------------------------
    // 插件官方地址 www.dtcms-forum.net
    // 本插件开源，支持个人对插件源码修改及非盈利性平台使用
    // 如用于商业盈利性平台，需支付授权费,具体参见官网
    // 我们承接新项目开发或插件二次开发 QQ 271478027
    //------------------------------------------------------
    public partial class Forum_Topic
    {
        private string databaseprefix; //数据库表名前缀
        private string column;
        public Forum_Topic(string _databaseprefix)
        {
            databaseprefix = _databaseprefix;
            this.column = " Id, BoardId, TopicTypeId, Title, ViewCount, ReplayCount, TodayReplayCount, Attachment, TagCount, PostUserId, PostUsername, PostNickname, PostDatetime, LastPostId, LastPostDatetime, LastPostUserId, LastPostUsername, LastPostNickname, Digest, [Top], Audit, Invisible, PostSubTable, HighLight, [Close], FormId, Ban, LastModId, Cover, Rate  ";
        }
        #region 基本方法================================
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "Forum_Topic");
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
            strSql.Append(" from " + databaseprefix + "Forum_Topic");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.Forum_Topic model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + databaseprefix + "Forum_Topic(");
            strSql.Append("BoardId,TopicTypeId,Title,ViewCount,ReplayCount,TodayReplayCount,Attachment,TagCount,PostUserId,PostUsername,PostNickname,PostDatetime,LastPostId,LastPostDatetime,LastPostUserId,LastPostUsername,LastPostNickname,Digest,[Top],Audit,Invisible,PostSubTable,HighLight,[Close],FormId,Ban,LastModId,Cover,Rate");
            strSql.Append(") values (");
            strSql.Append("@BoardId,@TopicTypeId,@Title,@ViewCount,@ReplayCount,@TodayReplayCount,@Attachment,@TagCount,@PostUserId,@PostUsername,@PostNickname,@PostDatetime,@LastPostId,@LastPostDatetime,@LastPostUserId,@LastPostUsername,@LastPostNickname,@Digest,@Top,@Audit,@Invisible,@PostSubTable,@HighLight,@Close,@FormId,@Ban,@LastModId,@Cover,@Rate");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@BoardId", SqlDbType.Int,4) ,            
                        new SqlParameter("@TopicTypeId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Title", SqlDbType.NVarChar,64) ,            
                        new SqlParameter("@ViewCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@ReplayCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@TodayReplayCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@Attachment", SqlDbType.Int,4) ,            
                        new SqlParameter("@TagCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@PostUserId", SqlDbType.Int,4) ,            
                        new SqlParameter("@PostUsername", SqlDbType.NVarChar,32) ,            
                        new SqlParameter("@PostNickname", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@PostDatetime", SqlDbType.DateTime) ,            
                        new SqlParameter("@LastPostId", SqlDbType.Int,4) ,            
                        new SqlParameter("@LastPostDatetime", SqlDbType.DateTime) ,            
                        new SqlParameter("@LastPostUserId", SqlDbType.Int,4) ,            
                        new SqlParameter("@LastPostUsername", SqlDbType.NVarChar,32) ,            
                        new SqlParameter("@LastPostNickname", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@Digest", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@Top", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@Audit", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@Invisible", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@PostSubTable", SqlDbType.Int,4) ,            
                        new SqlParameter("@HighLight", SqlDbType.NVarChar,32) ,            
                        new SqlParameter("@Close", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@FormId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Ban", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@LastModId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Cover", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@Rate", SqlDbType.Money,8)             
              
            };

            parameters[0].Value = model.BoardId;
            parameters[1].Value = model.TopicTypeId;
            parameters[2].Value = model.Title;
            parameters[3].Value = model.ViewCount;
            parameters[4].Value = model.ReplayCount;
            parameters[5].Value = model.TodayReplayCount;
            parameters[6].Value = model.Attachment;
            parameters[7].Value = model.TagCount;
            parameters[8].Value = model.PostUserId;
            parameters[9].Value = model.PostUsername;
            parameters[10].Value = model.PostNickname;
            parameters[11].Value = model.PostDatetime;
            parameters[12].Value = model.LastPostId;
            parameters[13].Value = model.LastPostDatetime;
            parameters[14].Value = model.LastPostUserId;
            parameters[15].Value = model.LastPostUsername;
            parameters[16].Value = model.LastPostNickname;
            parameters[17].Value = model.Digest;
            parameters[18].Value = model.Top;
            parameters[19].Value = model.Audit;
            parameters[20].Value = model.Invisible;
            parameters[21].Value = model.PostSubTable;
            parameters[22].Value = model.HighLight;
            parameters[23].Value = model.Close;
            parameters[24].Value = model.FormId;
            parameters[25].Value = model.Ban;
            parameters[26].Value = model.LastModId;
            parameters[27].Value = model.Cover;
            parameters[28].Value = model.Rate;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {

                return Convert.ToInt32(obj);

            }

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.Forum_Topic model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "Forum_Topic set ");

            strSql.Append(" BoardId = @BoardId , ");
            strSql.Append(" TopicTypeId = @TopicTypeId , ");
            strSql.Append(" Title = @Title , ");
            strSql.Append(" ViewCount = @ViewCount , ");
            strSql.Append(" ReplayCount = @ReplayCount , ");
            strSql.Append(" TodayReplayCount = @TodayReplayCount , ");
            strSql.Append(" Attachment = @Attachment , ");
            strSql.Append(" TagCount = @TagCount , ");
            strSql.Append(" PostUserId = @PostUserId , ");
            strSql.Append(" PostUsername = @PostUsername , ");
            strSql.Append(" PostNickname = @PostNickname , ");
            strSql.Append(" PostDatetime = @PostDatetime , ");
            strSql.Append(" LastPostId = @LastPostId , ");
            strSql.Append(" LastPostDatetime = @LastPostDatetime , ");
            strSql.Append(" LastPostUserId = @LastPostUserId , ");
            strSql.Append(" LastPostUsername = @LastPostUsername , ");
            strSql.Append(" LastPostNickname = @LastPostNickname , ");
            strSql.Append(" Digest = @Digest , ");
            strSql.Append(" [Top] = @Top , ");
            strSql.Append(" Audit = @Audit , ");
            strSql.Append(" Invisible = @Invisible , ");
            strSql.Append(" PostSubTable = @PostSubTable , ");
            strSql.Append(" HighLight = @HighLight , ");
            strSql.Append(" [Close] = @Close , ");
            strSql.Append(" FormId = @FormId , ");
            strSql.Append(" Ban = @Ban , ");
            strSql.Append(" LastModId = @LastModId , ");
            strSql.Append(" Cover = @Cover , ");
            strSql.Append(" Rate = @Rate  ");
            strSql.Append(" where Id=@Id ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@BoardId", SqlDbType.Int,4) ,            
                        new SqlParameter("@TopicTypeId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Title", SqlDbType.NVarChar,64) ,            
                        new SqlParameter("@ViewCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@ReplayCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@TodayReplayCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@Attachment", SqlDbType.Int,4) ,            
                        new SqlParameter("@TagCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@PostUserId", SqlDbType.Int,4) ,            
                        new SqlParameter("@PostUsername", SqlDbType.NVarChar,32) ,            
                        new SqlParameter("@PostNickname", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@PostDatetime", SqlDbType.DateTime) ,            
                        new SqlParameter("@LastPostId", SqlDbType.Int,4) ,            
                        new SqlParameter("@LastPostDatetime", SqlDbType.DateTime) ,            
                        new SqlParameter("@LastPostUserId", SqlDbType.Int,4) ,            
                        new SqlParameter("@LastPostUsername", SqlDbType.NVarChar,32) ,            
                        new SqlParameter("@LastPostNickname", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@Digest", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@Top", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@Audit", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@Invisible", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@PostSubTable", SqlDbType.Int,4) ,            
                        new SqlParameter("@HighLight", SqlDbType.NVarChar,32) ,            
                        new SqlParameter("@Close", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@FormId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Ban", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@LastModId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Cover", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@Rate", SqlDbType.Money,8)             
              
            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.BoardId;
            parameters[2].Value = model.TopicTypeId;
            parameters[3].Value = model.Title;
            parameters[4].Value = model.ViewCount;
            parameters[5].Value = model.ReplayCount;
            parameters[6].Value = model.TodayReplayCount;
            parameters[7].Value = model.Attachment;
            parameters[8].Value = model.TagCount;
            parameters[9].Value = model.PostUserId;
            parameters[10].Value = model.PostUsername;
            parameters[11].Value = model.PostNickname;
            parameters[12].Value = model.PostDatetime;
            parameters[13].Value = model.LastPostId;
            parameters[14].Value = model.LastPostDatetime;
            parameters[15].Value = model.LastPostUserId;
            parameters[16].Value = model.LastPostUsername;
            parameters[17].Value = model.LastPostNickname;
            parameters[18].Value = model.Digest;
            parameters[19].Value = model.Top;
            parameters[20].Value = model.Audit;
            parameters[21].Value = model.Invisible;
            parameters[22].Value = model.PostSubTable;
            parameters[23].Value = model.HighLight;
            parameters[24].Value = model.Close;
            parameters[25].Value = model.FormId;
            parameters[26].Value = model.Ban;
            parameters[27].Value = model.LastModId;
            parameters[28].Value = model.Cover;
            parameters[29].Value = model.Rate;
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
            strSql.Append("update " + databaseprefix + "Forum_Topic set " + strValue);
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
        /// 修改一列数据
        /// </summary>
        public bool UpdateField(string strWhere, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "Forum_Topic set " + strValue);
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
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "Forum_Topic ");
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
            strSql.Append("delete from " + databaseprefix + "Forum_Topic ");
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
        public Model.Forum_Topic GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select " + column);
            strSql.Append("  from " + databaseprefix + "Forum_Topic ");
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
        public Model.Forum_Topic DataRowToModel(DataRow row)
        {

            if (row != null)
            {
                Model.Forum_Topic model = new Model.Forum_Topic();

                if (row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["BoardId"].ToString() != "")
                {
                    model.BoardId = int.Parse(row["BoardId"].ToString());
                }
                if (row["TopicTypeId"].ToString() != "")
                {
                    model.TopicTypeId = int.Parse(row["TopicTypeId"].ToString());
                }
                model.Title = row["Title"].ToString();
                if (row["ViewCount"].ToString() != "")
                {
                    model.ViewCount = int.Parse(row["ViewCount"].ToString());
                }
                if (row["ReplayCount"].ToString() != "")
                {
                    model.ReplayCount = int.Parse(row["ReplayCount"].ToString());
                }
                if (row["TodayReplayCount"].ToString() != "")
                {
                    model.TodayReplayCount = int.Parse(row["TodayReplayCount"].ToString());
                }
                if (row["Attachment"].ToString() != "")
                {
                    model.Attachment = int.Parse(row["Attachment"].ToString());
                }
                if (row["TagCount"].ToString() != "")
                {
                    model.TagCount = int.Parse(row["TagCount"].ToString());
                }
                if (row["PostUserId"].ToString() != "")
                {
                    model.PostUserId = int.Parse(row["PostUserId"].ToString());
                }
                model.PostUsername = row["PostUsername"].ToString();
                model.PostNickname = row["PostNickname"].ToString();
                if (row["PostDatetime"].ToString() != "")
                {
                    model.PostDatetime = DateTime.Parse(row["PostDatetime"].ToString());
                }
                if (row["LastPostId"].ToString() != "")
                {
                    model.LastPostId = int.Parse(row["LastPostId"].ToString());
                }
                if (row["LastPostDatetime"].ToString() != "")
                {
                    model.LastPostDatetime = DateTime.Parse(row["LastPostDatetime"].ToString());
                }
                if (row["LastPostUserId"].ToString() != "")
                {
                    model.LastPostUserId = int.Parse(row["LastPostUserId"].ToString());
                }
                model.LastPostUsername = row["LastPostUsername"].ToString();
                model.LastPostNickname = row["LastPostNickname"].ToString();
                if (row["Digest"].ToString() != "")
                {
                    model.Digest = int.Parse(row["Digest"].ToString());
                }
                if (row["Top"].ToString() != "")
                {
                    model.Top = int.Parse(row["Top"].ToString());
                }
                if (row["Audit"].ToString() != "")
                {
                    model.Audit = int.Parse(row["Audit"].ToString());
                }
                if (row["Invisible"].ToString() != "")
                {
                    model.Invisible = int.Parse(row["Invisible"].ToString());
                }
                if (row["PostSubTable"].ToString() != "")
                {
                    model.PostSubTable = int.Parse(row["PostSubTable"].ToString());
                }
                model.HighLight = row["HighLight"].ToString();
                if (row["Close"].ToString() != "")
                {
                    model.Close = int.Parse(row["Close"].ToString());
                }
                if (row["FormId"].ToString() != "")
                {
                    model.FormId = int.Parse(row["FormId"].ToString());
                }
                if (row["Ban"].ToString() != "")
                {
                    model.Ban = int.Parse(row["Ban"].ToString());
                }
                if (row["LastModId"].ToString() != "")
                {
                    model.LastModId = int.Parse(row["LastModId"].ToString());
                }
                if (row["Cover"].ToString() != "")
                {
                    model.Cover = int.Parse(row["Cover"].ToString());
                }
                if (row["Rate"].ToString() != "")
                {
                    model.Rate = decimal.Parse(row["Rate"].ToString());
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

            row["Id"] = int.Parse(dr[i]["Id"].ToString());

            row["BoardId"] = int.Parse(dr[i]["BoardId"].ToString());

            row["TopicTypeId"] = int.Parse(dr[i]["TopicTypeId"].ToString());
            row["Title"] = dr[i]["Title"].ToString();

            row["ViewCount"] = int.Parse(dr[i]["ViewCount"].ToString());

            row["ReplayCount"] = int.Parse(dr[i]["ReplayCount"].ToString());

            row["TodayReplayCount"] = int.Parse(dr[i]["TodayReplayCount"].ToString());

            row["Attachment"] = int.Parse(dr[i]["Attachment"].ToString());

            row["TagCount"] = int.Parse(dr[i]["TagCount"].ToString());

            row["PostUserId"] = int.Parse(dr[i]["PostUserId"].ToString());
            row["PostUsername"] = dr[i]["PostUsername"].ToString();
            row["PostNickname"] = dr[i]["PostNickname"].ToString();

            row["PostDatetime"] = DateTime.Parse(dr[i]["PostDatetime"].ToString());

            row["LastPostId"] = int.Parse(dr[i]["LastPostId"].ToString());

            row["LastPostDatetime"] = DateTime.Parse(dr[i]["LastPostDatetime"].ToString());

            row["LastPostUserId"] = int.Parse(dr[i]["LastPostUserId"].ToString());
            row["LastPostUsername"] = dr[i]["LastPostUsername"].ToString();
            row["LastPostNickname"] = dr[i]["LastPostNickname"].ToString();

            row["Digest"] = int.Parse(dr[i]["Digest"].ToString());

            row["Top"] = int.Parse(dr[i]["Top"].ToString());

            row["Audit"] = int.Parse(dr[i]["Audit"].ToString());

            row["Invisible"] = int.Parse(dr[i]["Invisible"].ToString());

            row["PostSubTable"] = int.Parse(dr[i]["PostSubTable"].ToString());
            row["HighLight"] = dr[i]["HighLight"].ToString();

            row["Close"] = int.Parse(dr[i]["Close"].ToString());

            row["FormId"] = int.Parse(dr[i]["FormId"].ToString());

            row["Ban"] = int.Parse(dr[i]["Ban"].ToString());

            row["LastModId"] = int.Parse(dr[i]["LastModId"].ToString());

            row["Cover"] = int.Parse(dr[i]["Cover"].ToString());

            row["Rate"] = decimal.Parse(dr[i]["Rate"].ToString());


        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM " + databaseprefix + "Forum_Topic ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            strSql.Append(" FROM " + databaseprefix + "Forum_Topic ");
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
            strSql.Append("select *,(SELECT top 1 [Name] FROM [" + databaseprefix + "Forum_Board] where ID=" + databaseprefix + "Forum_Topic.BoardId) as BoardName FROM " + databaseprefix + "Forum_Topic ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        /// <summary>
        /// 获取置顶的贴子
        /// </summary>
        public DataSet GetTopList(int board_id)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("Select * from ( ");
            strSql.Append("SELECT Top 20 * FROM [" + databaseprefix + "Forum_Topic] where [audit]=0 and [Invisible]=0 and [top]=3 order by [lastpostid] desc  ");
            strSql.Append("Union all ");
            strSql.Append("SELECT Top 20 * FROM [" + databaseprefix + "Forum_Topic] where [audit]=0 and [Invisible]=0 and [top]=2 and [BoardId] in (SELECT  [Id] FROM [" + databaseprefix + "Forum_Board] where ParentId=" + board_id + ") order by [lastpostid] desc ");
            strSql.Append("Union all ");
            strSql.Append("SELECT Top 20 * FROM [" + databaseprefix + "Forum_Topic] where [audit]=0 and [Invisible]=0 and [Top]=1 and [BoardId]=" + board_id + " order by [lastpostid] desc ");
            strSql.Append(" ) as Forum_Topic ");

            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion

    }
}

