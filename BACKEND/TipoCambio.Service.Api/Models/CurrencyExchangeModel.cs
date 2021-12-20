using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TipoCambio.Service.Api.Models
{
    public partial class CurrencyExchangeModel
    {
        public int Type { get; set; }
        public int Id { get; set; }
        public int ExchangeValue { get; set; }
        public string CurrencyDestination { get; set; }
        public string CurrencySource { get; set; }
        public decimal MoneySource { get; set; }
        public decimal MoneyDestination { get; set; }
        public string Created { get; set; }
    }
}
