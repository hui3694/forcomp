﻿using System;
using System.Xml;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;

namespace DTcms.Web.admin.order
{
    public partial class payment_edit : Web.UI.ManagePage
    {
        private int id = 0;
        protected Model.payment model = new Model.payment();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.id = DTRequest.GetQueryInt("id");
            if (this.id == 0)
            {
                JscriptMsg("传输参数不正确！", "back");
                return;
            }
            if (!new BLL.payment().Exists(this.id))
            {
                JscriptMsg("支付方式不存在或已删除！", "back");
                return;
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("order_payment", DTEnums.ActionEnum.View.ToString()); //检查权限
                //添加、编辑权限
                if (!ChkAuthority("order_payment", DTEnums.ActionEnum.Edit.ToString()))
                {
                    this.btnSubmit.Visible = false;
                }
                ShowInfo(this.id);
            }
        }

        #region 赋值操作
        private void ShowInfo(int _id)
        {
            BLL.payment bll = new BLL.payment();
            model = bll.GetModel(_id);
            txtTitle.Text = model.title;
            rblType.SelectedValue = model.type.ToString();
            rblType.Enabled = false;
            if (model.is_lock == 0)
            {
                cbIsLock.Checked = true;
            }
            else
            {
                cbIsLock.Checked = false;
            }
            rblIsMobile.SelectedValue = model.is_mobile.ToString();
            txtSortId.Text = model.sort_id.ToString();
            rblPoundageType.SelectedValue = model.poundage_type.ToString();
            txtPoundageAmount.Text = model.poundage_amount.ToString();
            txtImgUrl.Text = model.img_url;
            txtRemark.Text = model.remark;
            if (model.api_path.ToLower() == "alipaypc")
            {
                //支付宝(PC)
                XmlDocument doc = XmlHelper.LoadXmlDoc(Utils.GetMapPath(siteConfig.webpath + "xmlconfig/alipaypc.config"));
                txtAlipayPartner.Text = doc.SelectSingleNode(@"Root/partner").InnerText;
                txtAlipayKey.Text = doc.SelectSingleNode(@"Root/key").InnerText;
                txtAlipaySellerEmail.Text = doc.SelectSingleNode(@"Root/email").InnerText;
                rblAlipayType.SelectedValue = doc.SelectSingleNode(@"Root/type").InnerText;
            }
            else if (model.api_path.ToLower() == "alipaymb")
            {
                //支付宝(MB)
                XmlDocument doc = XmlHelper.LoadXmlDoc(Utils.GetMapPath(siteConfig.webpath + "xmlconfig/alipaymb.config"));
                txtAlipayPartner.Text = doc.SelectSingleNode(@"Root/partner").InnerText;
                txtAlipayKey.Text = doc.SelectSingleNode(@"Root/key").InnerText;
                txtAlipaySellerEmail.Text = doc.SelectSingleNode(@"Root/email").InnerText;
            }
            else if (model.api_path.ToLower() == "tenpaypc")
            {
                //财付通(PC)
                XmlDocument doc = XmlHelper.LoadXmlDoc(Utils.GetMapPath(siteConfig.webpath + "xmlconfig/tenpaypc.config"));
                txtTenpayBargainorId.Text = doc.SelectSingleNode(@"Root/partner").InnerText;
                txtTenpayKey.Text = doc.SelectSingleNode(@"Root/key").InnerText;
                rblTenpayType.SelectedValue = doc.SelectSingleNode(@"Root/type").InnerText;
            }
            else if (model.api_path.ToLower() == "chinabankpc")
            {
                //网银在线(PC)
                XmlDocument doc = XmlHelper.LoadXmlDoc(Utils.GetMapPath(siteConfig.webpath + "xmlconfig/chinabankpc.config"));
                txtChinaBankPartner.Text = doc.SelectSingleNode(@"Root/partner").InnerText;
                txtChinaBankKey.Text = doc.SelectSingleNode(@"Root/key").InnerText;
            }
            else if (model.api_path.ToLower() == "wxapipay")
            {
                //微信公众号支付
                XmlDocument doc = XmlHelper.LoadXmlDoc(Utils.GetMapPath(siteConfig.webpath + "xmlconfig/wxapipay.config"));
                txtWxPartner.Text = doc.SelectSingleNode(@"Root/partner").InnerText;
                txtWxKey.Text = doc.SelectSingleNode(@"Root/key").InnerText;
                txtWxAppId.Text = doc.SelectSingleNode(@"Root/appid").InnerText;
                txtWxAppSecret.Text = doc.SelectSingleNode(@"Root/appsecret").InnerText;
            }
            else if (model.api_path.ToLower() == "wxnatpay")
            {
                //微信扫码支付
                XmlDocument doc = XmlHelper.LoadXmlDoc(Utils.GetMapPath(siteConfig.webpath + "xmlconfig/wxnatpay.config"));
                txtWxPartner.Text = doc.SelectSingleNode(@"Root/partner").InnerText;
                txtWxKey.Text = doc.SelectSingleNode(@"Root/key").InnerText;
                txtWxAppId.Text = doc.SelectSingleNode(@"Root/appid").InnerText;
            }
        }
        #endregion

