using Castle.Windsor;
using Castle.Windsor.Installer;
using NServiceBus;
using Statuos.Data;

namespace Statuos.Import.Backend
{
    [EndpointSLA("00:00:30")]
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Publisher, UsingTransport<Msmq>, IWantCustomInitialization
    {
        private IWindsorContainer _container;
        public void Init()
        {
            _container = new WindsorContainer();
            _container.Install(FromAssembly.This());
            Configure.With()
                    .CastleWindsorBuilder();

            Configure.Instance.Configurer.
                      ConfigureComponent<StatuosBackendUnitOfWork>(DependencyLifecycle.InstancePerUnitOfWork);
            Configure.Instance.Configurer
                .ConfigureComponent<IStatuosContext>(() => new StatuosContext(), DependencyLifecycle.InstancePerUnitOfWork);
        }
    }
}
