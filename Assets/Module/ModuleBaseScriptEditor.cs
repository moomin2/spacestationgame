using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



[CustomEditor(typeof(ModuleBaseScript))]
public class ModuleBaseScriptEditor : Editor {
    SerializedProperty connectors;

    private void OnEnable() {
        connectors = serializedObject.FindProperty("connectors");
    }

    public override void OnInspectorGUI() {
        serializedObject.Update();
        ModuleBaseScript mBase = (ModuleBaseScript)target;

        EditorGUILayout.LabelField("Connectors");

        List<GameObject> conns = mBase.GetConnectors();
        foreach (GameObject conn in conns) {
            EditorGUILayout.BeginHorizontal();
            EditorGUIUtility.labelWidth = 0.001f;
            bool enabled = EditorGUILayout.Toggle(conn.activeSelf);
            conn.SetActive(enabled);

            EditorGUIUtility.fieldWidth = 5.0f;
            EditorGUIUtility.labelWidth = 5.0f;
            EditorGUILayout.LabelField(conn.GetComponent<ConnectorRotation>().GetDirection().ToString());
            EditorGUIUtility.labelWidth = 100.0f;
            EditorGUIUtility.fieldWidth = 100.0f;

            EditorGUILayout.ObjectField(conn, typeof(GameObject), true);


            EditorGUILayout.EndHorizontal();
        }

        serializedObject.ApplyModifiedProperties();

        if (GUILayout.Button("Find attached connectors")) {
            mBase.FindConnectors();
            serializedObject.ApplyModifiedProperties();
        }

        

        /*
        serializedObject.Update();

        EditorGUILayout.PropertyField(northConnector);
        EditorGUILayout.PropertyField(southConnector);
        EditorGUILayout.PropertyField(eastConnector);
        EditorGUILayout.PropertyField(westConnector);
        EditorGUILayout.PropertyField(direction);
        

        serializedObject.ApplyModifiedProperties();
        
        EditorGUILayout.BeginVertical("box");


        
        Dictionary<Direction, bool> connectors = mBase.GetConnectors4Editor();

        Toggle("North", Direction.N, connectors);

        EditorGUILayout.BeginHorizontal();
        {
            Toggle("West", Direction.W, connectors);
            Toggle("East", Direction.E, connectors);
        }
        EditorGUILayout.EndHorizontal();
        Toggle("South", Direction.S, connectors);
        EditorGUILayout.EndHorizontal();


        mBase.SetActiveConnectors(connectors);
       

        EditorGUILayout.LabelField("Debug buttons");
        if (GUILayout.Button("Rotate clockwise")) {
            mBase.RotateClockwise();
        }
        if (GUILayout.Button("Rotate anticlockwise")) {
            mBase.RotateAnticlockwise();
        }
         */
    }



}
