using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace DTcms.Web.Plugin.Forum.Model{
	 	//dt_Forum_Moderator
			
	public class Forum_Moderator
	{
	
		private int _id = 0;              
		private int _boardid = 0;              
		private int _groupid = 0;              
		private int _userid = 0;              
		private string _username = "";              
		private string _nickname = "";              
				
   		     
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
		/// UserId
        /// </summary>
        public int UserId
        {
            get{ return _userid; }
            set{ _userid = value; }
        }        
		/// <summary>
		/// Username
        /// </summary>
        public string Username
        {
            get{ return _username; }
            set{ _username = value; }
        }        
		/// <summary>
		/// Nickname
        /// </summary>
        public string Nickname
        {
            get{ return _nickname; }
            set{ _nickname = value; }
        }        
				

   
	}
}

		