using UnityEngine;
using System.Collections;

public class ObjectArray : MonoBehaviour {

    public class BulletArray : MonoBehaviour
    {
        const int width = 5;
        const int height = 9;

        //intialized to 0 in C#
        public int[,] array = new int[width, height];


        // Update is called once per frame
        void Update()
        {

        }
    }

}
