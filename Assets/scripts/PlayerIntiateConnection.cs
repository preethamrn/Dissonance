using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerIntiateConnection : MonoBehaviour {

	void Update() {
		Debug.Log(NetworkServer.connections.Count + " players have connected");
		if (NetworkServer.connections.Count >= 2) {
        	Debug.Log("Two Players have connected");
        	
        	NetworkManager nm = FindObjectOfType<NetworkManager>();
        	nm.ServerChangeScene("game");
        }
	}
}
