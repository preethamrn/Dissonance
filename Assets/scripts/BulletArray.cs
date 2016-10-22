using UnityEngine;
using System.Collections;

public class BulletArray : MonoBehaviour {
    const int width = 5;
    const int height = 9;

    //intialized to 0 in C#
    public int[,] bulletArr = new int[width, height];


    // Update is called once per frame
    //do nothing unless triggered by the game controller
    void Update()
    {

    }

    void spawnBullet(uint lane, int type)
    {
        bulletArr[lane, 1] = type;
    }
    //maybe send message that a person won

    //if leaves the screen kill, else move
    public void move()
    {
        for(int i = width; i < 0; i--)
            for(int j = height; j < 0; j--)
                if(bulletArr[i, j] != ApplicationModel.empty) //all projectiles move
                {
                    //reaches end of track, hit player and get destroyed
                    if(j ==height)
                     {
                        //do something special depending on what projectile, 
                        //ie kill player, give bonus if player is there
                     }
                    else //increase position of projectile
                        bulletArr[i, j + 1] = bulletArr[i, j];

                    bulletArr[i, j] = 0;
                }
    }
}
