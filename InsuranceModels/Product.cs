using System;


namespace InsuranceModels
{
    /// <summary>
    /// 产品信息
    /// </summary>
    public  class ProductInfo
    {
        public ProductInfo()
        { }
        #region Model
        private string _productcode;
        private string _productname;
        private string _productdesc;
        private string _productfeature;
        private string _suitablecrowd;
        private string _suitableage;
        private string _insurancetime;
        private string _insurancemoney;
        private string _insuranceprofit;
        private bool _isrecommend;
        private string _updateuser;
        private DateTime? _updatetime;
        private string _remark;
        private int? _ordernum;
        private string _producttype;
        private string _imgurllist;
        private string _imgurldetail;
        private string _imgurlapp;
        private string _imgurlcode;
        private string _productexplain;
        private string _insuranceinfo;
        private string _insurancecase;
        private string _paymentservice;
        private bool _isvalid;
        private decimal? _minprice;
        private string _productexplainapp;
        private string _insuranceinfoapp;
        private string _insurancecaseapp;
        private string _paymentserviceapp;
        private bool _ispurchase;
        /// <summary>
        /// 产品编号
        /// </summary>
        public string ProductCode
        {
            set { _productcode = value; }
            get { return _productcode; }
        }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName
        {
            set { _productname = value; }
            get { return _productname; }
        }
        /// <summary>
        /// 产品简介
        /// </summary>
        public string ProductDesc
        {
            set { _productdesc = value; }
            get { return _productdesc; }
        }
        /// <summary>
        /// 产品特色
        /// </summary>
        public string ProductFeature
        {
            set { _productfeature = value; }
            get { return _productfeature; }
        }
        /// <summary>
        /// 适合人群
        /// </summary>
        public string SuitableCrowd
        {
            set { _suitablecrowd = value; }
            get { return _suitablecrowd; }
        }
        /// <summary>
        /// 适用年龄
        /// </summary>
        public string SuitableAge
        {
            set { _suitableage = value; }
            get { return _suitableage; }
        }
        /// <summary>
        /// 保险期限
        /// </summary>
        public string InsuranceTime
        {
            set { _insurancetime = value; }
            get { return _insurancetime; }
        }
        /// <summary>
        /// 最高保额
        /// </summary>
        public string InsuranceMoney
        {
            set { _insurancemoney = value; }
            get { return _insurancemoney; }
        }
        /// <summary>
        /// 保险利益
        /// </summary>
        public string InsuranceProfit
        {
            set { _insuranceprofit = value; }
            get { return _insuranceprofit; }
        }
        /// <summary>
        /// 是否推荐
        /// </summary>
        public bool IsRecommend
        {
            set { _isrecommend = value; }
            get { return _isrecommend; }
        }
        /// <summary>
        /// 修改人
        /// </summary>
        public string UpdateUser
        {
            set { _updateuser = value; }
            get { return _updateuser; }
        }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? UpdateTime
        {
            set { _updatetime = value; }
            get { return _updatetime; }
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
        /// 排序号
        /// </summary>
        public int? OrderNum
        {
            set { _ordernum = value; }
            get { return _ordernum; }
        }
        /// <summary>
        /// 类别
        /// </summary>
        public string ProductType
        {
            set { _producttype = value; }
            get { return _producttype; }
        }
        /// <summary>
        /// 列表展示图片
        /// </summary>
        public string ImgUrlList
        {
            set { _imgurllist = value; }
            get { return _imgurllist; }
        }
        /// <summary>
        /// 详情展示图片
        /// </summary>
        public string ImgUrlDetail
        {
            set { _imgurldetail = value; }
            get { return _imgurldetail; }
        }
        /// <summary>
        /// App展示图片
        /// </summary>
        public string ImgUrlApp
        {
            set { _imgurlapp = value; }
            get { return _imgurlapp; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ImgUrlCode
        {
            set { _imgurlcode = value; }
            get { return _imgurlcode; }
        }
        /// <summary>
        /// 产品说明
        /// </summary>
        public string ProductExplain
        {
            set { _productexplain = value; }
            get { return _productexplain; }
        }
        /// <summary>
        /// 投保须知
        /// </summary>
        public string InsuranceInfo
        {
            set { _insuranceinfo = value; }
            get { return _insuranceinfo; }
        }
        /// <summary>
        /// 保险案例
        /// </summary>
        public string InsuranceCase
        {
            set { _insurancecase = value; }
            get { return _insurancecase; }
        }
        /// <summary>
        /// 理赔服务
        /// </summary>
        public string PaymentService
        {
            set { _paymentservice = value; }
            get { return _paymentservice; }
        }
        /// <summary>
        /// 是否有效
        /// </summary>
        public bool IsValid
        {
            set { _isvalid = value; }
            get { return _isvalid; }
        }
        /// <summary>
        /// 最低价格
        /// </summary>
        public decimal? MinPrice
        {
            set { _minprice = value; }
            get { return _minprice; }
        }
        /// <summary>
        /// 产品说明App
        /// </summary>
        public string ProductExplainApp
        {
            set { _productexplainapp = value; }
            get { return _productexplainapp; }
        }
        /// <summary>
        /// 投保须知App
        /// </summary>
        public string InsuranceInfoApp
        {
            set { _insuranceinfoapp = value; }
            get { return _insuranceinfoapp; }
        }
        /// <summary>
        /// 保险案例App
        /// </summary>
        public string InsuranceCaseApp
        {
            set { _insurancecaseapp = value; }
            get { return _insurancecaseapp; }
        }
        /// <summary>
        /// 理赔服务App
        /// </summary>
        public string PaymentServiceApp
        {
            set { _paymentserviceapp = value; }
            get { return _paymentserviceapp; }
        }
        /// <summary>
        /// 是否立即购买
        /// </summary>
        public bool IsPurchase
        {
            set { _ispurchase = value; }
            get { return _ispurchase; }
        }
        #endregion Model

    }
}
