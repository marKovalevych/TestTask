using BL.ValidationModels;
using DA.Entities;
using DA.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class IncidentService : IIncidentService
    {
        private readonly IIncidentRepository _incidentRepository;
        private readonly IAccountService _accountService;
        public IncidentService(IIncidentRepository incidentRepository, IAccountService accountService, ISaveChangerService saveChangerService)
        {
            _incidentRepository=incidentRepository;
            _accountService=accountService;
        }

        public async Task<Incident> CreateIncident(IncidentModel model)
        {
            var incident = new Incident
            {
                Description = model.Description
            };
            var incidents = await _incidentRepository.GetAllIncidentsAsync();
            var titles = incidents.Select(x => x.Title).ToHashSet();
            var isAvailable = false;
            while (!isAvailable)
            {
                var title = GenerateTitle();
                if (!titles.Contains(title.ToString()))
                {
                    isAvailable = true;
                    incident.Title = title.ToString();
                }
            }

            var accountExist = await _accountService.CheckAccountExistingAsync(model.AccountName);

            if (accountExist)
            { 
                return null;
            }
            var account = new AccountCreateModel
            {
                Name = model.AccountName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email
            };

            await _accountService.CreateAccount(account, incident);

            await _incidentRepository.CreateIncidentAsync(incident);
            return incident;
        }

        public async Task<List<Incident>> GetAllIncidents()
        {
            return await _incidentRepository.GetAllIncidentsAsync();
        }

        private Guid GenerateTitle()
        {
            return Guid.NewGuid();
        }

        public async Task<Incident> UpdateIncident(AccountCreateModel model, string incidentTitle)
        {
            var incident = await _incidentRepository.GetIncidentByNameAsync(incidentTitle);
            if (incident is null)
            {
                return null;
            }

            var accountExist = await _accountService.CheckAccountExistingAsync(model.Name);

            if (accountExist)
            {
                return null;
            }
            var account = new AccountCreateModel
            {
                Name = model.Name,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email
            };

            await _accountService.CreateAccount(account, incident);

            return incident;
        }
    }
}
