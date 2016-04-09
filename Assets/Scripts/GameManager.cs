using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    List<GameObject> side1;
    List<GameObject> side2;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void EnterCombatMap(List<GameObject> unitsSide1, List<GameObject> unitsSide2)
    {
        gameObject.SetActive(false);
        Application.LoadLevel(1);
    }

    public void LeaveCombatMap()
    {
        gameObject.SetActive(true);
        Application.LoadLevel(0);
    }

    void OnLevelWasLoaded(int level)
    {
        Vector3 spawn1;
        Vector3 spawn2;
        if(level == 1)
        {
            spawn1 = GameObject.Find("Spawn1").transform.position;
            spawn2 = GameObject.Find("Spawn2").transform.position;
        }
    }
}
