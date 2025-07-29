using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pulumi;
using Twingate.Twingate;
using Twingate.Twingate.Inputs;
using Twingate.Twingate.Outputs;

class Program
{
    static Task<int> Main() => Deployment.RunAsync<DevStack>();
}

public class DevStack : Stack
{
    public DevStack()
    {
        var homelabNetwork = new TwingateRemoteNetwork("tg_remote_network_hl", new TwingateRemoteNetworkArgs
        {
            Name = "Homelab",
        });

        var homelabConnector = new TwingateConnector("tg_connector_hl", new TwingateConnectorArgs
        {
            RemoteNetworkId = homelabNetwork.Id,
            StatusUpdatesEnabled = true,
        });
    }
}
