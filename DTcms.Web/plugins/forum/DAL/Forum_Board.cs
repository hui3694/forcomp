using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using DTcms.DBUtility;
using DTcms.Common;
namespace DTcms.Web.Plugin.Forum.DAL
{
    //dt_Forum_Board
        //------------------------------------------------------
    // 插件官方地址 www.dtcms-forum.net
    // 本插件开源，支持个人对插件源码修改及非盈利性平台使用
    // 如用于商业盈利性平台，需支付授权费,具体参见官网
    // 我们承接新项目开发或插件二次开发 QQ 271478027
    //------------------------------------------------------
    public partial class Forum_Board
    {
        private string databaseprefix; //数据库表名前缀
        private string column;
        public Forum_Board(string _databaseprefix)
        {
            databaseprefix = _databaseprefix;
            this.column = " Id, PostCount, CreateTime, UpdateTime, Icon, [Rule], Description, ChildCol, LastPostUserId, LastPostUsername, LastPostNickname, ParentId, LastTopicId, LastTopicTitle, Url, Show, ClassList, ClassLayer, SortId, LeftNumber, RightNumber, Layer, ChildCount, Name, TodayTopicCount, TopicCount  ";
        }
        #region 基本方法================================
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "Forum_Board");
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
            strSql.Append(" from " + databaseprefix + "Forum_Board");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.Forum_Board model)
        {
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {

                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("insert into " + databaseprefix + "Forum_Board(");
                        strSql.Append("PostCount,CreateTime,UpdateTime,Icon,[Rule],Description,ChildCol,LastPostUserId,LastPostUsername,LastPostNickname,ParentId,LastTopicId,LastTopicTitle,Url,Show,ClassList,ClassLayer,SortId,LeftNumber,RightNumber,Layer,ChildCount,Name,TodayTopicCount,TopicCount");
                        strSql.Append(") values (");
                        strSql.Append("@PostCount,@CreateTime,@UpdateTime,@Icon,@Rule,@Description,@ChildCol,@LastPostUserId,@LastPostUsername,@LastPostNickname,@ParentId,@LastTopicId,@LastTopicTitle,@Url,@Show,@ClassList,@ClassLayer,@SortId,@LeftNumber,@RightNumber,@Layer,@ChildCount,@Name,@TodayTopicCount,@TopicCount");
                        strSql.Append(") ");
                        strSql.Append(";select @@IDENTITY");
                        SqlParameter[] parameters = {
			            new SqlParameter("@PostCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@CreateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@UpdateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Icon", SqlDbType.NVarChar,256) ,            
                        new SqlParameter("@Rule", SqlDbType.NText) ,            
                        new SqlParameter("@Description", SqlDbType.NText) ,            
                        new SqlParameter("@ChildCol", SqlDbType.SmallInt,2) ,            
                        new SqlParameter("@LastPostUserId", SqlDbType.Int,4) ,            
                        new SqlParameter("@LastPostUsername", SqlDbType.NVarChar,32) ,            
                        new SqlParameter("@LastPostNickname", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@ParentId", SqlDbType.Int,4) ,            
                        new SqlParameter("@LastTopicId", SqlDbType.Int,4) ,            
                        new SqlParameter("@LastTopicTitle", SqlDbType.NVarChar,64) ,            
                        new SqlParameter("@Url", SqlDbType.NVarChar,256) ,            
                        new SqlParameter("@Show", SqlDbType.Int,4) ,            
                        new SqlParameter("@ClassList", SqlDbType.NVarChar,255) ,            
                        new SqlParameter("@ClassLayer", SqlDbType.Int,4) ,            
                        new SqlParameter("@SortId", SqlDbType.Int,4) ,            
                        new SqlParameter("@LeftNumber", SqlDbType.Int,4) ,            
                        new SqlParameter("@RightNumber", SqlDbType.Int,4) ,            
                        new SqlParameter("@Layer", SqlDbType.Int,4) ,            
                        new SqlParameter("@ChildCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@Name", SqlDbType.NVarChar,64) ,            
                        new SqlParameter("@TodayTopicCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@TopicCount", SqlDbType.Int,4)             
              
            };

                        parameters[0].Value = model.PostCount;
                        parameters[1].Value = model.CreateTime;
                        parameters[2].Value = model.UpdateTime;
                        parameters[3].Value = model.Icon;
                        parameters[4].Value = model.Rule;
                        parameters[5].Value = model.Description;
                        parameters[6].Value = model.ChildCol;
                        parameters[7].Value = model.LastPostUserId;
                        parameters[8].Value = model.LastPostUsername;
                        parameters[9].Value = model.LastPostNickname;
                        parameters[10].Value = model.ParentId;
                        parameters[11].Value = model.LastTopicId;
                        parameters[12].Value = model.LastTopicTitle;
                        parameters[13].Value = model.Url;
                        parameters[14].Value = model.Show;
                        parameters[15].Value = model.ClassList;
                        parameters[16].Value = model.ClassLayer;
                        parameters[17].Value = model.SortId;
                        parameters[18].Value = model.LeftNumber;
                        parameters[19].Value = model.RightNumber;
                        parameters[20].Value = model.Layer;
                        parameters[21].Value = model.ChildCount;
                        parameters[22].Value = model.Name;
                        parameters[23].Value = model.TodayTopicCount;
                        parameters[24].Value = model.TopicCount;

                        object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);

                        model.Id = Convert.ToInt32(obj);

                        if (model.ParentId > 0)
                        {
                            Model.Forum_Board model2 = GetModel(conn, trans, model.ParentId); //带事务
                            model.ClassList = model2.ClassList + model.Id + ",";
                            model.ClassLayer = model2.ClassLayer + 1;
                        }
                        else
                        {
                            model.ClassList = "," + model.Id + ",";
                            model.ClassLayer = 1;
                        }
                        //修改节点列表和深度
                        DbHelperSQL.ExecuteSql(conn, trans, "update " + databaseprefix + "forum_board set classList='" + model.ClassList + "', classLayer=" + model.ClassLayer + " where id=" + model.Id); //带事务
                        trans.Commit();

                    }
                    catch
                    {
                        trans.Rollback();
                        return 0;
                    }
                }
            }

            UpdateChildCount();

            return model.Id;

        }

        /// <summary>
        /// 内部方法 更新子类总个数
        /// </summary>
        public void UpdateChildCount()
        {

            System.Data.DataTable dt = GetList("1=1").Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string strSql = "UPDATE [" + databaseprefix + "Forum_Board] SET [ChildCount]=(SELECT COUNT(*) FROM [" + databaseprefix + "Forum_Board] WHERE [ParentId]=" + dt.Rows[i]["id"].ToString() + ")  WHERE ID=" + dt.Rows[i]["id"].ToString();

                DbHelperSQL.ExecuteSql(strSql);
            }
        }

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.Forum_Board model)
        {
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        //先判断选中的父节点是否被包含
                        if (IsContainNode(model.Id, model.ParentId))
                        {
                            //查找旧数据
                            Model.Forum_Board oldModel = GetModel(model.Id);
                            //查找旧父节点数据
                            string class_list = "," + model.ParentId + ",";
                            int class_layer = 1;
                            if (oldModel.ParentId > 0)
                            {
                                Model.Forum_Board oldParentModel = GetModel(conn, trans, oldModel.ParentId); //带事务
                                class_list = oldParentModel.ClassList + model.ParentId + ",";
                                class_layer = oldParentModel.ClassLayer + 1;
                            }
                            //先提升选中的父节点
                            DbHelperSQL.ExecuteSql(conn, trans, "update " + databaseprefix + "Forum_Board set ParentId=" + oldModel.ParentId + ",ClassList='" + class_list + "', ClassLayer=" + class_layer + " where id=" + model.ParentId); //带事务
                            UpdateChilds(conn, trans, model.ParentId); //带事务
                        }
                        //更新子节点
                        if (model.ParentId > 0)
                        {
                            Model.Forum_Board model2 = GetModel(conn, trans, model.ParentId); //带事务
                            model.ClassList = model2.ClassList + model.Id + ",";
                            model.ClassLayer = model2.ClassLayer + 1;
                        }
                        else
                        {
                            model.ClassList = "," + model.Id + ",";
                            model.ClassLayer = 1;
                        }

                        UpdateModel(model);

                        //更新子节点
                        UpdateChilds(conn, trans, model.Id);
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        return false;
                    }
                }
            }
            return true;
        }
        #endregion

        /// <summary>
        /// 验证节点是否被包含
        /// </summary>
        /// <param name="id">待查询的节点</param>
        /// <param name="parent_id">父节点</param>
        /// <returns></returns>
        private bool IsContainNode(int id, int parent_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [" + databaseprefix + "Forum_Board] where ClassList like '%," + id + ",%' and id=" + parent_id);
            return DbHelperSQL.Exists(strSql.ToString());
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateModel(Model.Forum_Board model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "Forum_Board set ");

            strSql.Append(" PostCount = @PostCount , ");
            strSql.Append(" CreateTime = @CreateTime , ");
            strSql.Append(" UpdateTime = @UpdateTime , ");
            strSql.Append(" Icon = @Icon , ");
            strSql.Append(" [Rule] = @Rule , ");
            strSql.Append(" Description = @Description , ");
            strSql.Append(" ChildCol = @ChildCol , ");
            strSql.Append(" LastPostUserId = @LastPostUserId , ");
            strSql.Append(" LastPostUsername = @LastPostUsername , ");
            strSql.Append(" LastPostNickname = @LastPostNickname , ");
            strSql.Append(" ParentId = @ParentId , ");
            strSql.Append(" LastTopicId = @LastTopicId , ");
            strSql.Append(" LastTopicTitle = @LastTopicTitle , ");
            strSql.Append(" Url = @Url , ");
            strSql.Append(" Show = @Show , ");
            strSql.Append(" ClassList = @ClassList , ");
            strSql.Append(" ClassLayer = @ClassLayer , ");
            strSql.Append(" SortId = @SortId , ");
            strSql.Append(" LeftNumber = @LeftNumber , ");
            strSql.Append(" RightNumber = @RightNumber , ");
            strSql.Append(" Layer = @Layer , ");
            strSql.Append(" ChildCount = @ChildCount , ");
            strSql.Append(" Name = @Name , ");
            strSql.Append(" TodayTopicCount = @TodayTopicCount , ");
            strSql.Append(" TopicCount = @TopicCount  ");
            strSql.Append(" where Id=@Id ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@PostCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@CreateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@UpdateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Icon", SqlDbType.NVarChar,256) ,            
                        new SqlParameter("@Rule", SqlDbType.NText) ,            
                        new SqlParameter("@Description", SqlDbType.NText) ,            
                        new SqlParameter("@ChildCol", SqlDbType.SmallInt,2) ,            
                        new SqlParameter("@LastPostUserId", SqlDbType.Int,4) ,            
                        new SqlParameter("@LastPostUsername", SqlDbType.NVarChar,32) ,            
                        new SqlParameter("@LastPostNickname", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@ParentId", SqlDbType.Int,4) ,            
                        new SqlParameter("@LastTopicId", SqlDbType.Int,4) ,            
                        new SqlParameter("@LastTopicTitle", SqlDbType.NVarChar,64) ,            
                        new SqlParameter("@Url", SqlDbType.NVarChar,256) ,            
                        new SqlParameter("@Show", SqlDbType.Int,4) ,            
                        new SqlParameter("@ClassList", SqlDbType.NVarChar,255) ,            
                        new SqlParameter("@ClassLayer", SqlDbType.Int,4) ,            
                        new SqlParameter("@SortId", SqlDbType.Int,4) ,            
                        new SqlParameter("@LeftNumber", SqlDbType.Int,4) ,            
                        new SqlParameter("@RightNumber", SqlDbType.Int,4) ,            
                        new SqlParameter("@Layer", SqlDbType.Int,4) ,            
                        new SqlParameter("@ChildCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@Name", SqlDbType.NVarChar,64) ,            
                        new SqlParameter("@TodayTopicCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@TopicCount", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.PostCount;
            parameters[2].Value = model.CreateTime;
            parameters[3].Value = model.UpdateTime;
            parameters[4].Value = model.Icon;
            parameters[5].Value = model.Rule;
            parameters[6].Value = model.Description;
            parameters[7].Value = model.ChildCol;
            parameters[8].Value = model.LastPostUserId;
            parameters[9].Value = model.LastPostUsername;
            parameters[10].Value = model.LastPostNickname;
            parameters[11].Value = model.ParentId;
            parameters[12].Value = model.LastTopicId;
            parameters[13].Value = model.LastTopicTitle;
            parameters[14].Value = model.Url;
            parameters[15].Value = model.Show;
            parameters[16].Value = model.ClassList;
            parameters[17].Value = model.ClassLayer;
            parameters[18].Value = model.SortId;
            parameters[19].Value = model.LeftNumber;
            parameters[20].Value = model.RightNumber;
            parameters[21].Value = model.Layer;
            parameters[22].Value = model.ChildCount;
            parameters[23].Value = model.Name;
            parameters[24].Value = model.TodayTopicCount;
            parameters[25].Value = model.TopicCount;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                UpdateChildCount();
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
            strSql.Append("update " + databaseprefix + "Forum_Board set " + strValue);
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
        /// 修改一列数据
        /// </summary>
        public bool UpdateField(int Id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "Forum_Board set " + strValue);
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
            strSql.Append("delete from " + databaseprefix + "Forum_Board ");
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
            strSql.Append("delete from " + databaseprefix + "Forum_Board ");
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
        public Model.Forum_Board GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select " + column);
            strSql.Append("  from " + databaseprefix + "Forum_Board ");
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
        public Model.Forum_Board DataRowToModel(DataRow row)
        {

            if (row != null)
            {
                Model.Forum_Board model = new Model.Forum_Board();

                if (row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["PostCount"].ToString() != "")
                {
                    model.PostCount = int.Parse(row["PostCount"].ToString());
                }
                if (row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
                }
                if (row["UpdateTime"].ToString() != "")
                {
                    model.UpdateTime = DateTime.Parse(row["UpdateTime"].ToString());
                }
                model.Icon = row["Icon"].ToString();
                model.Rule = row["Rule"].ToString();
                model.Description = row["Description"].ToString();
                if (row["ChildCol"].ToString() != "")
                {
                    model.ChildCol = int.Parse(row["ChildCol"].ToString());
                }
                if (row["LastPostUserId"].ToString() != "")
                {
                    model.LastPostUserId = int.Parse(row["LastPostUserId"].ToString());
                }
                model.LastPostUsername = row["LastPostUsername"].ToString();
                model.LastPostNickname = row["LastPostNickname"].ToString();
                if (row["ParentId"].ToString() != "")
                {
                    model.ParentId = int.Parse(row["ParentId"].ToString());
                }
                if (row["LastTopicId"].ToString() != "")
                {
                    model.LastTopicId = int.Parse(row["LastTopicId"].ToString());
                }
                model.LastTopicTitle = row["LastTopicTitle"].ToString();
                model.Url = row["Url"].ToString();
                if (row["Show"].ToString() != "")
                {
                    model.Show = int.Parse(row["Show"].ToString());
                }
                model.ClassList = row["ClassList"].ToString();
                if (row["ClassLayer"].ToString() != "")
                {
                    model.ClassLayer = int.Parse(row["ClassLayer"].ToString());
                }
                if (row["SortId"].ToString() != "")
                {
                    model.SortId = int.Parse(row["SortId"].ToString());
                }
                if (row["LeftNumber"].ToString() != "")
                {
                    model.LeftNumber = int.Parse(row["LeftNumber"].ToString());
                }
                if (row["RightNumber"].ToString() != "")
                {
                    model.RightNumber = int.Parse(row["RightNumber"].ToString());
                }
                if (row["Layer"].ToString() != "")
                {
                    model.Layer = int.Parse(row["Layer"].ToString());
                }
                if (row["ChildCount"].ToString() != "")
                {
                    model.ChildCount = int.Parse(row["ChildCount"].ToString());
                }
                model.Name = row["Name"].ToString();
                if (row["TodayTopicCount"].ToString() != "")
                {
                    model.TodayTopicCount = int.Parse(row["TodayTopicCount"].ToString());
                }
                if (row["TopicCount"].ToString() != "")
                {
                    model.TopicCount = int.Parse(row["TopicCount"].ToString());
                }

                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM " + databaseprefix + "Forum_Board ");
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
            strSql.Append(" FROM " + databaseprefix + "Forum_Board ");
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
            strSql.Append("select * FROM " + databaseprefix + "Forum_Board ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        /// <summary>
        /// 取得指定类别下的列表
        /// </summary>
        /// <param name="parent_id">父ID</param>
        /// <param name="channel_id">频道ID</param>
        /// <returns></returns>
        public DataTable GetChildList(int parent_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select " + column);
            strSql.Append(" from " + databaseprefix + "forum_board");
            strSql.Append(" where parent_id=" + parent_id + " order by sortId asc,id desc");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            return ds.Tables[0];
        }

        /// <summary>
        /// 取得所有类别列表
        /// </summary>
        /// <param name="parent_id">父ID</param>
        /// <param name="channel_id">频道ID</param>
        /// <returns></returns>
        public DataTable GetAllList(int parent_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select " + column);
            strSql.Append(" from " + databaseprefix + "forum_board");
            strSql.Append(" order by sortId asc,id desc");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            DataTable oldData = ds.Tables[0] as DataTable;
            if (oldData == null)
            {
                return null;
            }
            //复制结构
            DataTable newData = oldData.Clone();
            //调用迭代组合成DAGATABLE
            GetChilds(oldData, newData, parent_id);
            return newData;
        }

        /// <summary>
        ///  
        /// </summary>				
        public void DataRowToRow(DataRow row, DataRow[] dr, int i)
        {

            row["Id"] = int.Parse(dr[i]["Id"].ToString());

            row["PostCount"] = int.Parse(dr[i]["PostCount"].ToString());

            row["CreateTime"] = DateTime.Parse(dr[i]["CreateTime"].ToString());

            row["UpdateTime"] = DateTime.Parse(dr[i]["UpdateTime"].ToString());
            row["Icon"] = dr[i]["Icon"].ToString();
            row["Rule"] = dr[i]["Rule"].ToString();
            row["Description"] = dr[i]["Description"].ToString();

            row["ChildCol"] = int.Parse(dr[i]["ChildCol"].ToString());

            row["LastPostUserId"] = int.Parse(dr[i]["LastPostUserId"].ToString());
            row["LastPostUsername"] = dr[i]["LastPostUsername"].ToString();
            row["LastPostNickname"] = dr[i]["LastPostNickname"].ToString();

            row["ParentId"] = int.Parse(dr[i]["ParentId"].ToString());

            row["LastTopicId"] = int.Parse(dr[i]["LastTopicId"].ToString());
            row["LastTopicTitle"] = dr[i]["LastTopicTitle"].ToString();
            row["Url"] = dr[i]["Url"].ToString();

            row["Show"] = int.Parse(dr[i]["Show"].ToString());
            row["ClassList"] = dr[i]["ClassList"].ToString();

            row["ClassLayer"] = int.Parse(dr[i]["ClassLayer"].ToString());

            row["SortId"] = int.Parse(dr[i]["SortId"].ToString());

            row["LeftNumber"] = int.Parse(dr[i]["LeftNumber"].ToString());

            row["RightNumber"] = int.Parse(dr[i]["RightNumber"].ToString());

            row["Layer"] = int.Parse(dr[i]["Layer"].ToString());

            row["ChildCount"] = int.Parse(dr[i]["ChildCount"].ToString());
            row["Name"] = dr[i]["Name"].ToString();

            row["TodayTopicCount"] = int.Parse(dr[i]["TodayTopicCount"].ToString());

            row["TopicCount"] = int.Parse(dr[i]["TopicCount"].ToString());

        }


        /// <summary>
        /// 从内存中取得所有下级类别列表（自身迭代）
        /// </summary>
        private void GetChilds(DataTable oldData, DataTable newData, int parent_id)
        {
            DataRow[] dr = oldData.Select("parentId=" + parent_id);
            for (int i = 0; i < dr.Length; i++)
            {
                //添加一行数据
                DataRow row = newData.NewRow();

                DataRowToRow(row, dr, i);

                newData.Rows.Add(row);
                //调用自身迭代
                this.GetChilds(oldData, newData, int.Parse(dr[i]["id"].ToString()));
            }
        }

        /// <summary>
        /// 修改子节点的ID列表及深度（自身迭代）
        /// </summary>
        /// <param name="parent_id"></param>
        private void UpdateChilds(SqlConnection conn, SqlTransaction trans, int parent_id)
        {
            //查找父节点信息
            Model.Forum_Board model = GetModel(conn, trans, parent_id);
            if (model != null)
            {
                //查找子节点
                string strSql = "select id from " + databaseprefix + "forum_board where parentId=" + parent_id;
                DataSet ds = DbHelperSQL.Query(conn, trans, strSql); //带事务
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    //修改子节点的ID列表及深度
                    int id = int.Parse(dr["id"].ToString());
                    string class_list = model.ClassList + id + ",";
                    int class_layer = model.ClassLayer + 1;
                    DbHelperSQL.ExecuteSql(conn, trans, "update " + databaseprefix + "forum_board set classList='" + class_list + "', classLayer=" + class_layer + " where id=" + id); //带事务

                    //调用自身迭代
                    this.UpdateChilds(conn, trans, id); //带事务
                }
            }
        }

        /// <summary>
        /// 得到一个对象实体(重载，带事务)
        /// </summary>
        public Model.Forum_Board GetModel(SqlConnection conn, SqlTransaction trans, int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1  " + column);
            strSql.Append(" from " + databaseprefix + "forum_board ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            Model.Forum_Board model = new Model.Forum_Board();
            DataSet ds = DbHelperSQL.Query(conn, trans, strSql.ToString(), parameters);
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


    }
}

