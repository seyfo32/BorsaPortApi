using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.External.CollectApi;

namespace api.Interfaces
{
    public interface ICollectApiService
    {
        Task<List<StockInfo>> GetStocksAsync();
        Task SaveBorsaStocksToDatabaseAsync();
    }
}