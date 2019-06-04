using System.Collections.Generic;
using System.Threading.Tasks;
using milestone_merger_console.Models;

namespace milestone_merger_console.GitLabClient
{
    /// <summary>
    /// Gitlab service
    /// </summary>
    public interface IGitLabService
    {
        /// <summary>
        /// Gets all merge requests for a milestone
        /// <param name="title"> milestone title</param>
        /// </summary>
        /// <returns> merge requests</returns>
        Task<IEnumerable<MergeRequest>> GetMilestoneOpenMergeRequestsAsync(string title);

        /// <summary>
        /// Accept a merge request, merging it once its pipeline has succeeded
        /// </summary>
        /// <param name="request"> merge reuest</param>
        /// <returns> task</returns>
        Task AcceptMergeRequestAsync(MergeRequest request);
    }
}