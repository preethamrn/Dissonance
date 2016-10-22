using UnityEngine;
using System.Collections;

public class Who : MonoBehaviour {

	GameObject me;
	GameObject notme;

	public void SetMe(GameObject go) {
		me = go;
		Debug.Log("Set Me!");
	}

	public void SetNotMe(GameObject go) {
		notme = go;
		Debug.Log("Set Not Me!");
	}

	public GameObject GetMe() {
		return me;
	}

	public GameObject GetNotMe() {
		return notme;
	}
}
