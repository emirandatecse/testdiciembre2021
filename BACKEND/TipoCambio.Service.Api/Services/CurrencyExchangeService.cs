using System.Threading.Tasks;
using TipoCambio.Service.Api.Models;
using TipoCambio.Service.Api.Data.DapperConexion.CurrencyExchange;

namespace TipoCambio.Service.Api.Services
{
    public class CurrencyExchangeService : ICurrencyExchangeService
    {
        private readonly ICurrencyExchangeRepository _currencyExchangeRepository;
        public CurrencyExchangeService(ICurrencyExchangeRepository currencyExchangeRepository)
        {
            _currencyExchangeRepository = currencyExchangeRepository;
        }

        public async Task<int> CreateCurrency(CurrencyExchangeModel currencyExchangeModel)
        {
            return await _currencyExchangeRepository.Create(currencyExchangeModel);
        }

        public async Task<CurrencyExchangeResult> GetCurencyExchange(CurrencyExchangeModel currencyExchangeModel)
        {
            return await _currencyExchangeRepository.Search(currencyExchangeModel);
        }
    }
}
