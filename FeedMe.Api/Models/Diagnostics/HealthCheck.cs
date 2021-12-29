using System;

namespace FeedMe.Api.Models.Diagnostics
{
    public class HealthCheck
    {
        public HealthStatuses Status { get; set; }

        public DateTime Time { get; set; }
    }
}
