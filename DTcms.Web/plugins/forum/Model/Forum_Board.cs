using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace DTcms.Web.Plugin.Forum.Model{
	 	//dt_Forum_Board
			
	public class Forum_Board
	{
	
		private int _id = 0;              
		private int _parentid = 0;              
		private int _leftnumber = 0;              
		private int _rightnumber = 0;              
		private int _layer = 0;              
		private int _childcount = 0;              
		private string _name = "";              
		private int _todaytopiccount = 0;              
		private int _topiccount = 0;              
		private int _postcount = 0;              
		private DateTime _createtime = System.DateTime.Now;              
		private DateTime _updatetime = System.DateTime.Now;              
		private string _icon = "";              
		private string _rule = "";              
		private string _description = "";              
		private int _childcol = 0;              
		private int _lastpostuserid = 0;              
		private string _lastpostusername = "";              
		private string _lastpostnickname = "";              
		private int _lasttopicid = 0;              
		private string _lasttopictitle = "";              
		private string _url = "";              
		private int _show = 0;              
		private string _classlist = "";              
		private int _classlayer = 0;              
		private int _sortid = 0;              
				
   		     
      	/// <summary>
		/// Id
        /// </summary>
        public int Id
        {
            get{ return _id; }
            set{ _id = value; }
        }        
		/// <summary>
		/// ParentId
        /// </summary>
        public int ParentId
        {
            get{ return _parentid; }
            set{ _parentid = value; }
        }        
		/// <summary>
		/// LeftNumber
        /// </summary>
        public int LeftNumber
        {
            get{ return _leftnumber; }
            set{ _leftnumber = value; }
        }        
		/// <summary>
		/// RightNumber
        /// </summary>
        public int RightNumber
        {
            get{ return _rightnumber; }
            set{ _rightnumber = value; }
        }        
		/// <summary>
		/// Layer
        /// </summary>
        public int Layer
        {
            get{ return _layer; }
            set{ _layer = value; }
        }        
		/// <summary>
		/// ChildCount
        /// </summary>
        public int ChildCount
        {
            get{ return _childcount; }
            set{ _childcount = value; }
        }        
		/// <summary>
		/// Name
        /// </summary>
        public string Name
        {
            get{ return _name; }
            set{ _name = value; }
        }        
		/// <summary>
		/// TodayTopicCount
        /// </summary>
        public int TodayTopicCount
        {
            get{ return _todaytopiccount; }
            set{ _todaytopiccount = value; }
        }        
		/// <summary>
		/// TopicCount
        /// </summary>
        public int TopicCount
        {
            get{ return _topiccount; }
            set{ _topiccount = value; }
        }        
		/// <summary>
		/// PostCount
        /// </summary>
        public int PostCount
        {
            get{ return _postcount; }
            set{ _postcount = value; }
        }        
		/// <summary>
		/// CreateTime
        /// </summary>
        public DateTime CreateTime
        {
            get{ return _createtime; }
            set{ _createtime = value; }
        }        
		/// <summary>
		/// UpdateTime
        /// </summary>
        public DateTime UpdateTime
        {
            get{ return _updatetime; }
            set{ _updatetime = value; }
        }        
		/// <summary>
		/// Icon
        /// </summary>
        public string Icon
        {
            get{ return _icon; }
            set{ _icon = value; }
        }        
		/// <summary>
		/// Rule
        /// </summary>
        public string Rule
        {
            get{ return _rule; }
            set{ _rule = value; }
        }        
		/// <summary>
		/// Description
        /// </summary>
        public string Description
        {
            get{ return _description; }
            set{ _description = value; }
        }        
		/// <summary>
		/// ChildCol
        /// </summary>
        public int ChildCol
        {
            get{ return _childcol; }
            set{ _childcol = value; }
        }        
		/// <summary>
		/// LastPostUserId
        /// </summary>
        public int LastPostUserId
        {
            get{ return _lastpostuserid; }
            set{ _lastpostuserid = value; }
        }        
		/// <summary>
		/// LastPostUsername
        /// </summary>
        public string LastPostUsername
        {
            get{ return _lastpostusername; }
            set{ _lastpostusername = value; }
        }        
		/// <summary>
		/// LastPostNickname
        /// </summary>
        public string LastPostNickname
        {
            get{ return _lastpostnickname; }
            set{ _lastpostnickname = value; }
        }        
		/// <summary>
		/// LastTopicId
        /// </summary>
        public int LastTopicId
        {
            get{ return _lasttopicid; }
            set{ _lasttopicid = value; }
        }        
		/// <summary>
		/// LastTopicTitle
        /// </summary>
        public string LastTopicTitle
        {
            get{ return _lasttopictitle; }
            set{ _lasttopictitle = value; }
        }        
		/// <summary>
		/// Url
        /// </summary>
        public string Url
        {
            get{ return _url; }
            set{ _url = value; }
        }        
		/// <summary>
		/// Show
        /// </summary>
        public int Show
        {
            get{ return _show; }
            set{ _show = value; }
        }        
		/// <summary>
		/// ClassList
        /// </summary>
        public string ClassList
        {
            get{ return _classlist; }
            set{ _classlist = value; }
        }        
		/// <summary>
		/// ClassLayer
        /// </summary>
        public int ClassLayer
        {
            get{ return _classlayer; }
            set{ _classlayer = value; }
        }        
		/// <summary>
		/// SortId
        /// </summary>
        public int SortId
        {
            get{ return _sortid; }
            set{ _sortid = value; }
        }        
				

   
	}
}

		