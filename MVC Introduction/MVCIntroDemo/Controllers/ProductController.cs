using Microsoft.AspNetCore.Mvc;
using MVCIntroDemo.ViewModels.Product;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text;
using static MVCIntroDemo.Seeding.ProductData;
using Microsoft.Net.Http.Headers;
using System.Security.Cryptography;

namespace MVCIntroDemo.Controllers
{
    public class ProductController : Controller
    {
        public object Stringbuilder { get; private set; }

        public IActionResult All(string keyword)
        {
            if (String.IsNullOrWhiteSpace(keyword))
            {
                return View(Products);
            }

            IEnumerable<ProductViewModel> productsAfterSearch = 
                Products
                .Where(p => p.Name
                .ToLower()
                .Contains(keyword.ToLower())).ToArray();
            return View(productsAfterSearch);
        }

        [Route("/Product/Details/{id}")]
        public IActionResult ById(string id)
        {
            ProductViewModel? product = Products.FirstOrDefault(p => p.Id.ToString().Equals(id));
            if (product == null)
            {
                return this.RedirectToAction("All");
            }

            return this.View(product);
        }

        public IActionResult AllAsJson()
        {
            return Json(Products, new JsonSerializerOptions()
            {
                WriteIndented = true
            });
        }

        public IActionResult DownloadProductsInfo()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var product in Products)
            {
                sb.AppendLine($"Product with id: {product.Id}");
                sb.AppendLine($"## Product Name: {product.Name}");
                sb.AppendLine($"## Price: {product.Price:f2}$");
                sb.AppendLine($"-------------------------------");
            }

            Response.Headers.Add(HeaderNames.ContentDisposition, "attachment;filename=products.txt");

            return File(Encoding.UTF8.GetBytes(sb.ToString()), "text/plain");
        }
    }
}
