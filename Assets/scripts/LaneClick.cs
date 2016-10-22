using UnityEngine;
using System.Collections;

public class LaneClick : MonoBehaviour {

    int screenSizeX, screenSizeY;
    GameObject go;
    // Use this for initialization
    void Start () {
        /*
        //For Desktop X,Y is switched for getting vector... Don't ask why.
        screenSizeX = Screen.currentResolution.height;
        screenSizeY = Screen.currentResolution.width;
        */
        go = (GameObject)Resources.Load("Lane"); ;

        screenSizeX = Screen.currentResolution.width;
        screenSizeY = Screen.currentResolution.height;
        Debug.Log(screenSizeX.ToString() + " " + screenSizeY.ToString());
    }
	
	// Update is called once per frame
	void Update () {
        /*if (Input.GetMouseButtonDown(0)) {
            Vector2 touch = Input.mousePosition;
            Debug.Log(touch);
            int lane = (int)touch.x / (screenSizeX / 5);
            Instantiate(go, new Vector3(18*touch.x/screenSizeX-9, 32*touch.y/screenSizeY-16, 0), Quaternion.identity);
            Debug.Log("Hit Lane" + lane);
        }*/

        Touch[] touches = Input.touches;
        if (touches.Length > 0) {
            Touch touch = touches[0];
            int lane = (int)touch.position.x / (screenSizeX / 5);
            Instantiate(go, new Vector3(18*touch.position.x/screenSizeX-9, 32*touch.position.y/screenSizeY-16, 0), Quaternion.identity);
            Debug.Log("Hit Lane" + lane);
            
        }
    }
}
