using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

	public AudioSource song;
	// Use this for initialization
	void Start () {
		song = gameObject.GetComponent<AudioSource>();
		song.Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
