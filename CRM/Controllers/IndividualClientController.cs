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
    public class IndividualClientController : ApiController
    {
        [HttpPost]
        public async Task<IHttpActionResult> AddIndividualClient([FromBody] IndividualClient individualClient)
        {
            IndClientRepository _repo = new IndClientRepository();
            try
            {
                _repo.AddIndividualClient(individualClient);
                return StatusCode(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteIndividualClient(int id)
        {
            IndClientRepository _repo = new IndClientRepository();
            try
            {
                _repo.DeleteIndividualClient(id);
                return StatusCode(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }
        }

        [HttpGet]
        public HttpResponseMessage ListOfIndividualClient()
        {
            IndClientRepository _repo = new IndClientRepository();
            try
            {
                IEnumerable<IndividualClient> list = _repo.ListOfIndividualClient();
                return Request.CreateResponse(HttpStatusCode.OK, list);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
                //return StatusCode(HttpStatusCode.BadRequest);
            }
        }

     
        [HttpGet]
        public HttpResponseMessage DetailsIndividualClient(int id)
        {
            IndClientRepository _repo = new IndClientRepository();
            try
            {
                IndividualClient client = _repo.DetailsOfIndividualClient(id);
                return Request.CreateResponse(HttpStatusCode.OK, client);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [HttpPut]
        public HttpResponseMessage UpdateIndividualClient([FromBody] ChangeClient changedClient)
        {
            IndClientRepository _repo = new IndClientRepository();
            try
            {
                _repo.UpdateOfIndividualClient(changedClient);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}