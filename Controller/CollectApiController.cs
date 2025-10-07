using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using api.Dtos.External.CollectApi;
using api.Service;
using api.Interfaces;

[Route("api/[controller]")]
[ApiController]
public class CollectApiController : ControllerBase
{
    private readonly ICollectApiService _collectApiService;

    public CollectApiController(ICollectApiService collectApiService)
    {
        _collectApiService = collectApiService;
    }

    [HttpGet("stocks")]
    public async Task<IActionResult> GetStocks()
    {
        var stocks = await _collectApiService.GetStocksAsync();
        if (stocks == null || stocks.Count == 0)
            return NotFound("No stock data found.");

        return Ok(stocks);
    }
}
