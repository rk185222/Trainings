using ContosoCrafts.WebSite.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ContosoCrafts.WebSite.Services
{
    public class JsonFileProductService
    {
        public JsonFileProductService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }
    
        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName => Path.Combine(WebHostEnvironment.WebRootPath, "data", "products.json");

        public IEnumerable<Product> GetProducts()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<Product[]>(jsonFileReader.ReadToEnd(),
                        new JsonSerializerOptions()
                        {
                            PropertyNameCaseInsensitive = true
                        });
            }
        }

        public void AddRating(string productId, int rating)
        {
            var products = GetProducts();
            var product = products.FirstOrDefault(z => z.Id == productId);
            if (product.Ratings != null)
            {
                var curRatings = product.Ratings.ToList();
                curRatings.Add(rating);
                product.Ratings = curRatings.ToArray();
            }
            else
            {
                product.Ratings = new int[] { rating };
            }

            using (var outputstream = File.OpenWrite(JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<Product>>(
                    new Utf8JsonWriter(outputstream, new JsonWriterOptions()
                    {
                        SkipValidation = true,
                        Indented = true
                    }), products);
            }
        }
    }
}
