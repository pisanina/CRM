using CRM.Models;
using CRM.Repositories;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;


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
    }
}