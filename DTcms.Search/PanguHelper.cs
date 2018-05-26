using System;
using System.Collections.Generic;
using System.Text;
using PanGu;
using PanGu.Dict;
using DTcms.Common;

namespace DTcms.Search
{
    public class PanguHelper
    {
        private WordDictionary wordDict = null;
        private string dicPath = string.Empty;

        public PanguHelper()
        {
            dicPath = Utils.GetXmlMapPath(DTKeys.FILE_PANGU_DIC_PATH);
            if (null == wordDict)
            {
                wordDict = new WordDictionary();
                wordDict.Load(dicPath);
            }
        }

        /// <summary>
        /// 获取词库词语总数
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return wordDict.Count;
        }

        /// <summary>
        /// 按关键词查询
        /// </summary>
        /// <param name="keywords">关键词</param>
        /// <returns></returns>
        public List<SearchWordResult> Search(string keywords)
        {
            List<SearchWordResult> result = wordDict.Search(keywords);
            result.Sort();
            return result;
        }

        /// <summary>
        /// 按关键词查询
        /// </summary>
        /// <param name="keywords">关键词</param>
        /// <returns></returns>
        public List<string> SearchWord(string keywords)
        {
            return SearchWord(keywords, 10);
        }

        /// <summary>
        /// 按关键词查询
        /// </summary>
        /// <param name="keywords">关键词</param>
        /// <returns></returns>
        public List<string> SearchWord(string keywords, int length)
        {
            List<SearchWordResult> result = wordDict.Search(keywords);
            result.Sort();
            int top = length;
            List<string> list = new List<string>();
            foreach (SearchWordResult word in result)
            {
                list.Add(word.ToString());
                top--;
                if (top == 0)
                {
                    break;
                }
            }
            return list;
        }

        /// <summary>
        /// 按关键词查询
        /// </summary>
        /// <param name="keywords">关键词</param>
        /// <returns></returns>
        public List<string> SearchWord(string keywords, int length, out int count)
        {
            List<SearchWordResult> result = wordDict.Search(keywords);
            result.Sort();
            count = result.Count;
            int top = length;
            List<string> list = new List<string>();
            foreach (SearchWordResult word in result)
            {
                list.Add(word.ToString());
                top--;
                if (top == 0)
                {
                    break;
                }
            }
            return list;
        }

        /// <summary>
        /// 按词性查询
        /// </summary>
        /// <param name="pos">词性</param>
        /// <returns></returns>
        public List<SearchWordResult> SearchByPos(int pos)
        {
            List<SearchWordResult> result = wordDict.SearchByPos((POS)pos);
            result.Sort();
            return result;
        }

        /// <summary>
        /// 按长度查询
        /// </summary>
        /// <param name="pos">词语长度</param>
        /// <returns></returns>
        public List<SearchWordResult> SearchByLength(int length)
        {
            List<SearchWordResult> result = wordDict.SearchByLength(length);
            result.Sort();
            return result;
        }

        /// <summary>
        /// 匹配关键词属性
        /// </summary>
        /// <param name="keywords"></param>
        /// <returns></returns>
        public WordAttribute GetWordAttr(string keywords)
        {
            WordAttribute selWord = wordDict.GetWordAttr(keywords);
            if (selWord != null)
            {
                return selWord;
            }
            return null;
        }

        /// <summary>
        /// 匹配关键词属性
        /// </summary>
        /// <param name="keywords"></param>
        /// <returns></returns>
        public double GetWordAttr(string keywords, out int pos)
        {
            pos = -1;
            WordAttribute selWord = wordDict.GetWordAttr(keywords);
            if (selWord != null)
            {
                pos = (int)selWord.Pos;
                return selWord.Frequency;
            }
            return 0;
        }

        /// <summary>
        /// 新增关键词
        /// </summary>
        /// <param name="keywords">关键词</param>
        /// <param name="number">词频</param>
        /// <param name="pos">词性</param>
        /// <returns></returns>
        public bool InsertWord(string keywords, double number, int pos)
        {
            if (string.IsNullOrEmpty(keywords))
            {
                return false;
            }
            WordAttribute selWord = wordDict.GetWordAttr(keywords);
            if (null != selWord)
            {
                return false;
            }
            wordDict.InsertWord(keywords, number, (POS)pos);
            return true;
        }

        /// <summary>
        /// 修改关键词
        /// </summary>
        /// <param name="keywords">关键词</param>
        /// <param name="number">词频</param>
        /// <param name="pos">词性</param>
        /// <returns></returns>
        public bool UpdateWord(string keywords, double number, int pos)
        {
            if (string.IsNullOrEmpty(keywords))
            {
                return false;
            }
            wordDict.UpdateWord(keywords, number, (POS)pos);
            return true;
        }

        /// <summary>
        /// 删除关键词
        /// </summary>
        /// <param name="keywords">关键词</param>
        /// <returns></returns>
        public bool DeleteWord(string keywords)
        {
            if (string.IsNullOrEmpty(keywords))
            {
                return false;
            }
            wordDict.DeleteWord(keywords);
            return true;
        }

        /// <summary>
        /// 清空词库
        /// </summary>
        public void DeleteAll()
        {
            wordDict = new WordDictionary();
            Save(DateTime.Now.ToString("yyMMddhh"));
        }

        /// <summary>
        /// 保存词库
        /// </summary>
        /// <param name="vesion">版本</param>
        /// <returns></returns>
        public bool Save(string vesion)
        {
            if (null == wordDict)
            {
                return false;
            }
            wordDict.Save(dicPath, vesion);
            return true;
        }
    }
}
