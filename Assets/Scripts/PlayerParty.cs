using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerParty : Party {

    public DialogueScript Dialogue;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Encounter(List<string> dialogueTexts, List<DialogueOption> dialogueOptions)
    {
        Dialogue.gameObject.SetActive(true);
        Dialogue.SetDialogueText(dialogueTexts[0]);
        foreach (DialogueOption option in dialogueOptions)
        {
            Dialogue.AddDialogueOption(option);
        }
    }
}
