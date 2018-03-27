using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction {
    N = 0, E = 270, S = 180, W = 90
}


abstract public class AbstractRotation : MonoBehaviour {

    [SerializeField]
    private Direction direction = Direction.N;
    private void OnValidate() {
        UpdateDirection();
    }


    internal Direction GetDirection() {
        return direction;
    }

    internal virtual void UpdateDirection() {
        float rotation = transform.eulerAngles.z;
        rotation = rotation % 360.0f;
        direction = (Direction)(Mathf.Round(rotation / 90.0f) * 90);
    }

    internal virtual void RotateClockwise() {
        int rotation = (int)direction - 90;
        if (rotation < 0.0f) rotation = rotation + 360;
        direction = (Direction)rotation;
        transform.eulerAngles = new Vector3(0.0f, 0.0f, (int)direction);
    }

    internal virtual void RotateAnticlockwise() {
        int rotation = (int)direction + 90;
        if (rotation >= 360.0f) rotation = rotation - 360;
        direction = (Direction)rotation;
        transform.eulerAngles = new Vector3(0.0f, 0.0f, (int)direction);
    }
}
