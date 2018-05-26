using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace DTcms.Web.Plugin.Forum.Model{
	 	//dt_Forum_Medal
			
	public class Forum_Medal
	{
	
		private int _id = 0;              
		private string _name = "";              
		private string _image = "";              
		private string _description = "";              
		private string _url = "";              
		private int _available = 0;              
				
   		     
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
		/// Image
        /// </summary>
        public string Image
        {
            get{ return _image; }
            set{ _image = value; }
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
		/// Url
        /// </summary>
        public string Url
        {
            get{ return _url; }
            set{ _url = value; }
        }        
		/// <summary>
		/// Available
        /// </summary>
        public int Available
        {
            get{ return _available; }
            set{ _available = value; }
        }        
				

   
	}
}

		