using System.Collections.Generic;
using System.Net.Http;

namespace ESShopUI.ApiCallers
{
    public class ProductApiCaller : ApiCallerBase
    {
        public ProductApiCaller(HttpClient httpClient) : base(httpClient)
        {
            Urls["list"] = "";
        }

        protected override Dictionary<string, string> Urls { get; init; }
    }
}
