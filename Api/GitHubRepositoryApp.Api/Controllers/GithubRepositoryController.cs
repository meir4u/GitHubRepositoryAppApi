using GitHubRepositoryApp.BL.Dto;
using GitHubRepositoryApp.BL.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace GitHubRepositoryApp.Api.Controllers
{
    [RoutePrefix("api/GithubRepository")]
    public class GithubRepositoryController : ApiController
    {
        private readonly GithubRepositoryManager _githubRepositoryManager  = new GithubRepositoryManager();
        public GithubRepositoryController()
        {

        }

        [HttpGet]
        [Route("GetAll")]
        // GET: api/GithubRepository
        public IEnumerable<string> GetAll()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        // GET: api/GithubRepository/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet]
        [Route("search")]
        // GET: api/GithubRepository/search?toSearch=somevalue
        public async Task<IEnumerable<GithubRepositoryDTO>> Search([FromUri] string toSearch)
        {
            var result = await _githubRepositoryManager.SearchRepositories(toSearch);
            return result;
        }

        [HttpPost]
        [Route("create")]
        // POST: api/GithubRepository
        public void Create([FromBody]string value)
        {
        }

        [HttpPut]
        [Route("update")]
        // PUT: api/GithubRepository/5
        public void Update(int id, [FromBody]string value)
        {
        }

        // DELETE: api/GithubRepository/5
        public void Delete(int id)
        {
        }
    }
}
