using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace DTcms.Web.Plugin.Forum.Model{
	 	//dt_Forum_GroupExtended
			
	public class Forum_GroupExtended
	{
	
		private int _groupid = 0;              
		private int _viewipfield = 0;              
		private string _attachmentextension = "";              
		private int _dayattachmentsize = 0;              
		private int _postintervalsecond = 0;              
		private int _search = 0;              
		private int _memberlist = 0;              
		private int _postcheck = 0;
        private int _cost = 0;              
		private decimal _costmax = 0;              
		private int _postupdatelog = 0;              
				
   		     
      	/// <summary>
		/// GroupId
        /// </summary>
        public int GroupId
        {
            get{ return _groupid; }
            set{ _groupid = value; }
        }        
		/// <summary>
		/// ViewIpField
        /// </summary>
        public int ViewIpField
        {
            get{ return _viewipfield; }
            set{ _viewipfield = value; }
        }        
		/// <summary>
		/// AttachmentExtension
        /// </summary>
        public string AttachmentExtension
        {
            get{ return _attachmentextension; }
            set{ _attachmentextension = value; }
        }        
		/// <summary>
		/// DayAttachmentSize
        /// </summary>
        public int DayAttachmentSize
        {
            get{ return _dayattachmentsize; }
            set{ _dayattachmentsize = value; }
        }        
		/// <summary>
		/// PostIntervalSecond
        /// </summary>
        public int PostIntervalSecond
        {
            get{ return _postintervalsecond; }
            set{ _postintervalsecond = value; }
        }        
		/// <summary>
		/// Search
        /// </summary>
        public int Search
        {
            get{ return _search; }
            set{ _search = value; }
        }        
		/// <summary>
		/// MemberList
        /// </summary>
        public int MemberList
        {
            get{ return _memberlist; }
            set{ _memberlist = value; }
        }        
		/// <summary>
		/// PostCheck
        /// </summary>
        public int PostCheck
        {
            get{ return _postcheck; }
            set{ _postcheck = value; }
        }        
		/// <summary>
		/// Cost
        /// </summary>
        public int Cost
        {
            get{ return _cost; }
            set{ _cost = value; }
        }        
		/// <summary>
		/// CostMax
        /// </summary>
        public decimal CostMax
        {
            get{ return _costmax; }
            set{ _costmax = value; }
        }        
		/// <summary>
		/// PostUpdateLog
        /// </summary>
        public int PostUpdateLog
        {
            get{ return _postupdatelog; }
            set{ _postupdatelog = value; }
        }        
				

   
	}
}

		