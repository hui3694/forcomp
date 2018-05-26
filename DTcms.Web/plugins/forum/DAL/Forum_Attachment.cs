using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using DTcms.DBUtility;
using DTcms.Common;
namespace DTcms.Web.Plugin.Forum.DAL
{
    //dt_Forum_Attachment
        //------------------------------------------------------
    // 插件官方地址 www.dtcms-forum.net
    // 本插件开源，支持个人对插件源码修改及非盈利性平台使用
    // 如用于商业盈利性平台，需支付授权费,具体参见官网
    // 我们承接新项目开发或插件二次开发 QQ 271478027
    //------------------------------------------------------
    public partial class Forum_Attachment
    {
        private string databaseprefix; //数据库表名前缀
        private string column;
        public Forum_Attachment(string _databaseprefix)
        {
            databaseprefix = _databaseprefix;
            this.column = " Id, UserId, BoardId, TopicId, PostId, UploadDatetime, Name, FileName, Description, FileType, FileSize, IsImage, Thumb, Download, Cost, CostType  ";
        }
        #region 基本方法================================
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "Forum_Attachment");
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
            strSql.Append(" from " + databaseprefix + "Forum_Attachment");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.Forum_Attachment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + databaseprefix + "Forum_Attachment(");
            strSql.Append("UserId,BoardId,TopicId,PostId,UploadDatetime,Name,FileName,Description,FileType,FileSize,IsImage,Thumb,Download,Cost,CostType");
            strSql.Append(") values (");
            strSql.Append("@UserId,@BoardId,@TopicId,@PostId,@UploadDatetime,@Name,@FileName,@Description,@FileType,@FileSize,@IsImage,@Thumb,@Download,@Cost,@CostType");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@UserId", SqlDbType.Int,4) ,            
                        new SqlParameter("@BoardId", SqlDbType.Int,4) ,            
                        new SqlParameter("@TopicId", SqlDbType.Int,4) ,            
                        new SqlParameter("@PostId", SqlDbType.Int,4) ,            
                        new SqlParameter("@UploadDatetime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Name", SqlDbType.NVarChar,256) ,            
                        new SqlParameter("@FileName", SqlDbType.NVarChar,256) ,            
                        new SqlParameter("@Description", SqlDbType.NVarChar,128) ,            
                        new SqlParameter("@FileType", SqlDbType.NVarChar,64) ,            
                        new SqlParameter("@FileSize", SqlDbType.Int,4) ,            
                        new SqlParameter("@IsImage", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@Thumb", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@Download", SqlDbType.Int,4) ,            
                        new SqlParameter("@Cost", SqlDbType.Money,8) ,            
                        new SqlParameter("@CostType", SqlDbType.TinyInt,1)             
              
            };

            parameters[0].Value = model.UserId;
            parameters[1].Value = model.BoardId;
            parameters[2].Value = model.TopicId;
            parameters[3].Value = model.PostId;
            parameters[4].Value = model.UploadDatetime;
            parameters[5].Value = model.Name;
            parameters[6].Value = model.FileName;
            parameters[7].Value = model.Description;
            parameters[8].Value = model.FileType;
            parameters[9].Value = model.FileSize;
            parameters[10].Value = model.IsImage;
            parameters[11].Value = model.Thumb;
            parameters[12].Value = model.Download;
            parameters[13].Value = model.Cost;
            parameters[14].Value = model.CostType;

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
        public bool Update(Model.Forum_Attachment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "Forum_Attachment set ");

            strSql.Append(" UserId = @UserId , ");
            strSql.Append(" BoardId = @BoardId , ");
            strSql.Append(" TopicId = @TopicId , ");
            strSql.Append(" PostId = @PostId , ");
            strSql.Append(" UploadDatetime = @UploadDatetime , ");
            strSql.Append(" Name = @Name , ");
            strSql.Append(" FileName = @FileName , ");
            strSql.Append(" Description = @Description , ");
            strSql.Append(" FileType = @FileType , ");
            strSql.Append(" FileSize = @FileSize , ");
            strSql.Append(" IsImage = @IsImage , ");
            strSql.Append(" Thumb = @Thumb , ");
            strSql.Append(" Download = @Download , ");
            strSql.Append(" Cost = @Cost , ");
            strSql.Append(" CostType = @CostType  ");
            strSql.Append(" where Id=@Id ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@UserId", SqlDbType.Int,4) ,            
                        new SqlParameter("@BoardId", SqlDbType.Int,4) ,            
                        new SqlParameter("@TopicId", SqlDbType.Int,4) ,            
                        new SqlParameter("@PostId", SqlDbType.Int,4) ,            
                        new SqlParameter("@UploadDatetime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Name", SqlDbType.NVarChar,256) ,            
                        new SqlParameter("@FileName", SqlDbType.NVarChar,256) ,            
                        new SqlParameter("@Description", SqlDbType.NVarChar,128) ,            
                        new SqlParameter("@FileType", SqlDbType.NVarChar,64) ,            
                        new SqlParameter("@FileSize", SqlDbType.Int,4) ,            
                        new SqlParameter("@IsImage", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@Thumb", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@Download", SqlDbType.Int,4) ,            
                        new SqlParameter("@Cost", SqlDbType.Money,8) ,            
                        new SqlParameter("@CostType", SqlDbType.TinyInt,1)             
              
            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.UserId;
            parameters[2].Value = model.BoardId;
            parameters[3].Value = model.TopicId;
            parameters[4].Value = model.PostId;
            parameters[5].Value = model.UploadDatetime;
            parameters[6].Value = model.Name;
            parameters[7].Value = model.FileName;
            parameters[8].Value = model.Description;
            parameters[9].Value = model.FileType;
            parameters[10].Value = model.FileSize;
            parameters[11].Value = model.IsImage;
            parameters[12].Value = model.Thumb;
            parameters[13].Value = model.Download;
            parameters[14].Value = model.Cost;
            parameters[15].Value = model.CostType;
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
            strSql.Append("update " + databaseprefix + "Forum_Attachment set " + strValue);
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
        public int UpdateField(string strWhere, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "Forum_Attachment set " + strValue);
            strSql.Append(" ");

            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());

            return rows;
                      
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "Forum_Attachment ");
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
            strSql.Append("delete from " + databaseprefix + "Forum_Attachment ");
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
        public Model.Forum_Attachment GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select " + column);
            strSql.Append("  from " + databaseprefix + "Forum_Attachment ");
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
        public Model.Forum_Attachment DataRowToModel(DataRow row)
        {

            if (row != null)
            {
                Model.Forum_Attachment model = new Model.Forum_Attachment();

                if (row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["UserId"].ToString() != "")
                {
                    model.UserId = int.Parse(row["UserId"].ToString());
                }
                if (row["BoardId"].ToString() != "")
                {
                    model.BoardId = int.Parse(row["BoardId"].ToString());
                }
                if (row["TopicId"].ToString() != "")
                {
                    model.TopicId = int.Parse(row["TopicId"].ToString());
                }
                if (row["PostId"].ToString() != "")
                {
                    model.PostId = int.Parse(row["PostId"].ToString());
                }
                if (row["UploadDatetime"].ToString() != "")
                {
                    model.UploadDatetime = DateTime.Parse(row["UploadDatetime"].ToString());
                }
                model.Name = row["Name"].ToString();
                model.FileName = row["FileName"].ToString();
                model.Description = row["Description"].ToString();
                model.FileType = row["FileType"].ToString();
                if (row["FileSize"].ToString() != "")
                {
                    model.FileSize = int.Parse(row["FileSize"].ToString());
                }
                if (row["IsImage"].ToString() != "")
                {
                    model.IsImage = int.Parse(row["IsImage"].ToString());
                }
                if (row["Thumb"].ToString() != "")
                {
                    model.Thumb = int.Parse(row["Thumb"].ToString());
                }
                if (row["Download"].ToString() != "")
                {
                    model.Download = int.Parse(row["Download"].ToString());
                }
                if (row["Cost"].ToString() != "")
                {
                    model.Cost = decimal.Parse(row["Cost"].ToString());
                }
                if (row["CostType"].ToString() != "")
                {
                    model.CostType = int.Parse(row["CostType"].ToString());
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

            row["UserId"] = int.Parse(dr[i]["UserId"].ToString());

            row["BoardId"] = int.Parse(dr[i]["BoardId"].ToString());

            row["TopicId"] = int.Parse(dr[i]["TopicId"].ToString());

            row["PostId"] = int.Parse(dr[i]["PostId"].ToString());

            row["UploadDatetime"] = DateTime.Parse(dr[i]["UploadDatetime"].ToString());
            row["Name"] = dr[i]["Name"].ToString();
            row["FileName"] = dr[i]["FileName"].ToString();
            row["Description"] = dr[i]["Description"].ToString();
            row["FileType"] = dr[i]["FileType"].ToString();

            row["FileSize"] = int.Parse(dr[i]["FileSize"].ToString());

            row["IsImage"] = int.Parse(dr[i]["IsImage"].ToString());

            row["Thumb"] = int.Parse(dr[i]["Thumb"].ToString());

            row["Download"] = int.Parse(dr[i]["Download"].ToString());

            row["Cost"] = decimal.Parse(dr[i]["Cost"].ToString());

            row["CostType"] = int.Parse(dr[i]["CostType"].ToString());


        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM " + databaseprefix + "Forum_Attachment ");
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
            strSql.Append(" FROM " + databaseprefix + "Forum_Attachment ");
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
            strSql.Append("select * FROM " + databaseprefix + "Forum_Attachment ");
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

