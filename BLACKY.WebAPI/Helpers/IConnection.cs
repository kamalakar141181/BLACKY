using System.Data;

namespace BLACKY.WebAPI.Helpers
{
    public interface IConnection
    {
        string ConnectionString { get; }    
        IDbConnection GetConnection { get; }
    }
}
