using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SyncClient : NetworkBehaviour {

    bool me;
    // Use this for initialization
    void Start() {
        Who who = FindObjectOfType<Who>();
        if (isLocalPlayer) {
            me = true;
            who.SetMe(gameObject);
        } else {
            me = false;
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
        if (!me) {
            Debug.Log("Enemy at: " + l.ToString());
            FindObjectOfType<EnemyControls>().move(l);
        }
    }


    //Communicating Game Over from Loser side to Winner
    public void MeGameOver() { CmdGameOver(); }
    [Command]
    void CmdGameOver() { RpcGameOver(); }
    [ClientRpc]
    void RpcGameOver() { GameOver(); }
    void GameOver() {
        if (!me) {
            Debug.Log("WIN!");
            FindObjectOfType<Text>().text = "YOU WIN!";
            FindObjectOfType<LaneClick>().setGameOver();
        }
    }
    
    //Communicating ready state
    public void MeReady() { CmdReady(); }
    [Command]
    void CmdReady() { RpcReady(); }
    [ClientRpc]
    void RpcReady() { Ready(); }
    void Ready() {
        if (!me) {
            FindObjectOfType<LaneClick>().setEnemyReady();
        }
    }
}
