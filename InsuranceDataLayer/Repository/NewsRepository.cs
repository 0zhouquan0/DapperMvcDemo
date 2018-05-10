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
    public class NewsRepository
    {
        /// <summary>
        /// 异步查询新闻信息
        /// </summary>
        /// <param name="device"></param>
        /// <param name="classify"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<IEnumerable<News>> GetNewsAsync(string device, string classify, int pageIndex, int pageSize)
        {

            string sql = $"SELECT* FROM(SELECT ROW_NUMBER() OVER(ORDER BY IsTop DESC, PublishDate DESC) rowId,* FROM dbo.News WHERE Classify = @Classify and Device = @Device and NewStatus = 1) AS T WHERE t.rowId BETWEEN {pageSize * pageIndex + 1} AND {pageSize + pageSize * pageIndex}";

            using (IDbConnection conn = new SqlConnection(ConfigurationSettings.GetConnectionString()))
            {

                var list = await conn.QueryAsync<News>(sql, new { Classify = classify, Device = device });


                return list;

            }

        }
        /// <summary>
        /// 查询新闻总行数
        /// </summary>
        /// <returns></returns>
        public async Task<int> GetNewsCount(string device, string classify)
        {

            string sql = "SELECT COUNT(1) FROM dbo.News WHERE Classify = @Classify and Device = @Device and NewStatus = 1";
            using (IDbConnection conn = new SqlConnection(ConfigurationSettings.GetConnectionString()))
            {

                var count = await conn.QuerySingleAsync(typeof(Int32), sql, new { Classify = classify, Device = device });

                if (count.Equals(null) || count.Equals(DBNull.Value))
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
        /// 查询新闻详情
        /// </summary>
        /// <param name="classify"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<News> GetNewsInfoAsync(string classify, int Id)
        {

            string sql = "SELECT *  FROM dbo.News WHERE Classify=@Classify AND ID=@ID";
            using (IDbConnection conn = new SqlConnection(ConfigurationSettings.GetConnectionString()))
            {

                var model = await conn.QueryFirstOrDefaultAsync<News>(sql, new { Classify = classify, ID = Id });

                return model;
            }


        }

        /// <summary>
        /// 获取前一条新闻信息
        /// </summary>
        /// <param name="classify"></param>
        /// <param name="device"></param>
        /// <param name="publishDate"></param>
        /// <returns></returns>
        public async Task<News> GetPreNewsInfoAsync(string classify, string device, DateTime publishDate)
        {

            string sql = "SELECT TOP 1 *  FROM dbo.News  WHERE NewStatus=1 AND  Classify=@Classify AND  Device=@Device AND PublishDate<@PublishDate ORDER BY PublishDate  DESC";
            using (IDbConnection conn = new SqlConnection(ConfigurationSettings.GetConnectionString()))
            {

                var model = await conn.QueryFirstOrDefaultAsync<News>(sql, new { Classify = classify, Device = device, PublishDate= publishDate });

                return model;

            }
        }


        /// <summary>
        /// 获取后一条新闻信息
        /// </summary>
        /// <param name="classify"></param>
        /// <param name="device"></param>
        /// <param name="publishDate"></param>
        /// <returns></returns>
        public async Task<News> GetNextNewsInfoAsync(string classify, string device, DateTime publishDate)
        {

            string sql = "SELECT TOP 1 *  FROM dbo.News  WHERE NewStatus=1 AND  Classify=@Classify AND  Device=@Device AND PublishDate>@PublishDate ORDER BY PublishDate ASC";
            using (IDbConnection conn = new SqlConnection(ConfigurationSettings.GetConnectionString()))
            {

                var model = await conn.QueryFirstOrDefaultAsync<News>(sql, new { Classify = classify, Device = device, PublishDate = publishDate });

                return model;

            }
        }

        /// <summary>
        /// 添加浏览记录
        /// </summary>
        /// <param name="newsId"></param>
        /// <param name="date"></param>
        public void NewsVisitAsync(int newsId,string date)
        {

            string sql_exists = "SELECT COUNT(1) FROM  NewsVisitor WHERE NewsID =@NewsID AND Dates=@Dates";
            using (IDbConnection conn = new SqlConnection(ConfigurationSettings.GetConnectionString()))
            {

                var count =  conn.QuerySingle(typeof(Int32),sql_exists, new { NewsID = newsId, Dates = date });
                string sql = string.Empty;
                if ((int)count>0)
                {
                    sql = "update NewsVisitor set clicks=clicks+1 where NewsID=@NewsID and Dates=@Dates";

                    //存在
                     conn.Execute(sql, new { NewsID = newsId, Dates = date });

                }
                else
                {
                    sql = "insert into NewsVisitor(NewsID,Dates,Clicks)values(@NewsID,@Dates,1)";
                    //不存在
                     conn.Execute(sql, new { NewsID = newsId, Dates = date });
                }

            }



        }

    }
}
