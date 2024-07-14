﻿using GitHubRepositoryApp.BL.Dto;
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
        public async Task<IEnumerable<GithubRepositoryDTO>> GetAll()
        {
            return await _githubRepositoryManager.GetAllRepositories();
        }

        [HttpGet]
        [Route("{username}")]
        // GET: api/GithubRepository/5
        public async Task<IEnumerable<GithubRepositoryDTO>> GetByUsername([FromUri] string username)
        {
            return await _githubRepositoryManager.GetByUsername(username);
        }

        [HttpGet]
        [Route("search")]
        // GET: api/GithubRepository/search?toSearch=somevalue
        public async Task<IEnumerable<GithubRepositoryDTO>> Search([FromUri] string toSearch)
        {
            //return null;
            var result = await _githubRepositoryManager.SearchRepositories(toSearch);
            return result;
        }

    }
}
