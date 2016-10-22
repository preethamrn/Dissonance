using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class SyncClient : NetworkBehaviour {

	
	// Use this for initialization
	void Start () {
		Who who = FindObjectOfType<Who>();
		if (isLocalPlayer) {
			who.SetMe(gameObject);
		} else {
			who.SetNotMe(gameObject);
		}
	}

    public void MeChangedLane(int lane) {
        CmdChangeLane(lane);
    }

	[Command]
	void CmdChangeLane(int lane) {
		RpcChangeLane(lane);
	}

	[ClientRpc]
	void RpcChangeLane(int lane) {
		SetLane(lane);
	} 

	void SetLane(int l) {
        Debug.Log("Enemy at: " + l.ToString());
        FindObjectOfType<EnemyControls>().move(l);
	}
}
