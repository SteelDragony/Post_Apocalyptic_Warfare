using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

    //ammo
    public enum AmmoTypes
    {
        pistol,
        rifle,
        hmg,
        rocket,
        guidedMissle,
        autocannon,
        lowCaliberCannon,
        highCaliberCannon,
        grenade
    }

    public Dictionary<string, int> ammo = new Dictionary<string, int>();
    public int pistolAmmo = 0;
    public int rifleAmmo = 0;
    public int hmgAmmo = 0;
    public int rocketAmmo = 0;
    public int guidedMissile = 0;
    public int autocannonAmmo = 0;
    public int lowCaliberCannonAmmo = 0;
    public int HighCaliberCannonAmmo = 0;
    public int grenadeAmmo = 0;

    //resources
    public Dictionary<string, int> resources = new Dictionary<string, int>();
    public int fuel = 0;
    public int food = 0;
    public int water = 0;
    public int medical = 0;
    public int scrap = 0;

    // Use this for initialization
    void Start () {
        
        ammo.Add("pistol", 0);
        ammo.Add("rifle", 0);
        ammo.Add("hmg", 0);
        ammo.Add("rocket", 0);
        ammo.Add("guidedMissile", 0);
        ammo.Add("pistolautocannon", 0);
        ammo.Add("lowCaliberCannon", 0);
        ammo.Add("highCaliberCannon", 0);
        ammo.Add("grenade", 0);

        resources.Add("fuel", 0);
        resources.Add("food", 0);
        resources.Add("water", 0);
        resources.Add("medical", 0);
        resources.Add("scrap", 0);

        
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
