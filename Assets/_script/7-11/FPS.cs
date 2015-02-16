using UnityEngine;
using System.Collections;

public class FPS : MonoBehaviour {

    string fps_to_show = "";
    float fps;

	void Start () {
        StartCoroutine(FPSCount());
	}
	IEnumerator FPSCount(){
        while(true){
            fps_to_show  = ""+(int)fps;
            yield return new WaitForSeconds(0.5f);
        }

    }
	void Update () {
        fps = 1f/Time.deltaTime;
	}
    void OnGUI(){
        GUI.Button(new Rect(0,0,66,22),fps_to_show);
    }
}
