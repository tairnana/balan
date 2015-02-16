using UnityEngine;
using System.Collections;

public class LpLookAt : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.LookAt(target);
	}

    public Transform target;
}
