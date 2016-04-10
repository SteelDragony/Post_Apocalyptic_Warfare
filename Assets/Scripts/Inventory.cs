using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

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
    public Dictionary<AmmoTypes, int> ammo = new Dictionary<AmmoTypes, int>();

    //resources

    public enum ResourceTypes
    {
        fuel,
        food,
        water,
        medical,
        scrap
    }
    public Dictionary<ResourceTypes, int> resources = new Dictionary<ResourceTypes, int>();

    public List<GameObject> weapons;

    // Use this for initialization
    void Start () {
        
        ammo.Add(AmmoTypes.pistol, 0);
        ammo.Add(AmmoTypes.rifle, 0);
        ammo.Add(AmmoTypes.hmg, 0);
        ammo.Add(AmmoTypes.rocket, 0);
        ammo.Add(AmmoTypes.guidedMissle, 0);
        ammo.Add(AmmoTypes.autocannon, 0);
        ammo.Add(AmmoTypes.lowCaliberCannon, 0);
        ammo.Add(AmmoTypes.highCaliberCannon, 0);
        ammo.Add(AmmoTypes.grenade, 0);

        resources.Add(ResourceTypes.fuel, 0);
        resources.Add(ResourceTypes.food, 0);
        resources.Add(ResourceTypes.water, 0);
        resources.Add(ResourceTypes.medical, 0);
        resources.Add(ResourceTypes.scrap, 0);

        
    }
	
    public virtual void ChangeAmmoAmount(AmmoTypes type, int amount)
    {
        if(ammo.ContainsKey(type))
        {
            ammo[type] += amount;
        }
        else
        {
            print("ammo type not found, something wrong with inventory");
        }
    }

    public virtual void ChangeResourceAmount(ResourceTypes type, int amount)
    {
        if(resources.ContainsKey(type))
        {
            resources[type] += amount;
        }
        else
        {
            print("resource type not found, something wrong with inventory");
        }
    }
	// Update is called once per frame
	void Update () {
	
	}
}
