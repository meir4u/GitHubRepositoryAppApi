using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubRepositoryApp.DL.Entity.Base
{
    public class ServiceResponseStatus
    {
        public int StatusCode{ get; set; }
        public bool Message { get; set; }
        public bool Success { get; set; }
    }
}
