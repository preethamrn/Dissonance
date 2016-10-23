using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class LaneClick : MonoBehaviour {

    BeatController beatController;
    bool gameOver = false;

    // Use this for initialization
    void Start () {
        
        beatController = FindObjectOfType<BeatController>();
        ApplicationModel.screenSizeX = Screen.width;
        ApplicationModel.screenSizeY = Screen.height;
        ApplicationModel.yRatio = 16;
        ApplicationModel.xRatio = (float) ApplicationModel.screenSizeX / (float) ApplicationModel.screenSizeY * (float) ApplicationModel.yRatio;
        //Debug.Log(ApplicationModel.screenSizeX.ToString() + " " + ApplicationModel.screenSizeY.ToString());
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            Vector2 touch = Input.mousePosition;
            int lane = (int)(touch.x / (ApplicationModel.screenSizeX / 5.0));
            Debug.Log("Hit Lane" + lane);
            if (!gameOver) beatController.input(lane);
            else {
                Invoke("endGame", 3);
            }
        }

        /*Touch[] touches = Input.touches;
        if (touches.Length > 0) {
            Touch touch = touches[0];
            int lane = (int)touch.position.x / (screenSizeX / 5);
            Debug.Log("Hit Lane" + lane);
            beatController.input(lane);
        }*/
    }

    public void setGameOver() { gameOver = true; }
    void endGame() {
        NetworkServer.DisconnectAll();
        Application.LoadLevel("connect");
    }
}
