using UnityEngine;
using System.Collections;

public class DontDestroyOnLoadScript : MonoBehaviour {

	// Use this for initialization
	void Awake() {
		DontDestroyOnLoad(gameObject);
	}
	
}
