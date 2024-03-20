using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleWebAPI.Models;
namespace SampleWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IList<Product> obj = new List<Product>();
        public ProductController()
        {
            // This list one coming from DB
            obj.Add(new Product() { ProductID = 101, ProductName = "Aluminium Wheel", ProductType = "Wheel", Amount = 589 });

            obj.Add(new Product() { ProductID = 102, ProductName = "Motor Oil leve 5", ProductType = "Oil", Amount = 749 });
            obj.Add(new Product() { ProductID = 103, ProductName = "Brandix Clutch Discs", ProductType = "Clutch", Amount = 345 });
            
        }
        [HttpGet("{productid}")]
        public Product Get(int productid)
        {
            var result = obj.Where(w => w.ProductID == productid).SingleOrDefault();
            return result;
        }
        [HttpGet]
        public List<Product> Get()        {
            
            return obj.ToList();
        }
        [HttpPost]
        public List<Product> Post([FromBody] Product product)
        {
            // here we need to call DAta Access Layer 
            obj.Add(new Product(){ProductID= product.ProductID,ProductName = product.ProductName,ProductType = product.ProductType,Amount=product.Amount});
            return obj.ToList();

        }
        [HttpPut("{productid}")]
        public List<Product> Put(int productid, [FromBody] Product product)
        {
            var p = obj.Where(w => w.ProductID == productid).Single<Product>();
            int i = obj.IndexOf(p);
            obj[i].ProductName = product.ProductName;
            obj[i].ProductType = product.ProductType;
            obj[i].Amount = product.Amount;
            return obj.ToList();
        }
        [HttpDelete("{productid}")]
        public string Delete(int productid)
        {
            var result = obj.Where(w => w.ProductID == productid).SingleOrDefault();
            if (obj.Remove(result))
                return "your data successfully deleted";
            else
                return "Data not deleted";
        }
    }
}
