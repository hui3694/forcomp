using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using DTcms.Common;
using DTcms.DBUtility;

namespace DTcms.Web.Plugin.Forum.BLL
{
    //dt_Forum_Post_
        //------------------------------------------------------
    // 插件官方地址 www.dtcms-forum.net
    // 本插件开源，支持个人对插件源码修改及非盈利性平台使用
    // 如用于商业盈利性平台，需支付授权费,具体参见官网
    // 我们承接新项目开发或插件二次开发 QQ 271478027
    //------------------------------------------------------
    public partial class Forum_Post
    {
        private readonly DTcms.Model.siteconfig siteConfig = new DTcms.BLL.siteconfig().loadConfig(); //获得站点配置信息     
        private readonly DAL.Forum_Post dal;
        public Forum_Post(int _PostSubTableId)
        {
            dal = new DAL.Forum_Post(siteConfig.sysdatabaseprefix, _PostSubTableId);
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
        /// 内部标题表的统计、版块的回贴统计及最后回贴人,积分，回贴归属
        /// </summary>
        public void Add(Model.Forum_Topic modelTopic, Model.Forum_Post modelPost)
        {
            modelTopic.LastPostUserId = modelPost.PostUserId;
            modelTopic.LastPostNickname = modelPost.PostNickname;
            modelTopic.LastPostUsername = modelPost.PostUsername;
            modelTopic.LastPostDatetime = System.DateTime.Now;
            modelTopic.ReplayCount = modelTopic.ReplayCount + 1;

            //主题与回贴不是同一人才记录入回复记录表
            if (modelTopic.PostUserId != modelPost.PostUserId)
            {
                //回贴归属
                new Forum_MyPost().Add(new Model.Forum_MyPost { TopicId = modelTopic.Id, UserId = modelPost.PostUserId, PostId = modelPost.Id });
            }

            //更新主题
            new Forum_Topic().Update(modelTopic);

            //版块统计
            Model.Forum_Board modelBoard = new BLL.Forum_Board().GetModel(modelTopic.BoardId);

            string strIds = "0" + modelBoard.ClassList + "0";

            string strSql = "UPDATE [" + siteConfig.sysdatabaseprefix + "Forum_Board] SET  [PostCount]=[PostCount]+1  WHERE Id in (" + strIds + ")";

            DbHelperSQL.ExecuteSql(strSql);

            dal.Add(modelPost);

            //除了标题贴
            if (modelPost.First == 0)
            {
                //获得实际积分
                int _point = new BLL.Forum_BoardActionPoint().GetRealPoint(modelTopic.BoardId, 2);
                new Forum_UserExtended().UpdateField(modelPost.PostUserId, " PostCount=PostCount+1 ,Credit=Credit+" + _point);
                new BLL.Forum_PostSubTable().UpdateField(modelTopic.PostSubTable, " PostCount=PostCount+1 ");
            }            
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.Forum_Post model)
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
        /// 删除一条数据 内部已经对 dt_Forum_PostId 也删除
        /// </summary>
        public bool Delete(int Id)
        {
            new BLL.Forum_PostId().Delete(Id);

            return dal.Delete(Id);
        }

        /// <summary>
        /// 通过TopicId 删除 内部已经对 dt_Forum_PostId 也删除
        /// </summary>
        public bool DeleteTopicId(int TopicId)
        {
            return dal.Delete(" TopicId=" + TopicId);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.Forum_Post GetModel(int Id)
        {
            return dal.GetModel(Id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.Forum_Post GetModel(string where)
        {
            return dal.GetModel(where);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Model.Forum_Post GetModelByCache(int Id)
        {
            string CacheKey = "Forum_Post_Model-" + Id;
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
            return (Model.Forum_Post)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 实际是通过主题表进行回贴合计，可能有些不正确但这样的速度快
        /// </summary>
        public int GetTotal(string strWhere)
        {
            return dal.GetTotal(strWhere);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// TopicId 这个参数不为 0 时 where 中会多出  id in (SELECT  [Id] FROM dt_Forum_PostId] where TopicId=" + TopicId + ")
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, int TopicId, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, TopicId, filedOrder, out recordCount);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.Forum_Post> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.Forum_Post> DataTableToList(DataTable dt)
        {
            List<Model.Forum_Post> modelList = new List<Model.Forum_Post>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.Forum_Post model;
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