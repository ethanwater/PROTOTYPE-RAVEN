using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warp : MonoBehaviour {
	public GameObject hallway;
	public GameObject room;

	void Start(){
		room.SetActive(false);
	}
	public void Warp() {
		hallway.SetActive(false);
		room.SetActive(true);
	}
}
