using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace DTcms.Web.Plugin.Forum.Model{
	 	//dt_Forum_Word
			
	public class Forum_Word
	{
	
		private int _id = 0;              
		private string _findword = "";              
		private string _replaceword = "";              
				
   		     
      	/// <summary>
		/// Id
        /// </summary>
        public int Id
        {
            get{ return _id; }
            set{ _id = value; }
        }        
		/// <summary>
		/// FindWord
        /// </summary>
        public string FindWord
        {
            get{ return _findword; }
            set{ _findword = value; }
        }        
		/// <summary>
		/// ReplaceWord
        /// </summary>
        public string ReplaceWord
        {
            get{ return _replaceword; }
            set{ _replaceword = value; }
        }        
				

   
	}
}

		