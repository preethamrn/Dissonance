using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {

    int lane = 2;
    //BulletScript bulletScript;
    GameObject player;

	// Use this for initialization
	void Start () {
        //bulletScript = FindObjectOfType<BulletScript>();
        GameObject playerPrefab = (GameObject)Resources.Load("Player");
        player = Instantiate(playerPrefab);
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void move(int newLane) {
        if (newLane > lane) lane++;
        else if (newLane < lane) lane--;

        //bulletScript.createBullet(newLane);

        player.transform.position = new Vector2((float)18 / 5 * (float)(lane + 0.5) - 9, -14);
    }
}
