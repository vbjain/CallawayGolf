using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Demo.CoreWeb.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Demo.Common;
using System.IO;
using System.Linq;

namespace Demo.CoreWeb.Controllers
{
    public class HomeController : Controller
    {
        private string GoogleImageSearchUrl
        {
            get
            {
                return "https://www.googleapis.com/customsearch/v1?q={0}&searchType=image&fileType=png&key=AIzaSyA30aiGp300gu4cLJhlH77LR0yueNhmHrA&cx=002692538317433306665:ytlo9nbpavy";
            }
        }

        private void PopulateImageUrls(List<Category> categories)
        {
            Parallel.ForEach(categories, c =>
            {
                try
                {
                    var url = string.Format(GoogleImageSearchUrl, c.Name);
                    var restClient = new RestSharp.RestClient(url);
                    var restRequest = new RestSharp.RestRequest(RestSharp.Method.GET);
                    var result = restClient.ExecuteAsGet<GoogleResult>(restRequest, "GET");
                    if (result != null &&
                            result.Data != null &&
                            result.Data.Items != null &&
                            result.Data.Items.Count > 0)
                    {
                        c.ImageUrl = result.Data.Items[0].Link;
                    }
                }
                catch
                {

                }
            });
        }

        public IActionResult Index()
        {
            var rootModel = new RootModel();
            rootModel.Categories = new List<Category>();
            return View(rootModel);
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return Content("file not selected");

            var rootModel = new RootModel();
            var streamReader = new StreamReader(file.OpenReadStream());
            var fileData = await streamReader.ReadToEndAsync();

            rootModel.Categories = JsonConvert.DeserializeObject<List<Category>>(fileData);

            rootModel.Categories = rootModel.Categories.OrderBy(c => c.SortOrder).ToList();
            Parallel.ForEach(rootModel.Categories, c =>
            {
                c.Models = c.Models.OrderBy(m => m.SortOrder).ToList();
                Parallel.ForEach(c.Models, m =>
                {
                    m.Products = m.Products.OrderBy(p => p.Hand).ThenBy(p => p.Gender).ThenBy(p => p.SortOrder).ThenBy(p => p.Description).ToList();
                });
            });

            PopulateImageUrls(rootModel.Categories);
            return View("Index", rootModel);
        }

        [HttpPost]
        public async Task<IActionResult> UploadFileInventory(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return Content("file not selected");

            var rootModel = new RootModel();
            var streamReader = new StreamReader(file.OpenReadStream());
            var fileData = await streamReader.ReadToEndAsync();

            rootModel.Categories = JsonConvert.DeserializeObject<List<Category>>(fileData);
            rootModel.Categories = rootModel.Categories.OrderBy(c => c.SortOrder).ToList();
            Parallel.ForEach(rootModel.Categories, c =>
            {
                c.Models = c.Models.OrderBy(m => m.SortOrder).ToList();
                Parallel.ForEach(c.Models, m =>
                {
                    m.Products = m.Products.OrderBy(p => p.Hand).ThenBy(p => p.Gender).ThenBy(p => p.SortOrder).ThenBy(p => p.Description).ToList();
                });
            });

            PopulateImageUrls(rootModel.Categories);

            Parallel.ForEach(rootModel.Categories, c =>
            {
                Parallel.ForEach(c.Models, m =>
                {
                    Demo.ExtraService.InventoryAssignService.Instance.RandomAssignInventory(m.Products);
                });
            });

            return View("Index", rootModel);
        }
    }
}
