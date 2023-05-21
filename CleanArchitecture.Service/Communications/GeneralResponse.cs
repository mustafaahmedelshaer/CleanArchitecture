using Microsoft.Extensions.Localization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;

namespace CleanArchitecture.Application.Communications
{
    public class GeneralResponse<T>
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("status")]
        public HttpStatusCode Status { get; set; }
        [JsonProperty("resource")]
        public T Resource { get; set; }
        public int ResourceCount { get; set; }
        //private readonly IStringLocalizer<GeneralMessages> _localization;

        //public GeneralResponse(IStringLocalizer<GeneralMessages> localization)
        //{
        //    _localization = localization;
        //}

        public GeneralResponse(T resource,string message ="",int Count=0)
        {
            Success = true;
            Message = message;
            Resource = resource;
            ResourceCount = Count;
            Status = HttpStatusCode.OK;
        }

        public GeneralResponse(string message, HttpStatusCode statusCode)
        {
            Success = false;
            Message = message;
            Resource = default;
            Status = statusCode;
        }
    }
}
