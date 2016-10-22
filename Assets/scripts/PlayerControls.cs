using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {

    int lane=3;
    BulletScript bulletScript;
    GameObject player;

	// Use this for initialization
	void Start () {
        bulletScript = FindObjectOfType<BulletScript>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void move(int newLane) {
        if (newLane > lane) lane++;
        else if (newLane < lane) lane--;

        bulletScript.createBullet(newLane);

        
    }
}
