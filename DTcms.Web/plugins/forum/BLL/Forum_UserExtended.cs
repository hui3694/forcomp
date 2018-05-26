using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using DTcms.Common;

namespace DTcms.Web.Plugin.Forum.BLL
{
    //dt_Forum_UserExtended
    //------------------------------------------------------
    // 插件官方地址 www.dtcms-forum.net
    // 本插件开源，支持个人对插件源码修改及非盈利性平台使用
    // 如用于商业盈利性平台，需支付授权费,具体参见官网
    // 我们承接新项目开发或插件二次开发 QQ 271478027
    //------------------------------------------------------
    public partial class Forum_UserExtended
    {
        private readonly DTcms.Model.siteconfig siteConfig = new DTcms.BLL.siteconfig().loadConfig(); //获得站点配置信息     
        private readonly DAL.Forum_UserExtended dal;
        public Forum_UserExtended()
        {
            dal = new DAL.Forum_UserExtended(siteConfig.sysdatabaseprefix);
        }

        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int UserId)
        {
            return dal.Exists(UserId);
        }

        /// <summary>
        /// 将原 Cms User表中的用户，对应在论坛Forum_UserExtended副表中生成，通常只在论坛插件安装时用上
        /// </summary>
        public void SysUserAdd()
        {
            dal.SysUserAdd();
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Model.Forum_UserExtended model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.Forum_UserExtended model)
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
        /// 方法自动计算积分并归组
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.Forum_UserExtended SetGroupId(Model.Forum_UserExtended modelUser)
        {
            //因为传过来的值不是最新的，需要重新获取
            Model.Forum_UserExtended model = GetModel(modelUser.UserId);

            Model.Forum_Group modelGroup = new BLL.Forum_Group().GetModel(model.GroupId);

            //作用升级的组
            if (modelGroup.Type == 5)
            {
                Model.Forum_Group newGroup = new BLL.Forum_Group().GetModel("Type=5 and CreditLower<=" + model.Credit + " and CreditHigher>=" + model.Credit);

                if (newGroup != null)
                {
                    model.GroupId = newGroup.Id;
                    model.GroupName = newGroup.Name;
                    model.UserName = modelUser.UserName;
                    Update(model);
                }
                else
                {
                    newGroup = new BLL.Forum_Group().GetModel("IsDefault=1");
                    model.GroupId = newGroup.Id;
                    model.GroupName = newGroup.Name;
                    model.UserName = modelUser.UserName;
                }
            }

            return model;

        }


        /// <summary>
        /// 删除一条数据，相关会员贴子和记录都清掉，掉用和前端一样的方法
        /// </summary>
        public bool Delete(int UserId)
        {
            BLL.Forum_MyTopic bllMyTopic = new Forum_MyTopic();
            BLL.Forum_MyPost bllMyPost = new Forum_MyPost();
            BLL.Forum_Topic bllTopic = new Forum_Topic();

            //清我的贴子
            List<Model.Forum_MyTopic> listMyTopic = bllMyTopic.GetModelList("UserId=" + UserId);

            foreach (Model.Forum_MyTopic item in listMyTopic)
            {
                bllTopic.Delete(item.TopicId);
            }

            //清我的回贴记录
            bllMyPost.Delete("UserId=" + UserId);

            return dal.Delete(UserId);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.Forum_UserExtended GetModel(int UserId)
        {

            return dal.GetModel(UserId);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Model.Forum_UserExtended GetModelByCache(int UserId)
        {
            string CacheKey = "Forum_UserExtendedModel-" + UserId;
            object objModel = DTcms.Common.CacheHelper.Get(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(UserId);
                    if (objModel != null)
                    {
                        DTcms.Common.CacheHelper.Insert(CacheKey, objModel, 180);
                    }
                }
                catch
                {
                }
            }
            return (Model.Forum_UserExtended)objModel;
        }

        /// <summary>
        /// 合计
        /// </summary>
        public int GetTotal(string strWhere)
        {
            return dal.GetTotal(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        ///[dt_Forum_UserExtended] as F,[dt_users] as U  内部表
        /// </summary>
        public DataSet GetPostList(string strWhere)
        {
            return dal.GetPostList(strWhere);
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
        public List<Model.Forum_UserExtended> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.Forum_UserExtended> DataTableToList(DataTable dt)
        {
            List<Model.Forum_UserExtended> modelList = new List<Model.Forum_UserExtended>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.Forum_UserExtended model;
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