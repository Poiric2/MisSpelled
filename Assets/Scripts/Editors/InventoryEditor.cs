using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor (typeof(Inventory))]
public class InventoryEditor : Editor {

    private SerializedProperty images;
    private SerializedProperty items;
    private SerializedProperty highlights;
    private SerializedProperty primes;
    private SerializedProperty texts;

    private bool[] Show;

    private const string i = "items";
    private const string im = "images";
    private const string h = "highlights";
    private const string p = "primes";
    private const string t = "texts";

    private void OnEnable()
    {
        images = serializedObject.FindProperty(im);
        items = serializedObject.FindProperty(i);
        highlights = serializedObject.FindProperty(h);
        primes = serializedObject.FindProperty(p);
        texts = serializedObject.FindProperty(t);
        Show = new bool[Inventory.inventorySize];
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        for (int j = 0; j < Inventory.inventorySize; j++)
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
            EditorGUILayout.PropertyField(primes.GetArrayElementAtIndex(index));
            EditorGUILayout.PropertyField(highlights.GetArrayElementAtIndex(index));
            EditorGUILayout.PropertyField(items.GetArrayElementAtIndex(index));
            EditorGUILayout.PropertyField(texts.GetArrayElementAtIndex(index));
        }

        EditorGUI.indentLevel--;
        EditorGUILayout.EndVertical();
    }
}