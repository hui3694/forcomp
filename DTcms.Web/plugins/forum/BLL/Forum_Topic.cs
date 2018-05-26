using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using DTcms.Common;
using DTcms.DBUtility;

namespace DTcms.Web.Plugin.Forum.BLL
{
    //dt_Forum_Topic
    //------------------------------------------------------
    // 插件官方地址 www.dtcms-forum.net
    // 本插件开源，支持个人对插件源码修改及非盈利性平台使用
    // 如用于商业盈利性平台，需支付授权费,具体参见官网
    // 我们承接新项目开发或插件二次开发 QQ 271478027
    //------------------------------------------------------
    public partial class Forum_Topic
    {
        private readonly DTcms.Model.siteconfig siteConfig = new DTcms.BLL.siteconfig().loadConfig(); //获得站点配置信息     
        private readonly DAL.Forum_Topic dal;
        public Forum_Topic()
        {
            dal = new DAL.Forum_Topic(siteConfig.sysdatabaseprefix);
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
        /// 增加一条数据,内部已经处理分表回贴，版块统计，属归作者表,积分
        /// </summary>
        public int Add(Model.Forum_Topic model, out int _subTable_id, out int _post_id)
        {

            Forum_PostSubTable bllSubTable = new Forum_PostSubTable();
            Forum_Board bllBoard = new Forum_Board();

            Model.Forum_PostSubTable modelSubTable = bllSubTable.GetModel("Avail=1");

            //分表ID
            _subTable_id = modelSubTable.Id;

            model.PostSubTable = _subTable_id;

            //主题表ID
            int _topic_id = dal.Add(model);

            //回复表ID
            _post_id = new Forum_PostId().Add(new Model.Forum_PostId { TopicId = _topic_id });

            new Forum_Post(_subTable_id).Add(model, new Model.Forum_Post
            {
                BoardId = model.BoardId,
                Message = model.Message,
                Title = model.Title,
                PostDateTime = model.PostDatetime,
                PostNickname = model.PostNickname,
                PostUsername = model.PostUsername,
                PostUserId = model.PostUserId,
                Id = _post_id,
                TopicId = _topic_id,
                First = 1
            });

            //版块包括父级版块的统计、标记最后发贴

            string strValue = "[TodayTopicCount]=[TodayTopicCount]+1,[TopicCount]=[TopicCount]+1,[LastPostUserId]=" + model.PostUserId + ",[LastPostUsername]='" + model.PostUsername.Replace("'", "") + "',[LastPostNickname]='" + model.PostNickname.Replace("'", "") + "',[LastTopicId]=" + _topic_id + ",[LastTopicTitle]='" + model.Title.Replace("'", "") + "'";

            Model.Forum_Board modelBoard = bllBoard.GetModel(model.BoardId);

            bllBoard.UpdateField(" Id in (0" + modelBoard.ClassList + "0) ", strValue);

            //文章归属
            new Forum_MyTopic().Add(new Model.Forum_MyTopic { TopicId = _topic_id, UserId = model.PostUserId });

            //获得实际积分
            int _point = new BLL.Forum_BoardActionPoint().GetRealPoint(model.BoardId, 1);

            new Forum_UserExtended().UpdateField(model.PostUserId, " TopicCount=TopicCount+1 ,Credit=Credit+" + _point);

            modelSubTable.TopicCount += 1;

            bllSubTable.Update(modelSubTable);

            return _topic_id;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.Forum_Topic model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 更新一条主题表及回贴
        /// </summary>
        public bool Update(Model.Forum_Topic model, Model.Forum_Post modelPost)
        {

            new DAL.Forum_Post(siteConfig.sysdatabaseprefix, model.PostSubTable).Update(modelPost);

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
        /// 屏蔽主题
        /// </summary>
        public void SetBan(string tids, int ban)
        {

            System.Data.DataTable dt = GetList("id in (" + tids + ")").Tables[0];

            string strSql = "";

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                strSql += "UPDATE [" + siteConfig.sysdatabaseprefix + "Forum_Post_" + dt.Rows[i]["PostSubTable"].ToString() + "] SET [Ban] = " + ban + " WHERE  TopicId=" + dt.Rows[i]["id"].ToString() + " and First=1";
            }

            new BLL.Forum_Topic().UpdateField("id in (" + tids + ")", "[ban]=" + ban);

            if (!string.IsNullOrEmpty(strSql))
            {
                DbHelperSQL.ExecuteSql(strSql);
            }

        }

        /// <summary>
        /// 屏蔽回复
        /// </summary>
        public void SetBanReply(string rids, int ban, int topic_id)
        {

            Model.Forum_Topic modelTopic = GetModel(topic_id);

            string strSql = "UPDATE [" + siteConfig.sysdatabaseprefix + "Forum_Post_" + modelTopic.PostSubTable + "] SET [Ban] = " + ban + " WHERE ID in (" + rids + ")";

            if (!string.IsNullOrEmpty(strSql))
            {
                DbHelperSQL.ExecuteSql(strSql);
            }
        }

        /// <summary>
        /// 删除回贴,标题统计，版块统计，积分一并处理,有附件的一并处理
        /// </summary>
        public void DeleterReply(string rids, int topic_id)
        {

            Model.Forum_Topic modelTopic = GetModel(topic_id);

            System.Data.DataTable dt = new BLL.Forum_Post(modelTopic.PostSubTable).GetList(" id in (" + rids + ") ").Tables[0];

            //获得实际积分
            int _point = new BLL.Forum_BoardActionPoint().GetRealPoint(modelTopic.BoardId, 6);

            BLL.Forum_Attachment bllAtt = new Forum_Attachment();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                new Forum_UserExtended().UpdateField(Convert.ToInt32(dt.Rows[i]["PostUserId"]), " PostCount=PostCount-1 , Credit=Credit+" + _point);

                //附件处理

                if (Convert.ToInt32(dt.Rows[i]["Attachment"]) != 0)
                {

                    List<Model.Forum_Attachment> dtAtt = bllAtt.GetModelList(" PostId=" + dt.Rows[i]["id"].ToString());

                    foreach (Model.Forum_Attachment item in dtAtt)
                    {
                        bllAtt.Delete(item, item.Id);
                    }
                }
            }

            string strSql = "DELETE [" + siteConfig.sysdatabaseprefix + "Forum_Post_" + modelTopic.PostSubTable + "]  WHERE ID in (" + rids + ")";

            //影响记录数相当于删了多少条数据
            int _count = 0;

            if (!string.IsNullOrEmpty(strSql))
            {
                _count = DbHelperSQL.ExecuteSql(strSql);
            }

            modelTopic.ReplayCount = modelTopic.ReplayCount - _count;

            Update(modelTopic);

            //版块包括父级版块的统计

            string strValue = "[PostCount]=[PostCount]-" + _count + "";

            Model.Forum_Board modelBoard = new BLL.Forum_Board().GetModel(modelTopic.BoardId);

            new Forum_Board().UpdateField(" Id in (0" + modelBoard.ClassList + "0) ", strValue);

            new Forum_PostId().DeleteList(rids);

            new Forum_PostSubTable().UpdateField(modelTopic.PostSubTable, " PostCount=PostCount-" + _count);

        }

        /// <summary>
        /// 移动主题
        /// </summary>
        public void SetMove(string tids, int board_id, int tobid)
        {
            Model.Forum_Board modelBoard = new BLL.Forum_Board().GetModel(board_id);
            Model.Forum_Board modelToBoard = new BLL.Forum_Board().GetModel(tobid);

            string strIds = "0" + modelBoard.ClassList + "0";
            string strToIds = "0" + modelToBoard.ClassList + "0";

            System.Data.DataTable dt = GetList("id in (" + tids + ")").Tables[0];

            string strSql = "";

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                strSql += "UPDATE [" + siteConfig.sysdatabaseprefix + "Forum_Board] SET [TopicCount] = [TopicCount]-1 ,[PostCount] = [PostCount]-" + dt.Rows[i]["ReplayCount"].ToString() + " WHERE  [TopicCount]>0 and [Id] in ( " + strIds + ");";
                strSql += "UPDATE [" + siteConfig.sysdatabaseprefix + "Forum_Board] SET [TopicCount] = [TopicCount]+1 ,[PostCount] = [PostCount]+" + dt.Rows[i]["ReplayCount"].ToString() + " WHERE  [Id] in ( " + strToIds + ");";
            }

            new BLL.Forum_Topic().UpdateField("id in (" + tids + ")", "[BoardId]=" + tobid);

            if (!string.IsNullOrEmpty(strSql))
            {
                DbHelperSQL.ExecuteSql(strSql);
            }

        }

