﻿using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace DTcms.Web.Plugin.Forum.Model{
	 	//dt_Forum_PostId
			
	public class Forum_PostId
	{
	
		private int _id = 0;              
		private int _topicid = 0;              
				
   		     
      	/// <summary>
		/// Id
        /// </summary>
        public int Id
        {
            get{ return _id; }
            set{ _id = value; }
        }        
		/// <summary>
		/// TopicId
        /// </summary>
        public int TopicId
        {
            get{ return _topicid; }
            set{ _topicid = value; }
        }        
				

   
	}
}

		