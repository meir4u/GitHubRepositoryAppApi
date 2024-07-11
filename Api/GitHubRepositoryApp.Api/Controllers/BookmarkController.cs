using GitHubRepositoryApp.BL.Dto;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.SessionState;

namespace GitHubRepositoryApp.Api.Controllers
{
    [RoutePrefix("api/Bookmark")]
    public class BookmarkController : BaseSessionController
    {
        [HttpGet]
        [Route("GetAll/{sessionId}")]
        // GET: api/Bookmark
        public IHttpActionResult Get(string sessionId)
        {
            try
            {
                var session = GetSession(sessionId);

                var repos = _getRepositoriesFromSession(session);

                return Ok(repos);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("add/{sessionId}/{id}")]
        // POST: api/Bookmark
        public IHttpActionResult Add([FromUri] string sessionId, [FromBody] GithubRepositoryDTO value)
        {
            try
            {
                var session = GetSession(sessionId);
                var repos= _getRepositoriesFromSession(session);
                repos.Add(value);
                return Ok();

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("edit/{sessionId}/{id}")]
        // DELETE: api/Bookmark/5
        public IHttpActionResult Delete([FromUri] string sessionId, int id)
        {
            try
            {
                var session = GetSession(sessionId);
                var repos = _getRepositoriesFromSession(session);
                var toDelete = repos.Find(r=>r.Id == id);
                repos.Remove(toDelete);
                return Ok();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        private List<GithubRepositoryDTO> _getRepositoriesFromSession(HttpSessionState session)
        {
            var repos = session["Repositories"] as List<GithubRepositoryDTO>;

            if (repos == null)
            {
                repos = new List<GithubRepositoryDTO>();
                session["Repositories"] = repos;
            }

            return repos;
        }
    }
}
