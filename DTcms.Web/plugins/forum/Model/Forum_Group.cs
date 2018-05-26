using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace DTcms.Web.Plugin.Forum.Model{
	 	//dt_Forum_Group
			
	public class Forum_Group
	{
	
		private int _id = 0;              
		private string _name = "";              
		private int _system = 0;              
		private int _type = 0;              
		private int _creditlower = 0;              
		private int _credithigher = 0;              
		private int _order = 0;              
		private string _color = "";              
		private string _image = "";              
		private string _onlineimage = "";
        private int _isdefault = 0;     
				
   		     
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
		/// System
        /// </summary>
        public int System
        {
            get{ return _system; }
            set{ _system = value; }
        }        
		/// <summary>
		/// Type
        /// </summary>
        public int Type
        {
            get{ return _type; }
            set{ _type = value; }
        }        
		/// <summary>
		/// CreditLower
        /// </summary>
        public int CreditLower
        {
            get{ return _creditlower; }
            set{ _creditlower = value; }
        }        
		/// <summary>
		/// CreditHigher
        /// </summary>
        public int CreditHigher
        {
            get{ return _credithigher; }
            set{ _credithigher = value; }
        }        
		/// <summary>
		/// Order
        /// </summary>
        public int Order
        {
            get{ return _order; }
            set{ _order = value; }
        }        
		/// <summary>
		/// Color
        /// </summary>
        public string Color
        {
            get{ return _color; }
            set{ _color = value; }
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
		/// OnlineImage
        /// </summary>
        public string OnlineImage
        {
            get{ return _onlineimage; }
            set{ _onlineimage = value; }
        }

        /// <summary>
        /// 注册默认项
        /// </summary>
        public int IsDefault
        {
            get { return _isdefault; }
            set { _isdefault = value; }
        }
   
	}
}

		