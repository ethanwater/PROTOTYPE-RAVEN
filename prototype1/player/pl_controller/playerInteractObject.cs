using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInteractObject : MonoBehaviour
{
	private GameObject hitObject;
	
	private void Obtain(GameObject item){
		item.SetActive(false);
	}
	//private void Drop(GameObject item){
	//	Vector3 playerPosition = transform.position;
	//	item.transform.position = playerPosition;
	//	item.SetActive(true);
	//}

  void Update() {
		gameObject.TryGetComponent(out playerRaycastInteractStatus status);
		hitObject = status.hitObject;

		if(Input.GetKeyDown("e") && hitObject.tag == "Item" && status.isInteractable == true) {
			Obtain(hitObject);
		} 	

	 	//if(Input.GetKey("g")) {
		//	Drop(hitObject);
		//}
	}
}
