using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ConnectorRotation))]
public class ConnectorRotationEditor : Editor {
    SerializedProperty direction;
    SerializedProperty rotation;

    private void OnEnable() {
        direction = serializedObject.FindProperty("direction");
        rotation = serializedObject.FindProperty("m_LocalRotation");
    }

    public override void OnInspectorGUI() {

        

       
        ConnectorRotation conn = (ConnectorRotation)target;
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

    /*
    public int selGridInt = 0;
    public string[] selStrings = new string[] {"NW","N","NE","W","BLANK","E","SW","S","SE" };
    Dictionary<int, Direction> dMap = new Dictionary<int, Direction>();
    

    private void OnEnable() {
        dMap.Add(0, Direction.NW);
        dMap.Add(1, Direction.N);
        dMap.Add(2, Direction.NE);
        dMap.Add(3, Direction.W);
        dMap.Add(4, Direction.E);
        dMap.Add(5, Direction.SW);
        dMap.Add(6, Direction.S);
        dMap.Add(7, Direction.SE);
        connectorDirection = serializedObject.FindProperty("direction");
    }

    public override void OnInspectorGUI() {
        serializedObject.Update();
        EditorGUILayout.PropertyField(connectorDirection);

        GUILayout.BeginVertical("Box");
        
        selGridInt = GUILayout.SelectionGrid(selGridInt, selStrings, 3);
    }
    */
}