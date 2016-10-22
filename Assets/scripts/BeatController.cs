using UnityEngine;
using System.Collections;

public class BeatController : MonoBehaviour {

	PlayerControls player;

	const float BPM = 120f;
	const float beatCooldown = 60 / BPM;
	const float buffer = 0.1f;


	float beatCooldownLeft;
	float playerMovedCD;

	int laneToMove;
	int beat;
	int beatDelay;

	bool playerDied;

	// MUSICAL BEATS OCCUR EVERY BEAT - (BUFFER / 2) 

	// Use this for initialization
	void Start () {

		player = FindObjectOfType<PlayerControls>();
		beatCooldownLeft = buffer;
		playerMovedCD = 0f;
		beat = 0;
		beatDelay = 10;
		playerDied = false;

	}
	
	// Update is called once per frame
	void Update () {

		beatCooldownLeft -= Time.deltaTime;
		playerMovedCD -= Time.deltaTime;

		if (beat < beatDelay && beatCooldownLeft <= 0) {
			beatCooldownLeft = beatCooldown;
			beat++;
			Debug.Log("Delay");
		}

		else if (beat >= beatDelay) {

			if (playerDied == false && playerMovedCD >= buffer) {
				// the player lost
				Debug.Log("Player lost due to clicking too early!");
				playerDied = true;
			}

			else if (beatCooldownLeft <= 0) {

				if (playerMovedCD < 0 - beatCooldown) {
					// the player lost
					Debug.Log("Player Lost due to not clicking!");
				}

				Debug.Log("On Beat");

				// MOVE ALL OBJECTS

				player.move(laneToMove);
				



				beatCooldownLeft = beatCooldown;
				beat++;
				playerDied = false;
			}
		}
	}

	public void input(int lane) {

		if (playerMovedCD <= 0) {
			laneToMove = lane;
			playerMovedCD = beatCooldownLeft;
		}
	}


}
