namespace FeedMeApi.Models
{
    /// <summary>
    /// Health Status Object
    /// </summary>
    public enum HealthStatuses
    {
        /// <summary>
        /// Indicated a healthy API check.
        /// </summary>
        Pass,

        /// <summary>
        /// Indicates an unhealthy API check.
        /// </summary>
        Fail
    }
}
