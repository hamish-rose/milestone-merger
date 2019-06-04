using System;
using Newtonsoft.Json;

namespace milestone_merger_console.Models
{
    /// <summary>
    /// GitLab group
    /// </summary>
    public class Group
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("web_url")]
        public Uri WebUrl { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("visibility")]
        public string Visibility { get; set; }

        [JsonProperty("lfs_enabled")]
        public bool LfsEnabled { get; set; }

        [JsonProperty("avatar_url")]
        public Uri AvatarUrl { get; set; }

        [JsonProperty("request_access_enabled")]
        public bool RequestAccessEnabled { get; set; }

        [JsonProperty("full_name")]
        public string FullName { get; set; }

        [JsonProperty("full_path")]
        public string FullPath { get; set; }

        [JsonProperty("parent_id")]
        public long? ParentId { get; set; }

        [JsonProperty("ldap_cn")]
        public object LdapCn { get; set; }

        [JsonProperty("ldap_access")]
        public object LdapAccess { get; set; }
    }
}