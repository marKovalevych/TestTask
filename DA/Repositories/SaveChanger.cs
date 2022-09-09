using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Repositories
{
    public class SaveChanger : ISaveChanger
    {
        private readonly DataContext _context;

        public SaveChanger(DataContext context)
        {
            _context=context;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
