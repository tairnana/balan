using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LogGuy : MonoBehaviour {
    #region /:: Functions ::/
    public static LogGuy FindMe() {
        return GameObject.Find("+LogGuy").GetComponent<LogGuy>();
    }
    IEnumerator AutoDestruct() {
        while(true) {
            Log.RemoveAt(0);
            yield return new WaitForSeconds(0.66f);
        }
    }
    public void Push(string s) {
        Log.Add(s);
    }
    public void Push(int s) {
        Log.Add("" + s);
    }
    public void Push(float s) {
        Log.Add("" + s);
    }
    public void Clear() {
        Log.Clear();
    }
    #endregion
    
    void OnGUI() {
        GUI.contentColor = Color.cyan;
        for(int i = 0; i < Log.Count; i++) {
            GUI.Label(new Rect(0 , i * 22 , Screen.width , 22) , Log[i]);
		}
    }
    
    void Update() {
        if(Log.Count * 22 > Screen.height) {
            Log.RemoveAt(0);
        }
    }
    
    private int lineMax = 60;
    private int line = 0;
    private float cd = 3;
    private List<string> Log = new List<string>();
}
