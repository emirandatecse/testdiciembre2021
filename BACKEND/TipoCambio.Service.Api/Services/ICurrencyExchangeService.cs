using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TipoCambio.Service.Api.Models;

namespace TipoCambio.Service.Api.Services
{
    public interface ICurrencyExchangeService
    {
        Task<CurrencyExchangeResult> GetCurencyExchange(CurrencyExchangeModel currencyExchangeModel);
        Task<int> CreateCurrency(CurrencyExchangeModel currencyExchangeModel);
    }
}
