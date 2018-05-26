using System;
using PanGu;

namespace DTcms.Search
{
    public class Utility
    {
        /// <summary>
        /// 返回词性
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public static String GetChsPos(int pos)
        {
            return GetChsPos((POS)pos);
        }
        /// <summary>
        /// 返回词性
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public static String GetChsPos(POS pos)
        {
            switch (pos)
            {
                case POS.POS_D_A:	//	形容词 形语素
                    return "形容词 形语素";
                case POS.POS_D_B:	//	区别词 区别语素
                    return "区别词 区别语素";
                case POS.POS_D_C:	//	连词 连语素
                    return "连词 连语素";
                case POS.POS_D_D:	//	副词 副语素
                    return "副词 副语素";
                case POS.POS_D_E:	//	叹词 叹语素
                    return "叹词 叹语素";
                case POS.POS_D_F:	//	方位词 方位语素
                    return "方位词 方位语素";
                case POS.POS_D_I:	//	成语
                    return "成语";
                case POS.POS_D_L:	//	习语
                    return "习语";
                case POS.POS_A_M:	//	数词 数语素
                    return "数词 数语素";
                case POS.POS_D_MQ:   //	数量词
                    return "数量词";
                case POS.POS_D_N:	//	名词 名语素
                    return "名词 名语素";
                case POS.POS_D_O:	//	拟声词
                    return "拟声词";
                case POS.POS_D_P:	//	介词
                    return "介词";
                case POS.POS_A_Q:	//	量词 量语素
                    return "量词 量语素";
                case POS.POS_D_R:	//	代词 代语素
                    return "代词 代语素";
                case POS.POS_D_S:	//	处所词
                    return "处所词";
                case POS.POS_D_T:	//	时间词
                    return "时间词";
                case POS.POS_D_U:	//	助词 助语素
                    return "助词 助语素";
                case POS.POS_D_V:	//	动词 动语素
                    return "动词 动语素";
                case POS.POS_D_W:	//	标点符号
                    return "标点符号";
                case POS.POS_D_X:	//	非语素字
                    return "非语素字";
                case POS.POS_D_Y:	//	语气词 语气语素
                    return "语气词 语气语素";
                case POS.POS_D_Z:	//	状态词
                    return "状态词";
                case POS.POS_A_NR://	人名
                    return "人名";
                case POS.POS_A_NS://	地名
                    return "地名";
                case POS.POS_A_NT://	机构团体
                    return "机构团体";
                case POS.POS_A_NX://	外文字符
                    return "外文字符";
                case POS.POS_A_NZ://	其他专名
                    return "其他专名";
                case POS.POS_D_H:	//	前接成分
                    return "前接成分";
                case POS.POS_D_K:	//	后接成分
                    return "后接成分";
                case POS.POS_UNK://  未知词性
                    return "未知词性";
                default:
                    return "未知词性";
            }
        }
    }
}
