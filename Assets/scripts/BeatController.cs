using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BeatController : MonoBehaviour {

    PlayerControls player;
    EnemyControls enemy;
    ProjectileScript projectileScript;
    Text countdown;

    const float BPM = 107f;
	const float beatCooldown = 60 / BPM;
	const float buffer = 0.2f;
	const int beatDelay = 16;

	float beatCooldownLeft;
	float totalTime;

	int laneToMove;

	int beat;

	bool illegalMove;
	bool recievedInput;
	bool playerMoved;
    bool animated;

	void Start () {

        player = FindObjectOfType<PlayerControls>();
        enemy = FindObjectOfType<EnemyControls>();
        projectileScript = FindObjectOfType<ProjectileScript>();
        countdown = FindObjectOfType<Text>();

        beatCooldownLeft = 0f;
        laneToMove = 2;
		beat = 0;

		totalTime = 0f;

		reset();
	}

	// Update is called once per frame
	void Update () {

		beatCooldownLeft -= Time.deltaTime;
		totalTime += Time.deltaTime;

		Debug.Log (countdown.fontSize);

		if (beat < beatDelay && beatCooldownLeft + buffer <= 0) {
			beatCooldownLeft = (beat * beatCooldown) - totalTime;
			beat++;

            //UI stuff for countdown
            countdown.text = (beatDelay - beat).ToString();
            if (beat == beatDelay) Destroy(countdown);

			Debug.Log("Delay");
            animate();
        }

		else if (beat >= beatDelay) {
			if (illegalMove) {
				// the player lost
				//Debug.Log("Illegal Move");
			}

			else if (recievedInput && !playerMoved) {
				player.move(laneToMove);
				playerMoved = true;
			}

            if (!animated && beatCooldownLeft - buffer <= 0) {
                animate();
                animated = true;
            }

			if (beatCooldownLeft + buffer <= 0) {
                if (!recievedInput) {
                    // the player lost
                    //Debug.Log("No Move");
                } else if (illegalMove) ;

				//Debug.Log("Beat");

                projectileScript.move();

				beat++;
				beatCooldownLeft = (beat * beatCooldown) - totalTime;
                reset();
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

        animated = false;
	}

    void animate() {
        player.animate();
        enemy.animate();
        projectileScript.animate();
    }
}
