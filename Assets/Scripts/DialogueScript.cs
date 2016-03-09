using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DialogueScript : MonoBehaviour {

    public Button buttonPrefab;
    public Text dialogueText;
    public PlayerParty playerParty;
    public List<Button> buttons;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetDialogueText(string dialogue)
    {
        dialogueText.text = dialogue;
    }

    public void AddDialogueOption(DialogueOption dialogueOption)
    {
        Button dialogueButton = Instantiate<Button>(buttonPrefab);
        buttons.Add(dialogueButton);
        dialogueButton.transform.Translate(0, -40 * buttons.IndexOf(dialogueButton), 0);
        dialogueButton.transform.SetParent(gameObject.transform, false);
        dialogueButton.GetComponentInChildren<Text>().text = dialogueOption.buttonText;
        dialogueButton.onClick.AddListener(delegate { ClickedButton(dialogueOption); });
    }

    public void ClickedButton(DialogueOption dialogueOption)
    {
        dialogueText.text = dialogueOption.resultText;
        playerParty.ammonution += dialogueOption.ammoReward;
        foreach (Button button in buttons)
        {
            print(button);
            Destroy(button.gameObject);
        }
        buttons.Clear();
        gameObject.SetActive(!dialogueOption.endDialogue);
        print(dialogueOption.dialogueOptions.Count);
        if (dialogueOption.dialogueOptions.Count != 0)
        {
            print("foundOption");
            AddDialogueOption(dialogueOption.dialogueOptions[0]);
        }
    }
}
