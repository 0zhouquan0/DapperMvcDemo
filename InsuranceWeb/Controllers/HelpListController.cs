using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using InsuranceDataLayer.Repository;
using InsuranceModels;
using Webdiyer.WebControls.Mvc;

namespace InsuranceWeb.Controllers
{
    public class HelpListController : Controller
    {
        // GET: helpList
        public async Task<ActionResult> Index(int id = 1)
        {
            id = id <= 0 ? 1 : id;
            NewsRepository _repo = new NewsRepository();
            IEnumerable<News> newsList = await _repo.GetNewsAsync("PC", "WT", id - 1, 10);

            //分页
            int totalCount = await _repo.GetNewsCount("PC", "WT");
            PagedList<News> PageList = new PagedList<News>(newsList, id, 10, totalCount);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_HelpNewsList", PageList);
            }

            return View(PageList);
        }
        public async Task<ActionResult> HelpNewsDetail(int Id=0)
        {
            NewsRepository _repo = new NewsRepository();
            Dictionary<string, News> list = new Dictionary<string, News>();
            News news = await _repo.GetNewsInfoAsync("WT", Id);
            if (news != null)
            {
                list.Add("News", news);
            }
            else
            {
                list.Add("News", new News());
            }
            list.Add("PreNews", new News());
            list.Add("NextNews", new News());
            if (news != null && news.PublishDate != null)
            {

                News news_Pre = await _repo.GetPreNewsInfoAsync("WT", "PC", (DateTime)news.PublishDate);
                if (news_Pre != null)
                {
                    list["PreNews"] = news_Pre;
                }
                News news_Next = await _repo.GetNextNewsInfoAsync("WT", "PC", (DateTime)news.PublishDate);
                if (news_Next != null)
                {
                    list["NextNews"] = news_Next;
                }
                _repo.NewsVisitAsync(news.ID, DateTime.Now.ToString("yyyy-MM-dd"));
            }

            return View(list);

        }
    }
}