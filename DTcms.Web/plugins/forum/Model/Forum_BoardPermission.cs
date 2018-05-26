using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace DTcms.Web.Plugin.Forum.Model{
	 	//dt_Forum_BoardPermission
			
	public class Forum_BoardPermission
	{
	
		private int _id = 1;              
		private int _boardid = 1;              
		private int _groupid = 1;              
		private int _visitboard = 1;              
		private int _visittopic = 1;              
		private int _posttopic = 1;              
		private int _postreply = 1;              
		private int _uploadattachment = 1;              
		private int _viewattachment = 1;              
		private int _updatemyselftopic = 1;              
		private int _updatemyselfreply = 1;              
		private int _deletemyselftopic = 1;              
		private int _deletemyselfreply = 1;              
		private int _postbantopic = 1;              
		private int _viewbantopic = 1;              
		private int _ratetopic = 1;              
		private int _ratereply = 1;              
				
   		     
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
		/// GroupId
        /// </summary>
        public int GroupId
        {
            get{ return _groupid; }
            set{ _groupid = value; }
        }        
		/// <summary>
		/// VisitBoard
        /// </summary>
        public int VisitBoard
        {
            get{ return _visitboard; }
            set{ _visitboard = value; }
        }        
		/// <summary>
		/// VisitTopic
        /// </summary>
        public int VisitTopic
        {
            get{ return _visittopic; }
            set{ _visittopic = value; }
        }        
		/// <summary>
		/// PostTopic
        /// </summary>
        public int PostTopic
        {
            get{ return _posttopic; }
            set{ _posttopic = value; }
        }        
		/// <summary>
		/// PostReply
        /// </summary>
        public int PostReply
        {
            get{ return _postreply; }
            set{ _postreply = value; }
        }        
		/// <summary>
		/// UploadAttachment
        /// </summary>
        public int UploadAttachment
        {
            get{ return _uploadattachment; }
            set{ _uploadattachment = value; }
        }        
		/// <summary>
		/// ViewAttachment
        /// </summary>
        public int ViewAttachment
        {
            get{ return _viewattachment; }
            set{ _viewattachment = value; }
        }        
		/// <summary>
		/// UpdateMyselfTopic
        /// </summary>
        public int UpdateMyselfTopic
        {
            get{ return _updatemyselftopic; }
            set{ _updatemyselftopic = value; }
        }        
		/// <summary>
		/// UpdateMyselfReply
        /// </summary>
        public int UpdateMyselfReply
        {
            get{ return _updatemyselfreply; }
            set{ _updatemyselfreply = value; }
        }        
		/// <summary>
		/// DeleteMyselfTopic
        /// </summary>
        public int DeleteMyselfTopic
        {
            get{ return _deletemyselftopic; }
            set{ _deletemyselftopic = value; }
        }        
		/// <summary>
		/// DeleteMyselfReply
        /// </summary>
        public int DeleteMyselfReply
        {
            get{ return _deletemyselfreply; }
            set{ _deletemyselfreply = value; }
        }        
		/// <summary>
		/// PostBanTopic
        /// </summary>
        public int PostBanTopic
        {
            get{ return _postbantopic; }
            set{ _postbantopic = value; }
        }        
		/// <summary>
		/// ViewBanTopic
        /// </summary>
        public int ViewBanTopic
        {
            get{ return _viewbantopic; }
            set{ _viewbantopic = value; }
        }        
		/// <summary>
		/// RateTopic
        /// </summary>
        public int RateTopic
        {
            get{ return _ratetopic; }
            set{ _ratetopic = value; }
        }        
		/// <summary>
		/// RateReply
        /// </summary>
        public int RateReply
        {
            get{ return _ratereply; }
            set{ _ratereply = value; }
        }        
				

   
	}
}

		