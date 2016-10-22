﻿using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {

    int lane = 2;
    ProjectileScript projectileScript;
    GameObject player;

	// Use this for initialization
	void Start () {
        projectileScript = FindObjectOfType<ProjectileScript>();
        GameObject playerPrefab = (GameObject)Resources.Load("Player");
        player = Instantiate(playerPrefab);
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void move(int newLane) {
        if (newLane > lane) lane++;
        else if (newLane < lane) lane--;
        
        player.transform.position = new Vector2(ApplicationModel.xRatio * 2 / 5 * (float)(lane + 0.5) - ApplicationModel.xRatio, -14); //move player
        this.animate();
    }

    public void animate() {
        player.GetComponent<Animator>().SetTrigger("pulse");
    }
}
