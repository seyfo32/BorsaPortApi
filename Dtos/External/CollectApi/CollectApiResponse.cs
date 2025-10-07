using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.External.CollectApi
{
    public class CollectApiResponse<T>
    {
         public bool Success { get; set; }
        public List<T> Result { get; set; }
    }
}