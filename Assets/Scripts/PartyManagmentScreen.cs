using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PartyManagmentScreen : MonoBehaviour {

    public Inventory inventory;
    public PlayerParty playerParty;
    public Button unitListButtonPrefab;
    public GameObject unitList;
    public WorldMapUnit activeUnit;

	// Use this for initialization
	void Start () {
        int i = 0;
        foreach (GameObject unit in playerParty.units)
        {
            Button unitListButton = (Button)Instantiate(unitListButtonPrefab, unitList.transform.position, Quaternion.identity);
            unitListButton.GetComponentInChildren<Text>().text = unit.name;
            unitListButton.onClick.AddListener(delegate { SetActiveUnit(unit); });
            unitListButton.transform.SetParent(unitList.transform);
            unitListButton.transform.position.Set(unitListButton.transform.position.x, 100, unitListButton.transform.position.z);
            unitListButton.transform.Translate(0, 50 * i, 0);

            i++;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void SetActiveUnit(GameObject unit)
    {
        activeUnit = unit.GetComponent<WorldMapUnit>();

    }

}
