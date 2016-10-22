using UnityEngine;
using System.Collections;

public class LaneClick : MonoBehaviour {

    BeatController beatController;

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
            //Debug.Log(touch);
            int lane = (int)(touch.x / (ApplicationModel.screenSizeX / 5.0));
            //Instantiate(go, new Vector3(18*touch.x/screenSizeX-9, 32*touch.y/screenSizeY-16, 0), Quaternion.identity);
            //Debug.Log("Hit Lane" + lane);
            beatController.input(lane);
        }

        /*Touch[] touches = Input.touches;
        if (touches.Length > 0) {
            Touch touch = touches[0];
            int lane = (int)touch.position.x / (screenSizeX / 5);
            //Instantiate(go, new Vector3(18*touch.position.x/screenSizeX-9, 32*touch.position.y/screenSizeY-16, 0), Quaternion.identity);
            Debug.Log("Hit Lane" + lane);
            beatController.input(lane);
        }*/
    }
}
