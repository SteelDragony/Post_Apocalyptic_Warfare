using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DialogueOption {

    public string buttonText = "Scavenge";
    public string resultText = "You found some ammo";
    public int ammoReward = 0;
    public bool endDialogue = false;
    public List<DialogueOption> dialogueOptions = new List<DialogueOption>();

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
