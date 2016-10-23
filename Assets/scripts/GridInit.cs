using UnityEngine;
using System.Collections;

public class GridInit : MonoBehaviour {
    
    // Use this for initialization
    void Start() {
        GameObject lane = (GameObject) Resources.Load("Lane");
        GameObject wave = (GameObject) Resources.Load("Wave");
        for (int i = 0; i < 5; i++) {
            //Debug.Log(ApplicationModel.xRatio * 2 / 5 * (float)(i + 0.5) - ApplicationModel.xRatio);
            Instantiate(lane, new Vector3(ApplicationModel.xRatio * 2 / 5 * (float)(i + 0.5) - ApplicationModel.xRatio, 0, 0), Quaternion.identity);
            Instantiate(wave, new Vector3(ApplicationModel.xRatio * 2 / 5 * (float)(i + 0.5) - ApplicationModel.xRatio, 0, 0), Quaternion.identity);
            //gameObject.GetComponent<LaneVisualization>().AddLane(lane);
        }

    }
}
