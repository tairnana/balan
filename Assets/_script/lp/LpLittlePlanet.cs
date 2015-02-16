using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LpLittlePlanet : MonoBehaviour {

    #region / Class /
    public UIState ui_state;
    public Transform[] predefined_position;

    void Awake(){
        Application.targetFrameRate = 60;
    }

    void Start(){
        foreach(Transform t in predefined_position){
            lp_position.Add(t.name,t);
        }
    }
    #endregion

    #region / META /
    [System.Flags]
    public enum UIState{
        Main,
        Battle,
        Shop,
        Research,
        EnergyManagement,
        Terraform,
        Tutorial
    }
    private Dictionary<string,Transform> lp_position = new Dictionary<string, Transform>();
    #endregion

    #region / Function /
    public Vector3 GetPresetPosition(string name){
        return lp_position[name].position;
    }
    #endregion

    #region / UI /
    IEnumerator UI_Main(){
        while(ui_state == UIState.Main){

            yield return 0;
        }
        ChangeUI();
    }

    private void ChangeUI(){
        StartCoroutine("UI_"+ui_state.ToString());
    }
    #endregion

}
