using UnityEngine;
using System.Collections;

public class EnemyControls : MonoBehaviour {

    int lane = 2;
    GameObject player;
    GameObject enemyBullet;
    ProjectileScript projectileScript;

    // Use this for initialization
    void Start() {
        GameObject playerPrefab = (GameObject)Resources.Load("Player");
        enemyBullet = (GameObject)Resources.Load("Bullet");
        projectileScript = FindObjectOfType<ProjectileScript>();
        player = Instantiate(playerPrefab);
        player.transform.position = new Vector2(ApplicationModel.xRatio * 2 / 5 * (float)(2.5) - ApplicationModel.xRatio, 14);
    }

    // Update is called once per frame
    void Update() {

    }

    public void move(int newLane) {
        if (newLane > lane) lane++;
        else if (newLane < lane) lane--;

        player.transform.position = new Vector2(ApplicationModel.xRatio * 2 / 5 * (float)(lane + 0.5) - ApplicationModel.xRatio, 14); //move player
        projectileScript.addProjectile(2, lane, Instantiate(enemyBullet));
    }

    public void animate() {
        player.GetComponent<Animator>().SetTrigger("pulse");
    }
}
