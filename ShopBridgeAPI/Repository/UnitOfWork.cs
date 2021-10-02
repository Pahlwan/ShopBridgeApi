using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PlutoContext _context;

        public UnitOfWork(PlutoContext context)
        {
            _context = context;
            Items = new ItemRepository(_context);
        }
        public IItemRepository Items { get; private set; }

        public int Complete(object entity)
        {
            int ret =  _context.SaveChanges();
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            return ret;
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
