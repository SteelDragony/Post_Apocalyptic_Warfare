using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitFire1 : MonoBehaviour {

	public Transform target;

	public float timeBetweenShots = 0.30f;
    public int burstLength = 5;
    public int burstRandomizeRange = 3;
    int currentShotInBurst = 0;
    public float timeBetweenBurst = 0.5f;
    float timeOfLastBurst;

    public Weapon weapon;
	public List<GameObject> targetsInRange = new List<GameObject>();

	// effects
	float timer;
	float effectDisplayTime = 0.10f;
	LineRenderer gunLine;
	Light gunLight;

	// unit components
	//public Transform barrelEnd;
	public GameObject turret;
	public UnitHealth unitHealth;

	// Use this for initialization
	void Start () {
		gunLine = GetComponentInChildren<LineRenderer>();
		gunLight = GetComponentInChildren<Light>();
		//barrelEnd = transform.FindChild("Turret").FindChild("Gun").FindChild("GunMuzzle");
		//turret = transform.FindChild("Turret").gameObject;
		unitHealth = GetComponent<UnitHealth>();
        weapon = GetComponentInChildren<Weapon>();
	}

	void OnTriggerEnter (Collider other)
	{
		if(other.isTrigger)
		{
			return;
		}
		if(other.gameObject.tag == "Unit")
		{
			UnitHealth potentialTarget = other.GetComponent<UnitHealth>();
			if( potentialTarget.side != unitHealth.side)
			{
				targetsInRange.Add(other.gameObject);
			}
		}
	}
	
	
	void OnTriggerExit (Collider other)
	{
		if(other.transform == target)
		{
			target = null;
		}
		targetsInRange.Remove(other.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		List<GameObject> deadTargets = new List<GameObject>();
		foreach (var i in targetsInRange) 
		{
			if(i == null)
			{
				deadTargets.Add(i);
			}
		}
		if(deadTargets.Count != 0)
		{
			foreach (var i in deadTargets) 
			{
				targetsInRange.Remove(i);
			}
		}

		if(target == null && targetsInRange.Count > 0)
		{
			target = targetsInRange[0].transform;
		}

		if(target != null)
		{
			Vector3 toTarget = target.position - transform.position;
			toTarget.y = 0f;
			Quaternion RotateQuat = Quaternion.LookRotation(toTarget);
			turret.transform.rotation = RotateQuat;
			if(timer >= timeBetweenShots)
			{
				Shoot();
			}
		}

		if(timer >= timeBetweenShots * effectDisplayTime)
		{
			DisableEffects();
		}
	}

	void DisableEffects()
	{
		gunLine.enabled = false;
		gunLight.enabled = false;
	}
	void Shoot()
	{
		timer = 0f;
		gunLight.enabled = true;
		//gunLine.enabled = true;
		//gunLine.SetPosition(0, barrelEnd.transform.position);
		//gunLine.SetPosition(1, target.position);
		UnitHealth targetHealth = target.GetComponent<UnitHealth>();

        if(currentShotInBurst < burstLength)
        {
            if(weapon.Fire(targetHealth))
            {
                currentShotInBurst++;
                timeOfLastBurst = Time.time;
            }
            else
            {

            }
        }
        else if(timeOfLastBurst + timeBetweenBurst < Time.time)
        {
            currentShotInBurst = 0 + Random.Range(-burstRandomizeRange, burstRandomizeRange);
        }
        
	}
}