using DA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Repositories
{
    public interface IIncidentRepository
    {
        public Task<List<Incident>> GetAllIncidentsAsync();
        public Task CreateIncidentAsync(Incident incident);
    }
}
