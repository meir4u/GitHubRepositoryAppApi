using GitHubRepositoryApp.BL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace GitHubRepositoryApp.Api.Controllers
{
    [RoutePrefix("api/Bookmark")]
    public class BookmarkController : BaseSessionController
    {
        [HttpGet]
        [Route("GetAll/{sessionId}")]
        // GET: api/Bookmark
        public IEnumerable<GithubRepositoryDTO> Get(string sessionId)
        {
            var session = GetSession(sessionId);
            var repos = session["Repositories"] as List<GithubRepositoryDTO>;

            return repos;
        }

        [HttpPost]
        [Route("add/{sessionId}/{id}")]
        // POST: api/Bookmark
        public void Add([FromUri] string sessionId, [FromBody]string value)
        {
            var session = GetSession(sessionId);
        }

        [HttpDelete]
        [Route("edit/{sessionId}/{id}")]
        // DELETE: api/Bookmark/5
        public void Delete([FromUri] string sessionId, int id)
        {
            var session = GetSession(sessionId);
        }
    }
}
