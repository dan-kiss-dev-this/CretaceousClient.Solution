using System.Threading.Tasks;
using RestSharp;
// class RestSharp.RestRequest

namespace CretaceousClient.Models
{
  public class ApiHelper
  {
    public static async Task<string> GetAll()
    {
      RestClient client = new RestClient("https://localhost:7277/");
      RestRequest request = new RestRequest($"api/animals", Method.Get);

      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }
    public static async Task<string> Get(int id)
    {
      RestClient client = new RestClient("https://localhost:7277/");
      RestRequest request = new RestRequest($"api/animals/{id}", Method.Get);
      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }

    public static async void Post(string newAnimal)
    {
      RestClient client = new RestClient("https://localhost:7277/");
      RestRequest request = new RestRequest($"api/animals", Method.Post);
      request.AddHeader("Context-Type", "application/json");
      request.AddJsonBody(newAnimal);
      await client.PostAsync(request);
    }
  }
}