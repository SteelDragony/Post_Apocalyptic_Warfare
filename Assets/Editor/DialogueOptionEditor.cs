using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(DialogueOption))]
public class DialogueOptionEditor : Editor {

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

        if (myTarget.numberOfDialogue > myTarget.dialogueOptions.Count)
        {
            myTarget.AddDialogueOption();
            //myTarget.dialogueOptions.Add(myTarget.gameObject.AddComponent<DialogueOption>());
        }
        else if (myTarget.numberOfDialogue < myTarget.dialogueOptions.Count)
        {
            myTarget.RemoveDialogueOption();
            //DestroyImmediate(myTarget.dialogueOptions[myTarget.dialogueOptions.Count - 1], false);
            //myTarget.dialogueOptions.Remove(myTarget.dialogueOptions[myTarget.dialogueOptions.Count - 1]);
        }
        foreach (DialogueOption dialogue in myTarget.dialogueOptions)
        {
            //dialogue.resultText = EditorGUILayout.TextArea(dialogue.resultText);
        }

    }
}
