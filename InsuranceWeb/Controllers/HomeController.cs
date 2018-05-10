using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using InsuranceModels;
using InsuranceDataLayer.Repository;
using System.Threading.Tasks;
using System.Configuration;

namespace InsuranceWeb.Controllers
{
    public class HomeController : Controller
    {

        public async Task<ActionResult> Index()
        {

            ImgAdvRepository _repoImageAdv = new ImgAdvRepository();
            IEnumerable<InsuranceModels.ImgAdv> listImgAdv = await _repoImageAdv.GetImgAdvListByStatusAsync(1, "PC");
            NewsRepository _repoNews = new NewsRepository();
            Dictionary<string, IEnumerable<InsuranceModels.News>> dicNews = new Dictionary<string, IEnumerable<News>>();
            IEnumerable<InsuranceModels.News> listNews_GX = await _repoNews.GetNewsAsync("PC", "GX", 0, 3);
            IEnumerable<InsuranceModels.News> listNews_HZ = await _repoNews.GetNewsAsync("PC", "HZ", 0, 3);
            IEnumerable<InsuranceModels.News> listNews_GG = await _repoNews.GetNewsAsync("PC", "GG", 0, 3);
            dicNews.Add("GX", listNews_GX);
            dicNews.Add("HZ", listNews_HZ);
            dicNews.Add("GG", listNews_GG);
            ProductRepository _repoProduct = new ProductRepository();
            IEnumerable<InsuranceModels.ProductInfo> listProduct = await _repoProduct.GetRecommendProduct(4);

            ViewBag.Http = ConfigurationManager.AppSettings["WebPath"];
            ViewData["listImgAdv"] = listImgAdv;
            ViewData["listNews"] = dicNews;
            ViewData["listProduct"] = listProduct;
            return View();
        }
    }
}