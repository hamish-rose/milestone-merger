using System;
using Newtonsoft.Json;

namespace milestone_merger_console.Models
{
    public class Author
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("avatar_url")]
        public Uri AvatarUrl { get; set; }

        [JsonProperty("web_url")]
        public Uri WebUrl { get; set; }
    }
}