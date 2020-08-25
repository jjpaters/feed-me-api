using System;

namespace FeedMeApi.Models
{
    /// <summary>
    /// Health Object
    /// </summary>
    public class Health
    {
        /// <summary>
        /// Indicates the health status.
        /// </summary>
        public HealthStatuses Status { get; set; }

        /// <summary>
        /// Indicates when the health check was performed.
        /// </summary>
        public DateTime Time { get; }

        /// <summary>
        /// Initializes Health.
        /// </summary>
        public Health()
        {
            this.Time = DateTime.UtcNow;
        }

        /// <summary>
        /// Indicates the username of the calling request.
        /// </summary>
        public string Username { get; set; }
    }
}
