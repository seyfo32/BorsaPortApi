using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class BorsaStock
    {
        [Key]
        public int Id { get; set; }

        public string Code { get; set; } // "ACSEL"
        public string Name { get; set; } // "ACIPAYAM SELÜLOZ"
        public decimal? LastPrice { get; set; } // 6.25
        public decimal? Rate { get; set; } // 1.46
        public decimal? Volume { get; set; } // 1181299.28
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
    }
}