using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using DTcms.Common;

namespace DTcms.Web.Plugin.Forum.BLL {
	 	//dt_Forum_Medal
		    //------------------------------------------------------
    // 插件官方地址 www.dtcms-forum.net
    // 本插件开源，支持个人对插件源码修改及非盈利性平台使用
    // 如用于商业盈利性平台，需支付授权费,具体参见官网
    // 我们承接新项目开发或插件二次开发 QQ 271478027
    //------------------------------------------------------
    public partial class Forum_Medal
	{
   		private readonly  DTcms.Model.siteconfig siteConfig = new  DTcms.BLL.siteconfig().loadConfig(); //获得站点配置信息     
		private readonly DAL.Forum_Medal dal;
		public Forum_Medal()
		{
			dal=new DAL.Forum_Medal(siteConfig.sysdatabaseprefix);
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
		public int  Add(Model.Forum_Medal model)
		{
						return dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.Forum_Medal model)
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
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Id)
		{
			
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
		public Model.Forum_Medal GetModel(int Id)
		{
			
			return dal.GetModel(Id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Model.Forum_Medal GetModelByCache(int Id)
		{			
			string CacheKey = "Forum_MedalModel-" + Id;
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
            return (Model.Forum_Medal)objModel;
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
		public List<Model.Forum_Medal> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Model.Forum_Medal> DataTableToList(DataTable dt)
		{
			List<Model.Forum_Medal> modelList = new List<Model.Forum_Medal>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Model.Forum_Medal model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
				
					modelList.Add(model);
				}
			}
			return modelList;
		}
#endregion
   
	}
}