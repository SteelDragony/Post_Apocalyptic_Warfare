using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {

	public Vector2 ScreenPos;
	public bool OnScreen;
	public bool Selected = false;

	void Update () {
		if (!Selected) {
			ScreenPos = Camera.main.WorldToScreenPoint (this.transform.position);

			if (MouseSelector.UnitWithinScreenSpace (ScreenPos)) {
				if (!OnScreen) {
					MouseSelector.unitsOnScreen.Add (this.gameObject);
					OnScreen = true;
				}
			} else {
				if(OnScreen)
					MouseSelector.removeFromOnScreenUnits(this.gameObject);
			}
		}
	}
}
