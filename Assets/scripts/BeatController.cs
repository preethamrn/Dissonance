using UnityEngine;
using System.Collections;

public class BeatController : MonoBehaviour {

	PlayerControls player;
    ProjectileScript projectileScript;
    GameObject playerBullet;

	const float BPM = 120f;
	const float beatCooldown = 60 / BPM;
	const float buffer = 0.15f;
	const int beatDelay = 10;

	float beatCooldownLeft;

	int laneToMove;
	int beat;

	bool illegalMove;
	bool recievedInput;
	bool playerMoved;
	bool playerFault;

	

	void Start () {

		player = FindObjectOfType<PlayerControls>();
        projectileScript = FindObjectOfType<ProjectileScript>();
        playerBullet = (GameObject)Resources.Load("Bullet");

        beatCooldownLeft = 0f;
        laneToMove = 2;
		beat = 0;

		reset();

	}
	
	// Update is called once per frame
	void Update () {

		beatCooldownLeft -= Time.deltaTime;

		if (beat < beatDelay && beatCooldownLeft <= 0) {
			beatCooldownLeft = beatCooldown;
			beat++;
			Debug.Log("Delay");
		}

		else if (beat >= beatDelay) {
			if (!playerFault && illegalMove) {
				// the player lost
				Debug.Log("Player lost due to clicking out of buffer!");
				playerFault = true;
			}

			else if (recievedInput && !playerMoved) {
				player.move(laneToMove);
				playerMoved = true;
			}
 
			if (beatCooldownLeft + buffer <= 0) {
				if (!playerFault && !recievedInput) {
					// the player lost
					Debug.Log("Illegal Move");
					playerFault = true;
				}

				else if (playerMoved) {
					projectileScript.addProjectile(1, laneToMove, Instantiate(playerBullet));
				}

				Debug.Log("Beat");

                projectileScript.move();
                

                beatCooldownLeft = beatCooldown - buffer;
                reset();
				beat++;
			}
		}
	}

	public void input(int lane) {

		if ((beatCooldownLeft <= (2 * buffer)) && !playerMoved) {
			laneToMove = lane;
		}

		else {
			illegalMove = true;
		}

		recievedInput = true;
	}

	void reset() {
		recievedInput = false;
    	playerMoved = false;
    	playerFault = false;
    	illegalMove = false;

	}
}
