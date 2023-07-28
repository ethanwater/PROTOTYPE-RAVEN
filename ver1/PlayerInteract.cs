using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInteract : MonoBehaviour
{
	float interactRange = 3f;

  void Update() {
		if (Input.GetKeyDown(KeyCode.E)){
  		Collider[] colliderArr = Physics.OverlapSphere(transform.position, interactRange);
			foreach (Collider collider in colliderArr){
				if (collider.TryGetComponent(out npcInteractable npcInteract)) {
					npcInteract.Interact();
				} else if (collider.TryGetComponent(out obtain itemObtainable)) {
					itemObtainable.Obtain();
				}
			}
		}
  }
}
