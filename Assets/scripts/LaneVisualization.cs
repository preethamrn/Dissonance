using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[RequireComponent (typeof(AudioListener))]
public class LaneVisualization : MonoBehaviour {

	//List<GameObject> lanes;
	GameObject[] lanes;
	//public void AddLane(GameObject lane) {
	//	lanes.Add(lane);
	//}
	//HingeJoint[] hinges = FindObjectsOfType(typeof(HingeJoint)) as HingeJoint[];
	void Start() {
		lanes = GameObject.FindGameObjectsWithTag("Lane");
	}

	void Update() {
		Visualization();
	}

	void Visualization() {
		float[] musicData = new float[1024];
		AudioListener.GetSpectrumData(musicData, 0, FFTWindow.Triangle);
		//float[] volumeData = new float[1024];
		//AudioListener.GetOutputData(volumeData, 0);
		float[] sums = new float[5];
		for (int i = 0; i < 40; i++) {
			sums[0] += musicData[i];
		}
		for (int i = 40; i < 150; i++) {
			sums[1] += musicData[i];
		}
		for (int i = 150; i < 250; i++) {
			sums[2] += musicData[i];
		}
		for (int i = 250; i < 400; i++) {
			sums[3] += musicData[i];
		}
		for (int i = 400; i < 1024; i++) {
			sums[4] += musicData[i];
		}

		for (int i = 0; i < 5; i++) {
			Debug.Log("SumData: " + i + " : " + sums[i] * 1000);
			lanes[i].GetComponent<SpriteRenderer>().color = HSVtoRGB (sums [i] * 1, 1, 1, 1);
		}
	}

	public static Color HSVtoRGB (float hue, float saturation, float value, float alpha)
		{
				while (hue > 1f) {
						hue -= 1f;
				}
				while (hue < 0f) {
						hue += 1f;
				}
				while (saturation > 1f) {
						saturation -= 1f;
				}
				while (saturation < 0f) {
						saturation += 1f;
				}
				while (value > 1f) {
						value -= 1f;
				}
				while (value < 0f) {
						value += 1f;
				}
				if (hue > 0.999f) {
						hue = 0.999f;
				}
				if (hue < 0.001f) {
						hue = 0.001f;
				}
				if (saturation > 0.999f) {
						saturation = 0.999f;
				}
				if (saturation < 0.001f) {
						return new Color (value * 255f, value * 255f, value * 255f);

				}
				if (value > 0.999f) {
						value = 0.999f;
				}
				if (value < 0.001f) {
						value = 0.001f;
				}
		
				float h6 = hue * 6f;
				if (h6 == 6f) {
						h6 = 0f;
				}
				int ihue = (int)(h6);
				float p = value * (1f - saturation);
				float q = value * (1f - (saturation * (h6 - (float)ihue)));
				float t = value * (1f - (saturation * (1f - (h6 - (float)ihue))));
				switch (ihue) {
				case 0:
						return new Color (value, t, p, alpha);
				case 1:
						return new Color (q, value, p, alpha);
				case 2:
						return new Color (p, value, t, alpha);
				case 3:
						return new Color (p, q, value, alpha);
				case 4:
						return new Color (t, p, value, alpha);
				default:
						return new Color (value, p, q, alpha);
				}
		}
}

/*
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class BarVisulization : MonoBehaviour
{
		public AudioClip[] clips;
		public SpriteRenderer[] barsSprites;
		public Slider musicSlider;
		[Range(0,10)]
		public float
				colorMultiplyer = 1;
		[Range(0,1)]	
		public float
				s = 1;
		[Range(0,1)]
		public float
				v = 1;
		private int index = 0;
		private float musicLength;
	
		void Update ()
		{
				Visulization ();
				if (Input.GetMouseButtonDown (0)) {
						ChangeSound ();
				}
		MusicSlider();
		}

		void Visulization ()
		{
				float[] musicData = audio.GetSpectrumData (64, 0, FFTWindow.Triangle);
				int i = 0;
				while (i<44) {
						barsSprites [i].transform.localScale = new Vector3 (musicData [i], 0.2f, 1);
						barsSprites [i].color = HSVtoRGB (musicData [i] * colorMultiplyer, s, v, 1);
					
						i++;
				}
				
		}

		void MusicSlider ()
		{
				musicLength = audio.time;
				Debug.Log(musicLength);
		musicSlider.value = musicLength/audio.clip.length;

		}

		void ChangeSound ()
		{
				index++;
				if (index > clips.Length - 1) {
						index = 0;
				}
				print (index);
				audio.clip = clips [index];	
				
				audio.Play ();
		}


	#region Static
		public static Color HSVtoRGB (float hue, float saturation, float value, float alpha)
		{
				while (hue > 1f) {
						hue -= 1f;
				}
				while (hue < 0f) {
						hue += 1f;
				}
				while (saturation > 1f) {
						saturation -= 1f;
				}
				while (saturation < 0f) {
						saturation += 1f;
				}
				while (value > 1f) {
						value -= 1f;
				}
				while (value < 0f) {
						value += 1f;
				}
				if (hue > 0.999f) {
						hue = 0.999f;
				}
				if (hue < 0.001f) {
						hue = 0.001f;
				}
				if (saturation > 0.999f) {
						saturation = 0.999f;
				}
				if (saturation < 0.001f) {
						return new Color (value * 255f, value * 255f, value * 255f);

				}
				if (value > 0.999f) {
						value = 0.999f;
				}
				if (value < 0.001f) {
						value = 0.001f;
				}
		
				float h6 = hue * 6f;
				if (h6 == 6f) {
						h6 = 0f;
				}
				int ihue = (int)(h6);
				float p = value * (1f - saturation);
				float q = value * (1f - (saturation * (h6 - (float)ihue)));
				float t = value * (1f - (saturation * (1f - (h6 - (float)ihue))));
				switch (ihue) {
				case 0:
						return new Color (value, t, p, alpha);
				case 1:
						return new Color (q, value, p, alpha);
				case 2:
						return new Color (p, value, t, alpha);
				case 3:
						return new Color (p, q, value, alpha);
				case 4:
						return new Color (t, p, value, alpha);
				default:
						return new Color (value, p, q, alpha);
				}
		}
	#endregion
}

*/