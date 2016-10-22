using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {

    int lane = 2;
    GameObject player;

	// Use this for initialization
	void Start () {
        GameObject playerPrefab = (GameObject)Resources.Load("Player");
        player = Instantiate(playerPrefab);
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void move(int newLane) {
        if (newLane > lane) lane++;
        else if (newLane < lane) lane--;

        FindObjectOfType<SyncClient>().MeChangedLane(lane); //move player on enemy screen

        player.transform.position = new Vector2(ApplicationModel.xRatio * 2 / 5 * (float)(lane + 0.5) - ApplicationModel.xRatio, -14); //move player
    }

    public void animate() {
        player.GetComponent<Animator>().SetTrigger("pulse");
    }
}
