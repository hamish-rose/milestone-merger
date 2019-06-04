using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using milestone_merger_console.Models;
using Newtonsoft.Json;

namespace milestone_merger_console.GitLabClient
{
    /// <summary>
    /// Typed GitLab http client / service
    /// </summary>
    public class GitLabService : IGitLabService
    {
        /// <summary>
        /// Initializes a new instance of the GitLabService class.
        /// </summary>
        public GitLabService(HttpClient client, IConfiguration configuration)
        {
            string privateToken = configuration.GetValue<string>("accessToken");
            string uri = configuration.GetValue<string>("gitlabUri");

            if (string.IsNullOrEmpty(privateToken))
            {
                throw new ArgumentException("access token app setting must be set, and cannot be null or whitespace");
            }

            if (!Uri.IsWellFormedUriString(uri, UriKind.Absolute))
            {
                throw new ArgumentException("gitlab URI app setting is not a valid absolute URI.");
            }

            client.BaseAddress = new Uri(uri);
            client.DefaultRequestHeaders.Add("Private-Token", privateToken);

            Client = client;
        }

        /// <summary>
        /// Gets the http client
        /// </summary>
        private HttpClient Client { get; }

        /// <summary>
        /// Accept a merge request, merging it once its pipeline has succeeded
        /// </summary>
        /// <param name="request"> merge reuest</param>
        /// <returns> task</returns>
        public async Task AcceptMergeRequestAsync(MergeRequest request)
        {
            string resource = $"projects/{request.ProjectId}/merge_requests/{request.Iid}/merge?"
            + "squash=true&should_remove_source_branch=true&merge_when_pipeline_succeeds=true";

            HttpResponseMessage response = await Client.PutAsync(resource, new StringContent(string.Empty));

            if (response.IsSuccessStatusCode)
            {
                return;
            }
            else
            {
                throw new InvalidOperationException($"Failed to accept merge request {request.Title}, {request.WebUrl}. " +
                $"Unsuccessful response from GitLab - {response.StatusCode}");
            }
        }

        /// <summary>
        /// Retrieves all merge requests for a given milestone
        /// </summary>
        /// <param name="groupId"> group id </param>
        /// <param name="milestoneId"> milestone id</param>
        /// <returns> all milestones associated with a merge request</returns>
        public async Task<IEnumerable<MergeRequest>> GetMilestoneOpenMergeRequestsAsync(string title)
        {
            HttpResponseMessage response = await Client.GetAsync($"merge_requests?milestone={title}&scope=all&state=opened");

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<IEnumerable<MergeRequest>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new InvalidOperationException($"GitLab responded with unsuccesful status code, {response.StatusCode}");
            }
        }
    }
}