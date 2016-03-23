using UnityEngine;
using System.Collections;

public class MouseClickWaypoint : MonoBehaviour {

    public GameObject waypoint;
    RaycastHit hit;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 500))
            {
                waypoint.transform.position = hit.point;
            }
        }
	}
}
