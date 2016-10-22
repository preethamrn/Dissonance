using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {
    public bool alive = true;
    public bool isEnemy = true;
   
	// Use this for initialization
    

    public void kill()
    {
        alive = false;
        Destroy(gameObject);
    }
	
	
	// Update is called once per frame
	void Update () {
	
	}
}
