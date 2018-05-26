using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace DTcms.Web.Plugin.Forum.Model
{
    //dt_Forum_UserExtended

    public class Forum_UserExtended
    {

        private int _userid = 0;
        private string _qq = "";
        private string _msn = "";
        private int _gender = 0;
        private string _birthday = "";
        private string _bio = "";
        private string _address = "";
        private string _site = "";
        private string _signature = "";
        private string _nickname = "";
        private string _username = "";//实际数据库中不存在     
        private DateTime _lastpostdatetime = System.DateTime.Now;
        private int _groupid = 0;
        private DateTime _lastactivity = System.DateTime.Now;
        private int _topiccount = 0;
        private int _postcount = 0;
        private int _postdigestcount = 0;
        private string _medal = "";
        private int _onlinetime = 0;
        private DateTime _onlineupdatetime = System.DateTime.Now;
        private int _verify = 0;
        private string _hometown = "";
        private string _nonlocal = "";
        private string _specialty = "";
        private decimal _credit = 0;
        private decimal _credittotal = 0;
        
        private string _groupname = "";
        private string _photo = "";


        /// <summary>
        /// UserId
        /// </summary>
        public int UserId
        {
            get { return _userid; }
            set { _userid = value; }
        }
        /// <summary>
        /// QQ
        /// </summary>
        public string QQ
        {
            get { return _qq; }
            set { _qq = value; }
        }
        /// <summary>
        /// MSN
        /// </summary>
        public string MSN
        {
            get { return _msn; }
            set { _msn = value; }
        }
        /// <summary>
        /// Gender
        /// </summary>
        public int Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }
        /// <summary>
        /// Birthday
        /// </summary>
        public string Birthday
        {
            get { return _birthday; }
            set { _birthday = value; }
        }
        /// <summary>
        /// Bio
        /// </summary>
        public string Bio
        {
            get { return _bio; }
            set { _bio = value; }
        }
        /// <summary>
        /// Address
        /// </summary>
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        /// <summary>
        /// Site
        /// </summary>
        public string Site
        {
            get { return _site; }
            set { _site = value; }
        }
        /// <summary>
        /// Signature
        /// </summary>
        public string Signature
        {
            get { return _signature; }
            set { _signature = value; }
        }
        /// <summary>
        /// Nickname
        /// </summary>
        public string Nickname
        {
            get { return _nickname; }
            set { _nickname = value; }
        }

        /// <summary>
        /// 用户名 实际的数据库不存在，来源于DTcms 原表付值
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }

        /// <summary>
        /// photo
        /// </summary>
        public string Photo
        {
            get { return _photo; }
            set { _photo = value; }
        }


        /// <summary>
        /// LastPostDateTime
        /// </summary>
        public DateTime LastPostDateTime
        {
            get { return _lastpostdatetime; }
            set { _lastpostdatetime = value; }
        }
        /// <summary>
        /// GroupId
        /// </summary>
        public int GroupId
        {
            get { return _groupid; }
            set { _groupid = value; }
        }

        /// <summary>
        /// GroupName
        /// </summary>
        public string GroupName
        {
            get { return _groupname; }
            set { _groupname = value; }
        }


        /// <summary>
        /// LastActivity
        /// </summary>
        public DateTime LastActivity
        {
            get { return _lastactivity; }
            set { _lastactivity = value; }
        }
        /// <summary>
        /// TopicCount
        /// </summary>
        public int TopicCount
        {
            get { return _topiccount; }
            set { _topiccount = value; }
        }
        /// <summary>
        /// PostCount
        /// </summary>
        public int PostCount
        {
            get { return _postcount; }
            set { _postcount = value; }
        }
        /// <summary>
        /// PostDigestCount
        /// </summary>
        public int PostDigestCount
        {
            get { return _postdigestcount; }
            set { _postdigestcount = value; }
        }
        /// <summary>
        /// Medal
        /// </summary>
        public string Medal
        {
            get { return _medal; }
            set { _medal = value; }
        }
        /// <summary>
        /// OnlineTime
        /// </summary>
        public int OnlineTime
        {
            get { return _onlinetime; }
            set { _onlinetime = value; }
        }
        /// <summary>
        /// OnlineUpdateTime
        /// </summary>
        public DateTime OnlineUpdateTime
        {
            get { return _onlineupdatetime; }
            set { _onlineupdatetime = value; }
        }
        /// <summary>
        /// Verify
        /// </summary>
        public int Verify
        {
            get { return _verify; }
            set { _verify = value; }
        }
        /// <summary>
        /// Hometown
        /// </summary>
        public string Hometown
        {
            get { return _hometown; }
            set { _hometown = value; }
        }
        /// <summary>
        /// Nonlocal
        /// </summary>
        public string Nonlocal
        {
            get { return _nonlocal; }
            set { _nonlocal = value; }
        }
        /// <summary>
        /// Specialty
        /// </summary>
        public string Specialty
        {
            get { return _specialty; }
            set { _specialty = value; }
        }
        /// <summary>
        /// Credit 当前积分，兑换后会相应的减少
        /// </summary>
        public decimal Credit
        {
            get { return _credit; }
            set { _credit = value; }
        }


        /// <summary>
        /// CreditTotal 积分总计，不会随着，兑换而减少
        /// </summary>
        public decimal CreditTotal
        {
            get { return _credittotal; }
            set { _credittotal = value; }
        }

        

    }
}

