using System;
using System.Collections.Generic;
using System.Net.Http;

namespace ESShopUI.ApiCallers
{
    public abstract class ApiCallerBase
    {
        protected HttpClient _httpClient { get; init; }

        public ApiCallerBase(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        protected abstract Dictionary<string, string> Urls { get; init; }
    }
}
