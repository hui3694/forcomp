using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace DTcms.Web.Plugin.Forum.Model{
	 	//dt_Forum_BoardActionPoint
			
	public class Forum_BoardActionPoint
	{
	
		private int _id = 0;              
		private int _enable = 0;              
		private int _boardid = 0;              
		private int _groupid = 0;              
		private int _actionid = 0;              
		private decimal _point = 0;              
				
   		     
      	/// <summary>
		/// Id
        /// </summary>
        public int Id
        {
            get{ return _id; }
            set{ _id = value; }
        }        
		/// <summary>
		/// Enable
        /// </summary>
        public int Enable
        {
            get{ return _enable; }
            set{ _enable = value; }
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
		/// ActionId
        /// </summary>
        public int ActionId
        {
            get{ return _actionid; }
            set{ _actionid = value; }
        }        
		/// <summary>
		/// Point
        /// </summary>
        public decimal Point
        {
            get{ return _point; }
            set{ _point = value; }
        }   
	}
}

		