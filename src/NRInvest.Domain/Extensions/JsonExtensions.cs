using System.Text.Json;

namespace NRInvest.Domain.Extensions
{
    public static class JsonExtensions
    {
        public static string ToJson(this object data)
        {
            return JsonSerializer.Serialize(data);
        }
    }
}