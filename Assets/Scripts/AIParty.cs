using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AIParty : Party {

    public string encounterText;
    public List<DialogueOption> dialogueOptions = new List<DialogueOption>();

    void OnTriggerEnter(Collider other)
    {
        print(other.name);
        PlayerParty encounter = other.gameObject.GetComponentInParent<PlayerParty>();
        encounter.Encounter(encounterText, dialogueOptions);
    }
}
