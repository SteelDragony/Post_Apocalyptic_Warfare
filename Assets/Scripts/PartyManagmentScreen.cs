using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PartyManagmentScreen : MonoBehaviour {

    public Inventory inventory;

    public PlayerParty playerParty;

    public Button unitListButtonPrefab;
    public GameObject unitList;
    public WorldMapUnit activeUnit;
    public GameObject displayedModel;
    public Transform displayPoint;

    public GameObject inventoryList;
    public Button inventoryListButtonPrefab;

	// Use this for initialization
	void Start () {
        int i = 1;
        foreach (GameObject unit in playerParty.units)
        {
            // tempory var makes sure they don't all hand same unit to SetActiveUnit function
            WorldMapUnit worldUnit = unit.GetComponent<WorldMapUnit>();
            Button unitListButton = (Button)Instantiate(unitListButtonPrefab, unitList.transform.position, Quaternion.identity);
            unitListButton.GetComponentInChildren<Text>().text = worldUnit.unitName;
            unitListButton.onClick.AddListener(delegate { SetActiveUnit(worldUnit); });
            unitListButton.transform.SetParent(unitList.transform, true);
            unitListButton.transform.Translate(0, Screen.height/2 -50 * i, 0);
            i++;
        }
        i = 1;
        foreach (GameObject weapon in inventory.weapons)
        {
            InventoryWeapon inventoryWeapon = weapon.GetComponent<InventoryWeapon>();
            Button inventoryListButton = (Button)Instantiate(inventoryListButtonPrefab, inventoryList.transform.position, Quaternion.identity);
            inventoryListButton.GetComponentInChildren<Text>().text = inventoryWeapon.weaponName;
            inventoryListButton.onClick.AddListener(delegate { EquipWeapon(inventoryWeapon); });
            inventoryListButton.transform.SetParent(inventoryList.transform, true);
            inventoryListButton.transform.Translate(0, Screen.height/2 -50 * i, 0);
            i++;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void SetActiveUnit(WorldMapUnit unit)
    {
        Destroy(displayedModel);
        activeUnit = unit.GetComponent<WorldMapUnit>();
        displayedModel = unit.SpawnOnCombatmap(displayPoint.position);
        displayedModel.transform.rotation = displayPoint.rotation;
        //displayedModel = (GameObject) Instantiate(activeUnit.combatMapUnitPrefab, displayPoint.position, displayPoint.rotation);
        foreach (MonoBehaviour script in displayedModel.GetComponentsInChildren<MonoBehaviour>())
        {
            script.enabled = false;
        }
        
    }

    void EquipWeapon(InventoryWeapon weapon)
    {
        if (activeUnit)
        {
            activeUnit.weapon = weapon;
            SetActiveUnit(activeUnit);
        }
    }

}
