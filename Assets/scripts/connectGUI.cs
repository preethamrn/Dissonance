using UnityEngine;
using System.Collections;

public class connectGUI : MonoBehaviour {

    public Texture connectTexture;

	void OnGUI()
    {

        //display background
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), connectTexture);

    }
}
