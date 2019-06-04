using System;
using Newtonsoft.Json;

namespace milestone_merger_console.Models
{
    /// <summary>
    /// A merge request
    /// </summary>
    public class MergeRequest
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("iid")]
        public long Iid { get; set; }

        [JsonProperty("project_id")]
        public long ProjectId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("merged_by")]
        public Author MergedBy { get; set; }

        [JsonProperty("merged_at")]
        public DateTimeOffset? MergedAt { get; set; }

        [JsonProperty("closed_by")]
        public object ClosedBy { get; set; }

        [JsonProperty("closed_at")]
        public object ClosedAt { get; set; }

        [JsonProperty("target_branch")]
        public string TargetBranch { get; set; }

        [JsonProperty("source_branch")]
        public string SourceBranch { get; set; }

        [JsonProperty("user_notes_count")]
        public long UserNotesCount { get; set; }

        [JsonProperty("upvotes")]
        public long Upvotes { get; set; }

        [JsonProperty("downvotes")]
        public long Downvotes { get; set; }

        [JsonProperty("assignee")]
        public Author Assignee { get; set; }

        [JsonProperty("author")]
        public Author Author { get; set; }

        [JsonProperty("assignees")]
        public Author[] Assignees { get; set; }

        [JsonProperty("source_project_id")]
        public long SourceProjectId { get; set; }

        [JsonProperty("target_project_id")]
        public long TargetProjectId { get; set; }

        [JsonProperty("labels")]
        public object[] Labels { get; set; }

        [JsonProperty("work_in_progress")]
        public bool WorkInProgress { get; set; }

        [JsonProperty("milestone")]
        public Milestone Milestone { get; set; }

        [JsonProperty("merge_when_pipeline_succeeds")]
        public bool MergeWhenPipelineSucceeds { get; set; }

        [JsonProperty("merge_status")]
        public string MergeStatus { get; set; }

        [JsonProperty("sha")]
        public string Sha { get; set; }

        [JsonProperty("merge_commit_sha")]
        public string MergeCommitSha { get; set; }

        [JsonProperty("discussion_locked")]
        public object DiscussionLocked { get; set; }

        [JsonProperty("should_remove_source_branch")]
        public object ShouldRemoveSourceBranch { get; set; }

        [JsonProperty("force_remove_source_branch")]
        public bool? ForceRemoveSourceBranch { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("web_url")]
        public Uri WebUrl { get; set; }

        [JsonProperty("time_stats")]
        public TimeStats TimeStats { get; set; }

        [JsonProperty("squash")]
        public bool Squash { get; set; }

        [JsonProperty("approvals_before_merge")]
        public long? ApprovalsBeforeMerge { get; set; }
    }
}