using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using DTcms.Common;

namespace DTcms.Web.admin.lucene
{
    public partial class builder_index : Web.UI.ManagePage
    {
        //页面初始化事件
        protected void Page_Init(object sernder, EventArgs e)
        {
            CreateChannelBind();  //动态生成
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("lucene_index", DTEnums.ActionEnum.View.ToString());
                //编辑权限
                if (!ChkAuthority("lucene_index", DTEnums.ActionEnum.Edit.ToString()))
                {
                    this.btnSubmit.Visible = false;
                }
                //赋值
                ShowInfo();
            }
        }

        //绑定频道
        private void CreateChannelBind()
        {

            BLL.channel bll = new BLL.channel();
            DataTable dt = bll.GetList(0, "", "sort_id asc,id desc").Tables[0];
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    //创建行
                    HtmlGenericControl htmlTR = new HtmlGenericControl("tr");

                    //创建单元格1
                    HtmlGenericControl htmlTD1 = new HtmlGenericControl("td");
                    htmlTD1.InnerHtml = dr["title"].ToString();
                    htmlTR.Controls.Add(htmlTD1);

                    //创建单元格2
                    HtmlGenericControl htmlTD2 = new HtmlGenericControl("td");

                    //Name
                    HiddenField hidControl1 = new HiddenField();
                    hidControl1.ID = "control_hide_" + dr["id"].ToString();
                    hidControl1.Value = dr["name"].ToString();
                    htmlTD2.Controls.Add(hidControl1);
                    htmlTR.Controls.Add(htmlTD2);

                    CheckBox cbControl = new CheckBox();
                    cbControl.ID = "control_checkbox_" + dr["id"].ToString();
                    HtmlGenericControl htmlDiv1 = new HtmlGenericControl("div");
                    htmlDiv1.Attributes.Add("class", "rule-single-checkbox");
                    htmlDiv1.Controls.Add(cbControl);
                    htmlTD2.Controls.Add(htmlDiv1);
                    htmlTR.Controls.Add(htmlTD2);

                    //创建单元格3
                    HtmlGenericControl htmlTD3 = new HtmlGenericControl("td");
                    TextBox txtControl = new TextBox();
                    txtControl.ID = "control_lastid_" + dr["id"].ToString();
                    txtControl.CssClass = "input small";
                    txtControl.Text = "0";
                    txtControl.ReadOnly = true;
                    htmlTD3.Controls.Add(txtControl);
                    htmlTR.Controls.Add(htmlTD3);

                    //创建单元格4
                    HtmlGenericControl htmlTD4 = new HtmlGenericControl("td");
                    TextBox txtControl2 = new TextBox();
                    txtControl2.ID = "control_lasttime_" + dr["id"].ToString();
                    txtControl2.CssClass = "input normal";
                    txtControl2.ReadOnly = true;
                    htmlTD4.Controls.Add(txtControl2);
                    htmlTR.Controls.Add(htmlTD4);

                    //将TR到TABLE
                    ChannelPannel.Controls.Add(htmlTR);
                }
            }
        }

        //赋值
        private void ShowInfo()
        {
            BLL.channel bll = new BLL.channel();
            DataTable dt = bll.GetList(0, "", "sort_id asc,id desc").Tables[0];
            if (dt.Rows.Count > 0)
            {
                BLL.luceneconfig xml = new BLL.luceneconfig();
                foreach (DataRow dr in dt.Rows)
                {
                    CheckBox cbControl = FindControl("control_checkbox_" + dr["id"].ToString()) as CheckBox;
                    TextBox txtLastId = FindControl("control_lastid_" + dr["id"].ToString()) as TextBox;
                    TextBox txtLastTime = FindControl("control_lasttime_" + dr["id"].ToString()) as TextBox;
                    if (null != cbControl && null != txtLastId && null != txtLastTime)
                    {
                        string status = xml.GetText("Lucene/" + dr["name"].ToString() + "/status");

                        if (status == "1")
                        {
                            cbControl.Checked = true;

                            txtLastId.Text = xml.GetText("Lucene/" + dr["name"].ToString() + "/lastid");
                            txtLastTime.Text = xml.GetText("Lucene/" + dr["name"].ToString() + "/lasttime");
                        }
                    }
                }
            }
        }

        //
        private List<Model.luceneconfig> GetDicValues()
        {
            List<Model.luceneconfig> list = new List<Model.luceneconfig>();
            BLL.channel bll = new BLL.channel();
            DataTable dt = bll.GetList(0, "", "sort_id asc,id desc").Tables[0];
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    HiddenField hidControl = FindControl("control_hide_" + dr["id"].ToString()) as HiddenField;
                    CheckBox cbControl = FindControl("control_checkbox_" + dr["id"].ToString()) as CheckBox;
                    TextBox txtLastId = FindControl("control_lastid_" + dr["id"].ToString()) as TextBox;
                    TextBox txtLastTime = FindControl("control_lasttime_" + dr["id"].ToString()) as TextBox;
                    //添加
                    Model.luceneconfig model = new Model.luceneconfig();
                    model.id = Utils.StrToInt(txtLastId.Text.Trim(), 0);
                    model.name = hidControl.Value;
                    model.status = cbControl.Checked == true ? 1 : 0;
                    string time = txtLastTime.Text.Trim();
                    if (null != time && time.Length > 0)
                    {
                        DateTime t;
                        if (DateTime.TryParse(time, out t))
                        {
                            model.update = t;
                        }
                    }
                    list.Add(model);
                }
            }
            return list;
        }

        //保存配置
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("lucene_index", DTEnums.ActionEnum.Edit.ToString());

            List<Model.luceneconfig> list = GetDicValues();
            //字典
            BLL.luceneconfig bll = new BLL.luceneconfig();
            if (bll.Save(list))
            {
                JscriptMsg("保存成功！", "builder_index.aspx");
            }
            else
            {
                JscriptMsg("保存过程中发生错误！", "");
            }

        }
    }
}