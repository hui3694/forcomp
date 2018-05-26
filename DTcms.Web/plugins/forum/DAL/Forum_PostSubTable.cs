using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using DTcms.DBUtility;
using DTcms.Common;
namespace DTcms.Web.Plugin.Forum.DAL
{
    //dt_Forum_PostSubTable
        //------------------------------------------------------
    // 插件官方地址 www.dtcms-forum.net
    // 本插件开源，支持个人对插件源码修改及非盈利性平台使用
    // 如用于商业盈利性平台，需支付授权费,具体参见官网
    // 我们承接新项目开发或插件二次开发 QQ 271478027
    //------------------------------------------------------
    public partial class Forum_PostSubTable
    {
        private string databaseprefix; //数据库表名前缀
        private string column;
        public Forum_PostSubTable(string _databaseprefix)
        {
            databaseprefix = _databaseprefix;
            this.column = " Id, Name, Description, TopicCount, PostCount, CreateDateTime, Avail, RecyclePost, UnauditedPost  ";
        }
        #region 基本方法================================
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "Forum_PostSubTable");
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
            strSql.Append(" from " + databaseprefix + "Forum_PostSubTable");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.Forum_PostSubTable model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + databaseprefix + "Forum_PostSubTable(");
            strSql.Append("Name,Description,TopicCount,PostCount,CreateDateTime,Avail,RecyclePost,UnauditedPost");
            strSql.Append(") values (");
            strSql.Append("@Name,@Description,@TopicCount,@PostCount,@CreateDateTime,@Avail,@RecyclePost,@UnauditedPost");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@Name", SqlDbType.NVarChar,32) ,            
                        new SqlParameter("@Description", SqlDbType.NVarChar,512) ,            
                        new SqlParameter("@TopicCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@PostCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@CreateDateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Avail", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@RecyclePost", SqlDbType.Int,4) ,            
                        new SqlParameter("@UnauditedPost", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = model.Name;
            parameters[1].Value = model.Description;
            parameters[2].Value = model.TopicCount;
            parameters[3].Value = model.PostCount;
            parameters[4].Value = model.CreateDateTime;
            parameters[5].Value = model.Avail;
            parameters[6].Value = model.RecyclePost;
            parameters[7].Value = model.UnauditedPost;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                int _id = Convert.ToInt32(obj);

                CreateForumPost(_id);

                UpdateAvail(_id, model.Avail);

                return _id;
            }

        }

        /// <summary>
        /// 设定激活
        /// </summary>
        /// <param name="_id"></param>
        /// <param name="_avail"></param>
        public void UpdateAvail(int _id, int _avail)
        {
            if (_avail != 0)
            {
                string strSql = "UPDATE [" + databaseprefix + "Forum_PostSubTable] SET [Avail] = 0 ; UPDATE [" + databaseprefix + "Forum_PostSubTable] SET [Avail] = 1 WHERE ID=" + _id;

                DbHelperSQL.Query(strSql.ToString());
            }
        }

        /// <summary>
        /// 创建贴子分表
        /// </summary>
        /// <param name="_id"></param>
        public void CreateForumPost(int _id)
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" CREATE TABLE [dbo].[" + databaseprefix + "Forum_Post_#](");
            sb.AppendFormat("	[Id] [int] NOT NULL,");
            sb.AppendFormat("	[BoardId] [int] NOT NULL,");
            sb.AppendFormat("	[TopicId] [int] NOT NULL,");
            sb.AppendFormat("	[PostUserId] [int] NOT NULL,");
            sb.AppendFormat("	[PostUsername] [nvarchar](64) NOT NULL,");
            sb.AppendFormat("	[PostNickname] [nvarchar](50) NOT NULL,");
            sb.AppendFormat("	[PostUserIp] [nvarchar](32) NOT NULL,");
            sb.AppendFormat("	[PostDateTime] [datetime] NOT NULL,");
            sb.AppendFormat("	[Title] [nvarchar](64) NOT NULL,");
            sb.AppendFormat("	[Message] [ntext] NOT NULL,");
            sb.AppendFormat("	[HTML] [tinyint] NOT NULL,");
            sb.AppendFormat("	[Smile] [tinyint] NOT NULL,");
            sb.AppendFormat("	[UBB] [tinyint] NOT NULL,");
            sb.AppendFormat("	[Attachment] [int] NOT NULL,");
            sb.AppendFormat("	[Signature] [tinyint] NOT NULL,");
            sb.AppendFormat("	[Url] [tinyint] NOT NULL,");
            sb.AppendFormat("	[Audit] [tinyint] NOT NULL,");
            sb.AppendFormat("	[First] [tinyint] NOT NULL,");
            sb.AppendFormat("	[Invisible] [tinyint] NOT NULL,");
            sb.AppendFormat("	[Ban] [tinyint] NOT NULL,");
            sb.AppendFormat("	[Grade] [int] NOT NULL,");
            sb.AppendFormat("	[Hide] [tinyint] NOT NULL,");
            sb.AppendFormat("	[UpdateUserId] [int] NOT NULL,");
            sb.AppendFormat("	[UpdateUsername] [nvarchar](32) NOT NULL,");
            sb.AppendFormat("	[UpdateNickname] [nvarchar](50) NOT NULL,");
            sb.AppendFormat("	[UpdateTime] [datetime] NOT NULL,");
            sb.AppendFormat("	[Support] [int] NOT NULL,");
            sb.AppendFormat("	[Against] [int] NOT NULL,");
            sb.AppendFormat("	[QuoteUserId] [int] NOT NULL,");
            sb.AppendFormat("	[QuoteMessage] [ntext] NOT NULL,");
            sb.AppendFormat("	[QuoteNickname] [nvarchar](50) NOT NULL,");
            sb.AppendFormat("	[QuotePostIds] [nvarchar](50) NOT NULL,");            
            sb.AppendFormat(" CONSTRAINT [PK_" + databaseprefix + "Forum_Post_#] PRIMARY KEY CLUSTERED ");
            sb.AppendFormat("(");
            sb.AppendFormat("	[Id] ASC");
            sb.AppendFormat(")WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]");
            sb.AppendFormat(") ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]");
            sb.AppendFormat("");
            sb.AppendFormat(" ; ");
            sb.AppendFormat("");
            sb.AppendFormat(" ALTER TABLE [dbo].[" + databaseprefix + "Forum_Post_#] ADD  CONSTRAINT [DF_" + databaseprefix + "Forum_Post_#_Support]  DEFAULT ((0)) FOR [Support]");
            sb.AppendFormat(" ; ");
            sb.AppendFormat("");
            sb.AppendFormat(" ALTER TABLE [dbo].[" + databaseprefix + "Forum_Post_#] ADD  CONSTRAINT [DF_" + databaseprefix + "Forum_Post_#_Against]  DEFAULT ((0)) FOR [Against]");
            sb.AppendFormat(" ; ");

            string strSql = sb.ToString().Replace("#", _id.ToString());

            DbHelperSQL.ExecuteSql(strSql);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.Forum_PostSubTable model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "Forum_PostSubTable set ");

            strSql.Append(" Name = @Name , ");
            strSql.Append(" Description = @Description , ");
            strSql.Append(" TopicCount = @TopicCount , ");
            strSql.Append(" PostCount = @PostCount , ");
            strSql.Append(" CreateDateTime = @CreateDateTime , ");
            strSql.Append(" Avail = @Avail , ");
            strSql.Append(" RecyclePost = @RecyclePost , ");
            strSql.Append(" UnauditedPost = @UnauditedPost  ");
            strSql.Append(" where Id=@Id ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Name", SqlDbType.NVarChar,32) ,            
                        new SqlParameter("@Description", SqlDbType.NVarChar,512) ,            
                        new SqlParameter("@TopicCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@PostCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@CreateDateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Avail", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@RecyclePost", SqlDbType.Int,4) ,            
                        new SqlParameter("@UnauditedPost", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.Description;
            parameters[3].Value = model.TopicCount;
            parameters[4].Value = model.PostCount;
            parameters[5].Value = model.CreateDateTime;
            parameters[6].Value = model.Avail;
            parameters[7].Value = model.RecyclePost;
            parameters[8].Value = model.UnauditedPost;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                UpdateAvail(model.Id, model.Avail);

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
            strSql.Append("update " + databaseprefix + "Forum_PostSubTable set " + strValue);
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
            strSql.Append("delete from " + databaseprefix + "Forum_PostSubTable ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

            if (rows > 0)
            {

                DbHelperSQL.ExecuteSql(" if object_id(N'" + databaseprefix + "Forum_Post_" + Id + "',N'U') is not null drop table  " + databaseprefix + "Forum_Post_" + Id);

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
            strSql.Append("delete from " + databaseprefix + "Forum_PostSubTable ");
            strSql.Append(" where ID in (" + Idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                string[] strId = Idlist.Split(',');

                for (int i = 0; i < strId.Length; i++)
                {
                    DbHelperSQL.ExecuteSql(" if object_id(N'" + databaseprefix + "Forum_Post_" + strId[i] + "',N'U') is not null drop table  " + databaseprefix + "Forum_Post_" + strId[i]);
                }

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
        public Model.Forum_PostSubTable GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select " + column);
            strSql.Append("  from " + databaseprefix + "Forum_PostSubTable ");
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
        public Model.Forum_PostSubTable GetModel(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 " + column);
            strSql.Append("  from " + databaseprefix + "Forum_PostSubTable ");
            strSql.Append(" where " + where);

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
        public Model.Forum_PostSubTable DataRowToModel(DataRow row)
        {

            if (row != null)
            {
                Model.Forum_PostSubTable model = new Model.Forum_PostSubTable();

                if (row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                model.Name = row["Name"].ToString();
                model.Description = row["Description"].ToString();
                if (row["TopicCount"].ToString() != "")
                {
                    model.TopicCount = int.Parse(row["TopicCount"].ToString());
                }
                if (row["PostCount"].ToString() != "")
                {
                    model.PostCount = int.Parse(row["PostCount"].ToString());
                }
                if (row["CreateDateTime"].ToString() != "")
                {
                    model.CreateDateTime = DateTime.Parse(row["CreateDateTime"].ToString());
                }
                if (row["Avail"].ToString() != "")
                {
                    model.Avail = int.Parse(row["Avail"].ToString());
                }
                if (row["RecyclePost"].ToString() != "")
                {
                    model.RecyclePost = int.Parse(row["RecyclePost"].ToString());
                }
                if (row["UnauditedPost"].ToString() != "")
                {
                    model.UnauditedPost = int.Parse(row["UnauditedPost"].ToString());
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
            row["Name"] = dr[i]["Name"].ToString();
            row["Description"] = dr[i]["Description"].ToString();

            row["TopicCount"] = int.Parse(dr[i]["TopicCount"].ToString());

            row["PostCount"] = int.Parse(dr[i]["PostCount"].ToString());

            row["CreateDateTime"] = DateTime.Parse(dr[i]["CreateDateTime"].ToString());

            row["Avail"] = int.Parse(dr[i]["Avail"].ToString());

            row["RecyclePost"] = int.Parse(dr[i]["RecyclePost"].ToString());

            row["UnauditedPost"] = int.Parse(dr[i]["UnauditedPost"].ToString());


        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM " + databaseprefix + "Forum_PostSubTable ");
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
            strSql.Append(" FROM " + databaseprefix + "Forum_PostSubTable ");
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
            strSql.Append("select * FROM " + databaseprefix + "Forum_PostSubTable ");
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

