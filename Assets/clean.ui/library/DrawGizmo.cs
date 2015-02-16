using UnityEngine;
using System.Collections;

public class DrawGizmo : MonoBehaviour {
    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(collider2D.bounds.center , collider2D.bounds.size);
    }
}
