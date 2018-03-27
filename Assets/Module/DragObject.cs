using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour {

    void OnMouseDrag(){
        Vector3 distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        Vector3 pos_move = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen.z));
        transform.position = new Vector3(pos_move.x, pos_move.y, transform.position.z);
    }

    void OnMouseUp() {
        transform.GetComponent<ModuleControl>().Snap();
    }

    void OnMouseDown() {
        transform.GetComponent<ModuleControl>().CanConnect();
    }
}
