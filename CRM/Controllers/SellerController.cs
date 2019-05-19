using CRM.Models;
using CRM.Repositories;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;


namespace CRM.Controllers
{
    [RoutePrefix("api/Seller")]
    public class SellerController : ApiController
    {
        [Route("")]
        [HttpGet]
        public HttpResponseMessage ListOfSellers()
        {
            SellerRepository _repo = new SellerRepository();
            try
            {
                IEnumerable<Seller> list = _repo.ListOfSellers();
                return Request.CreateResponse(HttpStatusCode.OK, list);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
                //return StatusCode(HttpStatusCode.BadRequest);
            }
        }

        [Route("")]
        [HttpPost]
        public async Task<IHttpActionResult> AddSeller([FromBody] Seller newSeller)
        {
            SellerRepository _repo = new SellerRepository();
            try
            {
                _repo.AddSeller(newSeller);
                return StatusCode(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }
        }

    }
}
