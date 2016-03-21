using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(InteractableArea))]
public class InteractableAreaEditor : Editor {

    public override void OnInspectorGUI()
    {
        InteractableArea myTarget = (InteractableArea)target;
        DrawDefaultInspector();
        /*
        for (int i = 0; i < myTarget.numberOfDialogue - myTarget.dialogueOptions.Count; i++)
        {
            myTarget.dialogueOptions.Add(new DialogueOption());
        }
        */
        
        if(myTarget.numberOfDialogue > myTarget.dialogueOptions.Count)
        {
            myTarget.AddDialogueOption();
            //myTarget.dialogueOptions.Add(myTarget.gameObject.AddComponent<DialogueOption>());
        }
        else if(myTarget.numberOfDialogue < myTarget.dialogueOptions.Count)
        {
            myTarget.RemoveDialogueOption();
            //DestroyImmediate(myTarget.dialogueOptions[myTarget.dialogueOptions.Count - 1], false);
            //myTarget.dialogueOptions.Remove(myTarget.dialogueOptions[myTarget.dialogueOptions.Count - 1]);
        }
        foreach (DialogueOption dialogue in myTarget.dialogueOptions)
        {
            if (dialogue.numberOfDialogue > dialogue.dialogueOptions.Count)
            {
                dialogue.AddDialogueOption();
            }
            else if (dialogue.numberOfDialogue < dialogue.dialogueOptions.Count)
            {
                dialogue.RemoveDialogueOption();
            }
            foreach (DialogueOption dialogue2 in dialogue.dialogueOptions)
            {
                if (dialogue2.numberOfDialogue > dialogue2.dialogueOptions.Count)
                {
                    dialogue2.AddDialogueOption();
                }
                else if (dialogue2.numberOfDialogue < dialogue2.dialogueOptions.Count)
                {
                    dialogue2.RemoveDialogueOption();
                }
            }
        }
        
    }
}
