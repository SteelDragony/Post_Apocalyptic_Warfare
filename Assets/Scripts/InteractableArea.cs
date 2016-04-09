using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InteractableArea : MonoBehaviour {

    public string encounterText;
    public List<DialogueOption> dialogueOptions = new List<DialogueOption>();
    public int numberOfDialogue = 0;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        print(other.name);
        PlayerParty encounter = other.gameObject.GetComponentInParent<PlayerParty>();
        encounter.Encounter(encounterText, dialogueOptions, gameObject);
    }

    public void AddDialogueOption()
    {
        DialogueOption option = new DialogueOption();
        dialogueOptions.Add(option);
    }

    public void RemoveDialogueOption()
    {
        DialogueOption option = dialogueOptions[dialogueOptions.Count - 1];
        dialogueOptions.Remove(dialogueOptions[dialogueOptions.Count - 1]);
    }
}
