using System.IO;
using UnityEditor;
using UnityEngine;
using System.Collections;

public class LpMenuItem : Editor {

    [MenuItem("LittlePlanet/Update CuiBtn(no script)")]
    static void Make2() {
        foreach(GameObject ca0 in Selection.gameObjects) {
            if(!ca0.GetComponent<Collider>()) {
                ca0.AddComponent<Collider2D>().isTrigger = true;
            } else {
                DestroyImmediate(ca0.GetComponent<Collider>());
                ca0.AddComponent<Collider2D>().isTrigger = true;
            }


            Transform btn_bg = ca0.transform.Find("btn.up");

            Collider2D col = new Collider2D();
            //col.bounds = btn_bg.renderer.bounds;

            
            //ca0.AddComponent<Collider2D>().bounds = btn_bg.renderer.bounds;
            ca0.GetComponent<Collider2D>().isTrigger = true;
            
            //Clear//
            DestroyImmediate(col);
            Debug.Log("Button " + Selection.activeTransform.gameObject.name + " made!!");
            
        }
    }
}
