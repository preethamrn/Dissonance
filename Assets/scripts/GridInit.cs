using UnityEngine;
using System.Collections;

public class GridInit : MonoBehaviour {
    
    // Use this for initialization
    void Start() {
        GameObject lane = (GameObject) Resources.Load("Lane");
        for (int i = 0; i < 5; i++) {
            Instantiate(lane, new Vector3((float)18/5 * (float)(i + 0.5) - 9, 0, 0), Quaternion.identity);
        }
    }
}
