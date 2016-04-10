using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Weapon : MonoBehaviour {

    public float weight;
    public int magazineSize;
    public int currentMagazine;
    public int fireRate;
    public int range;
    public int burstSize;
    public int shotSize;
    public float accuracy;
    public int damage;
    public int armourPiercing;
    public Inventory.AmmoTypes ammoType;
    public GameObject muzzleFlash;
    public AudioSource fireSound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Fire()
    {

    }

    public void Reload()
    {

    }
}
