using System;
using System.Collections.Generic;
using System.Text;
using InsuranceModels;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace InsuranceDataLayer.Repository
{
    public class ImgAdvRepository
    {
        /// <summary>
        /// 异步查询数据（广告信息）
        /// </summary>
        /// <param name="imgStatus"></param>
        /// <param name="device"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ImgAdv>> GetImgAdvListByStatusAsync(int? imgStatus, string device)
        {
            string sql = "SELECT * FROM dbo.ImgAdv WHERE ImgStatus=@ImgStatus AND Device=@Device";

            using (IDbConnection conn =new SqlConnection(ConfigurationSettings.GetConnectionString()))
            {

                var list= await conn.QueryAsync<ImgAdv>(sql, new { ImgStatus = imgStatus, Device = device });

                return list;
            }

        }




    }
}
