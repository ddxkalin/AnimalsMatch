using System;

namespace Pets.Data.Common
{
    public interface IDbQueryRunner : IDisposable
    {
        void RunQuery(string query, params object[] parameters);
    }
}
