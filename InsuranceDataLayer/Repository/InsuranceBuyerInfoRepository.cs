using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuranceModels;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace InsuranceDataLayer.Repository
{
   public class InsuranceBuyerInfoRepository
    {
        /// <summary>
        /// 添加用户购买信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> AddInsuranceBuyer(Temp_InsuranceBuyerInfo model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Temp_InsuranceBuyerInfo(");
            strSql.Append("BuyerName,Gender,Relation,CreditNumber,Mobile,Email,CityName,SubmitDate,State,UpdateDate,UpdateUser,ProductCode,CarNo)");
            strSql.Append(" values (");
            strSql.Append("@BuyerName,@Gender,@Relation,@CreditNumber,@Mobile,@Email,@CityName,@SubmitDate,@State,@UpdateDate,@UpdateUser,@ProductCode,@CarNo)");

            using (IDbConnection conn = new SqlConnection(ConfigurationSettings.GetConnectionString()))
            {

                var count = await conn.ExecuteAsync(strSql.ToString(), new { BuyerName = model.BuyerName, Gender = model.Gender, Relation=model.Relation, CreditNumber=model.CreditNumber, Mobile=model.Mobile, Email=model.Email, CityName=model.CityName, SubmitDate=model.SubmitDate, State=model.State, UpdateDate=model.UpdateDate, UpdateUser=model.UpdateUser, ProductCode=model.ProductCode, CarNo=model.CarNo });

                return count>0;
            }






        }



    }



}
