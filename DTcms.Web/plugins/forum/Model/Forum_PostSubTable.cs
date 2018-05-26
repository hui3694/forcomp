using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace DTcms.Web.Plugin.Forum.Model{
	 	//dt_Forum_PostSubTable
			
	public class Forum_PostSubTable
	{
	
		private int _id = 0;              
		private string _name = "";              
		private string _description = "";              
		private int _topiccount = 0;              
		private int _postcount = 0;              
		private DateTime _createdatetime = System.DateTime.Now;              
		private int _avail = 0;              
		private int _recyclepost = 0;              
		private int _unauditedpost = 0;              
				
   		     
      	/// <summary>
		/// Id
        /// </summary>
        public int Id
        {
            get{ return _id; }
            set{ _id = value; }
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
		/// Description
        /// </summary>
        public string Description
        {
            get{ return _description; }
            set{ _description = value; }
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
		/// CreateDateTime
        /// </summary>
        public DateTime CreateDateTime
        {
            get{ return _createdatetime; }
            set{ _createdatetime = value; }
        }        
		/// <summary>
		/// Avail
        /// </summary>
        public int Avail
        {
            get{ return _avail; }
            set{ _avail = value; }
        }        
		/// <summary>
		/// RecyclePost
        /// </summary>
        public int RecyclePost
        {
            get{ return _recyclepost; }
            set{ _recyclepost = value; }
        }        
		/// <summary>
		/// UnauditedPost
        /// </summary>
        public int UnauditedPost
        {
            get{ return _unauditedpost; }
            set{ _unauditedpost = value; }
        }        
				

   
	}
}

		