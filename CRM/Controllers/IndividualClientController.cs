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
    [RoutePrefix("api/IndividualClient")]
    public class IndividualClientController : ApiController
    {
        [Route("")]
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

        [Route("{id:int}")]
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

        [Route("")]
        [HttpGet]
        public HttpResponseMessage ListOfIndividualClient(string toSearch, int? typeId)
        {
            IndClientRepository _repo = new IndClientRepository();
            try
            {
                IEnumerable<IndividualClient> list = _repo.ListOfIndividualClient(toSearch, typeId);
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
        public HttpResponseMessage ListOfIndividualClient()
        {
           return ListOfIndividualClient(null, null);
        }

        [Route("{id:int}")]
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

        [Route("")]
        [HttpPut]
        public HttpResponseMessage UpdateIndividualClient([FromBody] IndividualClient changedClient)
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

        [Route("Type")]
        [HttpGet]
        public HttpResponseMessage ListOfClientsTypes()
        {
            IndClientRepository _repo = new IndClientRepository();
            try
            {
                IEnumerable<ClientType> list = _repo.ListOfClientTypes();
                return Request.CreateResponse(HttpStatusCode.OK, list);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
                //return StatusCode(HttpStatusCode.BadRequest);
            }
        }

        [Route("Industry")]
        [HttpGet]
        public HttpResponseMessage ListIndustries()
        {
            IndustryRepository _repo = new IndustryRepository();
            try
            {
                IEnumerable<Industry> list = _repo.ListOfIndustries();
                return Request.CreateResponse(HttpStatusCode.OK, list);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
                //return StatusCode(HttpStatusCode.BadRequest);
            }
        }

        [Route("Industry/{id:int}")]
        [HttpGet]
        public HttpResponseMessage IndustryOfClient(int id)
        {
            IndustryRepository _repo = new IndustryRepository();
            try
            {
                IEnumerable<int> list = _repo.IndustriesOfClient(id);
                return Request.CreateResponse(HttpStatusCode.OK, list);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}