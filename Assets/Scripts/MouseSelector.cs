using UnityEngine;
using System.Collections;

public class MouseSelector : MonoBehaviour {

	RaycastHit hit;

	public static ArrayList currentlySelectedUnits = new ArrayList ();
	public static ArrayList unitsOnScreen = new ArrayList ();
	public static ArrayList unitsInDrag = new ArrayList();
	private bool finishedDrag;

	private static Vector3 mouseDownPoint;
	//private static Vector3 mouseUpPoint;
	private static Vector3 currentMousePoint;

	public GUIStyle mouseDragSkin;

	public static bool isDragging;
	private static float beforeDragLimit = 1f;
	private static float timeLeft;
	private static Vector2 dragStart;

	private static float clickMargin = 1.3f;

	private float unitSpacing = 6f;

	private float boxWidth;
	private float boxHeight;
	private float boxTop;
	private float boxLeft;
	private static Vector2 boxStart;
	private static Vector2 boxFinish;

	void Awake(){
		mouseDownPoint = Vector3.zero;
	}
	
	void Update () {
	
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

		if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {

			currentMousePoint = hit.point;

			if (Input.GetMouseButtonDown (0)) {
				mouseDownPoint = hit.point;
				timeLeft = beforeDragLimit;
				dragStart = Input.mousePosition;
				if (!isShiftDown ()) {
					DeselectGameobjectsIfSelected();
				}
			} else if(Input.GetMouseButton(0)){
				if(!isDragging){
					timeLeft -= Time.deltaTime;
					if(timeLeft <= 0f || IsDraggingByPosition(dragStart,Input.mousePosition)){
						isDragging = true;
					}
				} else {
					Debug.Log("Is dragging");
				}
			} else if(Input.GetMouseButtonUp(0)){
				if(isDragging){
					finishedDrag = true;
				}
				timeLeft = 0f;
				isDragging = false;
			}

			if(!isDragging){
				if(hit.collider.name == "Terrain"){
					if(Input.GetMouseButtonUp(0) && DidUserClickLeftMouse(hit.point)){
						DeselectGameobjectsIfSelected();
					}
					else if(Input.GetMouseButtonUp(1) &&/* DidUserClickLeftMouse(hit.point) &&*/ currentlySelectedUnits.Count > 0){
						GameObject waypoint = new GameObject();
						waypoint.transform.position = hit.point;
						int root = Mathf.CeilToInt(Mathf.Sqrt(currentlySelectedUnits.Count));
						if(currentlySelectedUnits.Count <= 3)
							root = currentlySelectedUnits.Count;
						for(int i = 0; i < currentlySelectedUnits.Count; i++){

							GameObject unit = currentlySelectedUnits[i] as GameObject;
							if(i == Mathf.FloorToInt(currentlySelectedUnits.Count/2)){
								waypoint.transform.rotation = Quaternion.LookRotation((waypoint.transform.position - unit.transform.position).normalized);
							}
							UnitMove unitScript = unit.transform.GetComponent<UnitMove>();
							GameObject position = new GameObject();
							position.transform.SetParent(waypoint.transform);
							position.transform.localPosition = new Vector3(((i % root) * unitSpacing) - (((root - 1) * unitSpacing) / 2),
																	  0,
																	  Mathf.FloorToInt( i / root ) * unitSpacing) * -1;
							if(unit.transform.GetComponent<ASTAR_AI>() != null){
								unit.transform.GetComponent<ASTAR_AI>().target = hit.point;
							}else{

								unit.transform.GetComponent<UnitMove>().target = position.transform;
							}
						}
					}
				}
				else {
					if(Input.GetMouseButtonUp(0) && DidUserClickLeftMouse(hit.point)){
						if(hit.collider.transform.FindChild("Selected")){
							if(!isUnitSelected(hit.collider.gameObject)){

								if(!isShiftDown())
									DeselectGameobjectsIfSelected();
								currentlySelectedUnits.Add(hit.collider.gameObject);
								hit.collider.transform.FindChild("Selected").gameObject.SetActive(true);
							} else {
								if(isShiftDown())
									removeUnitFromArray(hit.collider.gameObject);
								else{
									DeselectGameobjectsIfSelected();
									currentlySelectedUnits.Add (hit.collider.gameObject);
									hit.collider.transform.FindChild("Selected").gameObject.SetActive(true);
								}
							}
						} else {
							DeselectGameobjectsIfSelected();
						}
					}
				}
			}
		} else {
			if(Input.GetMouseButtonUp(0) && DidUserClickLeftMouse(hit.point))
				DeselectGameobjectsIfSelected();
		}

		Debug.DrawRay (ray.origin, ray.direction * 500, Color.yellow);

		if (isDragging) {
			boxWidth = Camera.main.WorldToScreenPoint (mouseDownPoint).x - Camera.main.WorldToScreenPoint (currentMousePoint).x;
			boxHeight = Camera.main.WorldToScreenPoint (mouseDownPoint).y - Camera.main.WorldToScreenPoint (currentMousePoint).y;
			boxLeft = Input.mousePosition.x;
			boxTop = (Screen.height - Input.mousePosition.y) - boxHeight;

			if (boxWidth > 0f) {
				if (boxHeight > 0f)
					boxStart = new Vector2 (Input.mousePosition.x, Input.mousePosition.y + boxHeight);
				else
					boxStart = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
			} else {
				if (boxHeight > 0f)
					boxStart = new Vector2 (Input.mousePosition.x + boxWidth, Input.mousePosition.y + boxHeight);
				else
					boxStart = new Vector2 (Input.mousePosition.x + boxWidth, Input.mousePosition.y);
			}
			boxFinish = new Vector2 (boxStart.x + unsign (boxWidth), boxStart.y - unsign (boxHeight));
		}

	}

