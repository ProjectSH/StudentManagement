using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.DapperRepository.UnitOfWork
{
    public class UnitOfWork:IDisposable,IUnitOfWork
    {
        public UnitOfWork(IDbConnection conn)
        {
            _conn = conn;
        }

        private readonly IDbConnection _conn;
        private bool _disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _conn.Dispose();
                }
            }
            this._disposed = true;
        }

        public IContext Context { get; }
        public int SaveChanges()
        {
            throw new Exception();
        }
    }
}
