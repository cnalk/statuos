using NServiceBus;

namespace Statuos.Import.Backend
{
    [EndpointSLA("00:00:30")]
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Publisher, UsingTransport<Msmq>
    {
    }
}
