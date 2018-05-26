using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace DTcms.Web.Plugin.Forum.Model{
	 	//dt_Forum_MyPost
			
	public class Forum_MyPost
	{
	
		private int _id = 0;              
		private int _userid = 0;              
		private int _topicid = 0;              
		private int _postid = 0;              
				
   		     
      	/// <summary>
		/// Id
        /// </summary>
        public int Id
        {
            get{ return _id; }
            set{ _id = value; }
        }        
		/// <summary>
		/// UserId
        /// </summary>
        public int UserId
        {
            get{ return _userid; }
            set{ _userid = value; }
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
		/// PostId
        /// </summary>
        public int PostId
        {
            get{ return _postid; }
            set{ _postid = value; }
        }        
				

   
	}
}

		