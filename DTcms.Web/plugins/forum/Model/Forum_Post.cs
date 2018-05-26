using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace DTcms.Web.Plugin.Forum.Model{
	 	//dt_Forum_Post_
			
	public class Forum_Post
	{
	
		private int _id = 0;              
		private int _boardid = 0;              
		private int _topicid = 0;              
		private int _postuserid = 0;              
		private string _postusername = "";              
		private string _postnickname = "";              
		private string _postuserip = ""; 
		private DateTime _postdatetime = System.DateTime.Now;              
		private string _title = "";              
		private string _message = "";              
		private int _html = 0;              
		private int _smile = 0;              
		private int _ubb = 0;              
		private int _attachment = 0;              
		private int _signature = 1;              
		private int _url = 1;              
		private int _audit = 0;              
		private int _first = 0;              
		private int _invisible = 0;              
		private int _ban = 0;              
		private int _grade = 0;              
		private int _hide = 0;              
		private int _updateuserid = 0;              
		private string _updateusername = "";              
		private string _updatenickname = "";              
		private DateTime _updatetime = System.DateTime.Now;              
		private int _support = 0;              
		private int _against = 0;

        private string _quotepostids = "";
		private int _quoteuserid = 0;              
		private string _quotemessage = "";              
		private string _quotenickname = "";              
				
   		     
      	/// <summary>
		/// Id
        /// </summary>
        public int Id
        {
            get{ return _id; }
            set{ _id = value; }
        }        
		/// <summary>
		/// BoardId
        /// </summary>
        public int BoardId
        {
            get{ return _boardid; }
            set{ _boardid = value; }
        }        
		/// <summary>
		/// TopicId
        /// </summary>
        public int TopicId
        {
            get{ return _topicid; }
            set{ _topicid = value; }
        }        
		/// <summary>
		/// PostUserId
        /// </summary>
        public int PostUserId
        {
            get{ return _postuserid; }
            set{ _postuserid = value; }
        }        
		/// <summary>
		/// PostUsername
        /// </summary>
        public string PostUsername
        {
            get{ return _postusername; }
            set{ _postusername = value; }
        }        
		/// <summary>
		/// PostNickname
        /// </summary>
        public string PostNickname
        {
            get{ return _postnickname; }
            set{ _postnickname = value; }
        }        
		/// <summary>
		/// PostUserIp
        /// </summary>
        public string PostUserIp
        {
            get{ return _postuserip; }
            set{ _postuserip = value; }
        }        
		/// <summary>
		/// PostDateTime
        /// </summary>
        public DateTime PostDateTime
        {
            get{ return _postdatetime; }
            set{ _postdatetime = value; }
        }        
		/// <summary>
		/// Title
        /// </summary>
        public string Title
        {
            get{ return _title; }
            set{ _title = value; }
        }        
		/// <summary>
		/// Message
        /// </summary>
        public string Message
        {
            get{ return _message; }
            set{ _message = value; }
        }        
		/// <summary>
		/// HTML
        /// </summary>
        public int HTML
        {
            get{ return _html; }
            set{ _html = value; }
        }        
		/// <summary>
		/// Smile
        /// </summary>
        public int Smile
        {
            get{ return _smile; }
            set{ _smile = value; }
        }        
		/// <summary>
		/// UBB
        /// </summary>
        public int UBB
        {
            get{ return _ubb; }
            set{ _ubb = value; }
        }        
		/// <summary>
		/// Attachment
        /// </summary>
        public int Attachment
        {
            get{ return _attachment; }
            set{ _attachment = value; }
        }        
		/// <summary>
		/// Signature
        /// </summary>
        public int Signature
        {
            get{ return _signature; }
            set{ _signature = value; }
        }        
		/// <summary>
		/// Url
        /// </summary>
        public int Url
        {
            get{ return _url; }
            set{ _url = value; }
        }        
		/// <summary>
		/// Audit
        /// </summary>
        public int Audit
        {
            get{ return _audit; }
            set{ _audit = value; }
        }        
		/// <summary>
		/// First
        /// </summary>
        public int First
        {
            get{ return _first; }
            set{ _first = value; }
        }        
		/// <summary>
		/// Invisible
        /// </summary>
        public int Invisible
        {
            get{ return _invisible; }
            set{ _invisible = value; }
        }        
		/// <summary>
		/// Ban
        /// </summary>
        public int Ban
        {
            get{ return _ban; }
            set{ _ban = value; }
        }        
		/// <summary>
		/// Grade
        /// </summary>
        public int Grade
        {
            get{ return _grade; }
            set{ _grade = value; }
        }        
		/// <summary>
		/// Hide
        /// </summary>
        public int Hide
        {
            get{ return _hide; }
            set{ _hide = value; }
        }        
		/// <summary>
		/// UpdateUserId
        /// </summary>
        public int UpdateUserId
        {
            get{ return _updateuserid; }
            set{ _updateuserid = value; }
        }        
		/// <summary>
		/// UpdateUsername
        /// </summary>
        public string UpdateUsername
        {
            get{ return _updateusername; }
            set{ _updateusername = value; }
        }        
		/// <summary>
		/// UpdateNickname
        /// </summary>
        public string UpdateNickname
        {
            get{ return _updatenickname; }
            set{ _updatenickname = value; }
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
		/// Support
        /// </summary>
        public int Support
        {
            get{ return _support; }
            set{ _support = value; }
        }        
		/// <summary>
		/// Against
        /// </summary>
        public int Against
        {
            get{ return _against; }
            set{ _against = value; }
        }
         

        /// <summary>
        /// QuotePostIds
        /// </summary>
        public string QuotePostIds
        {
            get { return _quotepostids; }
            set { _quotepostids = value; }
        } 

		/// <summary>
		/// QuoteUserId
        /// </summary>
        public int QuoteUserId
        {
            get{ return _quoteuserid; }
            set{ _quoteuserid = value; }
        }        
		/// <summary>
		/// QuoteMessage
        /// </summary>
        public string QuoteMessage
        {
            get{ return _quotemessage; }
            set{ _quotemessage = value; }
        }        
		/// <summary>
		/// QuoteNickname
        /// </summary>
        public string QuoteNickname
        {
            get{ return _quotenickname; }
            set{ _quotenickname = value; }
        }        
				

   
	}
}

		