using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
	[Header("Movement")]
	public float movementSpeed;
	public float runSpeed;
	public float groundDrag;

	[Header("Ground Check")]
	public float playerHeight;
	public LayerMask defineGround;
	public bool grounded;

	public Transform orientation;
	float horizontalInput;
	float verticalInput;

	Vector3 movementDirection;
	Rigidbody rb;

  private void Start() {
    rb = GetComponent<Rigidbody>();
		rb.freezeRotation = true;
  }

	private void PlayerInput() {
		horizontalInput =  Input.GetAxisRaw("Horizontal");
		verticalInput = Input.GetAxisRaw("Vertical");
	}

	private void MovePlayer() {
		movementDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
		if(Input.GetKey("left shift"))
			rb.AddForce(movementDirection.normalized * runSpeed * 10f, ForceMode.Force);
		else 
			rb.AddForce(movementDirection.normalized * movementSpeed * 10f, ForceMode.Force);
	}

	private void SpeedControl() {
		Vector3 flatVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

		if (flatVelocity.magnitude > runSpeed){
			Vector3 limitedVelocity = flatVelocity.normalized * runSpeed;
			rb.velocity = new Vector3(limitedVelocity.x, rb.velocity.y, limitedVelocity.z);
		}
	}

  private void Update() {
		grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, defineGround);

    PlayerInput();
		SpeedControl();

		if (grounded)
			rb.drag = groundDrag;
		else 
			rb.drag = 0;
  }

	private void FixedUpdate() {
		MovePlayer();
	}
}
