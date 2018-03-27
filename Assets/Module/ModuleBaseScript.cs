using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleBaseScript : MonoBehaviour {
    [SerializeField]
    private List<GameObject> connectors = new List<GameObject>();

    internal void FindConnectors() {
        connectors.Clear();
        foreach(ConnectorRotation conn in transform.GetComponentsInChildren<ConnectorRotation>()) {
            connectors.Add(conn.gameObject);
        }
        Debug.Log(connectors.Count);
    }

    internal List<GameObject> GetConnectors() {
        return connectors;
    }

}
