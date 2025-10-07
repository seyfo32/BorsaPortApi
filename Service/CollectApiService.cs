using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.External.CollectApi;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


public class CollectApiService : ICollectApiService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _config;

    private readonly ApplicationDBContext _context;

    public CollectApiService(HttpClient httpClient, IConfiguration config, ApplicationDBContext context)
    {
        _httpClient = httpClient;
        _config = config;
        _context = context;
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

    public async Task SaveBorsaStocksToDatabaseAsync()
    {
         var stockInfos = await GetStocksAsync();

    var borsaStocks = stockInfos.Select(info => new BorsaStock
    {
        Code = info.Code,
        Name = info.Text,
        LastPrice = info.LastPrice,
        Rate = (decimal?)info.Rate,
        Volume = info.Hacim,
        LastUpdated = DateTime.UtcNow
    }).ToList();

    foreach (var stock in borsaStocks)
    {
        var existing = await _context.BorsaStocks.FirstOrDefaultAsync(s => s.Code == stock.Code);

        if (existing == null)
            _context.BorsaStocks.Add(stock);
        else
        {
            existing.LastPrice = stock.LastPrice;
            existing.Rate = stock.Rate;
            existing.Volume = stock.Volume;
            existing.LastUpdated = DateTime.UtcNow;
        }
    }

    await _context.SaveChangesAsync();
    }
}