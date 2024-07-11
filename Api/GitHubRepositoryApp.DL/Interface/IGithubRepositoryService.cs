using GitHubRepositoryApp.DL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubRepositoryApp.DL.Interface
{
    public interface IGithubRepositoryService
    {
        Task<IEnumerable<GithubRepository>> GetAllRepositories();
        Task<IEnumerable<GithubRepository>> GetByUsername(string username);
        Task<IEnumerable<GithubRepository>> SearchRepositories(string search);
    }
}
