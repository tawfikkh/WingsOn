using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace WingsOn.Api.DTOs
{
    public class ApiError
    {
        /// <summary>
        /// inner error
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public ApiError Erorr { get;set; }
        
        /// <summary>
        /// where the error was encountered
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Target { get; set; }
        
        /// <summary>
        /// human readable message
        /// </summary>
        public string Message { get; set; }
        
        /// <summary>
        /// error code
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Code { get; set; }

        /// <summary>
        /// error details
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<ApiError> Details { get; set; }
    }
}