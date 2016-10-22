using UnityEngine;
using System.Collections;

public class b_controller : MonoBehaviour {

    int screenSize;

    // Use this for initialization
    void Start () {
        screenSize = Screen.currentResolution.width;
	}
	
	// Update is called once per frame
	void Update () {
        Touch[] touches = Input.touches;
        if (touches.Length > 0) {
            Touch touch = touches[0];
            int lane = (int)touch.position.x / (screenSize / 5);
            Debug.Log("Hit Lane" + lane);
        }
    }
}
