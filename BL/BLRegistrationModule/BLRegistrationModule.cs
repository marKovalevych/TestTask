using Autofac;
using BL.Services;
using DA.DARegistrationModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BLRegistrationModule
{
    public class BLRegistrationModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new DARegistrationModule());
            builder.RegisterType<AccountService>().As<IAccountService>();
            builder.RegisterType<IncidentService>().As<IIncidentService>();
            builder.RegisterType<ContactService>().As<IContactService>();
            builder.RegisterType<SaveChangerService>().As<ISaveChangerService>();
        }
    }
}
