using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, Controls.IPlayerActions {
	public Vector2 moveComposite;
	public Vector2 mouseDelta;
	

	public Action onJumpPerformed;
	public Action onSprintPerformed;

	private Controls controls;

	private void OnEnable() {
    if (controls != null)
        return;

    controls = new Controls();
    controls.Player.SetCallbacks(this);
    controls.Player.Enable();
  }

  public void OnDisable()
  {
    controls.Player.Disable();
  }

  public void OnLook(InputAction.CallbackContext context)
  {
    mouseDelta = context.ReadValue<Vector2>();
  }

  public void OnMove(InputAction.CallbackContext context)
  {
    moveComposite = context.ReadValue<Vector2>();
  }

  public void OnJump(InputAction.CallbackContext context)
  {
    if (!context.performed)
      return;

    onJumpPerformed?.Invoke();
  }

	public void OnSprint(InputAction.CallbackContext context)
  {
    if (!context.performed)
      return;

    onSprintPerformed?.Invoke();
  }
}
