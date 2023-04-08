using System.Data;

namespace MyCompany.Store.Application.Shared.Data
{
    public interface ISqlConnectionFactory
    {
        IDbConnection GetOpenConnection();
    }
}
