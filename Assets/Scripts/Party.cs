using UnityEngine;
using System.Collections;

public class Party : MonoBehaviour {

    public enum Resources
    {
        fuel = 0,
        food = 0,
        water = 0,
        medical = 0,
        scrap = 0
    }

    public enum Ammo
    {
        pistol = 0,
        rifle = 0,
        hmg = 0,
        rocket = 0,
        guidedMissile = 0,
        autocannon = 0,
        lowCaliberCannon = 0,
        highCaliberCannon = 0,
        grenade = 0
    }

    

    Resources resources = new Resources();
    Ammo ammo = new Ammo();

    public int ammonution = 0;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
