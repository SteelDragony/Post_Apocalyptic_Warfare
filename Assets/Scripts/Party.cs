using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Party : MonoBehaviour {

    public int ammonution = 0;
    public Inventory inventory;
    public List<GameObject> units;
    // Use this for initialization
    void Start () {
        inventory = GetComponent<Inventory>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}


}
