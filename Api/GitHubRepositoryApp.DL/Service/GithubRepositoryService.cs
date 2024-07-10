using GitHubRepositoryApp.DL.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GitHubRepositoryApp.DL.Service
{
    public class GithubRepositoryService
    {
        private readonly HttpClient _httpClient;
        private string _baseAddress = "https://api.github.com/";

        public GithubRepositoryService()
        {
            try
            {
                this._httpClient = new HttpClient();
                this._httpClient.BaseAddress = new Uri( this._baseAddress);
                this._httpClient.DefaultRequestHeaders.Clear();
                this._httpClient.DefaultRequestHeaders.Add( "Accept", "application/json" );
                _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("request");

            }catch(Exception ex)
            {
                throw new ApplicationException("An error occurred while setting httpClient", ex);
            }
        }

        public async Task<IEnumerable<GithubRepository>> SearchRepositories(string search)
        {
            IEnumerable<GithubRepository> response = null;
            try
            {
                var endpoint = $"search/repositories?q={search}";
                var res = await this._httpClient.GetAsync(endpoint);

                if (res.IsSuccessStatusCode)
                {
                    var result = res.Content.ReadAsStringAsync().Result;
                    var jsonResponse = JsonConvert.DeserializeObject<GithubSearchResult>(result);
                    response = jsonResponse.Items;
                }

            }catch( Exception ex )
            {
                throw new ApplicationException("An error occurred while searching for repositories", ex);
            }

            return response;
        }

    }
}
