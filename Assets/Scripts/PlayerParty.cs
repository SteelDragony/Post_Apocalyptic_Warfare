using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerParty : Party {

    public DialogueScript Dialogue;

	// Update is called once per frame
	void Update () {
	
	}

    public void Encounter(string encounterText, List<DialogueOption> dialogueOptions)
    {
        Dialogue.dialogueText.text = encounterText;
        Dialogue.gameObject.SetActive(true);
        foreach (DialogueOption option in dialogueOptions)
        {
            Dialogue.AddDialogueOption(option);
        }
    }
}
