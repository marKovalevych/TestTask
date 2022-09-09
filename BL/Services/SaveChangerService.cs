using DA.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class SaveChangerService : ISaveChangerService
    {
        private readonly ISaveChanger saveChanger;

        public SaveChangerService(ISaveChanger saveChanger)
        {
            this.saveChanger=saveChanger;
        }

        public async Task SaveChangerAsync()
        {
            await saveChanger.SaveChangesAsync();
        }
    }
}
