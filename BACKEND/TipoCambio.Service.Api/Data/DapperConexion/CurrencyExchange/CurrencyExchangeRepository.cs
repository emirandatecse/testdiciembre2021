using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using TipoCambio.Service.Api.Models;

namespace TipoCambio.Service.Api.Data.DapperConexion.CurrencyExchange
{
    public class CurrencyExchangeRepository : ICurrencyExchangeRepository
    {
        private readonly IFactoryConnection _factoryConnection;

        public CurrencyExchangeRepository(IFactoryConnection factoryConnection)
        {
            _factoryConnection = factoryConnection;
        }

        public async Task<int> Create(CurrencyExchangeModel currencyExchangeModel)
        {
            var storeProcedure = "up_currencyexchange_register";

            try
            {
                var connection = _factoryConnection.GetConnection();
                
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@pintType", currencyExchangeModel.Type);
                parameters.Add("@pintId", int.MinValue);
                parameters.Add("@pvarCurrencySource", currencyExchangeModel.CurrencySource);
                parameters.Add("@pvarCurrencyDestination", currencyExchangeModel.CurrencyDestination);
                parameters.Add("@pdecMoneySource", currencyExchangeModel.MoneySource);
                parameters.Add("@pdecMoneyDestination", currencyExchangeModel.MoneyDestination);
                parameters.Add("@pdatCreated", currencyExchangeModel.Created);

                var resultado = await connection.ExecuteAsync(storeProcedure, parameters,commandType: CommandType.StoredProcedure);

                _factoryConnection.CloseConnection();

                return resultado;
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo guardar el tipo de cambio", e);
            }
            finally
            {
                _factoryConnection.CloseConnection();
            }
        }

        public async Task<CurrencyExchangeResult> Search(CurrencyExchangeModel currencyExchangeModel)
        {
            CurrencyExchangeResult currencyExchangeModelResult = new CurrencyExchangeResult();
            List<IDictionary<string, object>> listCurrencyExchange = null;

            var storeProcedure = "up_currencyexchange_search";
            try
            {
                var connection = _factoryConnection.GetConnection();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@pintType", currencyExchangeModel.Type);
                parameters.Add("@pvarCurrencySource", currencyExchangeModel.CurrencySource);
                parameters.Add("@pvarCurrencyDestination", currencyExchangeModel.CurrencyDestination);
                parameters.Add("@pdatCreated", currencyExchangeModel.Created);

                var result = await connection.QueryAsync(storeProcedure, parameters, commandType: CommandType.StoredProcedure);
                listCurrencyExchange = result.Select(x => (IDictionary<string, object>)x).ToList();
                currencyExchangeModelResult.ListCurrencyExchange = listCurrencyExchange;
            }
            catch (Exception e)
            {
                throw new Exception("Error en la consulta de datos", e);
            }
            finally
            {
                _factoryConnection.CloseConnection();
            }
            return currencyExchangeModelResult;
        }
    }
}
