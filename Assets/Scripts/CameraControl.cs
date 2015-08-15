using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	public struct BoxLimit {
		public float LeftLimit;
		public float RightLimit;
		public float TopLimit;
		public float BottomLimit;
	}

	public static BoxLimit cameraLimits = new BoxLimit ();
	public static BoxLimit mouseScrollLimits = new BoxLimit ();
	public static CameraControl Instance;

	private float cameraMoveSpeed = 60f;
	private float mouseBoundary = 25f;

	void Awake(){
		Instance = this;
	}

	void Start(){
		cameraLimits.LeftLimit = 10.0f;
		cameraLimits.RightLimit = 510.0f;
		cameraLimits.TopLimit = 520.0f;
		cameraLimits.BottomLimit = -20.0f;

		mouseScrollLimits.LeftLimit = mouseBoundary;
		mouseScrollLimits.RightLimit = mouseBoundary;
		mouseScrollLimits.TopLimit = mouseBoundary;
		mouseScrollLimits.BottomLimit = mouseBoundary;
	}

	void Update(){

		if (CheckIfUserCameraInput ()) {
			Vector3 cameraDesiredMove = GetDesiredTranslation();
			if(!isDesiredPositionOverBoundries(cameraDesiredMove)){
				this.transform.Translate(cameraDesiredMove);
			}
		}
	}

	public bool CheckIfUserCameraInput(){
		if (CameraControl.AreWASDKeysPressed () || CameraControl.IsMousePositionWithinBoundries())
			return true;
		else
			return false;
	}

	public Vector3 GetDesiredTranslation(){
		float moveSpeed = cameraMoveSpeed * Time.deltaTime;
		float desiredX = 0f;
		float desiredZ = 0f;

		if (Input.GetKey (KeyCode.W))
			desiredZ = moveSpeed;

		if (Input.GetKey (KeyCode.S))
			desiredZ = moveSpeed * -1;

		if (Input.GetKey (KeyCode.A))
			desiredX = moveSpeed * -1;

		if (Input.GetKey (KeyCode.D))
			desiredX = moveSpeed;

		if (Input.mousePosition.x < mouseScrollLimits.LeftLimit) {
			desiredX = moveSpeed * -1;
		}

		if (Input.mousePosition.x > (Screen.width - mouseScrollLimits.RightLimit)) {
			desiredX = moveSpeed;
		}

		if (Input.mousePosition.y < mouseScrollLimits.BottomLimit) {
			desiredZ = moveSpeed * -1;
		}
		
		if (Input.mousePosition.y > (Screen.height - mouseScrollLimits.TopLimit)) {
			desiredZ = moveSpeed;
		}

		return new Vector3 (desiredX, 0, desiredZ);
	}

	public bool isDesiredPositionOverBoundries(Vector3 desiredPosition){
		Debug.Log (cameraLimits.LeftLimit);
		if ((this.transform.position.x + desiredPosition.x) < cameraLimits.LeftLimit)
			return true;
		if ((this.transform.position.x + desiredPosition.x) > cameraLimits.RightLimit)
			return true;
		if ((this.transform.position.z + desiredPosition.z) > cameraLimits.TopLimit)
			return true;
		if ((this.transform.position.z + desiredPosition.z) < cameraLimits.BottomLimit)
			return true;

		return false;
	}

	public static bool AreWASDKeysPressed(){
		if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.D))
			return true;
		else
			return false;
	}

	public static bool IsMousePositionWithinBoundries(){
		if (
			(Input.mousePosition.x < mouseScrollLimits.LeftLimit && Input.mousePosition.x > -5) ||
			(Input.mousePosition.x > (Screen.width - mouseScrollLimits.RightLimit) && Input.mousePosition.x < (Screen.width + 5)) ||
			(Input.mousePosition.y < mouseScrollLimits.BottomLimit && Input.mousePosition.y > -5) ||
			(Input.mousePosition.y > (Screen.height - mouseScrollLimits.TopLimit) && Input.mousePosition.y < (Screen.width + 5))
		)
			return true;
		else
			return false;
	}
}
