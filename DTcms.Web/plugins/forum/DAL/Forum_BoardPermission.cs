using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using DTcms.DBUtility;
using DTcms.Common;
namespace DTcms.Web.Plugin.Forum.DAL  
{
	 	//dt_Forum_BoardPermission
		public partial class Forum_BoardPermission
	{
		private string databaseprefix; //数据库表名前缀
		private string column;
        public Forum_BoardPermission(string _databaseprefix)
        {
            databaseprefix = _databaseprefix;
            this.column = " Id, BoardId, GroupId, VisitBoard, VisitTopic, PostTopic, PostReply, UploadAttachment, ViewAttachment, UpdateMyselfTopic, UpdateMyselfReply, DeleteMyselfTopic, DeleteMyselfReply, PostBanTopic, ViewBanTopic, RateTopic, RateReply  ";
        }
   		#region 基本方法================================
   		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from "+ databaseprefix +"Forum_BoardPermission");
			strSql.Append(" where ");
			                                       strSql.Append(" Id = @Id  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
		/// <summary>
        /// 返回数据总数
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H ");
            strSql.Append(" from " + databaseprefix + "Forum_BoardPermission");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Model.Forum_BoardPermission model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into " + databaseprefix + "Forum_BoardPermission(");			
            strSql.Append("BoardId,GroupId,VisitBoard,VisitTopic,PostTopic,PostReply,UploadAttachment,ViewAttachment,UpdateMyselfTopic,UpdateMyselfReply,DeleteMyselfTopic,DeleteMyselfReply,PostBanTopic,ViewBanTopic,RateTopic,RateReply");
			strSql.Append(") values (");
            strSql.Append("@BoardId,@GroupId,@VisitBoard,@VisitTopic,@PostTopic,@PostReply,@UploadAttachment,@ViewAttachment,@UpdateMyselfTopic,@UpdateMyselfReply,@DeleteMyselfTopic,@DeleteMyselfReply,@PostBanTopic,@ViewBanTopic,@RateTopic,@RateReply");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@BoardId", SqlDbType.Int,4) ,            
                        new SqlParameter("@GroupId", SqlDbType.Int,4) ,            
                        new SqlParameter("@VisitBoard", SqlDbType.Int,4) ,            
                        new SqlParameter("@VisitTopic", SqlDbType.Int,4) ,            
                        new SqlParameter("@PostTopic", SqlDbType.Int,4) ,            
                        new SqlParameter("@PostReply", SqlDbType.Int,4) ,            
                        new SqlParameter("@UploadAttachment", SqlDbType.Int,4) ,            
                        new SqlParameter("@ViewAttachment", SqlDbType.Int,4) ,            
                        new SqlParameter("@UpdateMyselfTopic", SqlDbType.Int,4) ,            
                        new SqlParameter("@UpdateMyselfReply", SqlDbType.Int,4) ,            
                        new SqlParameter("@DeleteMyselfTopic", SqlDbType.Int,4) ,            
                        new SqlParameter("@DeleteMyselfReply", SqlDbType.Int,4) ,            
                        new SqlParameter("@PostBanTopic", SqlDbType.Int,4) ,            
                        new SqlParameter("@ViewBanTopic", SqlDbType.Int,4) ,            
                        new SqlParameter("@RateTopic", SqlDbType.Int,4) ,            
                        new SqlParameter("@RateReply", SqlDbType.Int,4)             
              
            };
			            
            parameters[0].Value = model.BoardId;                        
            parameters[1].Value = model.GroupId;                        
            parameters[2].Value = model.VisitBoard;                        
            parameters[3].Value = model.VisitTopic;                        
            parameters[4].Value = model.PostTopic;                        
            parameters[5].Value = model.PostReply;                        
            parameters[6].Value = model.UploadAttachment;                        
            parameters[7].Value = model.ViewAttachment;                        
            parameters[8].Value = model.UpdateMyselfTopic;                        
            parameters[9].Value = model.UpdateMyselfReply;                        
            parameters[10].Value = model.DeleteMyselfTopic;                        
            parameters[11].Value = model.DeleteMyselfReply;                        
            parameters[12].Value = model.PostBanTopic;                        
            parameters[13].Value = model.ViewBanTopic;                        
            parameters[14].Value = model.RateTopic;                        
            parameters[15].Value = model.RateReply;                        
			   
			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);			
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
		public bool Update(Model.Forum_BoardPermission model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update " + databaseprefix + "Forum_BoardPermission set ");
			                                                
            strSql.Append(" BoardId = @BoardId , ");                                    
            strSql.Append(" GroupId = @GroupId , ");                                    
            strSql.Append(" VisitBoard = @VisitBoard , ");                                    
            strSql.Append(" VisitTopic = @VisitTopic , ");                                    
            strSql.Append(" PostTopic = @PostTopic , ");                                    
            strSql.Append(" PostReply = @PostReply , ");                                    
            strSql.Append(" UploadAttachment = @UploadAttachment , ");                                    
            strSql.Append(" ViewAttachment = @ViewAttachment , ");                                    
            strSql.Append(" UpdateMyselfTopic = @UpdateMyselfTopic , ");                                    
            strSql.Append(" UpdateMyselfReply = @UpdateMyselfReply , ");                                    
            strSql.Append(" DeleteMyselfTopic = @DeleteMyselfTopic , ");                                    
            strSql.Append(" DeleteMyselfReply = @DeleteMyselfReply , ");                                    
            strSql.Append(" PostBanTopic = @PostBanTopic , ");                                    
            strSql.Append(" ViewBanTopic = @ViewBanTopic , ");                                    
            strSql.Append(" RateTopic = @RateTopic , ");                                    
            strSql.Append(" RateReply = @RateReply  ");            			
			strSql.Append(" where Id=@Id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@BoardId", SqlDbType.Int,4) ,            
                        new SqlParameter("@GroupId", SqlDbType.Int,4) ,            
                        new SqlParameter("@VisitBoard", SqlDbType.Int,4) ,            
                        new SqlParameter("@VisitTopic", SqlDbType.Int,4) ,            
                        new SqlParameter("@PostTopic", SqlDbType.Int,4) ,            
                        new SqlParameter("@PostReply", SqlDbType.Int,4) ,            
                        new SqlParameter("@UploadAttachment", SqlDbType.Int,4) ,            
                        new SqlParameter("@ViewAttachment", SqlDbType.Int,4) ,            
                        new SqlParameter("@UpdateMyselfTopic", SqlDbType.Int,4) ,            
                        new SqlParameter("@UpdateMyselfReply", SqlDbType.Int,4) ,            
                        new SqlParameter("@DeleteMyselfTopic", SqlDbType.Int,4) ,            
                        new SqlParameter("@DeleteMyselfReply", SqlDbType.Int,4) ,            
                        new SqlParameter("@PostBanTopic", SqlDbType.Int,4) ,            
                        new SqlParameter("@ViewBanTopic", SqlDbType.Int,4) ,            
                        new SqlParameter("@RateTopic", SqlDbType.Int,4) ,            
                        new SqlParameter("@RateReply", SqlDbType.Int,4)             
              
            };
						            
