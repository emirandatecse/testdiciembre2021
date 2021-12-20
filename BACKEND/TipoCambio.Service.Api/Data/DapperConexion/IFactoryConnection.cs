using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace TipoCambio.Service.Api.Data.DapperConexion
{
    public interface IFactoryConnection
    {
        void CloseConnection();
        IDbConnection GetConnection();
    }
}
