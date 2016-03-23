using UnityEngine;
using System.Collections;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;

[Node (false, "Dialogue/DialogueNode")]
public class DialogueNode : Node {

    public const string ID = "Dialogue Node";
    public override string GetID { get { return ID; } }

    public DialogueOption option = new DialogueOption();

    public override Node Create(Vector2 pos)
    {
        DialogueNode node = CreateInstance<DialogueNode>();
        node.rect = new Rect(pos.x, pos.y, 300, 100);
        node.name = "Dialogue Node";

        node.CreateInput("From Dialogue", "DialogueOption");
        node.CreateOutput("To Dialogue", "DialogueOption");

        return node;
    }

    protected internal override void NodeGUI()
    {
        option.dialogueText = GUILayout.TextArea(option.dialogueText);

        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical();

        Inputs[0].DisplayLayout();

        GUILayout.EndVertical();
        GUILayout.BeginVertical();

        Outputs[0].DisplayLayout();

        GUILayout.EndVertical();
        GUILayout.EndHorizontal();
    }

    public override bool Calculate()
    {
        if (!allInputsReady())
            return false;
        //Outputs[0].SetValue<float>(Inputs[0].GetValue<float>() * 5);
        return true;
    }

    


}
