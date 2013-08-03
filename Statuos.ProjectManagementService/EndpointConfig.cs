using Castle.Windsor;
using Castle.Windsor.Installer;
using NServiceBus;
using Statuos.Data;

namespace Statuos.ProjectManagementService
{
    [EndpointSLA("00:00:30")]
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Publisher, IWantCustomInitialization, UsingTransport<Msmq>
    {
        public void Init()
        {
            var context = new StatuosContext();
            Configure.With()
                    .CastleWindsorBuilder();
            Configure.Instance.Configurer.
                      ConfigureComponent<StatuosBackendUnitOfWork>(DependencyLifecycle.InstancePerUnitOfWork);
            Configure.Instance.Configurer
                .ConfigureComponent<StatuosContext>(DependencyLifecycle.InstancePerUnitOfWork);
            Configure.Instance.Configurer
                .ConfigureComponent<IStatuosContext>(() => new StatuosContext(), DependencyLifecycle.InstancePerUnitOfWork);
                
        }
    }
}
