using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PanGu;
using Lucene.Net.Index;
using Lucene.Net.Documents;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Search;
using Lucene.Net.QueryParsers;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.PanGu;
using DTcms.Common;

namespace DTcms.Search
{
    public class SearchItem
    {
        /// <summary>
        /// 自增ID
        /// </summary>
        public int id { set; get; }
        /// <summary>
        /// 网站ID
        /// </summary>
        public int site_id { set; get; }
        /// <summary>
        /// 频道ID
        /// </summary>
        public int channel_id { set; get; }
        /// <summary>
        /// 类别ID
        /// </summary>
        public int category_id { set; get; }
        /// <summary>
        /// 标题
        /// </summary>
        public string title { set; get; }
        ///// <summary>
        ///// 副标题
        ///// </summary>
        //public string sub_title { set; get; }
        /// <summary>
        /// 调用名
        /// </summary>
        public string call_index { set; get; }
        /// <summary>
        /// 图片地址
        /// </summary>
        public string img_url { set; get; }
        /// <summary>
        /// 标签
        /// </summary>
        public string tags { set; get; }
        /// <summary>
        /// 内容摘要
        /// </summary>
        public string zhaiyao { set; get; }
        ///// <summary>
        ///// 是否置顶
        ///// </summary>
        //public int is_top { set; get; }
        ///// <summary>
        ///// 是否推荐
        ///// </summary>
        //public int is_red { set; get; }
        ///// <summary>
        ///// 是否执门
        ///// </summary>
        //public int is_hot { set; get; }
        ///// <summary>
        ///// 市场价格
        ///// </summary>
        //public decimal market_price { set; get; }
        ///// <summary>
        ///// 销售价格
        ///// </summary>
        //public decimal sell_price { set; get; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime add_time { set; get; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime update_time { set; get; }
    }
    public class LuceneHelper
    {
        private static IndexWriter writer = null;
        /// <summary>
        /// 索引目录
        /// </summary>
        public static String INDEX_DIR
        {
            get
            {
                return Utils.GetXmlMapPath(DTKeys.FILE_LUCENE_DATA_PATH);
            }
        }
        public static int MaxMergeFactor
        {
            get
            {
                if (writer != null)
                {
                    return writer.GetMergeFactor();
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                if (writer != null)
                {
                    writer.SetMergeFactor(value);
                }
            }
        }
        public static int MaxMergeDocs
        {
            get
            {
                if (writer != null)
                {
                    return writer.GetMaxMergeDocs();
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                if (writer != null)
                {
                    writer.SetMaxMergeDocs(value);
                }
            }
        }
        public static int MinMergeDocs
        {
            get
            {
                if (writer != null)
                {
                    return writer.GetMaxBufferedDocs();
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                if (writer != null)
                {
                    writer.SetMaxBufferedDocs(value);
                }
            }
        }
        public static void CreateIndex(String indexDir, int create)
        {
            if (create == 0)
            {
                try
                {
                    writer = new IndexWriter(indexDir, new PanGuAnalyzer(), false);
                }
                catch
                {
                    writer = new IndexWriter(indexDir, new PanGuAnalyzer(), true);
                }
            }
            else
            {
                writer = new IndexWriter(indexDir, new PanGuAnalyzer(), true);
            }
        }
        /// <summary>
        /// 创建索引
        /// </summary>
        /// <param name="indexDir">索引文件目录</param>
        /// <param name="item">索引内容</param>
        /// <returns>索引总数</returns>
        public static int IndexString(String indexDir, SearchItem item)
        {
            Document doc = new Document();
            doc.Add(new Field("id", item.id.ToString(), Field.Store.YES, Field.Index.NO));
            doc.Add(new Field("sid", item.site_id.ToString(), Field.Store.YES, Field.Index.TOKENIZED));
            doc.Add(new Field("hid", item.channel_id.ToString(), Field.Store.YES, Field.Index.TOKENIZED));
            doc.Add(new Field("cid", item.category_id.ToString(), Field.Store.YES, Field.Index.UN_TOKENIZED));
            //doc.Add(new Field("top", item.is_top.ToString(), Field.Store.YES, Field.Index.UN_TOKENIZED));
            //doc.Add(new Field("red", item.is_red.ToString(), Field.Store.YES, Field.Index.UN_TOKENIZED));
            //doc.Add(new Field("hot", item.is_hot.ToString(), Field.Store.YES, Field.Index.UN_TOKENIZED));
            //Fieldable market = new NumericField("market", Field.Store.YES, true);
            //((NumericField)market).SetDoubleValue(Convert.ToDouble(item.market_price));
            //doc.Add(market);
            //Fieldable sell = new NumericField("sell", Field.Store.YES, true);
            //((NumericField)sell).SetDoubleValue(Convert.ToDouble(item.sell_price));
            //doc.Add(sell);
            doc.Add(new Field("title", item.title, Field.Store.YES, Field.Index.TOKENIZED));
            doc.Add(new Field("cidx", item.call_index, Field.Store.YES, Field.Index.NO));
            doc.Add(new Field("tags", item.tags, Field.Store.YES, Field.Index.TOKENIZED));
            doc.Add(new Field("zhaiyao", item.zhaiyao, Field.Store.YES, Field.Index.TOKENIZED));
            doc.Add(new Field("img", item.img_url, Field.Store.YES, Field.Index.NO));
            doc.Add(new Field("atime", item.add_time.ToString(), Field.Store.YES, Field.Index.NO));
            doc.Add(new Field("utime", item.update_time.ToString(), Field.Store.YES, Field.Index.NO));
            writer.AddDocument(doc);
            int num = writer.DocCount();
            return num;
        }

        /// <summary>
        /// 关闭（不优化）
        /// </summary>
        public static void CloseWithoutOptimize()
        {
            writer.Close();
        }

        /// <summary>
        /// 关闭并优化
        /// </summary>
        public static void Close()
        {
            writer.Optimize();
            writer.Close();
        }

        /// <summary>
        /// 分词
        /// </summary>
        /// <param name="keywords">关键词</param>
        /// <param name="ktTokenizer">词库</param>
        /// <returns></returns>
        public static string GetKeyWordsSplitBySpace(string keywords, PanGuTokenizer ktTokenizer)
        {
            StringBuilder result = new StringBuilder();
            ICollection<WordInfo> words = ktTokenizer.SegmentToWordInfos(keywords);
            foreach (WordInfo word in words)
            {
                if (null == word || word.Word.Length < 2)
                {
                    continue;
                }
                result.AppendFormat("{0}^{1}.0 ", word.Word, (int)Math.Pow(3, word.Rank));
            }
            return result.ToString().Trim();
        }

        /// <summary>
        /// 索引查询
        /// </summary>
        /// <param name="indexDir">索引文件路径</param>
        /// <param name="top">数量</param>
        /// <param name="site_id">网站ID</param>
        /// <param name="channel_id">频道ID</param>
        /// <param name="category_id">类别ID</param>
        /// <param name="keywords">关键词</param>
        /// <param name="is_high">是否高量显示</param>
        /// <returns></returns>
        public static DataTable Search(string indexDir, int top, int site_id, int channel_id, int category_id, String keywords)
        {
            IndexSearcher search = new IndexSearcher(indexDir);
            if (keywords.Length > 1)
            {
                keywords = GetKeyWordsSplitBySpace(keywords, new PanGuTokenizer());
            }
            //查询条件
            BooleanQuery bq = new BooleanQuery();
            if (site_id > 0)
            {
                Term t = new Term("sid", site_id.ToString());
                Query query = new TermQuery(t);
                bq.Add(query, BooleanClause.Occur.MUST);
            }
            if (channel_id > 0)
            {
                Term t = new Term("hid", channel_id.ToString());
                Query query = new TermQuery(t);
                bq.Add(query, BooleanClause.Occur.MUST);
            }
            if (category_id > 0)
            {
                Term t = new Term("cid", category_id.ToString());
                Query query = new TermQuery(t);
                bq.Add(query, BooleanClause.Occur.MUST);
            }
            if (null != keywords && keywords.Length > 0)
            {
                string[] fields = { "title", "tags", "zhaiyao" };
                MultiFieldQueryParser parser = new MultiFieldQueryParser(fields, new PanGuAnalyzer(true));
                Query query = parser.Parse(keywords);
                bq.Add(query, BooleanClause.Occur.MUST);
            }
            //搜索
            //Sort sort = new Sort(new SortField(null, SortField.DOC, true)); //排序
            Sort sort = Sort.RELEVANCE;
            Hits hits = search.Search(bq, sort);

            DataTable dt = new DataTable();
            dt.Columns.Add("id", Type.GetType("System.Int32"));
            dt.Columns.Add("site_id", Type.GetType("System.Int32"));
            dt.Columns.Add("channel_id", Type.GetType("System.Int32"));
            dt.Columns.Add("category_id", Type.GetType("System.Int32"));
            dt.Columns.Add("title", Type.GetType("System.String"));
            dt.Columns.Add("call_index", Type.GetType("System.String"));
            dt.Columns.Add("img_url", Type.GetType("System.String"));
            dt.Columns.Add("tags", Type.GetType("System.String"));
            dt.Columns.Add("zhaiyao", Type.GetType("System.String"));
            dt.Columns.Add("add_time", Type.GetType("System.DateTime"));
            dt.Columns.Add("update_time", Type.GetType("System.DateTime"));
            dt.Columns.Add("titlehighlight", Type.GetType("System.String"));
            dt.Columns.Add("zhaiyaohighlight", Type.GetType("System.String"));

            int i = 0;
            int recordCount = hits.Length();
            string title, zhaiyao;

            while (i < top && i < recordCount && dt.Rows.Count < top)
            {
                title = hits.Doc(i).Get("title");
                zhaiyao = hits.Doc(i).Get("zhaiyao");

                DataRow row = dt.NewRow();
                row["id"] = Utils.StrToInt(hits.Doc(i).Get("id"), 0);
                row["site_id"] = Utils.StrToInt(hits.Doc(i).Get("sid"), 0);
                row["channel_id"] = Utils.StrToInt(hits.Doc(i).Get("hid"), 0);
                row["category_id"] = Utils.StrToInt(hits.Doc(i).Get("cid"), 0);
                row["title"] = title;
                row["call_index"] = hits.Doc(i).Get("cidx");
                row["tags"] = hits.Doc(i).Get("tags");
                row["zhaiyao"] = zhaiyao;
                row["img_url"] = hits.Doc(i).Get("img");
                row["add_time"] = Utils.StrToDateTime(hits.Doc(i).Get("atime"));
                row["update_time"] = Utils.StrToDateTime(hits.Doc(i).Get("utime"));
                //高亮
                PanGu.HighLight.SimpleHTMLFormatter simpleHTMLFormatter = new PanGu.HighLight.SimpleHTMLFormatter("<font color=\"red\">", "</font>");
                PanGu.HighLight.Highlighter highlighter = new PanGu.HighLight.Highlighter(simpleHTMLFormatter, new PanGu.Segment());
                highlighter.FragmentSize = 50;
                title = highlighter.GetBestFragment(keywords, title);
                if (string.IsNullOrEmpty(title))
                {
                    row["titlehighlight"] = row["title"];
                }
                else
                {
                    row["titlehighlight"] = title;
                }
                zhaiyao = highlighter.GetBestFragment(keywords, zhaiyao);
                if (string.IsNullOrEmpty(zhaiyao))
                {
                    row["zhaiyaohighlight"] = row["zhaiyao"];
                }
                else
                {
                    row["zhaiyaohighlight"] = zhaiyao;
                }
                //填充
                dt.Rows.Add(row);
                //自增
                i++;
            }
            search.Close();
            return dt;
        }

        /// <summary>
        /// 索引查询
        /// </summary>
        /// <param name="indexDir">索引文件路径</param>
        /// <param name="pageSize">分页</param>
        /// <param name="pageIndex">当前分页</param>
        /// <param name="site_id">网站ID</param>
        /// <param name="channel_id">频道ID</param>
        /// <param name="category_id">类别ID</param>
        /// <param name="keywords">关键词</param>
        /// <param name="is_high">是否高亮显示</param>
        /// <param name="recordCount">总数</param>
        /// <returns></returns>
        public static DataTable Search(String indexDir, int pageSize, int pageIndex, int site_id, int channel_id, int category_id, String keywords, out int recordCount)
        {
            IndexSearcher search = new IndexSearcher(indexDir);
            if (keywords.Length > 1)
            {
                keywords = GetKeyWordsSplitBySpace(keywords, new PanGuTokenizer());
            }
            //查询条件
            BooleanQuery bq = new BooleanQuery();
            if (site_id > 0)
            {
                Term t = new Term("sid", site_id.ToString());
                Query query = new TermQuery(t);
                bq.Add(query, BooleanClause.Occur.MUST);
            }
            if (channel_id > 0)
            {
                Term t = new Term("hid", channel_id.ToString());
                Query query = new TermQuery(t);
                bq.Add(query, BooleanClause.Occur.MUST);
            }
            if (category_id > 0)
            {
                Term t = new Term("cid", category_id.ToString());
                Query query = new TermQuery(t);
                bq.Add(query, BooleanClause.Occur.MUST);
            }
            if (null != keywords && keywords.Length > 0)
            {
                string[] fields = { "title", "tags", "zhaiyao" };
                MultiFieldQueryParser parser = new MultiFieldQueryParser(fields, new PanGuAnalyzer(true));
                Query query = parser.Parse(keywords);
                bq.Add(query, BooleanClause.Occur.MUST);
            }
            //搜索
            Sort sort = Sort.RELEVANCE;
            Hits hits = search.Search(bq, sort);
            recordCount = hits.Length();

            DataTable dt = HitsToDataTable(hits, (pageIndex - 1) * pageSize, pageSize, keywords);
            search.Close();
            return dt;
        }

        /// <summary>
        /// 索引查询
        /// </summary>
        /// <param name="indexDir">索引文件路径</param>
        /// <param name="pageSize">分页</param>
        /// <param name="pageIndex">当前分页</param>
        /// <param name="keywords">关键词</param>
        /// <param name="strWhere">条件</param>
        /// <param name="filedOrder">排序</param>
        /// <param name="is_high">是否高亮显示</param>
        /// <param name="recordCount">总数</param>
        /// <returns></returns>
        public static DataTable Search(String indexDir, int pageSize, int pageIndex, int site_id, int channel_id, string keywords, BooleanQuery strWhere, Sort filedOrder, out int recordCount)
        {
            IndexSearcher search = new IndexSearcher(indexDir);
            keywords = GetKeyWordsSplitBySpace(keywords, new PanGuTokenizer());
            if (null != keywords && keywords.Length > 0)
            {
                string[] fields = { "title", "sub", "tags", "zhaiyao" };
                MultiFieldQueryParser parser = new MultiFieldQueryParser(fields, new PanGuAnalyzer(true));
                Query query = parser.Parse(keywords);
                strWhere.Add(query, BooleanClause.Occur.MUST);
            }
            Hits hits = search.Search(strWhere, filedOrder);
            recordCount = hits.Length();

            DataTable dt = HitsToDataTable(hits, (pageIndex - 1) * pageSize, pageSize, keywords);
            search.Close();
            return dt;
        }

        #region  私有方法
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hits"></param>
        /// <param name="i"></param>
        /// <param name="pageSize"></param>
        /// <param name="keywords"></param>
        /// <returns></returns>
        private static DataTable HitsToDataTable(Hits hits, int i, int pageSize, string keywords)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", Type.GetType("System.Int32"));
            dt.Columns.Add("site_id", Type.GetType("System.Int32"));
            dt.Columns.Add("channel_id", Type.GetType("System.Int32"));
            dt.Columns.Add("category_id", Type.GetType("System.Int32"));
            dt.Columns.Add("title", Type.GetType("System.String"));
            //dt.Columns.Add("sub_title", Type.GetType("System.String"));
            dt.Columns.Add("call_index", Type.GetType("System.String"));
            dt.Columns.Add("img_url", Type.GetType("System.String"));
            dt.Columns.Add("tags", Type.GetType("System.String"));
            dt.Columns.Add("zhaiyao", Type.GetType("System.String"));
            //dt.Columns.Add("is_top", Type.GetType("System.Int32"));
            //dt.Columns.Add("is_red", Type.GetType("System.Int32"));
            //dt.Columns.Add("is_hot", Type.GetType("System.Int32"));
            //dt.Columns.Add("market_price", Type.GetType("System.Decimal"));
            //dt.Columns.Add("sell_price", Type.GetType("System.Decimal"));
            dt.Columns.Add("add_time", Type.GetType("System.DateTime"));
            dt.Columns.Add("update_time", Type.GetType("System.DateTime"));
            dt.Columns.Add("titlehighlight", Type.GetType("System.String"));
            dt.Columns.Add("zhaiyaohighlight", Type.GetType("System.String"));

            int total = hits.Length();
            string title ,zhaiyao ;

            while (i < total && dt.Rows.Count < pageSize)
            {
                title = hits.Doc(i).Get("title");
                zhaiyao = hits.Doc(i).Get("zhaiyao");

                DataRow row = dt.NewRow();
                row["id"] = Utils.StrToInt(hits.Doc(i).Get("id"), 0);
                row["site_id"] = Utils.StrToInt(hits.Doc(i).Get("sid"), 0);
                row["channel_id"] = Utils.StrToInt(hits.Doc(i).Get("hid"), 0);
                row["category_id"] = Utils.StrToInt(hits.Doc(i).Get("cid"), 0);
                row["title"] = title;
                //row["sub_title"] = hits.Doc(i).Get("sub");
                row["call_index"] = hits.Doc(i).Get("cidx");
                row["tags"] = hits.Doc(i).Get("tags");
                row["zhaiyao"] = zhaiyao;
                //row["is_top"] = Utils.StrToInt(hits.Doc(i).Get("top"), 0);
                //row["is_red"] = Utils.StrToInt(hits.Doc(i).Get("red"), 0);
                //row["is_hot"] = Utils.StrToInt(hits.Doc(i).Get("hot"), 0);
                row["img_url"] = hits.Doc(i).Get("img");
                //row["market_price"] = Utils.StrToDecimal(hits.Doc(i).Get("market"), 0);
                //row["sell_price"] = Utils.StrToDecimal(hits.Doc(i).Get("sell"), 0);
                row["add_time"] = Utils.StrToDateTime(hits.Doc(i).Get("atime"));
                row["update_time"] = Utils.StrToDateTime(hits.Doc(i).Get("utime"));
                //高亮
                PanGu.HighLight.SimpleHTMLFormatter simpleHTMLFormatter = new PanGu.HighLight.SimpleHTMLFormatter("<font color=\"red\">", "</font>");
                PanGu.HighLight.Highlighter highlighter = new PanGu.HighLight.Highlighter(simpleHTMLFormatter, new PanGu.Segment());
                highlighter.FragmentSize = 100;
                title = highlighter.GetBestFragment(keywords, title);
                if (string.IsNullOrEmpty(title))
                {
                    row["titlehighlight"] = row["title"];
                }
                else
                {
                    row["titlehighlight"] = title;
                }
                zhaiyao = highlighter.GetBestFragment(keywords, zhaiyao);
                if (string.IsNullOrEmpty(zhaiyao))
                {
                    row["zhaiyaohighlight"] = Utils.CutString(row["zhaiyao"].ToString(), 100);
                }
                else
                {
                    row["zhaiyaohighlight"] = zhaiyao;
                }
                //填充
                dt.Rows.Add(row);
                //自增
                i++;
            }
            return dt;
        }
        #endregion
    }
}
