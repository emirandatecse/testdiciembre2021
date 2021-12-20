using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TipoCambio.Service.Api.Models;

namespace TipoCambio.Service.Api.Data.DapperConexion.CurrencyExchange
{
    public interface ICurrencyExchangeRepository
    {
        Task<int> Create(CurrencyExchangeModel currencyExchangeModel);
        Task<CurrencyExchangeResult> Search(CurrencyExchangeModel currencyExchangeModel);
    }
}
