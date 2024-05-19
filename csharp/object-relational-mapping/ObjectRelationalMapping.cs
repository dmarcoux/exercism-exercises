using System;

public class Orm(Database database) : IDisposable
{
    private Database _database = database;

    public void Begin()
    {
        try
        {
            _database.BeginTransaction();
        }
        catch
        {
            _database.Dispose();
        }
    }

    public void Write(string data)
    {
        try
        {
            _database.Write(data);
        }
        catch
        {
            _database.Dispose();
        }
    }

    public void Commit()
    {
        try
        {
            _database.EndTransaction();
        }
        catch
        {
            _database.Dispose();
        }
    }

    public void Dispose() => _database.Dispose();
}