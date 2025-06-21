using System.Data;

namespace SistemNotaris.Application.Abstraction.Data;

public interface ISqlConnectionFactory
{
    IDbConnection CreateConnection();
}