using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleControl : MonoBehaviour {
    private Transform newTransform = null;

    [SerializeField]
    private List<ModuleControl> connectedModules = new List<ModuleControl>();
    [SerializeField]
    private string FINDGRAPHIC = "Graphics";
    [SerializeField]
    private GameObject graphics = null;
    [SerializeField]
    private float gapBetweenModules = 0.2f;
    [SerializeField]
    private float moduleWidth = 5.0f;

    private bool willBeConnected = false;
    private bool snapPossible = false;
    private GameObject ghostMesh = null;
    

    private void FindGraphics() {
        if(!graphics) {
            graphics =transform.Find(FINDGRAPHIC).gameObject;
            if (!graphics) Debug.LogError("Couldn't find the graphic presentation of the module");
        }
    }

    private void Start() {
        FindGraphics();
    }

    private void OnEnable() {
        FindGraphics();
    }

    internal void Snap() {
        if (willBeConnected) {
            transform.position = ghostMesh.transform.position;
            Destroy(ghostMesh);
        }
        willBeConnected = false;
        snapPossible = false;
    }
	
    internal void CanConnect() {
        snapPossible = true;
    }

    internal void Connect(GameObject connectToModule, Vector3 connectorPosition, Direction dir) {
        connectedModules.Add(connectToModule.GetComponent<ModuleControl>());
        if (snapPossible && !willBeConnected) DrawGhostMesh(connectorPosition, dir, gapBetweenModules, moduleWidth);
        willBeConnected = true;
    }

    internal void Disconnect(GameObject disconnectFrom) {
        connectedModules.Remove(disconnectFrom.GetComponent<ModuleControl>());
        if (snapPossible && willBeConnected) Destroy(ghostMesh);
        willBeConnected = false;
    }

    private void DrawGhostMesh(Vector3 connectorPosition, Direction dir, float gapBetween, float moduleWidth) {
        ghostMesh = Instantiate(graphics);

        Vector3 pos = connectorPosition;
        pos.x = pos.x + (moduleWidth+gapBetween) * Mathf.Sin((int)dir * Mathf.PI / 180.0f);
        pos.y = pos.y - (moduleWidth+gapBetween) * Mathf.Cos((int)dir * Mathf.PI / 180.0f);
        ghostMesh.transform.rotation = graphics.transform.rotation;
        ghostMesh.transform.position = pos;
    }



}
