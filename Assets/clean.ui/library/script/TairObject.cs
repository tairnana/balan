using UnityEngine;
using System.Collections;

public class TairObject : MonoBehaviour {
    [HideInInspector]
    public GameObject go;
    [HideInInspector]
    public Transform trans;
    [HideInInspector]

    void Awake() {
        PrimInit();
    }

    protected void PrimInit() {
        go = this.gameObject;
        trans = this.transform;
    }



}