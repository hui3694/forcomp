﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DTcms.Common
{
    public class DTKeys
    {
        //系统版本
        /// <summary>
        /// 版本号全称
        /// </summary>
        public const string ASSEMBLY_VERSION = "4.0.3";
        /// <summary>
        /// 版本年号
        /// </summary>
        public const string ASSEMBLY_YEAR = "2015";
        /// <summary>
        /// 加密配置名称
        /// </summary>
        public const string SYSTEM_OPEN_ENCRYPT = "OpenEncrypt";
        /// <summary>
        /// 安全码
        /// </summary>
        public const string SECURITY_CODE = "2L00BN6H";
        /// <summary>
        /// 加密/解密－密匙
        /// </summary>
        public const string ENCRYPT_KEY = "JTPT6ND0";
        /// <summary>
        /// Cookie 加密密匙
        /// </summary>
        public const string COOKIE_KEY = "D624282L";
        /// <summary>
        /// 用户名称密码缓存
        /// </summary>
        public const string COOKIE_ENCRYPT = "6VZ8XXXF";

        //File======================================================
        /// <summary>
        /// 插件配制文件名
        /// </summary>
        public const string FILE_PLUGIN_XML_CONFING = "plugin.config";
        /// <summary>
        /// 站点配置文件名
        /// </summary>
        public const string FILE_SITE_XML_CONFING = "Configpath";
        /// <summary>
        /// URL配置文件名
        /// </summary>
        public const string FILE_URL_XML_CONFING = "Urlspath";
        /// <summary>
        /// 用户配置文件名
        /// </summary>
        public const string FILE_USER_XML_CONFING = "Userpath";
        /// <summary>
        /// 订单配置文件名
        /// </summary>
        public const string FILE_ORDER_XML_CONFING = "Orderpath";
        /// <summary>
        /// Lucene.NET配置文件
        /// </summary>
        public const string FILE_LUCENE_XML_CONFING = "LucenePath";

        //Directory==================================================
        /// <summary>
        /// ASPX目录名
        /// </summary>
        public const string DIRECTORY_REWRITE_ASPX = "aspx";
        /// <summary>
        /// HTML目录名
        /// </summary>
        public const string DIRECTORY_REWRITE_HTML = "html";
        /// <summary>
        /// 插件目录名
        /// </summary>
        public const string DIRECTORY_REWRITE_PLUGIN = "plugin";
        /// <summary>
        /// 盘古分词词库路径
        /// </summary>
        public const string FILE_PANGU_DIC_PATH = "PanguPath";
        /// <summary>
        /// Lucene.NET索引路径
        /// </summary>
        public const string FILE_LUCENE_DATA_PATH = "LuceneData";

        //Cache======================================================
        /// <summary>
        /// 站点配置
        /// </summary>
        public const string CACHE_SITE_CONFIG = "dt_cache_site_config";
        /// <summary>
        /// 用户配置
        /// </summary>
        public const string CACHE_USER_CONFIG = "dt_cache_user_config";
        /// <summary>
        /// 订单配置
        /// </summary>
        public const string CACHE_ORDER_CONFIG = "dt_cache_order_config";
        /// <summary>
        /// HttpModule映射类
        /// </summary>
        public const string CACHE_SITE_HTTP_MODULE = "dt_cache_http_module";
        /// <summary>
        /// 绑定域名
        /// </summary>
        public const string CACHE_SITE_HTTP_DOMAIN = "dt_cache_http_domain";
        /// <summary>
        /// 站点一级目录名
        /// </summary>
        public const string CACHE_SITE_DIRECTORY = "dt_cache_site_directory";
        /// <summary>
        /// 站点ASPX目录名
        /// </summary>
        public const string CACHE_SITE_ASPX_DIRECTORY = "dt_cache_site_aspx_directory";
        /// <summary>
        /// URL重写映射表
        /// </summary>
        public const string CACHE_SITE_URLS = "dt_cache_site_urls";
        /// <summary>
        /// URL重写LIST列表
        /// </summary>
        public const string CACHE_SITE_URLS_LIST = "dt_cache_site_urls_list";
        /// <summary>
        /// 升级通知
        /// </summary>
        public const string CACHE_OFFICIAL_UPGRADE = "dt_official_upgrade";
        /// <summary>
        /// 官方消息
        /// </summary>
        public const string CACHE_OFFICIAL_NOTICE = "dt_official_notice";

        //Session=====================================================
        /// <summary>
        /// 网页验证码
        /// </summary>
        public const string SESSION_CODE = "dt_session_code";
        /// <summary>
        /// 短信验证码
        /// </summary>
        public const string SESSION_SMS_CODE = "dt_session_sms_code";
        /// <summary>
        /// 后台管理员
        /// </summary>
        public const string SESSION_ADMIN_INFO = "dt_session_admin_info";
        /// <summary>
        /// 会员用户
        /// </summary>
        public const string SESSION_USER_INFO = "dt_session_user_info";

        //Cookies=====================================================
        /// <summary>
        /// 防重复顶踩KEY
        /// </summary>
        public const string COOKIE_DIGG_KEY = "dt_cookie_digg_key";
        /// <summary>
        /// 防重复评论KEY
        /// </summary>
        public const string COOKIE_COMMENT_KEY = "dt_cookie_comment_key";
        /// <summary>
        /// 记住会员用户名
        /// </summary>
        public const string COOKIE_USER_NAME_REMEMBER = "dt_cookie_user_name_remember";
        /// <summary>
        /// 记住会员密码
        /// </summary>
        public const string COOKIE_USER_PWD_REMEMBER = "dt_cookie_user_pwd_remember";
        /// <summary>
        /// 用户手机号码
        /// </summary>
        public const string COOKIE_USER_MOBILE = "dt_cookie_user_mobile";
        /// <summary>
        /// 用户电子邮箱
        /// </summary>
        public const string COOKIE_USER_EMAIL = "dt_cookie_user_email";
        /// <summary>
        /// 购物车
        /// </summary>
        public const string COOKIE_SHOPPING_CART = "dt_cookie_shopping_cart";
        /// <summary>
        /// 结账清单
        /// </summary>
        public const string COOKIE_SHOPPING_BUY = "dt_cookie_shopping_buy";
        /// <summary>
        /// 返回上一页
        /// </summary>
        public const string COOKIE_URL_REFERRER = "dt_cookie_url_referrer";
    }
}
