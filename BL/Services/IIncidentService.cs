using BL.ValidationModels;
using DA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public interface IIncidentService
    {
        public Task<Incident> CreateIncident(IncidentModel model); 
        public Task<List<Incident>> GetAllIncidents();
    }
}
