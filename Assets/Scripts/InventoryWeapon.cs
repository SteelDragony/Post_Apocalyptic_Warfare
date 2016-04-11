using UnityEngine;
using System.Collections;

public class InventoryWeapon : MonoBehaviour {

    public GameObject weaponPrefab;
    public string weaponName;

	// Use this for initialization
	void Start () {
        weaponName = weaponPrefab.GetComponent<Weapon>().weaponName;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
