using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Krzaq.Mikrus.WebApi.Core.Providers
{
    public interface IApiKeyProvider
    {
        SymmetricSecurityKey GetApiKey();
    }
    internal class ApiKeyProvider(IConfiguration configuration) : IApiKeyProvider
    {
        public SymmetricSecurityKey GetApiKey()
        {
            string key = configuration.GetValue<string>("apikey")!;
            byte[] keyBytes = Encoding.ASCII.GetBytes(key);
            return new(keyBytes);
        }
    }
}
