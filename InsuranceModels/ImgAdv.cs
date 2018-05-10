using System;


namespace InsuranceModels
{
    /// <summary>
    /// Banner图片 实体类
    /// </summary>
    public class ImgAdv
    {
        public ImgAdv()
        { }
        #region Model
        private int _id;
        private string _imgurl;
        private string _url = "#";
        private int? _sort;
        private string _title;
        private string _remark;
        private int _isactive = 1;
        private DateTime? _createdate = DateTime.Now;
        private string _createuser;
        private DateTime? _auditdate;
        private string _audituser;
        private string _auditresult;
        private int _istop = 0;
        private int _imgstatus = 0;
        private string _device;
        /// <summary>
        /// id
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 图片路径
        /// </summary>
        public string ImgUrl
        {
            set { _imgurl = value; }
            get { return _imgurl; }
        }
        /// <summary>
        /// 链接地址
        /// </summary>
        public string Url
        {
            set { _url = value; }
            get { return _url; }
        }
        /// <summary>
        /// 排序
        /// </summary>
        public int? Sort
        {
            set { _sort = value; }
            get { return _sort; }
        }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 选中状态
        /// </summary>
        public int IsActive
        {
            set { _isactive = value; }
            get { return _isactive; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateUser
        {
            set { _createuser = value; }
            get { return _createuser; }
        }
        /// <summary>
        /// 审核时间
        /// </summary>
        public DateTime? AuditDate
        {
            set { _auditdate = value; }
            get { return _auditdate; }
        }
        /// <summary>
        /// 审核人
        /// </summary>
        public string AuditUser
        {
            set { _audituser = value; }
            get { return _audituser; }
        }
        /// <summary>
        /// 审核结果
        /// </summary>
        public string AuditResult
        {
            set { _auditresult = value; }
            get { return _auditresult; }
        }
        /// <summary>
        /// 置顶
        /// </summary>
        public int IsTop
        {
            set { _istop = value; }
            get { return _istop; }
        }
        /// <summary>
        /// 状态(0：未审核，1：审核发布，2：无效)
        /// </summary>
        public int ImgStatus
        {
            set { _imgstatus = value; }
            get { return _imgstatus; }
        }
        /// <summary>
        /// 终端 
        /// </summary>
        public string Device
        {
            get
            {
                return _device;
            }

            set
            {
                _device = value;
            }
        }
        #endregion Model

    }
}
