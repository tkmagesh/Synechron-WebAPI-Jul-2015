using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Web.Http;

namespace ProductManagementApp.Controllers
{
    public class Product
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public int Units { get; set; }
    }

    public class ProductsController : ApiController
    {
        static IList<Product> products = new List<Product>(new[]
            {
                new Product{Id = 1, Name = "Pen", Cost = 20, Units = 10},
                new Product{Id = 2, Name = "Pencil", Cost = 10, Units = 100} 
            }); 
        // GET api/<controller>
        public IEnumerable<Product> Get()
        {
            return products;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public HttpResponseMessage Post(Product product)
        {
            product.Id = products.Max(p => p.Id) + 1;
            products.Add(product);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            response.StatusCode = HttpStatusCode.Created;
            string uri = Url.Link("DefaultApi", new { id = product.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        // PUT api/<controller>/5
        public void Put(int id, Product product)
        {
            var existingProduct = products.FirstOrDefault(p => p.Id == id);
            existingProduct.Name = product.Name;
            existingProduct.Cost = product.Cost;
            existingProduct.Units = product.Units;
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

        [HttpGet]
        public IEnumerable<Product> Search(string pattern)
        {
            Debug.WriteLine(pattern);
            return products;
        } 
    }
}