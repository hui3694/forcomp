using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using DTcms.DBUtility;
using DTcms.Common;
namespace DTcms.Web.Plugin.Forum.DAL  
{
	 	//dt_Forum_Medal
		    //------------------------------------------------------
    // 插件官方地址 www.dtcms-forum.net
    // 本插件开源，支持个人对插件源码修改及非盈利性平台使用
    // 如用于商业盈利性平台，需支付授权费,具体参见官网
    // 我们承接新项目开发或插件二次开发 QQ 271478027
    //------------------------------------------------------
    public partial class Forum_Medal
	{
		private string databaseprefix; //数据库表名前缀
		private string column;
        public Forum_Medal(string _databaseprefix)
        {
            databaseprefix = _databaseprefix;
            this.column = " Id, Name, Image, Description, Url, Available  ";
        }
   		#region 基本方法================================
   		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from "+ databaseprefix +"Forum_Medal");
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
            strSql.Append(" from " + databaseprefix + "Forum_Medal");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Model.Forum_Medal model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into " + databaseprefix + "Forum_Medal(");			
            strSql.Append("Name,Image,Description,Url,Available");
			strSql.Append(") values (");
            strSql.Append("@Name,@Image,@Description,@Url,@Available");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@Name", SqlDbType.NVarChar,128) ,            
                        new SqlParameter("@Image", SqlDbType.NVarChar,256) ,            
                        new SqlParameter("@Description", SqlDbType.NVarChar,256) ,            
                        new SqlParameter("@Url", SqlDbType.NVarChar,256) ,            
                        new SqlParameter("@Available", SqlDbType.TinyInt,1)             
              
            };
			            
            parameters[0].Value = model.Name;                        
            parameters[1].Value = model.Image;                        
            parameters[2].Value = model.Description;                        
            parameters[3].Value = model.Url;                        
            parameters[4].Value = model.Available;                        
			   
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
		public bool Update(Model.Forum_Medal model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update " + databaseprefix + "Forum_Medal set ");
			                                                
            strSql.Append(" Name = @Name , ");                                    
            strSql.Append(" Image = @Image , ");                                    
            strSql.Append(" Description = @Description , ");                                    
            strSql.Append(" Url = @Url , ");                                    
            strSql.Append(" Available = @Available  ");            			
			strSql.Append(" where Id=@Id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Name", SqlDbType.NVarChar,128) ,            
                        new SqlParameter("@Image", SqlDbType.NVarChar,256) ,            
                        new SqlParameter("@Description", SqlDbType.NVarChar,256) ,            
                        new SqlParameter("@Url", SqlDbType.NVarChar,256) ,            
                        new SqlParameter("@Available", SqlDbType.TinyInt,1)             
              
            };
						            
            parameters[0].Value = model.Id;                        
            parameters[1].Value = model.Name;                        
            parameters[2].Value = model.Image;                        
            parameters[3].Value = model.Description;                        
            parameters[4].Value = model.Url;                        
            parameters[5].Value = model.Available;                        
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
            strSql.Append("update " + databaseprefix + "Forum_Medal set " + strValue);
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
			strSql.Append("delete from " + databaseprefix + "Forum_Medal ");
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
			strSql.Append("delete from " + databaseprefix + "Forum_Medal ");
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
		public Model.Forum_Medal GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + column);			
			strSql.Append("  from " + databaseprefix + "Forum_Medal ");
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
		public Model.Forum_Medal DataRowToModel(DataRow row)		
		{
			
            if (row != null)
            {
            	Model.Forum_Medal model = new Model.Forum_Medal();
            
												if(row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
																																				model.Name= row["Name"].ToString();
																																model.Image= row["Image"].ToString();
																																model.Description= row["Description"].ToString();
																																model.Url= row["Url"].ToString();
																												if(row["Available"].ToString()!="")
				{
					model.Available=int.Parse(row["Available"].ToString());
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
																																				row["Name"]= dr[i]["Name"].ToString();
																																row["Image"]= dr[i]["Image"].ToString();
																																row["Description"]= dr[i]["Description"].ToString();
																																row["Url"]= dr[i]["Url"].ToString();
																												
					row["Available"]=int.Parse(dr[i]["Available"].ToString());				
																														
			
		}
		
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM " + databaseprefix + "Forum_Medal ");
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
			strSql.Append(" FROM " + databaseprefix + "Forum_Medal ");
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
            strSql.Append("select * FROM " + databaseprefix + "Forum_Medal ");
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