	void LateUpdate(){
		unitsInDrag.Clear ();
		if ((isDragging || finishedDrag) && unitsOnScreen.Count > 0) {
			for(int i = 0;i<unitsOnScreen.Count;i++){
				GameObject unitObj = unitsOnScreen[i] as GameObject;
				Unit unitScript = unitObj.GetComponent<Unit>();
				GameObject selectedObj = unitObj.transform.FindChild("Selected").gameObject;
				if(!isUnitAlreadyInDrag(unitObj)){
					if(isUnitInsideDrag(unitScript.ScreenPos)){
						selectedObj.SetActive(true);
						unitsInDrag.Add(unitObj);
					} else {
						if(!isUnitSelected(unitObj))
							selectedObj.SetActive(false);
					}
				}
			}
		}
		if (finishedDrag) {
			finishedDrag = false;
			selectDraggedUnits();
		}
	}

	void OnGUI(){

		if (isDragging) {
			GUI.Box (new Rect (boxLeft, boxTop, boxWidth, boxHeight), "", mouseDragSkin);
		}
	}

	public static float unsign(float Val){
		if (Val < 0f)
			Val *= -1;
		return Val;
	}

	public bool IsDraggingByPosition(Vector2 dragStart, Vector2 currentPoint){
		if(
			(currentPoint.x > dragStart.x + clickMargin || currentPoint.x < dragStart.x - clickMargin) ||
			(currentPoint.y > dragStart.y + clickMargin || currentPoint.y < dragStart.y - clickMargin)
		) 
			return true;
		return false;

	}

	public bool DidUserClickLeftMouse(Vector3 hitPoint){

		if (
			(mouseDownPoint.x < hitPoint.x + clickMargin && mouseDownPoint.x > hitPoint.x - clickMargin) &&
			(mouseDownPoint.y < hitPoint.y + clickMargin && mouseDownPoint.y > hitPoint.y - clickMargin) &&
			(mouseDownPoint.z < hitPoint.z + clickMargin && mouseDownPoint.z > hitPoint.z - clickMargin)
		)
			return true;
		else
			return false;

	}

	public static void DeselectGameobjectsIfSelected(){
		if (currentlySelectedUnits.Count > 0) {
			for(int i = 0;currentlySelectedUnits.Count > i; i++){
				GameObject arrayUnit = currentlySelectedUnits[i] as GameObject;
				arrayUnit.transform.FindChild("Selected").gameObject.SetActive(false);
				arrayUnit.GetComponent<Unit>().Selected = false;
			}
			currentlySelectedUnits.Clear();
		}
	}

	public static bool isUnitSelected(GameObject unit){
		if (currentlySelectedUnits.Count > 0) {
			for(int i = 0;currentlySelectedUnits.Count > i; i++){
				GameObject arrayUnit = currentlySelectedUnits[i] as GameObject;
				if(arrayUnit == unit)
					return true;
			}
		}
		return false;
	}

	public static void removeUnitFromArray(GameObject unit){
		if (currentlySelectedUnits.Count > 0) {
			for(int i = 0;currentlySelectedUnits.Count > i; i++){
				GameObject arrayUnit = currentlySelectedUnits[i] as GameObject;
				if(arrayUnit == unit){
					currentlySelectedUnits.RemoveAt(i);
					arrayUnit.transform.FindChild("Selected").gameObject.SetActive(false);
				}
			}
		}
	}

	public static bool isShiftDown(){
		if (Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift))
			return true;
		return false;
	}

	public static bool UnitWithinScreenSpace(Vector2 unitScreenPos){
		return((unitScreenPos.x < Screen.width && unitScreenPos.y < Screen.height) &&
			(unitScreenPos.x > 0f && unitScreenPos.y > 0f));
	}

	public static void removeFromOnScreenUnits(GameObject Unit){
		for (int i = 0; i < unitsOnScreen.Count; i++) {
			GameObject unitObj = unitsOnScreen[i] as GameObject;
			if(Unit == unitObj){
				unitsOnScreen.RemoveAt(i);
				unitObj.GetComponent<Unit>().OnScreen = false;
				return;
			}
		}
	}

	public static bool isUnitInsideDrag(Vector2 unitScreenPos){
		return(unitScreenPos.x > boxStart.x && unitScreenPos.y < boxStart.y) &&
			(unitScreenPos.x < boxFinish.x && unitScreenPos.y > boxFinish.y);
	}

	public static bool isUnitAlreadyInDrag(GameObject unit){
		if (unitsInDrag.Count > 0) {
			for(int i = 0;unitsInDrag.Count > i; i++){
				GameObject arrayUnit = unitsInDrag[i] as GameObject;
				if(arrayUnit == unit)
					return true;
			}
		}
		return false;
	}

	public static void selectDraggedUnits(){

		if (unitsInDrag.Count > 0) {
			for(int i = 0;i < unitsInDrag.Count;i++){
				GameObject unitObj = unitsInDrag[i] as GameObject;
				if(!isUnitSelected(unitObj)){
				   	currentlySelectedUnits.Add(unitObj);
					unitObj.GetComponent<Unit>().Selected = true;
				}
			}
			unitsInDrag.Clear();
		}
	}
}
