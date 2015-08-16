using UnityEngine;
using System.Collections;

public class MouseSelector : MonoBehaviour {

	RaycastHit hit;

	public static GameObject currentlySelectedUnit;

	public static Vector3 mouseDownPoint;

	void Awake(){
		mouseDownPoint = Vector3.zero;
	}
	
	void Update () {
	
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

		if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {

			if (Input.GetMouseButtonDown (0)) {
				mouseDownPoint = hit.point;
			}

			if(hit.collider.name == "Terrain"){
				if(Input.GetMouseButtonUp(0) && DidUserClickLeftMouse(mouseDownPoint)){
					DeselectGameobjectIfSelected();
				}
			}
			else {
				if(Input.GetMouseButtonUp(0) && DidUserClickLeftMouse(mouseDownPoint)){
					if(hit.collider.transform.FindChild("Selected")){
						if(currentlySelectedUnit != hit.collider.gameObject){
							GameObject SelectedObj = hit.collider.transform.FindChild("Selected").gameObject;
							SelectedObj.SetActive(true);

							if(currentlySelectedUnit != null)
								currentlySelectedUnit.transform.FindChild("Selected").gameObject.SetActive(false);
							currentlySelectedUnit = hit.collider.gameObject;
						}
					} else {
						DeselectGameobjectIfSelected();
					}
				}
			}
		} else {
			if(Input.GetMouseButtonUp(0) && DidUserClickLeftMouse(mouseDownPoint))
				DeselectGameobjectIfSelected();
		}

		Debug.DrawRay (ray.origin, ray.direction * 500, Color.yellow);
	}

	public bool DidUserClickLeftMouse(Vector3 hitPoint){
		float clickZone = 1.3f;

		if (
			(mouseDownPoint.x < hitPoint.x + clickZone && mouseDownPoint.x > hitPoint.x - clickZone) &&
			(mouseDownPoint.y < hitPoint.y + clickZone && mouseDownPoint.y > hitPoint.y - clickZone) &&
			(mouseDownPoint.z < hitPoint.z + clickZone && mouseDownPoint.z > hitPoint.z - clickZone)
		)
			return true;
		else
			return false;

	}

	public static void DeselectGameobjectIfSelected(){
		if (currentlySelectedUnit != null) {
			currentlySelectedUnit.transform.FindChild("Selected").gameObject.SetActive(false);
			currentlySelectedUnit = null;
		}
	}

}
