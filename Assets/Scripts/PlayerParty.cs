using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerParty : Party {

    public DialogueScript dialogue;

	// Update is called once per frame
	void Update () {
	
	}

    public void Encounter(string encounterText, List<DialogueOption> dialogueOptions, GameObject encounteredObject)
    {
        dialogue.dialogueText.text = encounterText;
        dialogue.gameObject.SetActive(true);
        dialogue.encounteredObject = encounteredObject;
        foreach (DialogueOption option in dialogueOptions)
        {
            dialogue.AddDialogueOption(option);
        }
    }
}
