using UnityEngine;
using System.Collections;

public class TairInput : MonoBehaviour
{
    public Camera main_cam;

    void Start()
    {
        StartCoroutine(Play());
    }

    IEnumerator Play()
    {
        while (true)
        {

#if UNITY_EDITOR
            if(Input.GetButtonDown("Fire1")) {
                this.Fire();
            }
#endif  
#if UNITY_ANDROID || UNITY_IPHONE
            if(Input.touchCount == 1){
                Touch touch = Input.GetTouch(0);
                switch(touch.phase){
                case TouchPhase.Ended:
                    this.Fire();
                    break;
                }
                
            }
#endif
            yield return 0;
        }
    }

    #region / BlackBox /
    private void Cast()
    {
        Ray ray = main_cam.ScreenPointToRay(Input.mousePosition);
        
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit))
        {

        }
    }

    private void Fire()
    {
        Ray ray = main_cam.ScreenPointToRay(Input.mousePosition);
        
        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit))
        {
            LpObject obj = hit.collider.gameObject.GetComponent<LpObject>();
            if (obj != null)
            {
                obj.Touched(hit);
            }
        }
    

    }
    #endregion
}
