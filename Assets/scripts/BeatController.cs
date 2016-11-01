using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BeatController : MonoBehaviour {

    PlayerControls player;
    EnemyControls enemy;
    ProjectileScript projectileScript;
    Text countdown;

    public float BPM = 107f;
	float beatCooldown = 0;
	const float buffer = 0.2f;
	const int beatDelay = 16;

	float beatCooldownLeft;
	float totalTime;

	int laneToMove0;
    int laneToMove1;
	int beat;

	bool illegalMove0;
    bool illegalMove1;
	bool recievedInput0;
    bool recievedInput1;
	bool playerMoved0;
    bool playerMoved1;
    bool animated;


	void Start () {

        player = FindObjectOfType<PlayerControls>();
        enemy = FindObjectOfType<EnemyControls>();
        projectileScript = FindObjectOfType<ProjectileScript>();
        countdown = FindObjectOfType<Text>();

        beatCooldown = 60/BPM;
        beatCooldownLeft = 0f;
        laneToMove0 = 2;
        laneToMove1 = 2;
		beat = 0;

		totalTime = 0f;

		reset();

	}

	// Update is called once per frame
	void Update () {

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

			//Debug.Log("Delay");
            animate();
        }

		else if (beat >= beatDelay) {
			if (illegalMove0) {
				// the player lost
				//Debug.Log("Illegal Move");
			}
			else if (recievedInput0 && !playerMoved0) {
				player.move(laneToMove0);
				playerMoved0 = true;
			}

            if (illegalMove1) {
                // the player lost
                //Debug.Log("Illegal Move");
            }
            else if (recievedInput1 && !playerMoved1) {
                enemy.move(laneToMove1);
                playerMoved1 = true;
            }

            if (!animated && beatCooldownLeft - buffer <= 0) {
                animate();
                animated = true;
            }

			if (beatCooldownLeft + buffer <= 0) {
                if (!recievedInput0) {
                    // the player lost
                    //Debug.Log("No Move");
                } else if (illegalMove0) {};

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
                    //FindObjectOfType<SyncClient>().MeGameOver();
                    FindObjectOfType<LaneClick>().setGameOver();
                } else if (enemyCol) {
                    Debug.Log("YOU WIN");
                    FindObjectOfType<Text>().text = "YOU WIN";
                    FindObjectOfType<LaneClick>().setGameOver();
                }
                beat++;
				beatCooldownLeft = (beat * beatCooldown) - totalTime;
                reset();
			}
		}
	}

	public void input(int lane, int p) {
        //p = 0 is the player, p = 1 is the enemy

        if (p == 0) {
		  if ((beatCooldownLeft <= (2 * buffer)) && !playerMoved0) {
		   	laneToMove0 = lane;
		  } else {
			illegalMove0 = true;
		  }
		    recievedInput0 = true;
        }
        else if (p == 1) {
            if ((beatCooldownLeft <= (2 * buffer)) && !playerMoved1) {
                laneToMove1 = lane;
            } else {
                illegalMove1 = true;
            }
                recievedInput1 = true;
        }
	}

	void reset() {
		recievedInput0 = false;
    	playerMoved0 = false;
    	illegalMove0 = false;
        recievedInput1 = false;
        playerMoved1 = false;
        illegalMove1 = false;

        animated = false;
	}

    void animate() {
        player.animate();
        enemy.animate();
        projectileScript.animate();
    }
}
