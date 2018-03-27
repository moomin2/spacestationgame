using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleCollision : MonoBehaviour {

    [SerializeField]
    private GameObject graphic = null;
    [SerializeField]
    private Color overlapColorTint = Color.magenta;

    private Color initialColorTint = Color.white;
    private Material initialMaterial = null;

    void OnAwake() {
        initialColorTint = graphic.GetComponent<Renderer>().material.color;
    }

    void Start() {
        initialColorTint = graphic.GetComponent<Renderer>().material.color;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        graphic.GetComponent<Renderer>().material.SetColor("_Color", overlapColorTint);
    }

    void OnCollisionExit2D(Collision2D collision) {
        graphic.GetComponent<Renderer>().material.SetColor("_Color", initialColorTint);
    }
}
