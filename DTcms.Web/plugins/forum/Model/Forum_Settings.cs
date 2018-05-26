using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace DTcms.Web.Plugin.Forum.Model{
	 	//dt_Forum_Settings
			
	public class Forum_Settings
	{

        private string _variable_old = "";
		private string _variable = "";              
		private string _value = "";              
		private string _title = "";              
		private int _group = 0;              
		private string _description = "";              
		private int _sortid = 99;


        /// <summary>
        /// 原字段值，在实际表中不存在
        /// </summary>
        public string VariableOld
        {
            get { return _variable_old; }
            set { _variable_old = value; }
        }   
      	/// <summary>
		/// Variable
        /// </summary>
        public string Variable
        {
            get{ return _variable; }
            set{ _variable = value; }
        }        
		/// <summary>
		/// Value
        /// </summary>
        public string Value
        {
            get{ return _value; }
            set{ _value = value; }
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
		/// Group
        /// </summary>
        public int Group
        {
            get{ return _group; }
            set{ _group = value; }
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
		/// SortId
        /// </summary>
        public int SortId
        {
            get{ return _sortid; }
            set{ _sortid = value; }
        }        
				

   
	}
}

		