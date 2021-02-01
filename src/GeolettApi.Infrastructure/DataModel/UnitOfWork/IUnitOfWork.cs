using System;
using System.Threading.Tasks;

namespace GeolettApi.Infrastructure.DataModel.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        GeolettContext Context { get; }
        bool IsRoot { get; }
        Task SaveChangesAsync();
    }
}