            parameters[0].Value = model.Id;                        
            parameters[1].Value = model.BoardId;                        
            parameters[2].Value = model.GroupId;                        
            parameters[3].Value = model.VisitBoard;                        
            parameters[4].Value = model.VisitTopic;                        
            parameters[5].Value = model.PostTopic;                        
            parameters[6].Value = model.PostReply;                        
            parameters[7].Value = model.UploadAttachment;                        
            parameters[8].Value = model.ViewAttachment;                        
            parameters[9].Value = model.UpdateMyselfTopic;                        
            parameters[10].Value = model.UpdateMyselfReply;                        
            parameters[11].Value = model.DeleteMyselfTopic;                        
            parameters[12].Value = model.DeleteMyselfReply;                        
            parameters[13].Value = model.PostBanTopic;                        
            parameters[14].Value = model.ViewBanTopic;                        
            parameters[15].Value = model.RateTopic;                        
            parameters[16].Value = model.RateReply;                        
            int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
            strSql.Append("update " + databaseprefix + "Forum_BoardPermission set " + strValue);
            strSql.Append(" where Id=@Id");
            			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

            int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from " + databaseprefix + "Forum_BoardPermission ");
			strSql.Append(" where Id=@Id");
						SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;


			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string Idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from " + databaseprefix + "Forum_BoardPermission ");
			strSql.Append(" where ID in ("+Idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public Model.Forum_BoardPermission GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + column);			
			strSql.Append("  from " + databaseprefix + "Forum_BoardPermission ");
			strSql.Append(" where Id=@Id");
						SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;
			
			
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
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
        public Model.Forum_BoardPermission GetModel(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select " + column);
            strSql.Append("  from " + databaseprefix + "Forum_BoardPermission ");
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
		public Model.Forum_BoardPermission DataRowToModel(DataRow row)		
		{
			
            if (row != null)
            {
            	Model.Forum_BoardPermission model = new Model.Forum_BoardPermission();
            
												if(row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
																																if(row["BoardId"].ToString()!="")
				{
					model.BoardId=int.Parse(row["BoardId"].ToString());
				}
																																if(row["GroupId"].ToString()!="")
				{
					model.GroupId=int.Parse(row["GroupId"].ToString());
				}
																																if(row["VisitBoard"].ToString()!="")
				{
					model.VisitBoard=int.Parse(row["VisitBoard"].ToString());
				}
																																if(row["VisitTopic"].ToString()!="")
				{
					model.VisitTopic=int.Parse(row["VisitTopic"].ToString());
				}
																																if(row["PostTopic"].ToString()!="")
				{
					model.PostTopic=int.Parse(row["PostTopic"].ToString());
				}
																																if(row["PostReply"].ToString()!="")
				{
					model.PostReply=int.Parse(row["PostReply"].ToString());
				}
																																if(row["UploadAttachment"].ToString()!="")
				{
					model.UploadAttachment=int.Parse(row["UploadAttachment"].ToString());
				}
																																if(row["ViewAttachment"].ToString()!="")
				{
					model.ViewAttachment=int.Parse(row["ViewAttachment"].ToString());
				}
																																if(row["UpdateMyselfTopic"].ToString()!="")
				{
					model.UpdateMyselfTopic=int.Parse(row["UpdateMyselfTopic"].ToString());
				}
																																if(row["UpdateMyselfReply"].ToString()!="")
				{
					model.UpdateMyselfReply=int.Parse(row["UpdateMyselfReply"].ToString());
				}
																																if(row["DeleteMyselfTopic"].ToString()!="")
				{
					model.DeleteMyselfTopic=int.Parse(row["DeleteMyselfTopic"].ToString());
				}
																																if(row["DeleteMyselfReply"].ToString()!="")
				{
					model.DeleteMyselfReply=int.Parse(row["DeleteMyselfReply"].ToString());
				}
																																if(row["PostBanTopic"].ToString()!="")
				{
					model.PostBanTopic=int.Parse(row["PostBanTopic"].ToString());
				}
																																if(row["ViewBanTopic"].ToString()!="")
				{
					model.ViewBanTopic=int.Parse(row["ViewBanTopic"].ToString());
				}
																																if(row["RateTopic"].ToString()!="")
				{
					model.RateTopic=int.Parse(row["RateTopic"].ToString());
				}
																																if(row["RateReply"].ToString()!="")
				{
					model.RateReply=int.Parse(row["RateReply"].ToString());
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
		public void DataRowToRow(DataRow row, DataRow[] dr,int i)	
		{
			
            
                       
												
					row["Id"]=int.Parse(dr[i]["Id"].ToString());				
																																
					row["BoardId"]=int.Parse(dr[i]["BoardId"].ToString());				
																																
					row["GroupId"]=int.Parse(dr[i]["GroupId"].ToString());				
																																
					row["VisitBoard"]=int.Parse(dr[i]["VisitBoard"].ToString());				
																																
					row["VisitTopic"]=int.Parse(dr[i]["VisitTopic"].ToString());				
																																
					row["PostTopic"]=int.Parse(dr[i]["PostTopic"].ToString());				
																																
					row["PostReply"]=int.Parse(dr[i]["PostReply"].ToString());				
																																
					row["UploadAttachment"]=int.Parse(dr[i]["UploadAttachment"].ToString());				
																																
					row["ViewAttachment"]=int.Parse(dr[i]["ViewAttachment"].ToString());				
																																
					row["UpdateMyselfTopic"]=int.Parse(dr[i]["UpdateMyselfTopic"].ToString());				
																																
					row["UpdateMyselfReply"]=int.Parse(dr[i]["UpdateMyselfReply"].ToString());				
																																
					row["DeleteMyselfTopic"]=int.Parse(dr[i]["DeleteMyselfTopic"].ToString());				
																																
					row["DeleteMyselfReply"]=int.Parse(dr[i]["DeleteMyselfReply"].ToString());				
																																
					row["PostBanTopic"]=int.Parse(dr[i]["PostBanTopic"].ToString());				
																																
					row["ViewBanTopic"]=int.Parse(dr[i]["ViewBanTopic"].ToString());				
																																
					row["RateTopic"]=int.Parse(dr[i]["RateTopic"].ToString());				
																																
					row["RateReply"]=int.Parse(dr[i]["RateReply"].ToString());				
																														
			
		}
		
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM " + databaseprefix + "Forum_BoardPermission ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" * ");
			strSql.Append(" FROM " + databaseprefix + "Forum_BoardPermission ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
            strSql.Append("select * FROM " + databaseprefix + "Forum_BoardPermission ");
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

