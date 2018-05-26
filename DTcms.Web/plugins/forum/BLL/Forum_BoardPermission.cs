using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using DTcms.Common;

namespace DTcms.Web.Plugin.Forum.BLL
{
    //dt_Forum_BoardPermission
    //------------------------------------------------------
    // 插件官方地址 www.dtcms-forum.net
    // 本插件开源，支持个人对插件源码修改及非盈利性平台使用
    // 如用于商业盈利性平台，需支付授权费,具体参见官网
    // 我们承接新项目开发或插件二次开发 QQ 271478027
    //------------------------------------------------------
    public partial class Forum_BoardPermission
    {
        private readonly DTcms.Model.siteconfig siteConfig = new DTcms.BLL.siteconfig().loadConfig(); //获得站点配置信息     
        private readonly DAL.Forum_BoardPermission dal;
        public Forum_BoardPermission()
        {
            dal = new DAL.Forum_BoardPermission(siteConfig.sysdatabaseprefix);
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
        public int Add(Model.Forum_BoardPermission model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.Forum_BoardPermission model)
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
        /// 得到一个对象实体
        /// </summary>
        public Model.Forum_BoardPermission GetModel(int Id)
        {

            return dal.GetModel(Id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.Forum_BoardPermission GetModel(string strWhere)
        {

            return dal.GetModel(strWhere);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Model.Forum_BoardPermission GetModelByCache(int Id)
        {
            string CacheKey = "Forum_BoardPermissionModel-" + Id;
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
            return (Model.Forum_BoardPermission)objModel;
        }


        /// <summary>
        /// 检查是否有权限 , Key= BoardId | GroupId ,val = 行为单词 ,注意大小写
        /// </summary>
        /// <returns></returns>
        public static bool CheckPermission(string key, string val)
        {

            bool bol = false;


            if (Global.ForumBoardPermissionList.ContainsKey(key))
            {
                Model.Forum_BoardPermission model = Global.ForumBoardPermissionList[key];

                switch (val)
                {
                    case "VisitBoard": //访问版块

                        if (model.VisitBoard == 1)
                        {
                            bol = true;
                        }

                        break;

                    case "VisitTopic"://访问主题

                        if (model.VisitTopic == 1)
                        {
                            bol = true;
                        }

                        break;

                    case "PostTopic"://发主题

                        if (model.PostTopic == 1)
                        {
                            bol = true;
                        }

                        break;

                    case "PostReply"://发回贴

                        if (model.PostReply == 1)
                        {
                            bol = true;
                        }

                        break;

                    case "UploadAttachment": //上传附件

                        if (model.UploadAttachment == 1)
                        {
                            bol = true;
                        }

                        break;

                    case "ViewAttachment": //下载附件

                        if (model.ViewAttachment == 1)
                        {
                            bol = true;
                        }

                        break;

                    case "UpdateMyselfTopic": //编辑自己主题

                        if (model.UpdateMyselfTopic == 1)
                        {
                            bol = true;
                        }

                        break;

                    case "UpdateMyselfReply": //编辑自己回复

                        if (model.UpdateMyselfReply == 1)
                        {
                            bol = true;
                        }

                        break;

                    case "DeleteMyselfTopic": //删除自己主题

                        if (model.DeleteMyselfTopic == 1)
                        {
                            bol = true;
                        }

                        break;

                    case "DeleteMyselfReply": //删除自己回复

                        if (model.DeleteMyselfReply == 1)
                        {
                            bol = true;
                        }

                        break;


                    default:

                        bol = true;

                        break;
                }
            }
            else
            {
                bol = true;
            }

            return bol;
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
        public List<Model.Forum_BoardPermission> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.Forum_BoardPermission> DataTableToList(DataTable dt)
        {
            List<Model.Forum_BoardPermission> modelList = new List<Model.Forum_BoardPermission>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.Forum_BoardPermission model;
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