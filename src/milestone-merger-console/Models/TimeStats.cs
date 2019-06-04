using Newtonsoft.Json;

namespace milestone_merger_console.Models
{
    public class TimeStats
    {
        [JsonProperty("time_estimate")]
        public long TimeEstimate { get; set; }

        [JsonProperty("total_time_spent")]
        public long TotalTimeSpent { get; set; }

        [JsonProperty("human_time_estimate")]
        public object HumanTimeEstimate { get; set; }

        [JsonProperty("human_total_time_spent")]
        public object HumanTotalTimeSpent { get; set; }
    }
}