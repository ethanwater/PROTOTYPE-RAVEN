using UnityEngine;

public class ExampleScript : MonoBehaviour {
    public Camera mainCamera;
    public Camera overheadCamera;

    public void overhead() {
			if (Input.GetKey("v")){
				mainCamera.enabled = false;
        overheadCamera.enabled = true;

			}
    }

		public void maincam() {
			if (Input.GetKey("c")){
        mainCamera.enabled = true;
        overheadCamera.enabled = false;
			}
    }

		public void Update() {
			overhead();
			maincam();
		}
}

