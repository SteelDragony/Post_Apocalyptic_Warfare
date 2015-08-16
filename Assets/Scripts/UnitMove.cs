using UnityEngine;
using System.Collections;

public class UnitMove : MonoBehaviour {

	public Transform target;
	NavMeshAgent nav;

	// Use this for initialization
	void Start () {
		nav = GetComponent <NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		nav.SetDestination (target.position);
	}
}
