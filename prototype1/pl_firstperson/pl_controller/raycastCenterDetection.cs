using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerRaycastInteractStatus : MonoBehaviour {
	int layerMaskInteractable = 1 << 7;
	const float InteractRange = 3f;

	[Header("Detection Check")]
	public bool isInteractable;
	public GameObject lastHitObject;

  void FixedUpdate() {
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit, InteractRange, layerMaskInteractable)) {
			isInteractable = true;
			lastHitObject = hit.transform.gameObject;
		} else {
			isInteractable = false;
		}
  }
}
