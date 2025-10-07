using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using api.Dtos.External.CollectApi;
using api.Interfaces;
using Microsoft.Extensions.Configuration;


public class CollectApiService : ICollectApiService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _config;

    public CollectApiService(HttpClient httpClient, IConfiguration config)
    {
        _httpClient = httpClient;
        _config = config;
    }

 public async Task<List<StockInfo>> GetStocksAsync()
{
    using var request = new HttpRequestMessage
    {
        Method = HttpMethod.Get,
        RequestUri = new Uri($"{_config["CollectApi:BaseUrl"]}/hisseSenedi")
    };

    // Sadece Authorization header eklenmeli
    request.Headers.Add("authorization", $"apikey {_config["CollectApi:ApiKey"]}");

    // "content-type" GET isteklerinde kullanılmaz! (Sildik)

    var response = await _httpClient.SendAsync(request);

    // Başarısızsa otomatik hata fırlatsın
    response.EnsureSuccessStatusCode();

    // İçeriği deserialize et
    var stream = await response.Content.ReadAsStreamAsync();

    var result = await JsonSerializer.DeserializeAsync<CollectApiResponse<StockInfo>>(stream, new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true
    });

    return result?.Result ?? new List<StockInfo>();
}

}