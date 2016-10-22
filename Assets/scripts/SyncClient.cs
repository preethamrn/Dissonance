using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class SyncClient : NetworkBehaviour {

	
	// Use this for initialization
	void Start () {
		Who[] whos = FindObjectsOfType(typeof(Who)) as Who[];
		if (isLocalPlayer) {
			
			whos[0].SetMe(gameObject);
		}
		else {
			whos[0].SetNotMe(gameObject);
		}
	
	}

	//[SyncVar(hook = "OnLaneChange")]
	//[SyncVar]
	int lane = 2; //This lane variable is only active for the OTHER client!
	
	// Update is called once per frame

	void Update () {

		if (isLocalPlayer) {
		
			if (Input.GetKeyDown(KeyCode.Alpha1)) {
				//lane = 0;
				CmdChangeLane(0);
			}
			else if (Input.GetKeyDown(KeyCode.Alpha2)) {
				//lane = 1;
				CmdChangeLane(1);
			}
			else if (Input.GetKeyDown(KeyCode.Alpha3)) {
				//lane = 2;
				CmdChangeLane(2);
			}
			else if (Input.GetKeyDown(KeyCode.Alpha4)) {
				//lane = 3;
				CmdChangeLane(3);
			}
			else if (Input.GetKeyDown(KeyCode.Alpha5)) {
				//lane = 4;
				CmdChangeLane(4);
			}
			//Debug.Log("My Lane Is " + lane);
		}
		else {
			//Debug.Log("NotMy Lane Is " + lane);
		}
	}

	/*
	void OnLaneChange(int lane) {
		Debug.Log("Received Change");
		if (isLocalPlayer) {

		}
		else {
			Debug.Log("NotMe Lane Changed To " + lane);
		}
	}
	*/
	[Command]
	void CmdChangeLane(int lane) {
		RpcChangeLane(lane);
	}

	[ClientRpc]
	void RpcChangeLane(int lane) {
		SetLane(lane);
	} 

	void SetLane(int l) {
		lane = l;
	}
}
