using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerIntiateConnection : NetworkBehaviour {

	private bool nextScene = false;
	[ServerCallback]
	void Update() {
		//if (NetworkServer.active) {
			//Debug.Log("I am a server");
			Debug.Log(NetworkServer.connections.Count + " players have connected");
			if (!nextScene && NetworkServer.connections.Count >= 2) {
    	    	Debug.Log("Two Players have connected");
    	    	
    	    	NetworkManager nm = FindObjectOfType<NetworkManager>();
    	    	nm.ServerChangeScene("game");
    	    	nextScene = true;
    	    }
    	//}
	}
}
