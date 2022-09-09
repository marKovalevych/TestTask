using DA.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Repositories
{
    public class IncidentRepository:IIncidentRepository
    {
        private readonly DataContext _context;

        public IncidentRepository(DataContext context)
        {
            _context=context;
        }

        public async Task CreateIncidentAsync(Incident incident)
        {
            await _context.Incidents.AddAsync(incident);
        }

       

        public async Task<List<Incident>> GetAllIncidentsAsync()
        {
            return await _context.Incidents.ToListAsync();
        }
    }
}
