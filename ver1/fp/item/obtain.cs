using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obtain : MonoBehaviour {
	public void Obtain() {
		Debug.Log("obtained: "+ gameObject.name);
		Destroy(gameObject);
	}
}