        #region 修改操作
        private bool DoEdit(int _id)
        {
            bool result = false;
            BLL.payment bll = new BLL.payment();
            Model.payment model = bll.GetModel(_id);

            model.title = txtTitle.Text.Trim();
            if (cbIsLock.Checked == true)
            {
                model.is_lock = 0;
            }
            else
            {
                model.is_lock = 1;
            }
            model.is_mobile = int.Parse(rblIsMobile.SelectedValue);
            model.sort_id = int.Parse(txtSortId.Text.Trim());
            model.poundage_type = int.Parse(rblPoundageType.SelectedValue);
            model.poundage_amount = decimal.Parse(txtPoundageAmount.Text.Trim());
            model.img_url = txtImgUrl.Text.Trim();
            model.remark = txtRemark.Text;
            if (model.api_path.ToLower() == "alipaypc")
            {
                //支付宝(PC)
                string alipayFilePath = Utils.GetMapPath(siteConfig.webpath + "xmlconfig/alipaypc.config");
                XmlHelper.UpdateNodeInnerText(alipayFilePath, @"Root/partner", txtAlipayPartner.Text);
                XmlHelper.UpdateNodeInnerText(alipayFilePath, @"Root/key", txtAlipayKey.Text);
                XmlHelper.UpdateNodeInnerText(alipayFilePath, @"Root/email", txtAlipaySellerEmail.Text);
                XmlHelper.UpdateNodeInnerText(alipayFilePath, @"Root/type", rblAlipayType.SelectedValue);
            }
            else if (model.api_path.ToLower() == "alipaymb")
            {
                //支付宝(MB)
                string alipayFilePath = Utils.GetMapPath(siteConfig.webpath + "xmlconfig/alipaymb.config");
                XmlHelper.UpdateNodeInnerText(alipayFilePath, @"Root/partner", txtAlipayPartner.Text);
                XmlHelper.UpdateNodeInnerText(alipayFilePath, @"Root/key", txtAlipayKey.Text);
                XmlHelper.UpdateNodeInnerText(alipayFilePath, @"Root/email", txtAlipaySellerEmail.Text);
            }
            else if (model.api_path.ToLower() == "tenpaypc")
            {
                //财付通(PC)
                string tenpayFilePath = Utils.GetMapPath(siteConfig.webpath + "xmlconfig/tenpaypc.config");
                XmlHelper.UpdateNodeInnerText(tenpayFilePath, @"Root/partner", txtTenpayBargainorId.Text);
                XmlHelper.UpdateNodeInnerText(tenpayFilePath, @"Root/key", txtTenpayKey.Text);
                XmlHelper.UpdateNodeInnerText(tenpayFilePath, @"Root/type", rblTenpayType.SelectedValue);
            }
            else if (model.api_path.ToLower() == "chinabankpc")
            {
                //网银在线(PC)
                string chinaBankFilePath = Utils.GetMapPath(siteConfig.webpath + "xmlconfig/chinabankpc.config");
                XmlHelper.UpdateNodeInnerText(chinaBankFilePath, @"Root/partner", txtChinaBankPartner.Text);
                XmlHelper.UpdateNodeInnerText(chinaBankFilePath, @"Root/key", txtChinaBankKey.Text);
            }
            else if (model.api_path.ToLower() == "wxapipay")
            {
                //微信公众号支付
                string wxFilePath = Utils.GetMapPath(siteConfig.webpath + "xmlconfig/wxapipay.config");
                XmlHelper.UpdateNodeInnerText(wxFilePath, @"Root/partner", txtWxPartner.Text);
                XmlHelper.UpdateNodeInnerText(wxFilePath, @"Root/key", txtWxKey.Text);
                XmlHelper.UpdateNodeInnerText(wxFilePath, @"Root/appid", txtWxAppId.Text);
                XmlHelper.UpdateNodeInnerText(wxFilePath, @"Root/appsecret", txtWxAppSecret.Text);
            }
            else if (model.api_path.ToLower() == "wxnatpay")
            {
                //微信扫码支付
                string wxFilePath = Utils.GetMapPath(siteConfig.webpath + "xmlconfig/wxnatpay.config");
                XmlHelper.UpdateNodeInnerText(wxFilePath, @"Root/partner", txtWxPartner.Text);
                XmlHelper.UpdateNodeInnerText(wxFilePath, @"Root/key", txtWxKey.Text);
                XmlHelper.UpdateNodeInnerText(wxFilePath, @"Root/appid", txtWxAppId.Text);
            }

            if (bll.Update(model))
            {
                AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改支付方式:" + model.title); //记录日志
                result = true;
            }

            return result;
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("order_payment", DTEnums.ActionEnum.Edit.ToString()); //检查权限
            if (!DoEdit(this.id))
            {
                JscriptMsg("保存过程中发生错误！", string.Empty);
                return;
            }
            JscriptMsg("修改配置成功！", "payment_list.aspx");
        }

    }
}