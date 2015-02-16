using UnityEngine;
using System.Collections;

public class Rotor : MonoBehaviour {

    public Vector3 rot_speed= new Vector3(0,10,0);
    private Transform trans;
    void Start() {
        trans = transform;
    }
    void Update() {
        trans.Rotate(rot_speed * Time.deltaTime);
    }
}
