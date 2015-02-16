using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TairInputManager : TairObject {

    public bool acceptInput = true;

    public List<TairButton> ignoredList = new List<TairButton>();
    private List<TairButton> managedButton = new List<TairButton>();

    public Camera camera;

    public bool isPause = false;
    public Touch touch;

    private int inputLayer = 0;

    private GameObject tapFx;

    #region /:: Functions ::/
    /*  Input Layer
     *  0 - default
     *  10 - popup
     *  20 - popup
     *  30 - popup
     * */
    void Start() {
        tapFx = trans.GetChild(0).gameObject;
        tapFx.particleSystem.enableEmission = false;
        switch(Application.loadedLevelName) {
            case "00Splash":
            case "01Main":
                StartCoroutine(Custom());
                break;
            case "02Play":
                StartCoroutine(Play());
                break;
            case "03Custom":
                StartCoroutine(Custom());
                break;
        }
    }
    public void SetInputLayer(int layer) {
        inputLayer = layer;
    }
    public int GetInputLayer() {
        return inputLayer;
    }
    #endregion
    #region /:: Input ::/
    private TairButton cacchedBtn;

    IEnumerator Play() {
        while(true) {
            if(!isPause && acceptInput) {
#if UNITY_EDITOR
                if(Input.GetMouseButtonDown(0)) {
                    ray = camera.ScreenPointToRay(Input.mousePosition);
                    this.Cast();
                    tapFx.transform.position = camera.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward;
                    tapFx.particleSystem.enableEmission = true;
                } else if(Input.GetMouseButton(0)) {
                    ray = camera.ScreenPointToRay(Input.mousePosition);
                    this.Cast();
                    tapFx.transform.position = camera.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward;
                    tapFx.particleSystem.enableEmission = true;
                } else if(Input.GetMouseButtonUp(0)) {
                    ray = camera.ScreenPointToRay(Input.mousePosition);
                    this.ClearManaged();
                    this.Fire();
                    tapFx.particleSystem.enableEmission = false;
                }
#endif
#if UNITY_ANDROID || UNITY_IPHONE
                if(Input.touchCount > 0) {
                    for(int i = 0; i < Input.touches.Length; i++) {
                        touch = Input.touches[i];
                        switch(touch.phase) {
                            case TouchPhase.Began:
                                this.UpdateRay();
                                this.Cast();
                                break;
                            case TouchPhase.Moved:
                                this.UpdateRay();
                                this.Cast();
                                break;
                            case TouchPhase.Stationary:
                                this.Cast();
                                break;
                            case TouchPhase.Ended:
                                this.UpdateRay();
                                this.ClearManaged();
                                this.Fire();
                                break;
                            case TouchPhase.Canceled:
                                this.ClearManaged();
                                break;
                        }
                    }
                }//Input
#endif
            }//isPause
            yield return 0;
        }
    }

    IEnumerator Custom() {
        while(true) {
            if(acceptInput) {
#if UNITY_EDITOR
                if(Input.GetMouseButtonDown(0)) {
                    ray = camera.ScreenPointToRay(Input.mousePosition);
                    this.Cast();
                    tapFx.transform.position = camera.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward;
                    tapFx.particleSystem.enableEmission = true;
                } else if(Input.GetMouseButton(0)) {
                    ray = camera.ScreenPointToRay(Input.mousePosition);
                    this.Cast();
                    tapFx.transform.position = camera.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward;
                    tapFx.particleSystem.enableEmission = true;
                } else if(Input.GetMouseButtonUp(0)) {
                    ray = camera.ScreenPointToRay(Input.mousePosition);
                    this.ClearManaged();
                    this.Fire();
                    tapFx.particleSystem.enableEmission = false;
                }
#endif
#if UNITY_ANDROID || UNITY_IPHONE
                if(Input.touchCount > 0) {
                    for(int i = 0; i < Input.touches.Length; i++) {
                        touch = Input.touches[i];
                        switch(touch.phase) {
                            case TouchPhase.Began:
                                this.UpdateRay();
                                this.Cast();
                                break;
                            case TouchPhase.Moved:
                                this.UpdateRay();
                                this.Cast();
                                break;
                            case TouchPhase.Stationary:
                                this.Cast();
                                break;
                            case TouchPhase.Ended:
                                this.UpdateRay();
                                this.ClearManaged();
                                this.Fire();
                                break;
                            case TouchPhase.Canceled:
                                this.ClearManaged();
                                break;
                        }
                    }
                }//Input
#endif
            }
            yield return 0;
        }
    }

    protected Ray ray;
    protected RaycastHit hit;
    protected void UpdateRay() {
        ray = camera.ScreenPointToRay(touch.position);
    }
    protected void Cast() {
        if(Physics.Raycast(ray , out hit)) {
            #region Button
            if(hit.collider.gameObject.GetComponent<TairButton>()) {
                TairButton btn = hit.collider.gameObject.GetComponent<TairButton>();
                if(!ignoredList.Contains(btn)) {
                    if(btn.layer == inputLayer) {
                        btn.Down();
                    }
                    this.AddToManaged(btn);
                }// check ignored //
            }
            #endregion
        }
        tapFx.transform.position = camera.ScreenToWorldPoint(touch.position) + Vector3.forward;
        tapFx.particleSystem.enableEmission = true;
    }
    protected void Fire() {
        if(Physics.Raycast(ray , out hit)) {
            #region Button
            if(hit.collider.gameObject.GetComponent<TairButton>()) {
                TairButton btn = hit.collider.gameObject.GetComponent<TairButton>();
                if(!ignoredList.Contains(btn)) {
                    if(btn.layer == inputLayer) {
                        btn.Activate();
                    }
                }// check ignored //
            }
            #endregion
        }
        tapFx.particleSystem.enableEmission = false;
    }
    protected void AddToManaged(TairButton btn) {
        if(!managedButton.Contains(btn)) {
            managedButton.Add(btn);
        }
    }
    protected void ClearManaged() {
        foreach(TairButton btn in managedButton) {
            btn.Up();
        }
        managedButton.Clear();
    }
    #endregion

}