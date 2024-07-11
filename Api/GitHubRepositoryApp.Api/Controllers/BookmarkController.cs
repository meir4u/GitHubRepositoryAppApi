using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GitHubRepositoryApp.Api.Controllers
{
    [RoutePrefix("api/Bookmark")]
    public class BookmarkController : BaseSessionController
    {
        [HttpGet]
        [Route("GetAll/{sessionId}")]
        // GET: api/Bookmark
        public IEnumerable<string> Get(string sessionId)
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        [Route("{sessionId}/{id}")]
        // GET: api/Bookmark/5
        public string Get([FromUri] string sessionId, int id)
        {
            return "value";
        }

        [HttpPost]
        [Route("add/{sessionId}/{id}")]
        // POST: api/Bookmark
        public void Add([FromUri] string sessionId, [FromBody]string value)
        {
        }

        [HttpPut]
        [Route("edit/{sessionId}/{id}")]
        // PUT: api/Bookmark/5
        public void Edit([FromUri] string sessionId, int id, [FromBody]string value)
        {
        }

        [HttpDelete]
        [Route("edit/{sessionId}/{id}")]
        // DELETE: api/Bookmark/5
        public void Delete([FromUri] string sessionId, int id)
        {
        }
    }
}
