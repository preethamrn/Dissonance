using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BeatController : MonoBehaviour {

	PlayerControls player;
    ProjectileScript projectileScript;
    GameObject playerBullet;

	const float BPM = 110f;
	const float beatCooldown = 60 / BPM;
	const float buffer = 0.15f;
	const int beatDelay = 10;

	float beatCooldownLeft;

	int laneToMove;
	int beat;

	bool illegalMove;
	bool recievedInput;
	bool playerMoved;


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

            //UI stuff for countdown
            Text countdown = FindObjectOfType<Text>();
            countdown.text = (beatDelay - beat).ToString();
            if (beat == beatDelay) Destroy(countdown);

			Debug.Log("Delay");
			player.animate();
		}

		else if (beat >= beatDelay) {
			if (illegalMove) {
				// the player lost
				Debug.Log("Illegal Move");
			}

			else if (recievedInput && !playerMoved) {
				player.move(laneToMove);
				playerMoved = true;
			}
 
			if (beatCooldownLeft + buffer <= 0) {
                if (!recievedInput) {
                    // the player lost
                    Debug.Log("No Move");
                } else if (illegalMove) ;
                else if (playerMoved) {
                    projectileScript.addProjectile(1, laneToMove, Instantiate(playerBullet));
                }

				Debug.Log("Beat");

                projectileScript.move();
             	player.animate();

                beatCooldownLeft = beatCooldown - buffer;
                reset();
				beat++;
			}
		}
	}

	public void input(int lane) {

		if ((beatCooldownLeft <= (2 * buffer)) && !playerMoved) {
			laneToMove = lane;
		} else {
			illegalMove = true;
		}

		recievedInput = true;
	}

	void reset() {
		recievedInput = false;
    	playerMoved = false;
    	illegalMove = false;

	}
}
