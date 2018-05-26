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
    public partial class post_edit : Web.UI.ManagePage
    {
        private string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;
        private int subTableId = 0;
       

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = DTRequest.GetQueryString("action");            

            if (!string.IsNullOrEmpty(_action) && _action == DTEnums.ActionEnum.Edit.ToString())
            {
                this.action = DTEnums.ActionEnum.Edit.ToString();//修改类型                

                this.subTableId = DTRequest.GetQueryInt("subTableId");

                if (!int.TryParse(Request.QueryString["id"] as string, out this.id))
                {
                    JscriptMsg("传输参数不正确！", "back");
                    return;
                }
                if (!new BLL.Forum_Post(subTableId).Exists(this.id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("plugin_forum_post", DTEnums.ActionEnum.View.ToString()); //检查权限

                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    hfTurl.Value = Request.UrlReferrer.ToString();
                    ShowInfo(this.id);
                }
            }
        }

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.Forum_Post bll = new BLL.Forum_Post(subTableId);
            Model.Forum_Post model = bll.GetModel(_id);
            //编写赋值操作Begin

            txtMessage.Text = model.Message;
            rblBan.SelectedValue = model.Ban.ToString();

            //编写赋值操作End
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            return true;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            BLL.Forum_Post bll = new BLL.Forum_Post(subTableId);
            Model.Forum_Post model = bll.GetModel(_id);

            //编写编辑操作Begin

            model.Message = txtMessage.Text;
            model.Ban = Convert.ToInt32(rblBan.SelectedValue);

            //编写编辑操作End

            if (bll.Update(model))
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
            if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
            {
                ChkAdminLevel("plugin_forum_post", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("修改信息成功！", hfTurl.Value);
            }
            else //添加
            {
                ChkAdminLevel("plugin_forum_post", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("添加信息成功！", hfTurl.Value);
            }
        }
    }
}