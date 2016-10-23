using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerInitiateConnection : NetworkBehaviour {

	private bool nextScene = false;

	private bool hostStage1 = false;
	private bool clientStage1 = false;

	//private bool hostStage2 = false;
	//private bool clientStage2 = false;

	private bool stage2begun = false;

	private bool pingOn = false;
	private int ping = -1;

	[ServerCallback]
	void Update() {
		if (!nextScene) {
			nextSceneWork();
			 return; //Wait for next scene to go
		}

		Debug.Log("Right before stage 1 done");
		if (!hostStage1 || !clientStage1) return; //wait for stage 1 to be done on both clients
		Debug.Log("Right after stage 1 done");

		if (!stage2begun) {
			GetPing();
			Debug.Log("Got to Stage 2");
			stage2begun = true;
		}

		if (ping >= 0.0f) {
			RpcTellClientToGo();
			StartCoroutine(ServerGo());
		}

	}

	IEnumerator ServerGo() {
		yield return new WaitForSeconds(ping / 1000.0f);
		BeatController bc = FindObjectOfType<BeatController>();
		bc.Go();
		Done();
	}

	[ServerCallback]
	void nextSceneWork() {
		if (!nextScene && NetworkServer.connections.Count >= 2) {
				nextScene = true;
    	    	Debug.Log("Two Players have connected");
    	    	
    	    	NetworkManager nm = FindObjectOfType<NetworkManager>();
    	    	//Debug.Log("1");
    	    	RpcConfirmNextScene();
    	    	//Debug.Log("2");
    	    	nm.ServerChangeScene("game");
    	    	//Debug.Log("3");
    	    }
	}

	void Done() {
		Debug.Log("Done!");
		Destroy(this);
	}

	[ClientRpc]
	void RpcConfirmNextScene() {
		ConfirmNextScene();
	}

	void ConfirmNextScene() {
		nextScene = true;
	}

	public void CompleteStage1() { //called when BeatController is loaded
		OnServerStage1();
		OnClientStage1();
		Debug.Log("Calling appropriate function");
	}

	[ServerCallback]
	void OnServerStage1() {
		hostStage1 = true; //server lets itself know its stage 1
		Debug.Log("Server done!");
		RpcStage1();	//server lets client know its stage 1
	}

	[ClientCallback]
	void OnClientStage1() {
		clientStage1 = true; //client lets itself know its stage 1
		CmdStage1(); //client lets server know its stage 1
	}

	[ClientRpc]
	void RpcStage1() { //
		hostStage1 = true;
	}

	[Command]
	void CmdStage1() {
		Debug.Log("Client done!");
		clientStage1 = true;
	}

	[ServerCallback]
	void GetPing() {
		Debug.Log("Getting Ping");
		/*
		float pingSum = 0;
		for (int i = 0; i < 4; i ++) {
			if (pingOn == false) {
				pingOn = true;
				RpcAskForResponse();
				while (pingOn) {
					pingSum += Time.deltaTime;
					Debug.Log("PingSum:" + i + " : " + pingSum);
				}
			}
		}
		ping = pingSum / 4.0f / 2.0f;
		*/
		//ping = NetworkServer.connections[1].GetRTT() / 2;
		ping = 50;
	}

	[ClientRpc]
	void RpcAskForResponse() {
		CmdReturnResponse();
	}

	[Command]
	void CmdReturnResponse() {
		pingOn = false;
	}

	[ClientRpc]
	void RpcTellClientToGo() {
		Debug.Log("Client Doing GO");
		BeatController bc = FindObjectOfType<BeatController>();
		bc.Go();
		Done();
	}
}
