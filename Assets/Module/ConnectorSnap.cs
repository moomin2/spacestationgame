using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectorSnap : MonoBehaviour {

    [SerializeField]
    private bool connected = false;

    void OnCollisionEnter2D(Collision2D collision){
        Direction otherDir = collision.gameObject.GetComponent<ConnectorRotation>().GetDirection();
        Direction myDir = gameObject.GetComponent<ConnectorRotation>().GetDirection();
        if (ValidDirections(myDir, otherDir)) {
            GameObject connectToModule = collision.transform.parent.gameObject;
            Vector3 connectorPosition = collision.transform.position;
            transform.parent.GetComponent<ModuleControl>().Connect(connectToModule, connectorPosition, myDir);
            connected = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision) {
        if (connected) {
            GameObject disconnectFrom = collision.transform.parent.gameObject;
            transform.parent.GetComponent<ModuleControl>().Disconnect(disconnectFrom);
            connected = false;
        }
    }

    private bool ValidDirections(Direction myDirection, Direction OtherDirection) {
        Debug.Log(Mathf.Abs((int)(myDirection) - (int)(OtherDirection)));
        if (Mathf.Abs((int)(myDirection) - (int)(OtherDirection)) == 180) return true;
        return false;
    } 


}
