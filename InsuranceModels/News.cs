using System;


namespace InsuranceModels
{
    /// <summary>
    /// 新闻表
    /// </summary>
    public  class News
    {
        public News()
        { }
        #region Model
        private int _id;
        private string _title;
        private string _contents;
        private string _classify;
        private DateTime? _createdate = DateTime.Now;
        private string _createuser;
        private DateTime? _auditdate;
        private string _audituser;
        private string _auditresult;
        private DateTime? _publishdate;
        private string _publishuser;
        private string _descriptions;
        private string _keyword;
        private string _defaultimg;
        private int? _clickeds = 0;
        private int? _sort = 0;
        private int? _istop = 0;
        private int? _newstatus = 0;
        private string _device;
        /// <summary>
        /// ID
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
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
        /// 内容
        /// </summary>
        public string Contents
        {
            set { _contents = value; }
            get { return _contents; }
        }
        /// <summary>
        /// 类别
        /// </summary>
        public string Classify
        {
            set { _classify = value; }
            get { return _classify; }
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
        /// 发布时间
        /// </summary>
        public DateTime? PublishDate
        {
            set { _publishdate = value; }
            get { return _publishdate; }
        }
        /// <summary>
        /// 发布人
        /// </summary>
        public string PublishUser
        {
            set { _publishuser = value; }
            get { return _publishuser; }
        }
        /// <summary>
        /// 描述
        /// </summary>
        public string Descriptions
        {
            set { _descriptions = value; }
            get { return _descriptions; }
        }
        /// <summary>
        /// 关键字
        /// </summary>
        public string KeyWord
        {
            set { _keyword = value; }
            get { return _keyword; }
        }
        /// <summary>
        /// 默认图片
        /// </summary>
        public string DefaultImg
        {
            set { _defaultimg = value; }
            get { return _defaultimg; }
        }
        /// <summary>
        /// 点击次数
        /// </summary>
        public int? Clickeds
        {
            set { _clickeds = value; }
            get { return _clickeds; }
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
        /// 顶置
        /// </summary>
        public int? IsTop
        {
            set { _istop = value; }
            get { return _istop; }
        }
        /// <summary>
        /// 状态 
        /// 0:创建
        /// 1:审核通过(发布)
        /// 2:不能发布
        /// </summary>
        public int? NewStatus
        {
            set { _newstatus = value; }
            get { return _newstatus; }
        }

        /// <summary>
        /// 设备 
        /// pc:网站
        /// mobile:移动端APP
        /// </summary>
        public string Device
        {
            set { _device = value; }
            get { return _device; }
        }
        #endregion Model

    }
}
