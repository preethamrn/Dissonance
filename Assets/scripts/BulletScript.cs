using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

    float moveLength;
   // bool enemyShot = false;
    // Use this for initialization
    void Start()
    {
        moveLength = Screen.currentResolution.height /7;
    }

    // Update is called once per frame
    //do nothing unless triggered by the game controller
    void Update()
    {
       
    }
        //maybe send message that a person won
    
        //if leaves the screen kill, else move
    public void move()
      {
       
        Vector3 position = this.transform.position;
        if (position.y == Screen.currentResolution.height) 
            Destroy(gameObject);
        position.y += moveLength;
        this.transform.position = position;
      }
 }
