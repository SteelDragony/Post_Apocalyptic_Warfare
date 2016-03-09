using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InteractableArea : MonoBehaviour {

    public List<string> dialogueTexts = new List<string>();
    public List<DialogueOption> dialogueOptions = new List<DialogueOption>();


	// Use this for initialization
	void Start () {
        dialogueTexts.Add("You encounter a city");
        dialogueTexts.Add("You found some ammo");
        DialogueOption scavenge = new DialogueOption();
        DialogueOption leave = new DialogueOption();
        leave.buttonText = "leave";
        leave.endDialogue = true;
        DialogueOption succes = new DialogueOption();
        succes.endDialogue = true;
        succes.buttonText = "done";
        succes.ammoReward = 2;
        scavenge.dialogueOptions.Add(succes);
        dialogueOptions.Add(scavenge);
        dialogueOptions.Add(leave);
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        print(other.name);
        PlayerParty encounter = other.gameObject.GetComponentInParent<PlayerParty>();
        encounter.Encounter(dialogueTexts, dialogueOptions);
    }


}
