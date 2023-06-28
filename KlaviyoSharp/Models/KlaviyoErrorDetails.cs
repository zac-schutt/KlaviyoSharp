namespace KlaviyoSharp.Models
{
    /// <summary>
    /// Details of the error returned from the Klaviyo API
    /// </summary>
    public class KlaviyoErrorDetails
    {
        /// <summary>
        /// ID of the error
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Code name of the error
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Details about the cause of the error
        /// </summary>
        public string Detail { get; set; }
        /// <summary>
        /// Error title
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Source of the error in the request
        /// </summary>
        public KlaviyoErrorSource Source { get; set; }
    }
}