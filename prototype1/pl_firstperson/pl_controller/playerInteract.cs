using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInteract : MonoBehaviour
{
  void Update() {
		gameObject.TryGetComponent(out playerRaycastInteractStatus status);
		if (status.isInteractable == true) {
			Destroy(status.lastHitObject);
		}
  }
}
