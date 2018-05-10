using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using InsuranceDataLayer.Repository;
using InsuranceModels;
using Webdiyer.WebControls.Mvc;

namespace InsuranceWeb.Controllers
{
    /******添加扩展方法********/
    public static class StrExtend
    {

        /// <summary>
        /// 获取将富文本编辑框里的img标签中的src添加路径
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string GetReplaceImgSrcContent(this string text)
        {
            text= text == null ? "" : text;

            string http = ConfigurationManager.AppSettings["WebPath"];

            ///////////////////////////////////////////////////////////////////////////////////////////以下是获取HTML代码段中所有<img>标签里的src属性里的路径
            // 定义正则表达式用来匹配 img 标签             
            Regex regImg = new Regex(@"<img\b[^<>]*?\bsrc[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<imgUrl>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>", RegexOptions.IgnoreCase);

            // 搜索匹配的字符串             
            MatchCollection matches = regImg.Matches(text);


            // 取得匹配项列表             
            foreach (Match match in matches)
            {
                if (!match.Groups["imgUrl"].Value.ToLower().Contains(";base64")&&!match.Groups["imgUrl"].Value.ToLower().Contains("http") && !match.Groups["imgUrl"].Value.ToLower().Contains("https"))
                {
                    text = Regex.Replace(text, match.Groups["imgUrl"].Value, http + "/" + match.Groups["imgUrl"].Value);
                }

            }


            return text;


        }


    }


    public class NewsListController : Controller
    {
        // GET: newList
        public async Task<ActionResult> Index(string Type= "GX", int id = 1)
        {
            id = id <= 0 ? 1 : id;
            NewsRepository _repo = new NewsRepository();
            IEnumerable<News> newsList =await _repo.GetNewsAsync("PC", Type, id - 1, 10);

            //分页
            int totalCount =await _repo.GetNewsCount("PC", Type);
            PagedList<News> PageList = new PagedList<News>(newsList,id,10,totalCount);

            ViewBag.Type = Type;
            switch (Type)
            {
                case "GX":
                    ViewBag.TypeName = "公司新闻";
                    break;
                case "HZ":
                    ViewBag.TypeName = "行业资讯";
                    break;
                case "GG":
                    ViewBag.TypeName = "平台公告";
                    break;
                default:
                    ViewBag.TypeName = "";
                    break;
            }

            if (Request.IsAjaxRequest())
            {
                return PartialView("_NewsList", PageList);
            }

            return View(PageList);
        }

        public async Task<ActionResult> news_details(string GX,string HZ,string GG)
        {
            string type = string.Empty;
            int Id = 0;
            if (!string.IsNullOrEmpty(GX))
            {
                type = "GX";
                ViewBag.TypeName = "公司新闻";
                int.TryParse(GX, out Id);
            }
            else if (!string.IsNullOrEmpty(HZ))
            {
                type = "HZ";
                ViewBag.TypeName = "行业资讯";
                int.TryParse(HZ, out Id);
            }
            else if (!string.IsNullOrEmpty(GG))
            {
                type = "GG";
                ViewBag.TypeName = "平台公告";
                int.TryParse(GG, out Id);
            }
            ViewBag.Type = type;
            NewsRepository _repo = new NewsRepository();
            Dictionary<string, News> list = new Dictionary<string, News>();
            News news = await _repo.GetNewsInfoAsync(type, Id);
            if (news!=null)
            {

                list.Add("News", news);
            }
            else
            {
                list.Add("News", new News());
            }
            list.Add("PreNews", new News());
            list.Add("NextNews", new News());
            if (news!=null&&news.PublishDate!=null)
            {

                News news_Pre = await _repo.GetPreNewsInfoAsync(type, "PC", (DateTime)news.PublishDate);
                if (news_Pre!=null)
                {
                    list["PreNews"] = news_Pre;
                }
                News news_Next = await _repo.GetNextNewsInfoAsync(type, "PC", (DateTime)news.PublishDate);
                if (news_Next!=null)
                {
                    list["NextNews"] = news_Next;
                }
                _repo.NewsVisitAsync(news.ID, DateTime.Now.ToString("yyyy-MM-dd"));
            }
     
            return View(list);
        }

    }
}