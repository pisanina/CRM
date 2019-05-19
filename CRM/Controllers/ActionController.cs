using CRM.Models;
using CRM.Repositories;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Action = CRM.Models.Action;

namespace CRM.Controllers
{
    [RoutePrefix("api/Action")]
    public class ActionController : ApiController
    {
        [Route("")]
        [HttpPost]
        public async Task<IHttpActionResult> AddAction([FromBody] Action newAction)
        {
            ActionRepository _repo = new ActionRepository();
            try
            {
                _repo.AddAction(newAction);
                return StatusCode(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }
        }

        [Route("")]
        [HttpGet]
        public HttpResponseMessage ListOfActions()
        {
            ActionRepository _repo = new ActionRepository();
            try
            {
                IEnumerable<Action> list = _repo.ListOfActions();
                return Request.CreateResponse(HttpStatusCode.OK, list);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
                //return StatusCode(HttpStatusCode.BadRequest);
            }
        }

        [Route("{id:int}")]
        [HttpGet]
        public HttpResponseMessage MessagesForClient(int id)
        {
            IActionRepository _repo = new ActionRepository();
            try
            {
                IEnumerable<Action> messages = _repo.MessagesForClient(id);
                return Request.CreateResponse(HttpStatusCode.OK, messages);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

    }
}