        /// <summary>
        /// 设置精华，同时也处理了个人的精华统计，积分
        /// </summary>
        public void SetDigest(string tids, int digest)
        {
            new BLL.Forum_Topic().UpdateField("id in (" + tids + ")", "[Digest]=" + digest);

            System.Data.DataTable dt = GetList("id in (" + tids + ")").Tables[0];

            string strSql = "";

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (digest == 1)
                {
                    strSql = "UPDATE [" + siteConfig.sysdatabaseprefix + "Forum_UserExtended]SET [PostDigestCount] = [PostDigestCount]+1 WHERE [UserId] = " + dt.Rows[i]["PostUserId"] + ";";

                    //获得实际积分
                    int _point = new BLL.Forum_BoardActionPoint().GetRealPoint(Convert.ToInt32(dt.Rows[i]["BoardId"]), 3);

                    new Forum_UserExtended().UpdateField(Convert.ToInt32(dt.Rows[i]["PostUserId"]), " Credit=Credit+" + _point);
                }
                else
                {
                    strSql = "UPDATE [" + siteConfig.sysdatabaseprefix + "Forum_UserExtended]SET [PostDigestCount] = [PostDigestCount]-1 WHERE  [PostDigestCount]>0 and [UserId] = " + dt.Rows[i]["PostUserId"] + ";";

                    //获得实际积分
                    int _point = new BLL.Forum_BoardActionPoint().GetRealPoint(Convert.ToInt32(dt.Rows[i]["BoardId"]), 4);

                    new Forum_UserExtended().UpdateField(Convert.ToInt32(dt.Rows[i]["PostUserId"]), " Credit=Credit+" + _point);
                }
            }

