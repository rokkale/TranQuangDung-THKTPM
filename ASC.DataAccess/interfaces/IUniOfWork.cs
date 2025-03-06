using ASC.Model.BaseTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASC.DataAccess.interfaces
{
    public interface IUniOfWork : IDisposable
    {
        IRepository<T> Repository<T>() where T : BaseEnity;
        public int CommitTransaction();
    }
}
