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
    public partial class attachment_edit : Web.UI.ManagePage
	{
		private string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;
        
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
                if (!new BLL.Forum_Attachment().Exists(this.id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("Forum_Attachment_list", DTEnums.ActionEnum.View.ToString()); //检查权限

                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
		}      
		
		#region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.Forum_Attachment bll = new BLL.Forum_Attachment();
            Model.Forum_Attachment model = bll.GetModel(_id);
            //编写赋值操作Begin
            
            			//txtId.Text = model.Id;
						//txtUserId.Text = model.UserId;
						//txtBoardId.Text = model.BoardId;
						//txtTopicId.Text = model.TopicId;
						//txtPostId.Text = model.PostId;
						//txtUploadDatetime.Text = model.UploadDatetime;
						//txtName.Text = model.Name;
						//txtFileName.Text = model.FileName;
						//txtDescription.Text = model.Description;
						//txtFileType.Text = model.FileType;
						//txtFileSize.Text = model.FileSize;
						//txtIsImage.Text = model.IsImage;
						//txtThumb.Text = model.Thumb;
						//txtDownload.Text = model.Download;
						//txtCost.Text = model.Cost;
						//txtCostType.Text = model.CostType;
			            
            //编写赋值操作End
        }
        #endregion
        
        #region 增加操作=================================
        private bool DoAdd()
        {
            Model.Forum_Attachment model = new Model.Forum_Attachment();
            BLL.Forum_Attachment bll = new BLL.Forum_Attachment();
            //编写添加操作Begin
            			//model.Id = txtId.Text;
						//model.UserId = txtUserId.Text;
						//model.BoardId = txtBoardId.Text;
						//model.TopicId = txtTopicId.Text;
						//model.PostId = txtPostId.Text;
						//model.UploadDatetime = txtUploadDatetime.Text;
						//model.Name = txtName.Text;
						//model.FileName = txtFileName.Text;
						//model.Description = txtDescription.Text;
						//model.FileType = txtFileType.Text;
						//model.FileSize = txtFileSize.Text;
						//model.IsImage = txtIsImage.Text;
						//model.Thumb = txtThumb.Text;
						//model.Download = txtDownload.Text;
						//model.Cost = txtCost.Text;
						//model.CostType = txtCostType.Text;
			            //编写添加操作End

            if (bll.Add(model) > 0)
            {
                AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "添加dt_Forum_Attachment:" 
                	+ model.Name); //记录日志
                return true;
            }
            return false;
        }
        #endregion
        
        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            BLL.Forum_Attachment bll = new BLL.Forum_Attachment();
            Model.Forum_Attachment model = bll.GetModel(_id);

            //编写编辑操作Begin
            			//model.Id = txtId.Text;
						//model.UserId = txtUserId.Text;
						//model.BoardId = txtBoardId.Text;
						//model.TopicId = txtTopicId.Text;
						//model.PostId = txtPostId.Text;
						//model.UploadDatetime = txtUploadDatetime.Text;
						//model.Name = txtName.Text;
						//model.FileName = txtFileName.Text;
						//model.Description = txtDescription.Text;
						//model.FileType = txtFileType.Text;
						//model.FileSize = txtFileSize.Text;
						//model.IsImage = txtIsImage.Text;
						//model.Thumb = txtThumb.Text;
						//model.Download = txtDownload.Text;
						//model.Cost = txtCost.Text;
						//model.CostType = txtCostType.Text;
			            //编写编辑操作End

            if (bll.Update(model))
            {
                AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改管理员:" + model.Name); //记录日志
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
                ChkAdminLevel("Forum_Attachment_list", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("修改信息成功！", "Forum_Attachment_list.aspx");
            }
            else //添加
            {
                ChkAdminLevel("Forum_Attachment_list", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("添加信息成功！", "Forum_Attachment_list.aspx");
            }
        }
     }
}