using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTalk : MonoBehaviour {
	int layerMask = 1 << 7; //if raycast detects layer7 (NPC)

  void FixedUpdate() {
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask)) {
			Debug.Log("hit");
		} else {
			Debug.Log("not hit");
		}
  }
}
