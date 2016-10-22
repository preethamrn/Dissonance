using UnityEngine;
using System.Collections;
using UnityEditor.SceneManagement;

public class mainMenu : MonoBehaviour {

    public Texture menuTexture;

    


    void OnGUI()
    {
       
        //display background
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), menuTexture);

        //make 4 buttons
        //if play connect

        if(GUI.Button(new Rect(Screen.width * .1f, Screen.height *.4f, Screen.width * .37f, 
            Screen.height * .25f *(9f/16f)), "Play"))
        {
            Debug.Log("Play Pressed");
            //unsure exacltly what the difference between editorSceneManager and sceneManger is
            UnityEditor.SceneManagement.EditorSceneManager.LoadScene("current");
        }

        //DLC!!!
        if(GUI.Button(new Rect(Screen.width * .1f + Screen.width*.42f, Screen.height * .4f, Screen.width * .37f ,
            Screen.height * .25f * (9f / 16f)), "$3.99 DLC"))
        {
            Debug.Log("DLC Pressed");
        }

        //Options
        if(GUI.Button(new Rect(Screen.width * .1f, Screen.height * .57f  , Screen.width * .37f,
            Screen.height * .25f * (9f / 16f)), "Options"))
        {
            Debug.Log("Options Pressed");
        }

        if(GUI.Button(new Rect(Screen.width * .1f + Screen.width * .42f, Screen.height * .57f, Screen.width * .37f,
           Screen.height * .25f * (9f / 16f)), "Credits"))
        {
            Debug.Log("Credits Pressed");
        }

    }
}
