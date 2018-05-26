using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace DTcms.Common
{
    public class PageCache
    {
        /// <summary>
        /// 缓存路径格式化
        /// </summary>
        /// <param name="cachePath"></param>
        /// <returns></returns>
        public static string CachePathFormart(string cachePath)
        {
            cachePath = cachePath.Replace("{", "\" + ");
            cachePath = cachePath.Replace("}", " + \"");
            return cachePath;
        }
        /// <summary>
        /// 读取缓存内容
        /// </summary>
        /// <param name="cacheKey">缓存名称</param>
        /// <returns></returns>
        public static string GetCache(string cacheKey)
        {
            object obj = CacheHelper.Get(cacheKey);
            if (null == obj)
            {
                return null;
            }
            return Convert.ToString(obj);
        }
        /// <summary>
        /// 写入缓存文件文件
        /// </summary>
        /// <param name="pageCache">是否开启缓存</param>
        /// <param name="fomatCode">是否格式化代码</param>
        /// <param name="filePath">文件路径</param>
        /// <param name="_content">内容</param>
        /// <param name="format">格式化内容</param>
        public static void WriteCache(string html, int cache, int cachetime, string cacheKey, int fomatCode)
        {
            if (cache == 1)
            {
                //是否格式化代码
                if (fomatCode == 1)
                {
                    html = Regex.Replace(html, " {2,}", " ");
                    html = Regex.Replace(html, @"\t+", "");
                    html = Regex.Replace(html, @"[\r\n\s?\r\n]{2,}", "\r\n");
                }
                CacheHelper.Insert(cacheKey, html, cachetime);
            }
        }
    }
}
