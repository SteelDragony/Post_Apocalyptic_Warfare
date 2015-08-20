using UnityEngine;
using System.Collections;

public class UnitMove : MonoBehaviour {

	//public Transform target;
	public Vector3 target;
	NavMeshAgent nav;

	// Use this for initialization
	void Start () {
		target = transform.position;
		nav = GetComponent <NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		//nav.SetDestination (target.position);
		nav.SetDestination (target);
	}
}
