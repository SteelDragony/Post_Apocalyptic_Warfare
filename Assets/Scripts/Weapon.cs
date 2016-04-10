using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Weapon : MonoBehaviour {

    public string name;
    public string description;
    public float weight;
    public int magazineSize;
    public int currentMagazine;
    public float reloadTime;
    public float fireRate;
    public int range;
    public int burstSize;
    public int shotSize;
    public float accuracy;
    public int damage;
    public int armourPiercing;
    public int soundLevel;
    public Inventory.AmmoTypes ammoType;
    public GameObject muzzleFlash;
    public AudioSource fireSound;

    bool reloading = false;
    float reloadStartTime = 0;
    float LastShotTime = 0;

	// Use this for initialization
	void Start () {
        fireSound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

	}

    public virtual bool Fire(UnitHealth target)
    {
        if (LastShotTime + (60 / fireRate) < Time.time && currentMagazine > 0)
        {
            fireSound.Play();
            target.health -= damage;
            LastShotTime = Time.time;
            currentMagazine -= 1;
            return true;
        }
        else
        {
            Reload();
            return false;
        }
    }

    public void Reload()
    {
        if(!reloading)
        {
            reloading = true;
            reloadStartTime = Time.time;
        }
        else if(reloadStartTime + reloadTime < Time.time)
        {
            currentMagazine = magazineSize;
            reloading = false;
        }
        else
        {

        }
    }
}
