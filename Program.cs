using System;
using System.Collections.Generic;
using Pulumi;
using Twingate.Twingate;
using Twingate.Twingate.Inputs;
using Twingate.Twingate.Outputs;

await Deployment.RunAsync(() =>
{
    var homelabNetwork = new TwingateRemoteNetwork("tg_remote_network_hl", new TwingateRemoteNetworkArgs
    {
        Name = "Homelab",
    });

    var homelabConnector = new TwingateConnector("tg_connector_hl", new TwingateConnectorArgs
    {
        Name = "tg-connector-hl-01"
        RemoteNetworkId = homelabNetwork.Id,
        StatusUpdatesEnabled = true,
    });
    
    return new Dictionary<string, object?>
    {
        { "remoteNetworkId", homelabNetwork.Id },
        { "connectorId", homelabConnector.Id }
    };
});
