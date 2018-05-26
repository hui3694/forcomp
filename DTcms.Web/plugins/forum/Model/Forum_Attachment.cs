using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace DTcms.Web.Plugin.Forum.Model{
	 	//dt_Forum_Attachment
			
	public class Forum_Attachment
	{
	
		private int _id = 0;              
		private int _userid = 0;              
		private int _boardid = 0;              
		private int _topicid = 0;              
		private int _postid = 0;              
		private DateTime _uploaddatetime = System.DateTime.Now;              
		private string _name = "";              
		private string _filename = "";              
		private string _description = "";              
		private string _filetype = "";              
		private int _filesize = 0;              
		private int _isimage = 0;              
		private int _thumb = 0;              
		private int _download = 0;              
		private decimal _cost = 0;              
		private int _costtype = 0;              
				
   		     
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
		/// BoardId
        /// </summary>
        public int BoardId
        {
            get{ return _boardid; }
            set{ _boardid = value; }
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
		/// <summary>
		/// UploadDatetime
        /// </summary>
        public DateTime UploadDatetime
        {
            get{ return _uploaddatetime; }
            set{ _uploaddatetime = value; }
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
		/// FileName
        /// </summary>
        public string FileName
        {
            get{ return _filename; }
            set{ _filename = value; }
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
		/// FileType
        /// </summary>
        public string FileType
        {
            get{ return _filetype; }
            set{ _filetype = value; }
        }        
		/// <summary>
		/// FileSize
        /// </summary>
        public int FileSize
        {
            get{ return _filesize; }
            set{ _filesize = value; }
        }        
		/// <summary>
		/// IsImage
        /// </summary>
        public int IsImage
        {
            get{ return _isimage; }
            set{ _isimage = value; }
        }        
		/// <summary>
		/// Thumb
        /// </summary>
        public int Thumb
        {
            get{ return _thumb; }
            set{ _thumb = value; }
        }        
		/// <summary>
		/// Download
        /// </summary>
        public int Download
        {
            get{ return _download; }
            set{ _download = value; }
        }        
		/// <summary>
		/// Cost
        /// </summary>
        public decimal Cost
        {
            get{ return _cost; }
            set{ _cost = value; }
        }        
		/// <summary>
		/// CostType
        /// </summary>
        public int CostType
        {
            get{ return _costtype; }
            set{ _costtype = value; }
        }        
				

   
	}
}

		