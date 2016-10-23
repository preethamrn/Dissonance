using UnityEngine;
using System.Collections;

public class DisableAutoRotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Screen.orientation = ScreenOrientation.Portrait;
    }
}
