using GitHubRepositoryApp.BL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubRepositoryApp.BL.Interface
{
    public interface IEmailManager
    {
        void SendEmail(EmailGithubRepositoryDTO email);
    }
}
