using Refit;
using System.Threading.Tasks;

namespace ZipCodeInformation
{
    public interface ICepApiService
    {
        [Get("/ws/{cep}/json")]
        Task<CepResponse> GetAddresAsync(string cep);
    }
}
