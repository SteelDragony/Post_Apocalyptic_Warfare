using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    List<GameObject> side1;
    List<GameObject> side2;
    public GameObject persistentWorldMap;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void EnterCombatMap(List<GameObject> unitsSide1, List<GameObject> unitsSide2)
    {
        side1 = unitsSide1;
        side2 = unitsSide2;
        persistentWorldMap.SetActive(false);
        Application.LoadLevel(1);
    }

    public void LeaveCombatMap()
    {
        persistentWorldMap.SetActive(true);
        Application.LoadLevel(0);
    }

    void OnLevelWasLoaded(int level)
    {
        Vector3 spawn1;
        Vector3 spawn2;
        print(level);
        if(level == 1)
        {
            spawn1 = GameObject.Find("Spawn1").transform.position;
            spawn2 = GameObject.Find("Spawn2").transform.position;
            foreach (GameObject unit in side1)
            {
                Instantiate(unit, spawn1, Quaternion.identity);
            }
            foreach (GameObject unit in side2)
            {
                Instantiate(unit, spawn2, Quaternion.identity);
            }
        }
    }
}
