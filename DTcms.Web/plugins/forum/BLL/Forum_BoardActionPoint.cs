using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using DTcms.Common;

namespace DTcms.Web.Plugin.Forum.BLL
{
    //dt_Forum_BoardActionPoint
        //------------------------------------------------------
    // 插件官方地址 www.dtcms-forum.net
    // 本插件开源，支持个人对插件源码修改及非盈利性平台使用
    // 如用于商业盈利性平台，需支付授权费,具体参见官网
    // 我们承接新项目开发或插件二次开发 QQ 271478027
    //------------------------------------------------------
    public partial class Forum_BoardActionPoint
    {
        private readonly DTcms.Model.siteconfig siteConfig = new DTcms.BLL.siteconfig().loadConfig(); //获得站点配置信息     
        private readonly DAL.Forum_BoardActionPoint dal;
        public Forum_BoardActionPoint()
        {
            dal = new DAL.Forum_BoardActionPoint(siteConfig.sysdatabaseprefix);
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
        public int Add(Model.Forum_BoardActionPoint model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.Forum_BoardActionPoint model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateField(int id, string strValue)
        {
            return dal.UpdateField(id, strValue);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateField(string strWhere, string strValue)
        {
            return dal.UpdateField(strWhere, strValue);
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
        public bool DeleteList(string Idlist)
        {
            return dal.DeleteList(Idlist);
        }

        /// <summary>
        /// 获取实际的积分，没有启用为 0 ，没有配置 使用父级 ,启用使自己
        ///.(1, "发主题");
        ///.(2, "发回复");
        ///.(3, "设置精华");
        ///.(4, "取消精华");
        ///.(5, "删除主题");
        ///.(6, "删除回复");
        ///.(7, "上传附件");
        ///.(8, "下载附件");
        /// </summary>
        /// <param name="board_id"></param>
        /// <param name="Action_id"></param>
        /// <returns></returns>
        public int GetRealPoint(int board_id, int action_id)
        {
            int _point = 0;

            System.Data.DataTable dt = GetList(" BoardId in (0," + board_id + ") and  ActionId=" + action_id).Tables[0];

            if (dt.Rows.Count != 0)
            {
                System.Data.DataRow[] dr1 = dt.Select("BoardId=" + board_id);

                //不存在则使用父级
                if (dr1.Length == 0)
                {
                    System.Data.DataRow[] dr2 = dt.Select("BoardId=0");

                    if (dr2.Length != 0)
                    {
                        _point = Convert.ToInt32(dr2[0]["Point"]);
                    }
                }
                else
                {
                    //启用返回实际
                    if (Convert.ToInt32(dr1[0]["Enable"]) == 1)
                    {
                        _point = Convert.ToInt32(dr1[0]["Point"]);
                    }
                }
            }

            return _point;
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.Forum_BoardActionPoint GetModel(int Id)
        {

            return dal.GetModel(Id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.Forum_BoardActionPoint GetModel(string strWhere)
        {

            return dal.GetModel(strWhere);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Model.Forum_BoardActionPoint GetModelByCache(int Id)
        {
            string CacheKey = "Forum_BoardActionPointModel-" + Id;
            object objModel = DTcms.Common.CacheHelper.Get(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(Id);
                    if (objModel != null)
                    {
                        DTcms.Common.CacheHelper.Insert(CacheKey, objModel, 180);
                    }
                }
                catch
                {
                }
            }
            return (Model.Forum_BoardActionPoint)objModel;
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
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
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
        public List<Model.Forum_BoardActionPoint> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.Forum_BoardActionPoint> DataTableToList(DataTable dt)
        {
            List<Model.Forum_BoardActionPoint> modelList = new List<Model.Forum_BoardActionPoint>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.Forum_BoardActionPoint model;
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