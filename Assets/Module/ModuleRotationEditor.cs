using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ModuleRotation))]
public class ModuleRotationEditor : Editor {
    SerializedProperty direction;
    SerializedProperty rotation;

    private void OnEnable() {
        direction = serializedObject.FindProperty("direction");
        rotation = serializedObject.FindProperty("m_LocalRotation");
    }

    public override void OnInspectorGUI() {

        ModuleRotation conn = (ModuleRotation)target;
        serializedObject.Update();

        EditorGUILayout.LabelField("Currently pointing to", EditorStyles.boldLabel);
        EditorGUILayout.LabelField(conn.GetDirection().ToString());
        serializedObject.ApplyModifiedProperties();

        EditorGUILayout.LabelField("Debug buttons", EditorStyles.boldLabel);
        if (GUILayout.Button("Update direction")) {
            conn.UpdateDirection();
        }
        if (GUILayout.Button("Rotate clockwise")) {
            conn.RotateClockwise();
        }
        if (GUILayout.Button("Rotate anticlockwise")) {
            conn.RotateAnticlockwise();
        }

    }
}
