using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ToDoGridController))]
public class ToDoGridControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        ToDoGridController toDoGridController = (ToDoGridController)target;
        if (GUILayout.Button("Set Sequence"))
        {
            toDoGridController.SetSequence();
        }

    }
}
