using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

 
   // bool enemyShot = false;
    // Use this for initialization
    void Start(uint lane, uint typeOfBullet)
    {
        //find out whether to make bullet, enemy bullet, or powerup
        switch(typeOfBullet)
        {
            case 1:

                break;
            default:
                Debug.Log("ERROR, Not a valid type for bullet!")
                break;
        }
        if (lane > 4)
            Debug.Log("ERROR! Lane specified for bullet creation not valid");
        //this.transform.position.x = (lane*spacebetween) + intialOffset;
       
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
