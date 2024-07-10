using GitHubRepositoryApp.BL.Dto;
using GitHubRepositoryApp.BL.Interface;
using GitHubRepositoryApp.DL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubRepositoryApp.BL.Mapper
{
    internal class GithubRepositoryMapper : IGithubRepositoryMapper
    {
        public GithubRepositoryDTO MapToDTO(GithubRepository entity)
        {
            var dto = new GithubRepositoryDTO()
            {
                Id = entity.id,
                Name = entity.name,
                Owner = new Dto.Owner()
                {
                    AvatarUrl = entity.owner.avatar_url,
                }
            };

            return dto;
        }

        public GithubRepository MapToEntity(GithubRepositoryDTO dto)
        {
            var entity = new GithubRepository()
            {
                id = dto.Id,
                name = dto.Name,
                owner = new DL.Entity.Owner()
                {
                    avatar_url = dto.Owner.AvatarUrl,
                }
            };
            return entity;
        }
    }
}
