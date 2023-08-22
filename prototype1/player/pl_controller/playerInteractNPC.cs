using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInteractNPC : MonoBehaviour
{
	private GameObject hitObject;

  void Update() {
		gameObject.TryGetComponent(out playerRaycastInteractStatus status);
		if (status.hitObject != null){
			hitObject = status.hitObject;
		}

		if(Input.GetKeyDown("e") && hitObject.tag == "NPC" && status.isInteractable == true) {
			hitObject.TryGetComponent(out npcDialogue chat);
			chat.Chat();
		} 	
	}
}

