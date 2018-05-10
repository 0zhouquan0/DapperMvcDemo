using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using InsuranceModels;
using System.Data;
using System.Data.SqlClient;


namespace InsuranceDataLayer.Repository
{
   public class ProductRepository
    {
        /// <summary>
        /// 获得主页主推产品
        /// </summary>
        /// <param name="Top"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ProductInfo>> GetRecommendProduct(int Top)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top);
            }
            strSql.Append(" ProductCode,ProductName,ProductFeature,MinPrice,ImgUrlList,ImgUrlApp,ProductDesc ");
            strSql.Append(" FROM ProductInfo ");
            strSql.Append(" where IsValid=1 and IsRecommend=1 ");
            strSql.Append(" order by OrderNum ");

            using (IDbConnection conn=new SqlConnection(ConfigurationSettings.GetConnectionString()))
            {

                var list = await conn.QueryAsync<ProductInfo>(strSql.ToString());

                return list;

            }

        }


        /// <summary>
        /// 分页查询产品
        /// </summary>
        /// <param name="productType"></param>
        /// <param name="start"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ProductInfo>> GetGetProductList(string productType, int pageIndex, int pageSize)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY OrderNum) rowId,ProductCode,ProductName,ProductDesc,ProductFeature,ImgUrlList ,ImgUrlApp,MinPrice  FROM dbo.ProductInfo WHERE IsValid=1 ");
            if (!string.IsNullOrEmpty(productType))
            {
                strSql.Append(" AND ProductType=@ProductType");
            }

            strSql.Append($" ) AS T WHERE  T.rowId   BETWEEN  {pageSize*pageIndex+1} AND {pageSize+ pageSize * pageIndex}");

            using (IDbConnection conn = new SqlConnection(ConfigurationSettings.GetConnectionString()))
            {

                var list = await conn.QueryAsync<ProductInfo>(strSql.ToString(),new { ProductType= productType });

                return list;

            }


        }

        /// <summary>
        /// 查询产品总页数
        /// </summary>
        /// <param name="productType"></param>
        /// <returns></returns>
        public async Task<int> GetGetProductListCount(string productType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM  dbo.ProductInfo WHERE IsValid=1 ");
            if (!string.IsNullOrEmpty(productType))
            {
                strSql.Append(" AND ProductType=@ProductType");
            }
            using (IDbConnection conn = new SqlConnection(ConfigurationSettings.GetConnectionString()))
            {

                var count = await conn.QuerySingleAsync(typeof(Int32), strSql.ToString(), new { ProductType= productType });

                if (count.Equals(null)||count.Equals(DBNull.Value))
                {
                    return 0;
                }
                else
                {
                    return (int)count;
                }

            }



        }


        /// <summary>
        /// 查询产品详情
        /// </summary>
        /// <param name="productCode"></param>
        /// <returns></returns>
        public async Task<ProductInfo> GetProductInfo(string productCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT ProductCode,ProductName,ProductDesc,ProductFeature,SuitableCrowd,SuitableAge,InsuranceTime ");
            strSql.Append(" ,InsuranceMoney,InsuranceProfit,ProductType,ImgUrlDetail,ProductExplain,InsuranceInfo ");
            strSql.Append(" ,InsuranceCase,PaymentService,MinPrice,IsPurchase,ImgUrlApp,ImgUrlCode FROM ProductInfo ");
            strSql.Append(" where ProductCode=@ProductCode ");

            using (IDbConnection conn = new SqlConnection(ConfigurationSettings.GetConnectionString()))
            {

                var model = await conn.QueryFirstOrDefaultAsync<ProductInfo>(strSql.ToString(), new { ProductCode = productCode });

                return model;
            }

        }

    }
}
