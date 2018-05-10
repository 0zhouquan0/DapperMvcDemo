using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using InsuranceDataLayer.Repository;
using InsuranceModels;
using Webdiyer.WebControls.Mvc;

namespace InsuranceWeb.Controllers
{
    
    public class TourismInsuranceController : Controller
    {
        // GET: tourismInsurance
        public async Task<ActionResult> index(int id = 1)
        {

            id= id <= 0 ? 1 : id;

            ProductRepository _repo = new ProductRepository();
            IEnumerable<ProductInfo> list = await _repo.GetGetProductList("", id-1, 4);

            //分页
            int totalCount= await _repo.GetGetProductListCount("");
            PagedList<ProductInfo> pageList = new PagedList<ProductInfo>(list,id,4, totalCount);
            
            ViewBag.Http= ConfigurationManager.AppSettings["WebPath"];
            return View(pageList);
        }

        public async Task<ActionResult> tourism_details(string ProductType="")
        {
            ProductRepository _repo = new ProductRepository();
            ProductInfo model =await _repo.GetProductInfo(ProductType);
            NewsRepository _repoNews = new NewsRepository();
            IEnumerable<News> list =await _repoNews.GetNewsAsync("PC", "GG", 0, 6);
            ViewData["NewsList"] = list;
            ViewData["ProductType"] = ProductType;
            ViewBag.Http = ConfigurationManager.AppSettings["WebPath"];
            return View(model);
        }


        [HttpPost]
        public async Task<ActionResult> SubmitData()
        {

            string codeNo = Request["codeNo"];

            if (TempData["Code"]== null|| TempData["Code"].ToString()!=codeNo)
            {

                return Json(new { state=100,msg="验证码输入错误" }, JsonRequestBehavior.AllowGet);

            }
            Temp_InsuranceBuyerInfo buyerInfo = new Temp_InsuranceBuyerInfo();
            buyerInfo.BuyerName = Request["name"].Trim();
            buyerInfo.Gender = Convert.ToInt32(Request["sex"]);
            buyerInfo.Relation = Request["relation"];
            buyerInfo.CreditNumber = Request["No"].Trim();
            buyerInfo.Mobile = Request["phone"].Trim();
            buyerInfo.Email = Request["email"].Trim();
            buyerInfo.CityName = Request["city"].Trim();
            buyerInfo.ProductCode = Request["productCode"].Trim();
            buyerInfo.SubmitDate = DateTime.Now;
            buyerInfo.UpdateDate = DateTime.Now;
            buyerInfo.State = 0;
            buyerInfo.UpdateUser = "";
            buyerInfo.CarNo = Request["carNo"].Trim();

            InsuranceBuyerInfoRepository _repo = new InsuranceBuyerInfoRepository();
            bool result = await _repo.AddInsuranceBuyer(buyerInfo);
            if (result)
            {
                return Json(new { state = 101, msg = "添加成功" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { state = 102, msg = "添加失败" }, JsonRequestBehavior.AllowGet);
            }

        }
        /// <summary>  
        /// 创建验证码的图片  
        /// </summary>  
        /// <param name="length">验证码的长度</param>  
        /// <returns>验证码图片</returns>  
        public FileResult CreateValidateGraphic(int length)
        {
            string validateCode = EmptyResultDemo(length);
            TempData["Code"] = validateCode;
            Bitmap image = new Bitmap((int)Math.Ceiling(validateCode.Length * 12.0), 22);
            Graphics g = Graphics.FromImage(image);

            //生成随机生成器    
            Random random = new Random();
            //清空图片背景色    
            g.Clear(Color.White);
            //画图片的干扰线    
            for (int i = 0; i < 25; i++)
            {
                int x1 = random.Next(image.Width);
                int x2 = random.Next(image.Width);
                int y1 = random.Next(image.Height);
                int y2 = random.Next(image.Height);
                g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
            }
            Font font = new Font("Arial", 12, (FontStyle.Bold | FontStyle.Italic));
            LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height),
             Color.Blue, Color.DarkRed, 1.2f, true);
            g.DrawString(validateCode, font, brush, 3, 2);
            //画图片的前景干扰点    
            for (int i = 0; i < 100; i++)
            {
                int x = random.Next(image.Width);
                int y = random.Next(image.Height);
                image.SetPixel(x, y, Color.FromArgb(random.Next()));
            }
            //画图片的边框线    
            g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);

            byte[] imageBuffer;
            //保存图片数据    
            using (MemoryStream stream = new MemoryStream())
            {
                //保存的二进制写入到stream对象中  
                image.Save(stream, ImageFormat.Jpeg);

                //ms对象中的二进制数据转换成byte数组  
                imageBuffer = stream.ToArray();
            }
            return File(imageBuffer, "image/jpeg");
        }

        /// <summary>  
        /// 产生验证码的随机数  
        /// </summary>  
        /// <param name="length">验证码的长度</param>  
        /// <returns>验证码</returns>  
        public string EmptyResultDemo(int length)
        {
            int[] randMembers = new int[length];
            int[] validateNums = new int[length];
            string validateNumberStr = "";
            //生成起始序列值    
            int seekSeek = unchecked((int)DateTime.Now.Ticks);
            Random seekRand = new Random(seekSeek);
            int beginSeek = (int)seekRand.Next(0, Int32.MaxValue - length * 10000);
            int[] seeks = new int[length];
            for (int i = 0; i < length; i++)
            {
                beginSeek += 10000;
                seeks[i] = beginSeek;
            }
            //生成随机数字    
            for (int i = 0; i < length; i++)
            {
                Random rand = new Random(seeks[i]);
                int pownum = 1 * (int)Math.Pow(10, length);
                randMembers[i] = rand.Next(pownum, Int32.MaxValue);
            }
            //抽取随机数字    
            for (int i = 0; i < length; i++)
            {
                string numStr = randMembers[i].ToString();
                int numLength = numStr.Length;
                Random rand = new Random();
                int numPosition = rand.Next(0, numLength - 1);
                validateNums[i] = Int32.Parse(numStr.Substring(numPosition, 1));
            }
            //生成验证码    
            for (int i = 0; i < length; i++)
            {
                validateNumberStr += validateNums[i].ToString();
            }
            return validateNumberStr;

        }
    }
}