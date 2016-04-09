using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    List<GameObject> unitsSide1;
    List<GameObject> unitsSide2;
    Party _side1;
    Party _side2;

    public List<GameObject> Spawned1;
    public List<GameObject> Spawned2;
    public GameObject persistentWorldMap;
    

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(persistentWorldMap);
	}
	
	// Update is called once per frame
	void Update () {
        Spawned1.RemoveAll(item => item == null);
        Spawned2.RemoveAll(item => item == null);
        if(Application.loadedLevel == 1 && (Spawned1.Count == 0 || Spawned2.Count == 0))
        {
            LeaveCombatMap();
        }
    }

    public void EnterCombatMap(Party side1, Party side2)
    {
        _side1 = side1;
        _side2 = side2;
        unitsSide1 = side1.units;
        unitsSide2 = side2.units;
        persistentWorldMap.SetActive(false);
        Application.LoadLevel(1);
    }

    public void LeaveCombatMap()
    {
        persistentWorldMap.SetActive(true);
        DontDestroyOnLoad(persistentWorldMap);
        _side1.units = Spawned1;
        _side2.units = Spawned2;
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
            foreach (GameObject unit in unitsSide1)
            {
                GameObject spawnedUnit = (GameObject)Instantiate(unit, spawn1, Quaternion.identity);
                spawnedUnit.GetComponent<UnitHealth>().side = 1;
                Spawned1.Add(spawnedUnit);
                
            }
            foreach (GameObject unit in unitsSide2)
            {
                GameObject spawnedUnit = (GameObject)Instantiate(unit, spawn2, Quaternion.identity);
                spawnedUnit.GetComponent<UnitHealth>().side = 2;
                Spawned2.Add(spawnedUnit);
            }
        }
    }
}
