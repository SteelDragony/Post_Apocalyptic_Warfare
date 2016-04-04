using UnityEngine;
using System.Collections;

public class UnitMove : MonoBehaviour {

	//public Transform target;
	public Vector3 target;
	NavMeshAgent nav;
    Animator animations;
    public float lookLeft = 0.0f;

	// Use this for initialization
	void Start () {
		target = transform.position;
		nav = GetComponent <NavMeshAgent> ();
        animations = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		//nav.SetDestination (target.position);
		nav.SetDestination (target);
        if (animations)
        {
            animations.SetFloat("Speed", nav.velocity.magnitude/3.5f);
            animations.SetFloat("AimLeft", lookLeft);
        }
	}
}
