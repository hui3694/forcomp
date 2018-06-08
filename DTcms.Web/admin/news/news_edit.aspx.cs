using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using DTcms.Common;
using DTcms.Web.UI;

namespace DTcms.Web.admin.news
{
    public partial class news_edit : Web.UI.ManagePage
    {
        protected string action = DTEnums.ActionEnum.Add.ToString(); //操作类型

        private int id = 0;
        private string backUrl = string.Empty;


        //页面加载事件
        protected void Page_Load(object sender, EventArgs e)
        {
            this.backUrl = DTRequest.GetQueryString("backurl");
            string _action = DTRequest.GetQueryString("action");

            //如果是编辑或复制则检查信息是否存在
            if (_action == DTEnums.ActionEnum.Edit.ToString() || _action == DTEnums.ActionEnum.Copy.ToString())
            {
                this.action = _action;//修改或复制类型
                this.id = DTRequest.GetQueryInt("id");
                if (this.id == 0)
                {
                    JscriptMsg("传输参数不正确！", "back");
                    return;
                }
                if (!new BLL.news().Exists(this.id))
                {
                    JscriptMsg("信息不存在或已被删除！", "back");
                    return;
                }
            }

            if (!Page.IsPostBack)
            {
                ChkAdminLevel("news_list", DTEnums.ActionEnum.View.ToString()); //检查权限

                //添加编辑权限
                if (action == DTEnums.ActionEnum.Copy.ToString() && !ChkAuthority("news_list", DTEnums.ActionEnum.Add.ToString()))
                {
                    this.btnSubmit.Visible = false;
                }
                else if (action != DTEnums.ActionEnum.Copy.ToString() && !ChkAuthority("news_list", this.action))
                {
                    this.btnSubmit.Visible = false;
                }
                
                if (action == DTEnums.ActionEnum.Edit.ToString() || action == DTEnums.ActionEnum.Copy.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        

        #region 赋值操作
        private void ShowInfo(int _id)
        {
            Model.news model = new BLL.news().GetModel(_id);
            txtTitle.Text = model.title;
            rblIsHide.SelectedValue = model.is_hide.ToString();
            rblIsMsg.SelectedValue = model.is_msg.ToString();
            txtImg.Text = model.img;
            txtSort.Text = model.sort.ToString();
            txtClick.Text = model.click.ToString();
            txtTime.Text = model.time.ToString("yyyy-MM-dd HH:mm:ss");
            txtZhaiyao.Text = model.zhaiyao;
            txtContent.InnerText = model.cont;
        }
        #endregion

        #region 保存远程图片到本地
        private string AutoRemoteImageSave(string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                return string.Empty;
            }
            Web.UI.UpLoad upload = new UI.UpLoad();
            Regex reg = new Regex("IMG[^>]*?src\\s*=\\s*(?:\"(?<1>[^\"]*)\"|'(?<1>[^\']*)')", RegexOptions.IgnoreCase);
            MatchCollection m = reg.Matches(content);
            foreach (Match math in m)
            {
                string imgUri = math.Groups[1].Value;
                if (imgUri.StartsWith("http"))
                {
                    string newImgPath = upload.remoteSaveAs(imgUri);
                    if (newImgPath != string.Empty)
                    {
                        content = content.Replace(imgUri, newImgPath);
                    }
                }
            }
            return content;
        }
        #endregion


        #region 增加操作
        private bool DoAdd()
        {
            bool result = false;
            Model.news model = new Model.news();
            BLL.news bll = new BLL.news();

            model.title = txtTitle.Text.Trim();
            model.is_hide = Convert.ToInt32(rblIsHide.SelectedValue);
            model.is_msg = Convert.ToInt32(rblIsMsg.SelectedValue);
            model.img = txtImg.Text;
            model.sort = Convert.ToInt32(txtSort.Text);
            model.click = Convert.ToInt32(txtClick.Text);
            if (string.IsNullOrEmpty(txtTime.Text))
            {
                model.time = DateTime.Now;
            }
            else
            {
                model.time = Convert.ToDateTime(txtTime.Text);
            }

            //内容摘要提取内容前255个字符
            if (string.IsNullOrEmpty(txtZhaiyao.Text.Trim()))
            {
                model.zhaiyao = Utils.DropHTML(txtContent.Value, 255);
            }
            else
            {
                model.zhaiyao = Utils.DropHTML(txtZhaiyao.Text, 255);
            }

            //是否将编辑器远程图片保存到本地
            if (siteConfig.fileremote == 1)
            {
                model.cont = AutoRemoteImageSave(txtContent.Value);
            }
            else
            {
                model.cont = txtContent.Value;
            }



            model.id = bll.Add(model);
            if (model.id > 0)
            {
                AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "添加咨询内容:" + model.title); //记录日志
                result = true;
            }
            return result;
        }
        #endregion

        #region 修改操作
        private bool DoEdit(int _id)
        {
            bool result = false;

            BLL.news bll = new BLL.news();
            Model.news model = bll.GetModel(_id);

            model.title = txtTitle.Text.Trim();
            model.is_hide = Convert.ToInt32(rblIsHide.SelectedValue);
            model.is_msg = Convert.ToInt32(rblIsMsg.SelectedValue);
            model.img = txtImg.Text;
            model.sort = Convert.ToInt32(txtSort.Text);
            model.click = Convert.ToInt32(txtClick.Text);
            if (string.IsNullOrEmpty(txtTime.Text))
            {
                model.time = DateTime.Now;
            }
            else
            {
                model.time = Convert.ToDateTime(txtTime.Text);
            }
            
            //内容摘要提取内容前255个字符
            if (string.IsNullOrEmpty(txtZhaiyao.Text.Trim()))
            {
                model.zhaiyao = Utils.DropHTML(txtContent.Value, 255);
            }
            else
            {
                model.zhaiyao = Utils.DropHTML(txtZhaiyao.Text, 255);
            }

            //是否将编辑器远程图片保存到本地
            if (siteConfig.fileremote == 1)
            {
                model.cont = AutoRemoteImageSave(txtContent.Value);
            }
            else
            {
                model.cont = txtContent.Value;
            }

            if (bll.Update(model))
            {
                AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改咨询内容:" + model.title); //记录日志
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
                ChkAdminLevel("news_list", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误啦！", string.Empty);
                    return;
                }
                JscriptMsg("修改信息成功！", "news_list.aspx" + backUrl);
            }
            else //添加
            {
                ChkAdminLevel("news_list", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", string.Empty);
                    return;
                }
                JscriptMsg("添加信息成功！", "news_list.aspx" + backUrl);
            }
        }



    }
}