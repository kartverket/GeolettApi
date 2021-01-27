using GeolettApi.Domain.Models;
using GeolettApi.Domain.Repositories;
using GeolettApi.Infrastructure.DataModel;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GeolettApi.Infrastructure.Repositories
{
    public class RegisterItemRepository : IRepository<RegisterItem, int>
    {
        private readonly GeolettContext _context;

        public RegisterItemRepository(
            GeolettContext context)
        {
            _context = context;
        }

        public IQueryable<RegisterItem> GetAll()
        {
            return _context.RegisterItems
                .AsQueryable();
        }

        public async Task<RegisterItem> GetByIdAsync(int id)
        {
            return await GetAll()
                .Include(registerItem => registerItem.Links)
                .SingleOrDefaultAsync(registerItem => registerItem.Id == id);
        }

        public RegisterItem Create(RegisterItem registerItem)
        {
            _context.RegisterItems.Add(registerItem);

            return registerItem;
        }

        public void Delete(RegisterItem registerItem)
        {
            if (registerItem == null)
                return;

            _context.RegisterItems.Remove(registerItem);
        }
    }
}
