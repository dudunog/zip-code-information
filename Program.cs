using Refit;
using System;
using System.Threading.Tasks;

namespace ZipCodeInformation
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                var cepClient = RestService.For<ICepApiService>("http://viacep.com.br");
                Console.Write("Informe seu CEP: ");

                string CepInformado = Console.ReadLine().ToString();
                Console.WriteLine("Consultando informações do CEP: " + CepInformado);

                var address = await cepClient.GetAddresAsync(CepInformado);

                Console.Write($"\nLogradouro: {address.Logradouro}\nBairro: {address.Bairro}\nCidade: {address.Localidade}" +
                    $"\nUf: {address.Uf}");
                Console.ReadKey();
            }
            catch(Exception e)
            {
                Console.WriteLine("Erro na consulta do CEP: " + e.Message);
            }
        }
    }
}
