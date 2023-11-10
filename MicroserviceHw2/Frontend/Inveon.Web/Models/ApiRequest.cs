using System.Security.AccessControl;

namespace Inveon.Web.Models
{
    public class ApiRequest
    {
        public StaticDefinitions.ApiType ApiType { get; set; } = StaticDefinitions.ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }
    }
}
