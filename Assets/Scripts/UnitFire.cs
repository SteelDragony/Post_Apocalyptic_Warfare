using UnityEngine;
using System.Collections;

public class UnitFire : MonoBehaviour {

	public Transform target;

	public float timeBetweenShots = 0.30f;

	float timer;
	float effectDisplayTime = 0.10f;
	LineRenderer gunLine;
	Light gunLight;
	public Transform barrelEnd;

	// Use this for initialization
	void Start () {
		gunLine = GetComponentInChildren<LineRenderer>();
		gunLight = GetComponentInChildren<Light>();
		//barrelEnd = transform.FindChild("GunMuzzle").transform;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 toTarget = target.position - transform.position;
		toTarget.y = 0f;
		Quaternion RotateQuat = Quaternion.LookRotation(toTarget);
		transform.rotation = RotateQuat;

		timer += Time.deltaTime;
		if(Input.GetButton("Fire1") && timer >= timeBetweenShots)
		{
			Shoot();
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
		gunLine.SetPosition(0, barrelEnd.position);
		gunLine.SetPosition(1, target.position);
	}
}