﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GitHubRepositoryApp.Api.Controllers
{
    public class EmailController : ApiController
    {
        // GET: api/Email
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Email/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        [Route("SendEmail")]
        // POST: api/Email
        public void SendEmail([FromBody]string value)
        {
        }

    }
}
