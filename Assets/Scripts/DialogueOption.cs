using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class DialogueOption{

    public string buttonText = "Scavenge";
    public string dialogueText = "You found some ammo";
    public int ammoReward = 0;
    public int numberOfDialogue = 0;
    public bool startCombat = false;
    public List<DialogueOption> dialogueOptions = new List<DialogueOption>();

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
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
