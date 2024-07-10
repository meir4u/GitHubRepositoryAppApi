using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubRepositoryApp.DL.Entity
{
    public class GithubRepository
    {
        public int id { get; set; }
        public string name { get; set; }
        public Owner owner { get; set; }

    }

    public class Owner
    {
        public string avatar_url { get; set; }
    }
}
