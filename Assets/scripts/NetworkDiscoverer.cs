using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class NetworkDiscoverer : NetworkDiscovery {

    public override void OnReceivedBroadcast(string fromAddress, string data) {
        NetworkManager.singleton.networkAddress = fromAddress;
        FindObjectOfType<Networker>().addServer(fromAddress);
    }

    public void receivedBroadcast() {
        NetworkManager.singleton.StartClient();
    }

    public void sendBroadcast() {
        NetworkManager.singleton.StartClient();
    }
}