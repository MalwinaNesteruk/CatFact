using CatFact.Models;
using CatFact.Services.Interfaces;
using Newtonsoft.Json;
using RestSharp;

namespace CatFact.Services
{
    public class InfoGetterService : IInfoGetterService
    {
        public string GetLineFromApi()
        {
            string url = "https://catfact.ninja/fact";
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.Execute(request, Method.Get);


            if (response.IsSuccessful)
            {
                var contentJson = response.Content;
                ApiResponse apiInfo = JsonConvert.DeserializeObject<ApiResponse>(contentJson);

                string fact = apiInfo.Fact;
                int length = apiInfo.Length;
                return fact + " Długość komunikatu: " + length.ToString();
            }
            else
            {
                throw new Exception("Nieprawidłowa odpowiedź API");
            }
        }
    }
}
