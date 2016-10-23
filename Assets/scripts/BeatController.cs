using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BeatController : MonoBehaviour {

    PlayerControls player;
    EnemyControls enemy;
    ProjectileScript projectileScript;
    Text countdown;
    public Camera mainCamera;

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

    bool go = false;

	void Start () {

        player = FindObjectOfType<PlayerControls>();
        enemy = FindObjectOfType<EnemyControls>();
        projectileScript = FindObjectOfType<ProjectileScript>();
        countdown = FindObjectOfType<Text>();

        beatCooldownLeft = 0f;
        laneToMove = 2;
		beat = 0;

		totalTime = 0f;

        mainCamera.gameObject.GetComponent<AudioSource>().Pause();

		reset();

        //Debug.Log("Trying to complete stage 1");
        PlayerInitiateConnection pic = FindObjectOfType<PlayerInitiateConnection>();
        Debug.Log("Trying to complete stage 1");
        pic.CompleteStage1();

	}

    public void Go() {
        go = true;
        mainCamera.gameObject.GetComponent<AudioSource>().Play();
    }

	// Update is called once per frame
	void Update () {

        if (!go) {
            return;
        }

		beatCooldownLeft -= Time.deltaTime;
		totalTime += Time.deltaTime;

		if (beat < beatDelay && beatCooldownLeft + buffer <= 0) {
			beatCooldownLeft = (beat * beatCooldown) - totalTime;
			beat++;

            //UI stuff for countdown
            countdown.text = (beatDelay - beat).ToString();
            if (beat == beatDelay) {
                countdown.text = "";
            }

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

                bool playerCol = projectileScript.collisions(player.getLane(), 0, 2);
                bool enemyCol = projectileScript.collisions(enemy.getLane(), ApplicationModel.height - 1, 1);
                if (playerCol && enemyCol) {
                    Debug.Log("DRAW");
                    FindObjectOfType<Text>().text = "DRAW";
                    FindObjectOfType<LaneClick>().setGameOver();
                } else if (playerCol) {
                    Debug.Log("YOU LOSE");
                    FindObjectOfType<Text>().text = "YOU LOSE";
                    FindObjectOfType<SyncClient>().MeGameOver();
                    FindObjectOfType<LaneClick>().setGameOver();
                }
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
