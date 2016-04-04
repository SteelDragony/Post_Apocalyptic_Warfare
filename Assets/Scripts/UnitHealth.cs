using UnityEngine;
using System.Collections;

public class UnitHealth : MonoBehaviour {

	public float startHealth = 100f;
	public float health = 100f;
	public int side = 0;

	// Use this for initialization
	void Start () {
		health = startHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if (health <=0)
		{
			MouseSelector.removeFromOnScreenUnits(this.gameObject);
			MouseSelector.removeUnitFromArray(this.gameObject);
			Destroy(gameObject);
		}
	}

	void OnGUI()
	{
		//Gets coordinate our object on screen
		Vector3 scrPos = Camera.main.WorldToScreenPoint(this.transform.position);
		//Sets texture for size, for example, 100x30
		GUI.DrawTexture(new Rect(scrPos.x - 100/2.0f, Screen.height - scrPos.y - 30/2.0f, health/startHealth * 100, 5), new Texture2D(20, 5), ScaleMode.StretchToFill);
        
	}
}
