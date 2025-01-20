using System.Data.Common;
using Npgsql;
using Quiz.Application.Abstractions.Data;

namespace Quiz.Infrastructure.Data;

internal class DbConnectionFactory(NpgsqlDataSource dataSource) : IDbConnectionFactory
{
    public async ValueTask<DbConnection> OpenConnectionAsync()
    {
        return await dataSource.OpenConnectionAsync();
    }
}
