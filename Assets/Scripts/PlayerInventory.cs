using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerInventory : Inventory {

    public List<Text> ammoTextfields = new List<Text>();

    public override void ChangeAmmoAmount(AmmoTypes type, int amount)
    {
        base.ChangeAmmoAmount(type, amount);
        UpdateAmmoTexts();
    }

    void UpdateAmmoTexts()
    {
        int i = 0;
        foreach (AmmoTypes type in ammo.Keys)
        {
            ammoTextfields[i].text = ammo[type].ToString();
            i++;
        }
    }
}
