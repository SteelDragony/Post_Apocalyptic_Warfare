using UnityEngine;
using System.Collections;

public class UnitHealth : MonoBehaviour {

	public float health = 100f;
	public int side = 0;

	// Use this for initialization
	void Start () {
	
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
}
