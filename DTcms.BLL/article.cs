using System;
using System.Data;
using System.Collections.Generic;
using DTcms.Common;

namespace DTcms.BLL
{
    /// <summary>
    /// ��������
    /// </summary>
    public partial class article
    {
        private readonly Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(); //���վ��������Ϣ
        private readonly DAL.article dal;

        public article()
        {
            dal = new DAL.article(siteConfig.sysdatabaseprefix);
        }

        #region ��������================================
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(string call_index)
        {
            return dal.Exists(call_index);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Model.article model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(Model.article model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool Delete(int id)
        {
            string content = dal.GetContent(id); //��ȡ��Ϣ����
            bool result = dal.Delete(id);
            if (result && !string.IsNullOrEmpty(content))
            {
                Utils.DeleteContentPic(content, siteConfig.webpath + siteConfig.filepath); //ɾ������ͼƬ
            }
            return result;
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Model.article GetModel(int id)
        {
            return dal.GetModel(id);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Model.article GetModel(string call_index)
        {
            return dal.GetModel(call_index);
        }

        /// <summary>
        /// ���ǰ��������
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        
        /// <summary>
        /// ��ò�ѯ��ҳ����
        /// </summary>
        public DataSet GetList(int channel_id, int category_id, int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(channel_id, category_id, pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }

        #endregion

        #region ��չ����================================
        /// <summary>
        /// �Ƿ���ڱ���
        /// </summary>
        public bool ExistsTitle(string title)
        {
            return dal.ExistsTitle(title);
        }
        /// <summary>
        /// �Ƿ���ڱ���
        /// </summary>
        public bool ExistsTitle(string title, int category_id)
        {
            return dal.ExistsTitle(title, category_id);
        }

        /// <summary>
        /// ������Ϣ����
        /// </summary>
        public string GetTitle(int id)
        {
            return dal.GetTitle(id);
        }

        /// <summary>
        /// ��ȡ�Ķ�����
        /// </summary>
        public int GetClick(int id)
        {
            return dal.GetClick(id);
        }

        /// <summary>
        /// ������������
        /// </summary>
        public int GetCount(string strWhere)
        {
            return dal.GetCount(strWhere);
        }

        /// <summary>
        /// ������Ʒ�������
        /// </summary>
        public int GetStockQuantity(int id, int goods_id)
        {
            return dal.GetStockQuantity(id, goods_id);
        }

        /// <summary>
        /// �޸�һ������
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            dal.UpdateField(id, strValue);
        }

        /// <summary>
        /// ��ȡ΢������ʵ��
        /// </summary>
        public Model.article GetWXModel(int id)
        {
            DataTable dt = dal.GetList(1, "id=" + id, "id desc").Tables[0];
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            Model.article model = new Model.article();
            model.id = int.Parse(dt.Rows[0]["id"].ToString());
            model.title = dt.Rows[0]["title"].ToString();
            model.img_url = dt.Rows[0]["img_url"].ToString();
            model.zhaiyao = dt.Rows[0]["zhaiyao"].ToString();
            model.content = dt.Rows[0]["content"].ToString();
            return model;
        }
        #endregion

        #region ǰ̨ģ����÷���========================
        /// <summary>
        /// ������ͼ��ʾǰ��������
        /// </summary>
        public DataSet GetList(string channel_name, int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(channel_name, Top, strWhere, filedOrder);
        }

        /// <summary>
        /// ������ͼ��ʾǰ��������
        /// </summary>
        public DataSet GetList(string channel_name, int category_id, int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(channel_name, category_id, Top, strWhere, filedOrder);
        }

        /// <summary>
        /// ������ͼ��ʾ�����������
        /// </summary>
        public DataSet GetRandomList(string channel_name, int category_id, int Top, string strWhere)
        {
            return dal.GetRandomList(channel_name, category_id, Top, strWhere);
        }

        /// <summary>
        /// ������ͼ��ò�ѯ��ҳ����
        /// </summary>
        public DataSet GetList(string channel_name, int category_id, int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(channel_name, category_id, pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }
          /// <summary>
        /// ������ͼ��ȡ�ܼ�¼��
        /// </summary>
        public int GetCount(string channel_name, int category_id, string strWhere)
        {
            return dal.GetCount(channel_name, category_id,strWhere);
        }

        /// <summary>
        /// ������ͼ������ѯ��ҳ����
        /// </summary>
        public DataSet GetList(string channel_name, int category_id, Dictionary<string, string> dicSpecIds, int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(channel_name, category_id, dicSpecIds, pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }

        /// <summary>
        /// ������ͼ��ò�ѯ��ҳ����
        /// </summary>
        public DataSet GetSearch(int channel_id, int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            string channel_name = new BLL.channel().GetName(channel_id);
            return dal.GetSearch(channel_name, pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }

        /// <summary>
        /// ��ùؽ��ֲ�ѯ��ҳ����(�����õ�)
        /// </summary>
        public DataSet GetSearch(string channel_name, int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetSearch(channel_name, pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }

        /// <summary>
        /// ���Tags��ѯǰ��������(�����õ�)
        /// </summary>
        public DataSet GetSearch(string channel_name, int tags_id, int Top, string strWhere, string filedOrder)
        {
            return dal.GetSearch(channel_name, tags_id, Top, strWhere, filedOrder);
        }

        /// <summary>
        /// ���Tags��ѯ��ҳ����(�����õ�)
        /// </summary>
        public DataSet GetSearch(string channel_name, string tags, int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetSearch(channel_name, tags, pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }
        #endregion

    }
}