using UnityEngine;
using System.Collections;

public class BeatController: MonoBehaviour {

	const float BPM = 120f;

	float beatCooldown = 60 / BPM;
	float beatCooldownLeft = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		beatCooldownLeft -= Time.deltaTime;
		if(beatCooldownLeft <= 0) {

			// Do all on Beat tasks
			

			

			Debug.Log("on beat");
			beatCooldownLeft = beatCooldown;
		}
	}
}
