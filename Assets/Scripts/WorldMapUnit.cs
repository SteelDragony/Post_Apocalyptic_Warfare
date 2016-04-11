using UnityEngine;
using System.Collections;

public class WorldMapUnit : MonoBehaviour {

    public GameObject combatMapUnitPrefab;
    public GameObject combatMapSpawnedUnitReference;
    public InventoryWeapon weapon;

    public string unitName;
    public string ocupation;
    public string nationality;
    public string backgroundStory;
    public int age;

    public float health = 100f;
    public float maxHealth = 100f; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public GameObject SpawnOnCombatmap(Vector3 spawnPoint)
    {
        combatMapSpawnedUnitReference = (GameObject) Instantiate(combatMapUnitPrefab, spawnPoint, Quaternion.identity);
        Transform weaponPoint = combatMapSpawnedUnitReference.GetComponentInChildren<WeaponPoint>().transform;
        GameObject tempWeapon = (GameObject)Instantiate(weapon.weaponPrefab);
        tempWeapon.transform.SetParent(weaponPoint);
        tempWeapon.transform.localPosition = weapon.weaponPrefab.transform.position;
        tempWeapon.transform.localRotation = weapon.weaponPrefab.transform.rotation;
        tempWeapon.transform.localScale = weapon.weaponPrefab.transform.localScale;
        return combatMapSpawnedUnitReference;
    }
}
