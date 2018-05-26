using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;

namespace DTcms.Web.Plugin.Forum.admin
{
        //------------------------------------------------------
    // 插件官方地址 www.dtcms-forum.net
    // 本插件开源，支持个人对插件源码修改及非盈利性平台使用
    // 如用于商业盈利性平台，需支付授权费,具体参见官网
    // 我们承接新项目开发或插件二次开发 QQ 271478027
    //------------------------------------------------------
    public partial class topic_edit : Web.UI.ManagePage
    {
        private string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;
        private Model.Forum_Post modelPost = null;
        private DTcms.Model.users modelUser = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = DTRequest.GetQueryString("action");
            if (!string.IsNullOrEmpty(_action) && _action == DTEnums.ActionEnum.Edit.ToString())
            {
                this.action = DTEnums.ActionEnum.Edit.ToString();//修改类型
                if (!int.TryParse(Request.QueryString["id"] as string, out this.id))
                {
                    JscriptMsg("传输参数不正确！", "back");
                    return;
                }
                if (!new BLL.Forum_Topic().Exists(this.id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("plugin_forum_topic", DTEnums.ActionEnum.View.ToString()); //检查权限
                TreeBind();
                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 绑定类别=================================
        private void TreeBind()
        {
            BLL.Forum_Board bll = new BLL.Forum_Board();
            DataTable dt = bll.GetAllList(0);

            this.ddlBoardId.Items.Clear();

            foreach (DataRow dr in dt.Rows)
            {
                string Id = dr["id"].ToString();
                int ClassLayer = int.Parse(dr["classLayer"].ToString());
                string Title = dr["Name"].ToString().Trim();

                if (ClassLayer == 1)
                {
                    this.ddlBoardId.Items.Add(new ListItem(Title, Id));
                }
                else
                {
                    Title = "├ " + Title;
                    Title = Utils.StringOfChar(ClassLayer - 1, "　") + Title;
                    this.ddlBoardId.Items.Add(new ListItem(Title, Id));
                }
            }
        }
        #endregion

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.Forum_Topic bll = new BLL.Forum_Topic();
            Model.Forum_Topic model = bll.GetModel(_id);
            //编写赋值操作Begin

            txtUserId.Text = model.PostUserId.ToString();
            ddlBoardId.SelectedValue = model.BoardId.ToString();
            txtTopicTypeId.Text = model.TopicTypeId.ToString();
            txtTitle.Text = model.Title;
            txtViewCount.Text = model.ViewCount.ToString();
            txtPostDatetime.Text = model.PostDatetime.ToString();

            if (model.Digest == 1)
            {
                cblItem.Items[0].Selected = true;
            }
            if (model.Top == 1)
            {
                cblItem.Items[1].Selected = true;
            }
            if (model.Ban == 1)
            {
                cblItem.Items[2].Selected = true;
            }

            rblClose.SelectedValue = model.Close.ToString();

            modelPost = new BLL.Forum_Post(model.PostSubTable).GetModel(" First=1 and TopicId=" + _id + " ");

            txtMessage.Text = modelPost.Message;

            //编写赋值操作End
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            Model.Forum_Topic model = new Model.Forum_Topic();
            BLL.Forum_Topic bll = new BLL.Forum_Topic();
            //编写添加操作Begin

            model.BoardId = Convert.ToInt32(ddlBoardId.SelectedValue);
            //model.TopicTypeId = txtTopicTypeId.Text;
            model.Title = txtTitle.Text;

            if (string.IsNullOrEmpty(txtPostDatetime.Text))
            {
                model.PostDatetime = System.DateTime.Now;
            }
            else
            {
                model.PostDatetime = Convert.ToDateTime(txtPostDatetime.Text);
            }

            model.Digest = 0;
            model.Top = 0;
            model.Ban = 0;
            model.Close = 0;

            if (cblItem.Items[0].Selected)
            {
                model.Digest = 1;
            }
            if (cblItem.Items[1].Selected)
            {
                model.Top = 1;
            }
            if (cblItem.Items[2].Selected)
            {
                model.Ban = 1;
            }

            if (rblClose.SelectedValue == "1")
            {
                model.Close = 1;
            }

            model.Message = txtMessage.Text;

            model.PostDatetime = System.DateTime.Now;
            model.PostUserId = Convert.ToInt32(txtUserId.Text);

            int _post_id = 0, _subTable_id = 0;

            //编写添加操作End

            if (bll.Add(model, out _subTable_id, out _post_id) > 0)
            {
                AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "添加dt_Forum_Topic:"
                    + model.Title); //记录日志
                return true;
            }
            return false;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            BLL.Forum_Topic bll = new BLL.Forum_Topic();
            Model.Forum_Topic model = bll.GetModel(_id);            


            //编写编辑操作Begin

            model.BoardId = Convert.ToInt32(ddlBoardId.SelectedValue);
            //model.TopicTypeId = txtTopicTypeId.Text;
            model.Title = txtTitle.Text;
            model.PostDatetime = Convert.ToDateTime(txtPostDatetime.Text);


            model.Digest = 0;
            model.Top = 0;
            model.Ban = 0;
            model.Close = 0;

            if (cblItem.Items[0].Selected)
            {
                model.Digest = 1;
            }
            if (cblItem.Items[1].Selected)
            {
                model.Top = 1;
            }
            if (cblItem.Items[2].Selected)
            {
                model.Ban = 1;
            }

            if (rblClose.SelectedValue == "1")
            {
                model.Close = 1;
            }

            model.Message = txtMessage.Text;

            modelPost = new BLL.Forum_Post(model.PostSubTable).GetModel(" First=1 and TopicId=" + _id + " ");
            modelPost.Message = txtMessage.Text;


            //编写编辑操作End

            model.PostUserId = modelUser.id;
            model.PostUsername = modelUser.user_name;
            model.PostNickname = modelUser.nick_name;

            modelPost.PostUserId = modelUser.id;
            modelPost.PostUsername = modelUser.user_name;
            modelPost.PostNickname = modelUser.nick_name;

            if (bll.Update(model, modelPost))
            {
                AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改管理员:" + model.Title); //记录日志
                result = true;
            }

            return result;
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int user_id = Convert.ToInt32(txtUserId.Text.ToString());

            modelUser = new DTcms.BLL.users().GetModel(user_id);

            if (modelUser == null)
            {
                JscriptMsg("指定的会员编号不存在！", "");
                return;
            }
            else
            {
                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ChkAdminLevel("plugin_forum_topic", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                    if (!DoEdit(this.id))
                    {
                        JscriptMsg("保存过程中发生错误！", "");
                        return;
                    }
                    JscriptMsg("修改信息成功！", "topic_list.aspx");
                }
                else //添加
                {
                    ChkAdminLevel("plugin_forum_topic", DTEnums.ActionEnum.Add.ToString()); //检查权限
                    if (!DoAdd())
                    {
                        JscriptMsg("保存过程中发生错误！", "");
                        return;
                    }
                    JscriptMsg("添加信息成功！", "topic_list.aspx");
                }
            }
        }
    }
}