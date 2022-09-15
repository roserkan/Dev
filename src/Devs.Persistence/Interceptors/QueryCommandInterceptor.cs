using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;

namespace Devs.Persistence.Interceptors;

public class QueryCommandInterceptor : DbCommandInterceptor
{


    public override InterceptionResult<int> NonQueryExecuting(
       DbCommand command,
       CommandEventData eventData,
       InterceptionResult<int> result)
    {
        // TODO: Add your business logic
        // var dbName = connection.Database;
        // var commandText = command.CommandText;
        return result;
    }

    public override ValueTask<InterceptionResult<int>> NonQueryExecutingAsync(
        DbCommand command,
        CommandEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        // TODO: Add your business logic
        // var dbName = connection.Database;
        // var commandText = command.CommandText;
        return new ValueTask<InterceptionResult<int>>(result);
    }

    public override InterceptionResult<DbDataReader> ReaderExecuting(
        DbCommand command,
        CommandEventData eventData,
        InterceptionResult<DbDataReader> result)
    {
        // TODO: Add your business logic
        // var dbName = connection.Database;
        // var commandText = command.CommandText;

        return result;
    }

    public override ValueTask<InterceptionResult<DbDataReader>> ReaderExecutingAsync(
        DbCommand command,
        CommandEventData eventData,
        InterceptionResult<DbDataReader> result,
        CancellationToken cancellationToken = default)
    {
        // TODO: Add your business logic
        // var dbName = connection.Database;
        // var commandText = command.CommandText;

        return new ValueTask<InterceptionResult<DbDataReader>>(result);
    }

    public override InterceptionResult<object> ScalarExecuting(
       DbCommand command,
       CommandEventData eventData,
       InterceptionResult<object> result)
    {
        // TODO: Add your business logic
        // var dbName = connection.Database;
        // var commandText = command.CommandText;
        return result;
    }

    public override ValueTask<InterceptionResult<object>> ScalarExecutingAsync(
        DbCommand command,
        CommandEventData eventData,
        InterceptionResult<object> result,
        CancellationToken cancellationToken = default)
    {
        // TODO: Add your business logic
        // var dbName = connection.Database;
        // var commandText = command.CommandText;
        return new ValueTask<InterceptionResult<object>>(result);
    }
}