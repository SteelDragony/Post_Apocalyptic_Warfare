using UnityEngine;
using System.Collections;

public class UnitFire1 : MonoBehaviour {

	public Transform target;

	public float timeBetweenShots = 0.30f;

	float timer;
	float effectDisplayTime = 0.10f;
	LineRenderer gunLine;
	Light gunLight;
	public Transform barrelEnd;
	public GameObject turret;
	// Use this for initialization
	void Start () {
		gunLine = GetComponentInChildren<LineRenderer>();
		gunLight = GetComponentInChildren<Light>();
		barrelEnd = transform.FindChild("Turret").FindChild("Gunall").FindChild("GunMuzzle");
		turret = transform.FindChild("Turret").gameObject;

	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		if(target != null)
		{
			Vector3 toTarget = target.position - transform.position;
			toTarget.y = 0f;
			Quaternion RotateQuat = Quaternion.LookRotation(toTarget);
			turret.transform.rotation = RotateQuat;
			if(Input.GetButton("Fire1") && timer >= timeBetweenShots)
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
		gunLine.enabled = true;
		gunLine.SetPosition(0, barrelEnd.transform.position);
		gunLine.SetPosition(1, target.position);
		UnitHealth targetHealth = target.GetComponent<UnitHealth>();
		targetHealth.health -= 20;
	}
}