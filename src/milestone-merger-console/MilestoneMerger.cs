using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using McMaster.Extensions.CommandLineUtils;
using McMaster.Extensions.CommandLineUtils.Abstractions;
using Microsoft.Extensions.Logging;
using milestone_merger_console.GitLabClient;
using milestone_merger_console.Models;

namespace milestone_merger_console
{
    /// <summary>
    /// Merger - merges all the merge requests for a milestone
    /// </summary>
    public class MilestoneMerger
    {
        /// <summary>
        /// Initializes a new instance of the milestone merger class.
        /// </summary>
        /// <param name="logger"> logger </param>
        /// <param name="service"> git lab service</param>
        public MilestoneMerger(ILogger<MilestoneMerger> logger, IGitLabService service)
        {
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            Service = service ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Gets the gitlab service
        /// </summary>
        private IGitLabService Service { get; }

        /// <summary>
        /// Gets the logger
        /// </summary>
        private ILogger Logger { get; }

        [Option]
        [Required]
        public string Milestone { get; set; }

        [Option("--merge")]
        public bool Merge { get; set; }

        public async Task OnExecuteAsync()
        {
            if (Merge)
            {
                Logger.LogWarning("Merge option supplied, all merge requests under milestone will be merged");
            }
            else
            {
                Logger.LogInformation("Merge option not specified, in dry run mode");
            }

            try
            {
                Logger.LogInformation($"Locating merge requests for milestone {Milestone}");
                IEnumerable<MergeRequest> requests = await Service.GetMilestoneOpenMergeRequestsAsync(Milestone);

                Logger.LogInformation($"Found {requests.Count()} opened merge requests for milestone {Milestone}");

                StringBuilder sb = new StringBuilder();

                foreach (MergeRequest request in requests)
                {
                    sb.AppendLine($"MR: {request.Title}, {request.WebUrl}, {request.State}");
                }

                Logger.LogInformation(sb.AppendLine().ToString());

                if (Merge)
                {
                    bool merge = Prompt.GetYesNo($"Confirm accept all opened merge requests for Milestone {Milestone}?", false);

                    if (merge)
                    {
                        foreach (MergeRequest request in requests)
                        {
                            try
                            {
                                await Service.AcceptMergeRequestAsync(request);

                                Logger.LogInformation($"Accepted merge request {request.Title} {request.WebUrl}");
                            }
                            catch (Exception ex)
                            {
                                Logger.LogError($"An error occured while accepting merge request, {ex.Message}");
                            }
                        }
                    }
                }
            }
            catch (InvalidOperationException ex)
            {
                Logger.LogCritical($"An error occured, {ex.Message}");
            }
        }
    }
}