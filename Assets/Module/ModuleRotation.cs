using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleRotation : AbstractRotation {

  
    private void UpdateConnRotations() {
        foreach (GameObject obj in transform.GetComponent<ModuleBaseScript>().GetConnectors()) {
            obj.GetComponent<ConnectorRotation>().UpdateDirection();
        }
    }

    internal override void UpdateDirection() {
        base.UpdateDirection();
        UpdateConnRotations();
    }

    internal override void RotateClockwise() {
        base.RotateClockwise();
        UpdateConnRotations();
    }

    internal override void RotateAnticlockwise() {
        base.RotateAnticlockwise();
        UpdateConnRotations();
    }
}
