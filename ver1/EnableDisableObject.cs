using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomChange : MonoBehaviour {
	public MeshRenderer state2mesh;
	public BoxCollider state2box;

	void Start(){
		state2mesh = GetComponent<MeshRenderer>();
		state2box = GetComponent<BoxCollider>();
	}

	void Update(){
		if(Input.GetKeyUp(KeyCode.Space))
    {
			state2box.enabled = !state2box.enabled;
			state2mesh.enabled = !state2mesh.enabled;

    }
	}
}
