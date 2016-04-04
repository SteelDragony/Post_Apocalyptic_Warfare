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

	Vector3 mouseDragStart;

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
//				this.transform.position = Vector3.Lerp(this.transform.position, this.transform.position + cameraDesiredMove, 1);
			}
		}
	}

	public bool CheckIfUserCameraInput(){
		if (CameraControl.AreWASDKeysPressed () || CameraControl.IsMousePositionWithinBoundries() || Input.GetMouseButton(2) || Input.mouseScrollDelta.y != 0)
			return true;
		else
			return false;
	}

	public Vector3 GetDesiredTranslation(){
		float moveSpeed = cameraMoveSpeed * Time.deltaTime;
		float desiredX = 0f;
		float desiredZ = 0f;
		float desiredY = 0f;
		if (Input.GetKey (KeyCode.W))
			desiredZ = moveSpeed;

		if (Input.GetKey (KeyCode.S))
			desiredZ = moveSpeed * -1;

		if (Input.GetKey (KeyCode.A))
			desiredX = moveSpeed * -1;

		if (Input.GetKey (KeyCode.D))
			desiredX = moveSpeed;
        /*
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
        */
		if(Input.GetMouseButtonDown(2))
		{
			mouseDragStart = Input.mousePosition;
		}

		if(Input.GetMouseButton(2))
		{
			desiredX = -Input.GetAxis("Mouse X");
			desiredZ = -Input.GetAxis("Mouse Y");
		}
		desiredY = -Input.mouseScrollDelta.y;
		//Debug.Log(desiredY);
		return new Vector3 (desiredX, desiredY, desiredZ);
	}

	public bool isDesiredPositionOverBoundries(Vector3 desiredPosition){
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
