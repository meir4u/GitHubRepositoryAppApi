using GitHubRepositoryApp.BL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubRepositoryApp.BL.Interface
{
    public interface IGithubRepositoryManager
    {
        Task<IEnumerable<GithubRepositoryDTO>> SearchRepositories(string search);
        Task<IEnumerable<GithubRepositoryDTO>> GetAllRepositories();
        Task<IEnumerable<GithubRepositoryDTO>> GetByUsername(string username);
    }
}
