using UnityEngine;
using System.Collections;

public class Party : MonoBehaviour {

    public int ammonution = 0;
    public Inventory inventory;
    // Use this for initialization
    void Start () {
        inventory = GetComponent<Inventory>();
        print("does this work?");
    }
	
	// Update is called once per frame
	void Update () {
	
	}


}
