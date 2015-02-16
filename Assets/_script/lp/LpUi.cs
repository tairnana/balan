using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LpUi : MonoBehaviour
{

    public LpLittlePlanet lp;


    public Camera ui_cam;
    public bool accept_input = true;
    public int input_layer;
    public Color[] ui_color;
    
    void Start()
    {
        StartCoroutine(Do());

    }
    
    IEnumerator Do()
    {
        while (true)
        {
            #if UNITY_EDITOR
            if(Input.GetMouseButtonDown(0)) {
                ray = ui_cam.ScreenPointToRay(Input.mousePosition);
                this.Cast();
            } else if(Input.GetMouseButton(0)) {
                ray = ui_cam.ScreenPointToRay(Input.mousePosition);
                this.Cast();
            } else if(Input.GetMouseButtonUp(0)) {
                ray = ui_cam.ScreenPointToRay(Input.mousePosition);
                this.ClearManaged();
                this.Fire();
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
            yield return 0;
        }
        
    }


    #region / Ray / 
    protected Touch touch;
    protected Ray ray;
    protected RaycastHit hit;
    
    protected void UpdateRay()
    {
        ray = ui_cam.ScreenPointToRay(touch.position);
    }
    
    protected void Cast()
    {
        if (Physics.Raycast(ray, out hit))
        {
            #region Button
            if (hit.collider.gameObject.GetComponent<CuiBtn>())
            {
                CuiBtn btn = hit.collider.gameObject.GetComponent<CuiBtn>();
                if (!ignoredList.Contains(btn))
                {
                    if (btn.layer == input_layer)
                    {
                        btn.Down();
                    }
                    this.AddToManaged(btn);
                }// check ignored //
            }
            #endregion
        }
    }
    
    protected void Fire()
    {
        if (Physics.Raycast(ray, out hit))
        {
            #region Button
            if (hit.collider.gameObject.GetComponent<CuiBtn>())
            {
                CuiBtn btn = hit.collider.gameObject.GetComponent<CuiBtn>();
                if (!ignoredList.Contains(btn))
                {
                    if (btn.layer == input_layer)
                    {
                        btn.Activate();
                    }
                }// check ignored //
            }
            #endregion
        }
    }
    #endregion
    protected void AddToManaged(CuiBtn btn)
    {
        if (!managedButton.Contains(btn))
        {
            managedButton.Add(btn);
        }
    }
    
    protected void ClearManaged()
    {
        foreach (CuiBtn btn in managedButton)
        {
            btn.Up();
        }
        managedButton.Clear();
    }
    
    public List<CuiBtn> ignoredList = new List<CuiBtn>();
    private List<CuiBtn> managedButton = new List<CuiBtn>();
}
