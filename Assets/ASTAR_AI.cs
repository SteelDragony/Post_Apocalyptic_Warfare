using UnityEngine;
using System.Collections;
using Pathfinding;

public class ASTAR_AI : MonoBehaviour {

	public Transform target;
	public float speed = 10f;

	Seeker seeker;
	Path path;
	int currentWaypoint;
	float waypointMarge = 2f;
	CharacterController charController;

	// Use this for initialization
	void Start () {
		seeker = GetComponent<Seeker> ();
		seeker.StartPath (transform.position, target.position, OnPathComplete);
		charController = GetComponent<CharacterController>();
	}

	public void OnPathComplete (Path p ) {
		if(!p.error)
		{
			path = p;
			currentWaypoint = 0;
		}
		else
		{
			Debug.Log(p.error);
		}
	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		if(path == null)
		{
			return;
		}

		if(currentWaypoint >= path.vectorPath.Count)
		{
			return;
		}

		Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized * speed;
		charController.SimpleMove(dir);

		if (Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]) < waypointMarge)
		{
			currentWaypoint ++;
		}
	}
}
