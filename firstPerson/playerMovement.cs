using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public const float staminaMAX = 100;

	[Header("Movement")]
	public float walkSpeed;
	public float runSpeed;
	public float stamina;
	public bool canRun;
	public bool runningStatus;

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
		canRun = true;
		runningStatus = false;
  }

	//Movement System
	private void PlayerInput() {
		horizontalInput =  Input.GetAxisRaw("Horizontal");
		verticalInput = Input.GetAxisRaw("Vertical");
	}

	private void MovePlayer() {
		movementDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
		if(Input.GetKey("left shift") && canRun) {
			if(Input.GetKey("w")) { //can only run forward
				rb.AddForce(movementDirection.normalized * runSpeed * 10f, ForceMode.Force);
				stamina -= .5f;
				runningStatus = true;
			} else { //cancels run if not forward
				runningStatus = false;
				rb.AddForce(movementDirection.normalized * walkSpeed * 10f, ForceMode.Force);
			}
			if(stamina <= 0f) { //stamina purged
				canRun = false; //no longer run
				walkSpeed = 2.5f; //walk slower to fatigue
			}
		} else { //walk
			runningStatus = false;
			rb.AddForce(movementDirection.normalized * walkSpeed * 10f, ForceMode.Force);
		}
	}

	private void SpeedControl() {
		Vector3 flatVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

		if (flatVelocity.magnitude > runSpeed) {
			Vector3 limitedVelocity = flatVelocity.normalized * runSpeed;
			rb.velocity = new Vector3(limitedVelocity.x, rb.velocity.y, limitedVelocity.z);
		}
	}
	
	private void StaminaRegeneration(){
		if (stamina <= staminaMAX && stamina >= 2f){ //regen normally if not too low
			stamina += .01f;		
		} else if(stamina < 2f){ //if stamina depleted, regen is slower by 1/10
			stamina += .001f;
		} else { //recovered can run and normal walk
			canRun = true;
			walkSpeed = 5f;
		}
	}

  private void Update() {
		grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, defineGround);

    PlayerInput();
		SpeedControl();
		StaminaRegeneration();

		if (grounded) {
			rb.drag = groundDrag;
		} else {
			rb.drag = 0;
		}
  }

	private void FixedUpdate() {
		MovePlayer();
	}
}
