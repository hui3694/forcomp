using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using DTcms.Common;

namespace DTcms.Web.Plugin.Forum.BLL {
	 	//dt_Forum_Board
		    //------------------------------------------------------
    // 插件官方地址 www.dtcms-forum.net
    // 本插件开源，支持个人对插件源码修改及非盈利性平台使用
    // 如用于商业盈利性平台，需支付授权费,具体参见官网
    // 我们承接新项目开发或插件二次开发 QQ 271478027
    //------------------------------------------------------
    public partial class Forum_Board
	{
   		private readonly  DTcms.Model.siteconfig siteConfig = new  DTcms.BLL.siteconfig().loadConfig(); //获得站点配置信息     
		private readonly DAL.Forum_Board dal;
		public Forum_Board()
		{
			dal=new DAL.Forum_Board(siteConfig.sysdatabaseprefix);
		}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			return dal.Exists(Id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Model.Forum_Board model)
		{
						return dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.Forum_Board model)
		{
			return dal.Update(model);
		}
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool UpdateField(int id, string strValue)
		{
			return dal.UpdateField(id,strValue);
		}

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateField(string strWhere, string strValue)
        {
            return dal.UpdateField(strWhere, strValue);
        }		

		/// <summary>
		/// 删除一条数据，所有标题和回贴都清掉
		/// </summary>
		public bool Delete(int Id)
		{
			//循环清除

            BLL.Forum_Topic bllTopic = new Forum_Topic();

            List<Model.Forum_Topic> listTopic = new BLL.Forum_Topic().GetModelList(" 1=1 ");

            foreach (Model.Forum_Topic item in listTopic)
            {
                bllTopic.Delete(item.Id);
            }

			return dal.Delete(Id);
		}
				/// <summary>
		/// 批量删除一批数据
		/// </summary>
		public bool DeleteList(string Idlist )
		{
			return dal.DeleteList(Idlist );
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.Forum_Board GetModel(int Id)
		{
			
			return dal.GetModel(Id);
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public Model.Forum_Board DataRowToModel(DataRow row)
        {
            return dal.DataRowToModel(row);
        }

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Model.Forum_Board GetModelByCache(int Id)
		{			
			string CacheKey = "Forum_BoardModel-" + Id;
			object objModel = DTcms.Common.CacheHelper.Get(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(Id);
                    if (objModel != null)
                    {
                        DTcms.Common.CacheHelper.Insert(CacheKey,objModel,180);
                    }
                }
                catch 
                {
                }
            }
            return (Model.Forum_Board)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Model.Forum_Board> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Model.Forum_Board> DataTableToList(DataTable dt)
		{
			List<Model.Forum_Board> modelList = new List<Model.Forum_Board>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Model.Forum_Board model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
				
					modelList.Add(model);
				}
			}
			return modelList;
		}

        /// <summary>
        /// 取得该频道指定类别下的列表
        /// </summary>
        /// <param name="parent_id">父ID</param>
        /// <param name="channel_id">频道ID</param>
        /// <returns></returns>
        public DataTable GetChildList(int parent_id)
        {
            return dal.GetChildList(parent_id);
        }

        /// <summary>
        /// 取得该频道下所有类别列表
        /// </summary>
        /// <param name="parent_id">父ID</param>
        /// <param name="channel_id">频道ID</param>
        /// <returns>DataTable</returns>
        public DataTable GetAllList(int parent_id)
        {
            return dal.GetAllList(parent_id);
        }
#endregion
   
	}
}