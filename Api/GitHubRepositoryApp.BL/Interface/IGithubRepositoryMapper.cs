using GitHubRepositoryApp.BL.Dto;
using GitHubRepositoryApp.DL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubRepositoryApp.BL.Interface
{
    internal interface IGithubRepositoryMapper
    {
        GithubRepositoryDTO MapToDTO(GithubRepository entity);
        GithubRepository MapToEntity(GithubRepositoryDTO dto);
    }
}
