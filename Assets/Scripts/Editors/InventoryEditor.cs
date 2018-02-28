using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor (typeof(Inventory))]
public class InventoryEditor : Editor {

    private SerializedProperty images;
    private SerializedProperty items;

    private bool[] Show = new bool[4];

    private const string i = "items";
    private const string im = "images";

    private void OnEnable()
    {
        images = serializedObject.FindProperty(im);
        items = serializedObject.FindProperty(i);
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        for (int j = 0; j < 4; j++)
        {
            SlotGUI(j);
        }

        serializedObject.ApplyModifiedProperties();
    }

    private void SlotGUI(int index)
    {
        EditorGUILayout.BeginVertical(GUI.skin.box);
        EditorGUI.indentLevel++;

        Show[index] = EditorGUILayout.Foldout(Show[index],"Item slot " + index);

        if (Show[index])
        {
            EditorGUILayout.PropertyField(images.GetArrayElementAtIndex(index));
            EditorGUILayout.PropertyField(items.GetArrayElementAtIndex(index));
        }

        EditorGUI.indentLevel--;
        EditorGUILayout.EndVertical();
    }
}