            if (!string.IsNullOrEmpty(strSql))
            {
                DbHelperSQL.ExecuteSql(strSql);
            }
        }


        /// <summary>
        /// 内部 删除一条数据及主题的回贴并重新统计版块的主题总数，积分，我的主题，我的回复一起清除
        /// </summary>
        public bool Delete(int Id)
        {
            Model.Forum_Topic model = GetModel(Id);

            //--删除回复----------------------------------

            System.Data.DataTable dt = new BLL.Forum_Post(model.PostSubTable).GetList(9999999, " TopicId=" + Id + " ", " id asc ").Tables[0];

            //获得实际积分,调整，删除主题不牵联其它已经回复者的积分
            //int _point = new BLL.Forum_BoardActionPoint().GetRealPoint(model.BoardId, 6);

            BLL.Forum_Attachment bllAtt = new Forum_Attachment();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (Convert.ToInt32(dt.Rows[i]["First"].ToString()) == 0)
                {
                    new Forum_UserExtended().UpdateField(Convert.ToInt32(dt.Rows[i]["PostUserId"]), " PostCount=PostCount-1 ");
                }

                //附件处理

                if (Convert.ToInt32(dt.Rows[i]["Attachment"]) != 0)
                {

                    List<Model.Forum_Attachment> dtAtt = bllAtt.GetModelList(" PostId=" + dt.Rows[i]["id"].ToString());

                    foreach (Model.Forum_Attachment item in dtAtt)
                    {
                        bllAtt.Delete(item, item.Id);
                    }
                }
            }

            //------------------------------------

            new BLL.Forum_Post(model.PostSubTable).DeleteTopicId(Id);

            //版块包括父级版块的统计

            string strValue = "[TopicCount]=[TopicCount]-1,[PostCount]=[PostCount]-" + model.ReplayCount;

            Model.Forum_Board modelBoard = new BLL.Forum_Board().GetModel(model.BoardId);

            string strIds = "0" + modelBoard.ClassList + "0";

            new Forum_Board().UpdateField(" Id in (" + strIds + ") ", strValue);

            new Forum_PostSubTable().UpdateField(model.PostSubTable, " TopicCount=TopicCount-1,PostCount=PostCount-" + model.ReplayCount);

            //获得实际积分
            int _point = new BLL.Forum_BoardActionPoint().GetRealPoint(model.BoardId, 5);

            new Forum_UserExtended().UpdateField(model.PostUserId, " TopicCount=TopicCount-1, Credit=Credit+" + _point);

            //--主题清空随之 我的主题，我的回复一起清除----------------------------------
            new BLL.Forum_MyTopic().Delete("TopicId=" + Id);

            new BLL.Forum_MyPost().Delete("TopicId=" + Id);

            return dal.Delete(Id);
        }

        /// <summary>
        /// 内部 删除一条数据及主题的回贴并重新统计版块的主题总数,积分
        /// </summary>
        public bool DeleteList(string Idlist)
        {
            string[] Ids = Idlist.Split(',');

            for (int i = 0; i < Ids.Length; i++)
            {
                if (!string.IsNullOrEmpty(Ids[i]))
                {
                    Delete(Convert.ToInt32(Ids[i]));
                }
            }

            return true;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.Forum_Topic GetModel(int Id)
        {
            return dal.GetModel(Id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Model.Forum_Topic GetModelByCache(int Id)
        {
            string CacheKey = "Forum_TopicModel-" + Id;
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
            return (Model.Forum_Topic)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 主题合计
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
        /// 获取置顶的贴子
        /// </summary>
        public DataTable GetTopList(int board_id)
        {
            string ids = Global.GetForumTopTopicIds(board_id);

            System.Data.DataTable dt = dal.GetTopList(board_id).Tables[0];

            if (dt.Rows.Count == 0)
            {
                ids = "0";
            }
            else
            {
                System.Data.DataRow[] drs = dt.Select("1=1");

                ids = "0";

                foreach (System.Data.DataRow dr in drs)
                {
                    ids += "," + dr["Id"].ToString();
                }
            }

            Global.PutForumTopTopicIds(board_id, ids);

            return dt;
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
        public List<Model.Forum_Topic> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.Forum_Topic> DataTableToList(DataTable dt)
        {
            List<Model.Forum_Topic> modelList = new List<Model.Forum_Topic>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.Forum_Topic model;
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