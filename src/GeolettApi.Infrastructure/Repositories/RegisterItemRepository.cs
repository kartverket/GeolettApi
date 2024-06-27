using GeolettApi.Domain.Models;
using GeolettApi.Domain.Repositories;
using GeolettApi.Infrastructure.DataModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
                .Include(registerItem => registerItem.Owner)
                .Include(registerItem => registerItem.DataSet)
                    .ThenInclude(dataSet => dataSet.TypeReference)
                .Include(registerItem => registerItem.Reference)
                    .ThenInclude(reference => reference.Tek17).AsNoTracking()
                .Include(registerItem => registerItem.Reference)
                    .ThenInclude(reference => reference.OtherLaw).AsNoTracking()
                .Include(registerItem => registerItem.Reference)
                    .ThenInclude(reference => reference.CircularFromMinistry).AsNoTracking()
                .Include(registerItem => registerItem.Links)
                    .ThenInclude(registerItemLink => registerItemLink.Link)
                .SingleOrDefaultAsync(registerItem => registerItem.Id == id);
        }

        public RegisterItem Create(RegisterItem registerItem)
        {
            var registerItemAdded = _context.RegisterItems.Add(registerItem);
            var owner = _context.Organizations.Where(o => o.Id == registerItem.OwnerId).FirstOrDefault();
            registerItem.Owner = owner;

            return registerItem;
        }

        public void Delete(RegisterItem registerItem)
        {
            if (registerItem == null)
                return;

            DeleteChildren(registerItem);

            _context.RegisterItems.Remove(registerItem);
        }

        private void DeleteChildren(RegisterItem registerItem)
        {
            var links = new List<Link>();

            registerItem.Links.ForEach(registerItemLink => links.Add(registerItemLink.Link));

            if (registerItem?.Reference?.Tek17 != null)
                links.Add(registerItem.Reference.Tek17);

            if (registerItem?.Reference?.OtherLaw != null)
                links.Add(registerItem.Reference.OtherLaw);

            if (registerItem?.Reference?.CircularFromMinistry != null)
                links.Add(registerItem.Reference.CircularFromMinistry);

            _context.Links.RemoveRange(links);

            if (registerItem?.DataSet?.TypeReference != null)
                _context.ObjectTypes.Remove(registerItem.DataSet.TypeReference);

            if (registerItem?.DataSet != null)
                _context.DataSets.Remove(registerItem.DataSet);

            if (registerItem?.Reference != null)
                _context.References.Remove(registerItem.Reference);
        }
    }
}
