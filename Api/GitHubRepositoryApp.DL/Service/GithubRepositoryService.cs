using GitHubRepositoryApp.DL.Entity;
using GitHubRepositoryApp.DL.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GitHubRepositoryApp.DL.Service
{
    public class GithubRepositoryService : IGithubRepositoryService
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
            IEnumerable<GithubRepository> response = new List<GithubRepository>();
            try
            {
                var endpoint = $"search/repositories?q={search}";

                var res = await this._httpClient.GetAsync(endpoint);

                var result = await _getRepositories(endpoint);

                if (string.IsNullOrEmpty(result) == false)
                {
                    var jsonResponse = JsonConvert.DeserializeObject<GithubSearchResult>(result);
                    response = jsonResponse.Items;
                }

            }
            catch( Exception ex )
            {
                throw new ApplicationException("An error occurred while searching for repositories", ex);
            }

            return response;
        }

        public async Task<IEnumerable<GithubRepository>> GetAllRepositories()
        {
            IEnumerable<GithubRepository> response = new List<GithubRepository>();
            try
            {
                var endpoint = $"repositories";

                var res = await this._httpClient.GetAsync(endpoint);
                var result = await _getRepositories(endpoint);

                if (string.IsNullOrEmpty(result) == false)
                {
                    var jsonResponse = JsonConvert.DeserializeObject<List<GithubRepository>>(result);
                    response = jsonResponse;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while getting all repositories", ex);
            }

            return response;
        }

        private async Task<string> _getRepositories(string endpoint)
        {
            var res = await this._httpClient.GetAsync(endpoint);

            string result = null;

            if (res.IsSuccessStatusCode)
            {
                result = res.Content.ReadAsStringAsync().Result;
            }

            return result;
        }

        public async Task<IEnumerable<GithubRepository>> GetByUsername(string username)
        {
            IEnumerable<GithubRepository> response = new List<GithubRepository>();
            try
            {
                var endpoint = $"users/{username}/repos";

                var result = await _getRepositories(endpoint);

                if (string.IsNullOrEmpty(result) == false)
                {
                    var jsonResponse = JsonConvert.DeserializeObject<List<GithubRepository>>(result);
                    response = jsonResponse;
                }

            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while searching for repositories", ex);
            }

            return response;
        }
    }
}
