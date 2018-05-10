using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceModels
{
    public  class Temp_InsuranceBuyerInfo
    {
        public Temp_InsuranceBuyerInfo()
        {
        }

        #region Model
        private int _insurancebuyerid;
        private string _buyername;
        private int? _gender;
        private string _relation;
        private string _creditnumber;
        private string _mobile;
        private string _email;
        private string _cityname;
        private DateTime? _submitdate;
        private int _state = 0;
        private DateTime? _updatedate;
        private string _updateuser;
        private string _productcode;
        private string _carno;
        /// <summary>
        /// ID
        /// </summary>
        public int InsuranceBuyerID
        {
            set { _insurancebuyerid = value; }
            get { return _insurancebuyerid; }
        }
        /// <summary>
        /// 投保人姓名
        /// </summary>
        public string BuyerName
        {
            set { _buyername = value; }
            get { return _buyername; }
        }
        /// <summary>
        /// 性别
        /// </summary>
        public int? Gender
        {
            set { _gender = value; }
            get { return _gender; }
        }
        /// <summary>
        /// 与被保人关系
        /// </summary>
        public string Relation
        {
            set { _relation = value; }
            get { return _relation; }
        }
        /// <summary>
        /// 身份证号码
        /// </summary>
        public string CreditNumber
        {
            set { _creditnumber = value; }
            get { return _creditnumber; }
        }
        /// <summary>
        /// 手机
        /// </summary>
        public string Mobile
        {
            set { _mobile = value; }
            get { return _mobile; }
        }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 所在城市
        /// </summary>
        public string CityName
        {
            set { _cityname = value; }
            get { return _cityname; }
        }
        /// <summary>
        /// 提交时间
        /// </summary>
        public DateTime? SubmitDate
        {
            set { _submitdate = value; }
            get { return _submitdate; }
        }
        /// <summary>
        /// 状态
        /// </summary>
        public int State
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime? UpdateDate
        {
            set { _updatedate = value; }
            get { return _updatedate; }
        }
        /// <summary>
        /// 最后修改人
        /// </summary>
        public string UpdateUser
        {
            set { _updateuser = value; }
            get { return _updateuser; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProductCode
        {
            set { _productcode = value; }
            get { return _productcode; }
        }
        /// <summary>
        /// 车牌号
        /// </summary>
        public string CarNo
        {
            set { _carno = value; }
            get { return _carno; }
        }
        #endregion Model
    }
}
