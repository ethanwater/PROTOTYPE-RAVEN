using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTalk : MonoBehaviour {
	//float talkRange = 3f;
	int layerMaskNPC = 1 << 7;
	int layerMaskItem = 1 << 8;
	const float InteractRange = 3f;

	[Header("Detection Check")]
	public bool isNPC;
	public bool isItem;
	

  void FixedUpdate() {
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit, InteractRange, layerMaskNPC)) {
			isInteractableNPC = true;
			Debug.Log("npc");
		} else {
			isNPC = false;
		}
		if (Physics.Raycast(ray, out hit, InteractRange, layerMaskItem)) {
			isInteractableItem = true;
			Debug.Log("item");
		} else {
			isItem = false;
		}
    //if (Input.GetKeyDown(KeyCode.E)){
  	//	Collider[] colliderArr = Physics.OverlapSphere(transform.position, talkRange);
		//	foreach (Collider collider in colliderArr){
		//		if (collider.TryGetComponent(out npcInteractable npcInteract)) {
		//			
		//		} 			
		//	}
		//}   
  }
}
