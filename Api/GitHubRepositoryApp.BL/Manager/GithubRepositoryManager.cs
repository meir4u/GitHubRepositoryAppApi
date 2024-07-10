using GitHubRepositoryApp.BL.Dto;
using GitHubRepositoryApp.BL.Interface;
using GitHubRepositoryApp.BL.Mapper;
using GitHubRepositoryApp.DL.Entity;
using GitHubRepositoryApp.DL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GitHubRepositoryApp.BL.Manager
{
    public class GithubRepositoryManager : IGithubRepositoryManager
    {
        private GithubRepositoryService _githubRepositoryService;
        private GithubRepositoryMapper _githubRepositoryMapper = new GithubRepositoryMapper();
        public GithubRepositoryManager()
        {
            this._githubRepositoryService = new GithubRepositoryService();
        }

        public async Task<IEnumerable<GithubRepositoryDTO>> SearchRepositories(string search)
        {
            var result = new List<GithubRepositoryDTO>();
            try
            {
                
                var data = await _githubRepositoryService.SearchRepositories(search);
                foreach (var item in data)
                {
                    var mapped = _githubRepositoryMapper.MapToDTO(item);
                    result.Add(mapped);
                }

            }
            catch(Exception ex)
            {

            }

            return result;
        }
    }
}
