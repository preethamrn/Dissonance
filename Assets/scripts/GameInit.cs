using UnityEngine;
using System.Collections;

public class GameInit : MonoBehaviour {
    
    // Use this for initialization
    void Start() {
        GameObject lane = (GameObject) Resources.Load("Lane");
        GameObject wave = (GameObject) Resources.Load("Wave");
        for (int i = 0; i < 5; i++) {
            //Debug.Log(ApplicationModel.xRatio * 2 / 5 * (float)(i + 0.5) - ApplicationModel.xRatio);
            Instantiate(lane, new Vector3(ApplicationModel.xRatio * 2 / 5 * (float)(i + 0.5) - ApplicationModel.xRatio, 0, 0), Quaternion.identity);
            Instantiate(wave, new Vector3(ApplicationModel.xRatio * 2 / 5 * (float)(i + 0.5) - ApplicationModel.xRatio, 0, 0), Quaternion.identity);
            //Instantiate(wave, new Vector3(ApplicationModel.xRatio * 2 / 5 * (float)(i + 0.5) - ApplicationModel.xRatio, 0, 0), Quaternion.identity);
            //gameObject.GetComponent<LaneVisualization>().AddLane(lane);
        }

        StartCoroutine(PauseAudio());
        StartCoroutine(WaitForPlayerTwo());
    }

    IEnumerator PauseAudio() {
        yield return new WaitUntil(audioPlaying);
        GetComponent<AudioSource>().Pause();
    }

    IEnumerator WaitForPlayerTwo() {
        yield return new WaitUntil(areTwoPlayers);
        BeatController bc = gameObject.AddComponent<BeatController>();
        bc.BPM = 90;
        GetComponent<AudioSource>().Play();
        Debug.Log("Got player 2. Game starting");
    }

    bool areTwoPlayers() {
        return GameObject.FindGameObjectsWithTag("Player").Length == 2;
    }

    bool audioPlaying() {
        return GetComponent<AudioSource>().isPlaying;
    }
}
