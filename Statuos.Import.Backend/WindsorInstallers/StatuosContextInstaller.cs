using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Statuos.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statuos.Import.Backend.WindsorInstallers
{
    public class StatuosContextInstaller : IWindsorInstaller
    {

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IStatuosContext>()
                .ImplementedBy<StatuosContext>()
                .LifeStyle.Singleton);
        }
    }
}
