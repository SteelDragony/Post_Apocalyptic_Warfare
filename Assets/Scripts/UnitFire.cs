using UnityEngine;
using System.Collections;

public class UnitFire : MonoBehaviour {

	public Transform target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Quaternion RotateQuat = Quaternion.FromToRotation(Transform.position, target.position)
;
	}
}