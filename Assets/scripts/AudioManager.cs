using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

	public AudioSource theme;
    public AudioSource[] songs;

   // public enum { }

	// Use this for initialization
	void Start () {
        songs = GetComponents<AudioSource>();
        
        theme = songs[0];
		theme.Play();
        

	}
	
	// Update is called once per frame
	void Update () {}

    void Halt()
    {
        theme.Stop();
    }

    public void gameStart(int n)
    {
        Halt();
        songs[n].Play();
    }
}
