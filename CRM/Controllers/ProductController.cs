using CRM.Models;
using CRM.Repositories;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Product = CRM.Models.Product;
using ProductCategory = CRM.Models.ProductCategory;

namespace CRM.Controllers
{
    [RoutePrefix("api/Product")]
    public class ProductController : ApiController
    {
        [Route("")]
        [HttpPost]
        public async Task<IHttpActionResult> AddProduct([FromBody] Product newProduct)
        {
            ProductRepository _repo = new ProductRepository();
            try
            {
                _repo.AddProduct(newProduct);
                return StatusCode(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }
        }

        [Route("")]
        [HttpGet]
        public HttpResponseMessage ListOfProducts(string toSearch, int? categoryId)
        {
            ProductRepository _repo = new ProductRepository();
            try
            {
                IEnumerable<Product> list = _repo.ListOfProducts(toSearch, categoryId);
                return Request.CreateResponse(HttpStatusCode.OK, list);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
                //return StatusCode(HttpStatusCode.BadRequest);
            }
        }

        [Route("")]
        [HttpGet]
        public HttpResponseMessage ListOfProducts()
        {
            return ListOfProducts(null, null);
        }

        [Route("Category")]
        [HttpGet]
        public HttpResponseMessage ListOfProductsCategories()
        {
            ProductRepository _repo = new ProductRepository();
            try
            {
                IEnumerable<ProductCategory> list = _repo.ListOfProductsCategories();
                return Request.CreateResponse(HttpStatusCode.OK, list);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
                //return StatusCode(HttpStatusCode.BadRequest);
            }
        }
    }
}
