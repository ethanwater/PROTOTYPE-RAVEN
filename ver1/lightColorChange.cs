using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightColorChange : MonoBehaviour {
	Light lt;
	public float duration = 2.0f;
	

	void FadeOut() {
		lt.color -= (Color.white / duration) * Time.deltaTime;
	}

	void Interpolate() {
		float t = Mathf.PingPong(Time.time, duration) / duration;
		//Declaration:public static float PingPong(float t, float length);
		//Description: PingPong returns a value that will increment and decrement 
		//between the value 0 and length. PingPong requires the value t to be a 
		//self-incrementing value, for example Time.time, and Time.unscaledTime.

    lt.color = Color.Lerp(Color.white, Color.black, t);
		//Declaration: public static Color Lerp(Color a, Color b, float t);
		//Description: Linearly interpolates between colors a and b by t.
		//t is clamped between 0 and 1. When t is 0 returns a. When t is 1 returns b.
	}

	void SetRange(float newRange) {
		lt.range = newRange;
	}

  void Start() {
  	lt = GetComponent<Light>();
  }

  void Update(){
		Interpolate();
  }
}
