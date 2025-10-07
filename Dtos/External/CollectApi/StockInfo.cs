using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.External.CollectApi
{
    public class StockInfo
    {public string Code { get; set; }
    public string Text { get; set; }
    public decimal? LastPrice { get; set; }
    public decimal? Rate { get; set; }
    public decimal? Hacim { get; set; }
    public string HacimStr { get; set; }
    public string LastPriceStr { get; set; }

        // Gerekirse CollectAPI’nin JSON yapısına göre diğer prop ları eklenecek
    }
}