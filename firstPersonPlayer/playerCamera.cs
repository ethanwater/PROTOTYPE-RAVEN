using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstpersonCam : MonoBehaviour
{
	public float xSensitivity;
	public float ySensitivity;
	float xRotation;
	float yRotation;

	public Transform orientation;

  private void Start() {
 		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;

  }

  private void Update() {
  	float xMouse = Input.GetAxisRaw("Mouse X") * Time.deltaTime * xSensitivity; 
  	float yMouse = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * ySensitivity; 

		yRotation += xMouse;
		xRotation -= yMouse;
		xRotation = Mathf.Clamp(xRotation, -90f, 90f);

		transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
		orientation.rotation = Quaternion.Euler(0, yRotation, 0);
  }
}
