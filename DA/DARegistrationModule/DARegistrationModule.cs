using Autofac;
using DA.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.DARegistrationModule
{
    public class DARegistrationModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DataContext>().AsSelf().SingleInstance();
            builder.RegisterType<ContactRepository>().As<IContactRepository>();
            builder.RegisterType<AccountRepository>().As<IAccountRepository>();
            builder.RegisterType<IncidentRepository>().As<IIncidentRepository>();
            builder.RegisterType<SaveChanger>().As<ISaveChanger>();
        }
    }
}
