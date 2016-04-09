using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DialogueScript : MonoBehaviour {

    public Button buttonPrefab;
    public Text dialogueText;
    public PlayerParty playerParty;
    public GameManager gameManager;
    public List<Button> buttons;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        Time.timeScale = 0;
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
        dialogueText.text = dialogueOption.dialogueText;
        playerParty.inventory.ChangeAmmoAmount(Inventory.AmmoTypes.rifle, dialogueOption.ammoReward);
        foreach (Button button in buttons)
        {
            print(button);
            Destroy(button.gameObject);
        }
        buttons.Clear();
        if (dialogueOption.dialogueOptions.Count != 0)
        {
            foreach (DialogueOption i in dialogueOption.dialogueOptions)
            {
                AddDialogueOption(i);
            }
        }
        else
        {
            Time.timeScale = 1;
            gameObject.SetActive(false);
            if(dialogueOption.startCombat)
            {
                gameManager.EnterCombatMap(playerParty.units, playerParty.units);
            }
        }
    }
}
