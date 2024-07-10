using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubRepositoryApp.BL.Dto
{
    public class GithubRepositoryDTO
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("owner")]
        public Owner Owner { get; set; }
        
    }

    public class Owner
    {
        [JsonProperty("avatarUrl")]
        public string AvatarUrl { get; set; }
    }
}
