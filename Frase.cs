using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiFrase{
    public class Root{
        public string phrase {get;set;}
        public string author {get;set;}
    }

    public class Frases{
        private static readonly HttpClient client = new HttpClient();

        public async Task<string> GetFraseDelDiaAsync(){
            string url = "https://frasedeldia.azurewebsites.net/api/phrase";

            try{
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                Root data = JsonSerializer.Deserialize<Root>(responseBody);

                if (data != null){
                    return data.phrase;
                }else{
                    return "No se pudo obtener la frase.";
                }
            }
            catch (HttpRequestException e){
                return $"Excepción capturada: {e.Message}";
            }
        }
    }
}
